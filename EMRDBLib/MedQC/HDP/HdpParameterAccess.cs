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
    public class HdpParameterAccess : DBAccessBase
    {
        private static HdpParameterAccess m_Instance = null;
        public static HdpParameterAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new HdpParameterAccess();
                return m_Instance;
            }
        }
        #region 系统参数管理
        /// <summary>
        /// 查询配置参数表获取指定的配置数据
        /// </summary>
        /// <param name="szProduct">产品</param>
        /// <param name="szGroupName">配置组名称</param>
        /// <param name="szConfigName">配置项名称(为空时返回该组所有配置项)</param>
        /// <param name="lstConfigInfos">返回的配置项及其配置数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetHdpParameters(string szProduct, string szGroupName, string szConfigName, ref List<HdpParameter> lstHdpParameter)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.HdpParameterTable.GROUP_NAME, SystemData.HdpParameterTable.CONFIG_NAME
                , SystemData.HdpParameterTable.CONFIG_VALUE, SystemData.HdpParameterTable.CONFIG_DESC
                , SystemData.HdpParameterTable.PRODUCT);

            string szCondition = String.Format("1=1");
            if (!GlobalMethods.Misc.IsEmptyString(szGroupName))
            {
                szCondition = string.Format("{0}='{1}'", SystemData.HdpParameterTable.GROUP_NAME, szGroupName);
                if (!GlobalMethods.Misc.IsEmptyString(szConfigName))
                {
                    szCondition = string.Format("{0} AND {1}='{2}'", szCondition
                        , SystemData.HdpParameterTable.CONFIG_NAME, szConfigName);
                }
            }
            if (!GlobalMethods.Misc.IsEmptyString(szProduct))
            {
                szCondition = string.Format("{0} AND {1}='{2}'", szCondition
                        , SystemData.HdpParameterTable.PRODUCT, szProduct);
            }

            string szOrder = string.Format("{0},{1}"
                , SystemData.HdpParameterTable.GROUP_NAME, SystemData.HdpParameterTable.CONFIG_NAME);

            string szSQL = null;
            if (string.IsNullOrEmpty(szCondition))
            {
                szSQL = string.Format(SystemData.SQL.SELECT_ORDER_ASC
                    , szField, SystemData.DataTable.HDP_PARAMETER_T, szOrder);
            }
            else
            {
                szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , szField, SystemData.DataTable.HDP_PARAMETER_T, szCondition, szOrder);
            }

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstHdpParameter == null)
                    lstHdpParameter = new List<HdpParameter>();
                do
                {
                    HdpParameter parameter = new HdpParameter();
                    parameter.GROUP_NAME = dataReader.GetString(0);
                    parameter.CONFIG_NAME = dataReader.GetString(1);
                    parameter.CONFIG_VALUE = dataReader.GetString(2);

                    if (!dataReader.IsDBNull(3))
                        parameter.CONFIG_DESC = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4))
                        parameter.PRODUCT = dataReader.GetString(4);
                    lstHdpParameter.Add(parameter);

                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.GetHdpParameters", new string[] { "szGroupName", "szConfigName", "SQL" }
                        , new object[] { szGroupName, szConfigName, szSQL }, "没有查询到记录!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 修改配置字典表中指定的配置数据
        /// </summary>
        /// <param name="configInfo">配置项及其配置数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveHdpParameter(HdpParameter hdpParameter)
        {
            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.HdpParameterTable.GROUP_NAME, SystemData.HdpParameterTable.CONFIG_NAME
                , SystemData.HdpParameterTable.CONFIG_VALUE, SystemData.HdpParameterTable.CONFIG_DESC
                , SystemData.HdpParameterTable.PRODUCT);
            string szValue = string.Format("'{0}','{1}',{2},'{3}','{4}'"
                , hdpParameter.GROUP_NAME, hdpParameter.CONFIG_NAME
                , base.QCAccess.GetSqlParamName("ConfigValue"), hdpParameter.CONFIG_DESC
                , hdpParameter.PRODUCT==null?"MedQC":hdpParameter.PRODUCT);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.HDP_PARAMETER_T, szField, szValue);

            DbParameter[] pmi = new DbParameter[1];
            pmi[0] = new DbParameter("ConfigValue", hdpParameter.CONFIG_VALUE);

            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.SaveHdpParameter", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        /// <summary>
        /// 修改配置字典表中指定的配置数据
        /// </summary>
        /// <param name="szGroupName">配置组</param>
        /// <param name="szConfigName">配置项</param>
        /// <param name="configInfo">配置项及其配置数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short UpdateHdpParameter( string szGroupName, string szConfigName, HdpParameter hdpParameter)
        {
            string szField = string.Format("{0}='{1}',{2}='{3}',{4}={5},{6}='{7}',{8}='{9}'"
                , SystemData.HdpParameterTable.GROUP_NAME, hdpParameter.GROUP_NAME
                , SystemData.HdpParameterTable.CONFIG_NAME, hdpParameter.CONFIG_NAME
                , SystemData.HdpParameterTable.CONFIG_VALUE, base.QCAccess.GetSqlParamName("ConfigValue")
                , SystemData.HdpParameterTable.CONFIG_DESC, hdpParameter.CONFIG_DESC
                , SystemData.HdpParameterTable.PRODUCT, hdpParameter.PRODUCT == null ? "MedQC" : hdpParameter.PRODUCT);
            string szCondition = string.Format("{0}='{1}' and {2}='{3}' "
                , SystemData.HdpParameterTable.GROUP_NAME, szGroupName
                , SystemData.HdpParameterTable.CONFIG_NAME, szConfigName);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.HDP_PARAMETER_T, szField, szCondition);

            DbParameter[] pmi = new DbParameter[1];
            pmi[0] = new DbParameter("ConfigValue", hdpParameter.CONFIG_VALUE);

            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.UpdateHdpParameter", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        /// <summary>
        /// 删除参数表中指定的配置数据
        /// </summary>
        /// <param name="szGroupName">配置组</param>
        /// <param name="szConfigName">配置项</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteHdpParameter( string szGroupName, string szConfigName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szGroupName))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}'", SystemData.HdpParameterTable.GROUP_NAME, szGroupName);
            if (!GlobalMethods.Misc.IsEmptyString(szConfigName))
            {
                szCondition = string.Format("{0} AND {1}='{2}' ", szCondition
                    , SystemData.HdpParameterTable.CONFIG_NAME, szConfigName);
            }
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.HDP_PARAMETER_T, szCondition);

            int count = 0;
            try
            {
                count = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.DeleteHdpParameter", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return count > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.RES_NO_FOUND;
        }

        #endregion
    }
}
