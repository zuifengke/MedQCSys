using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMRDBLib.DbAccess;
using EMRDBLib;

namespace Heren.MedQC.HomePage.PageCards
{
    public partial class MedicalQcMsgCard : BaseCard
    {
        public MedicalQcMsgCard()
        {
            InitializeComponent();
            this.Title = "质检问题状态监控";
            this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ReadOnly = true;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        public override bool RefreshCard()
        {
            this.dataGridView1.Rows.Clear();
            string szMsgState = string.Empty;
            if (chkModified.Checked)
            {
                szMsgState = SystemData.MsgStatus.Modified.ToString();
            }
            if (chkUnModified.Checked)
            {
                if (szMsgState == string.Empty)
                    szMsgState = SystemData.MsgStatus.UnCheck.ToString();
                else
                    szMsgState += "," + SystemData.MsgStatus.UnCheck.ToString();
            }
            string szIssuedBy = SystemParam.Instance.UserInfo.USER_NAME;
            List<MedicalQcMsg> lstMedicalQcMsg = null;
            short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgList2(szMsgState, szIssuedBy, ref lstMedicalQcMsg);
            if (lstMedicalQcMsg != null)
            {
                int rowIndex = 0;
                foreach (var item in lstMedicalQcMsg)
                {
                    rowIndex = this.dataGridView1.Rows.Add();
                    DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                    row.Cells[this.col_DOCTOR_COMMENT.Index].Value = item.DOCTOR_COMMENT;
                    row.Cells[this.col_ISSUED_DATE_TIME.Index].Value = item.ISSUED_DATE_TIME.ToString("yyyy-MM-dd HH:mm");
                    row.Cells[this.col_MESSAGE.Index].Value = item.MESSAGE;
                    if (item.PATIENT_NAME == string.Empty)
                    {
                        PatVisitInfo patVisitInfo = null;
                        shRet = PatVisitAccess.Instance.GetPatVisitInfo(item.PATIENT_ID, item.VISIT_ID, ref patVisitInfo);
                        if (patVisitInfo != null)
                        {
                            item.PATIENT_NAME = patVisitInfo.PATIENT_NAME;
                        }
                    }
                    row.Cells[this.col_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                    row.Tag = item;
                }
            }
            return true;
        }
        public override bool Export()
        {

            return true;
        }

        private void chkModified_CheckedChanged(object sender, EventArgs e)
        {
            this.RefreshCard();
        }

        private void chkUnModified_CheckedChanged(object sender, EventArgs e)
        {

            this.RefreshCard();
        }
    }
}
