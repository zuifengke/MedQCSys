// ***********************************************************
// 护理病历配置管理系统,报表设计模块管理器.
// 主要负责报表文件的下载,实例化设计器,并加载报表文件
// Author : YangMingkun, Date : 2012-6-6
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Report.Runtime;
using Heren.Common.Report.Loader;
using Heren.Common.VectorEditor.Shapes;
using EMRDBLib;
using Designers.Report;
using EMRDBLib.DbAccess;

namespace Designers
{
    internal class ReportHandler
    {
        private DesignForm m_mainForm = null;

        /// <summary>
        /// 获取当前主程序窗口对象
        /// </summary>
        public DesignForm MainForm
        {
            get
            {
                if (this.m_mainForm == null || this.m_mainForm.IsDisposed)
                    return null;
                return this.m_mainForm;
            }
        }

        public DesignEditForm ActiveReport
        {
            get
            {
                DesignEditForm activeReport =
                    this.MainForm.ActiveDocument as DesignEditForm;
                if (activeReport == null || activeReport.IsDisposed)
                    return null;
                return activeReport;
            }
        }

        public ScriptEditForm ActiveScript
        {
            get
            {
                ScriptEditForm activeScript =
                    this.MainForm.ActiveDocument as ScriptEditForm;
                if (activeScript == null || activeScript.IsDisposed)
                    return null;
                return activeScript;
            }
        }

        private static ReportHandler m_instance = null;

