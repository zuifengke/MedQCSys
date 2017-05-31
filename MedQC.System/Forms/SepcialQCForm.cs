// ***********************************************************
// 病案质控系统患者抽检分配信息对话框.
// Creator:yehui  Date:2014-02-09
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
using EMRDBLib;

using MedQCSys.Dialogs;
using EMRDBLib.DbAccess;
using Heren.MedQC.Utilities;
using MedQCSys.DockForms;
using MedQCSys;

namespace Heren.MedQC.Systems
{
    public partial class SpecialQCForm : DockContentBase
    {
        private EMRDBLib.QcSpecialCheck m_QcSpecialCheck = null;
        public EMRDBLib.QcSpecialCheck QcSpecialCheck
        {
            get
            {
                if (this.m_QcSpecialCheck == null)
                    this.m_QcSpecialCheck = new QcSpecialCheck();
                return this.m_QcSpecialCheck;
            }
            set
            {
                this.m_QcSpecialCheck = value;
            }
        }
        public bool IsNew = false;
        public SpecialQCForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (string.IsNullOrEmpty(this.QcSpecialCheck.ConfigID))
                this.IsNew = true;
            if (!this.IsNew)
            {
                //this.tooldtpDateFrom.Enabled = false;
                //this.tooldtpDateTo.Enabled = false;
                //this.toolcboDischargeMode.Enabled = false;
                //this.toolcboPatientCondition.Enabled = false;
                //this.tooltbPerCount.Enabled = false;
                this.button1.Enabled = false;//修改和查看时，不允许再抽取病历
                this.dtpBeginTime.Value = this.m_QcSpecialCheck.StartTime;
                this.dtpEndTime.Value = this.m_QcSpecialCheck.EndTime;
                this.cboDischargeMode.Text = this.m_QcSpecialCheck.DischargeMode;
                this.cboPatientCondition.Text = this.m_QcSpecialCheck.PatientCondition;
                this.txtName.Text = this.m_QcSpecialCheck.Name;
                this.numCount.Text = this.m_QcSpecialCheck.PerCount.ToString();
                this.InitCurQCSpecialDeTail();
            }
            else
            {
                this.dtpBeginTime.Value = SysTimeHelper.Instance.Now.AddMonths(-1);
                this.dtpEndTime.Value = SysTimeHelper.Instance.Now; 
                this.InitComBoxData();
            }
        }

        private void InitComBoxData()
        {
            this.InitDeptData();
            this.InitUserList();
        }

        private void InitUserList()
        {
            this.Update();
            this.ShowStatusMessage("正在下载用户列表，请稍候...");

            List<UserInfo> lstUserInfo = null;
            if (UserAccess.Instance.GetAllUserInfos(ref lstUserInfo) != EMRDBLib.SystemData.ReturnValue.OK)
            {
                this.ShowStatusMessage(null);
                MessageBoxEx.Show("用户列表下载失败！");
                return;
            }
            if (lstUserInfo == null || lstUserInfo.Count <= 0)
            {
                this.ShowStatusMessage(null);
                return;
            }
            for (int index = 0; index < lstUserInfo.Count; index++)
            {
                UserInfo userInfo = lstUserInfo[index];
                string szInputCode = GlobalMethods.Convert.GetInputCode(userInfo.Name, false, 10);
                this.cobRequestDoc.Items.Add(userInfo);
                this.cobParentDoc.Items.Add(userInfo);
            }
            this.cobRequestDoc.Items.Insert(0, string.Empty);
            this.cobParentDoc.Items.Insert(0, string.Empty);
            this.ShowStatusMessage(null);
        }

