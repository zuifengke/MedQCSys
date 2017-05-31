// ***********************************************************
// 病历编辑器配置管理系统文档类型字典管理窗口时间限编辑窗口.
// Creator:YangMingkun  Date:2010-12-1
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using MedQCSys.DockForms;
namespace Heren.MedQC.Maintenance
{
    internal partial class TimeLineEditForm : DockContentBase
    {
        public TimeLineEditForm()
        {
            this.InitializeComponent();
        }

        private string m_szTimeLine = "24H";
        /// <summary>
        /// 获取或设置当前时间限
        /// </summary>
        public string TimeLine
        {
            get { return this.m_szTimeLine; }
            set { this.m_szTimeLine = value; }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            if (GlobalMethods.Misc.IsEmptyString(this.m_szTimeLine))
                return;
            this.m_szTimeLine = this.m_szTimeLine.Trim().ToUpper();
            if (this.m_szTimeLine.EndsWith("M"))
                this.cboTimeLineType.SelectedIndex = 0;
            else if (this.m_szTimeLine.EndsWith("D"))
                this.cboTimeLineType.SelectedIndex = 1;
            else if (this.m_szTimeLine.EndsWith("H"))
                this.cboTimeLineType.SelectedIndex = 2;
            else
                return;
            if (this.m_szTimeLine.Length <= 1)
                return;
            int nTimeLineValue = 0;
            string szTimeLineValue = this.m_szTimeLine.Substring(0, this.m_szTimeLine.Length - 1);
            if (!int.TryParse(szTimeLineValue, out nTimeLineValue))
                return;
            GlobalMethods.UI.SetUpdownValue(this.nudTimeLineValue, nTimeLineValue);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.cboTimeLineType.SelectedIndex < 0)
                return;
            if (this.cboTimeLineType.SelectedIndex == 0)
                this.m_szTimeLine = string.Concat(this.nudTimeLineValue.Value, "M");
            else if (this.cboTimeLineType.SelectedIndex == 1)
                this.m_szTimeLine = string.Concat(this.nudTimeLineValue.Value, "D");
            else if (this.cboTimeLineType.SelectedIndex == 2)
                this.m_szTimeLine = string.Concat(this.nudTimeLineValue.Value, "H");
            this.DialogResult = DialogResult.OK;
        }
    }
}