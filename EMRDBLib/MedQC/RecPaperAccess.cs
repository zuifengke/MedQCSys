// ***********************************************************
// 病历质控结果数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using Heren.Common.Libraries.Ftp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{

    public class RecPaperAccess : DBAccessBase
    {
        private static RecPaperAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static RecPaperAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new RecPaperAccess();
                return RecPaperAccess.m_Instance;
            }
        }

        /// <summary>
        /// 获取所有自动核查结果信息列表
        /// </summary>
        /// <param name="lstQcCheckResults"></param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetRecPaper(string szPaperID, ref RecPaper recPaper)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.DOC_ID);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.IMAGE_FRONTAGE);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.IMAGE_OPPOSITE);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.PAPER_STATE);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.PAPER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecPaperTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szPaperID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.RecPaperTable.PAPER_ID
                    , szPaperID);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PAPER, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (recPaper == null)
                    recPaper = new RecPaper();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.RecPaperTable.DOC_ID:
                            recPaper.DOC_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPaperTable.IMAGE_FRONTAGE:
                            recPaper.IMAGE_FRONTAGE = dataReader.GetString(i);
                            break;
                        case SystemData.RecPaperTable.IMAGE_OPPOSITE:
                            recPaper.IMAGE_OPPOSITE = dataReader.GetString(i);
                            break;
                        case SystemData.RecPaperTable.PAPER_ID:
                            recPaper.PAPER_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPaperTable.PAPER_STATE:
                            recPaper.PAPER_STATE = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        case SystemData.RecPaperTable.PATIENT_ID:
                            recPaper.PATIENT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPaperTable.VISIT_ID:
                            recPaper.VISIT_ID = dataReader.GetString(i);
                            break;
                        case SystemData.RecPaperTable.VISIT_NO:
                            recPaper.VISIT_NO = dataReader.GetString(i);
                            break;
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

        public short GetRecPapers(string szPatientID, string szVisitNo, ref List<RecPaper> lstRecPapers)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.DOC_ID);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.IMAGE_FRONTAGE);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.IMAGE_OPPOSITE);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.PAPER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.PAPER_STATE);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecPaperTable.VISIT_NO);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = '{4}'"
                , szCondition
                , SystemData.RecPaperTable.PATIENT_ID, szPatientID
                , SystemData.RecPaperTable.VISIT_NO,szVisitNo);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.REC_PAPER, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstRecPapers == null)
                    lstRecPapers = new List<RecPaper>();
                do
                {
                    RecPaper recPaper = new RecPaper();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.RecPaperTable.DOC_ID:
                                recPaper.DOC_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPaperTable.IMAGE_FRONTAGE:
                                recPaper.IMAGE_FRONTAGE = dataReader.GetString(i);
                                break;
                            case SystemData.RecPaperTable.IMAGE_OPPOSITE:
                                recPaper.IMAGE_OPPOSITE = dataReader.GetString(i);
                                break;
                            case SystemData.RecPaperTable.PAPER_ID:
                                recPaper.PAPER_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPaperTable.PAPER_STATE:
                                recPaper.PAPER_STATE = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            case SystemData.RecPaperTable.PATIENT_ID:
                                recPaper.PATIENT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPaperTable.VISIT_ID:
                                recPaper.VISIT_ID = dataReader.GetString(i);
                                break;
                            case SystemData.RecPaperTable.VISIT_NO:
                                recPaper.VISIT_NO = dataReader.GetString(i);
                                break;
                        }
                    }
                    lstRecPapers.Add(recPaper);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 新增一条人工核查结果信息
        /// </summary>
        /// <param name="recPaper">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(RecPaper recPaper)
        {
            if (recPaper == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { recPaper }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (recPaper.PAPER_ID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.DOC_ID);
            sbValue.AppendFormat("'{0}',", recPaper.DOC_ID);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.IMAGE_FRONTAGE);
            sbValue.AppendFormat("'{0}',", recPaper.IMAGE_FRONTAGE);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.IMAGE_OPPOSITE);
            sbValue.AppendFormat("'{0}',", recPaper.IMAGE_OPPOSITE);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.PAPER_ID);
            sbValue.AppendFormat("'{0}',", recPaper.PAPER_ID);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.PAPER_STATE);
            sbValue.AppendFormat("{0},", recPaper.PAPER_STATE);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.PATIENT_ID);
            sbValue.AppendFormat("'{0}',", recPaper.PATIENT_ID);
            sbField.AppendFormat("{0},", SystemData.RecPaperTable.VISIT_ID);
            sbValue.AppendFormat("'{0}',", recPaper.VISIT_ID);
            sbField.AppendFormat("{0}", SystemData.RecPaperTable.VISIT_NO);
            sbValue.AppendFormat("'{0}'", recPaper.VISIT_NO);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.REC_PAPER, sbField.ToString(), sbValue.ToString());
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
        /// <summary>
        /// 更新一条整改通知单
        /// </summary>
        /// <param name="timeQCRule">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(RecPaper recPaper)
        {
            if (recPaper == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { recPaper }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPaperTable.DOC_ID,recPaper.DOC_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPaperTable.IMAGE_FRONTAGE, recPaper.IMAGE_FRONTAGE);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPaperTable.IMAGE_OPPOSITE, recPaper.IMAGE_OPPOSITE);
            sbField.AppendFormat("{0}={1},"
                , SystemData.RecPaperTable.PAPER_STATE, recPaper.PAPER_STATE);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPaperTable.PATIENT_ID, recPaper.PATIENT_ID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.RecPaperTable.VISIT_ID, recPaper.VISIT_ID);
            sbField.AppendFormat("{0}='{1}'"
                , SystemData.RecPaperTable.VISIT_NO, recPaper.VISIT_NO);
            string szCondition = string.Format("{0}='{1}'", SystemData.RecPaperTable.PAPER_ID, recPaper.PAPER_ID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.REC_PAPER, sbField.ToString(), szCondition);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="szRuleID">自动核查结果ID</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szPaperID)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szPaperID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szPaperID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.RecPaperTable.PAPER_ID, szPaperID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.REC_PAPER, szCondition);
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

        /// <summary>
        /// 获取FTP图片
        /// </summary>
        /// <param name="recPaperInfo"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public short GetImageFromFtp(RecPaper recPaperInfo, string fileName, ref string szLocalFile)
        {
            if (recPaperInfo == null)
                return SystemData.ReturnValue.FAILED;
            FtpAccess recPaperFtpAccess = base.GetRecPaperFtpAccess();
            try
            {
                if (recPaperInfo == null)
                    return SystemData.ReturnValue.PARAM_ERROR;
                if (!recPaperFtpAccess.OpenConnection())
                    return SystemData.ReturnValue.FAILED;
                string szRemoteFilePath = GetRecPaperRemoteDir(recPaperInfo) + fileName;
                szLocalFile = this.GetImageLocalFile(fileName);
                if (!recPaperFtpAccess.ResExists(szRemoteFilePath, false))
                    return SystemData.ReturnValue.FAILED;
                if (!recPaperFtpAccess.Download(szRemoteFilePath, szLocalFile))
                {
                    szLocalFile = "";
                    return SystemData.ReturnValue.FAILED;
                }
            }
            finally
            {
                if (recPaperFtpAccess != null)
                    recPaperFtpAccess.CloseConnection();
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 获取本地图片
        /// </summary>
        /// <param name="imageFrontage"></param>
        /// <returns></returns>
        public string GetImageLocalFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return "";
            return GlobalMethods.Misc.GetWorkingPath() + "\\Cache\\" + fileName;
        }

        private string GetRecPaperRemoteDir(RecPaper recPaperInfo)
        {
            //链接病人根目录
            StringBuilder ftpPath = new StringBuilder();
            ftpPath.Append("/RECPAPER");

            if (recPaperInfo == null || recPaperInfo.PATIENT_ID == null)
                return ftpPath.ToString();

            string szPatientID = recPaperInfo.PATIENT_ID.PadLeft(10, '0');
            for (int index = 0; index < 10; index += 2)
            {
                ftpPath.Append("/");
                ftpPath.Append(szPatientID.Substring(index, 2));
            }

            //链接就诊目录
            ftpPath.Append("/");
            ftpPath.Append("IP_");
            ftpPath.Append(recPaperInfo.VISIT_ID);
            ftpPath.Append("/");
            return ftpPath.ToString();
        }
    }
}