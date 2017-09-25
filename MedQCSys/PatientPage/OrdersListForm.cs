// ***********************************************************
// 医嘱列表显示窗口.
// Creator:YangMingkun  Date:2009-11-7
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using System.Linq;
using Heren.Common.Report;
using Heren.Common.VectorEditor;
using EMRDBLib.DbAccess;
using EMRDBLib.Entity;
using EMRDBLib;
using Heren.MedQC.Utilities;
using Heren.MedQC.Core;

namespace MedQCSys.DockForms
{
    public partial class OrdersListForm : DockContentBase
    {
        public OrdersListForm(MainForm parent)
            : base(parent)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.CloseButtonVisible = true;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }

        public OrdersListForm(MainForm parent, PatPage.PatientPageControl patientPageControl)
            : base(parent, patientPageControl)
        {
            this.InitializeComponent();
            this.HideOnClose = true;
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.CloseButtonVisible = true;
            this.dataGridView1.Font = new Font("宋体", 10.5f);
        }
        /// <summary>
        /// 标识值改变事件是否可用,避免重复执行
        /// </summary>
        private bool m_bValueChangedEnabled = true;
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!SystemParam.Instance.LocalConfigOption.PrintAndExcel)
            {
                this.btnExport.Visible = false;
                this.btnPrint.Visible = false;
            }
            this.m_bValueChangedEnabled = false;
            if (this.toolcboOrdersType.Items.Count > 0)
                this.toolcboOrdersType.SelectedIndex = 0;

            this.m_bValueChangedEnabled = true;
            if (SystemParam.Instance.LocalConfigOption.IsOrderTextAll)
            {
                this.colDosage.Visible = false;
                this.colDosageUnits.Visible = false;
                this.colFrequency.Visible = false;
                this.colAdministration.Visible = false;
                this.colOrderText.Width = 350;

            }
        }
        public override void OnRefreshView()
        {
            base.OnRefreshView();
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.ShowStatusMessage("正在下载医嘱记录，请稍候...");
            //医生下达医嘱标志
            int nOrderFlag = 0;
            this.LoadOrderInfoList(nOrderFlag);
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

        /// <summary>
        /// 更新医嘱列表显示，edited by FYB in 20091117
        /// <param name="nOrderFlag">医嘱标识(0-医生下达的医嘱 1-护士转抄的医嘱)</param>
        /// </summary>
        private void LoadOrderInfoList(int nOrderFlag)
        {
            this.dataGridView1.Rows.Clear();
            this.lblOrdersInfo.Text = "仍在执行的医嘱数目：0 条";
            if (this.MainForm == null || this.MainForm.IsDisposed)
                return;
            if (SystemParam.Instance.PatVisitInfo == null)
                return;
            bool bIsRepeat = this.toolcboOrdersType.SelectedIndex == 1;
            String bIsRepeatAll = this.toolcboOrdersType.Text;
            string szOrderText = this.tbOrderText.Text;
            string szPatientID = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
            string szVisitID = SystemParam.Instance.PatVisitInfo.VISIT_ID;
            List<OrderInfo> lstOrderInfo = null;
            if (GlobalMethods.Misc.IsEmptyString(szPatientID) || GlobalMethods.Misc.IsEmptyString(szVisitID))
            {
                return;
            }
            short shRet = OrdersAccess.Instance.GetInpOrderList(szPatientID, szVisitID, szOrderText, nOrderFlag, ref lstOrderInfo);
            if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.CANCEL
                && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                MessageBoxEx.Show("更新医嘱列表失败！");
                return;
            }
            if (lstOrderInfo == null || lstOrderInfo.Count <= 0)
            {
                return;
            }
            lstOrderInfo = lstOrderInfo.OrderBy(m => m.EnterTime).ToList();
            //先对父子医嘱进行分组

            Dictionary<string, List<OrderInfo>> dicOrderList =
                new Dictionary<string, List<OrderInfo>>();
            for (int index = 0; index < lstOrderInfo.Count; index++)
            {
                OrderInfo orderInfo = lstOrderInfo[index];
                if (orderInfo == null || string.IsNullOrEmpty(orderInfo.OrderNO))
                    continue;
                if (bIsRepeatAll != "全部"&& bIsRepeatAll != string.Empty)
                {
                    if (orderInfo.IsRepeat != bIsRepeat)
                        continue;
                }
                List<OrderInfo> lstOrderList = null;
                if (dicOrderList.ContainsKey(orderInfo.OrderNO))
                {
                    lstOrderList = dicOrderList[orderInfo.OrderNO];
                }
                else
                {
                    lstOrderList = new List<OrderInfo>();
                    dicOrderList.Add(orderInfo.OrderNO, lstOrderList);
                }
                if (orderInfo.OrderSubNO != "1")
                    lstOrderList.Add(orderInfo);
                else
                    lstOrderList.Insert(0, orderInfo);
            }
            List<OrderInfo>[] arrOrderList =
              new List<OrderInfo>[dicOrderList.Values.Count];
            dicOrderList.Values.CopyTo(arrOrderList, 0);
            string strOrderCatagrate = string.Empty;

            int nRowIndex = 0;
            int nUnStopedOrderCount = 0;
            for (int nListIndex = 0; nListIndex < arrOrderList.Length; nListIndex++)
            {
                List<OrderInfo> lstOrderList = arrOrderList[nListIndex];
                for (int index = 0; index < lstOrderList.Count; index++)
                {
                    OrderInfo orderInfo = lstOrderList[index];
                    if (orderInfo == null)
                        continue;
                    if (orderInfo.OrderStatus == SystemData.OrderStatus.Process)
                        nUnStopedOrderCount++;
                    if (!this.CheckOrderShow(orderInfo))
                        continue;
                    nRowIndex = this.dataGridView1.Rows.Add();
                    DataGridViewRow row = this.dataGridView1.Rows[nRowIndex];
                    this.SetRowData(row, orderInfo);

                    if (lstOrderList.Count > 1)
                    {
                        if (index == 0)
                            row.Cells[this.colSubFlag.Index].Value = "┓";
                        else if (index == lstOrderList.Count - 1)
                            row.Cells[this.colSubFlag.Index].Value = "┛";
                        else
                            row.Cells[this.colSubFlag.Index].Value = "┃";
                    }
                    this.dataGridView1.SetRowState(row.Index, Heren.Common.Controls.TableView.RowState.Normal);
                }
            }
            this.dataGridView1.Tag = string.Format("患者{0}第{1}次就诊的的医嘱信息详单", szPatientID, szVisitID);
            this.lblOrdersInfo.Text = string.Format("仍在执行的医嘱数目：{0} 条", nUnStopedOrderCount);
        }

        /// <summary>
        /// 设置指定行显示的数据,以及绑定的数据
        /// </summary>
        /// <param name="row">指定行</param>
        /// <param name="orderInfo">绑定的数据</param>
        private void SetRowData(DataGridViewRow row, OrderInfo orderInfo)
        {
            if (row == null || row.Index < 0 || orderInfo == null)
                return;
            row.Tag = orderInfo;

            //红色表示作废，蓝色表示停止
            if (orderInfo.OrderStatus == "4")
                row.DefaultCellStyle.ForeColor = Color.Red;
            else if (orderInfo.IsStartStop)
                row.DefaultCellStyle.ForeColor = Color.Blue;
            row.Cells[this.colOrderNo.Index].Value = orderInfo.OrderNO;
            row.Cells[this.colOrderSubNo.Index].Value = orderInfo.OrderSubNO;
            row.Cells[this.colOrderText.Index].Value = orderInfo.OrderText;
            if (orderInfo.Dosage > 0f)
                row.Cells[this.colDosage.Index].Value = orderInfo.Dosage;
            row.Cells[this.colDosageUnits.Index].Value = orderInfo.DosageUnits;
            row.Cells[this.colAdministration.Index].Value = orderInfo.Administration;
            row.Cells[this.colFrequency.Index].Value = orderInfo.Frequency;
            if (orderInfo.OrderSubNO == "1")
            {
                row.Cells[this.colRepeatIndicator.Index].Value = orderInfo.IsRepeat ? "长期" : "临时";
                row.Cells[this.colOrderStatus.Index].Value = SystemData.OrderStatus.GetOrderStatusDesc(orderInfo.OrderStatus);
                if (orderInfo.START_DATE_TIME != orderInfo.DefaultTime)
                    row.Cells[this.col_START_DATE_TIME.Index].Value = orderInfo.START_DATE_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colEnterTime.Index].Value = orderInfo.EnterTime.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colOrderClass.Index].Value = orderInfo.OrderClass;
                if (orderInfo.StopTime != orderInfo.DefaultTime)
                    row.Cells[this.colStopTime.Index].Value = orderInfo.StopTime.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colOrderDoctor.Index].Value = orderInfo.Doctor;
                row.Cells[this.colNurse.Index].Value = orderInfo.Nurse;
                if (orderInfo.PERFORM_TIME != orderInfo.DefaultTime)
                    row.Cells[this.col_PERFORM_TIME.Index].Value = orderInfo.PERFORM_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colStopDoctor.Index].Value = orderInfo.STOP_DOCTOR;
                if (orderInfo.PROCESSING_END_TIME != orderInfo.DefaultTime)
                    row.Cells[this.col_PROCESSING_END_TIME.Index].Value = orderInfo.PROCESSING_END_TIME.ToString("yyyy-MM-dd HH:mm");
                row.Cells[this.colStopNurse.Index].Value = orderInfo.STOP_NURSE;
                row.Cells[this.colStopDoctor.Index].Value = orderInfo.STOP_DOCTOR;
            }
        }
        // <summary>
        /// 根据是否停止来判断是否显示在界面上
        /// <param name="orderInfo">医嘱</param>
        /// <returns>是否应该显示</returns>
        private bool CheckOrderShow(OrderInfo orderInfo)
        {
            if (orderInfo == null || orderInfo.OrderClass == null)
                return false;
            if (orderInfo.OrderStatus == "2" && orderInfo.IsRepeat)
            {
                return true;
            }
            if (!orderInfo.IsRepeat || (orderInfo.IsRepeat && (orderInfo.OrderStatus == "3" || orderInfo.OrderStatus == "4")))
            {
                return true;
            }
            return false;
        }
        private ReportExplorerForm GetReportExplorerForm()
        {
            ReportExplorerForm reportExplorerForm = new ReportExplorerForm();
            reportExplorerForm.WindowState = FormWindowState.Maximized;
            reportExplorerForm.QueryContext +=
                new QueryContextEventHandler(this.ReportExplorerForm_QueryContext);
            reportExplorerForm.NotifyNextReport +=
                new NotifyNextReportEventHandler(this.ReportExplorerForm_NotifyNextReport);
            return reportExplorerForm;
        }

        /// <summary>
        /// 加载打印模板
        /// </summary>
        private byte[] GetReportFileData(string szReportName)
        {
            if (GlobalMethods.Misc.IsEmptyString(szReportName))
                szReportName = string.Format("{0}\\Templet\\{1}.hrdt", GlobalMethods.Misc.GetWorkingPath(), "医嘱信息清单");
            if (!System.IO.File.Exists(szReportName))
            {
                MessageBoxEx.ShowError("医嘱信息清单报表还没有制作!");
                return null;
            }

            byte[] byteTempletData = null;
            if (!GlobalMethods.IO.GetFileBytes(szReportName, ref byteTempletData))
            {
                MessageBoxEx.ShowError("医嘱信息清单报表内容下载失败!");
                return null;
            }
            return byteTempletData;
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
            if (SystemContext.Instance.GetSystemContext(name, ref value))
                return true;
            return false;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可打印内容！");
                return;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            string szReportName = string.Empty;
            if (this.toolcboOrdersType.Text == "全部")
                szReportName = "医嘱内容";
            else if (this.toolcboOrdersType.Text == "长期医嘱")
                szReportName = "长期医嘱单";
            else if (this.toolcboOrdersType.Text == "临时医嘱")
                szReportName = "临时医嘱单";
            ReportType reportType = ReportCache.Instance.GetWardReportType(SystemData.ReportTypeApplyEnv.ORDERS, szReportName);
            if (reportType == null)
            {
                MessageBoxEx.ShowMessage("打印报表还没有制作");
                return;
            }
            byte[] byteReportData = null;
            ReportCache.Instance.GetReportTemplet(reportType, ref byteReportData);
            if (byteReportData != null)
            {
                System.Data.DataTable table = GlobalMethods.Table.GetDataTable(this.dataGridView1, false, 0);
                ReportExplorerForm explorerForm = this.GetReportExplorerForm();
                explorerForm.ReportFileData = byteReportData;
                explorerForm.ReportParamData.Add("是否续打", false);
                explorerForm.ReportParamData.Add("打印数据", table);
                explorerForm.ShowDialog();
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.Rows.Count <= 0)
            {
                MessageBoxEx.Show("当前没有可导出的内容！", MessageBoxIcon.Information);
                return;
            }
            Hashtable htNoExportColunms = new Hashtable();
            StatExpExcelHelper.Instance.HtNoExportColIndex = htNoExportColunms;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            StatExpExcelHelper.Instance.ExportToExcel(this.dataGridView1, "医嘱内容清单");
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void ckbSwitch_CheckedChanged(object sender, EventArgs e)
        {
            int nOrderFlag = 0;
            //if (this.ckbSwitch.Checked)
            //    nOrderFlag = 1;
            this.LoadOrderInfoList(nOrderFlag);
        }

        private void ReportExplorerForm_QueryContext(object sender, Heren.Common.Report.QueryContextEventArgs e)
        {
            object value = e.Value;
            e.Success = this.GetSystemContext(e.Name, ref value);
            if (e.Success) e.Value = value;
        }

        private void ReportExplorerForm_NotifyNextReport(object sender, Heren.Common.Report.NotifyNextReportEventArgs e)
        {
            e.ReportData = this.GetReportFileData(e.ReportName);
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            int nOrderFlag = 0;
            this.LoadOrderInfoList(nOrderFlag);
        }

        private void OrdersListForm_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tbOrderText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoadOrderInfoList(0);
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if ((e.ColumnIndex >= 3 && e.ColumnIndex <= 7) & e.RowIndex > -1)
            //{
            //    using (var rowPen = new Pen(Color.Gray, 1))
            //    using (var gridlinePen = new Pen(Color.White, 1))
            //    {
            //        var topLeftPoint = new Point(e.CellBounds.Left - 1, e.CellBounds.Top - 1);
            //        var topRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Top - 1);
            //        var bottomRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
            //        var bottomLeftPoint = new Point(e.CellBounds.Left - 1, e.CellBounds.Bottom - 1);
            //        e.Paint(e.ClipBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
            //        if (e.ColumnIndex == 3)
            //        {
            //            e.Graphics.DrawLine(rowPen, bottomLeftPoint, topLeftPoint);
            //            e.Graphics.DrawLine(gridlinePen, bottomRightPoint, topRightPoint);

            //        }
            //        else if (e.ColumnIndex == 7)
            //        {
            //            e.Graphics.DrawLine(gridlinePen, bottomLeftPoint, topLeftPoint);
            //            e.Graphics.DrawLine(rowPen, bottomRightPoint, topRightPoint);
            //        }
            //        else
            //        {
            //            e.Graphics.DrawLine(gridlinePen, bottomRightPoint, topRightPoint);
            //            e.Graphics.DrawLine(gridlinePen, bottomLeftPoint, topLeftPoint);
            //        }
            //        e.Graphics.DrawLine(rowPen, bottomRightPoint, bottomLeftPoint);
            //        e.Graphics.DrawLine(rowPen, topLeftPoint, topRightPoint);
            //        e.Handled = true;
            //    }

            //}
        }

        private void toolcboOrdersType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.m_bValueChangedEnabled)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.LoadOrderInfoList(0);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
    }
}