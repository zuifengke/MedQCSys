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

namespace EMRDBLib.DbAccess
{
    public class HdpRoleGrantAccess : DBAccessBase
    {
        private static HdpRoleGrantAccess m_Instance = null;
        public static HdpRoleGrantAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new HdpRoleGrantAccess();
                return m_Instance;
            }
        }

        #region"角色权限管理接口"
        /// <summary>
        /// 管理平台,获取角色权限管理列表
        /// </summary>
        /// <param name="szRoleName"></param>
        /// <param name="lstHdpRole"></param>
        /// <returns></returns>
        public short GetHdpRoleGrantList(string szRoleCode, string szProduct, ref List<HdpRoleGrant> lstHdpRoleGrant)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5}"
                , SystemData.HdpRoleGrantTable.ROLE_CODE
                , SystemData.HdpRoleGrantTable.ROLE_RIGHT_KEY
                , SystemData.HdpRoleGrantTable.ROLE_RIGHT_DESC
                , SystemData.HdpRoleGrantTable.ROLE_RIGHT_COMMAND
                , SystemData.HdpRoleGrantTable.PRODUCT
                , SystemData.HdpRoleGrantTable.GRANT_ID
                );
            string szCondition = string.Format(" 1=1 ");
            if (!string.IsNullOrEmpty(szRoleCode))
            {
                szCondition = string.Format("{0} and {1} in '{2}'"
                    , szCondition
                    , SystemData.HdpRoleGrantTable.ROLE_CODE, szRoleCode);
            }
            if (!string.IsNullOrEmpty(szProduct))
            {
                szCondition = string.Format("{0} and {1}='{2}'"
                        , szCondition
                        , SystemData.HdpRoleGrantTable.PRODUCT, szProduct);

            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                  , SystemData.DataTable.HDP_ROLE_GRANT_T
                  , szCondition
                  , SystemData.HdpRoleGrantTable.ROLE_RIGHT_KEY);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstHdpRoleGrant == null)
                    lstHdpRoleGrant = new List<HdpRoleGrant>();
                do
                {
                    HdpRoleGrant hdpRoleGrant = new HdpRoleGrant();
                    if (!dataReader.IsDBNull(0)) hdpRoleGrant.RoleCode = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) hdpRoleGrant.RoleRightKey = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) hdpRoleGrant.RoleRightDesc = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) hdpRoleGrant.RoleRightCommand = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) hdpRoleGrant.Product = dataReader.GetString(4);

                    if (!dataReader.IsDBNull(5)) hdpRoleGrant.GrantID = dataReader.GetString(5);
                    lstHdpRoleGrant.Add(hdpRoleGrant);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetHdpRoleGrantList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.QCAccess.CloseConnnection(false);
            }
        }

        /// <summary>
        /// 管理平台,保存一条角色信息
        /// </summary>
        /// <param name="HdpUIConfig">角色信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveHdpRoleGrant(HdpRoleGrant hdpRoleGrant)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5}"
                , SystemData.HdpRoleGrantTable.GRANT_ID
                , SystemData.HdpRoleGrantTable.PRODUCT
                , SystemData.HdpRoleGrantTable.ROLE_CODE
                , SystemData.HdpRoleGrantTable.ROLE_RIGHT_COMMAND
                , SystemData.HdpRoleGrantTable.ROLE_RIGHT_DESC
                , SystemData.HdpRoleGrantTable.ROLE_RIGHT_KEY);
            string szValue = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}'"
                , hdpRoleGrant.GrantID
                , hdpRoleGrant.Product
                , hdpRoleGrant.RoleCode
                , hdpRoleGrant.RoleRightCommand
                , hdpRoleGrant.RoleRightDesc
                , hdpRoleGrant.RoleRightKey);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.HDP_ROLE_GRANT_T, szField, szValue);


            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.SaveHdpRoleGrant", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        /// <summary>
        /// 管理平台,保存多条角色权限集合
        /// </summary>
        /// <param name="szRoleCode">角色代码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveHdpRoleGrantList(string szRoleCode, string szProduct, List<HdpRoleGrant> lstHdpRoleGrant)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            //开始数据库事务
            if (!base.QCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            //删除原有关联信息
            short shRet = this.DeleteHdpRoleGrantByRoleCode(szRoleCode, szProduct);
            if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                base.QCAccess.AbortTransaction();
                return shRet;
            }

            //保存用户角色关联信息
            foreach (HdpRoleGrant item in lstHdpRoleGrant)
            {
                shRet = this.SaveHdpRoleGrant(item);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.QCAccess.AbortTransaction();
                    return shRet;
                }
            }
            //提交数据库更新
            if (!base.QCAccess.CommitTransaction(true))
                return SystemData.ReturnValue.EXCEPTION;
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 管理平台,修改一条授权信息
        /// </summary>
        /// <param name="hdpUIConfig">产品信息</param>
        /// <param name="szOldNameShort">旧的产品缩写</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short ModifyHdpRoleGrant(string szGrantID, HdpRoleGrant hdpRoleGrant)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}='{5}',{6}='{7}',{8}='{9}'"
                , SystemData.HdpRoleGrantTable.PRODUCT, hdpRoleGrant.Product
                , SystemData.HdpRoleGrantTable.ROLE_CODE, hdpRoleGrant.RoleCode
                , SystemData.HdpRoleGrantTable.ROLE_RIGHT_COMMAND, hdpRoleGrant.RoleRightCommand
                , SystemData.HdpRoleGrantTable.ROLE_RIGHT_DESC, hdpRoleGrant.RoleRightDesc
                , SystemData.HdpRoleGrantTable.ROLE_RIGHT_KEY, hdpRoleGrant.RoleRightKey);
            string szCondition = string.Format("{0}='{1}'"
                , SystemData.HdpRoleGrantTable.GRANT_ID, szGrantID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.HDP_ROLE_GRANT_T, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.ModifyHdpRoleGrant", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        /// <summary>
        ///  管理平台,根据角色代码,删除指定角色授权信息
        /// </summary>
        /// <param name="szRoleCode">角色代码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteHdpRoleGrant(string szGrantID)
        {
            if (GlobalMethods.Misc.IsEmptyString(szGrantID))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}' ", SystemData.HdpRoleGrantTable.GRANT_ID, szGrantID);

            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.HDP_ROLE_GRANT_T, szCondition);

            int count = 0;
            try
            {
                count = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.DeleteHdpRoleGrant", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return count > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.RES_NO_FOUND;
        }
        /// <summary>
        ///  管理平台,根据角色代码,删除指定角色授权信息
        /// </summary>
        /// <param name="szRoleCode">角色代码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteHdpRoleGrantByRoleCode(string szRoleCode, string szProduct)
        {
            if (GlobalMethods.Misc.IsEmptyString(szRoleCode) || GlobalMethods.Misc.IsEmptyString(szProduct))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}' and {2}='{3}'"
                , SystemData.HdpRoleGrantTable.ROLE_CODE, szRoleCode
                , SystemData.HdpRoleGrantTable.PRODUCT, szProduct);

            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.HDP_ROLE_GRANT_T, szCondition);

            int count = 0;
            try
            {
                count = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.DeleteHdpRoleGrantByRoleCode", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return count > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.RES_NO_FOUND;
        }
        #endregion
    }
}
