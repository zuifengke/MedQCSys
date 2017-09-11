using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;
using System.Data;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 文书文档索引主表访问类
    /// </summary>
    public class EmrDocAccess : DBAccessBase
    {
        private static EmrDocAccess m_Instance = null;
        public static EmrDocAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new EmrDocAccess();
                return m_Instance;
            }
        }
        #region"保存新文档接口"
        /// <summary>
        /// 保存新文档
        /// </summary>
        /// <param name="oDocInfo">文档信息</param>
        /// <param name="byteDocData">文档二进制内容</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short SaveDoc(MedDocInfo docInfo, byte[] byteDocData)
        {
            if (docInfo == null)
            {
                LogManager.Instance.WriteLog("MedDocAccess.SaveDoc"
                    , new string[] { "docInfo" }, new object[] { docInfo }, "文档信息类参数不能为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.StorageMode == StorageMode.Unknown)
            {
                LogManager.Instance.WriteLog("MedDocAccess.SaveDoc"
                    , new string[] { "docInfo" }, new object[] { docInfo }, "配置字典表中文档存储模式配置不正确!");
                return SystemData.ReturnValue.EXCEPTION;
            }

            if (base.StorageMode == StorageMode.DB)
                return this.SaveDocToDB(docInfo, byteDocData);
            else
                return this.SaveDocToFTP(docInfo, byteDocData);
        }
        /// <summary>
        /// 把文档保存到数据库
        /// </summary>
        /// <param name="oDocInfo">文档信息</param>
        /// <param name="byteDocData">文档数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short SaveDocToDB(MedDocInfo docInfo, byte[] byteDocData)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            //开始数据库事务
            if (!base.MeddocAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            //添加文档状态信息记录
            DocStatusInfo docStatusInfo = new DocStatusInfo();
            docStatusInfo.DocID = docInfo.DOC_ID;
            docStatusInfo.DocStatus = SystemData.DocStatus.NORMAL;
            docStatusInfo.OperatorID = docInfo.CREATOR_ID;
            docStatusInfo.OperatorName = docInfo.CREATOR_NAME;
            docStatusInfo.OperateTime = DateTime.Now;
            short shRet = this.AddDocStatusInfo(docStatusInfo);
            if (shRet != SystemData.ReturnValue.OK)
            {
                base.MeddocAccess.AbortTransaction();
                return shRet;
            }

            //保存文档索引信息记录,包括文档内容
            shRet = this.AddDocIndexInfo(docInfo, byteDocData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                base.MeddocAccess.AbortTransaction();
                return shRet;
            }

            //提交数据库更新
            if (!base.MeddocAccess.CommitTransaction(true))
                return SystemData.ReturnValue.EXCEPTION;
            return SystemData.ReturnValue.OK;
        }


        /// <summary>
        /// 把文档保存到FTP文档库
        /// </summary>
        /// <param name="oDocInfo">文档信息</param>
        /// <param name="byteDocData">文档数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short SaveDocToFTP(MedDocInfo docInfo, byte[] byteDocData)
        {
            if (base.FtpAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (!base.FtpAccess.OpenConnection())
            {
                base.FtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }

            string szCacheFile = string.Format("{0}\\Cache\\DAL\\{1}.{2}", SystemParam.Instance.WorkPath
                , docInfo.DOC_ID, SystemData.FileExt.MED_DOCUMENT);
            if (!GlobalMethods.IO.WriteFileBytes(szCacheFile, byteDocData))
            {
                LogManager.Instance.WriteLog("MedDocAccess.SaveDocToFTP", new string[] { "szCacheFile" }
                    , new object[] { szCacheFile }, "WriteFileBytes执行失败!");
                return SystemData.ReturnValue.EXCEPTION;
            }

            try
            {
                string szRemoteFile = SystemParam.Instance.GetFtpDocPath(docInfo, SystemData.FileExt.MED_DOCUMENT);
                string szRemoteDir = GlobalMethods.IO.GetFilePath(szRemoteFile);
                if (!base.FtpAccess.CreateDirectory(szRemoteDir))
                    return SystemData.ReturnValue.EXCEPTION;

                if (!base.FtpAccess.Upload(szCacheFile, szRemoteFile))
                    return SystemData.ReturnValue.EXCEPTION;

                short shRet = this.SaveDocToDB(docInfo, null);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.FtpAccess.DeleteFile(szRemoteFile);
                    return shRet;
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.SaveDocToFTP", new string[] { "docInfo" }, new object[] { docInfo }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                base.FtpAccess.CloseConnection();
                GlobalMethods.IO.DeleteFile(szCacheFile);
            }
        }

        /// <summary>
        /// 写文档状态记录
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        private short AddDocStatusInfo(DocStatusInfo docStatusInfo)
        {
            if (docStatusInfo == null)
            {
                LogManager.Instance.WriteLog("MedDocAccess.AddDocStatusInfo", "参数不能为null!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5}"
                , SystemData.DocStatusTable.DOC_ID, SystemData.DocStatusTable.DOC_STATUS, SystemData.DocStatusTable.OPERATOR_ID
                , SystemData.DocStatusTable.OPERATOR_NAME, SystemData.DocStatusTable.OPERATE_TIME, SystemData.DocStatusTable.STATUS_DESC);
            string szValue = string.Format("'{0}','{1}','{2}','{3}',{4},'{5}'"
                , docStatusInfo.DocID, docStatusInfo.DocStatus, docStatusInfo.OperatorID
                , docStatusInfo.OperatorName, base.MeddocAccess.GetSystemTimeSql(), docStatusInfo.StatusDesc);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.DOC_STATUS, szField, szValue);

            int nCount = 0;
            try
            {
                nCount = base.MeddocAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.AddDocStatusInfo", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("MedDocAccess.AddDocStatusInfo", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 新增文档索引信息
        /// </summary>
        /// <param name="docInfo">文档索引信息类</param>
        /// <param name="byteDocData">文档数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short AddDocIndexInfo(MedDocInfo docInfo, byte[] byteDocData)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}"
                , SystemData.EmrDocTable.DOC_ID, SystemData.EmrDocTable.DOC_TYPE, SystemData.EmrDocTable.DOC_TITLE
                , SystemData.EmrDocTable.DOC_TIME, SystemData.EmrDocTable.DOC_SETID, SystemData.EmrDocTable.DOC_VERSION
                , SystemData.EmrDocTable.CREATOR_ID, SystemData.EmrDocTable.CREATOR_NAME, SystemData.EmrDocTable.MODIFIER_ID
                , SystemData.EmrDocTable.MODIFIER_NAME, SystemData.EmrDocTable.MODIFY_TIME, SystemData.EmrDocTable.PATIENT_ID
                , SystemData.EmrDocTable.PATIENT_NAME, SystemData.EmrDocTable.VISIT_ID, SystemData.EmrDocTable.VISIT_TIME
                , SystemData.EmrDocTable.VISIT_TYPE, SystemData.EmrDocTable.DEPT_CODE, SystemData.EmrDocTable.DEPT_NAME
                , SystemData.EmrDocTable.SIGN_CODE, SystemData.EmrDocTable.CONFID_CODE, SystemData.EmrDocTable.ORDER_VALUE
                , SystemData.EmrDocTable.RECORD_TIME, SystemData.EmrDocTable.EMR_TYPE);
            string szValue = string.Format("'{0}','{1}','{2}',{3},'{4}',{5},'{6}','{7}','{8}','{9}',{10},'{11}','{12}','{13}',{14},'{15}','{16}','{17}','{18}','{19}',{20},{21},'{22}'"
                , docInfo.DOC_ID, docInfo.DOC_TYPE, docInfo.DOC_TITLE, base.MeddocAccess.GetSqlTimeFormat(docInfo.DOC_TIME)
                , docInfo.DOC_SETID, docInfo.DOC_VERSION, docInfo.CREATOR_ID, docInfo.CREATOR_NAME, docInfo.MODIFIER_ID
                , docInfo.MODIFIER_NAME, base.MeddocAccess.GetSqlTimeFormat(docInfo.MODIFY_TIME), docInfo.PATIENT_ID
                , docInfo.PATIENT_NAME, docInfo.VISIT_ID, base.MeddocAccess.GetSqlTimeFormat(docInfo.VISIT_TIME), docInfo.VISIT_TYPE
                , docInfo.DEPT_CODE, docInfo.DEPT_NAME, docInfo.SIGN_CODE, docInfo.CONFID_CODE, docInfo.ORDER_VALUE
                , base.MeddocAccess.GetSqlTimeFormat(docInfo.RECORD_TIME), docInfo.EMR_TYPE
               );

            DbParameter[] pmi = null;
            if (byteDocData != null)
            {
                szField = string.Format("{0},{1}", szField, SystemData.EmrDocTable.DOC_DATA);
                szValue = string.Format("{0},{1}", szValue, base.MeddocAccess.GetSqlParamName("DocData"));

                pmi = new DbParameter[1];
                pmi[0] = new DbParameter("DocData", byteDocData);
            }
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.EMR_DOC, szField, szValue);

            int nCount = 0;
            try
            {
                nCount = base.MeddocAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.AddDocIndexInfo", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("MedDocAccess.AddDocIndexInfo", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        #endregion


        /// <summary>
        /// 通过病历文书获取病人的责任医生
        /// </summary>
        /// <returns></returns>
        public short GetDoctorInChargeByEmrDoc(string szPatientID, string szVisitID, ref string szDoctorInCharge)
        {
            if (base.MeddocAccess == null)
            {
                LogManager.Instance.WriteLog("GetDoctorInChargeByEmrDoc base.QCAccess == null");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            StringBuilder sbSQL = new StringBuilder();
            sbSQL.AppendFormat(" select creator_name from emr_doc_t t where t.patient_id = '{0}' and t.visit_id ='{1}' and rownum <= 1 order by doc_time desc"
                , szPatientID, szVisitID);
            IDataReader dataReader = null;

            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(sbSQL.ToString(), CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                szDoctorInCharge = string.Empty;
                if (!dataReader.IsDBNull(0)) szDoctorInCharge = dataReader.GetString(0);
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("GetDoctorInChargeByEmrDoc", new string[] { "szSQL" }, new object[] { sbSQL.ToString() }, ex);
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
                base.MeddocAccess.CloseConnnection(false);
            }

        }
        public short GetInchargeDoctorList(string szPatientID, string szVisitNO, ref List<UserInfo> lstUserInfos)
        {
            if (string.IsNullOrEmpty(szPatientID) || string.IsNullOrEmpty(szVisitNO))
            {
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            string szSQL = string.Format("select distinct creator_id as USER_ID,creator_name as USER_NAME,DEPT_CODE,DEPT_NAME  from emr_doc_t t where t.patient_id ='{0}' and t.visit_id ='{1}'"
                , szPatientID
                , szVisitNO);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstUserInfos == null)
                    lstUserInfos = new List<UserInfo>();
                do
                {
                    UserInfo model = new UserInfo();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.UserView.DEPT_CODE:
                                model.DEPT_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.UserView.DEPT_NAME:
                                model.DEPT_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.UserView.USER_ID:
                                model.USER_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.UserView.USER_NAME:
                                model.USER_NAME = dataReader.GetValue(i).ToString();
                                break;
                            default: break;
                        }
                    }
                    lstUserInfos.Add(model);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 获取指定医生一段时间内书写的所有病历的列表
        /// </summary>
        /// <param name="szUserID">医生ID</param>
        /// <param name="dtBeginTime">文档起始时间</param>
        /// <param name="lstDocInfos">病历信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDoctorDocInfos(string szUserID, DateTime dtBeginTime, ref List<MedDocInfo> lstDocInfos)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10}"
                + ",A.{11},A.{12},A.{13},A.{14},A.{15},A.{16},A.{17},B.{18}"
                , SystemData.EmrDocTable.DOC_ID, SystemData.EmrDocTable.DOC_TITLE
                , SystemData.EmrDocTable.DOC_TYPE, SystemData.EmrDocTable.DOC_TIME
                , SystemData.EmrDocTable.CREATOR_ID, SystemData.EmrDocTable.CREATOR_NAME
                , SystemData.EmrDocTable.MODIFIER_ID, SystemData.EmrDocTable.MODIFIER_NAME
                , SystemData.EmrDocTable.MODIFY_TIME, SystemData.EmrDocTable.PATIENT_ID
                , SystemData.EmrDocTable.PATIENT_NAME, SystemData.EmrDocTable.VISIT_ID
                , SystemData.EmrDocTable.VISIT_TYPE, SystemData.EmrDocTable.VISIT_TIME
                , SystemData.EmrDocTable.DEPT_CODE, SystemData.EmrDocTable.DEPT_NAME
                , SystemData.EmrDocTable.ORDER_VALUE, SystemData.EmrDocTable.SIGN_CODE
                , SystemData.DocStatusTable.STATUS_DESC);

            string szCondition = string.Format("A.{0} = {1} AND A.{2}>={3} AND A.{4}=B.{5} AND B.{6}!='{7}'"
                , SystemData.EmrDocTable.CREATOR_ID, base.ParaHolder(SystemData.EmrDocTable.CREATOR_ID)
                , SystemData.EmrDocTable.DOC_TIME, base.ParaHolder(SystemData.EmrDocTable.DOC_TIME)
                , SystemData.EmrDocTable.DOC_ID, SystemData.DocStatusTable.DOC_ID
                , SystemData.DocStatusTable.DOC_STATUS, SystemData.DocStatus.CANCELED);

            string szTable = string.Format("{0} A,{1} B"
                , SystemData.DataTable.EMR_DOC, SystemData.DataTable.DOC_STATUS);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                , szField, szTable, szCondition, SystemData.EmrDocTable.PATIENT_NAME + "," + SystemData.EmrDocTable.DOC_ID);

            DbParameter[] paras = new DbParameter[2]
            {
                new DbParameter(SystemData.EmrDocTable.CREATOR_ID,szUserID),
                new DbParameter(SystemData.EmrDocTable.DOC_TIME,dtBeginTime)
            };

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text, ref paras);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstDocInfos == null)
                    lstDocInfos = new List<MedDocInfo>();
                lstDocInfos.Clear();
                do
                {
                    MedDocInfo docInfo = new MedDocInfo();
                    if (!dataReader.IsDBNull(0)) docInfo.DOC_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) docInfo.DOC_TITLE = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) docInfo.DOC_TYPE = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) docInfo.DOC_TIME = dataReader.GetDateTime(3);
                    if (!dataReader.IsDBNull(4)) docInfo.CREATOR_ID = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) docInfo.CREATOR_NAME = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) docInfo.MODIFIER_ID = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) docInfo.MODIFIER_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) docInfo.MODIFY_TIME = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) docInfo.PATIENT_ID = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) docInfo.PATIENT_NAME = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) docInfo.VISIT_ID = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) docInfo.VISIT_TYPE = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) docInfo.VISIT_TIME = dataReader.GetDateTime(13);
                    if (!dataReader.IsDBNull(14)) docInfo.DEPT_CODE = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) docInfo.DEPT_NAME = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) docInfo.ORDER_VALUE = int.Parse(dataReader.GetValue(16).ToString());
                    if (!dataReader.IsDBNull(17)) docInfo.SIGN_CODE = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) docInfo.StatusDesc = dataReader.GetString(18);

                    lstDocInfos.Add(docInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDoctorDocInfos", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }

        #region"更新已有文档接口"
        /// <summary>
        /// 更新已有文档
        /// </summary>
        /// <param name="szOldDocID">被更新的文档ID</param>
        /// <param name="newDocInfo">更新后的文档信息</param>
        /// <param name="szUpdateReason">病历更新原因描述</param>
        /// <param name="byteDocData">文档数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short UpdateDoc(string szOldDocID, MedDocInfo newDocInfo, string szUpdateReason, byte[] byteDocData)
        {
            if (base.StorageMode == StorageMode.Unknown)
            {
                LogManager.Instance.WriteLog("MedDocAccess.UpdateDoc", "配置字典表中文档存储模式配置不正确!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (base.StorageMode == StorageMode.DB)
                return this.UpdateDocToDB(szOldDocID, newDocInfo, szUpdateReason, byteDocData);
            else
                return this.UpdateDocToFTP(szOldDocID, newDocInfo, szUpdateReason, byteDocData);
        }

        /// <summary>
        /// 更新文档到数据库
        /// </summary>
        /// <param name="szOldDocID">被更新的文档ID</param>
        /// <param name="newDocInfo">更新后的文档信息</param>
        /// <param name="szUpdateReason">病历更新原因描述</param>
        /// <param name="byteDocData">文档数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short UpdateDocToDB(string szOldDocID, MedDocInfo newDocInfo, string szUpdateReason, byte[] byteDocData)
        {
            if (newDocInfo == null || base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            //开始数据库事务
            if (!base.MeddocAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            DocStatusInfo docStatusInfo = new DocStatusInfo();
            docStatusInfo.OperatorID = newDocInfo.CREATOR_ID;
            docStatusInfo.OperatorName = newDocInfo.CREATOR_NAME;
            docStatusInfo.OperateTime = DateTime.Now;

            //如果文档ID未变,那么覆盖已有文档
            if (szOldDocID == newDocInfo.DOC_ID)
            {
                //添加文档状态信息记录
                docStatusInfo.DocID = newDocInfo.DOC_ID;
                docStatusInfo.DocStatus = SystemData.DocStatus.NORMAL;
                docStatusInfo.StatusDesc = szUpdateReason;
                short shRet = this.ModifyDocStatusInfo(ref docStatusInfo);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.MeddocAccess.AbortTransaction();
                    return shRet;
                }

                //保存文档索引信息记录,包括文档内容
                shRet = this.ModifyDocIndexInfo(newDocInfo, byteDocData);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.MeddocAccess.AbortTransaction();
                    return shRet;
                }
            }
            else
            {
                //修改旧的文档状态为作废
                docStatusInfo.DocID = szOldDocID;
                docStatusInfo.DocStatus = SystemData.DocStatus.CANCELED;
                short shRet = this.ModifyDocStatusInfo(ref docStatusInfo);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.MeddocAccess.AbortTransaction();
                    return shRet;
                }

                //添加文档状态信息记录
                docStatusInfo.DocID = newDocInfo.DOC_ID;
                docStatusInfo.DocStatus = SystemData.DocStatus.NORMAL;
                docStatusInfo.StatusDesc = szUpdateReason;
                shRet = this.AddDocStatusInfo(docStatusInfo);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.MeddocAccess.AbortTransaction();
                    return shRet;
                }

                //保存文档索引信息记录,包括文档内容
                shRet = this.AddDocIndexInfo(newDocInfo, byteDocData);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.MeddocAccess.AbortTransaction();
                    return shRet;
                }
            }
            //提交数据库更新
            if (!base.MeddocAccess.CommitTransaction(true))
                return SystemData.ReturnValue.EXCEPTION;
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 更新文档到FTP
        /// </summary>
        /// <param name="szOldDocID">被更新的文档ID</param>
        /// <param name="newDocInfo">更新后的文档信息</param>
        /// <param name="szUpdateReason">病历更新原因描述</param>
        /// <param name="byteDocData">文档数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short UpdateDocToFTP(string szOldDocID, MedDocInfo newDocInfo, string szUpdateReason, byte[] byteDocData)
        {
            if (newDocInfo == null || base.FtpAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (!base.FtpAccess.OpenConnection())
            {
                base.FtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }

            string szCacheFile = string.Format("{0}\\Cache\\DAL\\{1}.{2}", SystemParam.Instance.WorkPath
                , newDocInfo.DOC_ID, SystemData.FileExt.MED_DOCUMENT);
            if (!GlobalMethods.IO.WriteFileBytes(szCacheFile, byteDocData))
            {
                LogManager.Instance.WriteLog("MedDocAccess.UpdateDocToFTP", new string[] { "szCacheFile" }
                    , new object[] { szCacheFile }, "WriteFileBytes执行失败!");
                base.FtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }

            try
            {
                string szRemoteFile = SystemParam.Instance.GetFtpDocPath(newDocInfo, SystemData.FileExt.MED_DOCUMENT);
                string szRemoteFileBak = null;

                //如果需要覆盖,那么先把被覆盖的文件备份一次
                if (szOldDocID == newDocInfo.DOC_ID)
                {
                    szRemoteFileBak = string.Format("{0}.bak", szRemoteFile);
                    if (!base.FtpAccess.RenameFile(szRemoteFile, szRemoteFileBak))
                        return SystemData.ReturnValue.EXCEPTION;
                }

                if (!base.FtpAccess.Upload(szCacheFile, szRemoteFile))
                {
                    //还原备份的远程文件
                    if (!string.IsNullOrEmpty(szRemoteFileBak))
                        base.FtpAccess.RenameFile(szRemoteFileBak, szRemoteFile);
                    return SystemData.ReturnValue.EXCEPTION;
                }

                short shRet = this.UpdateDocToDB(szOldDocID, newDocInfo, szUpdateReason, null);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.FtpAccess.DeleteFile(szRemoteFile);

                    //还原备份的远程文件
                    if (!string.IsNullOrEmpty(szRemoteFileBak))
                        base.FtpAccess.RenameFile(szRemoteFileBak, szRemoteFile);
                    return shRet;
                }

                //删除备份的远程文件
                if (!string.IsNullOrEmpty(szRemoteFileBak))
                    base.FtpAccess.DeleteFile(szRemoteFileBak);
            }
            finally
            {
                base.FtpAccess.CloseConnection();
                GlobalMethods.IO.DeleteFile(szCacheFile);
            }
            return SystemData.ReturnValue.OK;
        }


        /// <summary>
        /// 修改文档状态记录
        /// </summary>
        /// <returns>SystemData.ReturnValue</returns>
        private short ModifyDocStatusInfo(ref DocStatusInfo docStatusInfo)
        {
            if (docStatusInfo == null)
            {
                LogManager.Instance.WriteLog("MedDocAccess.ModifyDocStatusInfo", "参数不能为null!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}='{3}',{4}='{5}',{6}={7},{8}='{9}'"
                , SystemData.DocStatusTable.DOC_STATUS, docStatusInfo.DocStatus
                , SystemData.DocStatusTable.OPERATOR_ID, docStatusInfo.OperatorID
                , SystemData.DocStatusTable.OPERATOR_NAME, docStatusInfo.OperatorName
                , SystemData.DocStatusTable.OPERATE_TIME, base.MeddocAccess.GetSqlTimeFormat(docStatusInfo.OperateTime)
                , SystemData.DocStatusTable.STATUS_DESC, docStatusInfo.StatusDesc);
            string szCondition = string.Format("{0}='{1}'", SystemData.DocStatusTable.DOC_ID, docStatusInfo.DocID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.DOC_STATUS, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MeddocAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.ModifyDocStatusInfo", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("MedDocAccess.ModifyDocStatusInfo", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 修改文档索引信息
        /// </summary>
        /// <param name="docInfo">文档索引信息类</param>
        /// <param name="byteDocData">文档数据</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short ModifyDocIndexInfo(MedDocInfo docInfo, byte[] byteDocData)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}='{1}',{2}={3},{4}='{5}',{6}='{7}',{8}={9},{10}='{11}',{12}='{13}',{14}={15}"
                , SystemData.EmrDocTable.DOC_TITLE, docInfo.DOC_TITLE
                , SystemData.EmrDocTable.DOC_VERSION, docInfo.DOC_VERSION
                , SystemData.EmrDocTable.MODIFIER_ID, docInfo.MODIFIER_ID
                , SystemData.EmrDocTable.MODIFIER_NAME, docInfo.MODIFIER_NAME
                , SystemData.EmrDocTable.MODIFY_TIME, base.MeddocAccess.GetSqlTimeFormat(docInfo.MODIFY_TIME)
                , SystemData.EmrDocTable.SIGN_CODE, docInfo.SIGN_CODE
                , SystemData.EmrDocTable.CONFID_CODE, docInfo.CONFID_CODE
                , SystemData.EmrDocTable.RECORD_TIME, base.MeddocAccess.GetSqlTimeFormat(docInfo.RECORD_TIME)
               );
            string szCondition = string.Format("{0}='{1}'", SystemData.EmrDocTable.DOC_ID, docInfo.DOC_ID);

            DbParameter[] pmi = null;
            if (byteDocData != null)
            {
                szField = string.Format("{0},{1}={2}", szField, SystemData.EmrDocTable.DOC_DATA, base.MeddocAccess.GetSqlParamName("DocData"));

                pmi = new DbParameter[1];
                pmi[0] = new DbParameter("DocData", byteDocData);
            }
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.EMR_DOC, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MeddocAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.ModifyDocIndexInfo", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("MedDocAccess.ModifyDocIndexInfo", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 判断质控科医生是否能保存病历
        /// </summary>
        /// <returns></returns>
        public bool CheckQCSaveDocEnable()
        {
            return base.QCSaveDocEnable;
        }
        /// <summary>
        /// 获取指定病人的文档列表
        /// </summary>
        /// <param name="patientID"></param>
        /// <param name="visitID"></param>
        /// <param name="lstDocInfo"></param>
        /// <returns></returns>
        public short GetDocList(string patientID, string visitID, ref List<MedDocInfo> lstDocInfo)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("A.{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19}"
               , SystemData.EmrDocTable.DOC_ID, SystemData.EmrDocTable.DOC_TYPE, SystemData.EmrDocTable.DOC_TITLE
               , SystemData.EmrDocTable.CREATOR_ID, SystemData.EmrDocTable.CREATOR_NAME, SystemData.EmrDocTable.DOC_TIME
               , SystemData.EmrDocTable.MODIFIER_ID, SystemData.EmrDocTable.MODIFIER_NAME, SystemData.EmrDocTable.MODIFY_TIME
               , SystemData.EmrDocTable.PATIENT_ID, SystemData.EmrDocTable.PATIENT_NAME, SystemData.EmrDocTable.VISIT_ID
               , SystemData.EmrDocTable.VISIT_TIME, SystemData.EmrDocTable.VISIT_TYPE, SystemData.EmrDocTable.DEPT_CODE
               , SystemData.EmrDocTable.DEPT_NAME, SystemData.EmrDocTable.ORDER_VALUE
               , SystemData.EmrDocTable.DOC_SETID, SystemData.EmrDocTable.RECORD_TIME
               , SystemData.EmrDocTable.EMR_TYPE);
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}'"
                , SystemData.EmrDocTable.PATIENT_ID, patientID, SystemData.EmrDocTable.VISIT_ID, visitID);
            //过滤掉已作废的文档
            szCondition = string.Format("{0} AND A.{1}=B.{2} AND B.{3}!='{4}'"
                , szCondition
                , SystemData.EmrDocTable.DOC_ID, SystemData.DocStatusTable.DOC_ID
                , SystemData.DocStatusTable.DOC_STATUS, SystemData.DocStatus.CANCELED);

            string szTable = string.Format("{0} A,{1} B", SystemData.DataTable.EMR_DOC, SystemData.DataTable.DOC_STATUS);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                , szTable, szCondition, SystemData.EmrDocTable.DOC_TIME);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstDocInfo == null)
                    lstDocInfo = new List<MedDocInfo>();
                do
                {
                    MedDocInfo docInfo = new MedDocInfo();
                    if (!dataReader.IsDBNull(0)) docInfo.DOC_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) docInfo.DOC_TYPE = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) docInfo.DOC_TITLE = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) docInfo.CREATOR_ID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) docInfo.CREATOR_NAME = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) docInfo.DOC_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) docInfo.MODIFIER_ID = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) docInfo.MODIFIER_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) docInfo.MODIFY_TIME = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) docInfo.PATIENT_ID = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) docInfo.PATIENT_NAME = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) docInfo.VISIT_ID = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) docInfo.VISIT_TIME = dataReader.GetDateTime(12);
                    if (!dataReader.IsDBNull(13)) docInfo.VISIT_TYPE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) docInfo.DEPT_CODE = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) docInfo.DEPT_NAME = dataReader.GetString(15);

                    if (string.IsNullOrEmpty(docInfo.DOC_ID))
                        docInfo.DOC_ID = string.Concat(docInfo.PATIENT_ID, "_", docInfo.VISIT_ID, "_", docInfo.FileName);
                    if (!dataReader.IsDBNull(17)) docInfo.DOC_SETID = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18)) docInfo.RECORD_TIME = dataReader.GetDateTime(18);
                    if (!dataReader.IsDBNull(19)) docInfo.EMR_TYPE = dataReader.GetString(19);

                    lstDocInfo.Add(docInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetPatListByName", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 获取指定病人经治医师ID
        /// </summary>
        /// <param name="szPatientID"></param>
        /// <param name="szVisitID"></param>
        /// <param name="szRequestDoctorID"></param>
        /// <returns></returns>
        public short GetPatChargeDoctorID(string szPatientID, string szVisitID, ref string szRequestDoctorID)
        {
            if (base.MeddocAccess == null || string.IsNullOrEmpty(szPatientID) || string.IsNullOrEmpty(szVisitID))
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2}", SystemData.PatDoctorView.REQUEST_DOCTOR_ID
                , SystemData.PatDoctorView.PARENT_DOCTOR_ID, SystemData.PatDoctorView.SUPER_DOCTOR_ID);

            string szCondition = string.Format("{0}='{1}' AND {2}='{3}' "
                , SystemData.PatDoctorView.PATIENT_ID, szPatientID, SystemData.PatDoctorView.VISIT_ID, szVisitID);

            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField
                , SystemData.DataView.PAT_DOCTOR_V, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                else
                {
                    szRequestDoctorID = dataReader.GetString(0);
                    if (string.IsNullOrEmpty(szRequestDoctorID))
                    {
                        szRequestDoctorID = dataReader.GetString(1);
                    }
                    if (string.IsNullOrEmpty(szRequestDoctorID))
                    {
                        szRequestDoctorID = dataReader.GetString(2);
                    }
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetPatChargeDoctorID", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }
        #endregion

        /// <summary>
        /// 质控人员把文档保存到FTP文档库
        /// </summary>
        public short SaveQCDocToFTP(string szDocSetID, DateTime dtCheckTime, string szRemotePath, byte[] byteDocData)
        {
            if (base.FtpAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (!base.FtpAccess.OpenConnection())
            {
                base.FtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }

            string szCacheFile = string.Format("{0}\\Cache\\DAL\\{1}_{2}.{3}", SystemParam.Instance.WorkPath
                , szDocSetID, dtCheckTime.ToString("yyyyMMddHHmmss"), SystemData.FileExt.MED_DOCUMENT);
            if (!GlobalMethods.IO.WriteFileBytes(szCacheFile, byteDocData))
            {
                LogManager.Instance.WriteLog("MedDocAccess.SaveQCDocToFTP", new string[] { "szCacheFile" }
                    , new object[] { szCacheFile }, "WriteFileBytes执行失败!");
                return SystemData.ReturnValue.EXCEPTION;
            }

            try
            {
                string szRemoteDir = GlobalMethods.IO.GetFilePath(szRemotePath);
                if (!base.FtpAccess.CreateDirectory(szRemoteDir))
                    return SystemData.ReturnValue.EXCEPTION;

                if (!base.FtpAccess.Upload(szCacheFile, szRemotePath))
                    return SystemData.ReturnValue.EXCEPTION;

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.SaveQCDocToFTP", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                base.FtpAccess.CloseConnection();
                GlobalMethods.IO.DeleteFile(szCacheFile);
            }
        }

        public short UpdateQCDocToFtp(EMRDBLib.MedicalQcMsg questionInfo, string szRemoteFile, DateTime dtNewCheckTime)
        {
            byte[] byteDocData = null;
            short shRet = this.GetFtpHistoryDocByID(questionInfo.TOPIC_ID, questionInfo.ISSUED_DATE_TIME, szRemoteFile, ref byteDocData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                LogManager.Instance.WriteLog("GetFtpHistoryDocByID下载质控病历失败");
                return shRet;
            }
            if (base.FtpAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (!base.FtpAccess.OpenConnection())
            {
                base.FtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }
            string szCacheFile = string.Format("{0}\\Cache\\DAL\\{1}_{2}.{3}", SystemParam.Instance.WorkPath
                , questionInfo.TOPIC_ID, dtNewCheckTime.ToString("yyyyMMddHHmmss"), SystemData.FileExt.MED_DOCUMENT);
            if (!GlobalMethods.IO.WriteFileBytes(szCacheFile, byteDocData))
            {
                LogManager.Instance.WriteLog("MedDocAccess.UpdateQCDocToFtp", new string[] { "szCacheFile" }
                    , new object[] { szCacheFile }, "WriteFileBytes执行失败!");
                base.FtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }
            try
            {
                //string szRemoteFile = SystemParam.Instance.GetFtpDocPath(newDocInfo, SystemData.FileExt.MED_DOCUMENT);
                string szRemoteFileBak = null;
                string szNewRemoteFile = null;
                //如果需要覆盖,那么先把被覆盖的文件备份一次
                if (questionInfo.ISSUED_DATE_TIME != dtNewCheckTime)
                {
                    szNewRemoteFile = szRemoteFile.Replace(questionInfo.ISSUED_DATE_TIME.ToString("yyyyMMddHHmmss"), dtNewCheckTime.ToString("yyyyMMddHHmmss"));
                    szRemoteFileBak = string.Format("{0}.bak", szRemoteFile);
                    if (!base.FtpAccess.RenameFile(szRemoteFile, szRemoteFileBak))
                        return SystemData.ReturnValue.EXCEPTION;
                }

                if (!base.FtpAccess.Upload(szCacheFile, szNewRemoteFile))
                {
                    //还原备份的远程文件
                    if (!string.IsNullOrEmpty(szRemoteFileBak))
                        base.FtpAccess.RenameFile(szRemoteFileBak, szNewRemoteFile);
                    return SystemData.ReturnValue.EXCEPTION;
                }
                //删除备份的远程文件
                if (!string.IsNullOrEmpty(szRemoteFileBak))
                    base.FtpAccess.DeleteFile(szRemoteFileBak);
            }
            finally
            {
                base.FtpAccess.CloseConnection();
                GlobalMethods.IO.DeleteFile(szCacheFile);
            }
            return SystemData.ReturnValue.OK;

        }


        public short GetFtpHistoryDocByID(string szDocSetID, DateTime dtCheckTime, string szRemoteFile, ref byte[] byteSmdfData)
        {
            if (base.FtpAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (!base.FtpAccess.OpenConnection())
            {
                base.FtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }
            string szCacheFile = string.Format("{0}\\Cache\\DAL\\{1}_{2}.{3}", SystemParam.Instance.WorkPath
                , szDocSetID, dtCheckTime.ToString("yyyyMMddHHmmss"), SystemData.FileExt.MED_DOCUMENT);
            if (!base.FtpAccess.Download(szRemoteFile, szCacheFile))
            {
                base.FtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (!GlobalMethods.IO.GetFileBytes(szCacheFile, ref byteSmdfData))
            {
                base.FtpAccess.CloseConnection();
                GlobalMethods.IO.DeleteFile(szCacheFile);
                LogManager.Instance.WriteLog("MedDocAccess.GetFtpHistoryDocByID", new string[] { "szCacheFile" }
                    , new object[] { szCacheFile }, "GetFileBytes执行失败!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            base.FtpAccess.CloseConnection();
            GlobalMethods.IO.DeleteFile(szCacheFile);
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 病历质控系统,病案招回
        /// </summary>
        /// <param name="szPatientID">病人ID号</param>
        /// <param name="szVisitID">就诊号</param>
        /// <param name="szUserID">医生账号</param>
        /// <returns></returns>
        public short MedCallBack(string szPatientID, string szVisitID, string szUserID)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            DbParameter[] pmi = new DbParameter[3];
            pmi[0] = new DbParameter("patientID", szPatientID);
            pmi[1] = new DbParameter("visitID", szVisitID);
            pmi[2] = new DbParameter("userID", szUserID);

            try
            {
                base.MeddocAccess.ExecuteNonQuery("MED_CALL_BACK", CommandType.StoredProcedure, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.MedCallBack执行失败,存储过程MED_CALL_BACK执行失败", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        public short GetPatListByDocTypeAndDocTime(string szDocTypeID, DateTime dtBeginTime, DateTime dtEndTime, ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            //拼接PID VID
            short shRet = GetPidVidByDocTypeAndDocTime(szDocTypeID, dtBeginTime, dtEndTime, ref lstPatVisitLogs);
            if (lstPatVisitLogs == null || lstPatVisitLogs.Count <= 0)
                return SystemData.ReturnValue.RES_NO_FOUND;
            string szPidVid = GetPidVidList(lstPatVisitLogs);
            if (string.IsNullOrEmpty(szPidVid))
                return SystemData.ReturnValue.RES_NO_FOUND;
            string szField = string.Format("T1.{0},T1.{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16}"
                , SystemData.PatVisitView.PATIENT_ID, SystemData.PatVisitView.VISIT_ID
                , SystemData.PatVisitView.VISIT_TIME, SystemData.PatVisitView.PATIENT_NAME, SystemData.PatVisitView.INP_NO
                , SystemData.PatVisitView.PATIENT_SEX, SystemData.PatVisitView.BIRTH_TIME, SystemData.PatVisitView.CHARGE_TYPE
                , SystemData.PatVisitView.DEPT_NAME, SystemData.PatVisitView.BED_CODE, SystemData.PatVisitView.PATIENT_CONDITION
                , SystemData.PatVisitView.INCHARGE_DOCTOR, SystemData.PatVisitView.DIAGNOSIS, SystemData.PatVisitView.DEPT_CODE
                , SystemData.PatVisitView.DISCHARGE_TIME, SystemData.PatVisitView.DISCHARGE_MODE, SystemData.PatVisitView.MR_STATUS);

            string szCondition = szPidVid;
            string szTalbe = String.Format(" {0} T1", SystemData.DataView.PAT_VISIT_V);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTalbe, szCondition
                , SystemData.PatVisitView.DEPT_CODE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLogs == null)
                    lstPatVisitLogs = new List<PatVisitInfo>();
                lstPatVisitLogs.Clear();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitLog.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.VISIT_NO = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) patVisitLog.VISIT_TIME = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) patVisitLog.PATIENT_NAME = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) patVisitLog.INP_NO = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) patVisitLog.PATIENT_SEX = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) patVisitLog.BIRTH_TIME = dataReader.GetDateTime(6);
                    if (!dataReader.IsDBNull(7)) patVisitLog.CHARGE_TYPE = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) patVisitLog.DEPT_NAME = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) patVisitLog.BED_CODE = dataReader.GetValue(9).ToString();
                    if (!dataReader.IsDBNull(10))
                        patVisitLog.PATIENT_CONDITION = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) patVisitLog.INCHARGE_DOCTOR = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) patVisitLog.DIAGNOSIS = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) patVisitLog.DEPT_CODE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) patVisitLog.DISCHARGE_TIME = dataReader.GetDateTime(14);
                    if (!dataReader.IsDBNull(15)) patVisitLog.DISCHARGE_MODE = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) patVisitLog.MR_STATUS = dataReader.GetString(16);
                    lstPatVisitLogs.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatListByDocTypeAndDocTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MeddocAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="szDocTypeID"></param>
        /// <param name="dtBeginTime"></param>
        /// <param name="dtEndTime"></param>
        /// <param name="lstPatVisitLogs"></param>
        /// <returns></returns>
        public short GetEmrDocList(string szTimeType, string szDocTypeIDList, DateTime dtBeginTime, DateTime dtEndTime, string szDeptCode, ref List<MedDocInfo> lstMedDocInfos)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (dtBeginTime.CompareTo(dtEndTime) > 0)
                return SystemData.ReturnValue.RES_NO_FOUND;

            string szField = string.Format("A.*,C.{0}", SystemData.PatVisitView.DISCHARGE_TIME);
            string szCondition = string.Format("1=1 AND {0} >= {1} AND {0} <= {2} AND A.{3} = B.{3} AND B.{4} != {5} "
                , szTimeType
                , base.MeddocAccess.GetSqlTimeFormat(dtBeginTime)
                , base.MeddocAccess.GetSqlTimeFormat(dtEndTime)
                , SystemData.EmrDocTable.DOC_ID
                , SystemData.DocStatusTable.DOC_STATUS
                , SystemData.DocStatus.CANCELED);
            szCondition = string.Format("{0} AND A.{1}=C.{1} AND A.{2}=C.{2}"
                , szCondition
                , SystemData.EmrDocTable.PATIENT_ID
                , SystemData.EmrDocTable.VISIT_ID);
            if(!string.IsNullOrEmpty(szDocTypeIDList))
            {
                szDocTypeIDList = szDocTypeIDList.Replace(';', ',');
                szCondition = string.Format("{0} AND A.{1} in ({2})"
                    , szCondition
                    , SystemData.EmrDocTable.DOC_TYPE
                    , szDocTypeIDList);
            }
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition = string.Format("{0} AND A.{1} = '{2}'"
                    , szCondition
                    , SystemData.EmrDocTable.DEPT_CODE
                    , szDeptCode);
            string szTalbe = String.Format(" {0} A,{1} B,{2} C"
                , SystemData.DataTable.EMR_DOC
                , SystemData.DataTable.DOC_STATUS
                , SystemData.DataView.PAT_VISIT_V);
            string szOrderBy = string.Format("{0},{1},{2},{3}"
                , SystemData.EmrDocTable.DEPT_CODE
                , SystemData.EmrDocTable.CREATOR_NAME
                , SystemData.EmrDocTable.PATIENT_NAME
                , SystemData.EmrDocTable.VISIT_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTalbe, szCondition
                , "A." + SystemData.EmrDocTable.DEPT_CODE);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstMedDocInfos == null)
                    lstMedDocInfos = new List<MedDocInfo>();
                lstMedDocInfos.Clear();
                do
                {
                    MedDocInfo medDocInfo = new MedDocInfo();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.EmrDocTable.CONFID_CODE:
                                medDocInfo.CONFID_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.CREATOR_ID:
                                medDocInfo.CREATOR_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.CREATOR_NAME:
                                medDocInfo.CREATOR_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DEPT_CODE:
                                medDocInfo.DEPT_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DEPT_NAME:
                                medDocInfo.DEPT_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_ID:
                                medDocInfo.DOC_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_SETID:
                                medDocInfo.DOC_SETID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_TIME:
                                medDocInfo.DOC_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.EmrDocTable.DOC_TITLE:
                                medDocInfo.DOC_TITLE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_TYPE:
                                medDocInfo.DOC_TYPE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_VERSION:
                                medDocInfo.DOC_VERSION = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.EMR_TYPE:
                                medDocInfo.EMR_TYPE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.MODIFIER_ID:
                                medDocInfo.MODIFIER_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.MODIFIER_NAME:
                                medDocInfo.MODIFIER_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.MODIFY_TIME:
                                medDocInfo.MODIFY_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.EmrDocTable.ORDER_VALUE:
                                medDocInfo.ORDER_VALUE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.PATIENT_ID:
                                medDocInfo.PATIENT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.PATIENT_NAME:
                                medDocInfo.PATIENT_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.RECORD_TIME:
                                medDocInfo.RECORD_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.EmrDocTable.SIGN_CODE:
                                medDocInfo.SIGN_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.TEMPLET_ID:
                                medDocInfo.TEMPLET_ID = dataReader.GetValue(i).ToString();
                                break;

                            case SystemData.EmrDocTable.VISIT_ID:
                                medDocInfo.VISIT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.VISIT_TIME:
                                medDocInfo.VISIT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.PatVisitView.DISCHARGE_TIME:
                                medDocInfo.DischargeTime = dataReader.GetDateTime(i);
                                break;
                            case SystemData.EmrDocTable.VISIT_TYPE:
                                medDocInfo.VISIT_TYPE = dataReader.GetValue(i).ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    lstMedDocInfos.Add(medDocInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPatListByDocTypeAndDocTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MeddocAccess.CloseConnnection(false);
            }
        }
        private string GetPidVidList(List<PatVisitInfo> lstPatVisitLogs)
        {
            if (lstPatVisitLogs == null || lstPatVisitLogs.Count == 0)
                return string.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (PatVisitInfo item in lstPatVisitLogs)
                {
                    sb.AppendFormat("(PATIENT_ID='{0}' AND VISIT_ID='{1}') OR ", item.PATIENT_ID, item.VISIT_NO);
                }
                int index = sb.ToString().LastIndexOf("OR");
                return sb.ToString().Remove(index, 2);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetPidVidList", ex);
            }
            return string.Empty;
        }

        private short GetPidVidByDocTypeAndDocTime(string szDocTypeID, DateTime dtBeginTime, DateTime dtEndTime, ref List<PatVisitInfo> lstPatVisitLogs)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szSQL = string.Format("SELECT distinct A.PATIENT_ID ,A.VISIT_ID FROM EMR_DOC_T A,DOC_STATUS_T B "
                + "WHERE A.DOC_ID=B.DOC_ID  AND B.DOC_STATUS!='2' AND A.DOC_TYPE='{0}' "
                + "AND A.{1}>={2} AND A.{1}<={3}",
                szDocTypeID, SystemData.EmrDocTable.DOC_TIME, base.MeddocAccess.GetSqlTimeFormat(dtBeginTime), base.MeddocAccess.GetSqlTimeFormat(dtEndTime));
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPatVisitLogs == null)
                    lstPatVisitLogs = new List<PatVisitInfo>();
                lstPatVisitLogs.Clear();
                do
                {
                    PatVisitInfo patVisitLog = new PatVisitInfo();
                    if (!dataReader.IsDBNull(0)) patVisitLog.PATIENT_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) patVisitLog.VISIT_NO = dataReader.GetValue(1).ToString();
                    lstPatVisitLogs.Add(patVisitLog);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientAccess.GetPidVidByDocTypeAndDocTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MeddocAccess.CloseConnnection(false);
            }
        }

        /// <summary>
        /// 获取病历修改申请
        /// </summary>
        /// <param name="dtApplyBegin"></param>
        /// <param name="dtApplyEnd"></param>
        /// <param name="dtVisitBegin"></param>
        /// <param name="dtVisitEnd"></param>
        /// <param name="szDeptCode"></param>
        /// <param name="lstDocRecordModifyApply"></param>
        /// <returns></returns>
        public short GetDocModifyApplyList(DateTime dtApplyBegin, DateTime dtApplyEnd, string szAuditStatus, string szDeptCode, ref List<DocRecordModifyApply> lstDocRecordModifyApply)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (dtApplyBegin == null || dtApplyEnd == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}"
                , SystemData.DocRecordModifyApplyView.PATIENT_ID, SystemData.DocRecordModifyApplyView.VISIT_ID, SystemData.DocRecordModifyApplyView.VISIT_TIME
                , SystemData.DocRecordModifyApplyView.DOC_ID, SystemData.DocRecordModifyApplyView.DOC_TITLE, SystemData.DocRecordModifyApplyView.PATIENT_NAME
                , SystemData.DocRecordModifyApplyView.MODIFY_REASON, SystemData.DocRecordModifyApplyView.BEFORE_CONTENT, SystemData.DocRecordModifyApplyView.AFTER_CONTENT
                , SystemData.DocRecordModifyApplyView.APPLICANT_ID, SystemData.DocRecordModifyApplyView.APPLY_DATE, SystemData.DocRecordModifyApplyView.APPLY_DEPT_CODE,
                SystemData.DocRecordModifyApplyView.QC_ID, SystemData.DocRecordModifyApplyView.QC_TIME, SystemData.DocRecordModifyApplyView.QC_REMARK
                , SystemData.DocRecordModifyApplyView.AUDIT_STATUS);
            string szCondition = string.Format(" {0}>={1} AND {2}<={3}  AND {4} in ({5}) "
                , SystemData.DocRecordModifyApplyView.APPLY_DATE, base.MeddocAccess.GetSqlTimeFormat(dtApplyBegin)
                , SystemData.DocRecordModifyApplyView.APPLY_DATE, base.MeddocAccess.GetSqlTimeFormat(dtApplyEnd)
                , SystemData.DocRecordModifyApplyView.AUDIT_STATUS, szAuditStatus);
            if (!string.IsNullOrEmpty(szDeptCode))
                szCondition += string.Format(" AND {0}='{1}'", SystemData.DocRecordModifyApplyView.APPLY_DEPT_CODE, szDeptCode);
            string szSQL = String.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataView.DOC_RECORD_MODIFY_APPLY_V, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstDocRecordModifyApply == null)
                    lstDocRecordModifyApply = new List<DocRecordModifyApply>();
                lstDocRecordModifyApply.Clear();
                do
                {
                    DocRecordModifyApply apply = new DocRecordModifyApply();
                    if (!dataReader.IsDBNull(0)) apply.PatintID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) apply.VisitID = dataReader.GetValue(1).ToString();
                    if (!dataReader.IsDBNull(2)) apply.VisitTime = dataReader.GetDateTime(2);
                    if (!dataReader.IsDBNull(3)) apply.DocID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) apply.DocTitle = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) apply.PatientName = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6)) apply.ModifyReason = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) apply.BeforeContent = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) apply.AfterContent = dataReader.GetString(8);
                    if (!dataReader.IsDBNull(9)) apply.ApplicantID = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) apply.ApplyDate = dataReader.GetDateTime(10);
                    if (!dataReader.IsDBNull(11)) apply.ApplyDeptCode = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) apply.QCID = dataReader.GetString(12);
                    if (!dataReader.IsDBNull(13)) apply.QCTime = dataReader.GetDateTime(13);
                    if (!dataReader.IsDBNull(14)) apply.QCRemark = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) apply.AuditStatus = dataReader.GetString(15);
                    lstDocRecordModifyApply.Add(apply);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocModifyApplyList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.MeddocAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 根据修改时间获取前一天修改或者创建的病历信息
        /// </summary>
        /// <param name="dtModify"></param>
        /// <param name="lstDocInfo"></param>
        /// <returns></returns>
        public short GetDocInfoByModifyTime(DateTime dtModify, int nDays, string szIgnoreDocTypeIDs, ref List<MedDocInfo> lstDocInfo)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11}",
                SystemData.EmrDocTable.PATIENT_ID,
                SystemData.EmrDocTable.VISIT_ID,
                SystemData.EmrDocTable.PATIENT_NAME,
                SystemData.EmrDocTable.DOC_TYPE,
                SystemData.EmrDocTable.DOC_ID,
                SystemData.EmrDocTable.DOC_TIME,
                SystemData.EmrDocTable.MODIFY_TIME,
                SystemData.EmrDocTable.CREATOR_ID,
                SystemData.EmrDocTable.CREATOR_NAME,
                SystemData.EmrDocTable.DOC_TITLE,
                SystemData.EmrDocTable.EMR_TYPE,
                SystemData.EmrDocTable.DOC_SETID
                );

            string szCondition = string.Format("A.DOC_ID = B.DOC_ID  AND B.DOC_STATUS != '2'"
                                 + " AND A.MODIFY_TIME > TO_DATE('{0}', 'YYYY/MM/DD HH24:mi:ss')"
                                 + "  AND A.MODIFY_TIME < TO_DATE('{1}', 'YYYY/MM/DD HH24:mi:ss')"
                                 , dtModify.AddDays(-nDays).ToString("yyyy/MM/dd 00:00:00")
                                 , dtModify.ToString("yyyy/MM/dd 00:00:00"));
            if (!string.IsNullOrEmpty(szIgnoreDocTypeIDs))
            {
                //不分析某些文档类型，例如胸科提出跳过分析知情同意书。
                szCondition = string.Format("{0} and A.{1} not in ({2})"
                    , szCondition
                    , SystemData.EmrDocTable.DOC_TYPE
                    , szIgnoreDocTypeIDs);
            }
            string szTable = string.Format("{0} A,{1} B", SystemData.DataTable.EMR_DOC, SystemData.DataTable.DOC_STATUS);
            IDataReader reader = null;
            string szSql = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);
            try
            {
                reader = base.MeddocAccess.ExecuteReader(szSql);
                if (reader == null || reader.IsClosed || !reader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;
                if (lstDocInfo == null)
                    lstDocInfo = new List<MedDocInfo>();
                lstDocInfo.Clear();
                do
                {
                    MedDocInfo docInfo = new MedDocInfo();
                    if (!reader.IsDBNull(0)) docInfo.PATIENT_ID = reader.GetString(0);
                    if (!reader.IsDBNull(1)) docInfo.VISIT_ID = reader.GetString(1);
                    if (!reader.IsDBNull(2)) docInfo.PATIENT_NAME = reader.GetString(2);
                    if (!reader.IsDBNull(3)) docInfo.DOC_TYPE = reader.GetString(3);
                    if (!reader.IsDBNull(4)) docInfo.DOC_ID = reader.GetString(4);
                    if (!reader.IsDBNull(5)) docInfo.DOC_TIME = reader.GetDateTime(5);
                    if (!reader.IsDBNull(6)) docInfo.MODIFY_TIME = reader.GetDateTime(6);
                    if (!reader.IsDBNull(7)) docInfo.CREATOR_ID = reader.GetString(7);
                    if (!reader.IsDBNull(8)) docInfo.CREATOR_NAME = reader.GetString(8);
                    if (!reader.IsDBNull(9)) docInfo.DOC_TITLE = reader.GetString(9);
                    if (!reader.IsDBNull(10)) docInfo.EMR_TYPE = reader.GetString(10);
                    if (!reader.IsDBNull(11)) docInfo.DOC_SETID = reader.GetString(11);
                    lstDocInfo.Add(docInfo);
                } while (reader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception)
            {

                throw;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据文档ID获取文档内容
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="byteDocData">文档二进制内容</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDocByID(string szDocID, ref byte[] byteDocData)
        {
            if (GlobalMethods.Misc.IsEmptyString(szDocID))
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocByID"
                    , new string[] { "szDocID" }, new object[] { szDocID }, "文档ID参数不能为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.StorageMode == StorageMode.Unknown)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocByID"
                    , new string[] { "szDocID" }, new object[] { szDocID }, "配置字典表中文档存储模式配置不正确!");
                return SystemData.ReturnValue.EXCEPTION;
            }

            if (base.StorageMode == StorageMode.DB)
                return this.GetDocFromDB(szDocID, ref byteDocData);
            else
                return this.GetDocFromFTP(szDocID, ref byteDocData);
        }
        /// <summary>
        /// 根据文档ID从DB中获取文档内容
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="byteDocData">文档二进制内容</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short GetDocFromDB(string szDocID, ref byte[] byteDocData)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}'", SystemData.EmrDocTable.DOC_ID, szDocID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                , SystemData.EmrDocTable.DOC_DATA, SystemData.DataTable.EMR_DOC, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    LogManager.Instance.WriteLog("MedDocAccess.GetDocFromDB"
                        , new string[] { "szSQL" }, new object[] { szSQL }, "没有查询到记录!");
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                return GlobalMethods.IO.GetBytes(dataReader, 0, ref byteDocData)
                    ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocFromDB", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 根据文档ID从FTP中获取文档内容
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="byteDocData">文档二进制内容</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short GetDocFromFTP(string szDocID, ref byte[] byteDocData)
        {
            MedDocInfo docInfo = null;
            short result = this.GetDocInfo(szDocID, ref docInfo);
            if (result != SystemData.ReturnValue.OK)
                return result;

            if (base.FtpAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (!base.FtpAccess.OpenConnection())
            {
                return SystemData.ReturnValue.EXCEPTION;
            }

            string szRemoteFile = SystemParam.Instance.GetFtpDocPath(docInfo, SystemData.FileType.MED_DOCUMENT);
            string szCacheFile = string.Format("{0}\\Documents\\Temp\\{1}.{2}", SystemParam.Instance.WorkPath
                , docInfo.DOC_ID, SystemData.FileType.MED_DOCUMENT);

            bool success = base.FtpAccess.Download(szRemoteFile, szCacheFile);
            if (!success)
            {
                if (base.FtpAccess.RenameFile(szRemoteFile + ".bak", szRemoteFile))
                {
                    success = base.FtpAccess.Download(szRemoteFile, szCacheFile);
                    LogManager.Instance.WriteLog("MedDocAccess.GetDocFromFTP", new string[] { "szRemoteFile" }
                        , new object[] { szRemoteFile }, "自动恢复了病历内容为前一次保存的状态!");
                }
            }
            if (!success)
            {
                base.FtpAccess.CloseConnection();
                return SystemData.ReturnValue.EXCEPTION;
            }

            if (!GlobalMethods.IO.GetFileBytes(szCacheFile, ref byteDocData))
            {
                base.FtpAccess.CloseConnection();
                GlobalMethods.IO.DeleteFile(szCacheFile);
                LogManager.Instance.WriteLog("MedDocAccess.GetDocFromFTP", new string[] { "szCacheFile" }
                    , new object[] { szCacheFile }, "GetFileBytes执行失败!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            base.FtpAccess.CloseConnection();
            GlobalMethods.IO.DeleteFile(szCacheFile);
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 根据文档ID，获取文档基本信息
        /// </summary>
        /// <param name="szDocID">文档编号</param>
        /// <param name="docInfo">文档信息类</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDocInfo(string szDocID, ref MedDocInfo docInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szDocID))
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocInfo", new string[] { "szDocID" }, new object[] { szDocID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            szDocID = szDocID.Trim();
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}"
                , SystemData.EmrDocTable.DOC_ID, SystemData.EmrDocTable.DOC_TYPE, SystemData.EmrDocTable.DOC_TITLE
                , SystemData.EmrDocTable.DOC_TIME, SystemData.EmrDocTable.DOC_SETID, SystemData.EmrDocTable.DOC_VERSION
                , SystemData.EmrDocTable.CREATOR_ID, SystemData.EmrDocTable.CREATOR_NAME, SystemData.EmrDocTable.MODIFIER_ID
                , SystemData.EmrDocTable.MODIFIER_NAME, SystemData.EmrDocTable.MODIFY_TIME, SystemData.EmrDocTable.PATIENT_ID
                , SystemData.EmrDocTable.PATIENT_NAME, SystemData.EmrDocTable.VISIT_ID, SystemData.EmrDocTable.VISIT_TIME
                , SystemData.EmrDocTable.VISIT_TYPE, SystemData.EmrDocTable.DEPT_CODE, SystemData.EmrDocTable.DEPT_NAME
                , SystemData.EmrDocTable.SIGN_CODE, SystemData.EmrDocTable.CONFID_CODE, SystemData.EmrDocTable.ORDER_VALUE
                , SystemData.EmrDocTable.RECORD_TIME, SystemData.EmrDocTable.EMR_TYPE
               );
            string szCondition = string.Format("{0}='{1}'", SystemData.EmrDocTable.DOC_ID, szDocID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataTable.EMR_DOC, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    LogManager.Instance.WriteLog("MedDocAccess.GetDocInfo", new string[] { "szSQL" }, new object[] { szSQL }, "未查询到记录");
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (docInfo == null)
                    docInfo = new MedDocInfo();
                do
                {
                    docInfo.DOC_ID = dataReader.GetString(0);
                    docInfo.DOC_TYPE = dataReader.GetString(1);
                    docInfo.DOC_TITLE = dataReader.GetString(2);
                    docInfo.DOC_TIME = dataReader.GetDateTime(3);
                    docInfo.DOC_SETID = dataReader.GetString(4);
                    docInfo.DOC_VERSION = int.Parse(dataReader.GetValue(5).ToString());
                    docInfo.CREATOR_ID = dataReader.GetString(6);
                    docInfo.CREATOR_NAME = dataReader.GetString(7);
                    docInfo.MODIFIER_ID = dataReader.GetString(8);
                    docInfo.MODIFIER_NAME = dataReader.GetString(9);
                    docInfo.MODIFY_TIME = dataReader.GetDateTime(10);
                    docInfo.PATIENT_ID = dataReader.GetString(11);
                    docInfo.PATIENT_NAME = dataReader.GetString(12);
                    docInfo.VISIT_ID = dataReader.GetString(13);
                    docInfo.VISIT_TIME = dataReader.GetDateTime(14);
                    docInfo.VISIT_TYPE = dataReader.GetString(15);
                    docInfo.DEPT_CODE = dataReader.GetString(16);
                    docInfo.DEPT_NAME = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18))
                        docInfo.SIGN_CODE = dataReader.GetString(18);
                    if (!dataReader.IsDBNull(19))
                        docInfo.CONFID_CODE = dataReader.GetString(19);
                    if (!dataReader.IsDBNull(20))
                        docInfo.ORDER_VALUE = int.Parse(dataReader.GetValue(20).ToString());
                    if (!dataReader.IsDBNull(21))
                        docInfo.RECORD_TIME = dataReader.GetDateTime(21);
                    if (!dataReader.IsDBNull(22))
                        docInfo.EMR_TYPE = dataReader.GetString(22);

                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocInfo", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }
        /// <summary>
        ///  根据文档集ID查询当前文档集对应的历次修订的病历记录
        /// </summary>
        /// <param name="szDocSetID">文档集ID</param>
        /// <param name="lstDocInfo">病历文档列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDocInfoBySetID(string szDocSetID, ref List<MedDocInfo> lstDocInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szDocSetID))
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocInfoBySetID", new string[] { "szDocSetID" }
                    , new object[] { szDocSetID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            szDocSetID = szDocSetID.Trim();
            string szField = string.Format("*");
            string szCondition = string.Format("{0}={1}", SystemData.EmrDocTable.DOC_SETID, base.ParaHolder(SystemData.EmrDocTable.DOC_SETID));
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataTable.EMR_DOC, szCondition
                , SystemData.EmrDocTable.MODIFY_TIME);
            DbParameter[] paras = new DbParameter[1] { new DbParameter(SystemData.EmrDocTable.DOC_SETID, szDocSetID) };

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text, ref paras);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    LogManager.Instance.WriteLog("MedDocAccess.GetDocInfoBySetID", new string[] { "szSQL" }, new object[] { szSQL }, "未查询到记录");
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstDocInfo == null)
                    lstDocInfo = new List<MedDocInfo>();
                do
                {
                    MedDocInfo model = new MedDocInfo();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.EmrDocTable.CONFID_CODE:
                                model.CONFID_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.CREATOR_ID:
                                model.CREATOR_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.CREATOR_NAME:
                                model.CREATOR_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DEPT_CODE:
                                model.DEPT_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DEPT_NAME:
                                model.DEPT_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_ID:
                                model.CONFID_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_SETID:
                                model.DOC_SETID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_TIME:
                                model.DOC_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.DOC_TITLE:
                                model.DOC_TITLE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_TYPE:
                                model.DOC_TYPE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.DOC_VERSION:
                                model.DOC_VERSION = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.EMR_TYPE:
                                model.EMR_TYPE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.MODIFIER_ID:
                                model.MODIFIER_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.MODIFIER_NAME:
                                model.MODIFIER_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.MODIFY_TIME:
                                model.MODIFY_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.ORDER_VALUE:
                                model.ORDER_VALUE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.PATIENT_ID:
                                model.PATIENT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.PATIENT_NAME:
                                model.PATIENT_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.RECORD_TIME:
                                model.RECORD_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.SIGN_CODE:
                                model.SIGN_CODE = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.TEMPLET_ID:
                                model.TEMPLET_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.VISIT_ID:
                                model.VISIT_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.EmrDocTable.VISIT_TIME:
                                model.VISIT_TIME = DateTime.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.VISIT_TYPE:
                                model.VISIT_TYPE = dataReader.GetValue(i).ToString();
                                break;
                            default: break;
                        }
                    }
                    lstDocInfo.Add(model);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocInfoBySetID", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 获取指定文档集中最新的文档版本信息
        /// </summary>
        /// <param name="szDocSetID">文档集ID</param>
        /// <param name="docInfo">文档信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetLatestDocID(string szDocSetID, ref MedDocInfo docInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szDocSetID))
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetLatestDocID", new string[] { "szDocSetID" }
                    , new object[] { szDocSetID }, "参数不能为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            szDocSetID = szDocSetID.Trim();
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}"
                , SystemData.EmrDocTable.DOC_ID, SystemData.EmrDocTable.DOC_TYPE, SystemData.EmrDocTable.DOC_TITLE
                , SystemData.EmrDocTable.DOC_TIME, SystemData.EmrDocTable.DOC_SETID, SystemData.EmrDocTable.DOC_VERSION
                , SystemData.EmrDocTable.CREATOR_ID, SystemData.EmrDocTable.CREATOR_NAME, SystemData.EmrDocTable.MODIFIER_ID
                , SystemData.EmrDocTable.MODIFIER_NAME, SystemData.EmrDocTable.MODIFY_TIME, SystemData.EmrDocTable.PATIENT_ID
                , SystemData.EmrDocTable.PATIENT_NAME, SystemData.EmrDocTable.VISIT_ID, SystemData.EmrDocTable.VISIT_TIME
                , SystemData.EmrDocTable.VISIT_TYPE, SystemData.EmrDocTable.DEPT_CODE, SystemData.EmrDocTable.DEPT_NAME
                , SystemData.EmrDocTable.SIGN_CODE, SystemData.EmrDocTable.CONFID_CODE, SystemData.EmrDocTable.ORDER_VALUE
                , SystemData.EmrDocTable.RECORD_TIME, SystemData.EmrDocTable.EMR_TYPE);
            string szCondition = string.Format("{0}={1}", SystemData.EmrDocTable.DOC_SETID, base.ParaHolder(SystemData.EmrDocTable.DOC_SETID));
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_DESC, szField, SystemData.DataTable.EMR_DOC, szCondition
                , SystemData.EmrDocTable.DOC_VERSION);


            DbParameter[] paras = new DbParameter[1];
            paras[0] = new DbParameter(SystemData.EmrDocTable.DOC_SETID, szDocSetID);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text, ref paras);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;

                if (docInfo == null)
                    docInfo = new MedDocInfo();
                docInfo.DOC_ID = dataReader.GetString(0);
                docInfo.DOC_TYPE = dataReader.GetString(1);
                docInfo.DOC_TITLE = dataReader.GetString(2);
                docInfo.DOC_TIME = dataReader.GetDateTime(3);
                docInfo.DOC_SETID = dataReader.GetString(4);
                docInfo.DOC_VERSION = int.Parse(dataReader.GetValue(5).ToString());
                docInfo.CREATOR_ID = dataReader.GetString(6);
                docInfo.CREATOR_NAME = dataReader.GetString(7);
                docInfo.MODIFIER_ID = dataReader.GetString(8);
                docInfo.MODIFIER_NAME = dataReader.GetString(9);
                docInfo.MODIFY_TIME = dataReader.GetDateTime(10);
                docInfo.PATIENT_ID = dataReader.GetString(11);
                docInfo.PATIENT_NAME = dataReader.GetString(12);
                docInfo.VISIT_ID = dataReader.GetString(13);
                docInfo.VISIT_TIME = dataReader.GetDateTime(14);
                docInfo.VISIT_TYPE = dataReader.GetString(15);
                docInfo.DEPT_CODE = dataReader.GetString(16);
                docInfo.DEPT_NAME = dataReader.GetString(17);
                if (!dataReader.IsDBNull(18))
                    docInfo.SIGN_CODE = dataReader.GetString(18);
                if (!dataReader.IsDBNull(19))
                    docInfo.CONFID_CODE = dataReader.GetString(19);
                if (!dataReader.IsDBNull(20))
                    docInfo.ORDER_VALUE = int.Parse(dataReader.GetValue(20).ToString());
                if (!dataReader.IsDBNull(21))
                    docInfo.RECORD_TIME = dataReader.GetDateTime(21);
                if (!dataReader.IsDBNull(22))
                    docInfo.EMR_TYPE = dataReader.GetString(22);

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetLatestDocID", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 获取指定修改者在指定时间内修改病历的信息
        /// </summary>
        /// <param name="szModifierID">修改者ID</param>
        /// <param name="dtBegin">修改开始时间</param>
        /// <param name="dtEnd">修改截止时间</param>
        /// <param name="lstDocInfos">文档信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDocInfos(string szModifierID, DateTime dtBegin, DateTime dtEnd, ref List<MedDocInfo> lstDocInfos)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            szModifierID = szModifierID.Trim();
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}"
                , SystemData.EmrDocTable.DOC_SETID, SystemData.EmrDocTable.DOC_TITLE
                , SystemData.EmrDocTable.PATIENT_ID, SystemData.EmrDocTable.PATIENT_NAME
                , SystemData.EmrDocTable.CREATOR_ID, SystemData.EmrDocTable.CREATOR_NAME
                , SystemData.EmrDocTable.MODIFIER_ID, SystemData.EmrDocTable.MODIFIER_NAME
                , SystemData.EmrDocTable.DOC_TIME);

            DbParameter[] paras = new DbParameter[3]
            {
                new DbParameter(SystemData.EmrDocTable.MODIFIER_ID,szModifierID),
                new DbParameter("BeginDate",dtBegin),
                new DbParameter("EndDate",dtEnd)
            };

            string szCondition = string.Format("{0}={1} AND {2}>={3} AND {2}<{4} AND {5}>1"
                , SystemData.EmrDocTable.MODIFIER_ID, base.ParaHolder(SystemData.EmrDocTable.MODIFIER_ID)
                , SystemData.EmrDocTable.MODIFY_TIME, base.ParaHolder("BeginDate"), base.ParaHolder("EndDate")
                , SystemData.EmrDocTable.DOC_VERSION);
            string szOrderBy = string.Format("{0},{1}"
                , SystemData.EmrDocTable.DOC_SETID, SystemData.EmrDocTable.DOC_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                , szField, SystemData.DataTable.EMR_DOC, szCondition, szOrderBy);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text, ref paras);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;

                if (lstDocInfos == null)
                    lstDocInfos = new List<MedDocInfo>();
                do
                {
                    MedDocInfo docInfo = new MedDocInfo();
                    docInfo.DOC_SETID = dataReader.GetString(0);
                    docInfo.DOC_TITLE = dataReader.GetString(1);
                    docInfo.PATIENT_ID = dataReader.GetString(2);
                    docInfo.PATIENT_NAME = dataReader.GetString(3);
                    docInfo.CREATOR_ID = dataReader.GetString(4);
                    docInfo.CREATOR_NAME = dataReader.GetString(5);
                    docInfo.MODIFIER_ID = dataReader.GetString(6);
                    docInfo.MODIFIER_NAME = dataReader.GetString(7);
                    docInfo.DOC_TIME = dataReader.GetDateTime(8);

                    lstDocInfos.Add(docInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocInfos", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 获取指定就诊，指定病人，指定类型中已有文档详细信息列表.
        /// 注意：该接口不对返回病历列表进行排序,需要外部主动调用Sort方法排序
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊编号</param>
        /// <param name="szVisitType">就诊类型</param>
        /// <param name="dtVisitTime">就诊时间</param>
        /// <param name="szDocTypeID">文档类型代码,为空时返回当次就诊下所有类型的文档</param>
        /// <param name="lstDocInfos">文档信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDocInfos(string szPatientID, string szVisitID, string szVisitType, DateTime dtVisitTime, string szDocTypeID, ref MedDocList lstDocInfos)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.CONFID_CODE);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.CREATOR_ID);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.CREATOR_NAME);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.DEPT_CODE);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.DEPT_NAME);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.DOC_ID);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.DOC_SETID);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.DOC_TIME);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.DOC_TITLE);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.DOC_TYPE);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.DOC_VERSION);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.EMR_TYPE);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.MODIFIER_ID);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.MODIFIER_NAME);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.MODIFY_TIME);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.ORDER_VALUE);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.PATIENT_ID);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.PATIENT_NAME);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.RECORD_TIME);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.SIGN_CODE);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.TEMPLET_ID);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.VISIT_ID);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.VISIT_TIME);
            sbField.AppendFormat("A.{0},", SystemData.EmrDocTable.VISIT_TYPE);
            sbField.AppendFormat("B.{0}", SystemData.DocStatusTable.STATUS_DESC);
            //创建用来确定一次就诊的查询条件
            string szCondition = null;
            if (szVisitType == SystemData.VisitType.OP)
            {
                szCondition = string.Format("A.{0}='{1}' AND A.{2}={3}", SystemData.EmrDocTable.VISIT_ID, szVisitID
                    , SystemData.EmrDocTable.VISIT_TIME, base.MeddocAccess.GetSqlTimeFormat(dtVisitTime));
            }
            else
            {
                szCondition = string.Format("A.{0}='{1}' AND A.{2}='{3}'", SystemData.EmrDocTable.VISIT_ID, szVisitID
                    , SystemData.EmrDocTable.PATIENT_ID, szPatientID);
            }

            //过滤掉已作废的文档
            szCondition = string.Format("{0} AND A.{1}=B.{2} AND B.{3}!='{4}'", szCondition
                , SystemData.EmrDocTable.DOC_ID, SystemData.DocStatusTable.DOC_ID
                , SystemData.DocStatusTable.DOC_STATUS, SystemData.DocStatus.CANCELED);

            //如果传入了文档类型,则仅获取该文档类型对应的文档列表
            if (!GlobalMethods.Misc.IsEmptyString(szDocTypeID))
            {
                //这个子查询的设置是为了包含子文档类型
                string szSubSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , SystemData.DocTypeTable.DOCTYPE_ID, SystemData.DataTable.DOC_TYPE
                    , string.Format("{0}='{1}'", SystemData.DocTypeTable.HOSTTYPE_ID, szDocTypeID));

                szCondition = string.Format("{0} AND (A.{1}='{2}' OR A.{1} IN ({3}))", szCondition
                    , SystemData.EmrDocTable.DOC_TYPE, szDocTypeID, szSubSQL);
            }

            string szTable = string.Format("{0} A,{1} B", SystemData.DataTable.EMR_DOC, SystemData.DataTable.DOC_STATUS);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, sbField.ToString(), szTable, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;

                if (lstDocInfos == null)
                    lstDocInfos = new MedDocList();
                do
                {
                    MedDocInfo docInfo = new MedDocInfo();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.EmrDocTable.CONFID_CODE:
                                docInfo.CONFID_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.CREATOR_ID:
                                docInfo.CREATOR_ID = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.CREATOR_NAME:
                                docInfo.CREATOR_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.DEPT_CODE:
                                docInfo.DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.DEPT_NAME:
                                docInfo.DEPT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.DOC_ID:
                                docInfo.DOC_ID = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.DOC_SETID:
                                docInfo.DOC_SETID = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.DOC_TIME:
                                docInfo.DOC_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.EmrDocTable.DOC_TITLE:
                                docInfo.DOC_TITLE = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.DOC_TYPE:
                                docInfo.DOC_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.DOC_VERSION:
                                docInfo.DOC_VERSION = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.EMR_TYPE:
                                docInfo.EMR_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.MODIFIER_ID:
                                docInfo.MODIFIER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.MODIFIER_NAME:
                                docInfo.MODIFIER_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.MODIFY_TIME:
                                docInfo.MODIFY_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.EmrDocTable.ORDER_VALUE:
                                docInfo.ORDER_VALUE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.EmrDocTable.PATIENT_ID:
                                docInfo.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.PATIENT_NAME:
                                docInfo.PATIENT_NAME = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.RECORD_TIME:
                                docInfo.RECORD_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.EmrDocTable.SIGN_CODE:
                                docInfo.SIGN_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.TEMPLET_ID:
                                docInfo.TEMPLET_ID = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.VISIT_ID:
                                docInfo.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.EmrDocTable.VISIT_TIME:
                                docInfo.VISIT_TIME = dataReader.GetDateTime(i);
                                break;
                            case SystemData.EmrDocTable.VISIT_TYPE:
                                docInfo.VISIT_TYPE = dataReader.GetString(i);
                                break;
                            case SystemData.DocStatusTable.STATUS_DESC:
                                docInfo.StatusDesc = dataReader.GetString(i);
                                break;
                            default:
                                break;
                        }
                    }
                    lstDocInfos.Add(docInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocInfos", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 获取指定就诊，指定病人，指定类型中已有文档详细信息列表.
        /// 注意：该接口不对返回病历列表进行排序,需要外部主动调用Sort方法排序
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊编号</param>
        /// <param name="szVisitType">就诊类型</param>
        /// <param name="dtVisitTime">就诊时间</param>
        /// <param name="szDocTypeID">文档类型代码,为空时返回当次就诊下所有类型的文档</param>
        /// <param name="lstDocInfos">文档信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDocInfos(string szPatientID, string szVisitID, string szVisitType, DateTime dtVisitTime, string szDocTypeID, ref List<MedDocInfo> lstDocInfos)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("A.{0},A.{1},A.{2},A.{3},A.{4},A.{5},A.{6},A.{7},A.{8},A.{9},A.{10},A.{11},A.{12},A.{13},A.{14},A.{15},A.{16},A.{17},A.{18},A.{19},A.{20},A.{21},A.{22} "
                , SystemData.EmrDocTable.DOC_ID, SystemData.EmrDocTable.DOC_TYPE, SystemData.EmrDocTable.DOC_TITLE
                , SystemData.EmrDocTable.DOC_TIME, SystemData.EmrDocTable.DOC_SETID, SystemData.EmrDocTable.DOC_VERSION
                , SystemData.EmrDocTable.CREATOR_ID, SystemData.EmrDocTable.CREATOR_NAME, SystemData.EmrDocTable.MODIFIER_ID
                , SystemData.EmrDocTable.MODIFIER_NAME, SystemData.EmrDocTable.MODIFY_TIME, SystemData.EmrDocTable.PATIENT_ID
                , SystemData.EmrDocTable.PATIENT_NAME, SystemData.EmrDocTable.VISIT_ID, SystemData.EmrDocTable.VISIT_TIME
                , SystemData.EmrDocTable.VISIT_TYPE, SystemData.EmrDocTable.DEPT_CODE, SystemData.EmrDocTable.DEPT_NAME
                , SystemData.EmrDocTable.SIGN_CODE, SystemData.EmrDocTable.CONFID_CODE, SystemData.EmrDocTable.ORDER_VALUE
                , SystemData.EmrDocTable.RECORD_TIME, SystemData.EmrDocTable.EMR_TYPE);

            //创建用来确定一次就诊的查询条件
            string szCondition = null;
            if (szVisitType == SystemData.VisitType.OP)
            {
                szCondition = string.Format("A.{0}='{1}' AND A.{2}={3}", SystemData.EmrDocTable.VISIT_ID, szVisitID, SystemData.EmrDocTable.VISIT_TIME, base.MeddocAccess.GetSqlTimeFormat(dtVisitTime));
            }
            else
            {
                szCondition = string.Format("A.{0}='{1}' AND A.{2}='{3}'", SystemData.EmrDocTable.VISIT_ID, szVisitID
                    , SystemData.EmrDocTable.PATIENT_ID, szPatientID);
            }

            //过滤掉已作废的文档
            szCondition = string.Format("{0} AND A.{1}=B.{2} AND B.{3}!='{4}'", szCondition
                , SystemData.EmrDocTable.DOC_ID, SystemData.DocStatusTable.DOC_ID
                , SystemData.DocStatusTable.DOC_STATUS, SystemData.DocStatus.CANCELED);

            //如果传入了文档类型,则仅获取该文档类型对应的文档列表
            if (!GlobalMethods.Misc.IsEmptyString(szDocTypeID))
            {
                //这个子查询的设置是为了包含子文档类型
                string szSubSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , SystemData.DocTypeTable.DOCTYPE_ID, SystemData.DataTable.DOC_TYPE
                    , string.Format("{0}='{1}'", SystemData.DocTypeTable.HOSTTYPE_ID, szDocTypeID));

                szCondition = string.Format("{0} AND (A.{1}='{2}' OR A.{1} IN ({3}))", szCondition
                    , SystemData.EmrDocTable.DOC_TYPE, szDocTypeID, szSubSQL);
            }

            string szTable = string.Format("{0} A,{1} B", SystemData.DataTable.EMR_DOC, SystemData.DataTable.DOC_STATUS);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;

                if (lstDocInfos == null)
                    lstDocInfos = new List<MedDocInfo>();
                do
                {
                    MedDocInfo docInfo = new MedDocInfo();
                    docInfo.DOC_ID = dataReader.GetString(0);
                    docInfo.DOC_TYPE = dataReader.GetString(1);
                    docInfo.DOC_TITLE = dataReader.GetString(2);
                    docInfo.DOC_TIME = dataReader.GetDateTime(3);
                    docInfo.DOC_SETID = dataReader.GetString(4);
                    docInfo.DOC_VERSION = int.Parse(dataReader.GetValue(5).ToString());
                    docInfo.CREATOR_ID = dataReader.GetString(6);
                    docInfo.CREATOR_NAME = dataReader.GetString(7);
                    docInfo.MODIFIER_ID = dataReader.GetString(8);
                    docInfo.MODIFIER_NAME = dataReader.GetString(9);
                    docInfo.MODIFY_TIME = dataReader.GetDateTime(10);
                    docInfo.PATIENT_ID = dataReader.GetString(11);
                    docInfo.PATIENT_NAME = dataReader.GetString(12);
                    docInfo.VISIT_ID = dataReader.GetString(13);
                    docInfo.VISIT_TIME = dataReader.GetDateTime(14);
                    docInfo.VISIT_TYPE = dataReader.GetString(15);
                    docInfo.DEPT_CODE = dataReader.GetString(16);
                    docInfo.DEPT_NAME = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18))
                        docInfo.SIGN_CODE = dataReader.GetString(18);
                    if (!dataReader.IsDBNull(19))
                        docInfo.CONFID_CODE = dataReader.GetString(19);
                    if (!dataReader.IsDBNull(20))
                        docInfo.ORDER_VALUE = int.Parse(dataReader.GetValue(20).ToString());
                    if (!dataReader.IsDBNull(21))
                        docInfo.RECORD_TIME = dataReader.GetDateTime(21);
                    if (!dataReader.IsDBNull(22))
                        docInfo.EMR_TYPE = dataReader.GetString(22);
                    lstDocInfos.Add(docInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.GetDocInfos", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 更新病历审签状态，主要用于病历质控退回
        /// </summary>
        public short UpdateDocSignCode(string szDocSetID, string szSignCode)
        {
            if (string.IsNullOrEmpty(szDocSetID) || base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("{0}='{1}'"
              , SystemData.EmrDocTable.SIGN_CODE, szSignCode);
            string szCondition = string.Format("{0}='{1}'", SystemData.EmrDocTable.DOC_SETID, szDocSetID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.EMR_DOC, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MeddocAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocAccess.UpdateDocSignCode", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("MedDocAccess.UpdateDocSignCode", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

    }
}
