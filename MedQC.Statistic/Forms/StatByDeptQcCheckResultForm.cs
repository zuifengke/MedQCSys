using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.DockSuite;
using Heren.Common.Libraries;
using Heren.Common.Report;
using EMRDBLib.DbAccess;
using EMRDBLib;
using Heren.MedQC.Utilities;

namespace MedQCSys.DockForms
{
    public partial class StatByDeptQcCheckResultForm : MedQCSys.DockForms.DockContentBase
    {
        public StatByDeptQcCheckResultForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();

            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Columns[this.col_1_TotalErrorCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_ErrorCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_DeptName.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView2.Columns[this.col_2_VisitID.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dtpBeginTime.Value = DateTime.Now.AddMonths(-1);

            string szToolTip = string.Format("提示：\n统计维度为全院质控问题总数->科室质控问题总数->医生质控问题总数，选择医生可以查看具体的病历列表\n");
            this.toolTip1.SetToolTip(this.pictureBox1, szToolTip);
            toolTip1.AutoPopDelay = 25000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 0;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.dataGridView1.Font = new Font("宋体", 10.5f);
            this.ShowStatusMessage("正在下载临床科室列表，请稍候...");
            if (!InitControlData.InitCboDeptName(ref this.cboDeptName))
            {
                MessageBoxEx.Show("下载科室列表失败");
            }
            this.ShowStatusMessage(null);
        }
        private List<QcCheckResult> ListQcCheckResult = null;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime dtBeginTime = DateTime.Parse(this.dtpBeginTime.Value.ToShortDateString());
            DateTime dtEndTime = DateTime.Parse(this.dtpEndTime.Value.AddDays(1).ToShortDateString());
            if (this.ListQcCheckResult == null)
                this.ListQcCheckResult = new List<QcCheckResult>();
            this.ListQcCheckResult.Clear();
            string szMrStatus = SystemData.MrStatus.GetMrStatusCode(this.cboQcMrStatus.Text);
            int nStatType = SystemData.StatType.GetCode(this.cboStatType.Text);
            WorkProcess.Instance.Initialize(this, 2
             , string.Format("正在加载，请稍候..."));
            string szOrderBy = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.QcCheckResultTable.DEPT_IN_CHARGE
                , SystemData.QcCheckResultTable.INCHARGE_DOCTOR
                , SystemData.QcCheckResultTable.ORDER_VALUE
                , SystemData.QcCheckResultTable.PATIENT_ID
                , SystemData.QcCheckResultTable.VISIT_ID);
            short shRet = QcCheckResultAccess.Instance.GetQcCheckResults(dtBeginTime, dtEndTime, null, null, null, szOrderBy,szMrStatus,nStatType, ref ListQcCheckResult);

            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowMessage("未查询到结果");
                this.ShowStatusMessage("未查询到结果");
                WorkProcess.Instance.Close();
                return;
            }
            List<YunxingCheckResult> lstYunxingCheckResult = new List<YunxingCheckResult>();
            string szMsgDictMessag = string.Empty;
            string szMsgDictCode = string.Empty;
            string szDeptName = string.Empty;

            string szDoctor = string.Empty;
            int nErrorCount = 0;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            //计算结果
            WorkProcess.Instance.Show(string.Format("加载到计算，请稍候..."), 1);

            foreach (QcCheckResult item in ListQcCheckResult)
            {
                if (item.QC_RESULT == 1)
                    continue;
                if (item.MSG_DICT_CODE != szMsgDictCode && !string.IsNullOrEmpty(szMsgDictCode))
                {
                    YunxingCheckResult yunxingCheckResult = new YunxingCheckResult();
                    yunxingCheckResult.MsgDictCode = szMsgDictCode;
                    yunxingCheckResult.MsgDictMessage = szMsgDictMessag;
                    yunxingCheckResult.DeptName = item.DEPT_IN_CHARGE;
                    yunxingCheckResult.Doctor = item.INCHARGE_DOCTOR;
                    yunxingCheckResult.ErrorCount = nErrorCount;
                    lstYunxingCheckResult.Add(yunxingCheckResult);

                    szMsgDictMessag = string.Empty;
                    nErrorCount = 0;
                }
                if (item.MSG_DICT_CODE != szMsgDictCode)
                {
                    szMsgDictMessag = item.MSG_DICT_MESSAGE;
                    szMsgDictCode = item.MSG_DICT_CODE;
                }
                if (item.QC_RESULT == 0)
                {
                    nErrorCount = nErrorCount + item.ERROR_COUNT;
                }
            }
            //计算科室缺陷总数
            if (ListQcCheckResult != null && ListQcCheckResult.Count > 0)
            {
                int nTotalErrorCount = 0;
                string szDeptNamePre = string.Empty;
                foreach (var item in lstYunxingCheckResult)
                {
                    if (item.DeptName != szDeptNamePre && !string.IsNullOrEmpty(szDeptNamePre))
                    {
                        foreach (var item1 in lstYunxingCheckResult)
                        {
                            if (item1.DeptName == szDeptNamePre)
                            {
                                item1.TotalErrorCount = nTotalErrorCount;
                            }
                        }
                        szDeptNamePre = item.DeptName;
                        nTotalErrorCount = 0;
                    }
                    if (string.IsNullOrEmpty(szDeptNamePre))
                    {
                        szDeptNamePre = item.DeptName;
                    }
                    nTotalErrorCount = nTotalErrorCount + item.ErrorCount;
                    if (lstYunxingCheckResult.IndexOf(item) == lstYunxingCheckResult.Count - 1)
                    {
                        foreach (var item1 in lstYunxingCheckResult)
                        {
                            if (item1.DeptName == szDeptNamePre)
                            {
                                item1.TotalErrorCount = nTotalErrorCount;
                            }
                        }
                    }
                }
            }
            //显示到列表中
            WorkProcess.Instance.Show(string.Format("加载到计算，请稍候..."), 2);

