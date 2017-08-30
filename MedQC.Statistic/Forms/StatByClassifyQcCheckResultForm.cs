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
using System.Drawing.Drawing2D;
using Heren.MedQC.Utilities;
using System.Linq;
using MedQCSys;
using Heren.MedQC.Statistic.Dialogs;
namespace Heren.MedQC.Statistic
{
    public partial class StatByClassifyQcCheckResultForm : MedQCSys.DockForms.DockContentBase
    {
        public StatByClassifyQcCheckResultForm(MainForm parent)
            : base(parent)
        {
            InitializeComponent();

            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.dataGridView1.Columns[this.col_1_DeptCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_ErrorCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_DocCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_DoctorCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_DoctorPercent.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_DoctorTotalCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_DocTotalCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_DocPercent.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView1.Columns[this.col_1_DeptTotalCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[this.col_2_DocCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[this.col_2_DoctorCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dataGridView2.Columns[this.col_2_DocTotalCount.Index].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //this.dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            //this.dataGridView4.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dataGridView4.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            int nGroupIndex = this.dataGridView1.Groups.Add();
            this.dataGridView1.Groups[nGroupIndex].BeginColumn = 3;
            this.dataGridView1.Groups[nGroupIndex].EndColumn = 5;
            this.dataGridView1.Groups[nGroupIndex].Text = "科室";
            this.dataGridView1.Groups[nGroupIndex].BackColor = Color.White;
            this.dataGridView1.Groups[nGroupIndex].Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            nGroupIndex = this.dataGridView1.Groups.Add();
            this.dataGridView1.Groups[nGroupIndex].BeginColumn = 6;
            this.dataGridView1.Groups[nGroupIndex].EndColumn = 8;
            this.dataGridView1.Groups[nGroupIndex].Text = "医生";
            this.dataGridView1.Groups[nGroupIndex].BackColor = Color.White;
            this.dataGridView1.Groups[nGroupIndex].Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            nGroupIndex = this.dataGridView1.Groups.Add();
            this.dataGridView1.Groups[nGroupIndex].BeginColumn = 9;
            this.dataGridView1.Groups[nGroupIndex].EndColumn = 11;
            this.dataGridView1.Groups[nGroupIndex].Text = "病历";
            this.dataGridView1.Groups[nGroupIndex].Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dataGridView1.Groups[nGroupIndex].BackColor = Color.White;
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            this.dtpBeginTime.Value = DateTime.Now.AddMonths(-1);

            string szToolTip = string.Format("提示：\n系统按病历问题类型->发生该问题的科室->发生该问题的病历维度进行监控。\n最后可已查看到病历的缺陷列表\n");
            this.toolTip1.SetToolTip(this.pictureBox1, szToolTip);
            toolTip1.AutoPopDelay = 25000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 0;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;
            this.dataGridView1.GridColor = Color.LightGray;
            this.dataGridView2.GridColor = Color.LightGray;
            this.dataGridView3.GridColor = Color.LightGray;
            this.dataGridView4.GridColor = Color.LightGray;
            //this.arrowSplitter1.IsExpand = false;
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
        /// <summary>
        /// 系统质控缺陷
        /// </summary>
        private List<QcCheckResult> ListQcCheckResult = null;
        /// <summary>
        /// 人工质控缺陷
        /// </summary>
        private List<MedicalQcMsg> ListQcMsg = null;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //QcCheckResultStatistic();
            ClassifyQcCheckResult();
        }
        private void ClassifyQcCheckResult()
        {
            string szMsgCodeList= this.txtMsgDict.Tag as string;
            //加载字典
            List<QcMsgDict> lstQcMsgDict = null;
            short shRet= QcMsgDictAccess.Instance.GetQcMsgDictList(ref lstQcMsgDict);

            if (lstQcMsgDict == null)
            {
                MessageBoxEx.ShowMessage("数据加载失败");
                return;
            }
            if (!string.IsNullOrEmpty(szMsgCodeList))
                lstQcMsgDict = lstQcMsgDict.Where(m => szMsgCodeList.Contains(m.QC_MSG_CODE)).ToList();
            if (lstQcMsgDict.Count <= 0)
            {
                MessageBoxEx.ShowMessage("评分项目加载失败");
                return;
            }
            //加载缺陷结果项
            WorkProcess.Instance.Initialize(this, lstQcMsgDict.Count, "正在进行缺陷分类统计...");
            DateTime dtBeginTime = DateTime.Parse(this.dtpBeginTime.Value.ToShortDateString());
            DateTime dtEndTime = DateTime.Parse(this.dtpEndTime.Value.AddDays(1).ToShortDateString());
            string szOrderBy = string.Format("{0},{1},{2},{3},{4}"
              , SystemData.QcCheckResultTable.ORDER_VALUE
              , SystemData.QcCheckResultTable.DEPT_CODE
              , SystemData.QcCheckResultTable.INCHARGE_DOCTOR
              , SystemData.QcCheckResultTable.PATIENT_ID
              , SystemData.QcCheckResultTable.VISIT_ID);
            string szMrStatus = SystemData.MrStatus.GetMrStatusCode(this.cboQcMrStatus.Text);
            int nStatType = SystemData.StatType.GetCode(this.cboStatType.Text);
            WorkProcess.Instance.Show(1, true);
            shRet = QcCheckResultAccess.Instance.GetQcCheckResults(dtBeginTime, dtEndTime, null, null, null, szOrderBy, szMrStatus, nStatType, ref ListQcCheckResult);
            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();
            this.dataGridView3.Rows.Clear();
            this.dataGridView4.Rows.Clear();
            if (shRet != SystemData.ReturnValue.OK)
            {
                WorkProcess.Instance.Close();
                MessageBoxEx.ShowMessage("未查询到结果");
                this.ShowStatusMessage("未查询到结果");
                return;
            }
            if (WorkProcess.Instance.Canceled)
            {
                WorkProcess.Instance.Close();
                return;
            }
            List<YunxingCheckResult> lstYunxingCheckResult = new List<YunxingCheckResult>();
            int nErrorCount = 0;
            int nDeptCount = 0;
            int nDeptTotalCount = 0;
            int nDoctorCount = 0;
            int nDoctorTotalCount = 0;
            int nDocCount = 0;
            int nDocTotalCount = 0;
            foreach (var item in lstQcMsgDict)
            {
                if (WorkProcess.Instance.Canceled)
                {
                    WorkProcess.Instance.Close();
                    return;
                }
                WorkProcess.Instance.Show(lstQcMsgDict.IndexOf(item), true);
                List<QcCheckResult> lstQcCheckResult = this.ListQcCheckResult.Where(m => m.MSG_DICT_CODE == item.QC_MSG_CODE).ToList();
                nErrorCount= lstQcCheckResult.Sum(m=>m.ERROR_COUNT);
                nDeptCount = lstQcCheckResult.Where(m=>m.QC_RESULT==0).Select(m => m.DEPT_CODE).Distinct().Count();
                nDeptTotalCount = lstQcCheckResult.Select(m => m.DEPT_CODE).Distinct().Count();
                nDoctorCount = lstQcCheckResult.Where(m=>m.QC_RESULT==0).Select(m => m.INCHARGE_DOCTOR).Distinct().Count();
                nDoctorTotalCount = lstQcCheckResult.Select(m => m.INCHARGE_DOCTOR).Distinct().Count();
                nDocCount = lstQcCheckResult.Where(m=>m.QC_RESULT==0).Select(m => m.PATIENT_ID).Distinct().Count();
                nDocTotalCount = lstQcCheckResult.Select(m => m.PATIENT_ID).Distinct().Count();
                YunxingCheckResult yunxingCheckResult = new YunxingCheckResult();
                yunxingCheckResult.QaEventType = item.QA_EVENT_TYPE;
                yunxingCheckResult.MsgDictMessage = item.MESSAGE;
                yunxingCheckResult.MsgDictCode = item.QC_MSG_CODE;
                yunxingCheckResult.ErrorCount = nErrorCount;
                yunxingCheckResult.DeptCount = nDeptCount;
                yunxingCheckResult.DeptTotalCount = nDeptTotalCount;
                yunxingCheckResult.DeptPercent=nDeptTotalCount==0?0:Math.Round((1.0 * nDeptCount / nDeptTotalCount), 4);
                yunxingCheckResult.DoctorCount = nDoctorCount;
                yunxingCheckResult.DoctorTotalCount = nDoctorTotalCount;
                yunxingCheckResult.DoctorPercent =nDoctorTotalCount==0?0:Math.Round((1.0 * nDoctorCount / nDoctorTotalCount), 4);
                yunxingCheckResult.DocCount =nDocCount;
                yunxingCheckResult.DocTotalCount = nDocTotalCount;
                yunxingCheckResult.DocPercent = nDocTotalCount == 0 ? 0 : Math.Round((1.0 * nDocCount / nDocTotalCount), 4);

                lstYunxingCheckResult.Add(yunxingCheckResult);
            }

            //显示到列表中
            WorkProcess.Instance.Show(string.Format("加载到列表中，请稍候..."), lstQcMsgDict.Count-1);

            if (lstYunxingCheckResult != null && lstYunxingCheckResult.Count > 0)
            {
                string szQaEventTypePre = string.Empty;
                int rowIndex = 0;
                foreach (var item in lstYunxingCheckResult)
                {
                    rowIndex = this.dataGridView1.Rows.Add();
                    DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                    row.Height = 27;
                    this.dataGridView1.Rows[rowIndex].Tag = item;
                    if (string.IsNullOrEmpty(szQaEventTypePre) || item.QaEventType != szQaEventTypePre)
                    {
                        row.Cells[this.col_1_QaEventType.Index].Value = item.QaEventType;
                        szQaEventTypePre = item.QaEventType;
                    }
                    row.Cells[this.col_1_MsgDictMessage.Index].Value = item.MsgDictMessage;
                    row.Cells[this.col_1_ErrorCount.Index].Value = item.ErrorCount;
                    row.Cells[this.col_1_DeptCount.Index].Value = item.DeptCount;
                    row.Cells[this.col_1_DeptTotalCount.Index].Value = item.DeptTotalCount;
                    row.Cells[this.col_1_DeptPercent.Index].Value = (item.DeptPercent * 100).ToString();
                    row.Cells[this.col_1_DocCount.Index].Value = item.DocCount;
                    row.Cells[this.col_1_DocTotalCount.Index].Value = item.DocTotalCount;
                    row.Cells[this.col_1_DocPercent.Index].Value = (item.DocPercent * 100).ToString();
                    row.Cells[this.col_1_DoctorCount.Index].Value = item.DoctorCount;
                    row.Cells[this.col_1_DoctorTotalCount.Index].Value = item.DoctorTotalCount;
                    row.Cells[this.col_1_DoctorPercent.Index].Value = (item.DoctorPercent * 100).ToString();

                }
            }
            WorkProcess.Instance.Close();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);


        }
        private void QcCheckResultStatistic()
        {
            DateTime dtBeginTime = DateTime.Parse(this.dtpBeginTime.Value.ToShortDateString());
            DateTime dtEndTime = DateTime.Parse(this.dtpEndTime.Value.AddDays(1).ToShortDateString());

            if (this.ListQcCheckResult == null)
                this.ListQcCheckResult = new List<QcCheckResult>();
            this.ListQcCheckResult.Clear();

            WorkProcess.Instance.Initialize(this, 2
             , string.Format("正在加载，请稍候..."));
            string szOrderBy = string.Format("{0},{1},{2},{3},{4}"
               , SystemData.QcCheckResultTable.ORDER_VALUE
               , SystemData.QcCheckResultTable.DEPT_CODE
               , SystemData.QcCheckResultTable.INCHARGE_DOCTOR
               , SystemData.QcCheckResultTable.PATIENT_ID
               , SystemData.QcCheckResultTable.VISIT_ID);
            string szMrStatus = SystemData.MrStatus.GetMrStatusCode(this.cboQcMrStatus.Text);
            int nStatType = SystemData.StatType.GetCode(this.cboStatType.Text);
            short shRet = QcCheckResultAccess.Instance.GetQcCheckResults(dtBeginTime, dtEndTime, null, null, null, szOrderBy, szMrStatus, nStatType, ref ListQcCheckResult);
            this.dataGridView1.Rows.Clear();
            this.dataGridView2.Rows.Clear();
            this.dataGridView3.Rows.Clear();
            this.dataGridView4.Rows.Clear();
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.ShowMessage("未查询到结果");
                this.ShowStatusMessage("未查询到结果");
                WorkProcess.Instance.Close();
                return;
            }
            List<YunxingCheckResult> lstYunxingCheckResult = new List<YunxingCheckResult>();
            string szQaEventType = string.Empty;
            string szMsgDictMessag = string.Empty;
            string szMsgDictCode = string.Empty;
            string szDeptCode = string.Empty;
            string szTotalDeptCode = string.Empty;
            string szDoctor = string.Empty;
            string szTotalDoctor = string.Empty;
            string szPatientID = string.Empty;
            string szTotalPatientID = string.Empty;
            string szVisitID = string.Empty;
            string szTotalVisitID = string.Empty;
            int nErrorCount = 0;
            int nDeptCount = 0;
            int nDeptTotalCount = 0;
            int nDoctorCount = 0;
            int nDoctorTotalCount = 0;
            int nDocCount = 0;
            int nDocTotalCount = 0;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            //计算结果
            WorkProcess.Instance.Show(string.Format("加载到计算，请稍候..."), 1);
            foreach (QcCheckResult item in ListQcCheckResult)
            {
                if (item.MSG_DICT_CODE != szMsgDictCode && !string.IsNullOrEmpty(szMsgDictCode))
                {
                    YunxingCheckResult yunxingCheckResult = new YunxingCheckResult();
                    yunxingCheckResult.QaEventType = szQaEventType;
                    yunxingCheckResult.MsgDictCode = szMsgDictCode;
                    yunxingCheckResult.MsgDictMessage = szMsgDictMessag;
                    yunxingCheckResult.DeptCount = nDeptCount;
                    yunxingCheckResult.DeptTotalCount = nDeptTotalCount;
                    yunxingCheckResult.DeptPercent = Math.Round((1.0 * nDeptCount / nDeptTotalCount), 4);
                    yunxingCheckResult.DocCount = nDocCount;
                    yunxingCheckResult.DocTotalCount = nDocTotalCount;
                    yunxingCheckResult.DocPercent = Math.Round((1.0 * nDocCount / nDocTotalCount), 4);
                    yunxingCheckResult.DoctorCount = nDoctorCount;
                    yunxingCheckResult.DoctorTotalCount = nDoctorTotalCount;
                    yunxingCheckResult.DoctorPercent = Math.Round((1.0 * nDoctorCount / nDoctorTotalCount), 4);
                    yunxingCheckResult.ErrorCount = nErrorCount;
                    lstYunxingCheckResult.Add(yunxingCheckResult);
                    szQaEventType = string.Empty;
                    szMsgDictMessag = string.Empty;
                    //szMsgDictCode = string.Empty;
                    szDeptCode = string.Empty;
                    szTotalDeptCode = string.Empty;
                    szDoctor = string.Empty;
                    szTotalDoctor = string.Empty;
                    szPatientID = string.Empty;
                    szTotalPatientID = string.Empty;
                    szVisitID = string.Empty;
                    szTotalVisitID = string.Empty;
                    nErrorCount = 0;
                    nDeptCount = 0;
                    nDeptTotalCount = 0;
                    nDoctorCount = 0;
                    nDoctorTotalCount = 0;
                    nDocCount = 0;
                    nDocTotalCount = 0;
                }
                if (item.MSG_DICT_CODE != szMsgDictCode)
                {
                    szMsgDictMessag = item.MSG_DICT_MESSAGE;
                    szMsgDictCode = item.MSG_DICT_CODE;
                    szQaEventType = item.QA_EVENT_TYPE;
                }
                if (item.DEPT_CODE != szTotalDeptCode)
                {
                    szTotalDeptCode = item.DEPT_CODE;
                    nDeptTotalCount++;
                }
                if (item.DEPT_CODE != szDeptCode && item.QC_RESULT == 0)
                {
                    szDeptCode = item.DEPT_CODE;
                    nDeptCount++;
                }
                if (item.INCHARGE_DOCTOR != szTotalDoctor)
                {
                    szTotalDoctor = item.INCHARGE_DOCTOR;
                    nDoctorTotalCount++;
                }
                if (item.INCHARGE_DOCTOR != szDoctor && item.QC_RESULT == 0)
                {
                    szDoctor = item.INCHARGE_DOCTOR;
                    nDoctorCount++;
                }
                if (item.PATIENT_ID != szTotalPatientID && item.VISIT_ID != szTotalVisitID)
                {
                    szTotalPatientID = item.PATIENT_ID;
                    szTotalVisitID = item.VISIT_ID;
                    nDocTotalCount++;
                }
                if (item.PATIENT_ID != szPatientID && item.VISIT_ID != szVisitID && item.QC_RESULT == 0)
                {
                    szPatientID = item.PATIENT_ID;
                    szVisitID = item.VISIT_ID;
                    nDocCount++;
                }
                if (item.QC_RESULT == 0)
                {
                    nErrorCount = nErrorCount + item.ERROR_COUNT;
                }
                if (ListQcCheckResult.IndexOf(item) == ListQcCheckResult.Count - 1)
                {
                    //加载最后一个
                    YunxingCheckResult yunxingCheckResult = new YunxingCheckResult();
                    yunxingCheckResult.QaEventType = szQaEventType;
                    yunxingCheckResult.MsgDictCode = szMsgDictCode;
                    yunxingCheckResult.MsgDictMessage = szMsgDictMessag;
                    yunxingCheckResult.DeptCount = nDeptCount;
                    yunxingCheckResult.DeptTotalCount = nDeptTotalCount;
                    yunxingCheckResult.DeptPercent = Math.Round((1.0 * nDeptCount / nDeptTotalCount), 4);
                    yunxingCheckResult.DocCount = nDocCount;
                    yunxingCheckResult.DocTotalCount = nDocTotalCount;
                    yunxingCheckResult.DocPercent = Math.Round((1.0 * nDocCount / nDocTotalCount), 4);
                    yunxingCheckResult.DoctorCount = nDoctorCount;
                    yunxingCheckResult.DoctorTotalCount = nDoctorTotalCount;
                    yunxingCheckResult.DoctorPercent = Math.Round((1.0 * nDoctorCount / nDoctorTotalCount), 4);
                    yunxingCheckResult.ErrorCount = nErrorCount;
                    lstYunxingCheckResult.Add(yunxingCheckResult);
                }
            }
            //显示到列表中
            WorkProcess.Instance.Show(string.Format("加载到计算，请稍候..."), 2);

            if (lstYunxingCheckResult != null && lstYunxingCheckResult.Count > 0)
            {
                string szQaEventTypePre = string.Empty;
                int rowIndex = 0;
                foreach (var item in lstYunxingCheckResult)
                {
                    rowIndex = this.dataGridView1.Rows.Add();
                    DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                    row.Height = 27;
                    this.dataGridView1.Rows[rowIndex].Tag = item;
                    if (string.IsNullOrEmpty(szQaEventTypePre) || item.QaEventType != szQaEventTypePre)
                    {
                        row.Cells[this.col_1_QaEventType.Index].Value = item.QaEventType;
                        szQaEventTypePre = item.QaEventType;
                    }
                    row.Cells[this.col_1_MsgDictMessage.Index].Value = item.MsgDictMessage;
                    row.Cells[this.col_1_ErrorCount.Index].Value = item.ErrorCount;
                    row.Cells[this.col_1_DeptCount.Index].Value = item.DeptCount;
                    row.Cells[this.col_1_DeptTotalCount.Index].Value = item.DeptTotalCount;
                    row.Cells[this.col_1_DeptPercent.Index].Value = (item.DeptPercent * 100).ToString();
                    row.Cells[this.col_1_DocCount.Index].Value = item.DocCount;
                    row.Cells[this.col_1_DocTotalCount.Index].Value = item.DocTotalCount;
                    row.Cells[this.col_1_DocPercent.Index].Value = (item.DocPercent * 100).ToString();
                    row.Cells[this.col_1_DoctorCount.Index].Value = item.DoctorCount;
                    row.Cells[this.col_1_DoctorTotalCount.Index].Value = item.DoctorTotalCount;
                    row.Cells[this.col_1_DoctorPercent.Index].Value = (item.DoctorPercent * 100).ToString();

                }
            }
            WorkProcess.Instance.Close();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex != this.col_4_QcResult.Index)
                return;
            QcCheckResult qcCheckResult = this.dataGridView4.Rows[e.RowIndex].Tag as QcCheckResult;
            if (qcCheckResult.QC_RESULT == 0)
                MessageBoxEx.ShowWarning(qcCheckResult.QC_EXPLAIN);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.toolTip1.ShowAlways = true; ;
        }

        public class DocCheckResult
        {
            public string DeptCode { get; set; }
            public string DeptName { get; set; }
            public string Doctor { get; set; }
            public string PatientName { get; set; }
            public string PatientID { get; set; }
            public string VisitID { get; set; }
        }
        public class DeptCheckResult
        {
            public string MsgDictCode { get; set; }
            public string DeptCode { get; set; }
            public string DeptName { get; set; }
            public int DocCount { get; set; }
            public int DocTotalCount { get; set; }
            public int DoctorCount { get; set; }
        }
        public class YunxingCheckResult
        {
            public string QaEventType { get; set; }
            public string MsgDictMessage { get; set; }
            public string MsgDictCode { get; set; }
            public int ErrorCount { get; set; }
            public int DeptCount { get; set; }
            public int DeptTotalCount { get; set; }
            public double DeptPercent { get; set; }
            public int DocCount { get; set; }
            public int DocTotalCount { get; set; }
            public double DocPercent { get; set; }
            public int DoctorCount { get; set; }
            public int DoctorTotalCount { get; set; }
            public double DoctorPercent { get; set; }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            System.Collections.Hashtable htNoExportColunms = new System.Collections.Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "缺陷自动检查记录查询");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            DataGridViewRow row = this.dataGridView3.Rows[e.RowIndex];
            DocCheckResult docCheckResult = row.Tag as DocCheckResult;

            if (docCheckResult == null)
                return;
            this.MainForm.OpenDocument(string.Empty, docCheckResult.PatientID, docCheckResult.VisitID);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.dataGridView2.Rows.Clear();
            this.dataGridView3.Rows.Clear();
            this.dataGridView4.Rows.Clear();
            YunxingCheckResult yunxingCheckResult = this.dataGridView1.Rows[e.RowIndex].Tag as YunxingCheckResult;
            if (yunxingCheckResult == null)
                return;
            //过滤缺陷点，统计科室数量
            string szDeptCode = string.Empty;
            string szDeptName = string.Empty;
            string szDoctor = string.Empty;
            string szPatientID = string.Empty;
            string szVisitID = string.Empty;
            string szTotalPatientID = string.Empty;
            string szTotalVisitID = string.Empty;
            int nDocCount = 0;
            int nDocTotalCount = 0;
            int nDoctorCount = 0;
            List<DeptCheckResult> lstDeptCheckResult = new List<DeptCheckResult>();
            List<QcCheckResult> lstResult = this.ListQcCheckResult.Where(m => m.MSG_DICT_CODE == yunxingCheckResult.MsgDictCode).ToList();
            foreach (var item in lstResult)
            {
                if (szDeptCode != item.DEPT_CODE && !string.IsNullOrEmpty(szDeptCode))
                {
                    DeptCheckResult deptCheckResult = new DeptCheckResult();
                    deptCheckResult.DeptCode = szDeptCode;
                    deptCheckResult.DeptName = szDeptName;
                    deptCheckResult.MsgDictCode = yunxingCheckResult.MsgDictCode;
                    deptCheckResult.DocCount = nDocCount;
                    deptCheckResult.DoctorCount = nDoctorCount;
                    deptCheckResult.DocTotalCount = nDocTotalCount;
                    lstDeptCheckResult.Add(deptCheckResult);
                    nDocCount = 0;
                    nDocTotalCount = 0;
                    nDoctorCount = 0;
                }
                if (szDeptCode != item.DEPT_CODE)
                {
                    szDeptCode = item.DEPT_CODE;
                    szDeptName = item.DEPT_IN_CHARGE;
                }
                if (item.INCHARGE_DOCTOR != szDoctor)
                {
                    szDoctor = item.INCHARGE_DOCTOR;
                    nDoctorCount++;
                }
                if (item.PATIENT_ID != szPatientID && item.VISIT_ID != szVisitID && item.QC_RESULT == 0)
                {
                    szPatientID = item.PATIENT_ID;
                    szVisitID = item.VISIT_ID;
                    nDocCount++;
                }
                if (item.PATIENT_ID != szTotalPatientID && item.VISIT_ID != szTotalVisitID)
                {
                    szTotalPatientID = item.PATIENT_ID;
                    szTotalVisitID = item.VISIT_ID;
                    nDocTotalCount++;
                }

                if (lstResult.IndexOf(item) == lstResult.Count - 1)
                {
                    DeptCheckResult deptCheckResult = new DeptCheckResult();
                    deptCheckResult.DeptCode = szDeptCode;
                    deptCheckResult.DeptName = szDeptName;
                    deptCheckResult.MsgDictCode = yunxingCheckResult.MsgDictCode;
                    deptCheckResult.DocCount = nDocCount;
                    deptCheckResult.DoctorCount = nDoctorCount;
                    deptCheckResult.DocTotalCount = nDocTotalCount;
                    lstDeptCheckResult.Add(deptCheckResult);
                }
            }
            if (lstDeptCheckResult != null && lstDeptCheckResult.Count > 0)
            {
                foreach (var item in lstDeptCheckResult)
                {
                    int rowIndex = this.dataGridView2.Rows.Add();
                    DataGridViewRow row = this.dataGridView2.Rows[rowIndex];
                    row.Tag = item;
                    row.Cells[this.col_2_DeptName.Index].Value = item.DeptName;
                    row.Cells[this.col_2_DocCount.Index].Value = item.DocCount;
                    row.Cells[this.col_2_DoctorCount.Index].Value = item.DoctorCount;
                    row.Cells[this.col_2_DocTotalCount.Index].Value = item.DocTotalCount;
                }
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.dataGridView3.Rows.Clear();
            this.dataGridView4.Rows.Clear();
            DeptCheckResult deptCheckResult = this.dataGridView2.Rows[e.RowIndex].Tag as DeptCheckResult;
            if (deptCheckResult == null)
                return;
            if (deptCheckResult.DocCount <= 0)
            {
                return;
            }
            //过滤缺陷点，统计科室数量
            string szDeptCode = string.Empty;
            string szDeptName = string.Empty;
            string szDoctor = string.Empty;
            string szPatientID = string.Empty;
            string szVisitID = string.Empty;
            string szPatientName = string.Empty;
            string szTotalPatientID = string.Empty;
            string szTotalVisitID = string.Empty;
            List<DocCheckResult> lstDocCheckResult = new List<DocCheckResult>();
            List<QcCheckResult> lstresult = this.ListQcCheckResult.Where(m => m.DEPT_CODE == deptCheckResult.DeptCode && m.MSG_DICT_CODE == deptCheckResult.MsgDictCode).ToList();
            foreach (var item in lstresult)
            {

                if ((szPatientID != item.PATIENT_ID && szVisitID != item.VISIT_ID) && !string.IsNullOrEmpty(szPatientID))
                {
                    DocCheckResult docCheckResult = new DocCheckResult();
                    docCheckResult.DeptCode = szDeptCode;
                    docCheckResult.DeptName = szDeptName;
                    docCheckResult.PatientID = szPatientID;
                    docCheckResult.PatientName = szPatientName;
                    docCheckResult.VisitID = szVisitID;
                    docCheckResult.Doctor = szDoctor;
                    szPatientName = string.Empty;
                    lstDocCheckResult.Add(docCheckResult);
                }
                if (item.PATIENT_ID != szPatientID && item.VISIT_ID != szVisitID && item.QC_RESULT == 0)
                {
                    szDoctor = item.INCHARGE_DOCTOR;
                    szDeptCode = item.DEPT_CODE;
                    szDeptName = item.DEPT_IN_CHARGE;
                    szPatientID = item.PATIENT_ID;
                    szVisitID = item.VISIT_ID;
                    szPatientName = item.PATIENT_NAME;
                }

                if ((lstresult.IndexOf(item) == lstresult.Count - 1) && szPatientName != string.Empty)
                {
                    DocCheckResult docCheckResult = new DocCheckResult();
                    docCheckResult.DeptCode = szDeptCode;
                    docCheckResult.DeptName = szDeptName;
                    docCheckResult.PatientID = szPatientID;
                    docCheckResult.PatientName = szPatientName;
                    docCheckResult.VisitID = szVisitID;
                    docCheckResult.Doctor = szDoctor;
                    lstDocCheckResult.Add(docCheckResult);
                }
            }
            if (lstDocCheckResult != null && lstDocCheckResult.Count > 0)
            {
                foreach (var item in lstDocCheckResult)
                {
                    int rowIndex = this.dataGridView3.Rows.Add();
                    DataGridViewRow row = this.dataGridView3.Rows[rowIndex];
                    row.Tag = item;
                    row.Cells[this.col_3_DeptName.Index].Value = item.DeptName;
                    row.Cells[this.col_3_DoctorName.Index].Value = item.Doctor;
                    row.Cells[this.col_3_PatientID.Index].Value = item.PatientID;
                    row.Cells[this.col_3_PatientName.Index].Value = item.PatientName;
                    row.Cells[this.col_3_VisitID.Index].Value = item.VisitID;
                    row.Cells[this.col_3_VisitID.Index].Value = "1";
                }
            }
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            //if (e.ColumnIndex != this.col_3_PatientID.Index)
            //    return;
            this.dataGridView4.Rows.Clear();
            DocCheckResult docCheckResult = this.dataGridView3.Rows[e.RowIndex].Tag as DocCheckResult;
            if (docCheckResult == null)
                return;
            List<QcCheckResult> lstQcCheckResult = ListQcCheckResult.FindAll(m => m.PATIENT_ID == docCheckResult.PatientID && m.VISIT_ID == docCheckResult.VisitID);
            string szQAEventType = string.Empty;
            YunxingCheckResult yunxingCheckResult = this.dataGridView1.SelectedRows[0].Tag as YunxingCheckResult;
            foreach (var item in lstQcCheckResult)
            {
                int rowIndex = this.dataGridView4.Rows.Add();
                DataGridViewRow row = this.dataGridView4.Rows[rowIndex];
                if (string.IsNullOrEmpty(szQAEventType) || szQAEventType != item.QA_EVENT_TYPE)
                {
                    row.Cells[this.col_4_QAEventType.Index].Value = item.QA_EVENT_TYPE;
                    szQAEventType = item.QA_EVENT_TYPE;
                }
                row.Cells[this.col_4_CheckName.Index].Value = string.IsNullOrEmpty(item.CHECKER_NAME) ? "系统" : "";
                row.Cells[this.col_4_Confirm.Index].Value = item.QC_RESULT == 1 ? "" : "未确认";
                row.Cells[this.col_4_Modify.Index].Value = item.QC_RESULT == 1 ? "" : "未修改";
                row.Cells[this.col_4_QcResult.Index].Value = item.QC_RESULT == 0 ? "不通过" : "通过";
                row.Cells[this.col_4_MsgDictMessage.Index].Value = item.MSG_DICT_MESSAGE;
                row.Tag = item;
                if (yunxingCheckResult != null && yunxingCheckResult.MsgDictCode == item.MSG_DICT_CODE)
                {
                    row.Selected = true;
                    this.dataGridView4.CurrentCell = row.Cells[0];
                }
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.arrowSplitter1.IsExpand = true;
        }

        /// <summary>
        /// 显示文档类型设置对话框
        /// </summary>
        /// <param name="row">指定行</param>
        private void ShowMsgDictSelectForm()
        {
            MsgDictSelectForm msgDictSelectForm = new MsgDictSelectForm();
            msgDictSelectForm.DefaultMsgCode = txtMsgDict.Tag as string;
            msgDictSelectForm.MultiSelect = true;
            msgDictSelectForm.Description = "请选择缺陷内容：";
            if (msgDictSelectForm.ShowDialog() != DialogResult.OK)
                return;
            List<QcMsgDict> lstQcMsgDicts = msgDictSelectForm.SelectedQcMsgDicts;
            if (lstQcMsgDicts == null || lstQcMsgDicts.Count <= 0)
            {
                this.txtMsgDict.Text = "<双击选择>";
                this.txtMsgDict.Tag = null;
                return;
            }

            StringBuilder sbMsgCodeList = new StringBuilder();
            StringBuilder sbMessageList = new StringBuilder();
            for (int index = 0; index < lstQcMsgDicts.Count; index++)
            {
                QcMsgDict qcMsgDict = lstQcMsgDicts[index];
                if (qcMsgDict == null)
                    continue;
                sbMsgCodeList.Append(qcMsgDict.QC_MSG_CODE);
                if (index < lstQcMsgDicts.Count - 1)
                    sbMsgCodeList.Append(";");
                sbMessageList.Append(qcMsgDict.MESSAGE);
                if (index < lstQcMsgDicts.Count - 1)
                    sbMessageList.Append(";");
            }
            txtMsgDict.Text = sbMessageList.ToString();
            txtMsgDict.Tag = sbMsgCodeList.ToString();
        }

        private void txtMsgDict_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowMsgDictSelectForm();
        }
    }
}
