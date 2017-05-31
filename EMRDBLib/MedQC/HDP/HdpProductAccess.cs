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
    public class HdpProductAccess : DBAccessBase
    {
        private static HdpProductAccess m_Instance = null;
        public static HdpProductAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new HdpProductAccess();
                return m_Instance;
            }
        }

        #region"产品管理接口"
        public short GetHdpProduct(string szNameShort, ref HdpProduct hdpProduct)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.HdpProductTable.CN_NAME);
            sbField.AppendFormat("{0},", SystemData.HdpProductTable.EN_NAME);
            sbField.AppendFormat("{0},", SystemData.HdpProductTable.NAME_SHORT);
            sbField.AppendFormat("{0},", SystemData.HdpProductTable.PRODUCT_BAK);
            sbField.AppendFormat("{0}", SystemData.HdpProductTable.SERIAL_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szNameShort))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.HdpProductTable.NAME_SHORT
                    , szNameShort);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.HDP_PRODUCT_T, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (hdpProduct == null)
                    hdpProduct = new HdpProduct();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.HdpProductTable.CN_NAME:
                            hdpProduct.CN_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.HdpProductTable.EN_NAME:
                            hdpProduct.EN_NAME = dataReader.GetString(i);
                            break;
                        case SystemData.HdpProductTable.NAME_SHORT:
                            hdpProduct.NAME_SHORT = dataReader.GetString(i);
                            break;
                        case SystemData.HdpProductTable.PRODUCT_BAK:
                            hdpProduct.PRODUCT_BAK = dataReader.GetString(i);
                            break;
                        case SystemData.HdpProductTable.SERIAL_NO:
                            hdpProduct.SERIAL_NO = dataReader.GetValue(i).ToString();
                            break;
                        default: break;
                    }
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
    }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 管理平台,获取产品信息列表
        /// </summary>
        /// <param name="lstHdpProduct">产品信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetHdpProductList(ref List<HdpProduct> lstHdpProduct)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.HdpProductTable.SERIAL_NO
                , SystemData.HdpProductTable.NAME_SHORT
                , SystemData.HdpProductTable.CN_NAME
                , SystemData.HdpProductTable.EN_NAME
                , SystemData.HdpProductTable.PRODUCT_BAK);

            string szSQL = string.Format(SystemData.SQL.SELECT_ORDER_ASC, szField
                  , SystemData.DataTable.HDP_PRODUCT_T, SystemData.HdpProductTable.SERIAL_NO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstHdpProduct == null)
                    lstHdpProduct = new List<HdpProduct>();
                do
                {
                    HdpProduct hdpProduct = new HdpProduct();
                    if (!dataReader.IsDBNull(0)) hdpProduct.SERIAL_NO = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) hdpProduct.NAME_SHORT = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) hdpProduct.CN_NAME = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) hdpProduct.EN_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) hdpProduct.PRODUCT_BAK = dataReader.GetString(4);
                    lstHdpProduct.Add(hdpProduct);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.GetHdpProductList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 管理平台,保存一条产品信息
        /// </summary>
        /// <param name="HdpProduct">产品信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveHdpProduct(HdpProduct hdpProduct)
        {
            string szField = string.Format("{0},{1},{2},{3},{4}"
               , SystemData.HdpProductTable.CN_NAME, SystemData.HdpProductTable.EN_NAME
               , SystemData.HdpProductTable.NAME_SHORT, SystemData.HdpProductTable.PRODUCT_BAK
               , SystemData.HdpProductTable.SERIAL_NO);
            string szValue = string.Format("'{0}','{1}','{2}','{3}','{4}'"
                , hdpProduct.CN_NAME, hdpProduct.EN_NAME
                , hdpProduct.NAME_SHORT, hdpProduct.PRODUCT_BAK
                , hdpProduct.SERIAL_NO
               );
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.HDP_PRODUCT_T, szField, szValue);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.SaveHdpProduct", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        /// <summary>
        /// 管理平台,修改一条产品信息
        /// </summary>
        /// <param name="hdpProduct">产品信息</param>
        /// <param name="szOldNameShort">旧的产品缩写</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short ModifyHdpProduct(HdpProduct hdpProduct, string szOldNameShort)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}='{5}',{6}='{7}',{8}='{9}'"
                , SystemData.HdpProductTable.CN_NAME, hdpProduct.CN_NAME
                , SystemData.HdpProductTable.EN_NAME, hdpProduct.EN_NAME
                , SystemData.HdpProductTable.NAME_SHORT, hdpProduct.NAME_SHORT
                , SystemData.HdpProductTable.PRODUCT_BAK, hdpProduct.PRODUCT_BAK
                , SystemData.HdpProductTable.SERIAL_NO, hdpProduct.SERIAL_NO);
            string szCondition = string.Format("{0}='{1}'"
                , SystemData.HdpProductTable.NAME_SHORT, szOldNameShort);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.HDP_PRODUCT_T, szField, szCondition);

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
        ///  管理平台,根据缩写名称,删除指定产品信息
        /// </summary>
        /// <param name="szNameShort">名称缩写</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short DeleteHdpProduct(string szNameShort)
        {
            if (GlobalMethods.Misc.IsEmptyString(szNameShort))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}' ", SystemData.HdpProductTable.NAME_SHORT, szNameShort
                , SystemData.HdpProductTable.NAME_SHORT, szNameShort);

            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.HDP_PRODUCT_T, szCondition);

            int count = 0;
            try
            {
                count = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HDPDBAccess.DeleteHdpProduct", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return count > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.RES_NO_FOUND;
        }
        #endregion
    }
}
