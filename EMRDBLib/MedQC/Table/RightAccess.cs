// ***********************************************************
// 数据库访问层与用户相关数据的访问类.
// Creator:YangAiping  Date:2014-05-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using System.Data.OleDb;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    public class RightAccess : DBAccessBase
    {
        private static RightAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static RightAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new RightAccess();
                return m_Instance;
            }
        }

        /// <summary>
        /// 验证指定的用户账户及密码
        /// </summary>
        /// <param name="szUserID">用户ID</param>
        /// <param name="szOldPwd">旧密码</param>
        /// <param name="szNewPwd">新密码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short ModifyUserPwd(string szUserID, string szOldPwd, string szNewPwd)
        {
            if (szOldPwd == null || szOldPwd.Trim() == string.Empty)
                szOldPwd = string.Empty;

            //验证用户及密码
            short shRet = this.VerifyUser(szUserID, szOldPwd);
            if (shRet != SystemData.ReturnValue.OK)
                return shRet;

            if (szNewPwd == null || szNewPwd.Trim() == string.Empty)
                szNewPwd = string.Empty;

            if (szOldPwd.Trim() == szNewPwd.Trim())
                return SystemData.ReturnValue.OK;

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.EXCEPTION;

            if (szNewPwd != string.Empty)
                szNewPwd = GlobalMethods.Security.GetSummaryMD5(szNewPwd);

            DbParameter[] param = new DbParameter[2]
            {
             new DbParameter(SystemData.UserRightTable.USER_PWD, szNewPwd)
            ,new DbParameter( SystemData.UserRightTable.USER_ID, szUserID)
            };
            string szTable = SystemData.DataTable.USER_RIGHT;
            string szField = string.Format("{0}={1}", SystemData.UserRightTable.USER_PWD, base.ParaHolder(SystemData.UserRightTable.USER_PWD));
            string szCondition = string.Format("{0}={1} AND {2}='MEDQC'", SystemData.UserRightTable.USER_ID, base.ParaHolder(SystemData.UserRightTable.USER_ID)
                , SystemData.UserRightTable.RIGHT_TYPE);
            string szSQL = string.Format(SystemData.SQL.UPDATE, szTable, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref param);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.VerifyUser", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return (nCount > 0) ? SystemData.ReturnValue.OK : SystemData.ReturnValue.ACCESS_ERROR;
        }
        /// <summary>
        /// 验证指定的用户账户及密码
        /// </summary>
        /// <param name="szUserID">用户ID</param>
        /// <param name="szUserPwd">密码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short VerifyUser(string szUserID, string szUserPwd)
        {
            //获取数据库中的用户及密码
            if (GlobalMethods.Misc.IsEmptyString(szUserID))
            {
                LogManager.Instance.WriteLog("EMRDBAccess.VerifyUser", "用户ID不能为空!");
                return SystemData.ReturnValue.RES_NO_FOUND;
            }

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.EXCEPTION;

            //先获取用户信息
            string szField = SystemData.UserRightTable.USER_PWD;
            string szCondition = string.Format("{0}={1} AND {2}='{3}'"
                , SystemData.UserRightTable.USER_ID
                , base.ParaHolder(SystemData.UserRightTable.USER_ID)
                , SystemData.UserRightTable.RIGHT_TYPE
                , "MEDQC");
            DbParameter[] param = new DbParameter[] { new DbParameter(SystemData.UserRightTable.USER_ID, szUserID) };
            string szTable = SystemData.DataTable.USER_RIGHT;
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);

            string szPwdText = null;
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text, ref param);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (!dataReader.IsDBNull(0))
                    szPwdText = dataReader.GetString(0).Trim();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.VerifyUser", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }

            //验证密码
            if (GlobalMethods.Misc.IsEmptyString(szPwdText))
            {
                if (GlobalMethods.Misc.IsEmptyString(szUserPwd))
                    return SystemData.ReturnValue.OK;
                else
                    return SystemData.ReturnValue.FAILED;
            }
            return (GlobalMethods.Security.GetSummaryMD5(szUserPwd) == szPwdText.ToUpper()) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.FAILED;
        }

        /// <summary>
        /// 查询获取指定的用户是否已配置权限
        /// </summary>
        /// <param name="szUserID">用户ID</param>
        /// <param name="rightType">用户权限类型</param>
        /// <param name="nCount">返回的记录数</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short ExistRightInfo(string szUserID, UserRightType rightType, ref int nCount)
        {
            if (GlobalMethods.Misc.IsEmptyString(szUserID))
                return SystemData.ReturnValue.PARAM_ERROR;

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}'AND {2}='{3}'"
                , SystemData.UserRightTable.USER_ID, szUserID
                , SystemData.UserRightTable.RIGHT_TYPE, UserRightBase.GetRightTypeName(rightType));
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, "COUNT(*)", SystemData.DataTable.USER_RIGHT, szCondition);

            nCount = 0;
            try
            {
                object objValue = base.MedQCAccess.ExecuteScalar(szSQL, CommandType.Text);
                if (objValue == null || objValue == System.DBNull.Value)
                    nCount = 0;
                if (!int.TryParse(objValue.ToString(), out nCount))
                    nCount = 0;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("RightAccess.ExistRightInfo", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 更新已有编辑器用户权限
        /// </summary>
        /// <param name="userRight">用户权限</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short UpdateUserRight(UserRightBase userRight)
        {
            if (userRight == null || GlobalMethods.Misc.IsEmptyString(userRight.UserID))
                return SystemData.ReturnValue.PARAM_ERROR;

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}'", SystemData.UserRightTable.RIGHT_CODE, userRight.GetRightCode());
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}'"
                , SystemData.UserRightTable.USER_ID, userRight.UserID
                , SystemData.UserRightTable.RIGHT_TYPE, UserRightBase.GetRightTypeName(userRight.RightType));
            string szTable = SystemData.DataTable.USER_RIGHT;
            string szSQL = string.Format(SystemData.SQL.UPDATE, szTable, szField, szCondition);

            int count = 0;
            try
            {
                count = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("RightAccess.UpdateUserRight", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return (count <= 0) ? SystemData.ReturnValue.RES_NO_FOUND : SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 保存用户权限
        /// </summary>
        /// <param name="userRight">用户权限</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveUserRight(UserRightBase userRight)
        {
            if (userRight == null || GlobalMethods.Misc.IsEmptyString(userRight.UserID))
                return SystemData.ReturnValue.PARAM_ERROR;

            int count = 0;
            short shRet = this.ExistRightInfo(userRight.UserID, userRight.RightType, ref count);
            if (shRet != SystemData.ReturnValue.OK)
                return shRet;
            if (count > 0)
                return this.UpdateUserRight(userRight);

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3}"
                , SystemData.UserRightTable.USER_ID, SystemData.UserRightTable.RIGHT_CODE
                , SystemData.UserRightTable.RIGHT_DESC, SystemData.UserRightTable.RIGHT_TYPE);
            string szValue = string.Format("'{0}','{1}','{2}','{3}'"
                , userRight.UserID, userRight.GetRightCode().Replace('0','1')
                , userRight.RightDesc, UserRightBase.GetRightTypeName(userRight.RightType));
            string szTable = SystemData.DataTable.USER_RIGHT;
            string szSQL = string.Format(SystemData.SQL.INSERT, szTable, szField, szValue);

            count = 0;
            try
            {
                count = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("RightAccess.SaveUserRight", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return (count > 0) ? SystemData.ReturnValue.OK : SystemData.ReturnValue.ACCESS_ERROR;
        }
        /// <summary>
        /// 获取编辑器指定用户权限
        /// </summary>
        /// <param name="szUserID">用户ID</param>
        /// <param name="rightType">权限类型</param>
        /// <param name="userRight">用户权限信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetUserRight(string szUserID, UserRightType rightType, ref UserRightBase userRight)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2}"
                , SystemData.UserRightTable.USER_ID, SystemData.UserRightTable.RIGHT_CODE
                , SystemData.UserRightTable.RIGHT_DESC);
            string szTable = SystemData.DataTable.USER_RIGHT;
            string szCondition = string.Format("{0}='{1}' and ({2}='{3}' or {2}='MRQC')"
                , SystemData.UserRightTable.USER_ID, szUserID
                , SystemData.UserRightTable.RIGHT_TYPE, UserRightBase.GetRightTypeName(rightType));
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;

                userRight = UserRightBase.Create(rightType);
                userRight.UserID = dataReader.GetString(0).Trim();
                if (!dataReader.IsDBNull(2))
                    userRight.RightDesc = dataReader.GetString(2);
                if (!dataReader.IsDBNull(1))
                    userRight.SetRightCode(dataReader.GetString(1));
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("RightAccess.GetUserRight", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }


        /// <summary>
        /// 获取所有编辑器用户权限
        /// </summary>
        /// <param name="rightType">用户权限类型</param>
        /// <param name="lstUserRight">用户权限信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetUserRight(UserRightType rightType, ref List<UserRightBase> lstUserRight)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2}"
                , SystemData.UserRightTable.USER_ID, SystemData.UserRightTable.RIGHT_CODE
                , SystemData.UserRightTable.RIGHT_DESC);
            string szTable = SystemData.DataTable.USER_RIGHT;
            DbParameter[] param = new DbParameter[1]{new DbParameter(SystemData.UserRightTable.RIGHT_TYPE
                                                                 , UserRightBase.GetRightTypeName(rightType))};
            string szCondition = string.Format("{0}='{1}' or {0}='MRQC'", SystemData.UserRightTable.RIGHT_TYPE
                ,SystemData.UserRightTable.RIGHT_TYPE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text, ref param);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;

                if (lstUserRight == null)
                    lstUserRight = new List<UserRightBase>();
                lstUserRight.Clear();

                do
                {
                    UserRightBase userRight = UserRightBase.Create(rightType);
                    userRight.UserID = dataReader.GetString(0).Trim();
                    if (!dataReader.IsDBNull(2))
                        userRight.RightDesc = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(1))
                        userRight.SetRightCode(dataReader.GetString(1));
                    lstUserRight.Add(userRight);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("RightAccess.GetUserRight", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
    }
}
