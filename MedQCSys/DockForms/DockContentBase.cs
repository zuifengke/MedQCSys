// ***********************************************************
// DockPanel组件可停靠窗口继承基类.
// Creator:YangMingkun  Date:2009-11-7
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using EMRDBLib;
using MedQCSys.PatPage;

namespace MedQCSys.DockForms
{
    public partial class DockContentBase : DockContent
    {
        public DockContentBase()
        { }
        private bool m_bNeedRefreshView = false;
        /// <summary>
        /// 获取是否需要刷新视图
        /// </summary>
        [Browsable(false)]
        public virtual bool NeedRefreshView
        {
            get { return this.m_bNeedRefreshView; }
        }

        private MainForm m_mainForm = null;
        /// <summary>
        /// 获取或设置主程序窗口
        /// </summary>
        [Browsable(false)]
        protected virtual MainForm MainForm
        {
            get { return this.m_mainForm; }
            set { this.m_mainForm = value; }
        }

        private bool m_bIsUserHidden = false;
        /// <summary>
        /// 获取或设置用户是否主动隐藏了当前窗口
        /// </summary>
        [Browsable(false)]
        public bool IsUserHidden
        {
            get { return this.m_bIsUserHidden; }
            set { this.m_bIsUserHidden = value; }
        }

        private bool m_bSaveWindowBoundsEnabled = false;
        /// <summary>
        /// 获取或设置是否保存窗口坐标范围
        /// </summary>
        [Browsable(false)]
        public bool SaveWindowBoundsEnabled
        {
            get { return this.m_bSaveWindowBoundsEnabled; }
            set { this.m_bSaveWindowBoundsEnabled = value; }
        }


        public DockContentBase(MainForm parent)
        {
            this.m_mainForm = parent;
            this.InitializeComponent();
            this.TabPageContextMenuStrip = this.contextMenuStrip;
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            this.m_mainForm.PatientInfoChanging += new CancelEventHandler(this.MainForm_PatientInfoChanging);
            this.m_mainForm.PatientInfoChanged += new EventHandler(this.MainForm_PatientInfoChanged);
            this.m_mainForm.PatientListInfoChanged += new EventHandler(this.MainForm_PatientListInfoChanged);
            this.m_mainForm.ActiveContentChanged += new EventHandler(this.MainForm_ActiveContentChanged);
            this.m_mainForm.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.m_mainForm.PatientScoreChanged += new EventHandler(m_mainForm_PatientScoreChanged);
        }
        private PatPage.PatientPageControl m_patientPageControl = null;
        /// <summary>
        /// 获取或设置患者窗口
        /// </summary>
        [Browsable(false)]
        protected virtual PatPage.PatientPageControl PatientPageControl
        {
            get { return this.m_patientPageControl; }
            set { this.m_patientPageControl = value; }
        }
        public DockContentBase(MainForm mainForm, PatPage.PatientPageControl patientPageControl)
        {
            this.MainForm = mainForm;
            this.m_patientPageControl = patientPageControl;
            this.m_patientPageControl.MainForm = mainForm;
            this.InitializeComponent();
            this.TabPageContextMenuStrip = this.contextMenuStrip;
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            this.m_mainForm.ActiveContentChanged += new EventHandler(this.MainForm_ActiveContentChanged);
            this.m_mainForm.PatientListInfoChanged += new EventHandler(this.MainForm_PatientListInfoChanged);
            this.m_mainForm.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
            this.m_mainForm.PatientScoreChanged += new EventHandler(m_mainForm_PatientScoreChanged);

            this.m_patientPageControl.ActiveContentChanged += new EventHandler(PatientPageControl_ActiveContentChanged);
            this.m_patientPageControl.PatientInfoChanged += new EventHandler(PatientPageControl_PatientInfoChanged);
        }


