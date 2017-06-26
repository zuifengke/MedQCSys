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
using System.Reflection;
using System.Collections;

namespace EMRDBLib.DbAccess
{
    public class QcMsgDictAccess : DBAccessBase
    {
        private static QcMsgDictAccess m_Instance = null;
        private static Dictionary<string, PropertyInfo> m_htProperty = null;
        public static QcMsgDictAccess Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new QcMsgDictAccess();
                    m_htProperty = new Dictionary<string, PropertyInfo>();
                    QcMsgDict model = new QcMsgDict();
                    PropertyInfo[] propertyInfos= Reflect.GetProperties<QcMsgDict>(model);
                    foreach (var item in propertyInfos)
                    {
                        m_htProperty.Add(item.Name, item);
                    }
                }
                return m_Instance;
            }
        }
        #region"质控反馈问题字典管理接口"
        /// <summary>
        /// 病历质控系统,获取质控反馈信息字典列表
        /// </summary>
        /// <param name="lstQcMsgDicts">质控反馈信息字典列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetAllQcMsgDictList(ref List<QcMsgDict> lstQcMsgDicts)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("*");
            string szCondtion = string.Format("1=1 ");
            string szOrderBy = string.Format("{0},{1}"
                , SystemData.QcMsgDictTable.SERIAL_NO
                , SystemData.QcMsgDictTable.QC_MSG_CODE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataTable.QC_MSG_DICT, szCondtion
               , szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsgDicts == null)
                    lstQcMsgDicts = new List<QcMsgDict>();
                lstQcMsgDicts.Clear();
                do
                {
                    QcMsgDict model = new QcMsgDict();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        //PropertyInfo propertyInfo = m_htProperty[dataReader.GetName(i)];
                        //bool result = Reflect.SetPropertyValue(model, propertyInfo, dataReader.GetValue(i));
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.QcMsgDictTable.APPLY_ENV:
                                model.APPLY_ENV = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QcMsgDictTable.INPUT_CODE:
                                model.INPUT_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QcMsgDictTable.ISVETO:
                                model.ISVETO = dataReader.GetValue(i).ToString() == "1";
                                break;
                            case SystemData.QcMsgDictTable.IS_VALID:
                                model.IS_VALID = decimal.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcMsgDictTable.MESSAGE:
                                model.MESSAGE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QcMsgDictTable.MESSAGE_TITLE:
                                model.MESSAGE_TITLE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QcMsgDictTable.QA_EVENT_TYPE:
                                model.QA_EVENT_TYPE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QcMsgDictTable.QC_MSG_CODE:
                                model.QC_MSG_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.QcMsgDictTable.SCORE:
                                model.SCORE = float.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.QcMsgDictTable.SERIAL_NO:
                                model.SERIAL_NO = int.Parse(dataReader.GetValue(i).ToString());
                                break;

                            default: break;
                        }
                    }
                    lstQcMsgDicts.Add(model);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 病历质控系统,获取质控反馈信息有效字典列表
        /// </summary>
        /// <param name="lstQcMsgDicts">质控反馈信息字典列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcMsgDictList(ref List<QcMsgDict> lstQcMsgDicts)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}"
               , SystemData.QcMsgDictTable.APPLY_ENV
               , SystemData.QcMsgDictTable.INPUT_CODE
               , SystemData.QcMsgDictTable.ISVETO
               , SystemData.QcMsgDictTable.MESSAGE
               , SystemData.QcMsgDictTable.MESSAGE_TITLE
               , SystemData.QcMsgDictTable.QA_EVENT_TYPE
               , SystemData.QcMsgDictTable.QC_MSG_CODE
               , SystemData.QcMsgDictTable.SCORE
               , SystemData.QcMsgDictTable.SERIAL_NO
               , SystemData.QcMsgDictTable.IS_VALID
               );
            string szOrderBy = string.Format("{0},{1}"
               , SystemData.QcMsgDictTable.SERIAL_NO
               , SystemData.QcMsgDictTable.QC_MSG_CODE);
            string szCondtion = string.Format("1=1 and {0} = 1", SystemData.QcMsgDictTable.IS_VALID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataTable.QC_MSG_DICT, szCondtion
               , szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsgDicts == null)
                    lstQcMsgDicts = new List<QcMsgDict>();
                do
                {
                    QcMsgDict qcMsgDict = new QcMsgDict();
                    if (!dataReader.IsDBNull(0)) qcMsgDict.APPLY_ENV = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) qcMsgDict.INPUT_CODE = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcMsgDict.ISVETO = dataReader.GetString(2) == "0" ? false : true;
                    if (!dataReader.IsDBNull(3)) qcMsgDict.MESSAGE = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) qcMsgDict.MESSAGE_TITLE = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) qcMsgDict.QA_EVENT_TYPE = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) qcMsgDict.QC_MSG_CODE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) qcMsgDict.SCORE = float.Parse(dataReader.GetValue(7).ToString());
                    if (!dataReader.IsDBNull(8)) qcMsgDict.SERIAL_NO = int.Parse(dataReader.GetValue(8).ToString());
                    if (!dataReader.IsDBNull(9)) qcMsgDict.IS_VALID = decimal.Parse(dataReader.GetValue(9).ToString());
                    lstQcMsgDicts.Add(qcMsgDict);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCMessageTempletList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        public short GetQcMsgDict(string szQcMsgCode, ref QcMsgDict msgTemplet)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}"
               , SystemData.QcMsgDictTable.SERIAL_NO
               , SystemData.QcMsgDictTable.QC_MSG_CODE
               , SystemData.QcMsgDictTable.QA_EVENT_TYPE
               , SystemData.QcMsgDictTable.MESSAGE
               , SystemData.QcMsgDictTable.SCORE
               , SystemData.QcMsgDictTable.INPUT_CODE
               , SystemData.QcMsgDictTable.MESSAGE_TITLE
               , SystemData.QcMsgDictTable.ISVETO);
            string szCondtion = string.Format("{0}='{1}'"

                , SystemData.QcMsgDictTable.QC_MSG_CODE, szQcMsgCode);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataTable.QC_MSG_DICT, szCondtion
               , SystemData.QcMsgDictTable.SERIAL_NO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (msgTemplet == null)
                    msgTemplet = new QcMsgDict();
                if (!dataReader.IsDBNull(0)) msgTemplet.SERIAL_NO = int.Parse(dataReader.GetValue(0).ToString());
                if (!dataReader.IsDBNull(1)) msgTemplet.QC_MSG_CODE = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2)) msgTemplet.QA_EVENT_TYPE = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3)) msgTemplet.MESSAGE = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4)) msgTemplet.SCORE = float.Parse(dataReader.GetValue(4).ToString());
                if (!dataReader.IsDBNull(5)) msgTemplet.INPUT_CODE = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6)) msgTemplet.MESSAGE_TITLE = dataReader.GetString(6);
                if (!dataReader.IsDBNull(7)) msgTemplet.ISVETO = dataReader.GetString(7) == "1";
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 根据问题类型获取质控反馈信息字典列表
        /// </summary>
        /// <param name="szQuestionType">问题类型</param>
        /// <param name="lstQCMessageTemplets">质控反馈信息字典列表</param>
        /// <returns>MedDocSys.Common.SystemData.ReturnValue</returns>
        public short GetQcMsgDictList(string szQuestionType, ref List<EMRDBLib.QcMsgDict> lstQCMessageTemplets)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}"
               , SystemData.QcMsgDictTable.SERIAL_NO, SystemData.QcMsgDictTable.QC_MSG_CODE, SystemData.QcMsgDictTable.QA_EVENT_TYPE
               , SystemData.QcMsgDictTable.MESSAGE, SystemData.QcMsgDictTable.SCORE, SystemData.QcMsgDictTable.INPUT_CODE
               , SystemData.QcMsgDictTable.MESSAGE_TITLE, SystemData.QcMsgDictTable.ISVETO);
            string szCondition = string.Format(" 1=1 and {0}=1", SystemData.QcMsgDictTable.IS_VALID);
            if (!string.IsNullOrEmpty(szQuestionType))
                szCondition = string.Format("{0} AND {1}='{2}'"
                    , szCondition
                    , SystemData.QcMsgDictTable.QA_EVENT_TYPE, szQuestionType);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                , SystemData.DataTable.QC_MSG_DICT, szCondition, SystemData.QcMsgDictTable.SERIAL_NO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCMessageTemplets == null)
                    lstQCMessageTemplets = new List<QcMsgDict>();
                do
                {
                    QcMsgDict qcMessageTemplet = new QcMsgDict();
                    if (!dataReader.IsDBNull(0)) qcMessageTemplet.SERIAL_NO = int.Parse(dataReader.GetValue(0).ToString());
                    if (!dataReader.IsDBNull(1)) qcMessageTemplet.QC_MSG_CODE = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcMessageTemplet.QA_EVENT_TYPE = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcMessageTemplet.MESSAGE = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) qcMessageTemplet.SCORE = float.Parse(dataReader.GetValue(4).ToString());
                    if (!dataReader.IsDBNull(5)) qcMessageTemplet.INPUT_CODE = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) qcMessageTemplet.MESSAGE_TITLE = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) qcMessageTemplet.ISVETO = dataReader.GetString(7) == "1";
                    lstQCMessageTemplets.Add(qcMessageTemplet);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCMessageTempletList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 新增一条自动核查规则配置信息
        /// </summary>
        /// <param name="qcMsgDict">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(QcMsgDict qcMsgDict)
        {
            if (qcMsgDict == null)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.Insert", new string[] { "timeQCRule" }
                    , new object[] { qcMsgDict }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}"
                , SystemData.QcMsgDictTable.APPLY_ENV
                , SystemData.QcMsgDictTable.INPUT_CODE
                , SystemData.QcMsgDictTable.ISVETO
                , SystemData.QcMsgDictTable.MESSAGE
                , SystemData.QcMsgDictTable.MESSAGE_TITLE
                , SystemData.QcMsgDictTable.QA_EVENT_TYPE
                , SystemData.QcMsgDictTable.QC_MSG_CODE
                , SystemData.QcMsgDictTable.SCORE
                , SystemData.QcMsgDictTable.SERIAL_NO
                , SystemData.QcMsgDictTable.IS_VALID);

            string szValue = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},{9}"
                , qcMsgDict.APPLY_ENV
                , qcMsgDict.INPUT_CODE
                , qcMsgDict.ISVETO ? 1 : 0
                , qcMsgDict.MESSAGE
                , qcMsgDict.MESSAGE_TITLE
                , qcMsgDict.QA_EVENT_TYPE
                , qcMsgDict.QC_MSG_CODE
                , qcMsgDict.SCORE
                , qcMsgDict.SERIAL_NO
                , qcMsgDict.IS_VALID);

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_MSG_DICT, szField, szValue);
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
        /// 病历质控系统,修改一条质控反馈信息
        /// </summary>
        /// <param name="item">质控反馈信息</param>
        /// <param name="szOldQCMsgCode">旧的反馈信息代码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(QcMsgDict qcMsgDict, string szOldQCMsgCode)
        {
            if (qcMsgDict == null)
            {
                LogManager.Instance.WriteLog("QcMsgDictAccess.Update", new string[] { "qcMsgDict" }
                    , new object[] { qcMsgDict }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}='{5}',{6}='{7}',{8}='{9}',{10}='{11}',{12}='{13}',{14}={15},{16}={17},{18}={19}"
                , SystemData.QcMsgDictTable.APPLY_ENV, qcMsgDict.APPLY_ENV
                , SystemData.QcMsgDictTable.INPUT_CODE, qcMsgDict.INPUT_CODE
                , SystemData.QcMsgDictTable.ISVETO, qcMsgDict.ISVETO ? 1 : 0
                , SystemData.QcMsgDictTable.MESSAGE, qcMsgDict.MESSAGE
                , SystemData.QcMsgDictTable.MESSAGE_TITLE, qcMsgDict.MESSAGE_TITLE
                , SystemData.QcMsgDictTable.QA_EVENT_TYPE, qcMsgDict.QA_EVENT_TYPE
                , SystemData.QcMsgDictTable.QC_MSG_CODE, qcMsgDict.QC_MSG_CODE
                , SystemData.QcMsgDictTable.SCORE, qcMsgDict.SCORE
                , SystemData.QcMsgDictTable.SERIAL_NO, qcMsgDict.SERIAL_NO
                , SystemData.QcMsgDictTable.IS_VALID, qcMsgDict.IS_VALID);

            string szCondition = string.Format("{0}='{1}'", SystemData.QcMsgDictTable.QC_MSG_CODE, szOldQCMsgCode);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_MSG_DICT, szField, szCondition);
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
        ///  病历质控系统,根据反馈信息代码,删除指定反馈信息
        /// </summary>
        /// <param name="szQCMsgCode">反馈信息代码</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szQCMsgCode)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szQCMsgCode))
            {
                LogManager.Instance.WriteLog("QcMsgDictAccess.Delete", new string[] { "szRuleID" }
                    , new object[] { szQCMsgCode }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.QcMsgDictTable.QC_MSG_CODE, szQCMsgCode);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_MSG_DICT, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcMsgDictAccess.Delete", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("QcMsgDictAccess.Delete", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        #endregion
    }
}
