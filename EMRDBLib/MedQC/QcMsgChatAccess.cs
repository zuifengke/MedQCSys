using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    public class QcMsgChatAccess : DBAccessBase
    {
        private static QcMsgChatAccess m_instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static QcMsgChatAccess Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new QcMsgChatAccess();
                return m_instance;
            }
        }
        #region"质控问题消息沟通操作接口"

        /// <summary>
        /// 根据聊天记录ID获取图片
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="byteDocData">文档二进制内容</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short GetQCMsgChatInfoImage(string szChatID, ref byte[] byteImage)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}'", SystemData.QCMsgChatTable.CHAT_ID, szChatID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                , SystemData.QCMsgChatTable.CHAT_IMAGE, SystemData.DataTable.QC_MSG_CHAT_LOG, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    LogManager.Instance.WriteLog("DBAccess.GetQCMsgChatInfoImage"
                        , new string[] { "szSQL" }, new object[] { szSQL }, "没有查询到记录!");
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                return GlobalMethods.IO.GetBytes(dataReader, 0, ref byteImage)
                    ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQCMsgChatInfoImage", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 获取质控问题沟通消息列表
        /// </summary>
        /// <param name="szListenserID"></param>
        /// <param name="bIsRead"></param>
        /// <param name="lstQcMsgChatLog"></param>
        /// <returns></returns>
        public short GetQCMsgChatLogList(string szListenser, bool bIsRead, ref List<QcMsgChatLog> lstQcMsgChatLog)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}"
                , SystemData.QCMsgChatTable.CHAT_CONTENT
                , SystemData.QCMsgChatTable.CHAT_ID
                , SystemData.QCMsgChatTable.CHAT_SEND_DATE
                , SystemData.QCMsgChatTable.IS_READ
                , SystemData.QCMsgChatTable.LISTENER
                , SystemData.QCMsgChatTable.PATIENT_ID
                , SystemData.QCMsgChatTable.SENDER
                , SystemData.QCMsgChatTable.VISIT_ID
                , SystemData.QCMsgChatTable.MSG_CHAT_DATA_TYPE
                , "MSG_ID"
                );
            string szCondition = string.Format(" 1=1  and {0}='{1}' and {2}={3} "
                , SystemData.QCMsgChatTable.LISTENER, szListenser
                , SystemData.QCMsgChatTable.IS_READ, bIsRead ? "1" : "0"
                );

            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_DESC, szField
                  , SystemData.DataTable.QC_MSG_CHAT_LOG
                  , szCondition
                  , SystemData.QCMsgChatTable.CHAT_SEND_DATE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsgChatLog == null)
                    lstQcMsgChatLog = new List<QcMsgChatLog>();
                do
                {
                    QcMsgChatLog qcMsgChatLog = new QcMsgChatLog();
                    if (!dataReader.IsDBNull(0)) qcMsgChatLog.ChatContent = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) qcMsgChatLog.ChatID = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcMsgChatLog.ChatSendDate = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) qcMsgChatLog.IsRead = dataReader.GetValue(3).ToString() == "1" ? true : false;
                    if (!dataReader.IsDBNull(4)) qcMsgChatLog.Listener = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) qcMsgChatLog.PatientID = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) qcMsgChatLog.Sender = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) qcMsgChatLog.VisitID = dataReader.GetValue(7).ToString();
                    if (!dataReader.IsDBNull(8)) qcMsgChatLog.MsgChatDataType = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) qcMsgChatLog.MsgID = dataReader.GetString(9);
                    lstQcMsgChatLog.Add(qcMsgChatLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQCMsgChatLogList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 通过发送时间查询质控问题沟通消息列表
        /// </summary>
        /// <param name="szListenserID"></param>
        /// <param name="bIsRead"></param>
        /// <param name="lstQcMsgChatLog"></param>
        /// <returns></returns>
        public short GetQCMsgChatLogList(string szListenser, DateTime dtBeginTime, DateTime dtEndTime, ref List<QcMsgChatLog> lstQcMsgChatLog)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}"
                , SystemData.QCMsgChatTable.CHAT_CONTENT
                , SystemData.QCMsgChatTable.CHAT_ID
                , SystemData.QCMsgChatTable.CHAT_SEND_DATE
                , SystemData.QCMsgChatTable.IS_READ
                , SystemData.QCMsgChatTable.LISTENER
                , SystemData.QCMsgChatTable.PATIENT_ID
                , SystemData.QCMsgChatTable.SENDER
                , SystemData.QCMsgChatTable.VISIT_ID
                , SystemData.QCMsgChatTable.MSG_CHAT_DATA_TYPE
                , "MSG_ID"
                );
            string szCondition = string.Format(" 1=1  and {0}='{1}' and {2} >= {3} and {4} <={5}"
                , SystemData.QCMsgChatTable.LISTENER, szListenser
                , SystemData.QCMsgChatTable.CHAT_SEND_DATE, base.QCAccess.GetSqlTimeFormat(dtBeginTime)
                , SystemData.QCMsgChatTable.CHAT_SEND_DATE, base.QCAccess.GetSqlTimeFormat(dtEndTime)
                );

            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_DESC, szField
                  , SystemData.DataTable.QC_MSG_CHAT_LOG
                  , szCondition
                  , SystemData.QCMsgChatTable.CHAT_SEND_DATE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsgChatLog == null)
                    lstQcMsgChatLog = new List<QcMsgChatLog>();
                do
                {
                    QcMsgChatLog qcMsgChatLog = new QcMsgChatLog();
                    if (!dataReader.IsDBNull(0)) qcMsgChatLog.ChatContent = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) qcMsgChatLog.ChatID = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcMsgChatLog.ChatSendDate = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) qcMsgChatLog.IsRead = dataReader.GetValue(3).ToString() == "1" ? true : false;
                    if (!dataReader.IsDBNull(4)) qcMsgChatLog.Listener = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) qcMsgChatLog.PatientID = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) qcMsgChatLog.Sender = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) qcMsgChatLog.VisitID = dataReader.GetValue(7).ToString();
                    if (!dataReader.IsDBNull(8)) qcMsgChatLog.MsgChatDataType = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) qcMsgChatLog.MsgID = dataReader.GetString(9);
                    lstQcMsgChatLog.Add(qcMsgChatLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQCMsgChatLogList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取质控问题沟通消息列表,查找某份病案所有的沟通资料
        /// </summary>
        /// <param name="szListenserID"></param>
        /// <param name="bIsRead"></param>
        /// <param name="lstQcMsgChatLog"></param>
        /// <returns></returns>
        public short GetQCMsgChatLogList(string szPatientID, string szVisitID, ref List<QcMsgChatLog> lstQcMsgChatLog)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}"
                , SystemData.QCMsgChatTable.CHAT_CONTENT
                , SystemData.QCMsgChatTable.CHAT_ID
                , SystemData.QCMsgChatTable.CHAT_SEND_DATE
                , SystemData.QCMsgChatTable.IS_READ
                , SystemData.QCMsgChatTable.LISTENER
                , SystemData.QCMsgChatTable.PATIENT_ID
                , SystemData.QCMsgChatTable.SENDER
                , SystemData.QCMsgChatTable.VISIT_ID
                , SystemData.QCMsgChatTable.MSG_CHAT_DATA_TYPE
                , "MSG_ID"
                );
            string szCondition = string.Format(" 1=1  and {0}='{1}' and {2}='{3}' "
                , SystemData.QCMsgChatTable.PATIENT_ID, szPatientID
                , SystemData.QCMsgChatTable.VISIT_ID, szVisitID
                );

            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_ASC, szField
                  , SystemData.DataTable.QC_MSG_CHAT_LOG
                  , szCondition
                  , SystemData.QCMsgChatTable.CHAT_SEND_DATE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsgChatLog == null)
                    lstQcMsgChatLog = new List<QcMsgChatLog>();
                do
                {
                    QcMsgChatLog qcMsgChatLog = new QcMsgChatLog();
                    if (!dataReader.IsDBNull(0)) qcMsgChatLog.ChatContent = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) qcMsgChatLog.ChatID = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcMsgChatLog.ChatSendDate = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) qcMsgChatLog.IsRead = dataReader.GetValue(3).ToString() == "1" ? true : false;
                    if (!dataReader.IsDBNull(4)) qcMsgChatLog.Listener = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) qcMsgChatLog.PatientID = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) qcMsgChatLog.Sender = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) qcMsgChatLog.VisitID = dataReader.GetValue(7).ToString();
                    if (!dataReader.IsDBNull(8)) qcMsgChatLog.MsgChatDataType = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) qcMsgChatLog.MsgID = dataReader.GetString(9);
                    lstQcMsgChatLog.Add(qcMsgChatLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQCMsgChatLogList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取质控问题沟通消息列表,查找某份病案发给当前用户的未读消息
        /// </summary>
        /// <param name="szListenserID"></param>
        /// <param name="bIsRead"></param>
        /// <param name="lstQcMsgChatLog"></param>
        /// <returns></returns>
        public short GetQCMsgChatLogList(string szPatientID, string szVisitID, string szListener, ref List<QcMsgChatLog> lstQcMsgChatLog)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}"
                , SystemData.QCMsgChatTable.CHAT_CONTENT
                , SystemData.QCMsgChatTable.CHAT_ID
                , SystemData.QCMsgChatTable.CHAT_SEND_DATE
                , SystemData.QCMsgChatTable.IS_READ
                , SystemData.QCMsgChatTable.LISTENER
                , SystemData.QCMsgChatTable.PATIENT_ID
                , SystemData.QCMsgChatTable.SENDER
                , SystemData.QCMsgChatTable.VISIT_ID
                , SystemData.QCMsgChatTable.MSG_CHAT_DATA_TYPE
                , "MSG_ID"
                );
            string szCondition = string.Format(" 1=1  and {0}='{1}' and {2}='{3}' and {4}='{5}' and {6}=0  "
                , SystemData.QCMsgChatTable.PATIENT_ID, szPatientID
                , SystemData.QCMsgChatTable.VISIT_ID, szVisitID
                , SystemData.QCMsgChatTable.LISTENER, szListener
                , SystemData.QCMsgChatTable.IS_READ
                );

            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_ASC, szField
                  , SystemData.DataTable.QC_MSG_CHAT_LOG
                  , szCondition
                  , SystemData.QCMsgChatTable.CHAT_SEND_DATE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsgChatLog == null)
                    lstQcMsgChatLog = new List<QcMsgChatLog>();
                do
                {
                    QcMsgChatLog qcMsgChatLog = new QcMsgChatLog();
                    if (!dataReader.IsDBNull(0)) qcMsgChatLog.ChatContent = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) qcMsgChatLog.ChatID = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcMsgChatLog.ChatSendDate = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) qcMsgChatLog.IsRead = dataReader.GetValue(3).ToString() == "1" ? true : false;
                    if (!dataReader.IsDBNull(4)) qcMsgChatLog.Listener = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) qcMsgChatLog.PatientID = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) qcMsgChatLog.Sender = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) qcMsgChatLog.VisitID = dataReader.GetValue(7).ToString();
                    if (!dataReader.IsDBNull(8)) qcMsgChatLog.MsgChatDataType = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) qcMsgChatLog.MsgID = dataReader.GetString(9);
                    lstQcMsgChatLog.Add(qcMsgChatLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQCMsgChatLogList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 保存一条质控问题沟通消息
        /// </summary>
        /// <param name="HdpUIConfig">界面配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveQCMsgChatLog(QcMsgChatLog qcMsgChatLog, byte[] byteImage)
        {
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}"
               , SystemData.QCMsgChatTable.CHAT_CONTENT
               , SystemData.QCMsgChatTable.CHAT_ID
               , SystemData.QCMsgChatTable.CHAT_SEND_DATE
               , SystemData.QCMsgChatTable.IS_READ
               , SystemData.QCMsgChatTable.LISTENER
               , SystemData.QCMsgChatTable.PATIENT_ID
               , SystemData.QCMsgChatTable.SENDER
               , SystemData.QCMsgChatTable.VISIT_ID
               , SystemData.QCMsgChatTable.MSG_CHAT_DATA_TYPE
               , "MSG_ID");
            string szValue = string.Format("'{0}','{1}',{2},{3},'{4}','{5}','{6}','{7}',{8},'{9}'"
                , qcMsgChatLog.ChatContent
                , qcMsgChatLog.ChatID
                , base.QCAccess.GetSqlTimeFormat(qcMsgChatLog.ChatSendDate)
                , qcMsgChatLog.IsRead ? "1" : "0"
                , qcMsgChatLog.Listener
                , qcMsgChatLog.PatientID
                , qcMsgChatLog.Sender
                , qcMsgChatLog.VisitID
                , qcMsgChatLog.MsgChatDataType
                , qcMsgChatLog.MsgID
               );

            int nCount = 0;

            DbParameter[] pmi = null;
            if (byteImage != null)
            {
                szField = string.Format("{0},{1}", szField, SystemData.QCMsgChatTable.CHAT_IMAGE);
                szValue = string.Format("{0},{1}", szValue, base.QCAccess.GetSqlParamName("CHAT_IMAGE"));

                pmi = new DbParameter[1];
                pmi[0] = new DbParameter("CHAT_IMAGE", byteImage);
            }
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_MSG_CHAT_LOG, szField, szValue);
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.SaveQCMsgChatLog", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }
        #endregion

        public short UpdateQCMsgChatLog(QcMsgChatLog item)
        {
            string szField = string.Format("{0}={1}"
                , SystemData.QCMsgChatTable.IS_READ, item.IsRead ? "1" : "0");
            string szCondition = string.Format("{0}='{1}'"
                , SystemData.QCMsgChatTable.CHAT_ID, item.ChatID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QC_MSG_CHAT_LOG, szField, szCondition);

            int nCount = 0;
            try
            {

                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.UpdateQCMsgChatLog", new string[] { "SQL" }, new object[] { szSQL }, "SQL执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return nCount > 0 ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }
        /// <summary>
        /// 获取ID聊天过的用户ID List
        /// </summary>
        /// <param name="szUserID"></param>
        /// <param name="lstUserID"></param>
        /// <returns></returns>
        public short GetQCMsgLogUserID(string szUserID, ref List<string> lstUserID)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1}",
                SystemData.QCMsgChatTable.SENDER,
                 SystemData.QCMsgChatTable.LISTENER);
            string szCondition = string.Format(" {0}='{1}' or {2}='{3}' "
                , SystemData.QCMsgChatTable.LISTENER, szUserID
                , SystemData.QCMsgChatTable.SENDER, szUserID);

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField
                  , SystemData.DataTable.QC_MSG_CHAT_LOG
                  , szCondition
                  , SystemData.QCMsgChatTable.CHAT_SEND_DATE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstUserID == null)
                    lstUserID = new List<string>();
                do
                {
                    if (!dataReader.IsDBNull(0) && !lstUserID.Contains(dataReader.GetValue(0).ToString())) lstUserID.Add(dataReader.GetValue(0).ToString());
                    if (!dataReader.IsDBNull(1) && !lstUserID.Contains(dataReader.GetValue(1).ToString())) lstUserID.Add(dataReader.GetValue(1).ToString());
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQCMsgLogUserID", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 获取两人的沟通记录
        /// </summary>
        /// <param name="szUserID_A">沟通ID</param>
        /// <param name="szUserID_B">沟通ID</param>
        /// <param name="lstQcMsgChatLog"></param>
        /// <returns></returns>
        public short GetQCMsgChatLogView(string szUserID_A, string szUserID_B, DateTime dtBeginTime, DateTime dtEndTime, ref List<QcMsgChatLog> lstQcMsgChatLog)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}"
                , SystemData.QCMsgChatTable.CHAT_CONTENT
                , SystemData.QCMsgChatTable.CHAT_ID
                , SystemData.QCMsgChatTable.CHAT_SEND_DATE
                , SystemData.QCMsgChatTable.IS_READ
                , SystemData.QCMsgChatTable.LISTENER
                , SystemData.QCMsgChatTable.PATIENT_ID
                , SystemData.QCMsgChatTable.SENDER
                , SystemData.QCMsgChatTable.VISIT_ID
                , SystemData.QCMsgChatTable.MSG_CHAT_DATA_TYPE
                , "MSG_ID"
                );
            string szCondition = string.Format("(({0}='{1}' and {2}='{3}') or ({0}='{3}' and {2}='{1}')) "
                , SystemData.QCMsgChatTable.LISTENER, szUserID_A
                , SystemData.QCMsgChatTable.SENDER, szUserID_B
                );
            szCondition = string.Format(" {0} and {1} >= {2} and {3} <={4}"
                , szCondition
                , SystemData.QCMsgChatTable.CHAT_SEND_DATE, base.QCAccess.GetSqlTimeFormat(dtBeginTime)
                , SystemData.QCMsgChatTable.CHAT_SEND_DATE, base.QCAccess.GetSqlTimeFormat(dtEndTime)
                );
            string szSQL = string.Format(SystemData.SQL.SELECT_DISTINCT_WHERE_ORDER_ASC, szField
                  , SystemData.DataTable.QC_MSG_CHAT_LOG
                  , szCondition
                  , SystemData.QCMsgChatTable.CHAT_SEND_DATE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcMsgChatLog == null)
                    lstQcMsgChatLog = new List<QcMsgChatLog>();
                do
                {
                    QcMsgChatLog qcMsgChatLog = new QcMsgChatLog();
                    if (!dataReader.IsDBNull(0)) qcMsgChatLog.ChatContent = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) qcMsgChatLog.ChatID = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcMsgChatLog.ChatSendDate = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) qcMsgChatLog.IsRead = dataReader.GetValue(3).ToString() == "1" ? true : false;
                    if (!dataReader.IsDBNull(4)) qcMsgChatLog.Listener = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) qcMsgChatLog.PatientID = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) qcMsgChatLog.Sender = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) qcMsgChatLog.VisitID = dataReader.GetValue(7).ToString();
                    if (!dataReader.IsDBNull(8)) qcMsgChatLog.MsgChatDataType = dataReader.GetValue(8).ToString();
                    if (!dataReader.IsDBNull(9)) qcMsgChatLog.MsgID = dataReader.GetString(9);
                    lstQcMsgChatLog.Add(qcMsgChatLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DBAccess.GetQCMsgChatLogList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
    }
}
