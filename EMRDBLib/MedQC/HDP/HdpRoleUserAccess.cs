// ***********************************************************
// 数据库访问层与质检问题类型数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using EMRDBLib;
namespace EMRDBLib.DbAccess
{
    public class HdpRoleUserAccess : DBAccessBase
    {
        private static HdpRoleUserAccess m_Instance = null;
        public static HdpRoleUserAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new HdpRoleUserAccess();
                return m_Instance;
            }
        }

        #region 用户角色关联接口
        /// <summary>
        /// 管理平台,获取用户角色关联列表
        /// </summary>
        /// <param name="szRoleName"></param>
        /// <param name="lstHdpRole"></param>
        /// <returns></returns>
        public short GetHdpRoleUserList(string szUserID, ref List<HdpRoleUser> lstHdpRoleUser)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},A.{1},B.{2}"
                , SystemData.HdpRoleUserTable.USER_ID
                , SystemData.HdpRoleUserTable.ROLE_CODE
                , SystemData.HdpRoleUserTable.ROLE_NAME
                );
            string szTable = string.Format("{0} A, {1} B"
                , SystemData.DataTable.HDP_ROLE_USER_T, SystemData.DataTable.HDP_ROLE_T);
            string szCondition = string.Format(" B.STATUS = 1 And A.{0}=B.{1}"
                , SystemData.HdpRoleUserTable.ROLE_CODE, SystemData.HdpRoleTable.ROLE_CODE);
            if (!string.IsNullOrEmpty(szUserID))
            {
                szCondition = string.Format("{0} and A.{1}='{2}'"
                    , szCondition
                    , SystemData.HdpRoleUserTable.USER_ID, szUserID);
            }

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField
                  , szTable
                  , szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstHdpRoleUser == null)
                    lstHdpRoleUser = new List<HdpRoleUser>();
                do
                {
                    HdpRoleUser hdpRoleUser = new HdpRoleUser();
                    if (!dataReader.IsDBNull(0)) hdpRoleUser.UserID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) hdpRoleUser.RoleCode = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(1)) hdpRoleUser.RoleName = dataReader.GetString(2);

                    lstHdpRoleUser.Add(hdpRoleUser);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.GetHdpRoleUserList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 管理平台,验证用户角色授权信息
        /// </summary>
        /// <param name="szRoleName"></param>
        /// <param name="lstHdpRole"></param>
        /// <returns></returns>
        public short VerifyHdpRoleUser(string szUserID, string szRoleCode, ref HdpRoleUser hdpRoleUser)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szUserID) || string.IsNullOrEmpty(szRoleCode))
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("A.{0},A.{1},B.{2}"
                , SystemData.HdpRoleUserTable.USER_ID
                , SystemData.HdpRoleUserTable.ROLE_CODE
                , SystemData.HdpRoleUserTable.ROLE_NAME
                );
            string szTable = string.Format("{0} A, {1} B"
                , SystemData.DataTable.HDP_ROLE_USER_T, SystemData.DataTable.HDP_ROLE_T);
            string szCondition = string.Format(" 1=1 And A.{0}=B.{1}"
                , SystemData.HdpRoleUserTable.ROLE_CODE, SystemData.HdpRoleTable.ROLE_CODE);
            szCondition = string.Format("{0} and A.{1}='{2}' and A.{3}='{4}'"
                    , szCondition
                   , SystemData.HdpRoleUserTable.USER_ID, szUserID
                   , SystemData.HdpRoleUserTable.ROLE_CODE, szRoleCode);


            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField
                  , szTable
                  , szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }


                hdpRoleUser = new HdpRoleUser();
                if (!dataReader.IsDBNull(0)) hdpRoleUser.UserID = dataReader.GetString(0);
                if (!dataReader.IsDBNull(1)) hdpRoleUser.RoleCode = dataReader.GetString(1);
                if (!dataReader.IsDBNull(1)) hdpRoleUser.RoleName = dataReader.GetString(2);
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.GetHdpRoleUserList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 管理平台,保存一条用户角色授权信息
        /// </summary>
        /// <param name="HdpUIConfig">角色信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveHdpRoleUser(HdpRoleUser hdpRoleUser)
        {

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1}"
                , SystemData.HdpRoleUserTable.ROLE_CODE
                , SystemData.HdpRoleUserTable.USER_ID);
            string szValue = string.Format("'{0}','{1}'"
                , hdpRoleUser.RoleCode
                , hdpRoleUser.UserID);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.HDP_ROLE_USER_T, szField, szValue);


            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.SaveHdpRoleUser", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }
        /// <summary>
        ///  管理平台,根据用户账号,删除指定用户角色关联信息
        /// </summary>
        /// <param name="szUserID">用户账号</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteHdpRoleUser(string szUserID)
        {
            if (GlobalMethods.Misc.IsEmptyString(szUserID))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}' ", SystemData.HdpRoleUserTable.USER_ID, szUserID);

            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.HDP_ROLE_USER_T, szCondition);

            int count = 0;
            try
            {
                count = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.DeleteHdpRoleUser", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return count > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.RES_NO_FOUND;
        }
        /// <summary>
        /// 把用户角色授权信息保存到表中
        /// </summary>
        /// <param name="szUserID">用户账号</param>
        /// <param name="lstHdpRoleUser">用户角色关联信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveRoleUserList(string szUserID, List<HdpRoleUser> lstHdpRoleUser)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            //开始数据库事务
            if (!base.MedQCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            //删除原有关联信息
            short shRet = this.DeleteHdpRoleUser(szUserID);
            if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                base.MedQCAccess.AbortTransaction();
                return shRet;
            }

            //保存用户角色关联信息
            foreach (HdpRoleUser item in lstHdpRoleUser)
            {
                shRet = this.SaveHdpRoleUser(item);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.MedQCAccess.AbortTransaction();
                    return shRet;
                }
            }
            //提交数据库更新
            if (!base.MedQCAccess.CommitTransaction(true))
                return SystemData.ReturnValue.EXCEPTION;
            return SystemData.ReturnValue.OK;
        }
        #endregion
    }
}
