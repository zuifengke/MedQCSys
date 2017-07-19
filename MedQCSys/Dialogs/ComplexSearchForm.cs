using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Heren.Common.Libraries;
using EMRDBLib;
using EMRDBLib.DbAccess;

namespace MedQCSys.Dialogs
{
    public partial class ComplexSearchForm : Form
    {
        public ComplexSearchForm()
        {
            InitializeComponent();
            InitTimeControl();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            DateTime now = DateTime.Now;
            this.InitDeptList();
            this.InitOperationList();
            this.InitLabReportDict();
            this.InitChargeTypeDictList();
            this.InitIdentityDictList();
            this.SetControlVisible();
        }

        private void InitTimeControl()
        {
            this.dtpVisitTimeBegin.Value = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00"));
            this.dtpVisitTimeEnd.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
            this.dtpDischargeTimeBegin.Value = DateTime.Parse(DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd 00:00:00"));
            this.dtpDischargeTimeEnd.Value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
        }
        /// <summary>
        /// 初始化费别列表
        /// </summary>
        private void InitChargeTypeDictList()
        {
            if (this.cboChargeType == null || this.cboChargeType.IsDisposed)
                return;
            if (this.cboChargeType.Items.Count > 0)
                return;
            //加载科室列表
            List<ChargeTypeDictInfo> lstChargeTypeDictInfos = null;
            if (EMRDBAccess.Instance.GetChargeTypeDictInfos(ref lstChargeTypeDictInfos) != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("费别列表下载失败！");
                return;
            }
            if (lstChargeTypeDictInfos == null || lstChargeTypeDictInfos.Count <= 0)
            {
                return;
            }
            for (int index = 0; index < lstChargeTypeDictInfos.Count; index++)
            {
                ChargeTypeDictInfo chargeTypeDictInfo = lstChargeTypeDictInfos[index];
                this.cboChargeType.Items.Add(chargeTypeDictInfo);
            }
        }
        /// <summary>
        /// 初始化身份列表
        /// </summary>
        private void InitIdentityDictList()
        {
            if (this.cboIdentity == null || this.cboIdentity.IsDisposed)
                return;
            if (this.cboIdentity.Items.Count > 0)
                return;
            //加载科室列表
            List<IDentityDictInfo> lstIDentityDictInfos = null;
            if (EMRDBAccess.Instance.GetIdentityDictInfos(ref lstIDentityDictInfos) != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("身份列表下载失败！");
                return;
            }
            if (lstIDentityDictInfos == null || lstIDentityDictInfos.Count <= 0)
            {
                return;
            }
            for (int index = 0; index < lstIDentityDictInfos.Count; index++)
            {
                IDentityDictInfo iDentityDictInfo = lstIDentityDictInfos[index];
                this.cboIdentity.Items.Add(iDentityDictInfo);
            }
        }
        /// <summary>
        /// 初始化住院科室列表
        /// </summary>
        private void InitDeptList()
        {
            if (this.cboDeptName == null || this.cboDeptName.IsDisposed)
                return;
            if (this.cboDeptName.Items.Count > 0)
                return;
            //加载科室列表
            List<DeptInfo> lstDeptInfos = null;
            if (EMRDBAccess.Instance.GetWardDeptList(ref lstDeptInfos) != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("临床科室列表下载失败！");
                return;
            }
            if (lstDeptInfos == null || lstDeptInfos.Count <= 0)
            {
                return;
            }
            for (int index = 0; index < lstDeptInfos.Count; index++)
            {
                DeptInfo deptInfo = lstDeptInfos[index];
                this.cboDeptName.Items.Add(deptInfo);
            }
        }

        /// <summary>
        /// 按手术患者检索，初始化手术名称列表
        /// </summary>
        private void InitOperationList()
        {
            if (this.fdCBXOperation == null || this.fdCBXOperation.IsDisposed)
                return;
            if (this.fdCBXOperation.Items.Count > 0)
                return;
            List<EMRDBLib.OperationDict> lstOperationDict = null;
            if (MedQCAccess.Instance.GetOperationDict(ref lstOperationDict) != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("手术名称列表下载失败!");
                return;
            }
            if (lstOperationDict == null || lstOperationDict.Count <= 0)
            {
                return;
            }
            for (int index = 0; index < lstOperationDict.Count; index++)
            {
                EMRDBLib.OperationDict operationDict = lstOperationDict[index];
                this.fdCBXOperation.Items.Add(operationDict);
            }
        }
        /// <summary>
        /// 初始化检验报告字典
        /// </summary>
        private void InitLabReportDict()
        {
            if (this.fcbLabReprotDict == null || this.fcbLabReprotDict.IsDisposed)
                return;
            if (this.fcbLabReprotDict.Items.Count > 0)
                return;
            List<EMRDBLib.LabReportDict> lstLabReportDict = null;
            if (MedQCAccess.Instance.GetLabReportDict(ref lstLabReportDict) != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("手术名称列表下载失败!");
                return;
            }
            if (lstLabReportDict == null || lstLabReportDict.Count <= 0)
            {
                return;
            }
            for (int index = 0; index < lstLabReportDict.Count; index++)
            {
                EMRDBLib.LabReportDict item = lstLabReportDict[index];
                this.fcbLabReprotDict.Items.Add(item);
            }
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            switch (chk.Name)
            {
                case "chkDept":
                    if (chk.Checked)
                        cboDeptName.ReadOnly = false;
                    else
                        cboDeptName.ReadOnly = true;
                    break;
                case "chkIdentity":
                    if (chk.Checked)
                        cboIdentity.ReadOnly = false;
                    else
                        cboIdentity.ReadOnly = true;
                    break;

                case "chkDoctor":
                    if (chk.Checked)
                        txtDoctor.ReadOnly = false;
                    else
                        txtDoctor.ReadOnly = true;
                    break;
                case "chkChargeType":
                    if (chk.Checked)
                        cboChargeType.ReadOnly = false;
                    else
                        cboChargeType.ReadOnly = true;
                    break;
                case "chkNursingClass":
                    if (chk.Checked)
                        cboNursingClass.ReadOnly = false;
                    else
                        cboNursingClass.ReadOnly = true;
                    break;
                case "chkDiagnosis":
                    if (chk.Checked)
                    {
                        this.chkOperation.Checked = false;
                        this.chkLabResult.Checked = false;
                        this.chkMutilOperation.Checked = false;
                        txtDiagnosis.ReadOnly = false;
                    }
                    else
                    {
                        txtDiagnosis.ReadOnly = true;
                    }
                    break;
                case "chkBirthTime":
                    if (chk.Checked)
                    {
                        this.numBeginAge.ReadOnly = false;
                        this.numEndAge.ReadOnly = false;
                    }
                    else
                    {

                        this.numBeginAge.ReadOnly = true;
                        this.numEndAge.ReadOnly = true;
                    }
                    break;
                case "chkOperation":
                    if (chk.Checked)
                    {
                        fdCBXOperation.ReadOnly = false;
                        this.chkDiagnosis.Checked = false;
                        this.chkLabResult.Checked = false;
                        this.chkMutilOperation.Checked = false;
                    }
                    else
                    {
                        fdCBXOperation.ReadOnly = true;
                    }
                    break;
                case "chkMutilOperation":
                    if (chk.Checked)
                    {
                        this.chkDiagnosis.Checked = false;
                        this.chkOperation.Checked = false;
                        this.chkLabResult.Checked = false;
                    }
                    break;
                case "chkLabResult":
                    if (chk.Checked)
                    {
                        this.chkDiagnosis.Checked = false;
                        this.chkOperation.Checked = false;
                        this.chkMutilOperation.Checked = false;
                        this.fcbLabReprotDict.ReadOnly = false;
                    }
                    else {
                        this.fcbLabReprotDict.ReadOnly = true;
                    }
                    break;
                case "chkPatientCondition":
                    if (chk.Checked)
                        cboPatientCondition.ReadOnly = false;
                    else
                        cboPatientCondition.ReadOnly = true;
                    break;

                case "chkVisitTime":
                    if (chk.Checked)
                    {
                        this.dtpVisitTimeBegin.Enabled = true;
                        this.dtpVisitTimeEnd.Enabled = true;
                    }
                    else
                    {
                        this.chkDischargeTime.Checked = true;
                        this.dtpVisitTimeBegin.Enabled = false;
                        this.dtpVisitTimeEnd.Enabled = false;
                    }
                    break;
                case "chkDischargeTime":
                    if (chk.Checked)
                    {
                        this.dtpDischargeTimeBegin.Enabled = true;
                        this.dtpDischargeTimeEnd.Enabled = true;
                    }
                    else
                    {
                        this.chkVisitTime.Checked = true;
                        this.dtpDischargeTimeBegin.Enabled = false;
                        this.dtpDischargeTimeEnd.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
        }
        private List<PatVisitInfo> m_lstPatVisitLog;
        public List<PatVisitInfo> LstPatVisitLog
        {
            get
            {
                if (this.m_lstPatVisitLog == null)
                    this.m_lstPatVisitLog = new List<PatVisitInfo>();
                return this.m_lstPatVisitLog;
            }
            set
            {
                this.m_lstPatVisitLog = value;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            string szDeptCode = string.Empty;
            string szPatientID = string.Empty;
            string szPatientName = string.Empty;
            string szIdentity = string.Empty;
            string szDiagnosis = string.Empty;
            string szDoctor = string.Empty;
            string szChargeType = string.Empty;
            string szNursingClass = string.Empty;
            string szBedCode = string.Empty;
            string szPatientCondition = string.Empty;
            string szOperationCount = string.Empty;
            string szStayInHospitalDays = string.Empty;
            string szOperationCode = string.Empty;
            string szPatientStatus = string.Empty;

            DateTime dtVisitTimeBegin = DateTime.Parse("1900-1-1");
            DateTime dtVisitTimeEnd = DateTime.Parse("1900-1-1");
            DateTime dtStartDischargeTime = DateTime.Parse("1900-1-1");
            DateTime dtEndDischargeTime = DateTime.Parse("1900-1-1");
            int nBeginAge = 0;
            int nEndAge = 0;
            if (this.chkDept.Checked && this.cboDeptName.SelectedItem != null)
                szDeptCode = (this.cboDeptName.SelectedItem as MDSDBLib.DeptInfo).DeptCode;
           
            if (this.chkIdentity.Checked && this.cboIdentity.SelectedItem != null)
                szIdentity = this.cboIdentity.SelectedItem.ToString();
            if (this.chkDiagnosis.Checked && this.txtDiagnosis.Text.Trim() != string.Empty)
                szDiagnosis = this.txtDiagnosis.Text.Trim();
            if (this.chkDoctor.Checked && this.txtDoctor.Text.Trim() != string.Empty)
                szDoctor = this.txtDoctor.Text.Trim();
            if (this.chkChargeType.Checked && this.cboChargeType.SelectedItem != null)
                szChargeType = this.cboChargeType.SelectedItem.ToString();
            if (this.chkNursingClass.Checked && this.cboNursingClass.SelectedItem != null)
                szNursingClass = this.cboNursingClass.SelectedItem.ToString();

            if (this.chkPatientCondition.Checked && this.cboPatientCondition.SelectedItem != null)
                szPatientCondition = this.cboPatientCondition.SelectedItem.ToString();
            if (this.chkBirthTime.Checked)
            {
                nBeginAge = int.Parse(this.numBeginAge.Value.ToString());
                nEndAge = int.Parse(this.numEndAge.Value.ToString());
                if (nBeginAge > nEndAge)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    MessageBox.Show("按年龄查询时，起始年龄不能大于结束年龄");
                    return;
                }
            }
            if (this.chkOperation.Checked && this.fdCBXOperation.SelectedItem != null)
                szOperationCode = (this.fdCBXOperation.SelectedItem as OperationDict).OperationCode;
            if (this.chkVisitTime.Checked)
            {
                dtVisitTimeBegin = this.dtpVisitTimeBegin.Value;
                dtVisitTimeEnd = this.dtpVisitTimeEnd.Value;
                if (dtVisitTimeBegin > dtVisitTimeEnd)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    MessageBox.Show("按入院时间查询时，起始时间不能大于结束时间！");
                    return;
                }
            }
            if (this.chkDischargeTime.Checked)
            {
                dtStartDischargeTime = this.dtpDischargeTimeBegin.Value;
                dtEndDischargeTime = this.dtpDischargeTimeEnd.Value;

                if (dtStartDischargeTime > dtEndDischargeTime)
                {
                    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                    MessageBox.Show("按出院时间查询时，起始时间不能大于结束时间！");
                    return;
                }
            }
            if (this.cboPatientStatus != null && this.cboPatientStatus.Text.Trim() != "")
                szPatientStatus = this.cboPatientStatus.Text;
            if (this.m_lstPatVisitLog == null)
                this.m_lstPatVisitLog = new List<PatVisitInfo>();
            this.m_lstPatVisitLog.Clear();
            short shRet = SystemData.ReturnValue.OK;

            if (this.chkOperation.Checked)
            {
                shRet =PatVisitAccess.Instance.GetPatsListByComplexSearchWithOperation(szPatientStatus, szDeptCode, szPatientID
                     , szPatientName, szDoctor, szDiagnosis
                  , szNursingClass, szPatientCondition, szIdentity, szChargeType
                  , nBeginAge, nEndAge, szOperationCode, dtVisitTimeBegin, dtVisitTimeEnd
                  , dtStartDischargeTime, dtEndDischargeTime, ref m_lstPatVisitLog);

            }
            else if (this.chkMutilOperation.Checked)
            {
                shRet = PatVisitAccess.Instance.GetPatsListByComplexSearchWithOperation(szPatientStatus, szDeptCode, szPatientID
                         , szPatientName, szDoctor, szDiagnosis
                      , szNursingClass, szPatientCondition, szIdentity, szChargeType
                      , nBeginAge, nEndAge, string.Empty, dtVisitTimeBegin, dtVisitTimeEnd
                      , dtStartDischargeTime, dtEndDischargeTime, ref m_lstPatVisitLog);
                //过滤只有一次手术的患者
                this.GetMutiOperationPatVisitLog(ref m_lstPatVisitLog);
            }
            else if (this.chkLabResult.Checked)
            {
                shRet = PatVisitAccess.Instance.GetPatsListByComplexSearchWithLabResult(szPatientStatus, szDeptCode, szPatientID
                    , szPatientName, szDoctor, szDiagnosis
                , szNursingClass, szPatientCondition, szIdentity
                , szChargeType, nBeginAge, nEndAge, dtVisitTimeBegin, dtVisitTimeEnd
                , dtStartDischargeTime, dtEndDischargeTime, ref m_lstPatVisitLog);

            }
            else if (this.chkDiagnosis.Checked && this.txtDiagnosis.Text.Trim() != string.Empty)
            {
                shRet = PatVisitAccess.Instance.GetPatsListByComplexSearchWithDiagnosis(szPatientStatus, szDeptCode, szPatientID
                     , szPatientName, szDoctor, szDiagnosis
                  , szNursingClass, szPatientCondition, szIdentity, szChargeType
                  , nBeginAge, nEndAge, szOperationCode, dtVisitTimeBegin, dtVisitTimeEnd
                  , dtStartDischargeTime, dtEndDischargeTime, ref m_lstPatVisitLog);

            }
            else
            {
                shRet = PatVisitAccess.Instance.GetPatsListByComplexSearch(szPatientStatus, szDeptCode, szPatientID
                    , szPatientName, szDoctor, szDiagnosis
                , szNursingClass, szPatientCondition, szIdentity
                , szChargeType, nBeginAge, nEndAge, dtVisitTimeBegin, dtVisitTimeEnd
                , dtStartDischargeTime, dtEndDischargeTime, ref m_lstPatVisitLog);
            }
            if (shRet != SystemData.ReturnValue.OK)
            {
                GlobalMethods.UI.SetCursor(this, Cursors.Default);
                MessageBoxEx.Show("获取患者列表信息失败！");
                return;

            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 过滤只有一次手术的患者
        /// </summary>
        /// <param name="m_lstPatVisitLog"></param>
        private void GetMutiOperationPatVisitLog(ref List<PatVisitInfo> m_lstPatVisitLog)
        {
            if (m_lstPatVisitLog == null && m_lstPatVisitLog.Count == 0)
                return;
            List<PatVisitInfo> lstPatVisitLog = new List<PatVisitInfo>();
            System.Collections.Hashtable ht = new System.Collections.Hashtable();
            foreach (PatVisitInfo item in m_lstPatVisitLog)
            {
                if (ht.ContainsKey(item.PATIENT_ID + item.VISIT_ID))
                {
                    bool bExist = false;
                    foreach (PatVisitInfo t in lstPatVisitLog)
                    {
                        if (t.VISIT_ID == item.VISIT_ID && t.PATIENT_ID == item.PATIENT_ID)
                        {
                            bExist = true;
                            break;
                        }
                    }
                    if (!bExist)
                        lstPatVisitLog.Add(item);
                }
                else
                {
                    ht.Add(item.PATIENT_ID + item.VISIT_ID, 1);
                }
            }
            m_lstPatVisitLog = lstPatVisitLog;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
         
            this.chkDoctor.Checked = false;
            this.txtDoctor.Text = string.Empty;
            this.chkNursingClass.Checked = false;
            this.cboNursingClass.SelectedItem = string.Empty;
            this.chkPatientCondition.Checked = false;
            this.cboPatientCondition.SelectedItem = string.Empty;
            this.chkDiagnosis.Checked = false;
            this.txtDiagnosis.Text = string.Empty;
            this.chkChargeType.Checked = false;
            this.cboChargeType.Text = string.Empty;
            this.chkIdentity.Checked = false;
            this.cboIdentity.Text = string.Empty;
            this.chkBirthTime.Checked = false;
            this.numBeginAge.Value = 0;
            this.numEndAge.Value = 0;
            this.chkOperation.Checked = false;
            this.fdCBXOperation.Text = string.Empty;
            this.chkLabResult.Checked = false;
            this.cboDeptName.Text = string.Empty;
            this.chkDept.Checked = true;
            this.chkDischargeTime.Checked = false;
            InitTimeControl();
        }

        private void txtDiagnosis_DoubleClick(object sender, EventArgs e)
        {
            IcdQueryForm form = new IcdQueryForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.txtDiagnosis.Text = form.szSelectedDiagnosis;
                this.chkDiagnosis.Checked = true;
            }
        }

        /// <summary>
        /// 控制某些医院控件显示
        /// </summary>
        private void SetControlVisible()
        {
            //   if (EMRDBLib.SystemParam.Instance.SystemOption.HospitalName == "某某某某医院")
            if (SystemParam.Instance.LocalConfigOption.HOSPITAL_NAME == "浙江大学医学院附属第四医院")
            {
                if (chkPatientCondition.Visible == false)
                    return;

                chkPatientCondition.Visible = false;
                cboPatientCondition.Visible = false;
                chkIdentity.Visible = false;
                cboIdentity.Visible = false;
                chkChargeType.Visible = false;
                cboChargeType.Visible = false;
                chkNursingClass.Location = new Point(chkNursingClass.Location.X, 64);
                cboNursingClass.Location = new Point(cboNursingClass.Location.X, 64);
                chkDoctor.Location = new Point(chkDoctor.Location.X, 108);
                txtDoctor.Location = new Point(txtDoctor.Location.X, 108);
            }
        }

    }
}