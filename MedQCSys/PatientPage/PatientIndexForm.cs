using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;

using Heren.Common.Report;
using Heren.Common.VectorEditor;
using EMRDBLib.DbAccess;
using EMRDBLib.Entity;
using EMRDBLib;
using System.IO;
using Heren.MedQC.Core;
using Heren.Common.PrintLib;
using System.Drawing.Printing;
using Heren.MedQC.Utilities;
namespace MedQCSys.DockForms
{
    public partial class PatientIndexForm : DockContentBase
    {

        public PatientIndexForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
        }

        public PatientIndexForm(MainForm parent, PatPage.PatientPageControl patientPageControl)
            : base(parent, patientPageControl)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.DockAreas = DockAreas.Document | DockAreas.DockBottom | DockAreas.DockLeft
                | DockAreas.DockRight | DockAreas.DockTop;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.OnRefreshView();
            // ShowPageView();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                ShowPageView();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        private byte[] m_byteReportData = null;
        private bool m_bIsShow = false;

        private void ShowPageView()
        {
            this.previewControl1.Pages.Clear();
            List<ReportType> lstReportTypes = ReportCache.Instance.GetReportTypeList(SystemData.ReportTypeApplyEnv.PATIENT_INDEX);
            if (lstReportTypes == null || lstReportTypes.Count <= 0)
                return;
            foreach (var item in lstReportTypes)
            {
                if (item.IsFolder || !item.IsValid)
                    continue;
                if (item.ReportTypeName != "病案首页1")
                    continue;
                byte[] byteTempletData = null;
                bool result = ReportCache.Instance.GetReportTemplet(item.ReportTypeID, ref byteTempletData);
                if (result)
                {
                    this.reportDesigner1.OpenDocument(byteTempletData);
                    this.reportDesigner1.UpdateReport("显示数据", "1");
                    this.reportDesigner1.UpdateReport("显示下一页", "1");
                }
                m_byteReportData = byteTempletData;

            }
            this.m_bIsShow = true;
        }

