using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMRDBLib;
using System.Drawing.Drawing2D;
using Heren.Common.Libraries;
using Heren.MedQC.Core;

namespace MedQCSys.PatPage
{
    public partial class PatientInfoStrip : UserControl
    {
        private PatientPageControl m_patientPageControl = null;
        public PatientPageControl PatientPageControl
        {
            get { return this.m_patientPageControl; }
            set
            {
                this.SetPatientPageControl(value);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle ctrlRect = this.ClientRectangle;
            LinearGradientBrush brush = new LinearGradientBrush(ctrlRect, Color.White, Color.WhiteSmoke, LinearGradientMode.Vertical);
            e.Graphics.FillRectangle(brush, ctrlRect);
            brush.Dispose();
        }
        private void SetPatientPageControl(PatientPageControl patientPageControl)
        {
            this.m_patientPageControl = patientPageControl;
            if (this.m_patientPageControl == null || this.m_patientPageControl.IsDisposed)
                return;
            this.m_patientPageControl.PatientInfoChanged +=
                new EventHandler(this.PatientPageControl_PatientInfoChanged);
            //PatientTable.Instance.PatientInfoChanged -=
            //    new EventHandler(this.PatientPageControl_PatientInfoChanged);
            //PatientTable.Instance.PatientInfoChanged +=
            //    new EventHandler(this.PatientPageControl_PatientInfoChanged);
        }
        public PatVisitInfo PatVisitInfo { get; set; }
        public PatientInfoStrip()
        {
            InitializeComponent();
        }

        private void PatientPageControl_PatientInfoChanged(object sender, EventArgs e)
        {
            this.RefreshView(SystemParam.Instance.PatVisitInfo);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!SystemParam.Instance.LocalConfigOption.RecPrintLog)
                fbtnPrintLog.Visible = false;
            else
                fbtnPrintLog.Visible = true;
        }

        public void DocScoreNewForm_HummanScoreSaved(object sender, EventArgs e)
        {
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            this.lblScore.Text= "成绩：" + SystemParam.Instance.PatVisitInfo.TotalScore;

        }
        private void RefreshView(PatVisitInfo patientVisit)
        {
            this.PatVisitInfo = patientVisit;
            if (patientVisit == null || patientVisit.VISIT_TIME == patientVisit.DefaultTime)
                return;
            this.picSexFlag.Image = null;
            this.lblAge.Text = "0岁";
            this.lblPatientID.Text = "病案号：";
            this.lblInDays.Text = "在院：";
            this.lblDoctorInCharge.Text = "医生：";
            this.lblDiagnosis.Text = "诊断：";
            this.lblAllergyDrugs.Text = string.Empty;
            if (patientVisit == null || patientVisit.VISIT_TIME == patientVisit.DefaultTime)
                return;
            this.lblPatientName.Text = patientVisit.PATIENT_NAME;
            if (this.PatVisitInfo.PATIENT_SEX == "男")
                this.picSexFlag.Image = Properties.Resources.Male2;
            else if (this.PatVisitInfo.PATIENT_SEX == "女")
                this.picSexFlag.Image = Properties.Resources.Female2;
            DateTime dtBirthTime = patientVisit.BIRTH_TIME;
            this.lblAge.Text =
                GlobalMethods.SysTime.GetAgeText(dtBirthTime, patientVisit.VISIT_TIME);
            this.lblPatientID.Text = "病案号：" + patientVisit.PATIENT_ID;
            this.lblInDays.Text = string.Format("在院：{0}天"
                , GlobalMethods.SysTime.GetInpDays(patientVisit.VISIT_TIME, DateTime.Now).ToString());
            this.lblDoctorInCharge.Text = "医生：" + patientVisit.INCHARGE_DOCTOR;
            this.lblDiagnosis.Text = "诊断：" + patientVisit.DIAGNOSIS;
            this.lblAllergyDrugs.Text = "过敏：" + patientVisit.ALLERGY_DRUGS;
            this.lblChargeType.Text = "费别：" + patientVisit.CHARGE_TYPE;
            this.lblScore.Text = "成绩：" + patientVisit.TotalScore;
           
        }
        private void flatButton1_Click(object sender, EventArgs e)
        {
            this.Height = 30;
            this.panel2.Visible = false;
            this.panel1.Visible = true;
        }
        private void fbtnHigh_Click(object sender, EventArgs e)
        {
            this.Height = 10;
            this.panel2.Visible = true;
            this.panel1.Visible = false;
        }
        private void fbtnPrintLog_Click(object sender, EventArgs e)
        {
            CommandHandler.Instance.SendCommand("复印登记", null, null);
        }
    }
}
