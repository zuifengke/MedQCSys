// ***********************************************************
// 整改通知书创建窗口
// Creator:yehui  Date:2017-04-12
// Copyright:heren
// ***********************************************************
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Controls;
using Heren.Common.Controls.VirtualTreeView;
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedQCSys.Dialogs
{
    public partial class ModifyNoticeForm : HerenForm
    {
        public ModifyNoticeForm()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            foreach (DataGridViewColumn item in this.dataTableView1.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (item.Index == this.col_ERROR_COUNT.Index
                    || item.Index == this.col_SCORE.Index)
                    item.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }
        /// <summary>
        /// 初始化整改通知单
        /// </summary>
        private void LoadData()
        {
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            this.lbl_NOTICE_TIME.Text = SysTimeHelper.Instance.Now.ToString("yyyy-MM-dd HH:mm");
            this.lbl_QC_DEPT_NAME.Text = SystemParam.Instance.UserInfo.DeptName;
            this.lbl_QC_MAN.Text = SystemParam.Instance.UserInfo.Name;
            this.lbl_RECEIVER.Text = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR;
            this.lbl_RECEIVER_DEPT_NAME.Text = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
            this.lbl_QC_LEVEL.Text = SystemData.QcLevel.GetCnName(SystemData.QcLevel.GetCodeByMrStatus(SystemParam.Instance.PatVisitInfo.MR_STATUS));
            List<QcCheckResult> lstQcCheckResult = null;
            short shRet = QcCheckResultAccess.Instance.GetQcCheckResults(szPatientID, szVisitID, SystemData.StatType.Artificial, ref lstQcCheckResult);
            if (lstQcCheckResult == null || lstQcCheckResult.Count <= 0)
                return;
            int rowIndex = 0;
            float fModifyScore = 0;
            foreach (var item in lstQcCheckResult)
            {
                rowIndex = this.dataTableView1.Rows.Add();
                MedicalQcMsg medicalQcMsg = this.ToQcMsg(item);
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_ERROR_COUNT.Index].Value = medicalQcMsg.ERROR_COUNT;
                row.Cells[this.col_MSG_DICT_MESSAGE.Index].Value = string.Format("{0}.{1}", lstQcCheckResult.IndexOf(item) + 1, medicalQcMsg.MESSAGE);
                row.Cells[this.col_QA_EVENT_TYPE.Index].Value = item.QA_EVENT_TYPE;
                row.Cells[this.col_SCORE.Index].Value = medicalQcMsg.POINT;
                row.Tag = medicalQcMsg;
                fModifyScore += medicalQcMsg.POINT * medicalQcMsg.ERROR_COUNT;
                if (!string.IsNullOrEmpty(item.REMARKS))
                {
                    this.rtb_MODIFY_REMARK.AppendText(item.REMARKS);
                    this.rtb_MODIFY_REMARK.AppendText(Environment.NewLine);
                }
            }
            this.lbl_MODIFY_SCORE.Text = fModifyScore.ToString();
        }

        /// <summary>
        /// 人工检查结果转为消息对象
        /// </summary>
        /// <param name="qcCheckResult"></param>
        /// <returns></returns>
        private MedicalQcMsg ToQcMsg(QcCheckResult qcCheckResult)
        {
            MedicalQcMsg medicalQcMsg = new MedicalQcMsg();
            medicalQcMsg.APPLY_ENV = "MEDDOC";
            medicalQcMsg.CREATOR_ID = qcCheckResult.CREATE_ID;
            medicalQcMsg.DEPT_NAME = qcCheckResult.DEPT_IN_CHARGE;
            medicalQcMsg.DEPT_STAYED = qcCheckResult.DEPT_CODE;
            medicalQcMsg.ERROR_COUNT = qcCheckResult.ERROR_COUNT;
            medicalQcMsg.DOCTOR_IN_CHARGE = qcCheckResult.INCHARGE_DOCTOR;
            medicalQcMsg.ISSUED_BY = qcCheckResult.CHECKER_NAME;
            medicalQcMsg.ISSUED_DATE_TIME = SysTimeHelper.Instance.Now;
            medicalQcMsg.ISSUED_ID = qcCheckResult.CHECKER_ID;
            medicalQcMsg.ISSUED_TYPE = SystemData.IssuedType.NORMAL;
            medicalQcMsg.LOCK_STATUS = false;
            medicalQcMsg.LogDesc = string.Empty;
            medicalQcMsg.MESSAGE = qcCheckResult.MSG_DICT_MESSAGE;
            medicalQcMsg.MSG_STATUS = SystemData.MsgStatus.UnCheck;
            medicalQcMsg.PARENT_DOCTOR = string.Empty;
            medicalQcMsg.PATIENT_ID = qcCheckResult.PATIENT_ID;
            medicalQcMsg.PATIENT_NAME = qcCheckResult.PATIENT_NAME;
            medicalQcMsg.POINT = qcCheckResult.SCORE;
            medicalQcMsg.POINT_TYPE = SystemData.PointType.Artific;
            medicalQcMsg.QA_EVENT_TYPE = qcCheckResult.QA_EVENT_TYPE;
            medicalQcMsg.QCDOC_TYPE = SystemData.QCDocType.OUTHOSPITAL;
            medicalQcMsg.QC_MODULE = "DOCTOR_MR";
            medicalQcMsg.QC_MSG_CODE = qcCheckResult.MSG_DICT_CODE;
            medicalQcMsg.SUPER_DOCTOR = string.Empty;
            medicalQcMsg.TOPIC = qcCheckResult.DOC_TITLE;
            medicalQcMsg.TOPIC_ID = qcCheckResult.DOC_SETID;
            medicalQcMsg.VISIT_ID = qcCheckResult.VISIT_ID;
            medicalQcMsg.VISIT_NO = qcCheckResult.VISIT_NO;
            return medicalQcMsg;
        }
        private void herenButton1_Click(object sender, EventArgs e)
        {
            QcModifyNotice qcModifyNotice = this.Tag as QcModifyNotice;
            if (qcModifyNotice == null)
                qcModifyNotice = new QcModifyNotice();
            if (qcModifyNotice.NOTICE_STATUS == SystemData.NotifyStatus.Draft)
            {
                this.InsertModifyNotice(qcModifyNotice);
            }
            else
            {
                this.UpdateModifyNotice(qcModifyNotice);
            }

        }
        /// <summary>
        /// 新增整改通知书
        /// </summary>
        private void InsertModifyNotice(QcModifyNotice qcModifyNotice)
        {
            if (MessageBoxEx.ShowConfirm("评分结果将以消息形式发送到医生工作台，确认发送通知书吗？") != DialogResult.OK)
            {
                return;
            }
            qcModifyNotice.MODIFY_NOTICE_ID = qcModifyNotice.MakeID(); 
            qcModifyNotice.MODIFY_PERIOD = this.cbo_MODIFY_PERIOD.Text;
            qcModifyNotice.MODIFY_REMARK = this.rtb_MODIFY_REMARK.Text;
            qcModifyNotice.MODIFY_SCORE = float.Parse(this.lbl_MODIFY_SCORE.Text);
            qcModifyNotice.NOTICE_TIME = DateTime.Parse(this.lbl_NOTICE_TIME.Text);
            qcModifyNotice.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            qcModifyNotice.PATIENT_NAME = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
            qcModifyNotice.QC_DEPT_CODE = SystemParam.Instance.UserInfo.DeptCode;
            qcModifyNotice.QC_DEPT_NAME = SystemParam.Instance.UserInfo.DeptName;
            qcModifyNotice.QC_LEVEL = SystemData.QcLevel.GetCodeByMrStatus(SystemParam.Instance.PatVisitInfo.MR_STATUS);
            qcModifyNotice.QC_MAN = SystemParam.Instance.UserInfo.Name;
            qcModifyNotice.QC_MAN_ID = SystemParam.Instance.UserInfo.ID;
            qcModifyNotice.RECEIVER = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR;
            qcModifyNotice.RECEIVER_ID = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR_ID;
            qcModifyNotice.RECEIVER_DEPT_CODE = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            qcModifyNotice.RECEIVER_DEPT_NAME = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
            qcModifyNotice.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            qcModifyNotice.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            qcModifyNotice.NOTICE_STATUS = SystemData.NotifyStatus.Sended;
            short shRet = QcModifyNoticeAccess.Instance.Insert(qcModifyNotice);
            //新增质检信息
            foreach (DataGridViewRow item in this.dataTableView1.Rows)
            {
                MedicalQcMsg medicalQcMsg = item.Tag as MedicalQcMsg;
                medicalQcMsg.MODIFY_NOTICE_ID = qcModifyNotice.MODIFY_NOTICE_ID;
                shRet = MedicalQcMsgAccess.Instance.Insert(medicalQcMsg);
            }
            if (shRet == SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowMessage("发送成功");
                this.lbl_NOTICE_STATUS.Text = SystemData.NotifyStatus.GetCnName(qcModifyNotice.NOTICE_STATUS);
                this.lbl_NOTICE_STATUS.ForeColor = Color.Blue;
            }
            this.Tag = qcModifyNotice;
        }
        /// <summary>
        /// 修改整改通知书
        /// </summary>
        private void UpdateModifyNotice(QcModifyNotice qcModifyNotice)
        {
            if (MessageBoxEx.ShowConfirm("通知书已成功发送，您需要修改通知书内容重新提交吗？") != DialogResult.OK)
            {
                return;
            }
            qcModifyNotice.MODIFY_PERIOD = this.cbo_MODIFY_PERIOD.Text;
            qcModifyNotice.MODIFY_REMARK = this.rtb_MODIFY_REMARK.Text;
            qcModifyNotice.MODIFY_SCORE = float.Parse(this.lbl_MODIFY_SCORE.Text);
            qcModifyNotice.NOTICE_TIME = DateTime.Parse(this.lbl_NOTICE_TIME.Text);
            qcModifyNotice.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            qcModifyNotice.QC_DEPT_CODE = SystemParam.Instance.UserInfo.DeptCode;
            qcModifyNotice.QC_DEPT_NAME = SystemParam.Instance.UserInfo.DeptName;
            qcModifyNotice.QC_LEVEL = SystemData.QcLevel.GetCodeByMrStatus(SystemParam.Instance.PatVisitInfo.MR_STATUS);
            qcModifyNotice.QC_MAN = SystemParam.Instance.UserInfo.Name;
            qcModifyNotice.QC_MAN_ID = SystemParam.Instance.UserInfo.ID;
            qcModifyNotice.RECEIVER = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR;
            qcModifyNotice.RECEIVER_ID = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR_ID;
            qcModifyNotice.RECEIVER_DEPT_CODE = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            qcModifyNotice.RECEIVER_DEPT_NAME = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
            qcModifyNotice.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            qcModifyNotice.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            qcModifyNotice.NOTICE_STATUS = SystemData.NotifyStatus.Sended;
            short shRet = QcModifyNoticeAccess.Instance.Update(qcModifyNotice);
            if (shRet == SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowMessage("发送成功");
                this.lbl_NOTICE_STATUS.Text = SystemData.NotifyStatus.GetCnName(qcModifyNotice.NOTICE_STATUS);
                this.lbl_NOTICE_STATUS.ForeColor = Color.Blue;
            }
            this.Tag = qcModifyNotice;
        }
        private void herenButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
