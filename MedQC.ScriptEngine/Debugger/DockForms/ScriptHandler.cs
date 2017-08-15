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
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.MedQC.ScriptEngine.Debugger;
using Heren.MedQC.ScriptEngine.Script;

namespace Heren.MedQC.ScriptEngine
{
    internal class ScriptHandler
    {
        private DebuggerForm m_mainForm = null;

        /// <summary>
        /// 获取当前主程序窗口对象
        /// </summary>
        public DebuggerForm MainForm
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

        public ScriptEditForm ActiveScript
        {
            get
            {
                ScriptEditForm activeScript =
                    this.MainForm.ActiveScriptForm as ScriptEditForm;
                if (activeScript == null || activeScript.IsDisposed)
                    return null;
                return activeScript;
            }
        }

        private static ScriptHandler m_instance = null;

        /// <summary>
        /// 获取当前模板处理器实例
        /// </summary>
        public static ScriptHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new ScriptHandler();
                return m_instance;
            }
        }

        private ScriptHandler()
        {
        }

        /// <summary>
        /// 初始化模板处理器程序
        /// </summary>
        /// <param name="mainForm">主程序窗口</param>
        public void InitTempletHandler(DebuggerForm mainForm)
        {
            this.m_mainForm = mainForm;
        }

        private Script.CompileErrorCollection GetCompileErrors(Script.CompileResults results)
        {
            Script.CompileErrorCollection errors = null;
            if (results == null)
                return null;
            errors = results.Errors;
            return errors;
        }

        internal void ShowScriptTestForm()
        {
            //ScriptEditForm scriptForm = this.ActiveScript;
            //if (scriptForm == null)
            //    return;
            //scriptForm = this.GetScriptForm();
            //FormFileParser parser = new FormFileParser();
            //string szScriptData = null;
            //if (scriptForm != null)
            //    szScriptData = scriptForm.Save();
            //else
            //    szScriptData = parser.GetScriptData(designForm.HndfFile);

            //string szDesignData = null;
            //if (designForm != null)
            //    designForm.Save(ref szDesignData);
            //else
            //    szDesignData = parser.GetDesignData(scriptForm.HndfFile);

            ////编译脚本
            //ScriptProperty scriptProperty = new ScriptProperty();
            //scriptProperty.ScriptText = szScriptData;
            //CompileResults results = null;
            //results = ScriptCompiler.Instance.CompileScript(scriptProperty);
            //if (!results.HasErrors)
            //{
            //    this.MainForm.ShowCompileErrorForm(null);
            //}
            //else
            //{
            //    if (scriptForm == null)
            //        this.OpenScriptEditForm(designForm);
            //    this.MainForm.ShowCompileErrorForm(this.GetCompileErrors(results));
            //    MessageBoxEx.Show("编译失败，无法启动测试程序！");
            //    return;
            //}

            //ScriptTestForm scriptTestForm = new ScriptTestForm();
            ////scriptTestForm.ScriptData = szScriptData;
            ////scriptTestForm.DesignData = szDesignData;
            //scriptTestForm.ShowDialog();
        }

        internal ScriptEditForm GetScriptForm(ScriptConfig scriptConfig)
        {
            if (this.MainForm == null)
                return null;
            foreach (IDockContent content in this.MainForm.Documents)
            {
                ScriptEditForm scriptForm = content as ScriptEditForm;
                if (scriptForm == null|| scriptForm.ScriptConfig==null)
                    continue;
                if (scriptForm.ScriptConfig.SCRIPT_ID == scriptConfig.SCRIPT_ID)
                    return scriptForm;
            }
            return null;
        }
        internal short OpenScriptConfig(ScriptConfig scriptConfig)
        {
            if (scriptConfig == null)
                return SystemData.ReturnValue.FAILED;

            ScriptEditForm scriptEditForm = this.GetScriptForm(scriptConfig);
            if (scriptEditForm != null)
            {
                scriptEditForm.Activate();
                return SystemData.ReturnValue.OK;
            }
            scriptEditForm = new ScriptEditForm(this.MainForm);
            scriptEditForm.FlagCode = Guid.NewGuid().ToString();
            scriptEditForm.ScriptConfig = scriptConfig;

            this.MainForm.OpenScriptEditForm(scriptEditForm);

            string szScriptID = scriptConfig.SCRIPT_ID;
            string szHndfFile = string.Format("{0}\\Cache\\{1}.vbs"
                , GlobalMethods.Misc.GetWorkingPath(), szScriptID);

            string byteTempletData = null;
            if (szScriptID != string.Empty)
            {
                short shRet = ScriptConfigAccess.Instance.GetScriptSource(szScriptID, ref byteTempletData);
                if (shRet != SystemData.ReturnValue.OK)
                    return shRet;
            }

            GlobalMethods.IO.WriteFileText(szHndfFile, byteTempletData);
            return scriptEditForm.OpenScriptFile(szHndfFile) ?
                SystemData.ReturnValue.OK : SystemData.ReturnValue.FAILED;
        }

        //internal short OpenTemplet(string szFileName)
        //{
        //    if (string.IsNullOrEmpty(szFileName))
        //        return SystemData.ReturnValue.PARAM_ERROR;
        //    ScriptEditForm designEditForm = new ScriptEditForm(this.MainForm);
        //    designEditForm.FlagCode = Guid.NewGuid().ToString();
        //    this.MainForm.OpenScriptEditForm(designEditForm);

        //    return designEditForm.Open(szFileName) ?
        //        SystemData.ReturnValue.OK : SystemData.ReturnValue.FAILED;
        //}

        internal short OpenTemplet()
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "脚本模板(*.vbs)|*.vbs|所有文件(*.*)|*.*";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() != DialogResult.OK)
                return SystemData.ReturnValue.CANCEL;

            ScriptEditForm designEditForm = new ScriptEditForm(this.MainForm);

            designEditForm.FlagCode = Guid.NewGuid().ToString();
            this.MainForm.OpenScriptEditForm(designEditForm);

            return designEditForm.OpenScriptFile(openDialog.FileName) ?
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
            ScriptEditForm scriptEditForm = this.ActiveScript;
            if (scriptEditForm == null)
                return false;
            FormFileParser parser = new FormFileParser();

            string szScriptSource = scriptEditForm.ScriptProperty.ScriptText;
            byte[] byteScriptData = scriptEditForm.ScriptProperty.ScriptData;

            DialogResult result = MessageBoxEx.ShowQuestion("是否提交到服务器？"
                + "\r\n提交到服务器,请点击“是”按钮!\r\n仅保存到本地,请点击“否”按钮!");
            if (result == DialogResult.Cancel)
                return false;
            bool success = true;
            if (result == DialogResult.No)
                success = this.SaveTempletToLocal(szScriptSource);
            else
                success = this.SaveTempletToServer(szScriptSource, byteScriptData);
            if (success)
            {
                if (scriptEditForm != null) scriptEditForm.IsModified = false;
                //ScriptCache.Instance.Dispose();
                //ScriptCache.Instance.Initialize();
            }
            return success;
        }

        private bool SaveTempletToLocal(string byteTempletData)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "脚本模板(*.vbs)|所有文件(*.*)|*.*";
            saveDialog.Title = "另存为本地模板文件";
            saveDialog.RestoreDirectory = true;

            string szFileName = string.Empty;
            if (this.ActiveScript != null)
                szFileName = this.ActiveScript.Text + ".vbs";
            szFileName = szFileName.Replace("(脚本)", string.Empty);
            szFileName = szFileName.Replace("*", string.Empty);
            saveDialog.FileName = szFileName.Replace(" ", string.Empty);

            if (saveDialog.ShowDialog() != DialogResult.OK)
                return false;

            if (!GlobalMethods.IO.WriteFileText(saveDialog.FileName, byteTempletData))
            {
                MessageBoxEx.Show("文档数据写入文件失败!");
                return false;
            }
            return true;
        }

        private bool SaveTempletToServer(string szScriptSource,byte[] byteScriptData)
        {
            //获取当前模板类型信息
            ScriptConfig scriptConfig = null;
            if (this.ActiveScript != null)
                scriptConfig = this.ActiveScript.ScriptConfig;
            else if (this.ActiveScript != null)
                scriptConfig = this.ActiveScript.ScriptConfig;

            ScriptSelectForm frmTempletSelect = new ScriptSelectForm();
            frmTempletSelect.Description = "请选择需要更新的目标病历模板：";
            frmTempletSelect.MultiSelect = false;
            if (scriptConfig != null)
            {
                frmTempletSelect.DefaultDocTypeID = scriptConfig.SCRIPT_ID;
            }
            if (frmTempletSelect.ShowDialog() != DialogResult.OK)
                return false;
            if (frmTempletSelect.SelectedScriptConfigs == null)
                return false;
            if (frmTempletSelect.SelectedScriptConfigs.Count <= 0)
                return false;

            scriptConfig = frmTempletSelect.SelectedScriptConfigs[0];
            scriptConfig.MODIFY_TIME = SysTimeHelper.Instance.Now;
            short shRet = ScriptConfigAccess.Instance.SaveScriptDataToDB(scriptConfig, szScriptSource, byteScriptData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                string szDocTypeName = scriptConfig.SCRIPT_NAME;
                MessageBoxEx.Show(string.Format("模板“{0}”保存失败!", szDocTypeName));
                return false;
            }
            return true;
        }
    }
}
