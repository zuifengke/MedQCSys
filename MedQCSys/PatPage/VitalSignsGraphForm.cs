// ***********************************************************
// 护理电子病历系统,患者体征三测单窗口.
// Creator:YangMingkun  Date:2012-7-2
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Report;
using EMRDBLib;

using EMRDBLib.DbAccess;
using System.IO;
using Heren.MedQC.Core;

namespace MedQCSys.DockForms
{
    internal partial class VitalSignsGraphForm : DockContentBase
    {
        /// <summary>
        /// 标识日期时间控件改变事件是否可用,避免重复执行
        /// </summary>
        private bool m_bValueChangedEnabled = true;

        /// <summary>
        /// 缓存下载当前体温单报表文件数据,以便打印使用
        /// </summary>
        private byte[] m_byteReportData = null;

        public VitalSignsGraphForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;

            //string text = SystemContext.Instance.WindowName.VitalSignsGraph;
            //this.Text = SystemContext.Instance.WindowName.GetName(text);
            //this.Index = SystemContext.Instance.WindowName.GetIndex(text, 100);
        }

        public VitalSignsGraphForm(MainForm parent, PatPage.PatientPageControl patientPageControl)
            : base(parent, patientPageControl)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.splitContainer1.Panel2Collapsed = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.toolcboZoom.Text = "100%";
            this.LoadBodyTemperatureTemplet(false);
            this.reportDesigner1.Focus();

            this.m_bValueChangedEnabled = false;
            this.tooldtpDateFrom.Value = this.GetEndWeekDate(true);
            this.m_bValueChangedEnabled = true;

            this.tooltxtRecordWeek.Text = this.GetWeek(null).ToString();

