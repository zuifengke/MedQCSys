using EMRDBLib;
using EMRDBLib.DbAccess;
using EMRDBLib.Entity;
using Heren.Common.Controls.TableView;
using Heren.Common.Libraries;
using Heren.MedQC.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.CheckPoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.LoadGridViewData();
        }
        private void LoadGridViewData()
        {
            this.dataGridView1.Rows.Clear();
            Dictionary<string, string> dicTimeEventName = new Dictionary<string, string>();
            List<TimeQCEvent> lstTimeQCEvents = null;
            short result = EMRDBLib.DbAccess.TimeQCEventAccess.Instance.GetTimeQCEvents(ref lstTimeQCEvents);
            if (result != EMRDBLib.SystemData.ReturnValue.OK
                && result != EMRDBLib.SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.ShowError("病历时效事件列表下载失败!");
                return;
            }
            for (int index = 0; lstTimeQCEvents != null; index++)
            {
                if (index >= lstTimeQCEvents.Count)
                    break;
                if (lstTimeQCEvents[index] == null)
                    continue;
                string szEventID = lstTimeQCEvents[index].EventID;
                if (string.IsNullOrEmpty(szEventID))
                    continue;
                string szEventName = lstTimeQCEvents[index].EventName;
                if (string.IsNullOrEmpty(szEventName))
                    continue;
                dicTimeEventName.Add(szEventID, szEventName);
            }


            List<QcCheckPoint> lstQcCheckPoints = null;
            result = EMRDBLib.DbAccess.QcCheckPointAccess.Instance.GetQcCheckPoints(ref lstQcCheckPoints);
            if (result != EMRDBLib.SystemData.ReturnValue.OK
                && result != EMRDBLib.SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("自动核查规则列表下载失败!");
                return;
            }
            if (lstQcCheckPoints == null || lstQcCheckPoints.Count <= 0)
                return;
            for (int index = 0; index < lstQcCheckPoints.Count; index++)
            {
                QcCheckPoint qcCheckPoint = lstQcCheckPoints[index];
                if (qcCheckPoint == null)
                    continue;
                string szEventName = qcCheckPoint.EventID;
                if (!string.IsNullOrEmpty(szEventName))
                {
                    if (dicTimeEventName.ContainsKey(szEventName))
                        szEventName = dicTimeEventName[szEventName];
                }
                qcCheckPoint.EventName = szEventName;

                int nRowIndex = this.dataGridView1.Rows.Add();
                DataTableViewRow row = this.dataGridView1.Rows[nRowIndex];
                this.SetRowData(row, qcCheckPoint);
                this.dataGridView1.SetRowState(row, RowState.Normal);
            }
        }

        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="qcCheckPoint">绑定的数据</param>
        private void SetRowData(DataTableViewRow row, QcCheckPoint qcCheckPoint)
        {
            if (row == null || row.Index < 0 || qcCheckPoint == null)
                return;
            row.Tag = qcCheckPoint;
            row.Cells[this.colQaEventType.Index].Value = qcCheckPoint.QaEventType;
            row.Cells[this.colCheckType.Index].Value = qcCheckPoint.CheckType;
            row.Cells[this.colCheckPointContent.Index].Value = qcCheckPoint.CheckPointContent;
            row.Cells[this.colCheckPointID.Index].Tag = qcCheckPoint.CheckPointID;
            row.Cells[this.colCheckPointID.Index].Value = qcCheckPoint.CheckPointID;
            row.Cells[this.colDocType.Index].Tag = qcCheckPoint.DocTypeID;
            row.Cells[this.colDocType.Index].Value = qcCheckPoint.DocTypeName;
            row.Cells[this.colWrittenPeriod.Index].Value = qcCheckPoint.WrittenPeriod;
            if (qcCheckPoint.Score > 0)
                row.Cells[this.colQCScore.Index].Value = qcCheckPoint.Score;
            row.Cells[this.colIsValid.Index].Value = qcCheckPoint.IsValid;
            row.Cells[this.colMsgDictMessage.Index].Value = qcCheckPoint.MsgDictMessage;
            row.Cells[this.colExpression.Index].Value = qcCheckPoint.Expression;
            row.Cells[this.colHandlerCommand.Index].Value = qcCheckPoint.HandlerCommand;
            row.Cells[this.colEvent.Index].Value = qcCheckPoint.EventName;
            row.Cells[this.colEvent.Index].Tag = qcCheckPoint.EventID;
            row.Cells[this.colIsRepeat.Index].Value = qcCheckPoint.IsRepeat;
            row.Cells[this.colQaEventType.Index].Value = qcCheckPoint.QaEventType;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PatVisitInfo patVisitLog = new PatVisitInfo();
            patVisitLog.PATIENT_ID = "P099634";
            patVisitLog.VISIT_ID = "20150722000000000002";
            patVisitLog.VISIT_TIME = DateTime.Now.AddDays(-2);
            CheckPointHelper.Instance.InitPatientInfo(patVisitLog);
            QcCheckPoint qcCheckPoint = new QcCheckPoint();
            qcCheckPoint.CheckPointID = "P201608261507573079";
            short shRet = QcCheckPointAccess.Instance.GetQcCheckPoint(qcCheckPoint.CheckPointID, ref qcCheckPoint);
            Object result = null;
            CommandHandler.Instance.SendCommand(qcCheckPoint.HandlerCommand, qcCheckPoint, patVisitLog, out result);
            QcCheckResult qcCheckResult = result as QcCheckResult;
            shRet = QcCheckResultAccess.Instance.SaveQcCheckResult(qcCheckResult);
            if (qcCheckResult.QC_RESULT == 1)
            {
                MessageBox.Show("检查通过");
                return;
            }
            MessageBox.Show(qcCheckResult.QC_EXPLAIN);
        }
        
        private void button11_Click_1(object sender, EventArgs e)
        {
            this.LoadGridViewData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (!(column is DataGridViewButtonColumn))
                    return;
                QcCheckPoint qcCheckPoint = this.dataGridView1.Rows[e.RowIndex].Tag as QcCheckPoint;
                if (string.IsNullOrEmpty(qcCheckPoint.HandlerCommand))
                    return;
                Object result = null;

                DateTime startTime = DateTime.Now;
                PatVisitInfo patVisitLog = new PatVisitInfo() { PATIENT_ID = this.txtPatientID.Text, VISIT_ID = this.txtVisitID.Text };

                Heren.MedQC.CheckPoint.CheckPointHelper.Instance.InitPatientInfo(patVisitLog);
                CommandHandler.Instance.SendCommand(qcCheckPoint.HandlerCommand, qcCheckPoint, patVisitLog, out result);
                //这里可以编写你需要的任意关于按钮事件的操作~
                QcCheckResult qcCheckResult = result as QcCheckResult;
                short shRet = QcCheckResultAccess.Instance.SaveQcCheckResult(qcCheckResult);

                string time = (DateTime.Now - startTime).TotalSeconds.ToString();
                this.label3.Text = "耗时：" + time;

                if (qcCheckResult == null)
                {
                    return;
                }
                if (qcCheckResult.QC_RESULT == 1)
                {
                    MessageBoxEx.ShowMessage("规则通过");
                    return;
                }
                MessageBox.Show(qcCheckResult.QC_EXPLAIN);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("单规则测试出错", ex);
                MessageBoxEx.ShowErrorFormat("单规则测试出错", ex.ToString(), null);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
                DateTime startTime = DateTime.Now;
                PatVisitInfo patVisitLog = new PatVisitInfo();
                patVisitLog.PATIENT_ID = this.txtPatientID.Text;
                patVisitLog.VISIT_ID = this.txtVisitID.Text;
                CheckPointHelper.Instance.CheckPatient(patVisitLog);

                string time = (DateTime.Now - startTime).TotalSeconds.ToString();
                this.label3.Text = "耗时：" + time;
                List<QcCheckResult> lstQcCheckResult = null;
                this.dataGridView4.Rows.Clear();
                short shRet = QcCheckResultAccess.Instance.GetQcCheckResults(patVisitLog.DefaultTime, patVisitLog.DefaultTime, patVisitLog.PATIENT_ID, patVisitLog.VISIT_ID, null, null,null,0, ref lstQcCheckResult);
                    
                foreach (var item in lstQcCheckResult)
                {
                    int rowIndex = this.dataGridView4.Rows.Add();
                    DataGridViewRow row = this.dataGridView4.Rows[rowIndex];
                    row.Cells[this.col_4_QcResult.Index].Value = item.QC_RESULT == 0 ? "不通过" : "通过";
                    row.Cells[this.col_4_MsgDictMessage.Index].Value = item.MSG_DICT_MESSAGE;
                    row.Cells[this.colQcExplain.Index].Value = item.QC_EXPLAIN;
                    row.Tag = item;
                }

                GlobalMethods.UI.SetCursor(this, Cursors.Default);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("单患者运行所有规则出错",ex);
                MessageBoxEx.ShowErrorFormat("单患者运行所有规则出错",ex.ToString(),null);
            }
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
    }
}
