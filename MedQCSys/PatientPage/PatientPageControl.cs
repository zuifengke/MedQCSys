using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MedQCSys.DockForms;
using EMRDBLib;
using Heren.Common.Libraries;
using Heren.Common.DockSuite;
using MedQCSys.Document;

namespace MedQCSys.PatPage
{
    public partial class PatientPageControl : UserControl
    {
        public MainForm MainForm { get; set; }
        public PatientPageControl()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.patientInfoStrip1.PatientPageControl = this;
        }
        private PatVisitInfo m_patientVisit;
        /// <summary>
        /// 切换当前病人窗口中显示的活动病人
        /// </summary>
        /// <param name="patVisit">新的病人信息</param>
        /// <returns>是否成功</returns>
        public bool SwitchPatient(PatVisitInfo patVisit)
        {
            if (patVisit != null
                && patVisit.IsPatVisitSame(this.m_patientVisit))
            {
                return true;
            }
            SystemParam.Instance.PatVisitInfo = patVisit;
            PatientInfoChangingEventArgs e =
                new PatientInfoChangingEventArgs(this.m_patientVisit, patVisit);
            this.OnPatientInfoChanging(e);
            if (e.Cancel)
                return false;

            //仅第1次加载病人时加载各子窗口
            if (this.m_patientVisit == null)
            {
                this.LoadContentModules();
                this.m_patientVisit = new PatVisitInfo();
            }
            if (patVisit == null)
                patVisit = new PatVisitInfo();
            this.m_patientVisit = patVisit;
            this.OnPatientInfoChanged(EventArgs.Empty);
            return true;
        }

        /// <summary>
        /// 病人就诊等系统基本信息改变前触发
        /// </summary>
        [Description("病人就诊等系统基本信息改变前触发")]
        public event PatientInfoChangingEventHandler PatientInfoChanging;