            this.OnRefreshView();
            this.reportDesigner1.Focus();
        }

        /// <summary>
        /// 患者信息改变方法重写
        /// </summary>
        protected override void OnPatientInfoChanged()
        {
            if (this.IsHidden)
                return;
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this)
                this.OnRefreshView();
        }

        /// <summary>
        /// 当切换活动文档时刷新数据
        /// </summary>
        protected override void OnActiveContentChanged()
        {
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this && this.NeedRefreshView)
                this.OnRefreshView();
        }

        public override void OnRefreshView()
        {
            base.OnRefreshView();
            RefreshReport(false);
        }

        private void RefreshReport(bool force)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            if (this.m_byteReportData == null || force)
                this.LoadBodyTemperatureTemplet(force);
            this.Update();
            this.RefreshReportView(this.GetSelectedWeek());
            if (!this.splitContainer1.Panel2Collapsed)
            {
                DateTime dtNow = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                dtNow = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, dtNow.Hour, dtNow.Minute, 0);
                //this.formControl1.UpdateFormData("体征时间", dtNow);
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private ReportType m_reportTemplet;
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                RefreshReport(true);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 加载体温单报表模板
        /// </summary>
        private void LoadBodyTemperatureTemplet(bool force)
        {
            this.m_byteReportData = null;
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            if (SystemParam.Instance.UserInfo == null)
                return;
            this.Update();
            string szApplyEnv = SystemData.ReportTypeApplyEnv.TEMPERATURE;
            ReportType reportTypeInfo =
                ReportCache.Instance.GetWardReportType(szApplyEnv);
            if (reportTypeInfo == null)
            {
                MessageBoxEx.ShowError("体温单模板还没有制作!");
                return;
            }
            if (force)
            {
                short shRet = ReportTypeAccess.Instance.GetReportType(reportTypeInfo.ReportTypeID, ref reportTypeInfo);
            }


            byte[] byteTempletData = null;
            if (!ReportCache.Instance.GetReportTemplet(reportTypeInfo, ref byteTempletData))
            {
                MessageBoxEx.ShowError("体温单模板内容下载失败!");
                return;
            }
            this.m_reportTemplet = reportTypeInfo;
            this.reportDesigner1.OpenDocument(byteTempletData);
            this.m_byteReportData = byteTempletData;
        }

        /// <summary>
        /// 获取当前患者住院起始周的日期
        /// </summary>
        /// <returns>起始周日期</returns>
        private DateTime GetBeginWeekDate()
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
            DateTime dtWeekDate = SystemParam.Instance.PatVisitInfo.VISIT_TIME;
            if (dtWeekDate != SystemParam.Instance.PatVisitInfo.DefaultTime)
                return dtWeekDate;
            return MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
        }

        /// <summary>
        /// 获取当前患者住院截止周的日期
        /// </summary>
        /// <param name="bStopToCurrentTime">是否截止到当前时间</param>
        /// <returns>截止周日期</returns>
        private DateTime GetEndWeekDate(bool bStopToCurrentTime)
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
            DateTime dtWeekDate = SystemParam.Instance.PatVisitInfo.DISCHARGE_TIME;
            if (dtWeekDate != SystemParam.Instance.PatVisitInfo.DefaultTime)
                return dtWeekDate;
            return bStopToCurrentTime ? MedDocSys.DataLayer.SysTimeHelper.Instance.Now : DateTime.MaxValue;
        }

        /// <summary>
        /// 获取指定的日期时间对应的周次
        /// </summary>
        /// <param name="dtWeekDate">日期时间</param>
        /// <returns>周次</returns>
        private long GetWeek(DateTime? dtWeekDate)
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return 1;
            DateTime dtVisitTime = SystemParam.Instance.PatVisitInfo.VISIT_TIME;
            DateTime dtEndTime = DateTime.Now;
            if (dtWeekDate != null && dtWeekDate.HasValue)
                dtEndTime = dtWeekDate.Value;
            else
                dtEndTime = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
            long days = GlobalMethods.SysTime.DateDiff(DateInterval.Day, dtVisitTime.Date, dtEndTime.Date);
            long weeks = (days / 7) + 1;
            return weeks;
        }

        /// <summary>
        /// 获取当前周次文本框中的周次
        /// </summary>
        /// <returns>周次</returns>
        private long GetSelectedWeek()
        {
            return GlobalMethods.Convert.StringToValue(this.tooltxtRecordWeek.Text, 1);
        }

        /// <summary>
        /// 根据周次刷新当前报表视图显示
        /// </summary>
        /// <param name="week">周次</param>
        private void RefreshReportView(long week)
        {
            long end = this.GetWeek(this.GetEndWeekDate(false));
            if (end < 1)
                end = 1;
            if (week < 1)
            {
                week = 1;
                this.m_bValueChangedEnabled = false;
                this.tooldtpDateFrom.Value = this.GetBeginWeekDate();
                this.m_bValueChangedEnabled = true;
            }
            if (week > end)
            {
                week = end;
                this.m_bValueChangedEnabled = false;
                this.tooldtpDateFrom.Value = this.GetEndWeekDate(false);
                this.m_bValueChangedEnabled = true;
            }
            this.tooltxtRecordWeek.Text = week.ToString();

            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.UpdateReport("显示数据", week);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        
        private ReportExplorerForm GetReportExplorerForm()
        {
            ReportExplorerForm reportExplorerForm = new ReportExplorerForm();
            reportExplorerForm.WindowState = FormWindowState.Maximized;
            reportExplorerForm.QueryContext +=
                new QueryContextEventHandler(this.reportDesigner1_QueryContext);
            reportExplorerForm.ExecuteQuery +=
                new ExecuteQueryEventHandler(this.reportDesigner1_ExecuteQuery);
            return reportExplorerForm;
        }

        private void tooldtpDateFrom_ValueChanged(object sender, EventArgs e)
        {
            if (!this.m_bValueChangedEnabled)
                return;
            this.RefreshReportView(this.GetWeek(this.tooldtpDateFrom.Value));
        }

        private void tooltxtRecordWeek_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9')
                && e.KeyChar != (char)Keys.Enter
                && e.KeyChar != (char)Keys.Delete
                && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == (char)Keys.Enter)
                this.RefreshReportView(this.GetSelectedWeek());
        }

        private void toolbtnPrevWeek_Click(object sender, EventArgs e)
        {
            this.reportDesigner1.Focus();
            this.RefreshReportView(this.GetSelectedWeek() - 1);
        }

        private void toolbtnNextWeek_Click(object sender, EventArgs e)
        {
            this.reportDesigner1.Focus();
            this.RefreshReportView(this.GetSelectedWeek() + 1);
        }

        private void toolbtnRefresh_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.OnRefreshView();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolcboZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string szZoomText = this.toolcboZoom.Text;
            if (GlobalMethods.Misc.IsEmptyString(szZoomText))
                return;
            szZoomText = szZoomText.Remove(szZoomText.Length - 1);
            float zoom = GlobalMethods.Convert.StringToValue(szZoomText, 100f);
            this.reportDesigner1.Zoom = zoom / 100f;
        }

        private void toolbtnRecord_Click(object sender, EventArgs e)
        {

            this.splitContainer1.Panel2Collapsed =
                !this.splitContainer1.Panel2Collapsed;

        }

        private void toolmnuPrintCurrent_Click(object sender, EventArgs e)
        {
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            if (this.m_byteReportData != null)
            {
                ReportExplorerForm explorerForm = this.GetReportExplorerForm();
                explorerForm.StartPageNo = (int)this.GetSelectedWeek();
                explorerForm.ReportFileData = this.m_byteReportData;
                explorerForm.ReportParamData.Add("是否续打", false);
                explorerForm.ReportParamData.Add("打印数据", this.GetSelectedWeek());
                explorerForm.ShowDialog();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolmnuPrintFrom_Click(object sender, EventArgs e)
        {
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            if (this.m_byteReportData != null)
            {
                ReportExplorerForm explorerForm = this.GetReportExplorerForm();
                explorerForm.StartPageNo = (int)this.GetSelectedWeek();
                explorerForm.ReportFileData = this.m_byteReportData;
                explorerForm.ReportParamData.Add("是否续打", true);
                explorerForm.ReportParamData.Add("打印数据", this.GetSelectedWeek());
                explorerForm.ShowDialog();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);

        }

        private void toolbtnHide_Click(object sender, EventArgs e)
        {
            this.splitContainer1.Panel2Collapsed = true;
        }

        private void toolbtnSave_Click(object sender, EventArgs e)
        {

        }

        private void reportDesigner1_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = this.GetSystemContext(e.Name, ref value);
            if (e.Success) e.Value = value;
        }
        public bool GetSystemContext(string name, ref object value)
        {
            #region"系统上下文数据"
            if (name == "用户ID号" || name == "用户编号")
            {
                if (SystemParam.Instance.UserInfo == null)
                    return false;
                value = SystemParam.Instance.UserInfo.ID;
                return true;
            }
            if (name == "用户姓名")
            {
                if (SystemParam.Instance.UserInfo == null)
                    return false;
                value = SystemParam.Instance.UserInfo.Name;
                return true;
            }
            if (name == "用户科室代码")
            {
                if (SystemParam.Instance.UserInfo == null)
                    return false;
                value = SystemParam.Instance.UserInfo.DeptCode;
                return true;
            }
            if (name == "用户科室名称")
            {
                if (SystemParam.Instance.UserInfo == null)
                    return false;
                value = SystemParam.Instance.UserInfo.DeptName;
                return true;
            }

            if (name == "患者ID号" || name == "患者编号")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                return true;
            }
            if (name == "患者姓名")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
                return true;
            }
            if (name == "患者性别")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_SEX;
                return true;
            }
            if (name == "患者生日")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.BIRTH_TIME;
                return true;
            }
            if (name == "患者年龄")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = GlobalMethods.SysTime.GetAgeText(
                   SystemParam.Instance.PatVisitInfo.BIRTH_TIME,
                   SystemParam.Instance.PatVisitInfo.VISIT_TIME);
                return true;
            }
            if (name == "出院时间")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                if (SystemParam.Instance.PatVisitInfo.DISCHARGE_TIME ==
                    SystemParam.Instance.PatVisitInfo.DefaultTime)
                    value = DateTime.Now;
                else
                    value = SystemParam.Instance.PatVisitInfo.DISCHARGE_TIME;
                return true;
            }
            if (name == "患者病情")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_CONDITION;
                return true;
            }
            if (name == "护理等级")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.NURSING_CLASS;
                return true;
            }
            if (name == "入院次" || name == "入院次")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_ID;
                return true;
            }
            if (name == "入院时间")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_TIME;
                return true;
            }
            if (name == "就诊科室代码")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
                return true;
            }
            if (name == "就诊科室名称")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                return true;
            }
            if (name == "就诊病区代码")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
                return true;
            }
            if (name == "就诊病区名称")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                return true;
            }
            if (name == "就诊类型")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_TYPE;
                return true;
            }
            if (name == "床号")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.BED_CODE;
                return true;
            }
            if (name == "住院号")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.INP_NO;
                return true;
            }

            if (name == "当前时间")
            {
                value = MedDocSys.DataLayer.SysTimeHelper.Instance.Now;
                return true;
            }


            return false;
            #endregion
        }
        private void reportDesigner1_ExecuteQuery(object sender, Heren.Common.Report.ExecuteQueryEventArgs e)
        {
            DataSet result = null;

            if (CommonAccess.Instance.ExecuteQuery(e.SQL, out result) == SystemData.ReturnValue.OK)
            {
                e.Success = true;
                e.Result = result;
            }
        }

        private void reportDesigner1_ElementDoubleClick(object sender, Heren.Common.VectorEditor.CanvasEventArgs e)
        {
            if (e.Element is Heren.Common.VectorEditor.Shapes.TextFieldElement)
            {
                if (e.Element.Data == null)
                    return;
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

                System.Threading.Thread.Sleep(100);//这里做个延迟,以便给用户一个感觉上的反馈
                e.Handled = true;
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }

            Heren.Common.VectorEditor.Shapes.CoordinateElement coordinateElement =
                e.Element as Heren.Common.VectorEditor.Shapes.CoordinateElement;
            if (coordinateElement != null && coordinateElement.XAxisDataType ==
                Heren.Common.VectorEditor.Shapes.CoordinateElement.DataType.DateTime)
            {
                Heren.Common.VectorEditor.Shapes.CoordinateData data =
                    e.Data as Heren.Common.VectorEditor.Shapes.CoordinateData;
                if (data == null)
                    return;
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

                System.Threading.Thread.Sleep(100);//这里做个延迟,以便给用户一个感觉上的反馈
                e.Handled = true;
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
            }
        }

        private void toolmnuPrintAll_Click(object sender, EventArgs e)
        {
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            if (this.m_byteReportData != null)
            {
                ReportExplorerForm explorerForm = this.GetReportExplorerForm();
                explorerForm.ReportFileData = this.m_byteReportData;
                explorerForm.ReportParamData.Add("是否续打", true);
                explorerForm.ReportParamData.Add("打印数据", 1);
                explorerForm.ShowDialog();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

    }
}
