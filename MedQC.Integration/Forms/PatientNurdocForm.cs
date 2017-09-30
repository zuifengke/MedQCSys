// 病案质控系统患者信息窗口.
// Creator:LiChunYing  Date:2011-09-28
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;

using EMRDBLib.DbAccess;
using EMRDBLib.Entity;
using EMRDBLib;
using Heren.MedQC.Core;
using NurdocControl;

namespace MedQCSys.DockForms
{
    public partial class PatientNurdocForm : DockContentBase
    {
        public PatientNurdocForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }

        public PatientNurdocForm(MainForm mainForm, PatPage.PatientPageControl patientPageControl)
            : base(mainForm, patientPageControl)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = false;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            if (this.m_nurPatContrl == null)
                m_nurPatContrl = new NurdocControl.NurPatContrl();
            SystemConfig.Instance.ConfigFile = SystemParam.Instance.ConfigFile;
            this.Controls.Add(m_nurPatContrl);
            m_nurPatContrl.Dock = DockStyle.Fill;
        }
        private NurPatContrl m_nurPatContrl = null;
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            //if (LocateToDoc)
            //    NurPatContrl.OpenNurDoc(m_patientID, m_visitID, m_UserID, m_DocTypeID, m_DocID);
            //
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            string szUserID = SystemParam.Instance.UserInfo.USER_ID;
            this.m_nurPatContrl.SwitchPatient(szPatientID, szVisitID, szUserID);
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

        /// <summary>
        /// 患者信息改变方法重写
        /// </summary>
        protected override void OnPatientInfoChanged()
        {
            if (this.IsHidden)
                return;

            if (this.DockState == DockState.DockBottomAutoHide
                || this.DockState == DockState.DockTopAutoHide
                || this.DockState == DockState.DockLeftAutoHide
                || this.DockState == DockState.DockRightAutoHide)
            {
                if (SystemParam.Instance.PatVisitInfo != null)
                    this.DockHandler.Activate();
            }
            this.Update();

            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this)
                this.OnRefreshView();
        }
    }
}