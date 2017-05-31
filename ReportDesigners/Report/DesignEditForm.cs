// ***********************************************************
// 护理病历配置管理系统,报表设计器窗口.
// Author : YangMingkun, Date : 2012-6-6
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Report;
using Heren.Common.Report.Loader;
using Heren.Common.VectorEditor;
using Heren.Common.VectorEditor.Shapes;
using EMRDBLib;
using Designers;

namespace Designers.Report
{
    internal partial class DesignEditForm : DockContentBase, IDesignEditForm
    {
        private ReportType m_reportTemplet = null;

        /// <summary>
        /// 获取当打开的是服务器文件时,
        /// 设计器窗口当前关联的服务器文件信息
        /// </summary>
        public ReportType ReportTemplet
        {
            get { return this.m_reportTemplet; }
        }

        private string m_hndfFile = null;

        /// <summary>
        /// 获取当打开的是本地文件时,
        /// 设计器窗口当前关联的本地文件路径
        /// </summary>
        public string HndfFile
        {
            get { return this.m_hndfFile; }
        }

        private string m_flagCode = null;

        /// <summary>
        /// 获取或设置当前窗口的唯一标识,
        /// 仅用于查找到对应的脚本编辑窗口
        /// </summary>
        public string FlagCode
        {
            get { return this.m_flagCode; }
            set { this.m_flagCode = value; }
        }

        /// <summary>
        /// 获取当前报表设计器控件
        /// </summary>
        public ReportDesigner ReportDesigner
        {
            get { return this.reportDesigner1; }
        }

        private PropertyGrid m_PropertyGrid = null;

        /// <summary>
        /// 获取或设置报表设计器的属性编辑窗口
        /// </summary>
        public PropertyGrid PropertyGrid
        {
            get
            {
                return this.m_PropertyGrid;
            }

            set
            {
                this.m_PropertyGrid = value;
                this.ShowSelectedObjectsProperty();
            }
        }

        private bool m_bIsModified = false;

        /// <summary>
        /// 标识当前脚本是否已经被修改过
        /// </summary>
        public bool IsModified
        {
            get { return this.m_bIsModified; }
            set { this.m_bIsModified = value; }
        }

        public DesignEditForm(DesignForm mainForm)
            : base(mainForm)
        {
            this.InitializeComponent();

            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.toolcboZoom.SelectedIndex = 11;
        }

        /// <summary>
        /// 检查是否有未保存的数据
        /// </summary>
        /// <returns>bool</returns>
        public override bool HasUncommit()
        {
            return this.reportDesigner1.CanUndo();
        }

        /// <summary>
        /// 保存当前窗口的数据修改
        /// </summary>
        /// <returns>bool</returns>
        public override bool CommitModify()
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            bool success = ReportHandler.Instance.SaveReport();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            return success;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                //GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

                //string szReportTypeID = m_reportTemplet.ReportTypeID;
                //if (string.IsNullOrEmpty(szReportTypeID))
                //    return true;
                ////重新查询获取文档类型信息
                //ReportTypeInfo reportTypeInfo = null;
                //short shRet = TempletService.Instance.GetReportTypeInfo(szReportTypeID, ref reportTypeInfo);
                //// 如果本地与服务器的版本相同,则无需重新加载
                //DateTime dtModifyTime = ReportCache.Instance.GetReportModifyTime(szReportTypeID);
                //if (dtModifyTime.CompareTo(reportTypeInfo.ModifyTime) == 0)
                //{
                //    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                //    return true;
                //}
                //byte[] byteTempletData = null;
                //bool result = ReportCache.Instance.GetReportTemplet(reportTypeInfo, ref byteTempletData);
                //if (!result)
                //{
                //    MessageBoxEx.Show("刷新失败");
                //    GlobalMethods.UI.SetCursor(this, Cursors.Default);
                //    return true;
                //}
                //GlobalMethods.UI.SetCursor(this, Cursors.Default);
                //return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        #region"工具栏"
        private void toolbtnPage_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.ShowPageSettings();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ReportHandler.Instance.SaveReport();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnUndo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Undo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnRedo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Redo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnCopy_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Copy();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnCut_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Cut();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnPaste_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Paste();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnDelete_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Delete();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnShowGrid_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            //this.reportDesigner1.CanvasElement.ShowGrid =
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnProperty_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowPropertyEditForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnToolbox_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            //this.MainForm.ShowToolboxListForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnDebug_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ReportHandler.Instance.ShowScriptTestForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnArraw_Click(object sender, EventArgs e)
        {
            this.BeginDraw(null);
        }

