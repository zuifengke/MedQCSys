using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using EMRDBLib;
using Heren.Common.Libraries;
using MedQCSys.DockForms;

namespace MedQCSys.PatPage
{
    public partial class PatientPageForm : MedQCSys.DockForms.DockContentBase
    {
        private PatVisitInfo m_patientVisit;
        public PatVisitInfo PatVisitInfo
        {
            get { return this.m_patientVisit; }
            set { this.m_patientVisit = value; }
        }
        public void LoadModule(string moduleName)
        {
            this.patientPageControl1.LoadModule(moduleName);
        }
        public void GetActiveContent(ref DockContentBase dockContent)
        {
            this.patientPageControl1.GetActiveDoument(ref dockContent);
        }
        public PatientPageForm(MainForm parent) : base(parent)
        {
            InitializeComponent();
            this.patientPageControl1.MainForm = parent;
            this.MaximizeBox = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document|DockAreas.Float;
        }
        /// <summary>
        /// 切换当前窗口中显示的病人及就诊信息
        /// </summary>
        /// <param name="patVisit">病人就诊信息</param>
        /// <returns>是否成功</returns>
        public bool SwitchPatient(PatVisitInfo patVisit)
        {
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            bool success = this.patientPageControl1.SwitchPatient(patVisit);
            if (success)
            {
                this.m_patientVisit = patVisit;
                this.RefreshWindowCaption();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            return success;
        }

        private void RefreshWindowCaption()
        {
            if (this.m_patientVisit == null)
            {
                this.Text = "患者病案";
                return;
            }
            this.Text = string.Format("{0}({1})"
                , this.m_patientVisit.PATIENT_NAME
                , this.m_patientVisit.PATIENT_ID);
        }
    }
}