        private void InitDeptData()
        {
            this.Update();
            this.ShowStatusMessage("正在下载临床科室列表，请稍候...");
            if (!InitControlData.InitCboDeptName(ref this.cobDeptName))
            {
                MessageBoxEx.Show("下载科室列表失败");
            }
            this.ShowStatusMessage(null);
        }
        /// <summary>
        /// 初始化当前次病案抽检分配详情信息
        /// </summary>
        private void InitCurQCSpecialDeTail()
        {
            this.dataGridView1.Rows.Clear();
            this.dgvDetailList.Rows.Clear();
            if (this.m_QcSpecialCheck == null || string.IsNullOrEmpty(this.m_QcSpecialCheck.ConfigID))
                return;
            string szConfigID = this.m_QcSpecialCheck.ConfigID;
            List<QcSpecialDetail> lstQcSpecialDetail = null;
            short shRet = SpecialAccess.Instance.GetQCSpecialDetailList(szConfigID, ref lstQcSpecialDetail);
            if (shRet !=  SystemData.ReturnValue.OK)
                return;
            string szPreSpecialID = string.Empty;
            int detailIndex = 0;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            /// 获三级医生信息
            List<EMRDBLib.PatDoctorInfo> lstPatDoctorInfos = new List<EMRDBLib.PatDoctorInfo>();
            foreach (QcSpecialDetail item in lstQcSpecialDetail)
            {
                if (szPreSpecialID != item.SpecialID)
                {

                    Specialist specialist = new Specialist();
                    specialist.UserID = item.SpecialID;
                    specialist.UserName = item.SpecialName;
                    szPreSpecialID = item.SpecialID;
                    detailIndex = this.dgvDetailList.Rows.Add();
                    this.dgvDetailList.Rows[detailIndex].Cells[this.colUserName.Index].Value = item.SpecialName;
                    this.dgvDetailList.Rows[detailIndex].Tag = specialist;
                    List<PatVisitInfo> lstPatVisitLog = new List<PatVisitInfo>();
                    this.dgvDetailList.Rows[detailIndex].Cells[this.colPatientCount.Index].Tag = lstPatVisitLog;
                    this.dgvDetailList.Rows[detailIndex].Cells[this.colPatientCount.Index].Value = lstPatVisitLog.Count.ToString();
                }

                PatVisitInfo patVisitLog = null;
                shRet = SpecialAccess.Instance.GetPatVisitInfo(item.PatientID, item.VisitID, ref patVisitLog);
                if (patVisitLog == null)
                    continue;
                //三级医生信息
                EMRDBLib.PatDoctorInfo patDoctorInfo = new EMRDBLib.PatDoctorInfo();
                patDoctorInfo.PatientID = patVisitLog.PATIENT_ID;
                patDoctorInfo.VisitID = patVisitLog.VISIT_ID;
                lstPatDoctorInfos.Add(patDoctorInfo);

                if (shRet !=  SystemData.ReturnValue.OK)
                    continue;

                int rowIndex = this.dataGridView1.Rows.Add();
                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                this.SetRowData(row, patVisitLog);
                Specialist detailSpecial = this.dgvDetailList.Rows[detailIndex].Tag as Specialist;
                row.Cells[this.colSpecialistName.Index].Tag = detailSpecial;
                row.Cells[this.colSpecialistName.Index].Value = item.SpecialName;
                if (this.dataGridView1.Rows.Count <= 20)
                    this.dataGridView1.Update();
                List<PatVisitInfo> lstPatVisitLogDetail = this.dgvDetailList.Rows[detailIndex].Cells[this.colPatientCount.Index].Tag as List<PatVisitInfo>;
                if (lstPatVisitLogDetail == null)
                    lstPatVisitLogDetail = new List<PatVisitInfo>();
                lstPatVisitLogDetail.Add(patVisitLog);
                this.dgvDetailList.Rows[detailIndex].Cells[this.colPatientCount.Index].Value = lstPatVisitLogDetail.Count.ToString();
            }
            this.UpdateInchargeDoctor(lstPatDoctorInfos);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        private void toolbtnPreview_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 绑定患者病情
        /// </summary>
        /// <param name="lstPatVisitLog"></param>
        private void BindPatientCondition(List<PatVisitInfo> lstPatVisitLog)
        {
            if (!string.IsNullOrEmpty(this.cboPatientCondition.Text))
            {
                string szCondition = this.cboPatientCondition.Text;
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    row.Cells[this.colPatientCondition.Index].Value = szCondition;
                }
                return;
            }
            //查询病情
            short shRet = PatVisitAccess.Instance.GetOutPatientCondition(lstPatVisitLog);
            if (shRet !=  SystemData.ReturnValue.OK
                )
                return;
            if (lstPatVisitLog == null || lstPatVisitLog.Count == 0)
                return;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                EMRDBLib.PatVisitInfo patVistiLog = row.Tag as EMRDBLib.PatVisitInfo;
                if (patVistiLog == null)
                    continue;
                EMRDBLib.PatVisitInfo patVisitLog2 = lstPatVisitLog.Find(delegate(EMRDBLib.PatVisitInfo p)
                {
                    if (p.PATIENT_ID == patVistiLog.PATIENT_ID && p.VISIT_ID == patVistiLog.VISIT_ID)
                        return true;
                    else
                        return false;
                });
                if (patVisitLog2 != null)
                {
                    row.Cells[this.colPatientCondition.Index].Value = patVisitLog2.PATIENT_CONDITION;
                }
            }
        }

        private string GetPARENT_DOCTORID()
        {
            if (this.cobParentDoc == null || this.cobParentDoc.SelectedItem == null
                || string.IsNullOrEmpty(this.cobParentDoc.Text))
                return string.Empty;
           UserInfo userInfo = this.cobParentDoc.SelectedItem as UserInfo;
            return userInfo.ID;
        }

        private string GetRequestDoctorID()
        {
            if (this.cobRequestDoc == null || this.cobRequestDoc.SelectedItem == null
                || string.IsNullOrEmpty(this.cobRequestDoc.Text))
                return string.Empty;
            UserInfo userInfo = this.cobRequestDoc.SelectedItem as UserInfo;
            return userInfo.ID;
        }

        private  DeptInfo GetSelectecDeptInfo()
        {
            if (this.cobDeptName == null || this.cobDeptName.SelectedItem == null
                || string.IsNullOrEmpty(this.cobDeptName.Text))
                return null;
             DeptInfo deptInfo = this.cobDeptName.SelectedItem as  DeptInfo;
            return deptInfo;
        }

        private void ShowStatusMessage(string szMessage)
        {
            if (MainForm != null || !MainForm.IsDisposed)
                MainForm.ShowStatusMessage(szMessage);
        }
        /// <summary>
        /// 将数据信息加载到DataGridView中
        /// </summary>
        /// <param name="row"></param>
        /// <param name="qcWorkloadStatInfo"></param>
        private void SetRowData(DataGridViewRow row, EMRDBLib.PatVisitInfo patVisitLog)
        {
            if (row == null || patVisitLog == null)
                return;
            if (row.DataGridView == null)
                return;
            row.Cells[this.colSpecialistName.Index].Value = string.Empty;
            row.Cells[this.colPatientName.Index].Value = patVisitLog.PATIENT_NAME;
            row.Cells[this.colPatientID.Index].Value = patVisitLog.PATIENT_ID;
            row.Cells[this.colVisitID.Index].Value = patVisitLog.VISIT_ID;
            row.Cells[this.colVisitTime.Index].Value = patVisitLog.VISIT_TIME.ToString("yyyy-MM-dd");
            row.Cells[this.colDischargeTime.Index].Value = patVisitLog.DISCHARGE_TIME.ToString("yyyy-MM-dd");
            row.Cells[this.colDept.Index].Value = patVisitLog.DEPT_NAME;
            row.Cells[this.colPatientCondition.Index].Value = patVisitLog.PATIENT_CONDITION;
            row.Cells[this.colDischargeMode.Index].Value = patVisitLog.DISCHARGE_MODE;
            row.Tag = patVisitLog;
        }

        /// <summary>
        /// 三级医生信息从历史表里读取
        /// </summary>
        /// <param name="lstPatDoctorInfos"></param>
        /// <returns></returns>
        private void UpdateInchargeDoctor(List<EMRDBLib.PatDoctorInfo> lstPatDoctorInfos)
        {
            //有选择经治医生，直接绑定
             UserInfo userInfo = this.cobRequestDoc.SelectedItem as  UserInfo;
            if (userInfo != null)
            {
                foreach (DataGridViewRow row in this.dataGridView1.Rows)
                {
                    row.Cells[this.colDoctor.Index].Value = userInfo.Name;
                }
            }

            //一次查询一批患者的三级患者信息
            //获取三级医生信息
            if (lstPatDoctorInfos == null)
                return;
            short shRet = PatVisitAccess.Instance.GetPatSanjiDoctors(ref lstPatDoctorInfos);
            if (shRet != EMRDBLib.SystemData.ReturnValue.OK)
                return;
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                EMRDBLib.PatVisitInfo patVistiLog = row.Tag as EMRDBLib.PatVisitInfo;
                if (patVistiLog == null)
                    continue;
                EMRDBLib.PatDoctorInfo patDoctorInfo = lstPatDoctorInfos.Find(delegate(EMRDBLib.PatDoctorInfo p)
                {
                    if (p.PatientID == patVistiLog.PATIENT_ID && p.VisitID == patVistiLog.VISIT_ID)
                        return true;
                    else
                        return false;
                });
                if (patDoctorInfo != null)
                {
                    row.Cells[this.colDoctor.Index].Value = patDoctorInfo.RequestDoctorName;
                }
            }
        }

        private void tsbSelect_Click(object sender, EventArgs e)
        {

            SpecialDoctorForm form = new SpecialDoctorForm(this);
            if (form.ShowDialog() != DialogResult.OK)
                return;
            if (form.SelectedSpecial == null
                || form.SelectedSpecial.Count <= 0)
                return;
            foreach (Specialist item in form.SelectedSpecial)
            {
                if (this.dgvDetailList.Rows.Count >= 0)
                {
                    bool bExist = false;
                    foreach (DataGridViewRow row1 in this.dgvDetailList.Rows)
                    {
                        Specialist specialist = row1.Tag as Specialist;
                        if (specialist == null)
                            continue;
                        if (specialist.UserID == item.UserID)
                        {
                            bExist = true;
                            break;
                        }
                    }
                    //已存在专家，则不需要添加到列表中
                    if (bExist)
                        continue;
                }
                int rowIndex = this.dgvDetailList.Rows.Add();
                DataGridViewRow row = this.dgvDetailList.Rows[rowIndex];
                row.Tag = item;
                row.Cells[this.colUserName.Index].Value = item.UserName;
                row.Cells[this.colPatientCount.Index].Value = "0";
                row.Cells[this.colPatientCount.Index].Tag = new List<PatVisitInfo>();
            }
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvDetailList.SelectedRows.Count <= 0)
            {
                MessageBoxEx.ShowMessage("未选择人员");
                return;
            }
            this.dgvDetailList.Rows.Remove(this.dgvDetailList.SelectedRows[0]);
        }

        private void tooltbPatientCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((ToolStripTextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((ToolStripTextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            PatVisitInfo patVisitLog = row.Tag as PatVisitInfo;
            Specialist specialist = this.dataGridView1.Rows[e.RowIndex].Cells[this.colSpecialistName.Index].Tag as Specialist;
            if (specialist == null)
            {
                this.AddPatVisitLog(row);
            }
            else if (specialist == (this.dgvDetailList.SelectedRows.Count > 0 ? this.dgvDetailList.SelectedRows[0].Tag as Specialist : null))
            {
                this.RemovePatVisitLog(row);
            }
            else
            {
                this.RemovePatVisitLog(row);
                this.AddPatVisitLog(row);
            }

        }

        /// <summary>
        /// 取消病案分配
        /// </summary>
        /// <param name="patRow"></param>
        private void RemovePatVisitLog(DataGridViewRow patRow)
        {
            if (patRow.Cells[this.colSpecialistName.Index].Tag == null)
            {
                return;
            }
            Specialist specialist = patRow.Cells[this.colSpecialistName.Index].Tag as Specialist;
            foreach (DataGridViewRow row in this.dgvDetailList.Rows)
            {
                if (specialist == (row.Tag as Specialist))
                {
                    patRow.Cells[this.colSpecialistName.Index].Tag = null;
                    patRow.Cells[this.colSpecialistName.Index].Value = string.Empty;
                    patRow.DefaultCellStyle.BackColor = Color.White;
                    List<PatVisitInfo> lstPatVisitLog = row.Cells[this.colPatientCount.Index].Tag as List<PatVisitInfo>;
                    PatVisitInfo patVisitLog = patRow.Tag as PatVisitInfo;
                    if (patVisitLog != null)
                    {
                        lstPatVisitLog.Remove(patVisitLog);
                    }
                    row.Cells[this.colPatientCount.Index].Value = lstPatVisitLog.Count.ToString();
                    break;
                }
            }
        }

        /// <summary>
        /// 分配病案
        /// </summary>
        /// <param name="patRow"></param>
        private void AddPatVisitLog(DataGridViewRow patRow)
        {
            PatVisitInfo patVisitLog = patRow.Tag as PatVisitInfo;
            if (this.dgvDetailList.SelectedRows.Count <= 0)
            {
                MessageBoxEx.Show("分配病案时请选择病案专家");
                return;
            }
            Specialist specialist = this.dgvDetailList.SelectedRows[0].Tag as Specialist;
            if (specialist == null)
            {
                MessageBoxEx.Show("读取病案专家信息失败");
                return;
            }
            patRow.Cells[this.colSpecialistName.Index].Tag = specialist;
            patRow.Cells[this.colSpecialistName.Index].Value = specialist.UserName;
            patRow.DefaultCellStyle.BackColor = Color.LightGray;

            List<PatVisitInfo> lstPatVisitLog = this.dgvDetailList.SelectedRows[0].Cells[this.colPatientCount.Index].Tag as List<PatVisitInfo>;
            if (lstPatVisitLog == null)
                lstPatVisitLog = new List<PatVisitInfo>();
            lstPatVisitLog.Add(patVisitLog);
            this.dgvDetailList.SelectedRows[0].Cells[this.colPatientCount.Index].Value = lstPatVisitLog.Count.ToString();
        }

        private void dgvDetailList_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvDetailList.SelectedRows == null || this.dgvDetailList.SelectedRows.Count == 0)
                return;
            DataGridViewRow row = this.dgvDetailList.SelectedRows[0];
            Specialist specialist = this.dgvDetailList.SelectedRows[0].Tag as Specialist;
            if (specialist == null)
                return;
            foreach (DataGridViewRow item in this.dataGridView1.Rows)
            {
                if (specialist == (item.Cells[this.colSpecialistName.Index].Tag as Specialist))
                {
                    item.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    item.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void tsbSaveResult_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 检查分配情况，移除分配数量为0的医生
        /// </summary>
        private void CheckdgvDetailInfos()
        {
            if (dgvDetailList == null || dgvDetailList.Rows == null || dgvDetailList.Rows.Count == 0)
                return;
            for (int index = dgvDetailList.Rows.Count - 1; index >=0; index--)
            {
                if (dgvDetailList.Rows[index].Cells[this.colPatientCount.Index].Value.ToString() == "0")
                {
                    dgvDetailList.Rows.RemoveAt(index);
                }
            }
        }

        private void txtInDaysBegin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }
        }

        private void txtInDaysEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20) e.KeyChar = (char)0;  //禁止空格键  
            if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) return;   //处理负数  
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((TextBox)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //处理非法字符  
                }
            }
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                MessageBoxEx.ShowWarning("请设置本次抽检名称");
                this.txtName.Focus();
                return;
            }
            if (this.numCount.Value==0)
            {
                MessageBoxEx.ShowWarning("请输入每科室抽检的病案数");
                this.numCount.Focus();
                return;
            }
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.ShowWarning("未抽检出病案信息");
                return;
            }
            if (this.dgvDetailList.Rows.Count <= 0)
            {
                MessageBoxEx.ShowWarning("请选择专家！");
                return;
            }
            if (this.m_QcSpecialCheck == null || this.m_QcSpecialCheck.ConfigID == string.Empty)
            {
                this.m_QcSpecialCheck = new QcSpecialCheck();
                this.m_QcSpecialCheck.ConfigID = this.m_QcSpecialCheck.MakeConfigID();
                this.m_QcSpecialCheck.Creater = SystemParam.Instance.UserInfo.Name;
                this.m_QcSpecialCheck.CreateTime = DateTime.Now;
            }
            this.m_QcSpecialCheck.Name = this.txtName.Text.Trim();
            this.m_QcSpecialCheck.DischargeMode = this.cboDischargeMode.Text.Trim();
            this.m_QcSpecialCheck.PatientCondition = this.cboPatientCondition.Text.Trim();
            this.m_QcSpecialCheck.PatientCount = this.dataGridView1.Rows.Count;
            this.m_QcSpecialCheck.PerCount = int.Parse(this.numCount.Text);
            this.CheckdgvDetailInfos();//移除分配为0份病案的专家
            this.m_QcSpecialCheck.SpecialCount = this.dgvDetailList.Rows.Count;
            this.m_QcSpecialCheck.StartTime = this.dtpBeginTime.Value;
            this.m_QcSpecialCheck.EndTime = this.dtpEndTime.Value;
            short shRet =  SystemData.ReturnValue.OK;
            if (this.IsNew)
            {
                shRet = SpecialAccess.Instance.SaveQCSpecialCheck(this.m_QcSpecialCheck);
                if (shRet !=  SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowError("保存失败");
                    this.m_QcSpecialCheck = null;
                    return;
                }
            }
            else
            {
                shRet = SpecialAccess.Instance.UpdateQCSpecialCheck(this.m_QcSpecialCheck);
                if (shRet != EMRDBLib.SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowError("保存失败");
                    return;
                }
            }
            //保存专家质控病案分配详情信息
            //先删除之前的配置信息
            if (!this.IsNew)
            {
                shRet = SpecialAccess.Instance.DeleteQCSpecialDetail(this.m_QcSpecialCheck.ConfigID);
            }
            //再保存分配信息
            for (int detailIndex = 0; detailIndex < this.dgvDetailList.Rows.Count; detailIndex++)
            {
                DataGridViewRow detailRow = this.dgvDetailList.Rows[detailIndex];
                List<PatVisitInfo> lstPatVisitLog = detailRow.Cells[this.colPatientCount.Index].Tag as List<PatVisitInfo>;
                Specialist specialist = detailRow.Tag as Specialist;
                if (specialist == null)
                    continue;
                if (lstPatVisitLog == null || lstPatVisitLog.Count <= 0)
                    continue;
                foreach (PatVisitInfo item in lstPatVisitLog)
                {
                    QcSpecialDetail qcSpecialDetail = new QcSpecialDetail();
                    qcSpecialDetail.ConfigID = this.m_QcSpecialCheck.ConfigID;
                    qcSpecialDetail.PatientID = item.PATIENT_ID;
                    qcSpecialDetail.VisitID = item.VISIT_ID;
                    qcSpecialDetail.SpecialID = specialist.UserID;
                    qcSpecialDetail.SpecialName = specialist.UserName;
                    shRet = SpecialAccess.Instance.SaveQCSpecialDetail(qcSpecialDetail);
                    if (shRet != EMRDBLib.SystemData.ReturnValue.OK)
                    {
                        MessageBoxEx.ShowError("病案分配详情保存失败！");
                        return;
                    }
                }
            }
            MessageBoxEx.ShowMessage("保存成功");
            this.IsNew = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在查询数据，请稍候...");
            this.dataGridView1.Rows.Clear();
            this.dgvDetailList.Rows.Clear();
            string szPatientCondition = this.cboPatientCondition.Text;
            string szDischargeMode = this.cboDischargeMode.Text;
            string szPatientCount = this.numCount.Text;
            string szInDaysBegin = this.txtInDaysBegin.Text.Trim();
            string szInDaysEnd = this.txtInDaysEnd.Text.Trim();
            string szRequestDoctorID = this.GetRequestDoctorID();
            string szPARENT_DOCTORID = this.GetPARENT_DOCTORID();
            if (string.IsNullOrEmpty(szPatientCount))
            {
                MessageBoxEx.ShowMessage("请输入每科室抽取的病案数量");
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }
            if (this.dtpBeginTime.Value == null || this.dtpEndTime.Value == null)
            {
                MessageBoxEx.ShowMessage("请选择出院时间段");
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                return;
            }

            DateTime dtStartTime = new DateTime(this.dtpBeginTime.Value.Year,
                this.dtpBeginTime.Value.Month,
                this.dtpBeginTime.Value.Day, 0, 0, 0);
            DateTime dtEndTime = new DateTime(this.dtpEndTime.Value.Year,
                this.dtpEndTime.Value.Month,
                this.dtpEndTime.Value.Day, 23, 59, 59);
            //如果没有选择科室就全部抽取
             DeptInfo selectedDeptInfo = this.GetSelectecDeptInfo();
            //获取所有的就诊科室
            List< DeptInfo> lstDeptInfo = new List< DeptInfo>();
            short shRet = 0;
            if (selectedDeptInfo == null)
            {
                shRet = EMRDBAccess.Instance.GetClinicDeptList(ref lstDeptInfo);
                if (shRet !=  SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.Show("获取科室列表失败");
                    return;
                }
            }
            else
            {
                lstDeptInfo.Add(selectedDeptInfo);
            }

            WorkProcess.Instance.Initialize(this, lstDeptInfo.Count, "正在随机抽取患者数据...");
            for (int index = 0; index <= lstDeptInfo.Count - 1; index++)
            {
                if (WorkProcess.Instance.Canceled)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    WorkProcess.Instance.Close();
                    this.ShowStatusMessage(null);
                    return;
                }
                 DeptInfo item = lstDeptInfo[index];
                WorkProcess.Instance.Show(index + 1, true);
                string szDeptCode = item.DEPT_CODE;
                List<PatVisitInfo> lstPatVisitLog = null;

                shRet = SpecialAccess.Instance.GetPatientList(szPatientCondition, szDischargeMode, szDeptCode, dtStartTime, dtEndTime, szPatientCount,
                    szInDaysBegin, szInDaysEnd, szRequestDoctorID, szPARENT_DOCTORID, ref lstPatVisitLog);
                if (shRet ==  SystemData.ReturnValue.RES_NO_FOUND)
                    continue;
                if (shRet !=  SystemData.ReturnValue.OK)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    WorkProcess.Instance.Close();
                    this.ShowStatusMessage(null);
                    MessageBoxEx.Show("查询数据失败！");
                    return;
                }
                if (lstPatVisitLog == null || lstPatVisitLog.Count <= 0)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    WorkProcess.Instance.Close();
                    this.ShowStatusMessage(null);
                    MessageBoxEx.Show("没有符合条件的数据！", MessageBoxIcon.Information);
                    return;
                }
                /// 获三级医生信息
                List<EMRDBLib.PatDoctorInfo> lstPatDoctorInfos = new List<EMRDBLib.PatDoctorInfo>();
                for (int patindex = 0; patindex < lstPatVisitLog.Count; patindex++)
                {
                    PatVisitInfo patVisitLog = lstPatVisitLog[patindex];
                    int nRowIndex = this.dataGridView1.Rows.Add();
                    DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                    this.SetRowData(row, patVisitLog);
                    if (this.dataGridView1.Rows.Count <= 40)
                    {
                        this.dataGridView1.Update();
                    }
                    EMRDBLib.PatDoctorInfo patDoctorInfo = new EMRDBLib.PatDoctorInfo();
                    patDoctorInfo.PatientID = patVisitLog.PATIENT_ID;
                    patDoctorInfo.VisitID = patVisitLog.VISIT_ID;
                    lstPatDoctorInfos.Add(patDoctorInfo);
                }
                //绑定三级医生信息
                this.UpdateInchargeDoctor(lstPatDoctorInfos);
                //绑定患者病情
                this.BindPatientCondition(lstPatVisitLog);
            }

            WorkProcess.Instance.Close();
            this.ShowStatusMessage(string.Format("共抽取出{0}位患者", this.dataGridView1.Rows.Count.ToString()));
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}