        #region"窗口位置记录"
            /// <summary>
            /// 恢复窗口大小和位置
            /// </summary>
        public void RestoreWindowLocationAndSize()
        {
            string szFormTypeName = this.GetType().ToString();

            //设置主窗口显示位置和大小
            int nLeft = SystemConfig.Instance.Get(string.Concat(szFormTypeName, ".Left"), this.Left);
            int nTop = SystemConfig.Instance.Get(string.Concat(szFormTypeName, ".Top"), this.Top);
            int nWidth = SystemConfig.Instance.Get(string.Concat(szFormTypeName, ".Width"), this.Width);
            int nHeight = SystemConfig.Instance.Get(string.Concat(szFormTypeName, ".Height"), this.Height);

            //使窗口始终处于屏幕区域内
            Rectangle screenBounds = GlobalMethods.UI.GetScreenBounds();
            if (nLeft >= screenBounds.Right - 8 || nLeft + nWidth <= 8)
                nLeft = 0;
            if (nTop >= screenBounds.Bottom - 8 || nTop + nHeight <= 8)
                nTop = 0;

            this.SetBounds(nLeft, nTop, nWidth, nHeight, BoundsSpecified.All);

            //处理最大化状态
            if (SystemConfig.Instance.Get(string.Concat(szFormTypeName, ".Maximized"), false))
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DockPanel != null)
                return;
            bool bSaveWindowBoundsEnabled = this.m_bSaveWindowBoundsEnabled;
            this.m_bSaveWindowBoundsEnabled = false;

            this.RestoreWindowLocationAndSize();

            this.m_bSaveWindowBoundsEnabled = bSaveWindowBoundsEnabled;
        }

        protected override void OnLocationChanged(EventArgs e)
        {
            base.OnLocationChanged(e);
            if (!this.m_bSaveWindowBoundsEnabled || this.WindowState != FormWindowState.Normal)
                return;
            string szFormTypeName = this.GetType().ToString();
            SystemConfig.Instance.Write(string.Concat(szFormTypeName, ".Left"), this.Left.ToString());
            SystemConfig.Instance.Write(string.Concat(szFormTypeName, ".Top"), this.Top.ToString());
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (!this.m_bSaveWindowBoundsEnabled || this.WindowState != FormWindowState.Normal)
                return;
            string szFormTypeName = this.GetType().ToString();
            SystemConfig.Instance.Write(string.Concat(szFormTypeName, ".Width"), this.Width.ToString());
            SystemConfig.Instance.Write(string.Concat(szFormTypeName, ".Height"), this.Height.ToString());
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!this.SaveUncommitedChange())
                return;

            this.ClearOwnerForms();

            if (!this.m_bSaveWindowBoundsEnabled)
                return;

