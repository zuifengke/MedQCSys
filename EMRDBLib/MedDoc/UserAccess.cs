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
    public class UserAccess : DBAccessBase
    {
        private static UserAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static UserAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new UserAccess();
                return m_Instance;
            }
        }

        /// <summary>
        /// 根据科室编号获取用户信息列表
        /// </summary>
        /// <param name="szDeptCode">科室编号</param>
        /// <param name="lstUserInfos">用户信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDeptUserList(string szDeptCode, ref List<UserInfo> lstUserInfos)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            //先获取用户信息
            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.UserView.USER_ID, SystemData.UserView.USER_NAME
                , SystemData.UserView.DEPT_CODE, SystemData.UserView.DEPT_NAME, SystemData.UserView.USER_PWD);
            string szTable = SystemData.DataView.USER_V;
            string szCondition = string.Format("{0}={1}", SystemData.UserView.DEPT_CODE, base.ParaHolder(SystemData.UserView.DEPT_CODE));
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);
            DbParameter[] paras = new DbParameter[1] { new DbParameter(SystemData.UserView.DEPT_CODE, szDeptCode) };
            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text, ref paras);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstUserInfos == null)
                    lstUserInfos = new List<UserInfo>();
                do
                {
                    UserInfo userInfo = new UserInfo();
                    if (!dataReader.IsDBNull(0)) userInfo.ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) userInfo.Name = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) userInfo.DeptCode = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) userInfo.DeptName = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) userInfo.Password = dataReader.GetString(4);
                    lstUserInfos.Add(userInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetDeptUserList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 根据用户名获取指定的用户信息
        /// </summary>
        /// <param name="szUserName">用户名</param>
        /// <param name="lstUserInfo">用户信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetUserInfo(string szUserName, ref List<UserInfo> lstUserInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szUserName))
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetUserInfo", "用户姓名不能为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            //先获取用户信息
            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.UserView.USER_ID, SystemData.UserView.USER_NAME
                , SystemData.UserView.DEPT_CODE, SystemData.UserView.DEPT_NAME, SystemData.UserView.USER_PWD);
            string szCondition = string.Format("{0} like '%{1}%'", SystemData.UserView.USER_NAME, szUserName);
            string szTable = SystemData.DataView.USER_V;
            string szOrder = SystemData.UserView.DEPT_CODE;
            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrder);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstUserInfo == null)
                    lstUserInfo = new List<UserInfo>();
                do
                {
                    UserInfo userInfo = new UserInfo();
                    if (!dataReader.IsDBNull(0)) userInfo.ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) userInfo.Name = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) userInfo.DeptCode = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) userInfo.DeptName = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) userInfo.Password = dataReader.GetString(4);
                    lstUserInfo.Add(userInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetUserInfo", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 获取全院所有用户列表
        /// </summary>
        /// <param name="lstUserInfos">用户列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetAllUserInfos(ref List<UserInfo> lstUserInfos)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            //先获取用户信息
            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.UserView.USER_ID, SystemData.UserView.USER_NAME
                , SystemData.UserView.DEPT_CODE, SystemData.UserView.DEPT_NAME, SystemData.UserView.USER_PWD);
            string szTable = SystemData.DataView.USER_V;
            string szOrder = SystemData.UserView.DEPT_NAME;
            string szSQL = string.Format(SystemData.SQL.SELECT_ORDER_ASC, szField, szTable, szOrder);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstUserInfos == null)
                    lstUserInfos = new List<UserInfo>();
                do
                {
                    UserInfo userInfo = new UserInfo();
                    if (!dataReader.IsDBNull(0)) userInfo.ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) userInfo.Name = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) userInfo.DeptCode = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) userInfo.DeptName = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) userInfo.Password = dataReader.GetString(4);
                    lstUserInfos.Add(userInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("UserAccess.GetAllUserInfos", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 根据用户ID获取指定的用户信息
        /// </summary>
        /// <param name="szUserID">用户ID</param>
        /// <param name="userInfo">返回的用户信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetUserInfo(string szUserID, ref UserInfo userInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szUserID))
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetUserInfo", "用户ID不能为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            //先获取用户信息
            string szField = string.Format("{0},{1},{2},{3},{4},{5}"
                , SystemData.UserView.USER_ID, SystemData.UserView.USER_NAME
                , SystemData.UserView.DEPT_CODE, SystemData.UserView.DEPT_NAME, SystemData.UserView.USER_PWD, SystemData.UserView.USER_GRADE);
            string szCondition = string.Format("{0}='{1}' "
                , SystemData.UserView.USER_ID, szUserID);
            string szTable = SystemData.DataView.USER_V;
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (userInfo == null)
                    userInfo = new UserInfo();
                if (!dataReader.IsDBNull(0)) userInfo.ID = dataReader.GetString(0);
                if (!dataReader.IsDBNull(1)) userInfo.Name = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2)) userInfo.DeptCode = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3)) userInfo.DeptName = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4)) userInfo.Password = dataReader.GetString(4);
                if (!dataReader.IsDBNull(5)) userInfo.Grade = dataReader.GetValue(5).ToString();
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetUserInfo", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
    }
}