        private void toolbtnDrawLine_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new LineElement());
        }

        private void toolbtnDrawRectangle_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new RectangleElement());
        }

        private void toolbtnDrawRoundRect_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new RoundRectElement());
        }

        private void toolbtnDrawCircle_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new CircleElement());
        }

        private void toolbtnDrawArc_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new ArcElement());
        }

        private void toolbtnDrawPolygon_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new PolygonElement());
        }

        private void toolbtnDrawFreeCurve_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new FreeCurveElement());
        }

        private void toolbtnDrawGrid_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new TableElement());
        }

        private void toolbtnDrawRowColumn_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new RowColumnElement());
        }

        private void toolbtnDrawCheckBox_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new CheckBoxElement());
        }

        private void toolbtnDrawRadioBox_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new RadioBoxElement());
        }

        private void toolbtnDrawText_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new TextFieldElement());
        }

        private void toolbtnDrawImage_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new ImageElement());
        }

        private void toolbtnDrawCoordinate_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new CoordinateElement());
        }

        private void toolbtnDrawBarcode_Click(object sender, EventArgs e)
        {
            this.BeginDraw(new BarcodeElement());
        }

        private void toolcboZoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            string szZoomText = this.toolcboZoom.Text;
            if (GlobalMethods.Misc.IsEmptyString(szZoomText))
                return;
            szZoomText = szZoomText.Remove(szZoomText.Length - 1);
            float zoom = GlobalMethods.Convert.StringToValue(szZoomText, 100f);
            this.reportDesigner1.Zoom = zoom / 100f;
        }
        #endregion

        #region"右键菜单"
        private void cmenuDesigner_Opening(object sender, CancelEventArgs e)
        {
            this.mnuUndo.Enabled = this.reportDesigner1.CanUndo();
            this.mnuRedo.Enabled = this.reportDesigner1.CanRedo();

            this.mnuSelectElement.DropDownItems.Clear();

            Point mousePos = Control.MousePosition;
            mousePos = this.reportDesigner1.PointToClient(mousePos);

            List<ElementBase> elements =
                this.reportDesigner1.GetElementAt(mousePos.X, mousePos.Y);
            if (elements == null || elements.Count <= 0)
                elements = new List<ElementBase>();

            elements.Add(this.reportDesigner1.CanvasElement);
            foreach (ElementBase element in elements)
            {
                ToolStripMenuItem menuItem = new ToolStripMenuItem();
                menuItem.Tag = element;
                if (element.Selected)
                    menuItem.Font = new Font(menuItem.Font, FontStyle.Bold);

                menuItem.Text = string.Format("{0}({1})", element.Name, element.Type);
                menuItem.Click += new EventHandler(this.mnuSelectElement_Click);
                this.mnuSelectElement.DropDownItems.Add(menuItem);
            }
        }

        private void mnuSelectElement_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem == null)
                return;
            ElementBase element = menuItem.Tag as ElementBase;
            if (element == null)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.SelectedElements.Clear();
            this.reportDesigner1.SelectedElements.Add(element);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuScript_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ReportHandler.Instance.OpenScriptEditForm(this);
            
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuBringToFront_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.BringToFront(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuSendToBack_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.SendToBack(null);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Undo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuRedo_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Redo();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuCut_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Cut();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuCopy_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Copy();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuPaste_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Paste();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.Delete();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void mnuElementProperty_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.MainForm.ShowPropertyEditForm();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }
        #endregion

        public void UpdateButtonState(ElementBase elememt)
        {
            this.toolbtnArraw.Checked = (elememt == null);
            this.toolbtnDrawLine.Checked = (elememt is LineElement);
            this.toolbtnDrawRectangle.Checked = (elememt is RectangleElement);
            this.toolbtnDrawRoundRect.Checked = (elememt is RoundRectElement);
            this.toolbtnDrawCircle.Checked = (elememt is CircleElement);
            this.toolbtnDrawArc.Checked = (elememt is ArcElement);
            this.toolbtnDrawPolygon.Checked = (elememt is PolygonElement);
            this.toolbtnDrawFreeCurve.Checked = (elememt is FreeCurveElement);
            this.toolbtnDrawGrid.Checked = (elememt is TableElement);
            this.toolbtnDrawRowColumn.Checked = (elememt is RowColumnElement);
            this.toolbtnDrawCheckBox.Checked = (elememt is CheckBoxElement);
            this.toolbtnDrawRadioBox.Checked = (elememt is RadioBoxElement);
            this.toolbtnDrawText.Checked = (elememt is TextFieldElement);
            this.toolbtnDrawImage.Checked = (elememt is ImageElement);
            this.toolbtnDrawBarcode.Checked = (elememt is BarcodeElement);
            this.toolbtnDrawCoordinate.Checked = (elememt is CoordinateElement);
        }

        private void BeginDraw(ElementBase elememt)
        {
            this.reportDesigner1.BeginDraw(elememt);
        }
        /// <summary>
        /// 刷新表单标题
        /// </summary>
        private void RefreshFormText()
        {
            string title = string.Empty;
            string subhead = string.Empty;
            if (this.m_reportTemplet == null)
            {
                title = "新报表模板";
            }
            if (this.m_hndfFile != null)
            {
                title = GlobalMethods.IO.GetFileName(this.m_hndfFile, true);
            }
            if (this.m_reportTemplet != null)
            {
                title = this.m_reportTemplet.ReportTypeName;
                subhead = "更新时间:"
                    + this.m_reportTemplet.ModifyTime.ToString("yyyy年M月d日 HH:mm");
            }
            this.Text = title + "(设计)";
            this.TabSubhead = subhead;
        }

        public bool Open(ReportType reportTemplet)
        {
            return this.Open(reportTemplet, null);
        }

        public bool Open(string szHndfFile)
        {
            return this.Open(null, szHndfFile);
        }

        public bool Open(ReportType reportTemplet, string szHndfFile)
        {
            this.m_hndfFile = szHndfFile;
            this.m_reportTemplet = reportTemplet;
            this.RefreshFormText();
            if (this.MainForm == null)
                return false;

            ReportFileParser parser = new ReportFileParser();
            string szDesignData = null;
            if (System.IO.File.Exists(szHndfFile))
                szDesignData = parser.GetDesignData(szHndfFile);
            this.reportDesigner1.LoadXml(szDesignData);
            return true;
        }

        public bool SetElements(List<ElementBase> elements)
        {
            this.reportDesigner1.Elements.Clear();
            if (elements == null || elements.Count <= 0)
                return false;

            this.reportDesigner1.SuspendLayout();
            CanvasElement canvas = elements[0] as CanvasElement;
            if (canvas != null)
            {
                this.reportDesigner1.CanvasElement.Width = canvas.Width;
                this.reportDesigner1.CanvasElement.Height = canvas.Height;
                elements.Remove(canvas);
            }
            foreach (ElementBase element in elements)
            {
                if (element is CanvasElement)
                    continue;
                this.reportDesigner1.CanvasElement.Elements.Add(element);
            }
            this.reportDesigner1.CanvasElement.ShowGrid = false;
            this.reportDesigner1.PerformLayout();
            return true;
        }

        public bool Save(string szDesignFile)
        {
            this.reportDesigner1.Save(szDesignFile);
            return true;
        }

        public bool Save(ref string szDesignData)
        {
            szDesignData = this.reportDesigner1.Save();
            return true;
        }

        private void reportDesigner1_DoubleClick(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);

            //显示属性
            this.MainForm.ShowPropertyEditForm();

            //复制名称
            SelectedCollection elements = this.reportDesigner1.SelectedElements;
            if (elements != null && elements.Count > 0)
                GlobalMethods.Clipbrd.SetData(elements[0].Name);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void reportDesigner1_ElementBeginDraw(object sender, CanvasEventArgs e)
        {
            if (e.Element != null)
                this.UpdateButtonState(e.Element);
        }

        private void reportDesigner1_ElementEndDraw(object sender, CanvasEventArgs e)
        {
            this.UpdateButtonState(null);
        }

        private void reportDesigner1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.reportDesigner1.SelectedElements.Count <= 0)
                return;
            ElementBase element = this.reportDesigner1.SelectedElements[0] as ElementBase;
            if (element != null)
                this.ShowStatusMessage("主选中图形:" + element.Name);
            this.ShowSelectedObjectsProperty();
        }

        private void ShowSelectedObjectsProperty()
        {
            if (this.m_PropertyGrid == null || this.m_PropertyGrid.IsDisposed)
                return;
            this.m_PropertyGrid.SelectedObjects = this.reportDesigner1.SelectedElements.ToArray();
        }
    }
}
