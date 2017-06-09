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

namespace MedQCSys.DockForms
{
    public partial class PatientIndexForm : DockContentBase
    {
        private int m_nPageIndex = 1;
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
            this.OnRefreshView();
            // ShowPageView();
        }
        private delegate void DispMSGDelegate();
        private void Thread_DisplayMSG()
        {
            DispMsg();
        }
        private void DispMsg()
        {
            if (this.InvokeRequired == false)                      //如果调用该函数的线程和控件lstMain位于同一个线程内
            {
                //直接将内容添加到窗体的控件上
                this.ShowPageView();
            }
            else
            {
                //通过使用Invoke的方法，让子线程告诉窗体线程来完成相应的控件操作
                DispMSGDelegate DMSGD = new DispMSGDelegate(DispMsg);

                //使用控件lstMain的Invoke方法执行DMSGD代理(其类型是DispMSGDelegate)
                this.Invoke(DMSGD);
            }
        }
      
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                ReportType reportTypeInfo = null;
                if (this.m_nPageIndex==1)
                    ReportTypeAccess.Instance.GetReportType(this.m_PatientIndex1.ReportTypeID, ref reportTypeInfo);
                else
                    ReportTypeAccess.Instance.GetReportType(this.m_PatientIndex2.ReportTypeID, ref reportTypeInfo);
                this.Update();
                if (reportTypeInfo == null)
                {
                    MessageBoxEx.ShowError("体温单模板还没有制作!");
                    return true;
                }
                byte[] byteTempletData = null;
                if (!ReportCache.Instance.GetReportTemplet(reportTypeInfo, ref byteTempletData))
                {
                    MessageBoxEx.ShowError("体温单模板内容下载失败!");
                    return true;
                }
                if (this.m_nPageIndex == 1)
                    this.reportDesigner1.OpenDocument(byteTempletData);
                else
                    this.reportDesigner2.OpenDocument(byteTempletData);
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private bool m_bIsShow = false;
        private ReportType m_PatientIndex1;
        private ReportType m_PatientIndex2;
        private void ShowPageView()
        {
            if (this.m_bIsShow)
                return;
            List<ReportType> lstReportTypes = ReportCache.Instance.GetReportTypeList(SystemData.ReportTypeApplyEnv.PATIENT_INDEX);
            if (lstReportTypes == null || lstReportTypes.Count <= 0)
                return;
            foreach (var item in lstReportTypes)
            {
                if (item.IsFolder || !item.IsValid)
                    continue;
                if (item.ReportTypeName == "病案首页1"
                    && this.m_PatientIndex1 == null)
                {
                    byte[] byteTempletData = null;
                    bool result = ReportCache.Instance.GetReportTemplet(item.ReportTypeID, ref byteTempletData);
                    if (result)
                        this.reportDesigner1.OpenDocument(byteTempletData);
                    this.m_PatientIndex1 = item;
                }
                else if (item.ReportTypeName == "病案首页2"
                    && this.m_PatientIndex2 == null)
                {
                    byte[] byteTempletData = null;
                    bool result = ReportCache.Instance.GetReportTemplet(item.ReportTypeID, ref byteTempletData);
                    if (result)
                        this.reportDesigner2.OpenDocument(byteTempletData);
                    this.m_PatientIndex2 = item;
                }
            }
            this.m_bIsShow = true;

            ShowReportDesignerIndex(this.m_nPageIndex);
        }

        public override void OnRefreshView()
        {
            this.m_bIsShow = false;
            base.OnRefreshView();
            //Thread thread = new Thread(new ThreadStart(Thread_DisplayMSG));
            //thread.Start();
            this.ShowPageView();
            this.Update();
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

        private void ShowReportDesignerIndex(int pageIndex)
        {
            if (pageIndex == 1)
            {
                this.reportDesigner1.Visible = true;
                this.reportDesigner1.PerformLayout();
                this.reportDesigner2.Visible = false;
            }
            else
            {
                this.reportDesigner1.Visible = false;
                this.reportDesigner2.Visible = true;
                this.reportDesigner2.PerformLayout();
            }
        }

        private void LoadPatProfileTemplet(string szTempletPath, int pageIndex)
        {
            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szTempletPath, ref byteTempletData))
            {
                MessageBoxEx.Show("首页模板加载失败");
                return;
            }
            if (pageIndex == 1)
            {
                this.reportDesigner1.OpenDocument(byteTempletData);
            }
            else
            {
                this.reportDesigner2.OpenDocument(byteTempletData);
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.m_nPageIndex == 1)
                this.m_nPageIndex = 2;
            else
                this.m_nPageIndex = 1;
            this.ShowReportDesignerIndex(this.m_nPageIndex);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (this.m_nPageIndex == 1)
                this.m_nPageIndex = 2;
            else
                this.m_nPageIndex = 1;
            this.ShowReportDesignerIndex(this.m_nPageIndex);
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
    }
}