            if (lstYunxingCheckResult != null && lstYunxingCheckResult.Count > 0)
            {
                string szDeptNamePre = string.Empty;
                string szDoctorPre = string.Empty;
                int rowIndex = 0;
                foreach (var item in lstYunxingCheckResult)
                {
                    rowIndex = this.dataGridView1.Rows.Add();
                    DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                    this.dataGridView1.Rows[rowIndex].Tag = item;
                    if (szDeptNamePre != item.DeptName)
                    {
                        row.Cells[this.col_1_DeptName.Index].Value = item.DeptName;
                        row.Cells[this.col_1_TotalErrorCount.Index].Value = item.TotalErrorCount;
                        szDeptNamePre = item.DeptName;
                    }
                    if (szDoctorPre != item.Doctor)
                    {
                        row.Cells[this.col_1_Doctor.Index].Value = item.Doctor;
                        szDoctorPre = item.Doctor;
                    }
                    row.Cells[this.col_1_MsgDictMessage.Index].Value = item.MsgDictMessage;
                    row.Cells[this.col_1_ErrorCount.Index].Value = item.ErrorCount;
                }
            }
            WorkProcess.Instance.Close();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex != this.col_1_Doctor.Index)
                return;
            this.dataGridView2.Rows.Clear();
            YunxingCheckResult yunxingCheckResult = this.dataGridView1.Rows[e.RowIndex].Tag as YunxingCheckResult;
            if (yunxingCheckResult == null)
                return;
            //过滤缺陷点，统计科室数量
            string szDeptCode = string.Empty;
            string szDeptName = string.Empty;
            string szMsgDictMessage = string.Empty;
            string szDoctor = string.Empty;
            string szPatientID = string.Empty;
            string szVisitID = string.Empty;
            string szTotalPatientID = string.Empty;
            string szTotalVisitID = string.Empty;
            List<DocCheckResult> lstDoctorCheckResult = new List<DocCheckResult>();
            var result = this.ListQcCheckResult.FindAll(m => m.DEPT_IN_CHARGE == yunxingCheckResult.DeptName && m.INCHARGE_DOCTOR == yunxingCheckResult.Doctor && m.QC_RESULT == 0);

            if (result != null && result.Count > 0)
            {

                foreach (var item in result)
                {
                    int rowIndex = this.dataGridView2.Rows.Add();
                    DataGridViewRow row = this.dataGridView2.Rows[rowIndex];
                    row.Tag = item;
                    if (szDeptName != item.DEPT_IN_CHARGE)
                    {
                        row.Cells[this.col_2_DeptName.Index].Value = item.DEPT_IN_CHARGE;
                        szDeptName = item.DEPT_IN_CHARGE;
                    }
                    if (szDoctor != item.INCHARGE_DOCTOR)
                    {
                        row.Cells[this.col_2_Doctor.Index].Value = item.INCHARGE_DOCTOR;
                        szDoctor = item.INCHARGE_DOCTOR;
                    }
                    if (szMsgDictMessage != item.MSG_DICT_MESSAGE)
                    {
                        row.Cells[this.col_2_MsgDictMessage.Index].Value = item.MSG_DICT_MESSAGE;
                        szMsgDictMessage = item.MSG_DICT_MESSAGE;
                    }
                    row.Cells[this.col_2_PatientName.Index].Value = item.PATIENT_NAME;
                    row.Cells[this.col_2_PatientID.Index].Value = item.PATIENT_ID;
                    row.Cells[this.col_2_VisitID.Index].Value = item.VISIT_ID;
                    row.Cells[this.col_2_VisitID.Index].Value = "1";
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.toolTip1.ShowAlways = true; ;
        }

        public class DocCheckResult
        {
            public string MsgDictMessage { get; set; }
            public string MsgDictCode { get; set; }
            public string DeptCode { get; set; }
            public string DeptName { get; set; }
            public string Doctor { get; set; }
            public string PatientName { get; set; }
            public string PatientID { get; set; }
            public string VisitID { get; set; }
        }
        public class YunxingCheckResult
        {
            public string DeptName { get; set; }
            public int TotalErrorCount { get; set; }
            public string Doctor { get; set; }
            public string MsgDictMessage { get; set; }
            public string MsgDictCode { get; set; }
            public int ErrorCount { get; set; }
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
            QcCheckResult docCheckResult = row.Tag as QcCheckResult;

            if (docCheckResult == null)
                return;
            this.MainForm.OpenDocument(string.Empty, docCheckResult.PATIENT_ID, docCheckResult.VISIT_ID);
        }
    }
}
