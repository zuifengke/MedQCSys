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
    public class QaEventTypeDictAccess : DBAccessBase
    {
        private static QaEventTypeDictAccess m_Instance = null;
        public static QaEventTypeDictAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QaEventTypeDictAccess();
                return m_Instance;
            }
        }
        #region"质控反馈问题类型管理接口"

        /// <summary>
        /// 病历质控系统,获取病案质量问题分类信息字典列表
        /// </summary>
        /// <param name="lstQCEventTypes">病案质量问题分类信息字典列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCEventType(string szQAEventType,ref QaEventTypeDict qcEventType)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4}", SystemData.QaEventTypeDictTable.SERIAL_NO
               , SystemData.QaEventTypeDictTable.QA_EVENT_TYPE, SystemData.QaEventTypeDictTable.INPUT_CODE
               , SystemData.QaEventTypeDictTable.PARENT_CODE, SystemData.QaEventTypeDictTable.MAX_SCORE);
            string szCondtion = string.Format("{0} = '{1}'", SystemData.QaEventTypeDictTable.QA_EVENT_TYPE, szQAEventType);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                , SystemData.DataTable.QA_EVENT_TYPE_DICT, szCondtion, SystemData.QaEventTypeDictTable.SERIAL_NO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (qcEventType == null)
                    qcEventType = new QaEventTypeDict();
                if (!dataReader.IsDBNull(0)) qcEventType.SERIAL_NO = int.Parse(dataReader.GetValue(0).ToString());
                if (!dataReader.IsDBNull(1)) qcEventType.QA_EVENT_TYPE = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2)) qcEventType.INPUT_CODE = dataReader.GetString(2);
                if (!dataReader.IsDBNull(3)) qcEventType.PARENT_CODE = dataReader.GetString(3);
                if (!dataReader.IsDBNull(4)) qcEventType.MAX_SCORE = Convert.ToDouble(dataReader.GetValue(4));
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCEventType", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 病历质控系统,获取病案质量问题分类信息字典列表
        /// </summary>
        /// <param name="QaEventTypeDict">病案质量问题分类信息字典列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCEventTypeList(ref List<QaEventTypeDict> QaEventTypeDict)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4}", SystemData.QaEventTypeDictTable.SERIAL_NO
               , SystemData.QaEventTypeDictTable.QA_EVENT_TYPE, SystemData.QaEventTypeDictTable.INPUT_CODE
               , SystemData.QaEventTypeDictTable.PARENT_CODE, SystemData.QaEventTypeDictTable.MAX_SCORE);
            string szCondtion = string.Format("{0}='{1}' or {0} is null", SystemData.QaEventTypeDictTable.APPLY_ENV, "MEDDOC");
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                , SystemData.DataTable.QA_EVENT_TYPE_DICT, szCondtion, SystemData.QaEventTypeDictTable.SERIAL_NO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (QaEventTypeDict == null)
                    QaEventTypeDict = new List<QaEventTypeDict>();
                do
                {
                    QaEventTypeDict qcEventType = new QaEventTypeDict();
                    if (!dataReader.IsDBNull(0)) qcEventType.SERIAL_NO =int.Parse(dataReader.GetValue(0).ToString());
                    if (!dataReader.IsDBNull(1)) qcEventType.QA_EVENT_TYPE = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcEventType.INPUT_CODE = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcEventType.PARENT_CODE = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) qcEventType.MAX_SCORE = Convert.ToDouble(dataReader.GetValue(4));
                    QaEventTypeDict.Add(qcEventType);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCEventTypeList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
        /// 病历质控系统,保存一条病案质控问题类别
        /// </summary>
        /// <param name="qcEventType">病案质控问题类别</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(QaEventTypeDict qcEventType)
        {
            if (qcEventType == null)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.Insert", new string[] { "timeQCRule" }
                    , new object[] { qcEventType }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szField = string.Format("{0},{1},{2},{3},{4},{5}"
                , SystemData.QaEventTypeDictTable.APPLY_ENV
                , SystemData.QaEventTypeDictTable.INPUT_CODE
                , SystemData.QaEventTypeDictTable.MAX_SCORE
                , SystemData.QaEventTypeDictTable.PARENT_CODE
                , SystemData.QaEventTypeDictTable.QA_EVENT_TYPE
                , SystemData.QaEventTypeDictTable.SERIAL_NO);

            string szValue = string.Format("'{0}','{1}',{2},'{3}','{4}',{5}"
                , "MEDDOC"
                , qcEventType.INPUT_CODE
                , qcEventType.MAX_SCORE
                , qcEventType.PARENT_CODE
                , qcEventType.QA_EVENT_TYPE
                , qcEventType.SERIAL_NO);

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QA_EVENT_TYPE_DICT, szField, szValue);
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
        /// 病历质控系统,修改一条病案质控问题类别
        /// </summary>
        /// <param name="qcEventType">病案质控问题类别</param>
        /// <param name="szOldInputCode">旧的病案质控问题类别名称</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(QaEventTypeDict qcEventType, string szOldInputCode)
        {
            if (qcEventType == null)
            {
                LogManager.Instance.WriteLog("QcMsgDictAccess.Update", new string[] { "qcMsgDict" }
                    , new object[] { qcEventType }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            qcEventType.APPLY_ENV = "MEDDOC";
            string szField = string.Format("{0}='{1}',{2}='{3}',{4}={5},{6}='{7}',{8}='{9}',{10}={11}"
                , SystemData.QaEventTypeDictTable.APPLY_ENV, qcEventType.APPLY_ENV
                , SystemData.QaEventTypeDictTable.INPUT_CODE, qcEventType.INPUT_CODE
                , SystemData.QaEventTypeDictTable.MAX_SCORE, qcEventType.MAX_SCORE
                , SystemData.QaEventTypeDictTable.PARENT_CODE, qcEventType.PARENT_CODE
                , SystemData.QaEventTypeDictTable.QA_EVENT_TYPE, qcEventType.QA_EVENT_TYPE
                , SystemData.QaEventTypeDictTable.SERIAL_NO, qcEventType.SERIAL_NO);

            string szCondition = string.Format("{0}='{1}'", SystemData.QaEventTypeDictTable.INPUT_CODE, szOldInputCode);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.QA_EVENT_TYPE_DICT, szField, szCondition);
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
        ///  病历质控系统,根据反馈信息代码,删除指定病案质控问题类别
        /// </summary>
        /// <param name="szEventType">病案质控问题类别名称</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szInputCode)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szInputCode))
            {
                LogManager.Instance.WriteLog("QcMsgDictAccess.Delete", new string[] { "szInputCode" }
                    , new object[] { szInputCode }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.QaEventTypeDictTable.INPUT_CODE, szInputCode);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QA_EVENT_TYPE_DICT, szCondition);

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
        #endregion
    }
}
