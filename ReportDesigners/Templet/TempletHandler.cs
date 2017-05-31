// ***********************************************************
// 护理病历配置管理系统,表单模板设计模块管理器.
// 主要负责表单模板文件的下载,实例化设计器,并加载表单模板文件
// Author : YangMingkun, Date : 2012-6-6
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using Heren.Common.Forms.Loader;
using Heren.Common.Forms.Runtime;
using EMRDBLib;
using EMRDBLib.DbAccess;

namespace Designers.Templet
{
    internal class TempletHandler
    {
        private DesignForm m_mainForm = null;

        /// <summary>
        /// 获取当前主程序窗口对象
        /// </summary>
        public DesignForm MainForm
        {
            get
            {
                if (this.m_mainForm == null)
                    return null;
                if (this.m_mainForm.IsDisposed)
                    return null;
                return this.m_mainForm;
            }
        }

        public DesignEditForm ActiveTemplet
        {
            get
            {
                DesignEditForm activeTemplet =
                    this.MainForm.ActiveDocument as DesignEditForm;
                if (activeTemplet == null || activeTemplet.IsDisposed)
                    return null;
                return activeTemplet;
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

        private static TempletHandler m_instance = null;

        /// <summary>
        /// 获取当前模板处理器实例
        /// </summary>
        public static TempletHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new TempletHandler();
                return m_instance;
            }
        }

        private TempletHandler()
        {
        }

        /// <summary>
        /// 初始化模板处理器程序
        /// </summary>
        /// <param name="mainForm">主程序窗口</param>
        public void InitTempletHandler(DesignForm mainForm)
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
            DesignEditForm designForm = this.ActiveTemplet;
            ScriptEditForm scriptForm = this.ActiveScript;
            if (scriptForm == null && designForm == null)
                return;

            if (designForm != null)
                scriptForm = this.GetScriptForm(designForm);
            else if (scriptForm != null)
                designForm = this.GetDesignForm(scriptForm);

            FormFileParser parser = new FormFileParser();
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

        internal DesignEditForm GetDesignForm(TempletType docTypeInfo)
        {
            if (docTypeInfo == null)
                return null;
            return this.GetDesignForm(docTypeInfo.DocTypeID);
        }

        internal DesignEditForm GetDesignForm(string szDocTypeID)
        {
            if (this.MainForm == null || string.IsNullOrEmpty(szDocTypeID))
                return null;
            foreach (IDockContent content in this.MainForm.Documents)
            {
                DesignEditForm designForm = content as DesignEditForm;
                if (designForm == null || designForm.DocTypeInfo == null)
                    continue;
                if (designForm.DocTypeInfo.DocTypeID == szDocTypeID)
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
            return scriptEditForm.Open(designForm.DocTypeInfo, designForm.HndfFile);
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
            designEditForm = new DesignEditForm(this.MainForm);
            designEditForm.FlagCode = scriptForm.FlagCode;
            this.MainForm.OpenDesignEditForm(designEditForm);
            return designEditForm.Open(scriptForm.DocTypeInfo, scriptForm.HndfFile);
        }

        internal short OpenTemplet(TempletType docTypeInfo)
        {
            if (docTypeInfo == null)
                return SystemData.ReturnValue.FAILED;

            DesignEditForm designEditForm = this.GetDesignForm(docTypeInfo);
            if (designEditForm != null)
            {
                designEditForm.Activate();
                return SystemData.ReturnValue.OK;
            }
            designEditForm = new DesignEditForm(this.MainForm);
            designEditForm.FlagCode = Guid.NewGuid().ToString();
            this.MainForm.OpenDesignEditForm(designEditForm);

            string szDocTypeID = docTypeInfo.DocTypeID;
            string szHndfFile = string.Format("{0}\\Cache\\{1}.hndt"
                , GlobalMethods.Misc.GetWorkingPath(), szDocTypeID);

            byte[] byteTempletData = null;
            if (szDocTypeID != string.Empty)
            {
                short shRet = TempletTypeAccess.Instance.GetTempletData(szDocTypeID, ref byteTempletData);
                if (shRet != SystemData.ReturnValue.OK)
                    return shRet;

            }

            GlobalMethods.IO.WriteFileBytes(szHndfFile, byteTempletData);
            return designEditForm.Open(docTypeInfo, szHndfFile) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.FAILED;
        }

        internal short OpenTemplet(string szFileName)
        {
            if (string.IsNullOrEmpty(szFileName))
                return SystemData.ReturnValue.PARAM_ERROR;
            DesignEditForm designEditForm = new DesignEditForm(this.MainForm);
            designEditForm.FlagCode = Guid.NewGuid().ToString();
            this.MainForm.OpenDesignEditForm(designEditForm);

            return designEditForm.Open(szFileName) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.FAILED;
        }

        internal short OpenTemplet()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "护理病历模板(*.hndt)|*.hndt|所有文件(*.*)|*.*";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() != DialogResult.OK)
                return SystemData.ReturnValue.CANCEL;

            DesignEditForm designEditForm = new DesignEditForm(this.MainForm);
            designEditForm.FlagCode = Guid.NewGuid().ToString();
            this.MainForm.OpenDesignEditForm(designEditForm);

            return designEditForm.Open(openDialog.FileName) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.FAILED;
        }

