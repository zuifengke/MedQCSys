using EMRDBLib;
using Heren.Common.Libraries;
using Heren.Common.RichEditor;
using Heren.MedQC.Model.MedDoc;
using MedQCSys.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Frame.Document
{
    public class ChenPadEditor : DocumentEditor
    {
        private bool m_modified = false;
        private AxZJHREMRLib.AxZJHREMR m_textEditor = null;
        private float m_zoom;

        public AxZJHREMRLib.AxZJHREMR TextEditor
        {
            get
            {
                return this.m_textEditor;
            }
        }
        



        private void TextEditor_SelectionChanged(object sender, EventArgs e)
        {
            this.OnSelectionChanged();
        }
        public ChenPadEditor()
        {
            this.SetStyle(ControlStyles.Selectable, true);
        }
        

        public override bool OpenTemplet(byte[] fileData)
        {
            return this.OpenDocument(fileData);
        }
        public override bool OpenDocument(byte[] fileData)
        {
            if (!this.LoadTextEditor())
                return false;

            bool success = false;
            if (fileData == null || fileData.Length <= 0)
            {
                success = this.m_textEditor.FileNew();
                this.m_textEditor.PageFixheaderVisible = false;
                this.m_textEditor.DeletePageHeaderFooter(true);
                this.m_textEditor.DeletePageHeaderFooter(false);
            }
            else
            {
                success = this.m_textEditor.FileOpenBinay(fileData, fileData.Length, 0);
            }
            this.InitPageSettings();
            this.ApplyAutoZoom();
            return success;
        }

        protected PageSettings m_pageSettings = null;
        public override PageSettings PageSettings
        {
            get { return this.m_pageSettings; }
        }

        /// <summary>
        /// 应用文档自动缩放功能
        /// </summary>
        public override void ApplyAutoZoom()
        {
            if (!this.AutoZoom || this.PageSettings == null)
                return;
            float mmWidth = this.PageSettings.Width;
            if (this.PageSettings.Landscape)
                mmWidth = this.PageSettings.Height;
            int width = GlobalMethods.Convert.MMToPixel(mmWidth, false);
            if (this.Width >= width + 64)
            {
                if (this.Zoom < 1f)
                    this.Zoom = 1f;
            }
            else
            {
                float zoomWidth = (float)(this.Width - 64);
                float zoomValue = (float)Math.Round(zoomWidth / width, 2);
                if (zoomValue < 0.1f)
                    zoomValue = 0.1f;
                this.Zoom = zoomValue;
            }
        }
        /// <summary>
        /// 获取当前页面的页面设置参数
        /// </summary>
        /// <param name="pageSettings">页面设置参数</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        private void InitPageSettings()
        {
            if (this.m_pageSettings == null)
                this.m_pageSettings = new PageSettings();
            if (this.TextEditor == null)
                return;
            try
            {
                PageProperty pageProperty = new PageProperty();
                pageProperty.SetPropertyText(this.TextEditor.GetPageSetupInfo());
                if (pageProperty == null)
                    return;

                float zoom = this.TextEditor.ZoomPercentage / 100f;
                this.m_pageSettings.Width = (int)Math.Round(pageProperty.Width / zoom);
                this.m_pageSettings.Height = (int)Math.Round(pageProperty.Height / zoom);
                this.m_pageSettings.Landscape = pageProperty.Landscape;
                this.m_pageSettings.LeftMargin = (int)pageProperty.LeftMargin;
                this.m_pageSettings.RightMargin = (int)pageProperty.RightMargin;
                this.m_pageSettings.TopMargin = (int)pageProperty.TopMargin;
                this.m_pageSettings.BottomMargin = (int)pageProperty.BottomMargin;
                this.m_pageSettings.PageLayout = pageProperty.PageLayout;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ChenPadCtrl.InitPageSettings", ex);
            }
        }
        /// 获取当前选中元素
        /// </summary>
        /// <returns></returns>
        public override StructElement GetCurrentElement()
        {
            if (this.m_textEditor == null || this.m_textEditor.IsDisposed)
                return null;

            try
            {
                string expression = this.m_textEditor.GetFieldElemXmlPath(0);
                if (string.IsNullOrEmpty(expression))
                    return null;

                string[] names = expression.Split(new char[] { '.' }
                    , StringSplitOptions.RemoveEmptyEntries);
                if (names == null || names.Length <= 0)
                    return null;

                StructElement structElement = new StructElement();
                structElement.ElementName = names[names.Length - 1];
                return structElement;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("HerenPad3Editor.GetCurrentElement", ex);
                return null;
            }
        }
        private bool LoadTextEditor()
        {
            if (this.m_textEditor != null)
                return true;
            try
            {
                this.m_textEditor = new AxZJHREMRLib.AxZJHREMR();
                this.m_textEditor.Size = this.Size;
                this.m_textEditor.Dock = DockStyle.Fill;
                this.m_textEditor.Parent = this;
                this.m_textEditor.SetCtrlBgColor(144, 153, 174);
                this.m_textEditor.SetHospitalName(SystemParam.Instance.LocalConfigOption.HOSPITAL_NAME);
                this.m_textEditor.FontInfo +=
                    new AxZJHREMRLib._DZJHREMREvents_FontInfoEventHandler(this.TextEditor_FontInfo);
                return true;
            }
            catch (Exception ex)
            {
                this.RegisterActiveXControl();
                MessageBoxEx.Show("已自动注册该病历的编辑器,请再次打开重试!");
                LogManager.Instance.WriteLog("HerenPad3Editor.LoadTextEditor", "病历编辑器加载失败!", ex);
                return false;
            }
        }

        /// <summary>
        /// 注册OCX编辑器控件
        /// </summary>
        private void RegisterActiveXControl()
        {
            string addinPath = this.GetType().Assembly.Location;
            addinPath = GlobalMethods.IO.GetFilePath(addinPath);
            string szOcxFile = @"\ChenPad\ZJHREMR.ocx";
            GlobalMethods.Win32.InstallActiveXControl(szOcxFile, false);

        }

        private void TextEditor_FontInfo(object sender, AxZJHREMRLib._DZJHREMREvents_FontInfoEvent e)
        {
            this.OnSelectionChanged();
        }
    }
}