        internal virtual void OnPatientInfoChanging(PatientInfoChangingEventArgs e)
        {
            if (this.PatientInfoChanging == null)
                return;
            try
            {
                this.PatientInfoChanging(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientPageControl.OnPatientInfoChanging", ex);
            }
        }
        /// <summary>
        /// 病人就诊等系统基本信息改变时触发
        /// </summary>
        [Description("病人就诊等系统基本信息改变时触发")]
        public event EventHandler PatientInfoChanged;
        internal virtual void OnPatientInfoChanged(EventArgs e)
        {
            if (this.PatientInfoChanged == null)
                return;
            try
            {
                this.PatientInfoChanged(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("PatientPageControl.OnPatientInfoChanged", ex);
            }
        }
        /// <summary>
        /// 当活动的停靠窗口改变活动状态时触发
        /// </summary>
        [Description("当活动的停靠窗口改变活动状态时触发")]
        public event EventHandler ActiveContentChanged;
        internal virtual void OnActiveContentChanged(EventArgs e)
        {
            if (this.ActiveContentChanged == null)
                return;
            try
            {
                this.ActiveContentChanged(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocCtrl.OnActiveContentChanged", ex);
            }
        }
        /// <summary>
        /// 当活动的文档窗口改变活动状态时触发
        /// </summary>
        [Description("当活动的文档窗口改变活动状态时触发")]
        public event EventHandler ActiveDocumentChanged;

        internal virtual void OnActiveDocumentChanged(EventArgs e)
        {
            if (this.ActiveDocumentChanged == null)
                return;
            try
            {
                this.ActiveDocumentChanged(this, e);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedDocCtrl.OnActiveDocumentChanged", ex);
            }
        }
        /// <summary>
        /// 加载病人选项卡下的模块列表
        /// </summary>
        private void LoadContentModules()
        {
            //初始化患者病案资料模块
            List<MedQCSys.DockForms.DockContentBase> contents = this.GetPatPageModule();

            foreach (MedQCSys.DockForms.DockContentBase content in contents)
            {
                content.IsHidden = false;
                content.Show(this.dockPanel1, false);
            }
        }
        /// <summary>
        /// 移除所有已打开的窗口
        /// </summary>
        private void CloseAllContentModules()
        {
            while (this.dockPanel1.Contents.Count > 0)
                this.dockPanel1.Contents[0].DockHandler.Close();
        }
        private List<DockContentBase> GetPatPageModule()
        {
            List<MedQCSys.DockForms.DockContentBase> contents = new List<MedQCSys.DockForms.DockContentBase>();
            if (SystemParam.Instance.LocalConfigOption.DefaultEditor == "2")
                contents.Add(new DocumentListNewForm(this.MainForm, this));
            else
                contents.Add(new DocumentListForm(this.MainForm, this));
            contents.Add(new PatientInfoForm(this.MainForm, this));
            contents.Add(new DiagnosisListForm(this.MainForm, this));
            contents.Add(new OrdersListForm(this.MainForm, this));
            contents.Add(new ExamResultListForm(this.MainForm, this));
            contents.Add(new TestResultListForm(this.MainForm, this));
            contents.Add(new DocumentTimeForm(this.MainForm, this));
            if (SystemParam.Instance.LocalConfigOption.IsShowVitalSignsGraph)
                contents.Add(new VitalSignsGraphForm(this.MainForm, this));
            if (SystemParam.Instance.LocalConfigOption.IsShowPatientIndex)
                contents.Add(new PatientIndexForm(this.MainForm, this));
            if (SystemParam.Instance.LocalConfigOption.IsNewScore)
            {
                DocScoreNewForm docScoreNewForm = new DocScoreNewForm(this.MainForm, this);
                contents.Add(docScoreNewForm);
                this.MainForm.DocScoreNewForm = docScoreNewForm;
                docScoreNewForm.HummanScoreSaved += new EventHandler(this.MainForm.DocScoreNewForm_HummanScoreSaved);
                docScoreNewForm.HummanScoreSaved += new EventHandler(this.patientInfoStrip1.DocScoreNewForm_HummanScoreSaved);
            }
            else
            {
                DocScoreForm docScoreForm = new DocScoreForm(this.MainForm, this);
                contents.Add(docScoreForm);
                docScoreForm.DocScoreSaved += new EventHandler(this.MainForm.DocScoreNewForm_HummanScoreSaved);
                docScoreForm.DocScoreSaved += new EventHandler(this.patientInfoStrip1.DocScoreNewForm_HummanScoreSaved);

            }
            if (SystemParam.Instance.LocalConfigOption.IsOpenOperation)
            {
                contents.Add(new OperationForm(this.MainForm, this));

            }
            return contents;
        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {
            this.OnActiveContentChanged(e);
        }

        private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
        {
            this.OnActiveDocumentChanged(e);
        }

        internal void LoadModule(string moduleName)
        {
            if (moduleName == "病案首页")
            {
                foreach (DockContent item in this.dockPanel1.Contents)
                {
                    if (item is PatientIndexForm)
                    {
                        item.Activate();
                    }
                }
            }
            else if (moduleName == "围手术期记录")
            {
                moduleName = "手术记录";
                OpenDocument(moduleName);
            }
            else if (moduleName == "医嘱单及辅助检查"
                || moduleName == "医嘱单")
            {
                foreach (DockContent item in this.dockPanel1.Contents)
                {
                    if (item is OrdersListForm)
                    {
                        item.Activate();
                    }
                }
            }
            else
            {
                OpenDocument(moduleName);
            }

        }
        public void GetActiveDoument(ref DockContentBase activeDocument)
        {
            foreach (DockContentBase item in this.dockPanel1.Contents)
            {
                if (item.IsActivated)
                {
                    activeDocument = item;
                }

            }
        }
        private void OpenDocument(string szDocTitle)
        {
            foreach (DockContent item in this.dockPanel1.Contents)
            {
                if (item is DocumentListNewForm)
                {
                    DocumentListNewForm frm = item as DocumentListNewForm;
                    frm.Activate();
                    frm.OpenDocument(szDocTitle);
                }
            }
        }
    }

}
