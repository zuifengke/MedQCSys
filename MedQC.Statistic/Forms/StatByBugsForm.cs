// ***********************************************************
// 病案质控系统检查问题清单窗口.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;
using Heren.Common.Report;
using Heren.Common.VectorEditor;

using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Statistic
{
    public partial class StatByBugsForm : DockContentBase
    {
        public StatByBugsForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new System.Drawing.Font("宋体", 10.5f);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!SystemParam.Instance.LocalConfigOption.IsOpenHospitalTimeCheck)
            {
                this.chkContentCheck.Visible = false;
                this.chkTimeCheck.Visible = false;
            }
            this.dtpStatTimeEnd.Value = DateTime.Now;
            this.dtpStatTimeBegin.Value = DateTime.Now.AddDays(-1);
        }

        public override void OnRefreshView()
        {
            this.Update();
            this.ShowStatusMessage("正在下载临床科室列表，请稍候...");
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.Show("下载科室列表失败");
            }
            this.ShowStatusMessage(null);
        }

        /// <summary>
        /// 加载打印模板
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "检查问题清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("检查问题清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("检查问题清单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

        private ReportExplorerForm GetReportExplorerForm()
        {
            ReportExplorerForm reportExplorerForm = new ReportExplorerForm();
            reportExplorerForm.WindowState = FormWindowState.Maximized;
            reportExplorerForm.QueryContext +=
                new QueryContextEventHandler(this.ReportExplorerForm_QueryContext);
            reportExplorerForm.NotifyNextReport +=
                new NotifyNextReportEventHandler(this.ReportExplorerForm_NotifyNextReport);
            return reportExplorerForm;
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "所在科室")
            {
                string szDeptName = null;
                if (!string.IsNullOrEmpty(this.cboDeptName.Text.Trim()))
                    szDeptName = this.cboDeptName.Text;
                else
                    szDeptName = "全院";
                value = szDeptName;
                return true;
            }
            if (name == "起始日期")
            {
                value = this.dtpStatTimeBegin.Value;
                return true;
            }
            if (name == "截止日期")
            {
                value = this.dtpStatTimeEnd.Value;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 用于缓存按照科室、问题分组的问题类型
        /// </summary>
        private List<EMRDBLib.MedicalQcMsg> M_lstQCQuestionInfosOrderByDeptBugs = null;
        /// <summary>
        /// 用于缓存按照科室、患者姓名分组的问题类型
        /// </summary>
        private List<EMRDBLib.MedicalQcMsg> M_lstQCQuestionInfosOrderByDeptPatNames = null;
        private void btnQuery_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在统计病历反馈问题，请稍候...");
            this.dataGridView1.Rows.Clear();
            DeptInfo deptInfo = this.cboDeptName.SelectedItem as DeptInfo;
            string szDeptCode = null;
            if (deptInfo != null)
                szDeptCode = deptInfo.DEPT_CODE;
            if (string.IsNullOrEmpty(this.cboDeptName.Text))
                szDeptCode = null;
            string szMsgState =string.Empty;
            if (!string.IsNullOrEmpty(this.cboMsgStatus.Text))
                szMsgState = SystemData.MsgStatus.GetMsgStateCode(this.cboMsgStatus.Text).ToString();
            List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfos = null;
            short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgList(szDeptCode, szMsgState,
                DateTime.Parse(dtpStatTimeBegin.Value.ToString("yyyy-M-d 00:00:00")),
                DateTime.Parse(dtpStatTimeEnd.Value.ToString("yyyy-M-d 23:59:59")), ref lstQCQuestionInfos);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("查询数据失败！");
                return;
            }
            if (lstQCQuestionInfos == null)
                lstQCQuestionInfos = new List<EMRDBLib.MedicalQcMsg>();
            if (this.chkTimeCheck.Checked)
                JoinTimeCheck(lstQCQuestionInfos);
            if (this.chkContentCheck.Checked)
                JoinContentBugsCheck(lstQCQuestionInfos);
            lstQCQuestionInfos.Sort(CompareDinosByDeptCode);
            //查询，清空按照科室、患者姓名的数据
            //缓存根据科室、问题类型分组的数据
            M_lstQCQuestionInfosOrderByDeptBugs = lstQCQuestionInfos;
            M_lstQCQuestionInfosOrderByDeptPatNames = null;
            if (SystemParam.Instance.LocalConfigOption.ShowBugListMode == "3")
            {
                ShowAsNormalBugs(lstQCQuestionInfos);
            }
            else
                ShowAsDeptBugs(lstQCQuestionInfos);
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 南总显示格式
        /// </summary>
        /// <param name="lstQCQuestionInfos"></param>
        private void ShowAsNormalBugs(List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfos)
        {
            for (int index = 0; index < lstQCQuestionInfos.Count; index++)
            {
                EMRDBLib.MedicalQcMsg qcQuestionInfo = lstQCQuestionInfos[index];
                int nRowIndex = 0;
                string szQuestionCount = null;
                nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow parentRow = this.dataGridView1.Rows[nRowIndex];
                parentRow.Cells[this.colDeptName.Index].Value = qcQuestionInfo.DEPT_NAME;
                parentRow.Cells[this.colQuestionType.Index].Value = qcQuestionInfo.QA_EVENT_TYPE;
                parentRow.Cells[this.colQuestionCount.Index].Value = szQuestionCount;
                this.SetRowData(parentRow, qcQuestionInfo);
            }
        }
        /// <summary>
        /// 按照科室问题类型分组显示
        /// </summary>
        /// <param name="lstQCQuestionInfos"></param>
        private void ShowAsDeptBugs(List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfos)
        {
            if (lstQCQuestionInfos == null || lstQCQuestionInfos.Count == 0)
                return;
            this.dataGridView1.Rows.Clear();
            string szDeptName = null;
            string szQuestionType = null;
            int nQuestionCount = 0;
            string szKey = null;
            Hashtable htQuestionInfos = new Hashtable();
            //统计病历份数ht
            Hashtable htPidVid = new Hashtable();
            for (int index = 0; index < lstQCQuestionInfos.Count; index++)
            {
                EMRDBLib.MedicalQcMsg qcQuestionInfo = lstQCQuestionInfos[index];
                if (qcQuestionInfo.DEPT_NAME != szDeptName)
                    szDeptName = qcQuestionInfo.DEPT_NAME;
                if (qcQuestionInfo.QA_EVENT_TYPE != szQuestionType)
                    szQuestionType = qcQuestionInfo.QA_EVENT_TYPE;
                if (szKey == null)
                {
                    szKey = szDeptName + szQuestionType;
                    nQuestionCount++;
                }
                else if (szKey == (szDeptName + szQuestionType))
                {
                    nQuestionCount++;
                }
                else
                {
                    if (!htQuestionInfos.ContainsKey(szKey))
                        htQuestionInfos.Add(szKey, nQuestionCount);
                    szKey = szDeptName + szQuestionType;
                    nQuestionCount = 1;
                }
                if (index == lstQCQuestionInfos.Count - 1 && !htQuestionInfos.ContainsKey(szKey))
                    htQuestionInfos.Add(szKey, nQuestionCount);
                if (!htPidVid.ContainsKey(lstQCQuestionInfos[index].PATIENT_ID + lstQCQuestionInfos[index].VISIT_ID))
                    htPidVid.Add(lstQCQuestionInfos[index].PATIENT_ID + lstQCQuestionInfos[index].VISIT_ID, lstQCQuestionInfos[index].PATIENT_ID + lstQCQuestionInfos[index].VISIT_ID);
            }
            szKey = null;
            for (int index = 0; index < lstQCQuestionInfos.Count; index++)
            {
                EMRDBLib.MedicalQcMsg qcQuestionInfo = lstQCQuestionInfos[index];
                int nRowIndex = 0;
                if (szKey != (qcQuestionInfo.DEPT_NAME + qcQuestionInfo.QA_EVENT_TYPE))
                {
                    szKey = qcQuestionInfo.DEPT_NAME + qcQuestionInfo.QA_EVENT_TYPE;
                    string szQuestionCount = null;
                    if (htQuestionInfos.Contains(szKey))
                        szQuestionCount = htQuestionInfos[szKey].ToString();
                    nRowIndex = this.dataGridView1.Rows.Add();
                    DataGridViewRow parentRow = this.dataGridView1.Rows[nRowIndex];
                    parentRow.Cells[this.colDeptName.Index].Value = qcQuestionInfo.DEPT_NAME;
                    parentRow.Cells[this.colQuestionType.Index].Value = qcQuestionInfo.QA_EVENT_TYPE;
                    parentRow.Cells[this.colQuestionCount.Index].Value = szQuestionCount;
                    parentRow.DefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
                }
                nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow childRow = this.dataGridView1.Rows[nRowIndex];
                this.SetRowData(childRow, qcQuestionInfo);
            }
            int nIndex = this.dataGridView1.Rows.Add();
            DataGridViewRow row = this.dataGridView1.Rows[nIndex];
            row.Cells[this.colDeptName.Index].Value = "合计";
            row.Cells[1].Value = "检查例数：";
            row.Cells[2].Value = lstQCQuestionInfos.Count;
            row.Cells[4].Value = "病历份数：";
            row.Cells[5].Value = htPidVid.Count;
            row.DefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            Hashtable htNoExportColunms = new Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "检查问题清单");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可打印内容！", MessageBoxIcon.Information);
                return;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            byte[] byteReportData = this.GetReportFileData(null);
            if (byteReportData != null)
            {
                System.Data.DataTable table = GlobalMethods.Table.GetDataTable(this.dataGridView1, false, 0);
                ReportExplorerForm explorerForm = this.GetReportExplorerForm();
                explorerForm.ReportFileData = byteReportData;
                explorerForm.ReportParamData.Add("是否续打", false);
                explorerForm.ReportParamData.Add("打印数据", table);
                explorerForm.ShowDialog();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ReportExplorerForm_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = this.GetSystemContext(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private void ReportExplorerForm_NotifyNextReport(object sender, Heren.Common.Report.NotifyNextReportEventArgs e)
        {
            e.ReportData = this.GetReportFileData(e.ReportName);
        }

        /// <summary>
        /// 将数据信息加载到DataGridView中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="qcQuestionInfo"></param>
        private void SetRowData(DataGridViewRow row, EMRDBLib.MedicalQcMsg qcQuestionInfo)
        {
            if (row == null || qcQuestionInfo == null)
                return;
            if (row.DataGridView == null)
                return;
            if (IsNeedShowSamePatientColumn(row.Index, qcQuestionInfo))
            {
                row.Cells[this.colPatientID.Index].Value = qcQuestionInfo.PATIENT_ID;
                row.Cells[this.colVisitID.Index].Value = qcQuestionInfo.VISIT_ID;
                row.Cells[this.colPatientName.Index].Value = qcQuestionInfo.PATIENT_NAME;
            }

            row.Cells[this.colQuestionContent.Index].Value = qcQuestionInfo.MESSAGE;
            row.Cells[this.colDoctorInCharege.Index].Value = qcQuestionInfo.DOCTOR_IN_CHARGE;
            row.Cells[this.colPARENT_DOCTOR.Index].Value = qcQuestionInfo.PARENT_DOCTOR;

            //显示权限改到质控权限控制
            //if (SystemConfig.Instance.Get(SystemData.ConfigKey.STAT_SHOW_CHECKER_NAME, false))
            if (qcQuestionInfo.ISSUED_BY == "系统自动")
            {
                row.Cells[this.colCheckName.Index].Value = qcQuestionInfo.ISSUED_BY;
            }
            else
            {
                if (qcQuestionInfo.ISSUED_BY == SystemParam.Instance.UserInfo.USER_NAME)
                    row.Cells[this.colCheckName.Index].Value = qcQuestionInfo.ISSUED_BY;
            }

            row.Cells[this.colQuestionCount.Index].Value = "1";
            row.Cells[this.colQuestionType.Index].Value = qcQuestionInfo.QA_EVENT_TYPE;
            if (qcQuestionInfo.ISSUED_DATE_TIME != qcQuestionInfo.DefaultTime)
                row.Cells[this.colCheckTime.Index].Value = qcQuestionInfo.ISSUED_DATE_TIME.ToString("yyyy-MM-dd HH:mm");
            if (qcQuestionInfo.ASK_DATE_TIME != qcQuestionInfo.DefaultTime)
                row.Cells[this.colConfirmDate.Index].Value = qcQuestionInfo.ASK_DATE_TIME.ToString("yyyy-MM-dd");
            row.Cells[this.colQuestionStatus.Index].Value = SystemData.MsgStatus.GetCnMsgState(qcQuestionInfo.MSG_STATUS);
            row.Tag = qcQuestionInfo;
        }

        /// <summary>
        /// 是否需要显示同一患者的相同列
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool IsNeedShowSamePatientColumn(int rowIndex, MedicalQcMsg currentQCQuestionInfo)
        {
            if (SystemParam.Instance.LocalConfigOption.IsShowSameColumn)
            {
                return true;
            }
            else//判断是否是同一个患者，是则不需要显示
            {
                if (rowIndex == 0 || currentQCQuestionInfo == null)
                    return true;
                MedicalQcMsg preQCQuestionInfo = this.dataGridView1.Rows[rowIndex - 1].Tag as MedicalQcMsg;
                if (preQCQuestionInfo == null)
                    return true;
                if (preQCQuestionInfo.PATIENT_ID == currentQCQuestionInfo.PATIENT_ID
                    && preQCQuestionInfo.VISIT_ID == currentQCQuestionInfo.VISIT_ID)
                    return false;
                else
                    return true;
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == this.colPatientName.Index)
            {
                ShowAsDeptPatNames(M_lstQCQuestionInfosOrderByDeptPatNames);
            }
            else if (e.ColumnIndex == this.colQuestionType.Index)
            {
                ShowAsDeptBugs(M_lstQCQuestionInfosOrderByDeptBugs);
            }
        }

        /// <summary>
        /// 按照科室、患者姓名分组显示
        /// </summary>
        /// <param name="M_lstQCQuestionInfosOrderByDeptPatNames"></param>
        private void ShowAsDeptPatNames(List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfos)
        {
            if (lstQCQuestionInfos == null || lstQCQuestionInfos.Count == 0)
            {
                this.ShowStatusMessage("正在统计病历反馈问题，请稍候...");
                this.dataGridView1.Rows.Clear();
                DeptInfo deptInfo = this.cboDeptName.SelectedItem as DeptInfo;
                string szDeptCode = null;
                if (deptInfo != null)
                    szDeptCode = deptInfo.DEPT_CODE;
                if (string.IsNullOrEmpty(this.cboDeptName.Text))
                    szDeptCode = null;
                lstQCQuestionInfos = null;
                short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgList(szDeptCode, dtpStatTimeBegin.Value.Date,
                dtpStatTimeEnd.Value.Date.AddDays(1).AddSeconds(-1), ref lstQCQuestionInfos);
                if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    MessageBoxEx.Show("查询数据失败！");
                    return;
                }
                if (lstQCQuestionInfos == null || lstQCQuestionInfos.Count <= 0)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    MessageBoxEx.Show("没有符合条件的数据！", MessageBoxIcon.Information);
                    return;
                }
                M_lstQCQuestionInfosOrderByDeptPatNames = lstQCQuestionInfos;
            }
            this.dataGridView1.Rows.Clear();
            int sum = 0;
            Hashtable hsTable = new Hashtable();
            for (int index = 0; index < lstQCQuestionInfos.Count; index++)
            {
                int rowIndex = this.dataGridView1.Rows.Add();
                sum++;
                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                this.SetRowData(row, lstQCQuestionInfos[index]);
                if (!hsTable.ContainsKey(lstQCQuestionInfos[index].DEPT_STAYED))
                {
                    hsTable.Add(lstQCQuestionInfos[index].DEPT_STAYED, lstQCQuestionInfos[index].DEPT_NAME);
                    row.Cells[this.colDeptName.Index].Value = lstQCQuestionInfos[index].DEPT_NAME;
                }
                if (index == lstQCQuestionInfos.Count - 1 || lstQCQuestionInfos[index].DEPT_STAYED != lstQCQuestionInfos[index + 1].DEPT_STAYED)
                {
                    rowIndex = this.dataGridView1.Rows.Add();
                    DataGridViewRow sumRow = this.dataGridView1.Rows[rowIndex];
                    sumRow.Cells[0].Value = "合计";
                    sumRow.Cells[5].Value = sum.ToString();
                    sumRow.DefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
                    sum = 0;
                }
            }
            int rIndex = this.dataGridView1.Rows.Add();
            DataGridViewRow CountRow = this.dataGridView1.Rows[rIndex];
            CountRow.Cells[0].Value = "总计";
            CountRow.Cells[5].Value = lstQCQuestionInfos.Count;
            CountRow.DefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
            this.ShowStatusMessage(null);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            EMRDBLib.MedicalQcMsg info = row.Tag as EMRDBLib.MedicalQcMsg;
            if (info == null)
                return;


            //切换当前患者
            PatVisitInfo patVisitLog = null;
            short shRet = PatVisitAccess.Instance.GetPatVisitInfo(info.PATIENT_ID, info.VISIT_ID, ref patVisitLog);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowError("患者信息查询失败！");
                return;
            }
            SystemParam.Instance.PatVisitInfo = patVisitLog;
            this.MainForm.OnPatientInfoChanged(EventArgs.Empty);
            //如果是系统自动检查，则将内容检查者设置为当前用户和检查时间为当前时间,代表质控已确认自动查出的问题
            if (!string.IsNullOrEmpty(info.TOPIC_ID)
                && info.ISSUED_BY == "系统自动")
            {
                UpdateQCContentRecord(info.TOPIC_ID);
            }
            if (!string.IsNullOrEmpty(info.TOPIC_ID))
            {
                this.MainForm.OpenDocument(info.TOPIC_ID, info.PATIENT_ID, info.VISIT_ID);
            }
        }
        //更新内容质检问题质检人和质检时间
        private void UpdateQCContentRecord(string szDocSetId)
        {
            if (string.IsNullOrEmpty(szDocSetId))
                return;
            string szUserID = SystemParam.Instance.UserInfo.USER_ID;
            string szUserName = SystemParam.Instance.UserInfo.USER_NAME;
            DateTime now = DateTime.Now;
            short shRet = QcContentRecordAccess.Instance.UpdateQCContentRecord(szDocSetId, szUserID, szUserName, now);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("更新内容质检问题失败！");
            }
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                EMRDBLib.MedicalQcMsg info = row.Tag as EMRDBLib.MedicalQcMsg;
                if (info == null)
                    continue;
                if (info.TOPIC_ID == szDocSetId)
                {
                    info.ISSUED_ID = szUserID;
                    info.ISSUED_BY = szUserName;
                    info.ISSUED_DATE_TIME = now;
                    row.Cells[this.colCheckName.Index].Value = info.ISSUED_BY;
                    row.Cells[this.colCheckTime.Index].Value = info.ISSUED_DATE_TIME;
                }
            }
        }
        /// <summary>
        /// 合并系统时效检查
        /// </summary>
        private void JoinTimeCheck(List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfo)
        {
            try
            {
                this.ShowStatusMessage("正在加载系统时效检查...");
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                DateTime dtBeginTime = DateTime.Parse(this.dtpStatTimeBegin.Value.ToShortDateString());
                DateTime dtEndTime = DateTime.Parse(this.dtpStatTimeEnd.Value.AddDays(1).ToShortDateString());
                DeptInfo deptInfo = this.cboDeptName.SelectedItem as DeptInfo;
                string szDeptCode = null;
                if (deptInfo != null && !string.IsNullOrEmpty(this.cboDeptName.Text))
                    szDeptCode = deptInfo.DEPT_CODE;
                List<EMRDBLib.QcTimeRecord> lstQcTimeRecord = null;
                string szTimeType = "CHECK_DATE";
                short shRet = QcTimeRecordAccess.Instance.GetQcTimeRecords(dtBeginTime, dtEndTime, szTimeType, "1,3", szDeptCode, ref lstQcTimeRecord);
                if (shRet != SystemData.ReturnValue.OK
                    || lstQcTimeRecord == null
                    || lstQcTimeRecord.Count <= 0)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
                if (lstQCQuestionInfo == null)
                    lstQCQuestionInfo = new List<EMRDBLib.MedicalQcMsg>();
                foreach (EMRDBLib.QcTimeRecord item in lstQcTimeRecord)
                {
                    EMRDBLib.MedicalQcMsg qcQuestionInfo = new EMRDBLib.MedicalQcMsg();
                    qcQuestionInfo.ISSUED_BY = item.CheckName;
                    qcQuestionInfo.ISSUED_DATE_TIME = item.EndDate;
                    qcQuestionInfo.DEPT_STAYED = item.DeptInCharge;
                    qcQuestionInfo.DEPT_NAME = item.DeptStayed;
                    string szQuestionContent = string.Empty;

                    if (item.QcResult == EMRDBLib.SystemData.WrittenState.Timeout)
                        szQuestionContent = EMRDBLib.SystemData.WrittenState.GetCnWrittenState(item.QcResult) + " 已超" + Math.Round((item.RecordTime - item.EndDate).TotalHours, 0, MidpointRounding.ToEven) + "小时" + " " + item.QcExplain;
                    else
                        szQuestionContent = EMRDBLib.SystemData.WrittenState.GetCnWrittenState(item.QcResult) + " " + item.QcExplain;
                    qcQuestionInfo.MESSAGE = szQuestionContent;
                    qcQuestionInfo.PATIENT_ID = item.PatientID;
                    qcQuestionInfo.VISIT_ID = item.VisitID;
                    qcQuestionInfo.PATIENT_NAME = item.PatientName;
                    qcQuestionInfo.QA_EVENT_TYPE = "时效要求";
                    qcQuestionInfo.DOCTOR_IN_CHARGE = item.DoctorInCharge;
                    lstQCQuestionInfo.Add(qcQuestionInfo);
                }


                GlobalMethods.UI.SetCursor(this, Cursors.Default);
            }
            catch (Exception ex)
            {
                MessageBoxEx.ShowError("问题清单加载时效记录失败", ex.ToString());
                LogManager.Instance.WriteLog("问题清单加载时效记录失败", ex);
            }
        }
        /// <summary>
        /// 合并系统内容缺陷检查
        /// </summary>
        private void JoinContentBugsCheck(List<EMRDBLib.MedicalQcMsg> lstQCQuestionInfo)
        {
            try
            {
                this.ShowStatusMessage("正在加载系统内容缺陷检查...");
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                DateTime dtBeginTime = DateTime.Parse(this.dtpStatTimeBegin.Value.ToShortDateString());
                DateTime dtEndTime = DateTime.Parse(this.dtpStatTimeEnd.Value.AddDays(1).ToShortDateString());
                DeptInfo deptInfo = this.cboDeptName.SelectedItem as DeptInfo;
                string szDeptCode = null;
                if (deptInfo != null && !string.IsNullOrEmpty(this.cboDeptName.Text))
                    szDeptCode = deptInfo.DEPT_CODE;
                List<EMRDBLib.Entity.QcContentRecord> lstQcContentRecord = null;
                short shRet = QcContentRecordAccess.Instance.GetQcContentRecord(dtBeginTime, dtEndTime, szDeptCode, ref lstQcContentRecord);
                if (shRet != SystemData.ReturnValue.OK
                    || lstQcContentRecord == null
                    || lstQcContentRecord.Count <= 0)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    return;
                }
                if (lstQCQuestionInfo == null)
                    lstQCQuestionInfo = new List<EMRDBLib.MedicalQcMsg>();
                foreach (EMRDBLib.Entity.QcContentRecord item in lstQcContentRecord)
                {
                    EMRDBLib.MedicalQcMsg qcQuestionInfo = new EMRDBLib.MedicalQcMsg();
                    if (string.IsNullOrEmpty(item.CheckerName))
                    {
                        qcQuestionInfo.ISSUED_BY = "系统自动";
                        qcQuestionInfo.ISSUED_DATE_TIME = item.BugCreateTime;

                    }
                    else
                    {
                        qcQuestionInfo.ISSUED_BY = item.CheckerName;
                        qcQuestionInfo.ISSUED_DATE_TIME = item.CheckDate;
                        qcQuestionInfo.ISSUED_ID = item.CheckerID;
                    }

                    qcQuestionInfo.DEPT_STAYED = item.DeptCode;
                    qcQuestionInfo.DEPT_NAME = item.DeptIncharge;
                    qcQuestionInfo.TOPIC_ID = item.DocSetID;
                    qcQuestionInfo.DOCTOR_IN_CHARGE = item.DocIncharge;
                    string szQuestionContent = string.Empty;
                    if (item.BugClass == 0)
                        szQuestionContent = string.Format("出现警告：{0}", item.QCExplain);
                    else
                        szQuestionContent = string.Format("出现错误：{0}", item.QCExplain);
                    qcQuestionInfo.MESSAGE = szQuestionContent;
                    qcQuestionInfo.PATIENT_ID = item.PatientID;
                    qcQuestionInfo.VISIT_ID = item.VisitID;
                    qcQuestionInfo.PATIENT_NAME = item.PatientName;
                    qcQuestionInfo.QA_EVENT_TYPE = string.Format("自动检查-{0}", item.DocTitle);
                    lstQCQuestionInfo.Add(qcQuestionInfo);
                }


                GlobalMethods.UI.SetCursor(this, Cursors.Default);
            }
            catch (Exception ex)
            {
                MessageBoxEx.ShowError("问题清单加载时效记录失败", ex.ToString());
                LogManager.Instance.WriteLog("问题清单加载时效记录失败", ex);
            }
        }
        private int CompareDinosByDeptCode(EMRDBLib.MedicalQcMsg x, EMRDBLib.MedicalQcMsg y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int retval = x.DEPT_STAYED.CompareTo(y.DEPT_STAYED);

                    if (retval != 0)
                    {
                        // If the strings are not of equal length,
                        // the longer string is greater.
                        //
                        return retval;
                    }
                    else
                    {
                        // If the strings are of equal length,
                        // sort them with ordinary string comparison.
                        //
                        //科室一样，按患者姓名比较
                        int retval2 = x.PATIENT_NAME.CompareTo(y.PATIENT_NAME);
                        if (retval2 != 0)
                        {
                            return retval2;
                        }
                        else
                            return x.QA_EVENT_TYPE.CompareTo(y.QA_EVENT_TYPE);
                    }
                }
            }
        }
    }
}