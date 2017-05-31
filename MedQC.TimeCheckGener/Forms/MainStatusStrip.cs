// ***********************************************************
// 病案质控系统主窗口状态条控件.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Timer = System.Windows.Forms.Timer;
using EMRDBLib.DbAccess;
using EMRDBLib;
using MedDocSys.QCEngine.BugCheck;
using MedDocSys.QCEngine.TimeCheck;

namespace Heren.MedQC.TimeCheckGener.Forms
{
    internal class MainStatusStrip : StatusStrip
    {
        //运行状态
        public enum RunState
        {
            Normal,
            Running,
            Pause,
            Stop
        }

        private List<PatVisitInfo> m_ListPatVisitInfos;

      
        private BugCheckEngine m_bugCheckEngine;
        private RunState m_BugState = RunState.Normal;

        private DateTime m_LastBugRunTime = SystemParam.Instance.DefaultTime;
        //最近一次时效执行的时间
        private DateTime m_LastQCRunTime = SystemParam.Instance.DefaultTime;


        private global::MedQC.TimeCheckGener.MainForm m_parent;
        private RunState m_QCState = RunState.Normal;
        private Thread m_QCThread;

        public MainStatusStrip()
            : this(null)
        {
            m_ListPatVisitInfos = new List<PatVisitInfo>();
        }

        public MainStatusStrip(global::MedQC.TimeCheckGener.MainForm parent)
        {
            m_parent = parent;
            InitializeComponent();
            CommonTimer.Stop();
        }

        public virtual global::MedQC.TimeCheckGener.MainForm MainForm
        {
            get { return m_parent; }
            set { m_parent = value; }
        }

        public void ShowStatusMessage(string szMessage)
        {
            if (szMessage == null || szMessage.Trim() == string.Empty)
                szMessage = "就绪";
            statuslblSystemInfo.Text = szMessage;
            Update();
        }

        public void Stop()
        {
            CommonTimer.Stop();
            if (m_QCThread != null)
                m_QCThread.Abort();

        }

        public void Start()
        {
            CommonTimer.Start();
            
            m_ListPatVisitInfos.Clear();
        }

        private void CommonTick_Tick(object sender, EventArgs e)
        {
            statuslblTime.Text = DateTime.Now.ToString("yyyy年M月d日 HH:mm:ss dddd");
            //时效检查
            if (m_QCState != RunState.Running
                && DateTime.Now.ToString("H:m") == MainForm.QCStartTime
               ) //当天运行过了不再运行
            {
                m_QCState = RunState.Running;
                m_QCThread = new Thread(DoTimeCheckGener);
                m_QCThread.Start(); //启动线程
               
            }
            //内容检查
            if (m_BugState != RunState.Running
                && DateTime.Now.ToString("H:m") == MainForm.BugStartTime
               )
            {
            
                //m_BugState = RunState.Running;
                //m_BugThread = new Thread(BugCheckGener);
                //m_BugThread.Start(); //启动线程
                BugCheckGener();
               
            }
        }