        //internal short OpenTemplet(DocTypeInfo docTypeInfo)
        //{
        //    if (docTypeInfo == null)
        //        return SystemData.ReturnValue.FAILED;

        //    DesignEditForm designEditForm = this.GetDesignForm(docTypeInfo);
        //    if (designEditForm != null)
        //    {
        //        designEditForm.Activate();
        //        return SystemData.ReturnValue.OK;
        //    }
        //    designEditForm = new DesignEditForm(this.MainForm);
        //    designEditForm.FlagCode = Guid.NewGuid().ToString();
        //    this.MainForm.OpenDesignEditForm(designEditForm);

        //    string szDocTypeID = docTypeInfo.DocTypeID;
        //    string szHndfFile = string.Format("{0}\\Cache\\{1}.hndt"
        //        , GlobalMethods.Misc.GetWorkingPath(), szDocTypeID);

        //    byte[] byteTempletData = null;
        //    //short shRet = TempletService.Instance.GetFormTemplet(szDocTypeID, ref byteTempletData);
        //    //if (shRet != SystemData.ReturnValue.OK)
        //    //    return shRet;

        //    GlobalMethods.IO.WriteFileBytes(szHndfFile, byteTempletData);
        //    return designEditForm.Open(docTypeInfo, szHndfFile) ?
        //        SystemData.ReturnValue.OK : SystemData.ReturnValue.FAILED;
        //}

        /// <summary>
        /// 保存当前正在编辑的模板文件
        /// </summary>
        /// <returns>bool</returns>
        internal bool SaveTemplet()
        {
            DesignEditForm designForm = this.ActiveTemplet;
            ScriptEditForm scriptForm = this.ActiveScript;
            if (scriptForm == null && designForm == null)
                return false;

            if (designForm != null)
                scriptForm = this.GetScriptForm(designForm);
            else if (scriptForm != null)
                designForm = this.GetDesignForm(scriptForm);

            FormFileParser parser = new FormFileParser();
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
            parser.MakeFormData(szDesignData, szScriptData, out byteTempletData);

            DialogResult result = MessageBoxEx.ShowQuestion("是否提交到服务器？"
                + "\r\n提交到服务器,请点击“是”按钮!\r\n仅保存到本地,请点击“否”按钮!");
            if (result == DialogResult.Cancel)
                return false;
            bool success = true;
            if (result == DialogResult.No)
                success = this.SaveTempletToLocal(byteTempletData);
            else
                success = this.SaveTempletToServer(byteTempletData);
            if (success)
            {
                if (designForm != null) designForm.IsModified = false;
                if (scriptForm != null) scriptForm.IsModified = false;
            }
            return success;
        }

        private bool SaveTempletToLocal(byte[] byteTempletData)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "护理病历模板(*.hndt)|*.hndt|所有文件(*.*)|*.*";
            saveDialog.Title = "另存为本地模板文件";
            saveDialog.RestoreDirectory = true;

            string szFileName = string.Empty;
            if (this.ActiveTemplet != null)
                szFileName = this.ActiveTemplet.Text + ".hndt";
            else if (this.ActiveScript != null)
                szFileName = this.ActiveScript.Text + ".hndt";
            szFileName = szFileName.Replace("(设计)", string.Empty);
            szFileName = szFileName.Replace("(脚本)", string.Empty);
            szFileName = szFileName.Replace(".hndt", string.Empty);
            szFileName = szFileName.Replace("*", string.Empty);
            saveDialog.FileName = szFileName.Replace(" ", string.Empty);

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return false;

            if (!GlobalMethods.IO.WriteFileBytes(saveDialog.FileName, byteTempletData))
            {
                MessageBoxEx.Show("文档数据写入文件失败!");
                return false;
            }
            return true;
        }

        private bool SaveTempletToServer(byte[] byteTempletData)
        {
            //获取当前模板类型信息
            TempletType docTypeInfo = null;
            if (this.ActiveTemplet != null)
                docTypeInfo = this.ActiveTemplet.DocTypeInfo;
            else if (this.ActiveScript != null)
                docTypeInfo = this.ActiveScript.DocTypeInfo;

            TempletSelectForm frmTempletSelect = new TempletSelectForm();
            frmTempletSelect.Description = "请选择需要更新的目标病历模板：";
            frmTempletSelect.MultiSelect = false;
            if (docTypeInfo != null)
            {
                frmTempletSelect.ApplyEnv = docTypeInfo.ApplyEnv;
                frmTempletSelect.DefaultDocTypeID = docTypeInfo.DocTypeID;
            }
            if (frmTempletSelect.ShowDialog() != DialogResult.OK)
                return false;
            if (frmTempletSelect.SelectedDocTypes == null)
                return false;
            if (frmTempletSelect.SelectedDocTypes.Count <= 0)
                return false;

            docTypeInfo = frmTempletSelect.SelectedDocTypes[0];
            short shRet =TempletTypeAccess.Instance.SaveTempletDataToDB(docTypeInfo.DocTypeID, byteTempletData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                string szDocTypeName = docTypeInfo.DocTypeName;
                MessageBoxEx.Show(string.Format("模板“{0}”保存失败!", szDocTypeName));
                return false;
            }
            return true;
        }
    }
}