            string szFormTypeName = this.GetType().ToString();
            if (this.WindowState == FormWindowState.Maximized)
            {
                SystemConfig.Instance.Write(string.Concat(szFormTypeName, ".Maximized"), "True");
            }
            else
            {
                SystemConfig.Instance.Write(string.Concat(szFormTypeName, ".Maximized"), "False");
            }
        }
        #endregion

        private void PatientPageControl_PatientInfoChanging(object sender, PatientInfoChangingEventArgs e)
        {
            this.OnPatientInfoChanging(e);
        }


        private void MainForm_PatientInfoChanging(object sender, CancelEventArgs e)
        {
            this.OnPatientInfoChanging(e);
        }

        private void MainForm_PatientInfoChanged(object sender, EventArgs e)
        {
            //设置"是否需要刷新数据"标识为true
            this.m_bNeedRefreshView = true;
            //
            this.OnPatientInfoChanged();
            //
            if (this.Pane != null && !this.Pane.IsDisposed && this.Pane.ActiveContent == this)
                this.m_bNeedRefreshView = false;

        }
        /// <summary>
        /// 检查是否有需要保存的数据
        /// </summary>
        /// <returns>是否保存成功</returns>
        public virtual bool CheckModifiedData()
        {
            if (!this.HasUncommit())
                return true;
            this.DockHandler.Activate();
            DialogResult result = MessageBoxEx.ShowQuestion("当前有未保存的修改,是否保存？");
            if (result == DialogResult.Cancel)
                return false;
            else if (result == DialogResult.Yes)
                return this.CommitModify();
            return true;
        }
        private void MainForm_PatientListInfoChanged(object sender, EventArgs e)
        {
            //设置"是否需要刷新数据"标识为true
            this.m_bNeedRefreshView = true;
            //
            this.OnPatientListInfoChanged();
            //
            if (this.Pane != null && !this.Pane.IsDisposed && this.Pane.ActiveContent == this)
                this.m_bNeedRefreshView = false;
        }

        private void MainForm_ActiveContentChanged(object sender, EventArgs e)
        {
            this.OnActiveContentChanged();

            //
            if (this.Pane != null && !this.Pane.IsDisposed && this.Pane.ActiveContent == this)
                this.m_bNeedRefreshView = false;

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //发现主窗口关闭时,不会触发各子窗口的FormClosing事件,所以这里主动调用
            if (!e.Cancel)
                this.OnFormClosing(e);
        }

        private void m_mainForm_PatientScoreChanged(object sender, EventArgs e)
        {
            //设置"是否需要刷新数据"标识为true
            this.m_bNeedRefreshView = true;
            //
            this.OnPatientScoreChanged();
        }

        /// <summary>
        /// 患者质检问题改变前自动调用的方法
        /// </summary>
        protected virtual void OnPatientScoreChanged()
        {

        }
        /// <summary>
        /// 刷新视图方法
        /// </summary>
        public virtual void OnRefreshView()
        {
            this.m_bNeedRefreshView = false;
        }

        /// <summary>
        /// 患者信息改变前自动调用的方法
        /// 在子类中重写此方法来判断是否需要在改变前保存数据
        /// </summary>
        protected virtual void OnPatientInfoChanging(CancelEventArgs e)
        {

        }

        /// <summary>
        /// 患者信息改变时自动调用的方法
        /// 在子类中重写此方法来刷新当前的数据
        /// </summary>
        protected virtual void OnPatientInfoChanged()
        {

        }

        /// <summary>
        /// 患者列表信息改变时自动调用的方法
        /// 在子类中重写此方法来刷新当前的数据
        /// </summary>
        protected virtual void OnPatientListInfoChanged()
        {

        }

        /// <summary>
        /// 停靠窗口的活动状态改变时自动调用的方法
        /// 在子类中重写此方法来初始化当前的数据
        /// </summary>
        protected virtual void OnActiveContentChanged()
        {

        }
        private void PatientPageControl_ActiveContentChanged(object sender, EventArgs e)
        {
            if (!this.DockHandler.IsHidden)
                this.OnActiveContentChanged();
            //
            if (this.Pane != null && !this.Pane.IsDisposed && this.Pane.ActiveContent == this)
                this.m_bNeedRefreshView = false;
        }
        private void PatientPageControl_PatientInfoChanged(object sender, EventArgs e)
        {
            PatVisitInfo patVisit = SystemParam.Instance.PatVisitInfo;
            if (patVisit != null)
            {
                this.m_bNeedRefreshView = true;
                if (!this.DockHandler.IsHidden)
                    this.OnPatientInfoChanged();
            }
        }
        /// <summary>
        /// 获取是否有未保存的记录
        /// </summary>
        public virtual bool HasUncommit()
        {
            return false;
        }

        /// <summary>
        /// 保存当前对记录的修改
        /// </summary>
        /// <returns></returns>
        public virtual bool CommitModify()
        {
            return true;
        }

        /// <summary>
        /// 检查是否有需要保存的数据
        /// </summary>
        /// <returns>是否保存成功</returns>
        public virtual bool SaveUncommitedChange()
        {
            if (!this.HasUncommit())
                return true;
            this.DockHandler.Activate();
            DialogResult result = MessageBoxEx.Show("当前有未保存的修改,是否保存？"
                , MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
                return false;
            else if (result == DialogResult.Yes)
                return this.CommitModify();
            return true;
        }

        protected void ShowStatusMessage(string szMessage)
        {
            if (this.m_mainForm != null && !this.m_mainForm.IsDisposed)
                this.m_mainForm.ShowStatusMessage(szMessage);
        }

        private void ClearOwnerForms()
        {
            Form[] arrOwnedForms = this.OwnedForms;
            if (arrOwnedForms == null || arrOwnedForms.Length <= 0)
                return;
            for (int index = 0; index < arrOwnedForms.Length; index++)
            {
                if (arrOwnedForms[index] != null && !arrOwnedForms[index].IsDisposed)
                    arrOwnedForms[index].Owner = null;
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            if (this.DockHandler == null)
                this.Close();
            else
                this.DockHandler.Close();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            this.OnRefreshView();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                return;
            this.m_mainForm.PatientInfoChanging -= new CancelEventHandler(this.MainForm_PatientInfoChanging);
            this.m_mainForm.PatientInfoChanged -= new EventHandler(this.MainForm_PatientInfoChanged);
            this.m_mainForm.PatientListInfoChanged -= new EventHandler(this.MainForm_PatientListInfoChanged);
            this.m_mainForm.FormClosing -= new FormClosingEventHandler(this.MainForm_FormClosing);
            this.m_mainForm.ActiveContentChanged -= new EventHandler(this.MainForm_ActiveContentChanged);
        }

        private void contextMenuStrip_Opened(object sender, EventArgs e)
        {
            bool visible = true;
            if (!this.CloseButtonVisible)
                visible = false;
            if (this.mnuClose.Visible != visible)
                this.mnuClose.Visible = visible;
        }
    }
}