        private void DoTimeCheckGener()
        {
            if (!this.MainForm.bTimeCheckRunning)
                return;
            int iCurrIndex = 0;
            LogManager.Instance.WriteLog(string.Format("{0} 执行时效记录生成", DateTime.Now), null, LogType.Information);
            List<EMRDBLib.PatVisitInfo> lstPatVisitLog = null;
            short shRet =QcTimeRecordAccess.Instance.GetPatsListByInHosptial(ref lstPatVisitLog);
            if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                LogManager.Instance.WriteLog("未查询到在院病人或失败");
                m_QCState = RunState.Normal;
                return;
            }
            int nudDisCharge = int.Parse(m_parent.DischargeDays);
            DateTime now = DateTime.Now;
            m_LastQCRunTime = now;
            DateTime dtDischargeBeginTime = DateTime.Parse(now.AddDays(-nudDisCharge).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtDischargeEndTime = DateTime.Parse(now.ToString("yyyy-MM-dd 23:59:59"));

            shRet = QcTimeRecordAccess.Instance.GetPatsListByOutHosptial(dtDischargeBeginTime, dtDischargeEndTime,
                ref lstPatVisitLog);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND
                && lstPatVisitLog.Count <= 0)
            {
                LogManager.Instance.WriteLog("未查询到出院病人");
                m_QCState = RunState.Normal;
                return;
            }
            if (lstPatVisitLog != null && lstPatVisitLog.Count > 0)
            {
                LogManager.Instance.WriteLog(
                    string.Format("时效版本号：{1}，本次时效运行病案数：{0} 开始执行 ", lstPatVisitLog.Count,
                        Assembly.GetExecutingAssembly().GetName().Version), null, LogType.Information);
                iCurrIndex = 0;
                StartRun(lstPatVisitLog.Count, CheckType.TimeCheck);
                int nError = 0;
                int nSuccess = 0;
                foreach (EMRDBLib.PatVisitInfo item in lstPatVisitLog)
                {
                    if (string.IsNullOrEmpty(item.INCHARGE_DOCTOR))
                    {
                        string szDoctorIncharge = string.Empty;
                        //通过病人视图无法取到责任医生，由于首页未录入造成，通过最近书写的一份文书去取
                        shRet = EmrDocAccess.Instance.GetDoctorInChargeByEmrDoc(item.PATIENT_ID, item.VISIT_ID,
                            ref szDoctorIncharge);
                        if (shRet == SystemData.ReturnValue.OK)
                            item.INCHARGE_DOCTOR = szDoctorIncharge;
                    }
                    TimeCheckQuery timeCheckQuery = new TimeCheckQuery();
                    timeCheckQuery.PatientID = item.PATIENT_ID;
                    //timeCheckQuery.VisitID = item.VISIT_ID;
                    //timeCheckQuery.VisitID = SystemParam.Instance.PatVisitLog.VISIT_ID;
                    //编辑器VISIT_NO=VISIT_ID
                    timeCheckQuery.VisitID = item.VISIT_NO;
                    timeCheckQuery.VisitNO = item.VISIT_NO;
                    timeCheckQuery.PatientName = item.PATIENT_NAME;
                    timeCheckQuery.DeptCode = item.DEPT_CODE;
                    try
                    {
                        TimeCheckEngine.Instance.PerformTimeCheck(timeCheckQuery);
                    }
                    catch (Exception ex)
                    {
                        m_QCState = RunState.Normal;
                        LogManager.Instance.WriteLog("TimeCheckEngine.Instance.PerformTimeCheck 时效接口调用失败", ex);
                        nError++;
                        continue;
                    }
                    //获取已经保存在数据库QC_TIME_RECORD_T表里面的时效结果
                    List<QcTimeRecord> lstExitQCTimeRecord = new List<QcTimeRecord>();
                    QcTimeRecordAccess.Instance.GetQcTimeRecords(item.PATIENT_ID, item.VISIT_ID, ref lstExitQCTimeRecord);

                    //保存时效质控分析结果
                    List<TimeCheckResult> lstCheckResults = TimeCheckEngine.Instance.TimeCheckResults;

                    if (lstCheckResults == null)
                        continue;
                    List<QcTimeRecord> lstQcTimeRecord = new List<QcTimeRecord>();
                    for (int index = 0; index < lstCheckResults.Count; index++)
                    {
                        QcTimeRecord qcTimeRecord = new QcTimeRecord();
                        TimeCheckResult resultInfo = lstCheckResults[index];
                        resultInfo.VisitID = item.VISIT_ID;
                        qcTimeRecord.BeginDate = resultInfo.StartTime;
                        qcTimeRecord.CheckDate = now;
                        qcTimeRecord.CheckName = "系统自动";
                        qcTimeRecord.CreateID = resultInfo.CreatorID;
                        qcTimeRecord.CreateName = resultInfo.CreatorName;
                        qcTimeRecord.DeptInCharge = item.DEPT_CODE;
                        qcTimeRecord.DeptStayed = item.DEPT_NAME;
                        qcTimeRecord.DocID = resultInfo.DocID;
                        qcTimeRecord.DocTitle = resultInfo.DocTitle;
                        qcTimeRecord.DoctorInCharge = item.INCHARGE_DOCTOR;
                        qcTimeRecord.DocTypeID = resultInfo.DocTypeID;
                        qcTimeRecord.DocTypeName = resultInfo.DocTypeName;
                        qcTimeRecord.EndDate = resultInfo.EndTime;
                        qcTimeRecord.EventID = resultInfo.EventID;
                        qcTimeRecord.EventName = resultInfo.EventName;
                        qcTimeRecord.EventTime = resultInfo.EventTime;
                        qcTimeRecord.PatientID = item.PATIENT_ID;
                        qcTimeRecord.PatientName = item.PATIENT_NAME;
                        qcTimeRecord.Point = resultInfo.QCScore;
                        qcTimeRecord.DischargeTime = item.DISCHARGE_TIME;
                        qcTimeRecord.QcExplain = resultInfo.ResultDesc;
                        qcTimeRecord.IsVeto = resultInfo.IsVeto;
                        if (resultInfo.WrittenState == WrittenState.Early)
                            qcTimeRecord.QcResult = SystemData.WrittenState.Early;
                        if (resultInfo.WrittenState == WrittenState.Normal)
                            qcTimeRecord.QcResult = SystemData.WrittenState.Normal;
                        if (resultInfo.WrittenState == WrittenState.Timeout)
                            qcTimeRecord.QcResult = SystemData.WrittenState.Timeout;
                        if (resultInfo.WrittenState == WrittenState.Unwrite)
                        {
                            //根据海总需求，将未书写的文书分成两种状态：一种是未书写，另一种是正常未书写。第一种代表已经超时了，需要进行扣分。
                            if (resultInfo.EndTime < now)
                            {
                                //病历未书写超过截止时间，状态为未书写超时
                                qcTimeRecord.QcResult = SystemData.WrittenState.Unwrite;
                            }
                            else
                            {
                                qcTimeRecord.QcResult = SystemData.WrittenState.UnwriteNormal;
                            }
                        }
                        // qcTimeRecord.QcResult = SystemData.WrittenState.Unwrite;
                        qcTimeRecord.RecNo = "0"; //未做处理
                        qcTimeRecord.RecordTime = resultInfo.RecordTime;
                        qcTimeRecord.DocTime = resultInfo.DocTime;
                        qcTimeRecord.VisitID = resultInfo.VisitID;
                        if (!resultInfo.IsRepeat)
                        {
                            qcTimeRecord.QcExplain = string.Format("病人{0}{1},{2}内书写{3}"
                                , resultInfo.EventTime.ToString("yyyy-M-d HH:mm")
                                , resultInfo.EventName, resultInfo.WrittenPeriod, resultInfo.DocTypeName);
                        }
                        else
                        {
                            qcTimeRecord.QcExplain = string.Format("病人{0}{1},每{2}书写一次{3}"
                                , resultInfo.EventTime.ToString("yyyy-M-d HH:mm")
                                , resultInfo.EventName, resultInfo.WrittenPeriod, resultInfo.DocTypeName);
                        }

                        //判断是否已短信通知，海总需求：时效记录已存在的会写入个人统计表，进行短信通知，所以主键相同的已存数据将标记为短信通知，通过该字段避免写入统计到个人的表从而解决重复短信发送的问题。
                        if (lstExitQCTimeRecord != null && lstExitQCTimeRecord.Count > 0)
                        {
                            foreach (QcTimeRecord exitTimeRecord in lstExitQCTimeRecord)
                            {
                                //QCTimeRecord主键为PatientId,VisitID,DocTypeID,BeginDate,EndDate,QcResult,EventTime
                                if (exitTimeRecord.PatientID == qcTimeRecord.PatientID
                                    && exitTimeRecord.VisitID == qcTimeRecord.VisitID
                                    && exitTimeRecord.DocTypeID == qcTimeRecord.DocTypeID
                                    && exitTimeRecord.BeginDate == qcTimeRecord.BeginDate
                                    && exitTimeRecord.EndDate == qcTimeRecord.EndDate
                                    && exitTimeRecord.QcResult == qcTimeRecord.QcResult
                                    && exitTimeRecord.EventTime == qcTimeRecord.EventTime)
                                {
                                    //已存在的记录为当天的，则短信通知仍旧为未通知,主要是测试中会在当天运行两次以上
                                    //实际情况是每日只会运行一次
                                    if (qcTimeRecord.CheckDate.ToShortDateString() !=
                                        exitTimeRecord.CheckDate.ToShortDateString())
                                        qcTimeRecord.MessageNotify = true;
                                }
                            }
                        }
                        lstQcTimeRecord.Add(qcTimeRecord);
                    }
                    shRet = QcTimeRecordAccess.Instance.SavePatientQcTimeRecord(item.PATIENT_ID, item.VISIT_ID, lstQcTimeRecord);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        LogManager.Instance.WriteLog(string.Format("病人{0} 时效质控记录生成失败", item.PATIENT_NAME));
                        nError++;
                    }
                    iCurrIndex++;
                    string szMessage = string.Format("时效质控病案生成 {0}/{1}"
                        , iCurrIndex, lstPatVisitLog.Count);
                    ShowMessage(szMessage, iCurrIndex, CheckType.TimeCheck);
                    nSuccess++;
                }
                //执行成功后写入日志
                LogManager.Instance.WriteLog(string.Format("运行结束，本次执行成功数{0}，失败数{1}", nSuccess, nError), null,
                    LogType.Information);
                //保存统计到个人的时效结果
                shRet = QcTimeRecordAccess.Instance.SaveTimeRecordStatByPatient(now);


