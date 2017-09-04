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
    public class HdpUIConfigAccess : DBAccessBase
    {
        private static HdpUIConfigAccess m_Instance = null;
        public static HdpUIConfigAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new HdpUIConfigAccess();
                return m_Instance;
            }
        }

        #region"界面配置管理接口"
        /// <summary>
        /// 管理平台,获取界面配置管理列表
        /// </summary>
        /// <param name="szProduct">产品缩写</param>
        /// <param name="szUIType">元件类型</param>
        /// <param name="lstHdpOperationType">操作类型信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetHdpUIConfigList(string szProduct, string szUIType, string szPopMenuResource, ref List<HdpUIConfig> lstHdpUIConfig)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}"
                , SystemData.HdpUIConfigTable.UI_CONFIG_ID
                , SystemData.HdpUIConfigTable.SHOW_NAME
                , SystemData.HdpUIConfigTable.PRODUCT
                , SystemData.HdpUIConfigTable.SHORTCUTS
                , SystemData.HdpUIConfigTable.SHOW_TYPE
                , SystemData.HdpUIConfigTable.UI_ICON
                , SystemData.HdpUIConfigTable.UI_ICON_SIZE
                , SystemData.HdpUIConfigTable.UI_RIGHT_KEY
                , SystemData.HdpUIConfigTable.UI_RIGHT_DESC
                , SystemData.HdpUIConfigTable.UI_COMMAND
                , SystemData.HdpUIConfigTable.MICRO_HELP
                , SystemData.HdpUIConfigTable.UI_TYPE
                , SystemData.HdpUIConfigTable.PARENT_ID
                , SystemData.HdpUIConfigTable.SORT_INDEX
                , SystemData.HdpUIConfigTable.UI_GRADE
                , SystemData.HdpUIConfigTable.POPMENU_RESOURCE
                );
            string szCondition = string.Format(" 1=1 and {0}='{1}' and {2}='{3}'"
                , SystemData.HdpUIConfigTable.PRODUCT, szProduct
                , SystemData.HdpUIConfigTable.UI_TYPE, szUIType);
            if (!string.IsNullOrEmpty(szPopMenuResource))
            {
                szCondition = string.Format("{0} and {1}='{2}'"
                    , szCondition
                    , SystemData.HdpUIConfigTable.POPMENU_RESOURCE, szPopMenuResource);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                  , SystemData.DataTable.HDP_UICONFIG_T
                  , szCondition
                  , SystemData.HdpUIConfigTable.SORT_INDEX);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstHdpUIConfig == null)
                    lstHdpUIConfig = new List<HdpUIConfig>();
                do
                {
                    HdpUIConfig hdpUIConfig = new HdpUIConfig();
                    if (!dataReader.IsDBNull(0)) hdpUIConfig.UIConfigID = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) hdpUIConfig.ShowName = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) hdpUIConfig.Product = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) hdpUIConfig.ShortCuts = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) hdpUIConfig.ShowType = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) hdpUIConfig.UIIcon = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) hdpUIConfig.UIIconSize = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) hdpUIConfig.UIRightKey = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) hdpUIConfig.UIRightDesc = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) hdpUIConfig.UICommand = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) hdpUIConfig.MicroHelp = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) hdpUIConfig.UIType = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) hdpUIConfig.ParentID = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) hdpUIConfig.SortIndex = int.Parse(dataReader.GetValue(13).ToString());
                    if (!dataReader.IsDBNull(14)) hdpUIConfig.UIGrade = int.Parse(dataReader.GetValue(14).ToString());
                    if (!dataReader.IsDBNull(15)) hdpUIConfig.PopMenuResource = dataReader.GetString(15);
                    lstHdpUIConfig.Add(hdpUIConfig);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.GetHdpUIConfigList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 管理平台,保存一条界面配置信息
        /// </summary>
        /// <param name="HdpUIConfig">界面配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveHdpUIConfig(HdpUIConfig hdpUIConfig)
        {
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}"
               , SystemData.HdpUIConfigTable.MICRO_HELP
               , SystemData.HdpUIConfigTable.PARENT_ID
               , SystemData.HdpUIConfigTable.POPMENU_RESOURCE
               , SystemData.HdpUIConfigTable.PRODUCT
               , SystemData.HdpUIConfigTable.SHORTCUTS
               , SystemData.HdpUIConfigTable.SHOW_NAME
               , SystemData.HdpUIConfigTable.SHOW_TYPE
               , SystemData.HdpUIConfigTable.SORT_INDEX
               , SystemData.HdpUIConfigTable.UI_COMMAND
               , SystemData.HdpUIConfigTable.UI_GRADE
               , SystemData.HdpUIConfigTable.UI_ICON
               , SystemData.HdpUIConfigTable.UI_ICON_SIZE
               , SystemData.HdpUIConfigTable.UI_RIGHT_DESC
               , SystemData.HdpUIConfigTable.UI_RIGHT_KEY
               , SystemData.HdpUIConfigTable.UI_TYPE
               , SystemData.HdpUIConfigTable.UI_CONFIG_ID);
            string szValue = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}'"
                , hdpUIConfig.MicroHelp
                , hdpUIConfig.ParentID
                , hdpUIConfig.PopMenuResource
                , hdpUIConfig.Product
                , hdpUIConfig.ShortCuts
                , hdpUIConfig.ShowName
                , hdpUIConfig.ShowType
                , hdpUIConfig.SortIndex
                , hdpUIConfig.UICommand
                , hdpUIConfig.UIGrade
                , hdpUIConfig.UIIcon
                , hdpUIConfig.UIIconSize
                , hdpUIConfig.UIRightDesc
                , hdpUIConfig.UIRightKey
                , hdpUIConfig.UIType
                 , hdpUIConfig.UIConfigID
               );
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.HDP_UICONFIG_T, szField, szValue);
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.SaveHdpUIConfig", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }
        public short ModifySortIndex(HdpUIConfig model)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.HdpUIConfigTable.SORT_INDEX, model.SortIndex);
            string szCondition = string.Format("{0}='{1}'", SystemData.HdpUIConfigTable.UI_CONFIG_ID, model.UIConfigID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.HDP_UICONFIG_T, sbField.ToString(), szCondition);
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 管理平台,修改一条产品信息
        /// </summary>
        /// <param name="hdpUIConfig">产品信息</param>
        /// <param name="szOldNameShort">旧的产品缩写</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short ModifyHdpUIConfig(HdpUIConfig hdpUIConfig)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}='{5}',{6}='{7}',{8}='{9}',{10}='{11}',{12}='{13}',{14}='{15}',{16}='{17}',{18}='{19}',{20}='{21}',{22}='{23}',{24}='{25}',{26}='{27}',{28}='{29}'"
                , SystemData.HdpUIConfigTable.MICRO_HELP, hdpUIConfig.MicroHelp
                , SystemData.HdpUIConfigTable.PARENT_ID, hdpUIConfig.ParentID
                , SystemData.HdpUIConfigTable.POPMENU_RESOURCE, hdpUIConfig.PopMenuResource
                , SystemData.HdpUIConfigTable.PRODUCT, hdpUIConfig.Product
                , SystemData.HdpUIConfigTable.SHORTCUTS, hdpUIConfig.ShortCuts
                , SystemData.HdpUIConfigTable.SHOW_NAME, hdpUIConfig.ShowName
                , SystemData.HdpUIConfigTable.SHOW_TYPE, hdpUIConfig.ShowType
                , SystemData.HdpUIConfigTable.SORT_INDEX, hdpUIConfig.SortIndex
                , SystemData.HdpUIConfigTable.UI_COMMAND, hdpUIConfig.UICommand
                , SystemData.HdpUIConfigTable.UI_GRADE, hdpUIConfig.UIGrade
                , SystemData.HdpUIConfigTable.UI_ICON, hdpUIConfig.UIIcon
                , SystemData.HdpUIConfigTable.UI_ICON_SIZE, hdpUIConfig.UIIconSize
                , SystemData.HdpUIConfigTable.UI_RIGHT_DESC, hdpUIConfig.UIRightDesc
                , SystemData.HdpUIConfigTable.UI_RIGHT_KEY, hdpUIConfig.UIRightKey
                , SystemData.HdpUIConfigTable.UI_TYPE, hdpUIConfig.UIType
                );
            string szCondition = string.Format("{0}='{1}'"
                , SystemData.HdpUIConfigTable.UI_CONFIG_ID, hdpUIConfig.UIConfigID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.HDP_UICONFIG_T, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.ModifyHdpProduct", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        /// <summary>
        ///  管理平台,根据缩写名称,删除指定产品信息
        /// </summary>
        /// <param name="szNameShort">名称缩写</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteHdpUIConfig(string szUIConfigID)
        {
            if (GlobalMethods.Misc.IsEmptyString(szUIConfigID))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}' ", SystemData.HdpUIConfigTable.UI_CONFIG_ID, szUIConfigID);

            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.HDP_UICONFIG_T, szCondition);

            int count = 0;
            try
            {
                count = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.DeleteHdpUIConfig", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return count > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.RES_NO_FOUND;
        }
        #endregion
    }
}
