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
    public class QcMsgDictAccess : DBAccessBase
    {
        private static QcMsgDictAccess m_Instance = null;
        public static QcMsgDictAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcMsgDictAccess();
                return m_Instance;
            }
        }
        #region"质控反馈问题字典管理接口"
        /// <summary>
        /// 病历质控系统,获取质控反馈信息字典列表
        /// </summary>
        /// <param name="lstQCMessageTemplets">质控反馈信息字典列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcMsgDictList(ref List<QcMsgDict> lstQcMsgDicts)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}"
               , SystemData.QcMsgDictTable.APPLY_ENV
               , SystemData.QcMsgDictTable.INPUT_CODE
               , SystemData.QcMsgDictTable.ISVETO
               , SystemData.QcMsgDictTable.MESSAGE
               , SystemData.QcMsgDictTable.MESSAGE_TITLE
               , SystemData.QcMsgDictTable.QA_EVENT_TYPE
               , SystemData.QcMsgDictTable.QC_MSG_CODE
               , SystemData.QcMsgDictTable.SCORE
               , SystemData.QcMsgDictTable.SERIAL_NO
               );
            string szCondtion = string.Format("1=1");
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataTable.QC_MSG_DICT, szCondtion
               , SystemData.QcMsgDictTable.SERIAL_NO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
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
                base.QCAccess.CloseConnnection(false);
            }
        }
        public short GetQcMsgDictList(string szQaEventType, string szMessageTitle, ref List<QcMsgDict> lstQCMessageTemplets)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}"
               , SystemData.QcMsgDictTable.SERIAL_NO, SystemData.QcMsgDictTable.QC_MSG_CODE, SystemData.QcMsgDictTable.QA_EVENT_TYPE
               , SystemData.QcMsgDictTable.MESSAGE, SystemData.QcMsgDictTable.SCORE, SystemData.QcMsgDictTable.INPUT_CODE
               , SystemData.QcMsgDictTable.MESSAGE_TITLE, SystemData.QcMsgDictTable.ISVETO);
            string szCondtion = string.Format("1=1");
            if (!string.IsNullOrEmpty(szQaEventType))
            {
                szCondtion = string.Format("{0} AND {1}='{2}'"
                    , szCondtion
                    , SystemData.QcMsgDictTable.QA_EVENT_TYPE
                    , szQaEventType);
            }
            if (!string.IsNullOrEmpty(szMessageTitle))
            {
                szCondtion = string.Format("{0} AND {1}='{2}'"
                    , szCondtion
                    , SystemData.QcMsgDictTable.MESSAGE_TITLE
                    , szMessageTitle);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataTable.QC_MSG_DICT, szCondtion
               , SystemData.QcMsgDictTable.SERIAL_NO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
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
                LogManager.Instance.WriteLog("QcMsgDictAccess.GetQcMsgDictList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        public short GetQcMsgDict(string szQcMsgCode, ref QcMsgDict msgTemplet)
        {
            if (base.QCAccess == null)
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
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
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
                base.QCAccess.CloseConnnection(false);
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
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}"
               , SystemData.QcMsgDictTable.SERIAL_NO, SystemData.QcMsgDictTable.QC_MSG_CODE, SystemData.QcMsgDictTable.QA_EVENT_TYPE
               , SystemData.QcMsgDictTable.MESSAGE, SystemData.QcMsgDictTable.SCORE, SystemData.QcMsgDictTable.INPUT_CODE
               , SystemData.QcMsgDictTable.MESSAGE_TITLE, SystemData.QcMsgDictTable.ISVETO);
            string szCondition = " 1=1 ";
            if (!string.IsNullOrEmpty(szQuestionType))
                szCondition = string.Format("{0}='{1}'", SystemData.QcMsgDictTable.QA_EVENT_TYPE, szQuestionType);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                , SystemData.DataTable.QC_MSG_DICT, szCondition, SystemData.QcMsgDictTable.SERIAL_NO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
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
                base.QCAccess.CloseConnnection(false);
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

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}"
                , SystemData.QcMsgDictTable.APPLY_ENV
                , SystemData.QcMsgDictTable.INPUT_CODE
                , SystemData.QcMsgDictTable.ISVETO
                , SystemData.QcMsgDictTable.MESSAGE
                , SystemData.QcMsgDictTable.MESSAGE_TITLE
                , SystemData.QcMsgDictTable.QA_EVENT_TYPE
                , SystemData.QcMsgDictTable.QC_MSG_CODE
                , SystemData.QcMsgDictTable.SCORE
                , SystemData.QcMsgDictTable.SERIAL_NO);

            string szValue = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7},{8}"
                , qcMsgDict.APPLY_ENV
                , qcMsgDict.INPUT_CODE
                , qcMsgDict.ISVETO ? 1 : 0
                , qcMsgDict.MESSAGE
                , qcMsgDict.MESSAGE_TITLE
                , qcMsgDict.QA_EVENT_TYPE
                , qcMsgDict.QC_MSG_CODE
                , qcMsgDict.SCORE
                , qcMsgDict.SERIAL_NO);

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_MSG_DICT, szField, szValue);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.SaveQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.SaveQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
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

            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}='{5}',{6}='{7}',{8}='{9}',{10}='{11}',{12}='{13}',{14}={15},{16}={17}"
                , SystemData.QcMsgDictTable.APPLY_ENV, qcMsgDict.APPLY_ENV
                , SystemData.QcMsgDictTable.INPUT_CODE, qcMsgDict.INPUT_CODE
                , SystemData.QcMsgDictTable.ISVETO, qcMsgDict.ISVETO?1:0
                , SystemData.QcMsgDictTable.MESSAGE, qcMsgDict.MESSAGE
                , SystemData.QcMsgDictTable.MESSAGE_TITLE, qcMsgDict.MESSAGE_TITLE
                , SystemData.QcMsgDictTable.QA_EVENT_TYPE, qcMsgDict.QA_EVENT_TYPE
                , SystemData.QcMsgDictTable.QC_MSG_CODE, qcMsgDict.QC_MSG_CODE
                , SystemData.QcMsgDictTable.SCORE, qcMsgDict.SCORE
                , SystemData.QcMsgDictTable.SERIAL_NO, qcMsgDict.SERIAL_NO);

            string szCondition = string.Format("{0}='{1}'", SystemData.QcMsgDictTable.QC_MSG_CODE, szOldQCMsgCode);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_MSG_DICT, szField, szCondition);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("QcMsgDictAccess.Update", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.UpdateQcCheckPoint", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
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
            if (base.QCAccess == null)
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
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