                if (shRet != SystemData.ReturnValue.OK)
                {
                    LogManager.Instance.WriteLog("统计到个人的结果时效性结果保存失败");
                }
                //保存统计到科室的时效结果 
                shRet = QcTimeRecordAccess.Instance.SaveTimeRecordStatByDept(now);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    LogManager.Instance.WriteLog("统计到科室的结果时效性结果保存失败");
                }
            }
            m_QCState = RunState.Normal;


            EndRun(iCurrIndex, CheckType.TimeCheck);
        }

        private void BugCheckGener()
        {
            if (!this.MainForm.ContentRecordRunning)
                return;
            int iCurrIndex = 0;
            LogManager.Instance.WriteLog(string.Format("{0} 执行内容检查记录生成", DateTime.Now), null, LogType.Information);
            List<EMRDBLib.MedDocInfo> lstDocInfos = null;
            int nDays = m_parent.DocContentDay;
            short shRet = EmrDocAccess.Instance.GetDocInfoByModifyTime(DateTime.Now,nDays, ref lstDocInfos);
            if (shRet != SystemData.ReturnValue.OK || lstDocInfos == null)
            {
                LogManager.Instance.WriteLog("未查询到昨天修改病历信息");
                m_BugState = RunState.Normal;
                return;
            }
            StartRun(lstDocInfos.Count, CheckType.BugCheck);
            //需设置父级控件
            Editor.Instance.ParentControl = Parent;
            for (int index = 0; index < lstDocInfos.Count; index++)
            {
                string szMessage = string.Format("内容质控病案生成 {0}/{1}"
                   , index + 1, lstDocInfos.Count);
                ShowMessage(szMessage, index + 1, CheckType.BugCheck);
                string szTextData = Editor.Instance.GetDocText(lstDocInfos[index]);
                if (string.IsNullOrEmpty(szTextData))
                    continue;
                //获取病人基本信息
                InitPatientInfo(lstDocInfos[index].PATIENT_ID, lstDocInfos[index].VISIT_ID);

                //初始化质控引擎
                if (m_bugCheckEngine == null)
                    m_bugCheckEngine = new BugCheckEngine();
                m_bugCheckEngine.UserInfo = GetUserInfo();
                m_bugCheckEngine.PatientInfo = GetPatientInfo(lstDocInfos[index].PATIENT_ID, lstDocInfos[index].VISIT_ID);
                m_bugCheckEngine.VisitInfo = GetVisitInfo(lstDocInfos[index].PATIENT_ID, lstDocInfos[index].VISIT_ID);
                m_bugCheckEngine.DocType = lstDocInfos[index].DOC_TITLE;
                m_bugCheckEngine.DocText = szTextData;
                //m_bugCheckEngine.SectionInfos = new List<DocumentSectionInfo>();
                shRet = m_bugCheckEngine.InitializeEngine();
                if (shRet != SystemData.ReturnValue.OK)
                {
                    LogManager.Instance.WriteLog(string.Format("{0} 病历质控引擎初始化失败,无法对病历进行自动质控！", DateTime.Now), null,
                        LogType.Information);
                    continue;
                }

                //检查文档内容缺陷
                List<DocuemntBugInfo> lstDocuemntBugList = null;
                if (shRet == SystemData.ReturnValue.OK)
                {
                    lstDocuemntBugList = m_bugCheckEngine.PerformBugCheck();
                    m_bugCheckEngine.DocText = null;
                }

                //检查文档元素缺陷
                List<ElementBugInfo> lstElementBugList = null;
                Editor.Instance.CheckElementBugs(lstDocInfos[index].EMR_TYPE, ref lstElementBugList);
                if ((lstDocuemntBugList == null || lstDocuemntBugList.Count <= 0)
                    && (lstElementBugList == null || lstElementBugList.Count <= 0))
                {
                    continue;
                }

                //如果存在DocID对应的则删除老数据
                QcContentRecordAccess.Instance.DeleteContentRecord(lstDocInfos[index].DOC_SETID);
                //保存Bug
                PatVisitInfo patVisitInfo =
                    m_ListPatVisitInfos.Find(
                        item =>
                            item.PATIENT_ID == lstDocInfos[index].PATIENT_ID && item.VISIT_ID == lstDocInfos[index].VISIT_ID);
                SaveContentRecord(patVisitInfo, lstDocInfos[index], lstDocuemntBugList, lstElementBugList);
            }

            m_BugState = RunState.Normal;
            EndRun(iCurrIndex, CheckType.BugCheck);
        }

        private void SaveContentRecord(PatVisitInfo patVisitInfo, MedDocInfo docInfo, List<DocuemntBugInfo> lstDocuemntBugList, List<ElementBugInfo> lstElementBugList)
        {
            if (patVisitInfo == null || docInfo == null)
                return;
            List<EMRDBLib.Entity.QcContentRecord> lstQcContentRecord = new List<EMRDBLib.Entity.QcContentRecord>();
            //内容错误赋值
            if (lstDocuemntBugList != null)
                foreach (var item in lstDocuemntBugList)
                {
                    QcContentRecord record = CreateQcContentRecord(patVisitInfo, docInfo);
                    record.BugClass = (int)item.BugLevel;
                    record.BugType = "1";
                    //去掉 （双击定位到缺陷）、（双击定位到错误）
                    record.QCExplain = item.BugDesc.Replace("（双击定位到缺陷）", "").Replace("（双击定位到错误）", "");
                   
                    lstQcContentRecord.Add(record);
                }
            //元素错误赋值
            if (lstElementBugList != null)
                foreach (var item in lstElementBugList)
                {
                    QcContentRecord record = CreateQcContentRecord(patVisitInfo, docInfo);
                    record.BugClass = item.IsFatalBug ? 1 : 0;
                    record.BugType = "2";
                    record.QCExplain = item.BugDesc;
                    lstQcContentRecord.Add(record);
                }
            //保存
            QcContentRecordAccess.Instance.SaveQCContentRecord(lstQcContentRecord);
        }

        /// <summary>
        /// 基本信息绑定
        /// </summary>
        /// <param name="patVisitInfo"></param>
        /// <param name="docInfo"></param>
        /// <returns></returns>
        private static QcContentRecord CreateQcContentRecord(PatVisitInfo patVisitInfo, EMRDBLib.MedDocInfo docInfo)
        {
            EMRDBLib.Entity.QcContentRecord record = new EMRDBLib.Entity.QcContentRecord();
            record.PatientID = patVisitInfo.PATIENT_ID;
            record.PatientName = patVisitInfo.PATIENT_NAME;
            record.VisitID = patVisitInfo.VISIT_ID;
            record.DocTypeID = docInfo.DOC_TYPE;
            record.Point = 0.0f;
            record.DocSetID = docInfo.DOC_SETID;
            record.DocTitle = docInfo.DOC_TITLE;
            record.ModifyTime = docInfo.MODIFY_TIME;
            record.BugCreateTime = DateTime.Now;
            record.CreateID = docInfo.CREATOR_ID;
            record.CreateName = docInfo.CREATOR_NAME;
            record.DocTime = docInfo.DOC_TIME;
            record.DocIncharge = patVisitInfo.INCHARGE_DOCTOR;
            record.DeptIncharge = patVisitInfo.DEPT_NAME;
            record.DeptCode = patVisitInfo.DEPT_CODE;
            return record;
        }

        //获取病人信息，保存到HashTable中
        private void InitPatientInfo(string patientId, string visitId)
        {
            if (m_ListPatVisitInfos == null)
                m_ListPatVisitInfos = new List<PatVisitInfo>();
            if (!m_ListPatVisitInfos.Exists(item => item.PATIENT_ID == patientId && item.VISIT_ID == visitId))
            {
                PatVisitInfo patVisitInfo = null;
                short shRet =PatVisitAccess.Instance.GetPatVisitInfo(patientId, visitId, ref patVisitInfo);
                if (shRet != SystemData.ReturnValue.OK || patVisitInfo == null)
                {
                    LogManager.Instance.WriteLog(string.Format("{0} 获取病人信息Pid:{1},Vid:{2}失败！", DateTime.Now, patientId, visitId), null,
                        LogType.Error);
                    return;
                }
                m_ListPatVisitInfos.Add(patVisitInfo);
            }
        }

        private VisitInfo GetVisitInfo(string patientId, string visitId)
        {
            if (m_ListPatVisitInfos == null)
                return null;
             PatVisitInfo patVisitInfo =
               m_ListPatVisitInfos.Find(item => item.PATIENT_ID == patientId && item.VISIT_ID == visitId);
            if (patVisitInfo == null)
                return null;
            VisitInfo clientVisitInfo = new VisitInfo();
            clientVisitInfo.ID = visitId;
            clientVisitInfo.InpID = patVisitInfo.INP_NO;
            clientVisitInfo.Time = patVisitInfo.VISIT_TIME;
            clientVisitInfo.WardCode = patVisitInfo.WARD_CODE;
            clientVisitInfo.WardName = patVisitInfo.WardName;
            clientVisitInfo.BedCode = patVisitInfo.BED_CODE;
            clientVisitInfo.Type = VisitType.IP;
            return clientVisitInfo;
        }

        private PatientInfo GetPatientInfo(string patientId, string visitId)
        {
             PatVisitInfo patVisitInfo =
                m_ListPatVisitInfos.Find(item => item.PATIENT_ID == patientId && item.VISIT_ID == visitId);
            if (patVisitInfo == null)
                return null;

            PatientInfo patInfo = new PatientInfo();
            patInfo.ID = patientId;
            patInfo.Name = patVisitInfo.PATIENT_NAME;
            patInfo.Gender = patVisitInfo.PATIENT_SEX;
            patInfo.BirthTime = patVisitInfo.BIRTH_TIME;
            return patInfo;
        }

        /// <summary>
        ///     生成系统数据
        /// </summary>
        /// <returns></returns>
        private UserInfo GetUserInfo()
        {
            UserInfo clientUserInfo = new UserInfo();
            clientUserInfo.ID = "System";
            clientUserInfo.Name = "System";
            return clientUserInfo;
        }

        /// <summary>
        ///     委托主线程显示当前操作进度信息
        /// </summary>
        /// <param name="info">显示的信息</param>
        private void ShowMessage(string info, int index, string szCheckType)
        {
            if (m_parent == null || m_parent.IsDisposed)
                return;
            try
            {
                ShowMessageHandler handler = m_parent.ShowStatusMessage;
                m_parent.Invoke(handler, index, info, szCheckType);
            }
            catch
            {
            }
        }

        /// <summary>
        ///     开始运行初始化主线程进度条参数
        /// </summary>
        /// <param name="info">显示的信息</param>
        private void StartRun(int nPatCount, string szChectType)
        {
            if (m_parent == null || m_parent.IsDisposed)
                return;
            try
            {
                RunHandler handler = m_parent.HandStartRun;
                m_parent.Invoke(handler, nPatCount, szChectType);
            }
            catch
            {
            }
        }

        /// <summary>
        ///     通知主线程操作已结束运行
        /// </summary>
        /// <param name="info">显示的信息</param>
        private void EndRun(int nPatCount, string szCheckType)
        {
            if (m_parent == null || m_parent.IsDisposed)
                return;
            try
            {
                RunHandler handler = m_parent.EndStartRun;
                m_parent.Invoke(handler, nPatCount, szCheckType);
            }
            catch
            {
            }
        }

        private delegate void ShowMessageHandler(int index, string info, string szCheckType);

        private delegate void RunHandler(int nPatCount, string szCheckType);

        #region"主状态条初始化"

        private ToolStripStatusLabel statuslblSystemInfo;
        private ToolStripStatusLabel statuslblTime;
        private IContainer components;
        private Timer CommonTimer;

        private void InitializeComponent()
        {
            components = new Container();
            statuslblSystemInfo = new ToolStripStatusLabel();
            statuslblTime = new ToolStripStatusLabel();
            CommonTimer = new Timer(components);
            SuspendLayout();
            // 
            // statuslblSystemInfo
            // 
            statuslblSystemInfo.Name = "statuslblSystemInfo";
            statuslblSystemInfo.Size = new Size(608, 17);
            statuslblSystemInfo.Spring = true;
            statuslblSystemInfo.Text = "就绪";
            statuslblSystemInfo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statuslblTime
            // 
            statuslblTime.AutoSize = false;
            statuslblTime.Name = "statuslblTime";
            statuslblTime.Size = new Size(200, 17);
            statuslblTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CommonTimer
            // 
            CommonTimer.Enabled = true;
            CommonTimer.Interval = 500;
            CommonTimer.Tick += CommonTick_Tick;
            // 
            // MainStatusStrip
            // 
            Items.AddRange(new ToolStripItem[]
            {
                statuslblSystemInfo,
                statuslblTime
            });
            Location = new Point(0, 498);
            Size = new Size(823, 22);
            ResumeLayout(false);
        }

        #endregion
    }
}