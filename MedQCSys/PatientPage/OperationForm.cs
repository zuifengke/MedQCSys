// ***********************************************************
// 诊断记录显示窗口.
// Creator:LiChunYing  Date:2012-01-04
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Collections;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Controls;
using Heren.Common.Report;
using Heren.Common.VectorEditor;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;
using Heren.Common.Controls.TableView;
using Heren.Common.Controls.DictInput;
using Heren.Common.Controls.TimeControl;

namespace MedQCSys.DockForms
{
    public partial class OperationForm : DockContentBase
    {
        public OperationForm(MainForm mainForm)
            : base(mainForm)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataTableView1.Font = new Font("宋体", 10.5f);
        }

        public OperationForm(MainForm mainForm, PatPage.PatientPageControl patientPageControl)
            : base(mainForm, patientPageControl)
        {
            InitializeComponent();
            this.HideOnClose = true;
            this.CloseButtonVisible = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataTableView1.Font = new Font("宋体", 10.5f);
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载手术信息，请稍候...");
            this.LoadOperationName();
            this.ShowOperatoin();
            this.ShowStatusMessage(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        /// <summary>
        /// 患者信息改变方法重写
        /// </summary>
        protected override void OnPatientInfoChanged()
        {
            if (this.IsHidden)
                return;
            if (this.Pane == null || this.Pane.IsDisposed)
                return;
            if (this.Pane.ActiveContent == this)
                this.OnRefreshView();
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

        private void LoadOperationName()
        {
            this.dataTableView1.SuspendLayout();
            this.dataTableView1.Rows.Clear();
            this.dataTableView1.ResumeLayout();
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitNo = SystemParam.Instance.PatVisitInfo.VISIT_NO;

            List<OperationName> lstOperationNames = null;
            short shRet = OperationNameAccess.Instance.GetOperationNames(szPatientID, szVisitNo, ref lstOperationNames);
            if (shRet != SystemData.ReturnValue.OK)
                return;
            if (lstOperationNames == null || lstOperationNames.Count <= 0)
                return;

            int nRowIndex = 0;
            this.dataTableView1.Rows.Clear();
            foreach (var item in lstOperationNames)
            {
                nRowIndex = this.dataTableView1.Rows.Add();
                DataTableViewRow row = this.dataTableView1.Rows[nRowIndex];
                row.Cells[this.colOperationName.Index].Value = item.OPERATION;
                row.Cells[this.colOperationScale.Index].Value = item.OPERATION_SCALE;
                row.Tag = item;
            }
            if (this.dataTableView1.Rows.Count > 0)
                this.dataTableView1.SelectRow(0);
        }

        private bool GetSystemContext(string name, ref object value)
        {
            if (name == "患者姓名")
            {
                value = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
                return true;
            }
            if (name == "患者ID")
            {
                value = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                return true;
            }
            if (name == "所在科室")
            {
                value = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                return true;
            }
            return false;
        }

        private void ReportExplorerForm_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = this.GetSystemContext(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private void dataTableView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            ShowOperatoin();
        }

        private void ShowOperatoin()
        {
            if (this.dataTableView1.SelectedRows.Count <= 0)
            {
                foreach (var item in this.xGroupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        (item as TextBox).Text = string.Empty;
                    }
                    else if (item is FindComboBox)
                    {
                        (item as FindComboBox).Text = string.Empty;
                    }
                    else if (item is DateTimeControl)
                    {
                        (item as DateTimeControl).Value = null;
                    }
                }
                return;
            }
            OperationName operationName = this.dataTableView1.SelectedRows[0].Tag as OperationName;
            if (operationName == null)
                return;
            string szOperNo = operationName.OPER_NO;
            OperationMaster operationMaster = new OperationMaster();
            short shRet = OperationMasterAccess.Instance.GetOperationMaster(szOperNo, ref operationMaster);
            txtDIAG_BEFORE_OPERATION.Text = operationMaster.DIAG_BEFORE_OPERATION;
            txtPATIENT_CONDITION.Text = operationMaster.PATIENT_CONDITION;
            if (operationMaster.START_DATE_TIME != operationMaster.DefaultTime)
                dtSTART_DATE_TIME.Value = operationMaster.START_DATE_TIME;
            else
                dtSTART_DATE_TIME.Value = null;
            if (operationMaster.END_DATE_TIME != operationMaster.DefaultTime)
                dtEND_DATE_TIME.Value = operationMaster.END_DATE_TIME;
            else
                dtEND_DATE_TIME.Value = null;
            DeptInfo deptInfo = null;
            shRet = DeptAccess.Instance.GetDeptInfo(operationMaster.OPERATING_ROOM, ref deptInfo); 
            if (deptInfo != null)
                cboOPERATING_ROOM.Text = deptInfo.DEPT_NAME;
            else
                cboOPERATING_ROOM.Text = string.Empty;
            txt_ISOLATION_FLAG.Text = SystemData.IsolationFlag.GetCnIsoLationFlag(operationMaster.ISOLATION_FLAG);
            shRet = DeptAccess.Instance.GetDeptInfo(operationMaster.OPERATING_DEPT, ref deptInfo);
            if (shRet == SystemData.ReturnValue.OK)
                txt_OPERATING_DEPT.Text = deptInfo.DEPT_NAME;
            else
                txt_OPERATING_DEPT.Text = string.Empty;
            txt_OPERATING_SCALE.Text = operationMaster.OPERATING_SCALE;
            txt_OPERATOR_DOCTOR.Text = operationMaster.OPERATOR_DOCTOR;
            cbo_FIRST_ANESTHESIA.Text = operationMaster.FIRST_ANESTHESIA;
            cbo_FIRST_ASSISTANT.Text = operationMaster.FIRST_ANESTHESIA;
            cbo_FIRST_OPERATION_NURSE.Text = operationMaster.FIRST_OPERATION_NURSE;
            cbo_FIRST_SUPPLY_NURSE.Text = operationMaster.FIRST_SUPPLY_NURSE;
            cbo_FOUR_ASSISTANT.Text = operationMaster.FOUR_ASSISTANT;
            cbo_SECOND_ASSISTANT.Text = operationMaster.SECOND_ASSISTANT;
            cbo_SECOND_OPERATION_NURSE.Text = operationMaster.SECOND_OPERATION_NURSE;
            cbo_SECOND_SUPPLY_NURSE.Text = operationMaster.SECOND_SUPPLY_NURSE;
            cbo_THREE_ASSISTANT.Text = operationMaster.THREE_ASSISTANT;
            cbo_ANAESTHESIA_METHOD.Text = operationMaster.ANAESTHESIA_METHOD;
            if (operationMaster.REQ_DATE_TIME != operationMaster.DefaultTime)
                dt_REQ_DATE_TIME.Value = operationMaster.REQ_DATE_TIME;
            else
                dt_REQ_DATE_TIME.Value = null;

        }
    }
}