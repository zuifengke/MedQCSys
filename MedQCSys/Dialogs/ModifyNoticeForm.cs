// ***********************************************************
// 整改通知书创建窗口
// Creator:yehui  Date:2017-04-12
// Copyright:heren
// ***********************************************************
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Controls;
using Heren.Common.Controls.TableView;
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
                if (item.Index == this.col_INCHARGE_DOCTOR.Index)
                    item.ReadOnly = false;
                else
                    item.ReadOnly = true;
            }
        }
        private QcModifyNotice m_QcModifyNotice = null;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadGridComboBoxItem();
            LoadData();
        }
        /// <summary>
        /// 初始化整改通知单
        /// </summary>
        private void LoadData()
        {
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            string szVisitNO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            short shRet = QcModifyNoticeAccess.Instance.GetQcModifyNotice(szPatientID, szVisitID, ref this.m_QcModifyNotice);
            if (this.m_QcModifyNotice == null)
            {

                this.lbl_NOTICE_TIME.Text = SysTimeHelper.Instance.Now.ToString("yyyy-MM-dd HH:mm");
                this.lbl_QC_DEPT_NAME.Text = SystemParam.Instance.UserInfo.DEPT_NAME;
                this.lbl_QC_MAN.Text = SystemParam.Instance.UserInfo.USER_NAME;
                this.lbl_RECEIVER.Text = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR;
                this.lbl_RECEIVER_DEPT_NAME.Text = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                this.lbl_QC_LEVEL.Text = SystemData.QcLevel.GetCnName(SystemData.QcLevel.GetCodeByMrStatus(SystemParam.Instance.PatVisitInfo.MR_STATUS));
            }
            else
            {
                this.herenButton1.Text = "修改整改通知单";
                this.lbl_NOTICE_TIME.Text = this.m_QcModifyNotice.NOTICE_TIME.ToString("yyyy-MM-dd HH:mm");
                this.lbl_NOTICE_STATUS.Text = SystemData.NotifyStatus.GetCnName(this.m_QcModifyNotice.NOTICE_STATUS);
                this.cbo_MODIFY_PERIOD.Text = this.m_QcModifyNotice.MODIFY_PERIOD;
                this.rtb_MODIFY_REMARK.Text = this.m_QcModifyNotice.MODIFY_REMARK;
            }
            List<QcCheckResult> lstQcCheckResult = null;
            shRet = QcCheckResultAccess.Instance.GetQcCheckResults(szPatientID, szVisitID, SystemData.StatType.Artificial, ref lstQcCheckResult);
            List<MedicalQcMsg> lstMedicalQcMsg = null;
            shRet = MedicalQcMsgAccess.Instance.GetMedicalQcMsgList(szPatientID, szVisitID, ref lstMedicalQcMsg);
            if (lstQcCheckResult == null || lstQcCheckResult.Count <= 0)
                return;

            int rowIndex = 0;
            float fModifyScore = 0;
            foreach (var item in lstQcCheckResult)
            {
                rowIndex = this.dataTableView1.Rows.Add();
                DataGridViewRow row = this.dataTableView1.Rows[rowIndex];
                row.Cells[this.col_ERROR_COUNT.Index].Value = item.ERROR_COUNT;
                row.Cells[this.col_MSG_DICT_MESSAGE.Index].Value = string.Format("{0}.{1}", lstQcCheckResult.IndexOf(item) + 1, item.MSG_DICT_MESSAGE);
                row.Cells[this.col_QA_EVENT_TYPE.Index].Value = item.QA_EVENT_TYPE;
                row.Cells[this.col_SCORE.Index].Value = item.SCORE;
                row.Cells[this.col_INCHARGE_DOCTOR.Index].Value = item.INCHARGE_DOCTOR;
                row.Cells[this.col_DEPT_IN_CHARGE.Index].Value = item.DEPT_IN_CHARGE;
                if (!string.IsNullOrEmpty(item.MSG_ID) && lstMedicalQcMsg != null)
                {
                    row.Cells[this.col_MSG_ID.Index].Value = item.MSG_ID;
                    row.Cells[this.col_MSG_ID.Index].Tag = lstMedicalQcMsg.Where(m => m.MSG_ID == item.MSG_ID).FirstOrDefault();
                }
                row.Tag = item;
                fModifyScore += item.SCORE * item.ERROR_COUNT;
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
            medicalQcMsg.MODIFY_NOTICE_ID = qcCheckResult.MODIFY_NOTICE_ID;
            medicalQcMsg.DOCTOR_IN_CHARGE_ID = qcCheckResult.INCHARGE_DOCTOR_ID;


            return medicalQcMsg;
        }
        private void herenButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_QcModifyNotice == null)
                    m_QcModifyNotice = new QcModifyNotice();
                if (m_QcModifyNotice.NOTICE_STATUS == SystemData.NotifyStatus.Draft)
                {
                    this.InsertModifyNotice(m_QcModifyNotice);
                }
                else
                {
                    this.UpdateModifyNotice(m_QcModifyNotice);
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.ShowMessage("操作失败", (ex.ToString()));
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
            qcModifyNotice.QC_DEPT_CODE = SystemParam.Instance.UserInfo.DEPT_CODE;
            qcModifyNotice.QC_DEPT_NAME = SystemParam.Instance.UserInfo.DEPT_NAME;
            qcModifyNotice.QC_LEVEL = SystemData.QcLevel.GetCodeByMrStatus(SystemParam.Instance.PatVisitInfo.MR_STATUS);
            qcModifyNotice.QC_MAN = SystemParam.Instance.UserInfo.USER_NAME;
            qcModifyNotice.QC_MAN_ID = SystemParam.Instance.UserInfo.USER_ID;
            qcModifyNotice.RECEIVER = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR;
            qcModifyNotice.RECEIVER_ID = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR_ID;
            qcModifyNotice.RECEIVER_DEPT_CODE = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            qcModifyNotice.RECEIVER_DEPT_NAME = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
            qcModifyNotice.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            qcModifyNotice.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            qcModifyNotice.NOTICE_STATUS = SystemData.NotifyStatus.Sended;
            short shRet = QcModifyNoticeAccess.Instance.Insert(qcModifyNotice);
            //新增质检信息 更新人工质控结果 新增
            foreach (DataGridViewRow item in this.dataTableView1.Rows)
            {
                QcCheckResult qcCheckResult = item.Tag as QcCheckResult;
                qcCheckResult.MODIFY_NOTICE_ID = qcModifyNotice.MODIFY_NOTICE_ID;
                MedicalQcMsg medicalQcMsg = item.Cells[this.col_MSG_ID.Index].Tag as MedicalQcMsg;
                UserInfo userInfo = item.Cells[this.col_INCHARGE_DOCTOR.Index].Tag as UserInfo;
                if (userInfo != null)
                {
                    qcCheckResult.DEPT_CODE = userInfo.DEPT_CODE;
                    qcCheckResult.DEPT_IN_CHARGE = userInfo.DEPT_NAME;
                    qcCheckResult.INCHARGE_DOCTOR = userInfo.USER_NAME;
                    qcCheckResult.INCHARGE_DOCTOR_ID = userInfo.USER_ID;
                }
                if (medicalQcMsg == null)
                {
                    medicalQcMsg = this.ToQcMsg(qcCheckResult);
                    shRet = MedicalQcMsgAccess.Instance.Insert(medicalQcMsg);
                }
                qcCheckResult.MSG_ID = medicalQcMsg.MSG_ID;
                shRet = QcCheckResultAccess.Instance.Update(qcCheckResult);
            }
            if (shRet == SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowMessage("发送成功");
                this.lbl_NOTICE_STATUS.Text = SystemData.NotifyStatus.GetCnName(qcModifyNotice.NOTICE_STATUS);
                this.lbl_NOTICE_STATUS.ForeColor = Color.Blue;
                this.herenButton1.Text = "修改整改通知单";
            }
        }
        /// <summary>
        /// 修改整改通知书
        /// </summary>
        private void UpdateModifyNotice(QcModifyNotice qcModifyNotice)
        {
            
            qcModifyNotice.MODIFY_PERIOD = this.cbo_MODIFY_PERIOD.Text;
            qcModifyNotice.MODIFY_REMARK = this.rtb_MODIFY_REMARK.Text;
            qcModifyNotice.MODIFY_SCORE = float.Parse(this.lbl_MODIFY_SCORE.Text);
            qcModifyNotice.NOTICE_TIME = DateTime.Parse(this.lbl_NOTICE_TIME.Text);
            qcModifyNotice.PATIENT_ID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            qcModifyNotice.QC_DEPT_CODE = SystemParam.Instance.UserInfo.DEPT_CODE;
            qcModifyNotice.QC_DEPT_NAME = SystemParam.Instance.UserInfo.DEPT_NAME;
            qcModifyNotice.QC_LEVEL = SystemData.QcLevel.GetCodeByMrStatus(SystemParam.Instance.PatVisitInfo.MR_STATUS);
            qcModifyNotice.QC_MAN = SystemParam.Instance.UserInfo.USER_NAME;
            qcModifyNotice.QC_MAN_ID = SystemParam.Instance.UserInfo.USER_ID;
            qcModifyNotice.RECEIVER = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR;
            qcModifyNotice.RECEIVER_ID = SystemParam.Instance.PatVisitInfo.INCHARGE_DOCTOR_ID;
            qcModifyNotice.RECEIVER_DEPT_CODE = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
            qcModifyNotice.RECEIVER_DEPT_NAME = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
            qcModifyNotice.VISIT_ID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            qcModifyNotice.VISIT_NO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            qcModifyNotice.NOTICE_STATUS = SystemData.NotifyStatus.Sended;
            qcModifyNotice.NOTICE_TIME = SysTimeHelper.Instance.Now;
            short shRet = QcModifyNoticeAccess.Instance.Update(qcModifyNotice);
            //更新人工质控和质检信息 更新人工质控责任医生和责任科室，同步更新反馈消息
            foreach (DataGridViewRow item in this.dataTableView1.Rows)
            {
                QcCheckResult qcCheckResult = item.Tag as QcCheckResult;
                qcCheckResult.MODIFY_NOTICE_ID = qcModifyNotice.MODIFY_NOTICE_ID;
                MedicalQcMsg medicalQcMsg = item.Cells[this.col_MSG_ID.Index].Tag as MedicalQcMsg;
                UserInfo userInfo = item.Cells[this.col_INCHARGE_DOCTOR.Index].Tag as UserInfo;
                if (userInfo != null)
                {
                    qcCheckResult.DEPT_CODE = userInfo.DEPT_CODE;
                    qcCheckResult.DEPT_IN_CHARGE = userInfo.DEPT_NAME;
                    qcCheckResult.INCHARGE_DOCTOR = userInfo.USER_NAME;
                    qcCheckResult.INCHARGE_DOCTOR_ID = userInfo.USER_ID;
                }
                if (medicalQcMsg == null)
                {
                    medicalQcMsg = this.ToQcMsg(qcCheckResult);
                    shRet = MedicalQcMsgAccess.Instance.Insert(medicalQcMsg);
                    item.Cells[this.col_MSG_ID.Index].Tag = medicalQcMsg;
                }
                else
                {
                    if (userInfo != null)
                    {
                        medicalQcMsg.DEPT_STAYED = userInfo.DEPT_CODE;
                        medicalQcMsg.DEPT_NAME = userInfo.DEPT_NAME;
                        medicalQcMsg.DOCTOR_IN_CHARGE = userInfo.USER_NAME;
                        medicalQcMsg.DOCTOR_IN_CHARGE_ID = userInfo.USER_ID;
                        shRet = MedicalQcMsgAccess.Instance.Update(medicalQcMsg);
                    }
                }
                qcCheckResult.MSG_ID = medicalQcMsg.MSG_ID;
                shRet = QcCheckResultAccess.Instance.Update(qcCheckResult);

            }
            if (shRet == SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowMessage("修改成功");
                this.lbl_NOTICE_STATUS.Text = SystemData.NotifyStatus.GetCnName(qcModifyNotice.NOTICE_STATUS);
                this.lbl_NOTICE_TIME.Text = this.m_QcModifyNotice.NOTICE_TIME.ToString("yyyy-MM-dd HH:mm");
                this.lbl_NOTICE_STATUS.ForeColor = Color.Blue;
            }
            this.Tag = qcModifyNotice;
        }
        private void herenButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dataTableView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dataTableView1.CurrentCell.ColumnIndex == this.col_INCHARGE_DOCTOR.Index)
            {
                FindComboBoxEditingControl control = (e.Control as FindComboBoxEditingControl);
                control.SelectedIndexChanged -= new EventHandler(colRight_SelectedIndexChanged);
                control.SelectedIndexChanged += new EventHandler(colRight_SelectedIndexChanged);
            }
        }
        private void colRight_SelectedIndexChanged(object sender, EventArgs e)
        {

            Heren.Common.Controls.TableView.FindComboBoxEditingControl control = sender as Heren.Common.Controls.TableView.FindComboBoxEditingControl;
            if (control.SelectedItem != null)
            {
                UserInfo userInfo = control.SelectedItem as UserInfo;
                QcCheckResult qcCheckResult = this.dataTableView1.CurrentRow.Tag as QcCheckResult;
                if (qcCheckResult == null)
                    return;
                qcCheckResult.INCHARGE_DOCTOR = userInfo.USER_NAME;
                qcCheckResult.INCHARGE_DOCTOR_ID = userInfo.USER_ID;
                qcCheckResult.DEPT_CODE = userInfo.DEPT_CODE;
                qcCheckResult.DEPT_IN_CHARGE = userInfo.DEPT_NAME;
                this.dataTableView1.CurrentRow.Cells[this.col_DEPT_IN_CHARGE.Index].Value = userInfo.DEPT_NAME;
                this.dataTableView1.CurrentRow.Cells[this.col_INCHARGE_DOCTOR.Index].Value = userInfo.USER_ID;
                this.dataTableView1.CurrentRow.Cells[this.col_INCHARGE_DOCTOR.Index].Tag = userInfo;
            }
        }
        /// <summary>
        /// 绑定
        /// </summary>
        private void LoadGridComboBoxItem()
        {

            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitNO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
            List<UserInfo> lstUserInfos = null;
            short shRet = EmrDocAccess.Instance.GetInchargeDoctorList(szPatientID, szVisitNO, ref lstUserInfos);
            this.col_INCHARGE_DOCTOR.Items.Clear();
            if (lstUserInfos == null)
                return;
            foreach (UserInfo item in lstUserInfos)
            {
                this.col_INCHARGE_DOCTOR.Items.Add(item);
            }
        }
    }
}
