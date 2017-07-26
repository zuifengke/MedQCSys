// ***********************************************************
// 病案质控系统按质检问题统计窗口.
// Creator:LiChunYing  Date:2010-04-19
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
    public partial class StatByQuestionForm : DockContentBase
    {
        public StatByQuestionForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
            this.colPARENT_DOCTOR.Visible = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
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
            this.ShowStatusMessage("正在下载质量问题列表，请稍候...");
            List<EMRDBLib.QaEventTypeDict> lstQCEventTypes = null;
            short shRet = QaEventTypeDictAccess.Instance.GetQCEventTypeList(ref lstQCEventTypes);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("病案质量问题分类字典下载失败！");
                return;
            }
            if (lstQCEventTypes == null || lstQCEventTypes.Count <= 0)
            {
                this.ShowStatusMessage(null);
                return;
            }
            for (int index = 0; index < lstQCEventTypes.Count; index++)
            {
                EMRDBLib.QaEventTypeDict qcEventType = lstQCEventTypes[index];
                this.cboEventType.Items.Add(qcEventType);
            }
            this.ShowStatusMessage(null);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            EMRDBLib.QaEventTypeDict qcEventType = this.cboEventType.SelectedItem as EMRDBLib.QaEventTypeDict;
            string szTypeDesc = null;
            if (qcEventType != null)
                szTypeDesc = qcEventType.QA_EVENT_TYPE;
            UserInfo userInfo = this.cboDoctor.SelectedItem as UserInfo;
            string szUserID = null;
            if (userInfo != null)
                szUserID = userInfo.USER_ID;
            if (szTypeDesc == null && szUserID == null)
            {
                MessageBoxEx.Show("请指定质量问题分类或者医生！", MessageBoxIcon.Information);
                return;
            }
            string szDeptName = null;
            if (!string.IsNullOrEmpty(this.cboDeptName.Text))
                szDeptName = this.cboDeptName.Text.Trim();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在统计质检问题，请稍候...");
            this.dataGridView1.Rows.Clear();
            List<EMRDBLib.MedicalQcMsg> lstQuestionInfo = null;
            short shRet = MedicalQcMsgAccess.Instance.GetQCQuestionListByQaEventType(szDeptName, szTypeDesc, szUserID, DateTime.Parse(dtpStatTimeBegin.Value.ToString("yyyy-M-d 00:00:00")),
                DateTime.Parse(dtpStatTimeEnd.Value.ToString("yyyy-M-d 23:59:59")), ref lstQuestionInfo);
            if (shRet != SystemData.ReturnValue.OK
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("查询数据失败！");
                this.ShowStatusMessage(null);
                return;
            }
            if (lstQuestionInfo == null || lstQuestionInfo.Count <= 0)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("没有符合条件的数据！", MessageBoxIcon.Information);
                this.ShowStatusMessage(null);
                return;
            }
            for (int index = 0; index < lstQuestionInfo.Count; index++)
            {
                EMRDBLib.MedicalQcMsg questionInfo = lstQuestionInfo[index];
                int nRowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                this.SetRowData(row, questionInfo);
            }
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 将数据信息加载到DataGridView中
        /// </summary>
        /// <param name="row">数据行</param>
        /// <param name="questionInfo">质检问题类</param>
        private void SetRowData(DataGridViewRow row, EMRDBLib.MedicalQcMsg questionInfo)
        {
            if (row == null || questionInfo == null)
                return;
            if (row.DataGridView == null)
                return;
            if (IsNeedShowSamePatientColumn(row.Index, questionInfo))
            {
                row.Cells[this.colPatID.Index].Value = questionInfo.PATIENT_ID;
                row.Cells[this.colPatName.Index].Value = questionInfo.PATIENT_NAME;
                row.Cells[this.colVisitID.Index].Value = questionInfo.VISIT_ID;
            }
            row.Cells[this.colPatDeptName.Index].Value = questionInfo.DEPT_NAME;
            row.Cells[this.colDoctorInCharge.Index].Value = questionInfo.DOCTOR_IN_CHARGE;
            row.Cells[this.colPARENT_DOCTOR.Index].Value = questionInfo.PARENT_DOCTOR;
            row.Cells[this.colQaEventType.Index].Value = questionInfo.QA_EVENT_TYPE;
            row.Cells[this.colMessage.Index].Value = questionInfo.MESSAGE;
          
                row.Cells[this.colCheckerName.Index].Value = questionInfo.ISSUED_BY;
            
            row.Cells[this.colCheckDataTime.Index].Value = questionInfo.ISSUED_DATE_TIME;
            row.Cells[this.colMsgStatus.Index].Value = questionInfo.MSG_STATUS;
            if (questionInfo.ASK_DATE_TIME != questionInfo.DefaultTime)
                row.Cells[this.colDateConfirmed.Index].Value = questionInfo.ASK_DATE_TIME;
            if (questionInfo.MSG_STATUS == 1)

                row.Cells[this.colMsgStatus.Index].Value = "已确认";

            else
                row.Cells[this.colMsgStatus.Index].Value = "未确认";
            row.Tag = questionInfo;
        }

        /// <summary>
        /// 是否需要显示同一患者的相同列
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool IsNeedShowSamePatientColumn(int rowIndex, EMRDBLib.MedicalQcMsg currentQCQuestionInfo)
        {
            if (SystemParam.Instance.LocalConfigOption.IsShowSameColumn)
            {
                return true;
            }
            else//判断是否是同一个患者，是则不需要显示
            {
                if (rowIndex == 0 || currentQCQuestionInfo == null)
                    return true;
                EMRDBLib.MedicalQcMsg preQCQuestionInfo = this.dataGridView1.Rows[rowIndex - 1].Tag as EMRDBLib.MedicalQcMsg;
                if (preQCQuestionInfo == null)
                    return true;
                if (preQCQuestionInfo.PATIENT_ID == currentQCQuestionInfo.PATIENT_ID
                    && preQCQuestionInfo.VISIT_ID == currentQCQuestionInfo.VISIT_ID)
                    return false;
                else
                    return true;
            }
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

        /// <summary>
        /// 加载打印模板
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "按质检问题统计问题清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("按质检问题统计问题清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("按质检问题统计问题清单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "问题分类")
            {
                value = this.cboEventType.Text;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可打印内容！");
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
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "按质检问题统计清单");
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
        private List<UserInfo> lstUserInfo = null;

        /// <summary>
        /// 用户信息列表
        /// </summary>
        public List<UserInfo> LstUserInfo
        {
            get
            {
                if (lstUserInfo == null)
                {
                    this.ShowStatusMessage("正在下载经治医生列表，请稍候...");
                    short shRet = UserAccess.Instance.GetAllUserInfos(ref lstUserInfo);
                    if (shRet != SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.Show("经治医生列表下载失败");
                    }
                    this.ShowStatusMessage(null);
                }
                return lstUserInfo;
            }
        }

        private void cboDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeptInfo deptInfo = this.cboDeptName.SelectedItem as DeptInfo;
            if (deptInfo == null)
                return;
            this.ShowStatusMessage(null);
            this.ShowStatusMessage("正在绑定经治医生列表，请稍候...");
            this.cboDoctor.Items.Clear();
            foreach (UserInfo userInfo in LstUserInfo)
            {
                if (deptInfo.DEPT_CODE == userInfo.DEPT_CODE)
                    this.cboDoctor.Items.Add(userInfo);
            }
            this.ShowStatusMessage(null);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            EMRDBLib.MedicalQcMsg info = row.Tag as EMRDBLib.MedicalQcMsg;
            if (info == null)
                return;
            this.MainForm.OpenDocument(info.TOPIC_ID, info.PATIENT_ID, info.VISIT_ID);
        }
    }
}