        /// <summary>
        /// 获取当前报表处理器实例
        /// </summary>
        public static ReportHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new ReportHandler();
                return m_instance;
            }
        }

        private ReportHandler()
        {
        }

        /// <summary>
        /// 初始化报表处理器程序
        /// </summary>
        /// <param name="mainForm">主程序窗口</param>
        public void InitReportHandler(DesignForm mainForm)
        {
            this.m_mainForm = mainForm;
        }

        private ErrorsListForm.CompileError[] GetCompileErrors(CompileResults results)
        {
            ErrorsListForm.CompileError[] errors = null;
            if (results == null)
                return null;
            errors = new ErrorsListForm.CompileError[results.Errors.Count];
            for (int index = 0; index < errors.Length; index++)
            {
                CompileError error = results.Errors[index];
                errors[index] = new ErrorsListForm.CompileError();
                errors[index].Line = error.Line;
                errors[index].Column = error.Column;
                errors[index].ErrorText = error.ErrorText;
                errors[index].FileName = error.FileName;
                errors[index].IsWarning = error.IsWarning;
            }
            return errors;
        }

        internal void ShowScriptTestForm()
        {
            DesignEditForm designForm = this.ActiveReport;
            ScriptEditForm scriptForm = this.ActiveScript;
            if (scriptForm == null && designForm == null)
                return;

            if (designForm != null)
                scriptForm = this.GetScriptForm(designForm);
            else if (scriptForm != null)
                designForm = this.GetDesignForm(scriptForm);

            ReportFileParser parser = new ReportFileParser();
            string szScriptData = null;
            if (scriptForm != null)
                szScriptData = scriptForm.Save();
            else
                szScriptData = parser.GetScriptData(designForm.HndfFile);

            string szDesignData = null;
            if (designForm != null)
                designForm.Save(ref szDesignData);
            else
                szDesignData = parser.GetDesignData(scriptForm.HndfFile);

            //编译脚本
            ScriptProperty scriptProperty = new ScriptProperty();
            scriptProperty.ScriptText = szScriptData;
            CompileResults results = null;
            results = ScriptCompiler.Instance.CompileScript(scriptProperty);
            if (!results.HasErrors)
            {
                this.MainForm.ShowCompileErrorForm(null);
            }
            else
            {
                if (scriptForm == null)
                    this.OpenScriptEditForm(designForm);
                this.MainForm.ShowCompileErrorForm(this.GetCompileErrors(results));
                MessageBoxEx.Show("编译失败，无法启动测试程序！");
                return;
            }

            ScriptTestForm scriptTestForm = new ScriptTestForm();
            scriptTestForm.ScriptData = szScriptData;
            scriptTestForm.DesignData = szDesignData;
            scriptTestForm.ShowDialog();
        }

        internal ScriptEditForm GetScriptForm(DesignEditForm designForm)
        {
            if (this.MainForm == null || designForm == null)
                return null;
            foreach (IDockContent content in this.MainForm.Documents)
            {
                ScriptEditForm scriptForm = content as ScriptEditForm;
                if (scriptForm == null)
                    continue;
                if (scriptForm.FlagCode == designForm.FlagCode)
                    return scriptForm;
                if (scriptForm.HndfFile == designForm.HndfFile)
                    return scriptForm;
            }
            return null;
        }

        internal DesignEditForm GetDesignForm(ScriptEditForm scriptForm)
        {
            if (this.MainForm == null || scriptForm == null)
                return null;
            foreach (IDockContent content in this.MainForm.Documents)
            {
                DesignEditForm designForm = content as DesignEditForm;
                if (designForm == null)
                    continue;
                if (designForm.FlagCode == scriptForm.FlagCode)
                    return designForm;
                if (designForm.HndfFile == scriptForm.HndfFile)
                    return designForm;
            }
            return null;
        }

        internal DesignEditForm GetDesignForm(ReportType reportTemplet)
        {
            if (reportTemplet == null)
                return null;
            return this.GetDesignForm(reportTemplet.ReportTypeID);
        }

        internal DesignEditForm GetDesignForm(string szTempletID)
        {
            if (this.MainForm == null || string.IsNullOrEmpty(szTempletID))
                return null;
            foreach (IDockContent content in this.MainForm.Documents)
            {
                DesignEditForm designForm = content as DesignEditForm;
                if (designForm == null || designForm.ReportTemplet == null)
                    continue;
                if (designForm.ReportTemplet.ReportTypeID == szTempletID)
                    return designForm;
            }
            return null;
        }

        internal bool OpenScriptEditForm(DesignEditForm designForm)
        {
            if (designForm == null || designForm.IsDisposed)
                return false;

            ScriptEditForm scriptEditForm = this.GetScriptForm(designForm);
            if (scriptEditForm != null)
            {
                scriptEditForm.DockHandler.Activate();
                return true;
            }
            scriptEditForm = new ScriptEditForm(this.MainForm);
            scriptEditForm.FlagCode = designForm.FlagCode;
            this.MainForm.OpenScriptEditForm(scriptEditForm);
            return scriptEditForm.Open(designForm.ReportTemplet, designForm.HndfFile);
        }

        internal bool OpenDesignEditForm(ScriptEditForm scriptForm)
        {
            if (scriptForm == null || scriptForm.IsDisposed)
                return false;

            DesignEditForm designEditForm = this.GetDesignForm(scriptForm);
            if (designEditForm != null)
            {
                designEditForm.DockHandler.Activate();
                return true;
            }
            designEditForm = new DesignEditForm(this.m_mainForm);
            designEditForm.FlagCode = scriptForm.FlagCode;
            this.MainForm.OpenDesignEditForm(designEditForm);
            return designEditForm.Open(scriptForm.ReportTemplet, scriptForm.HndfFile);
        }

        internal short CreateReport(List<ElementBase> elements)
        {
            DesignEditForm designEditForm = new DesignEditForm(this.MainForm);
            designEditForm.FlagCode = Guid.NewGuid().ToString();
            this.MainForm.OpenDesignEditForm(designEditForm);
            bool success = designEditForm.Open(null, null);
            if (success)
                success = designEditForm.SetElements(elements);
            return success ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        internal short OpenReport(string szFileName)
        {
            if (string.IsNullOrEmpty(szFileName))
                return SystemData.ReturnValue.PARAM_ERROR;
            DesignEditForm designEditForm = new DesignEditForm(this.MainForm);
            designEditForm.FlagCode = Guid.NewGuid().ToString();
            this.MainForm.OpenDesignEditForm(designEditForm);

            return designEditForm.Open(szFileName) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.PARAM_ERROR;
        }

        internal short OpenReport()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "护理病历模板(*.hrdt)|*.hrdt|所有文件(*.*)|*.*";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() != DialogResult.OK)
                return SystemData.ReturnValue.ACCESS_ERROR;
            if (this.MainForm == null)
                return SystemData.ReturnValue.ACCESS_ERROR;
            DesignEditForm designEditForm = new DesignEditForm(this.MainForm);
            designEditForm.FlagCode = Guid.NewGuid().ToString();
            this.MainForm.OpenDesignEditForm(designEditForm);

            return designEditForm.Open(openDialog.FileName) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.PARAM_ERROR;
        }

        internal short NewReport(ReportType reportTemplet)
        {
            if (reportTemplet == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            DesignEditForm designEditForm = this.GetDesignForm(reportTemplet);
            if (designEditForm != null)
            {
                designEditForm.Activate();
                return SystemData.ReturnValue.OK;
            }
            designEditForm = new DesignEditForm(this.MainForm);
            designEditForm.FlagCode = Guid.NewGuid().ToString();
            this.MainForm.OpenDesignEditForm(designEditForm);

            string szReportTypeID = reportTemplet.ReportTypeID;
            string szHndfFile = string.Format("{0}\\Cache\\{1}.hrdt"
                , GlobalMethods.Misc.GetWorkingPath(), szReportTypeID);
            //byte[] byteTempletData = null;
            //short shRet = ReportTypeAccess.Instance.GetReportData(szReportTypeID, ref byteTempletData);
            //if (shRet != SystemData.ReturnValue.OK)
            //    return shRet;
            //GlobalMethods.IO.WriteFileBytes(szHndfFile, byteTempletData);
            return designEditForm.Open(reportTemplet, szHndfFile) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }
        internal short OpenReport(ReportType reportTemplet)
        {
            if (reportTemplet == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            DesignEditForm designEditForm = this.GetDesignForm(reportTemplet);
            if (designEditForm != null)
            {
                designEditForm.Activate();
                return SystemData.ReturnValue.OK;
            }
            designEditForm = new DesignEditForm(this.MainForm);
            designEditForm.FlagCode = Guid.NewGuid().ToString();
            this.MainForm.OpenDesignEditForm(designEditForm);

            string szReportTypeID = reportTemplet.ReportTypeID;
            string szHndfFile = string.Format("{0}\\Cache\\{1}.hrdt"
                , GlobalMethods.Misc.GetWorkingPath(), szReportTypeID);

            byte[] byteTempletData = null;
            short shRet =ReportTypeAccess.Instance.GetReportData(szReportTypeID, ref byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
                return shRet;
            GlobalMethods.IO.WriteFileBytes(szHndfFile, byteTempletData);
            return designEditForm.Open(reportTemplet, szHndfFile) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
        }

        /// <summary>
        /// 保存当前正在编辑的模板文件
        /// </summary>
        /// <returns>bool</returns>
        internal bool SaveReport()
        {
            DesignEditForm designForm = this.ActiveReport;
            ScriptEditForm scriptForm = this.ActiveScript;
            if (scriptForm == null && designForm == null)
                return false;

            if (designForm != null)
                scriptForm = this.GetScriptForm(designForm);
            else if (scriptForm != null)
                designForm = this.GetDesignForm(scriptForm);

            ReportFileParser parser = new ReportFileParser();
            string szScriptData = null;
            if (scriptForm != null)
                szScriptData = scriptForm.Save();
            else
                szScriptData = parser.GetScriptData(designForm.HndfFile);

            string szDesignData = null;
            if (designForm != null)
                designForm.Save(ref szDesignData);
            else
                szDesignData = parser.GetDesignData(scriptForm.HndfFile);

            byte[] byteTempletData = null;
            parser.MakeReportData(szDesignData, szScriptData, out byteTempletData);

            DialogResult result = MessageBoxEx.ShowQuestion("是否提交到服务器？"
                + "\r\n提交到服务器,请点击“是”按钮!\r\n仅保存到本地,请点击“否”按钮!");
            if (result == DialogResult.Cancel)
                return false;
            bool success = true;
            if (result == DialogResult.No)
                success = this.SaveReportToLocal(byteTempletData);
            else
                success = this.SaveReportToServer(byteTempletData);
            if (success)
            {
                if (designForm != null) designForm.IsModified = false;
                if (scriptForm != null) scriptForm.IsModified = false;
            }
            return success;
        }

        private bool SaveReportToLocal(byte[] byteTempletData)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "护理报表模板(*.hrdt)|*.hrdt|所有文件(*.*)|*.*";
            saveDialog.Title = "另存为本地模板文件";
            saveDialog.RestoreDirectory = true;

            string szFileName = string.Empty;
            if (this.ActiveReport != null)
                szFileName = this.ActiveReport.Text + ".hrdt";
            else if (this.ActiveScript != null)
                szFileName = this.ActiveScript.Text + ".hrdt";
            szFileName = szFileName.Replace("(设计)", string.Empty);
            szFileName = szFileName.Replace("(脚本)", string.Empty);
            szFileName = szFileName.Replace(".hrdt", string.Empty);
            szFileName = szFileName.Replace("*", string.Empty);
            saveDialog.FileName = szFileName.Replace(" ", string.Empty);

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return false;

            if (!GlobalMethods.IO.WriteFileBytes(saveDialog.FileName, byteTempletData))
            {
                MessageBoxEx.Show("报告数据写入文件失败!");
                return false;
            }
            return true;
        }

        private bool SaveReportToServer(byte[] byteTempletData)
        {
            //获取当前报告信息
            ReportType reportTemplet = null;
            if (this.ActiveReport != null)
                reportTemplet = this.ActiveReport.ReportTemplet;
            else if (this.ActiveScript != null)
                reportTemplet = this.ActiveScript.ReportTemplet;

            ReportSelectForm frmTempletSelect = new ReportSelectForm();
            frmTempletSelect.Description = "请选择需要更新的目标报表模板：";
            frmTempletSelect.MultiSelect = false;
            if (reportTemplet != null)
            {
                frmTempletSelect.ReportType = reportTemplet.ApplyEnv;
                frmTempletSelect.DefaultTempletID = reportTemplet.ReportTypeID;
            }
            if (frmTempletSelect.ShowDialog() != DialogResult.OK)
                return false;
            if (frmTempletSelect.SelectedTemplets == null)
                return false;
            if (frmTempletSelect.SelectedTemplets.Count <= 0)
                return false;

            reportTemplet = frmTempletSelect.SelectedTemplets[0];
            short shRet =ReportTypeAccess.Instance.SaveReportDataToDB(reportTemplet.ReportTypeID, byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                string szTempletName = reportTemplet.ReportTypeName;
                MessageBoxEx.Show(string.Format("报表模板“{0}”保存失败!", szTempletName));
                return false;
            }
            return true;
        }
    }
}
