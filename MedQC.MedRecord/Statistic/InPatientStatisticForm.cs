/********************************************************
 * @FileName   : QcTrackForm.cs
 * @Description: 病案管理系统之在院患者列表
 * @Author     : 叶慧(Yehui)
 * @Date       : 2017-04-17 11:06:51
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
********************************************************/
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using MedQCSys.Utility;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Controls.TableView;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;
using System.Collections;
using MedQCSys.PatPage;

namespace Heren.MedQC.MedRecord
{
    public partial class InPatientStatisticForm : DockContentBase
    {
        public InPatientStatisticForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.CloseButtonVisible = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.ShowError("加载科室列表失败");
            }
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载医嘱记录，请稍候...");
            this.dataTableView1.Rows.Clear();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        public InPatientStatisticForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.dataTableView1.Rows.Clear();
            string szDeptCode = string.Empty;
            string szUserID = string.Empty;
            string szPatientID = this.txtPatientID.Text.Trim();
            string szPatientName = this.txtName.Text.Trim();

            if (this.cboDeptName.Text.Trim() != string.Empty && this.cboDeptName.SelectedItem != null)
            {
                szDeptCode = (this.cboDeptName.SelectedItem as DeptInfo).DEPT_CODE;
            }
            DateTime dtVisitTimeBegin = SystemParam.Instance.DefaultTime;
            DateTime dtVisitTimeEnd = SystemParam.Instance.DefaultTime;

            List<PatVisitInfo> lstPatVisitInfo = null;
            short shRet = InpVisitAccess.Instance.GetInpVisitInfos(szDeptCode, szPatientID, szPatientName, ref lstPatVisitInfo);
            if (lstPatVisitInfo == null)
                return;
            //查找转科记录
            List<Transfer> lstTransfers = null;
            shRet = TransferAccess.Instance.GetList(lstPatVisitInfo, ref lstTransfers);
            int rowIndex = 0;
            int nTransferCount = 0;
            WorkProcess.Instance.Initialize(this, lstPatVisitInfo.Count, "正在加载留院患者列表...");
            string preDeptName = string.Empty;
            foreach (var item in lstPatVisitInfo)
            {
                if (WorkProcess.Instance.Canceled)
                    return;
                if (preDeptName == string.Empty)
                    preDeptName = item.DEPT_NAME;
                if (preDeptName != item.DEPT_NAME)
                {
                    rowIndex = this.dataTableView1.Rows.Add();
                    this.dataTableView1.Rows[rowIndex].Cells[2].Value = "合计";
                    this.dataTableView1.Rows[rowIndex].Cells[3].Value = "留院人数：";
                    this.dataTableView1.Rows[rowIndex].Cells[4].Value = lstPatVisitInfo.Where(m => m.DEPT_NAME == preDeptName).Count().ToString();
                    this.dataTableView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
                    preDeptName = item.DEPT_NAME;
                }
                WorkProcess.Instance.Show(lstPatVisitInfo.IndexOf(item));
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_ORDER_NO.Index].Value = row.Index + 1;
                row.Cells[this.col_1_BED_NO.Index].Value = item.BED_CODE;
                row.Cells[this.col_CHARGE_TYPE.Index].Value = item.CHARGE_TYPE;
                row.Cells[this.col_1_PATIENT_NAME.Index].Value = item.PATIENT_NAME;
                row.Cells[this.col_AGE.Index].Value = GlobalMethods.SysTime.GetAgeText(item.BIRTH_TIME);
                row.Cells[this.col_1_DEPT_NAME.Index].Value = item.DEPT_NAME;
                row.Cells[this.col_VISIT_TIME.Index].Value = item.VISIT_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.col_PATIENT_SEX.Index].Value = item.PATIENT_SEX;
                row.Cells[this.col_PATIENT_ID.Index].Value = item.PATIENT_ID;

                if (shRet == SystemData.ReturnValue.OK
                    && lstTransfers != null && lstTransfers.Count > 0)
                {
                    var lstTransfer = lstTransfers.Where(m => m.PATIENT_ID == item.PATIENT_ID && m.VISIT_ID == item.VISIT_ID).ToList();
                    if (lstTransfer != null && lstTransfer.Count > 1)
                    {
                        nTransferCount++;
                        var first = lstTransfer.FirstOrDefault();
                        if (first != null && first.DISCHARGE_DATE_TIME != first.DefaultTime)
                        {
                            row.Cells[this.col_TRANSFER_TIME.Index].Value = first.DISCHARGE_DATE_TIME.ToString("yyyy-MM-dd HH:mm");
                        }
                    }
                    if (lstTransfer != null && lstTransfer.Count > 0)
                    {
                        var last = lstTransfer.LastOrDefault();
                        if (last != null && !string.IsNullOrEmpty(last.MEDICAL_GROUP_NAME))
                            row.Cells[this.col_1_MEDICAL_GROUP.Index].Value = last.MEDICAL_GROUP_NAME;
                    }
                }
                //row.Cells[this.col_TRANSFER_TIME.Index].Value=
                row.Tag = item;
            }
            rowIndex = this.dataTableView1.Rows.Add();
            this.dataTableView1.Rows[rowIndex].Cells[2].Value = "合计";
            this.dataTableView1.Rows[rowIndex].Cells[3].Value = "留院人数：";
            this.dataTableView1.Rows[rowIndex].Cells[4].Value = lstPatVisitInfo.Where(m => m.DEPT_NAME == preDeptName).Count().ToString();
            this.dataTableView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(200, 200, 200);
            WorkProcess.Instance.Close();
            this.lblTransferCount.Text = nTransferCount.ToString();
            this.lblInPatientCount.Text = lstPatVisitInfo.Count.ToString();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataTableView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            QcModifyNotice item = this.dataTableView1.Rows[e.RowIndex].Tag as QcModifyNotice;
            if (item == null)
                return;

            List<MedicalQcMsg> lstMedicalQcMsg = null;
            short shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgs(item.MODIFY_NOTICE_ID, ref lstMedicalQcMsg);
            if (lstMedicalQcMsg == null || lstMedicalQcMsg.Count <= 0)
                return;

            int rowIndex = 0;

            if (string.IsNullOrEmpty(lstMedicalQcMsg[0].TOPIC_ID))
            {
                return;
            }

        }


        private void RefreshDataTable1(MedicalQcMsg qcMsg)
        {
            this.dataTableView1.SelectedRows[0].Tag = qcMsg;
        }


        private void dataTableView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            PatVisitInfo patVisitInfo = this.dataTableView1.Rows[e.RowIndex].Tag as PatVisitInfo;
            if (patVisitInfo == null)
                return;
            this.MainForm.SwitchPatient(patVisitInfo);
        }

    }
}
