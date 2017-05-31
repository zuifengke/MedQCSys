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
    public class HdpRoleAccess : DBAccessBase
    {
        private static HdpRoleAccess m_Instance = null;
        public static HdpRoleAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new HdpRoleAccess();
                return m_Instance;
            }
        }
        #region"角色管理接口"
        /// <summary>
        /// 管理平台,获取角色管理列表
        /// </summary>
        /// <param name="szRoleName"></param>
        /// <param name="lstHdpRole"></param>
        /// <returns></returns>
        public short GetHdpRoleList(string szRoleName, ref List<HdpRole> lstHdpRole)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.HdpRoleTable.SERIAL_NO
                , SystemData.HdpRoleTable.ROLE_NAME
                , SystemData.HdpRoleTable.ROLE_CODE
                , SystemData.HdpRoleTable.STATUS
                , SystemData.HdpRoleTable.ROLE_BAK
                );
            string szCondition = string.Format(" 1=1 ");
            if (!string.IsNullOrEmpty(szRoleName))
            {
                szCondition = string.Format("{0} and {1}='{2}'"
                    , szCondition
                    , SystemData.HdpRoleTable.ROLE_NAME, szRoleName);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                  , SystemData.DataTable.HDP_ROLE_T
                  , szCondition
                  , SystemData.HdpRoleTable.SERIAL_NO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstHdpRole == null)
                    lstHdpRole = new List<HdpRole>();
                do
                {
                    HdpRole hdpRole = new HdpRole();
                    if (!dataReader.IsDBNull(0)) hdpRole.SerialNo = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) hdpRole.RoleName = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) hdpRole.RoleCode = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) hdpRole.Status = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) hdpRole.RoleBak = dataReader.GetString(4);

                    lstHdpRole.Add(hdpRole);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.GetHdpRoleList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        public short SaveHdpRole(HdpRole hdpRole)
        {
            string szField = string.Format("{0},{1},{2},{3},{4}"
                 , SystemData.HdpRoleTable.ROLE_BAK
                 , SystemData.HdpRoleTable.ROLE_CODE
                 , SystemData.HdpRoleTable.ROLE_NAME
                 , SystemData.HdpRoleTable.SERIAL_NO
                 , SystemData.HdpRoleTable.STATUS);
            string szValue = string.Format("'{0}','{1}','{2}','{3}','{4}'"
                , hdpRole.RoleBak
                , hdpRole.RoleCode
                , hdpRole.RoleName
                , hdpRole.SerialNo
                , hdpRole.Status);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.HDP_ROLE_T, szField, szValue);

            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.SaveHdpParameter", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        /// <summary>
        /// 管理平台,修改一条产品信息
        /// </summary>
        /// <param name="hdpUIConfig">产品信息</param>
        /// <param name="szOldNameShort">旧的产品缩写</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short ModifyHdpRole(string szOldRoleCode, HdpRole hdpRole)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}='{5}',{6}='{7}',{8}='{9}'"
                , SystemData.HdpRoleTable.ROLE_BAK, hdpRole.RoleBak
                , SystemData.HdpRoleTable.ROLE_CODE, hdpRole.RoleCode
                , SystemData.HdpRoleTable.ROLE_NAME, hdpRole.RoleName
                , SystemData.HdpRoleTable.SERIAL_NO, hdpRole.SerialNo
                , SystemData.HdpRoleTable.STATUS, hdpRole.Status);
            string szCondition = string.Format("{0}='{1}'"
                , SystemData.HdpRoleTable.ROLE_CODE, szOldRoleCode);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.HDP_ROLE_T, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.ModifyHdpProduct", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        /// <summary>
        ///  管理平台,根据角色代码,删除指定角色信息
        /// </summary>
        /// <param name="szRoleCode">角色代码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteHdpRole(string szOldRoleCode)
        {
            if (GlobalMethods.Misc.IsEmptyString(szOldRoleCode))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}' ", SystemData.HdpRoleTable.ROLE_CODE, szOldRoleCode);

            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.HDP_ROLE_T, szCondition);

            int count = 0;
            try
            {
                count = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.DeleteHdpRole", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return count > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.RES_NO_FOUND;
        }
        #endregion
    }
}