        public override void OnRefreshView()
        {
            base.OnRefreshView();
            //Thread thread = new Thread(new ThreadStart(Thread_DisplayMSG));
            //thread.Start();
            this.previewControl1.PrintDocument = new XPrintDocument();
            this.ShowPageView();
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

        protected override void OnPatientInfoChanged()
        {
            base.OnPatientInfoChanged();
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this && this.NeedRefreshView)
                this.OnRefreshView();
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

        private void reportDesigner1_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = GetSystemContext(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "患者ID号" || name == "患者编号")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                return true;
            }
            else if (name == "就诊ID号" || name == "入院次" || name == "入院次")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_ID;
                return true;
            }
            else if (name == "就诊流水号")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_NO;
                return true;
            }
            else if (name == "入院时间")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_TIME;
                return true;
            }

            else if (name.ToUpper() == "DBLINK")
            {
                value = SystemParam.Instance.LocalConfigOption.DBLINK;
                return true;
            }
            else if (name == "医院名称")
            {
                value = SystemParam.Instance.LocalConfigOption.HOSPITAL_NAME;
                return true;
            }
            return false;
        }

        private void toolbtnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    morepages = true;
                    printDocument1.PrinterSettings = printDialog.PrinterSettings;
                    printDocument1.Print();
                }
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
            }
            catch (Exception ex)
            {
                MessageBoxEx.ShowMessage(ex.ToString());
                LogManager.Instance.WriteLog(ex.ToString());
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
            }
        }
        private void reportDesigner1_NotifyNextReport(object sender, NotifyNextReportEventArgs e)
        {
            e.ReportData = this.GetReportFileData(e.ReportName);
            if (e.ReportData == null)
                return;
            this.reportDesigner1.OpenDocument(e.ReportData, null);
            this.reportDesigner1.UpdateReport("显示数据", "1");
        }
        private byte[] GetReportFileData(string szReportName)
        {
            string szApplyEnv = SystemData.ReportTypeApplyEnv.PATIENT_INDEX;
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = "病案首页2";
            ReportType reportTypeInfo =
                ReportCache.Instance.GetWardReportType(szApplyEnv, szReportName);
            if (reportTypeInfo == null)
            {
                MessageBoxEx.ShowErrorFormat("{0}打印报表还没有制作!", null, szReportName);
                return null;
            }

            byte[] byteTempletData = null;
            if (!ReportCache.Instance.GetReportTemplet(reportTypeInfo, ref byteTempletData))
            {
                MessageBoxEx.ShowErrorFormat("{0}打印报表内容下载失败!", null, szReportName);
                return null;
            }
            return byteTempletData;
        }

        private void reportDesigner1_NotifyPageCompleted(object sender, EventArgs e)
        {
            this.previewControl1.Pages.Add(this.reportDesigner1.SaveAsImage());

        }
        bool morepages = true;
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image first = this.previewControl1.Pages[0].Image;
            Image second = this.previewControl1.Pages[1].Image;
            if (morepages)//第一页打印的图片
            {
                morepages = false;
                e.Graphics.DrawImage(first, 0, 0); e.HasMorePages = true;
            }
            else//第二页打印的图片
            {
                e.Graphics.DrawImage(second, 0, 0); e.HasMorePages = false;
            }
        }

        private void toolbtnPdf_Click(object sender, EventArgs e)
        {
            if (previewControl1.Pages.Count <= 1)
            {
                MessageBoxEx.ShowMessage("首页不全，另存为PDF失败");
            }
            Image first = this.previewControl1.Pages[0].Image;
            Image second = this.previewControl1.Pages[1].Image;
            Image[] files = new Image[] { first, second };
            string fileName = string.Concat("病案首页", "", "");
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                StringBuilder filter = new StringBuilder();
                filter.Append("PDF文件(*.pdf)|*.pdf|");
                filter.Append("所有文件(*.*)|*.*");
                saveDialog.Filter = filter.ToString();
                saveDialog.FileName = fileName;
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!PdfHelper.process(files, saveDialog.FileName))
                        MessageBoxEx.ShowMessage("导出失败");
                }
            }
        }
        #region 缩放
        private void UpdatePreviewZoom()
        {
            if (this.toolcboZoom.Text == "页宽")
            {
                this.previewControl1.SetZoomToWindow();
                this.previewControl1.Focus();
                return;
            }

            float fZoom = 1f;
            string szZoom = this.toolcboZoom.Text.Trim();
            int index = szZoom.IndexOf('%');
            if (index > 0)
            {
                fZoom = float.Parse(szZoom.Substring(0, index));
            }
            else
            {
                fZoom = float.Parse(szZoom);
            }
            fZoom = fZoom / 100f;
            this.previewControl1.Zoom = fZoom;
        }

        private void toolcboZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdatePreviewZoom();
        }

        private void ShowZoomValue()
        {
            this.toolcboZoom.Text = string.Format("{0}%", this.previewControl1.Zoom * 100);
        }

        private void previewControl1_ZoomChanged(object sender, EventArgs e)
        {
            this.ShowZoomValue();
        }

        private void toolcboZoom_Leave(object sender, EventArgs e)
        {
            this.ShowZoomValue();
        }

        private void toolcboZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.UpdatePreviewZoom();
        }

        private void toolcboZoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            //转半角
            if (e.KeyChar >= '０' && e.KeyChar <= '９')
                e.KeyChar = (char)(e.KeyChar - 65248);
            else if (e.KeyChar == '．')
                e.KeyChar = (char)(e.KeyChar - 65248);

            //仅数值
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
                return;
            if (e.KeyChar == '%' || e.KeyChar == '.')
                return;
            e.Handled = true;
        }

        private void toolbtnZoomIn_Click(object sender, EventArgs e)
        {
            if (this.toolcboZoom.SelectedIndex > 0)
                this.toolcboZoom.SelectedIndex--;
            this.previewControl1.Focus();
        }

        private void toolbtnZoomOut_Click(object sender, EventArgs e)
        {
            if (this.toolcboZoom.SelectedIndex < this.toolcboZoom.Items.Count - 1)
                this.toolcboZoom.SelectedIndex++;
            this.previewControl1.Focus();
        }
        #endregion

    }
}

