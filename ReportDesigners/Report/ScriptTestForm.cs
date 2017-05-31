// ***********************************************************
// 护理病历配置管理系统,报表模板脚本测试窗口.
// Author : YangMingkun, Date : 2012-6-6
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.Report.Loader;
using EMRDBLib;
using EMRDBLib.DbAccess;
namespace Designers.Report
{
    internal partial class ScriptTestForm : HerenForm
    {
        private string m_szScriptData = null;

        /// <summary>
        /// 获取或设置脚本数据
        /// </summary>
        [Browsable(false)]
        public string ScriptData
        {
            get { return this.m_szScriptData; }
            set { this.m_szScriptData = value; }
        }

        private string m_szDesignData = null;

        /// <summary>
        /// 获取或设置设计数据
        /// </summary>
        [Browsable(false)]
        public string DesignData
        {
            get { return this.m_szDesignData; }
            set { this.m_szDesignData = value; }
        }

        public ScriptTestForm()
        {
            this.InitializeComponent();
            this.SaveWindowState = true;
            this.Icon = Properties.Resources.Test;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();

            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            ReportFileParser parser = new ReportFileParser();
            byte[] byteFileData = null;
            parser.MakeReportData(this.m_szDesignData, this.m_szScriptData, out byteFileData);
            this.reportDesigner1.Focus(); 
            this.reportDesigner1.IsDesignMode = true;
            this.reportDesigner1.Readonly = true;
            this.reportDesigner1.OpenDocument(byteFileData);
            this.reportDesigner1.CanvasElement.ShowGrid = false;
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void toolbtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "护理病历文件(*.hndf)|*.hndf|所有文件(*.*)|*.*";
            saveDialog.Title = "另存为本地病历文件";
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.reportDesigner1.SaveDocument(saveDialog.FileName);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void reportDesigner1_ExecuteQuery(object sender, Heren.Common.Report.ExecuteQueryEventArgs e)
        {
            DataSet result = null;
            
            if (CommonAccess.Instance.ExecuteQuery(e.SQL, out result) == SystemData.ReturnValue.OK)
            {
                e.Success = true;
                e.Result = result;
            }
        }

        private void reportDesigner1_ExecuteUpdate(object sender, Heren.Common.Report.ExecuteUpdateEventArgs e)
        {
            if (CommonAccess.Instance.ExecuteUpdate(e.IsProc, e.SQL) == SystemData.ReturnValue.OK)
                e.Success = true;
        }
    }
}
