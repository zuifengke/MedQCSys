// ***********************************************************
// 病历质控结果数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{

    public class KeyValueDataAccess : DBAccessBase
    {
        private static KeyValueDataAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static KeyValueDataAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new KeyValueDataAccess();
                return KeyValueDataAccess.m_Instance;
            }
        }

        /// <summary>
        /// 新增一条人工核查结果信息
        /// </summary>
        /// <param name="keyValueData">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(KeyValueData keyValueData)
        {
            if (keyValueData == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { keyValueData }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();

            sbField.AppendFormat("{0},", SystemData.KeyValueDataTable.ID);
            sbValue.AppendFormat("'{0}',", keyValueData.ID);
            sbField.AppendFormat("{0},", SystemData.KeyValueDataTable.DATA_GROUP);
            sbValue.AppendFormat("'{0}',", keyValueData.DATA_GROUP);
            sbField.AppendFormat("{0},", SystemData.KeyValueDataTable.DATA_KEY);
            sbValue.AppendFormat("'{0}',", keyValueData.DATA_KEY);
            sbField.AppendFormat("{0},", SystemData.KeyValueDataTable.VALUE1);
            sbValue.AppendFormat("'{0}',", keyValueData.VALUE1);
            sbField.AppendFormat("{0}", SystemData.KeyValueDataTable.DATA_VALUE);
            sbValue.AppendFormat("'{0}'", keyValueData.DATA_VALUE);
            
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.KEY_VALUE_DATA, sbField.ToString(), sbValue.ToString());
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
        public short Update(KeyValueData keyValueData)
        {
            if (keyValueData == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { keyValueData }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.KeyValueDataTable.DATA_GROUP, keyValueData.DATA_GROUP);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.KeyValueDataTable.DATA_KEY, keyValueData.DATA_KEY);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.KeyValueDataTable.DATA_VALUE, keyValueData.DATA_VALUE);
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.KeyValueDataTable.VALUE1, keyValueData.VALUE1);
            string szCondition = string.Format("{0}='{1}'", SystemData.KeyValueDataTable.ID, keyValueData.ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.KEY_VALUE_DATA, sbField.ToString(), szCondition);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
        public short Delete(string szID)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.KeyValueDataTable.ID, szID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.KEY_VALUE_DATA, szCondition);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
        public short GetHolidays(string year, ref List<KeyValueData> lstKeyValueDatas)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.KeyValueDataTable.DATA_GROUP);
            sbField.AppendFormat("{0},", SystemData.KeyValueDataTable.DATA_KEY);
            sbField.AppendFormat("{0},", SystemData.KeyValueDataTable.DATA_VALUE);
            sbField.AppendFormat("{0},", SystemData.KeyValueDataTable.VALUE1);
            sbField.AppendFormat("{0}", SystemData.KeyValueDataTable.ID);
            string szCondition = " 1=1";
            szCondition = string.Format("{0} AND {1}='{2}'"
                , szCondition
                , SystemData.KeyValueDataTable.DATA_GROUP
                , SystemData.DataGroup.holiday);
            if (!string.IsNullOrEmpty(year))
            {
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.KeyValueDataTable.VALUE1
                    , year);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                   , sbField.ToString(), SystemData.DataTable.KEY_VALUE_DATA, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstKeyValueDatas == null)
                    lstKeyValueDatas = new List<KeyValueData>();
                do
                {
                    KeyValueData keyValueData = new KeyValueData();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.KeyValueDataTable.DATA_GROUP:
                                keyValueData.DATA_GROUP = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.KeyValueDataTable.DATA_KEY:
                                keyValueData.DATA_KEY = dataReader.GetString(i);
                                break;
                            case SystemData.KeyValueDataTable.DATA_VALUE:
                                keyValueData.DATA_VALUE = dataReader.GetString(i);
                                break;
                            case SystemData.KeyValueDataTable.ID:
                                keyValueData.ID = dataReader.GetString(i);
                                break;
                            case SystemData.KeyValueDataTable.VALUE1:
                                keyValueData.VALUE1 = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstKeyValueDatas.Add(keyValueData);
                } while (dataReader.Read());
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
    }
}