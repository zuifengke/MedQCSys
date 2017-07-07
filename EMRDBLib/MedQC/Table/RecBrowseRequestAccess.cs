// ***********************************************************
// 数据库访问层通用操作有关的数据访问接口.
// Creator:YangMingkun  Date:2010-11-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using EMRDBLib.DbAccess;
using System.Reflection;

namespace EMRDBLib
{

    public class RecBrowseRequestAccess : DBAccessBase
    {
        public const string TableName = SystemData.DataTable.REC_BROWSE_REQUEST;
        public const string KeyName = SystemData.RecBrowseRequestTable.ID;
        private static RecBrowseRequestAccess m_Instance = null;
        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static RecBrowseRequestAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new RecBrowseRequestAccess();
                return m_Instance;
            }
        }
        public short Insert(RecBrowseRequest model)
        {
            if (model == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { model }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (model.ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            PropertyInfo[] PropertyList = Reflect.GetProperties<RecBrowseRequest>(model);
            foreach (var item in PropertyList)
            {
                string name = item.Name;
                object value = item.GetValue(model, null);

                switch (item.PropertyType.Name)
                {
                    case "Decimal":
                        sbField.AppendFormat("{0},", name);
                        sbValue.AppendFormat("{0},", value);
                        break;
                    case "DateTime":
                        DateTime dt = DateTime.Parse(value.ToString());
                        if (dt == model.DefaultTime || dt == model.DefaultTime2)
                            break;
                        sbField.AppendFormat("{0},", name);
                        sbValue.AppendFormat("{0},", base.MedQCAccess.GetSqlTimeFormat(dt));
                        break;
                    default:
                        sbField.AppendFormat("{0},", name);
                        sbValue.AppendFormat("'{0}',", value);
                        break;
                }
            }
            string szField = sbField.ToString().Substring(0, sbField.Length - 1);
            string szValue = sbValue.ToString().Substring(0, sbValue.Length - 1);
            string szSQL = string.Format(SystemData.SQL.INSERT
                , SystemData.DataTable.REC_BROWSE_REQUEST
                , szField
                , szValue);
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
        public short Update(RecBrowseRequest model)
        {
            if (model == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { model }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            PropertyInfo[] PropertyList = Reflect.GetProperties<RecBrowseRequest>(model);
            foreach (var item in PropertyList)
            {
                string name = item.Name;
                object value = item.GetValue(model, null);

                switch (item.PropertyType.Name)
                {
                    case "Decimal":
                        sbField.AppendFormat("{0}={1},", name, value);
                        break;
                    case "int":
                        sbField.AppendFormat("{0}={1},", name, value);
                        break;
                    case "DateTime":
                        DateTime dt = DateTime.Parse(value.ToString());
                        if (dt == model.DefaultTime || dt == model.DefaultTime2)
                            break;
                        sbField.AppendFormat("{0}={1},", name, base.MedQCAccess.GetSqlTimeFormat(dt));
                        break;
                    default:
                        sbField.AppendFormat("{0}='{1}',", name, value);
                        break;
                }
            }
            string szField = sbField.ToString().Substring(0, sbField.Length - 1);
            string szCondition = string.Format("{0}='{1}'", KeyName, model.ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, TableName, szField, szCondition);
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
        public short Delete(string id)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(id))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { id }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", KeyName, id);
            string szSQL = string.Format(SystemData.SQL.DELETE, TableName, szCondition);
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
        public short GetModel(string id, ref RecBrowseRequest model)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' "
                , szCondition
                , KeyName
                , id);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), TableName, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }

                model = new RecBrowseRequest();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    PropertyInfo property = Reflect.GetPropertyInfo(typeof(RecBrowseRequest), dataReader.GetName(i));
                    bool result = Reflect.SetPropertyValue(model, property, dataReader.GetValue(i));
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        public short GetList(ref List<RecBrowseRequest> lst)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), TableName, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lst == null)
                    lst = new List<RecBrowseRequest>();
                do
                {
                    RecBrowseRequest model = new RecBrowseRequest();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecBrowseRequestTable.APPROVAL_ID:
                                model.APPROVAL_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.APPROVAL_NAME:
                                model.APPROVAL_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.APPROVAL_TIME:
                                model.APPROVAL_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecBrowseRequestTable.DISCHARGE_TIME:
                                model.DISCHARGE_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecBrowseRequestTable.ID:
                                model.ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.PATIENT_ID:
                                model.PATIENT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.PATIENT_NAME:
                                model.PATIENT_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.REQUEST_ID:
                                model.REQUEST_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.REQUEST_NAME:
                                model.REQUEST_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.REQUEST_TIME:
                                model.REQUEST_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecBrowseRequestTable.STATUS:
                                model.STATUS = decimal.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecBrowseRequestTable.VISIT_ID:
                                model.VISIT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.VISIT_NO:
                                model.REQUEST_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.REMARK:
                                model.REMARK = dataReader.GetValue(i).ToString();
                                break;
                        }
                    }
                    lst.Add(model);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
        public short GetList(string szPatientID, string szVisitID, string szRequestID, ref List<RecBrowseRequest> lst)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1}='{2}' AND {3}='{4}' AND {5}='{6}'"
                , szCondition
                , SystemData.RecBrowseRequestTable.PATIENT_ID, szPatientID
                , SystemData.RecBrowseRequestTable.VISIT_ID, szVisitID
                , SystemData.RecBrowseRequestTable.REQUEST_ID, szRequestID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), TableName, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lst == null)
                    lst = new List<RecBrowseRequest>();
                do
                {
                    RecBrowseRequest model = new RecBrowseRequest();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecBrowseRequestTable.APPROVAL_ID:
                                model.APPROVAL_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.APPROVAL_NAME:
                                model.APPROVAL_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.APPROVAL_TIME:
                                model.APPROVAL_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecBrowseRequestTable.DISCHARGE_TIME:
                                model.DISCHARGE_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecBrowseRequestTable.ID:
                                model.ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.PATIENT_ID:
                                model.PATIENT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.PATIENT_NAME:
                                model.PATIENT_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.REQUEST_ID:
                                model.REQUEST_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.REQUEST_NAME:
                                model.REQUEST_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.REQUEST_TIME:
                                model.REQUEST_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecBrowseRequestTable.STATUS:
                                model.STATUS = decimal.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecBrowseRequestTable.VISIT_ID:
                                model.VISIT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.VISIT_NO:
                                model.REQUEST_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.RecBrowseRequestTable.REMARK:
                                model.REMARK = dataReader.GetValue(i).ToString();
                                break;
                        }
                    }
                    lst.Add(model);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }

    }
}
