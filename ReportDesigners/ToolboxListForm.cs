// ***********************************************************
// 护理病历配置管理系统,模板设计器控件工具箱窗口.
// Author : YangMingkun, Date : 2012-3-20
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;
using Heren.Common.DockSuite;
using Designers.Templet;
namespace Designers
{
    public partial class ToolboxListForm : DockContentBase
    {
        public ToolboxListForm(DesignForm mainForm)
            : base(mainForm)
        {
            this.HideOnClose = true;
            this.ShowHint = DockState.DockLeft;
            this.DockAreas = DockAreas.DockLeft | DockAreas.DockLeft
                | DockAreas.DockTop | DockAreas.DockBottom;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.InitializeComponent();
            this.UpdateBounds();
            this.Icon = Properties.Resources.ToolboxIcon;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.toolbox1.InitializeToolbox();
            if (TempletHandler.Instance.ActiveTemplet != null)
                TempletHandler.Instance.ActiveTemplet.FormDesigner.Toolbox = this.toolbox1;
        }

        protected override void OnActiveDocumentChanged()
        {
            base.OnActiveDocumentChanged();
            if (TempletHandler.Instance.ActiveTemplet != null)
                TempletHandler.Instance.ActiveTemplet.FormDesigner.Toolbox = this.toolbox1;
        }
    }
}
