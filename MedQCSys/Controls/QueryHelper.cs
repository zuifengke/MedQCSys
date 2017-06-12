using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using Heren.Common.Libraries;
using MedQCSys.DockForms;
 
using EMRDBLib.DbAccess;
using EMRDBLib;

namespace MedQCSys.Utility
{
    internal class QueryHelper
    {
        /// <summary>
        /// 存放线程列表
        /// </summary>
        private ArrayList m_ThrdList;

        private PatientListForm m_PatientListForm;
        /// <summary>
        /// 获取或设置患者列表检索窗口
        /// </summary>
        public PatientListForm PatientListForm
        {
            get { return this.m_PatientListForm; }
            set { this.m_PatientListForm = value; }
        }

        private static QueryHelper m_Instance = null;
        /// <summary>
        /// 检索患者列表单实例
        /// </summary>
        public static QueryHelper Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QueryHelper();
                return m_Instance;
            }
        }

        /// <summary>
        /// 是否有线程需要启动执行
        /// </summary>
        /// <returns></returns>
        internal bool IsHaveProgressStart()
        {
            if (this.m_ThrdList == null)
                this.m_ThrdList = new ArrayList();
            bool bResut = false;
            SearchThread searchThread = null;
            for (int nIndex = 0; nIndex < this.m_ThrdList.Count; nIndex++)
            {
                searchThread = this.m_ThrdList[nIndex] as SearchThread;
                if (searchThread == null)
                    continue;
                if (searchThread.ThreadState == EMRDBLib.SearchThreadState.running
                    || searchThread.ThreadState == EMRDBLib.SearchThreadState.ready)
                {
                    bResut = true;
                    break;
                }
            }
            return bResut;
        }

        /// <summary>
        /// 所有线程是否已经完成执行
        /// </summary>
        /// <returns></returns>
        internal bool IsFinishProgress()
        {
            if (this.m_ThrdList == null)
                return true;
            SearchThread st = default(SearchThread);
            int nIndex = 0;
            for (nIndex = 0; nIndex < this.m_ThrdList.Count; nIndex += 1)
            {
                st = this.m_ThrdList[nIndex] as SearchThread;
                if (st == null)
                    continue;
                if (st.ThreadState != EMRDBLib.SearchThreadState.finished)
                    return false;
            }
            return true;
        }

        /// <summary>
        ///启动检索线程(启动下一个未启动的线程)
        /// </summary>
        internal bool StartNextThread()
        {
            if (this.m_ThrdList == null)
                return false;

            bool bResult = false;
            SearchThread startThread = new SearchThread();
            for (int nIndex = 0; nIndex < this.m_ThrdList.Count; nIndex++)
            {
                startThread = this.m_ThrdList[nIndex] as SearchThread;
                if (startThread == null)
                    continue;
                if (startThread.ThreadState != EMRDBLib.SearchThreadState.ready)
                    continue;

                bResult = true;
                Thread thread = null;
                try
                {
                    thread = new Thread(new ThreadStart(startThread.PatSearchCondition.SearchPatInfos));
                    thread.Name = startThread.Name;
                    startThread.Thread = thread;
                    thread.Start();
                    return bResult;
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteLog("检索数据时出错！", ex, LogType.Warning);
                    bResult = false;
                    break;
                }
            }
            return bResult;
        }

        /// <summary>
        /// 根据线程名称获取线程对象
        /// </summary>
        /// <param name="szTreadName">线程名称</param>
        /// <returns>线程对象</returns>
        internal SearchThread Item(string szTreadName)
        {
            if (this.m_ThrdList == null)
                return null;
            SearchThread searchThread = null;
            SearchThread temp = new SearchThread();
            int i = 0;
            while (i < this.m_ThrdList.Count)
            {
                temp = (SearchThread)this.m_ThrdList[i];
                if (temp == null)
                    continue;
                if (temp.Name == szTreadName)
                    searchThread = temp;
                System.Math.Min(Interlocked.Increment(ref i), i - 1);
            }
            return searchThread;
        }

        /// <summary>
        /// 终止线程检索数据
        /// </summary>
        public short StopThreadsWork()
        {
            if (this.m_ThrdList == null || this.m_ThrdList.Count <= 0)
                return SystemData.ReturnValue.OK;

            if (this.IsHaveProgressStart())
            {
                int nCount = this.m_ThrdList.Count;
                for (int nIndex = 0; nIndex < nCount; nIndex++)
                {
                    SearchThread searchThread = (SearchThread)this.m_ThrdList[nIndex];
                    if (searchThread.ThreadState != EMRDBLib.SearchThreadState.running)
                    {
                        searchThread.ThreadState = EMRDBLib.SearchThreadState.cancelled;
                        continue;
                    }
                    Thread thread = null;
                    try
                    {
                        thread = searchThread.Thread;
                        if ((thread != null)) thread.Abort();
                    }
                    catch (Exception ex)
                    {
                        LogManager.Instance.WriteLog("线程执行出现异常", ex, LogType.Error);
                        return SystemData.ReturnValue.FAILED;
                    }
                }
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 检索符合条件的患者就诊信息
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="patientType">患者列表检索方式</param>
        /// <param name="dtBeginTime">起始时间</param>
        /// <param name="dtEndTime">截止时间</param>
        /// <param name="patientListForm">患者列表窗口</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short ExecuteSearch(string szDeptCode, EMRDBLib.PatientType patientType, DateTime dtBeginTime, DateTime dtEndTime
            , PatientListForm patientListForm, EMRDBLib.PatSearchType SearchType, string szOperationCode,MDSDBLib.DocTypeInfo docTypeInfo)
        {
            if (patientListForm == null || patientListForm.IsDisposed)
                return SystemData.ReturnValue.FAILED;

            if (this.StopThreadsWork() != SystemData.ReturnValue.OK)
                return SystemData.ReturnValue.FAILED;

            if (this.m_ThrdList != null && this.m_ThrdList.Count > 0)
                this.m_ThrdList.Clear();

            while (dtBeginTime.AddDays(30) < dtEndTime)
            {
                this.AddSearchThread(szDeptCode, dtBeginTime, dtBeginTime.AddDays(30), patientType, patientListForm, SearchType, szOperationCode, docTypeInfo);
                dtBeginTime = dtBeginTime.AddDays(31);
            }
            if (dtBeginTime < dtEndTime)
                this.AddSearchThread(szDeptCode, dtBeginTime, dtEndTime, patientType, patientListForm, SearchType, szOperationCode, docTypeInfo);
            this.StartNextThread();
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 将线程添加到线程池中
        /// </summary>
        /// <param name="szDeptCode">科室代码</param>
        /// <param name="dtBeginTime">查询起始时间</param>
        /// <param name="dtEndTime">查询截止时间</param>
        /// <param name="patientType">检索方式</param>
        /// <param name="patientListForm">患者列表检索窗口</param>
        /// <param name="patSearchType">患者质控方式</param>
        private void AddSearchThread(string szDeptCode, DateTime dtBeginTime, DateTime dtEndTime, EMRDBLib.PatientType patientType
            , PatientListForm patientListForm, EMRDBLib.PatSearchType patSearchType, string szOperationCode ,MDSDBLib.DocTypeInfo docTypeInfo)
        {
            if (this.m_ThrdList == null)
                this.m_ThrdList = new ArrayList();
            string szThreadName = "Thread" + (this.m_ThrdList.Count + 1).ToString();
            dtEndTime = DateTime.Parse(dtEndTime.ToString("yyyy-M-d 23:59:59"));
            PatSearchCondition searchConditon = new PatSearchCondition(szThreadName, szDeptCode, patientListForm, dtBeginTime, dtEndTime
                , patientType, patSearchType, szOperationCode, docTypeInfo);
            SearchThread searchThread = new SearchThread();
            searchThread.Name = szThreadName;
            searchThread.Thread = null;
            searchThread.ThreadState = EMRDBLib.SearchThreadState.ready;
            searchThread.PatSearchCondition = searchConditon;
            this.m_ThrdList.Add(searchThread);
        }
    }

    /// <summary>
    /// 查询线程类
    /// </summary>
    public class SearchThread
    {
        private string m_szName = string.Empty;
        private Thread m_Thread = null;
        private EMRDBLib.SearchThreadState m_State = EMRDBLib.SearchThreadState.ready;
        private PatSearchCondition m_PatSearchCondition = null;

        /// <summary>
        /// 获取或设置线程名称
        /// </summary>
        public string Name
        {
            get { return this.m_szName; }
            set { this.m_szName = value; }
        }

        /// <summary>
        /// 获取或设置线程对象
        /// </summary>
        public Thread Thread
        {
            get { return this.m_Thread; }
            set { this.m_Thread = value; }
        }

        /// <summary>
        /// 获取或设置线程状态
        /// </summary>
        public EMRDBLib.SearchThreadState ThreadState
        {
            get { return this.m_State; }
            set { this.m_State = value; }
        }

        /// <summary>
        /// 获取或设置患者列表检索条件
        /// </summary>
        public PatSearchCondition PatSearchCondition
        {
            get { return this.m_PatSearchCondition; }
            set { this.m_PatSearchCondition = value; }
        }
    }

    /// <summary>
    /// 患者列表检索条件
    /// </summary>
    public class PatSearchCondition
    {
        private string m_szThreadName = null;
        /// <summary>
        /// 获取或设置线程名称
        /// </summary>
        public string ThreadName
        {
            get { return this.m_szThreadName; }
            set { this.m_szThreadName = value; }
        }

        private PatientListForm m_PatientListForm = null;
        /// <summary>
        /// 获取或设置患者列表窗口
        /// </summary>
        public PatientListForm PatientListForm
        {
            get { return this.m_PatientListForm; }
            set { this.m_PatientListForm = value; }
        }

        private string m_szDeptCode = string.Empty;
        /// <summary>
        /// 获取或设置检索的科室代码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }

        private DateTime m_dtBeginTime = DateTime.MinValue;
        /// <summary>
        /// 获取或设置检索起始时间
        /// </summary>
        public DateTime BeginTime
        {
            get { return this.m_dtBeginTime; }
            set { this.m_dtBeginTime = value; }
        }

        private DateTime m_dtEndTime = DateTime.MinValue;
        /// <summary>
        ///  获取或设置检索截止时间
        /// </summary>
        public DateTime EndTime
        {
            get { return this.m_dtEndTime; }
            set { this.m_dtEndTime = value; }
        }

        private EMRDBLib.PatSearchType m_PatSearchType = EMRDBLib.PatSearchType.Department;
        /// <summary>
        /// 获取或设置患者质控方式
        /// </summary>
        public EMRDBLib.PatSearchType PatSearchType
        {
            get { return this.m_PatSearchType; }
            set { this.m_PatSearchType = value; }
        }

        private EMRDBLib.PatientType m_PatientType = EMRDBLib.PatientType.PatInHosptial;
        /// <summary>
        /// 获取或设置患者列表检索方式
        /// </summary>
        public EMRDBLib.PatientType PatientType
        {
            get { return this.m_PatientType; }
            set { this.m_PatientType = value; }
        }

        private string m_szOperationCode = string.Empty;
        /// <summary>
        /// 获取或设置手术操作代码
        /// </summary>
        public string OperationCode
        {
            get { return this.m_szOperationCode; }
            set { this.m_szOperationCode = value; }
        }

        private MDSDBLib.DocTypeInfo m_DocType = null;
        /// <summary>
        /// 获取上次的文档类型
        /// </summary>
        public MDSDBLib.DocTypeInfo DocType
        {
            get { return this.m_DocType; }
            set { this.m_DocType = value; }
        }


        public PatSearchCondition(string szThrdName, string szDeptCode, PatientListForm patientListForm, DateTime dtBeginTime
            , DateTime dtEndTime, EMRDBLib.PatientType patientType, EMRDBLib.PatSearchType patSearchType, string szOperationCode,MDSDBLib.DocTypeInfo docTypeInfo)
        {
            this.m_szDeptCode = szDeptCode;
            this.m_szThreadName = szThrdName;
            this.m_PatientListForm = patientListForm;
            this.m_dtBeginTime = dtBeginTime;
            this.m_dtEndTime = dtEndTime;
            this.m_PatientType = patientType;
            this.m_PatSearchType = patSearchType;
            this.m_szOperationCode = szOperationCode;
            this.m_DocType = docTypeInfo;
        }

        public void SearchPatInfos()
        {
            PatientListForm.UpdateThreadState OnUpdateThreadState = null;
            try
            {
                string szDeptCode = null;
                List<EMRDBLib.PatVisitInfo> lstPatVisitLog = null;
                if (this.m_PatSearchType == EMRDBLib.PatSearchType.Department)
                    PatVisitAccess.Instance.GetPatVisitList(this.m_szDeptCode, this.m_PatientType, this.m_dtBeginTime, this.m_dtEndTime, ref lstPatVisitLog);
                else if (this.m_PatSearchType == EMRDBLib.PatSearchType.Admission)
                    PatVisitAccess.Instance.GetPatsListByAdmTime(this.m_dtBeginTime, this.m_dtEndTime, this.m_PatientType, szDeptCode, ref lstPatVisitLog);
                else if (this.m_PatSearchType == EMRDBLib.PatSearchType.Death)
                    PatVisitAccess.Instance.GetPatsListByDeadTime(this.m_dtBeginTime, this.m_dtEndTime, szDeptCode, ref lstPatVisitLog);
                else if (this.m_PatSearchType == EMRDBLib.PatSearchType.Discharge)
                    PatVisitAccess.Instance.GetPatientListByDisChargeTime(this.m_dtBeginTime, this.m_dtEndTime, szDeptCode, ref lstPatVisitLog);
                else if (this.m_PatSearchType == EMRDBLib.PatSearchType.SeriousAndCritical)
                  InpVisitAccess.Instance.GetPatsListBySerious(this.m_dtBeginTime, this.m_dtEndTime, szDeptCode, ref lstPatVisitLog);
                else if (this.m_PatSearchType == EMRDBLib.PatSearchType.OperationPatient)
                    PatVisitAccess.Instance.GetPatListByOperation(this.m_szDeptCode, this.m_PatientType, this.m_dtBeginTime, this.m_dtEndTime, this.m_szOperationCode
                        , ref lstPatVisitLog);
                else if (this.m_PatSearchType == EMRDBLib.PatSearchType.DocType)
                    EmrDocAccess.Instance.GetPatListByDocTypeAndDocTime(this.DocType.DocTypeID, this.m_dtBeginTime, this.m_dtEndTime, ref lstPatVisitLog);
                OnUpdateThreadState = new PatientListForm.UpdateThreadState(this.PatientListForm.OnUpdateThreadState);
                this.m_PatientListForm.Invoke(OnUpdateThreadState, new object[] { this.m_szThreadName, lstPatVisitLog, EMRDBLib.SearchThreadState.finished });
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatSearchCondition.SearchPatInfos", ex);
            }
        }
    }
}
