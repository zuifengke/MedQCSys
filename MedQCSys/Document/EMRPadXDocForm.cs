// ***********************************************************
// 病案质控系统陈连忠控件文档显示窗口,主要兼容以前的病历.
// Creator:YangMingkun  Date:2010-11-10
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Windows.Forms;
using MedDocSys.PadWrapper;
 
using MedQCSys.DockForms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using Heren.Common.DockSuite;
using EMRDBLib;

namespace MedQCSys.Document
{
    internal partial class EMRPadXDocForm : DockContentBase, IDocumentForm
    {
        public EMRPadXDocForm(MainForm mainForm)
            : base(mainForm)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.Icon = MedQCSys.Properties.Resources.MedDocIcon;
        }

        #region"IDocumentForm属性"
        /// <summary>
        /// 获取或设置当前文档信息
        /// </summary>
        public  MedDocInfo Document
        {
            get
            {
                if (this.m_documents == null || this.m_documents.Count <= 0)
                    return null;
                return this.m_documents[0];
            }
        }

        private  MedDocList m_documents = null;
        /// <summary>
        /// 获取或设置文档信息列表
        /// </summary>
        public  MedDocList Documents
        {
            get { return this.m_documents; }
        }

        private bool m_bIsEMRPad3 = true;
        /// <summary>
        /// 获取本窗口中编辑器控件
        /// </summary>
        public IMedEditor MedEditor
        {
            get
            {
                if (this.m_bIsEMRPad3)
                {
                    if (this == null || this.EMRPad3Ctrl1.IsDisposed)
                        return null;
                    return this.EMRPad3Ctrl1;
                }
                else
                {
                    if (this == null || this.EPRPad2Ctrl1.IsDisposed)
                        return null;
                    return this.EPRPad2Ctrl1;
                }
            }
        }
        #endregion

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            this.CloseDocument();
            if (this.MedEditor != null) this.EMRPad3Ctrl1.Dispose();
        }

        protected override void OnPatientInfoChanged()
        {
            base.OnPatientInfoChanged();
            this.Close();
        }

        /// <summary>
        /// 刷新文档在文档标签上显示的标题
        /// </summary>
        /// <param name="szDocTitle">缺省标题</param>
        public void RefreshFormTitle(string szDocTitle)
        {
            string szTabText = szDocTitle;
            if (!GlobalMethods.Misc.IsEmptyString(szTabText))
                szTabText = szDocTitle;
            else if (this.Document == null)
                szTabText = "无主题";
            else
                szTabText = this.Document.DOC_TITLE;

            this.Text = string.Concat(szTabText, "(旧)");

            if (this.Document == null)
                this.TabSubhead = string.Empty;
            else
            {
                this.TabSubhead = string.Format("{0} {1}", this.Document.CREATOR_NAME
                    , this.Document.DOC_TIME.ToString("yyyy-M-d HH:mm"));
            }
        }

        /// <summary>
        /// 质控人员打开历史病历
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenHistoryDocument(EMRDBLib.MedicalQcMsg questionInfo)
        {
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 打开指定的EMRPad文档
        /// </summary>
        /// <param name="document">文档信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenDocument( MedDocInfo document)
        {
            this.m_documents = new  MedDocList();
            this.m_documents.Add(document);
            return this.OpenDocument(this.m_documents);
        }

        /// <summary>
        /// 合并打开指定的一系列文档
        /// </summary>
        /// <param name="documents">文档信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenDocument( MedDocList documents)
        {
            this.m_documents = documents;
            this.RefreshFormTitle(null);
            if (this.m_documents == null || this.m_documents.Count <= 0)
                return SystemData.ReturnValue.FAILED;

            short shRet = SystemData.ReturnValue.OK;
            for (int index = 0; index < this.m_documents.Count; index++)
            {
                 MedDocInfo document = this.m_documents[index];
                if (GlobalMethods.Misc.IsEmptyString(document.PATIENT_ID))
                {
                    MessageBoxEx.Show("无法打开旧病历！患者ID为空！");
                    return SystemData.ReturnValue.FAILED;
                }
                if (GlobalMethods.Misc.IsEmptyString(document.VISIT_ID))
                {
                    MessageBoxEx.Show("无法打开旧病历！患者就诊ID非法！");
                    return SystemData.ReturnValue.FAILED;
                }

                string szPatientID = document.PATIENT_ID.Trim().PadLeft(10, '0');
                string szLastTwoChars = szPatientID.Substring(szPatientID.Length - 2);
                string szPrefixChars = szPatientID.Substring(0, szPatientID.Length - 2);

                string szLocalDocDir = string.Format("{0}\\Cache\\EMRPadX", GlobalMethods.Misc.GetWorkingPath());
                GlobalMethods.IO.CreateDirectory(szLocalDocDir);

                string szRemoteFile = string.Format("{0}\\{1}\\{2}", szLastTwoChars, szPrefixChars, document.FileName);
                string szLocalFile = string.Format("{0}\\{1}{2}.emr", szLocalDocDir, document.PATIENT_ID, document.FileName);
               
                if (!GlobalMethods.IO.DeleteFile(szLocalFile))
                {
                    MessageBoxEx.Show(string.Format("病历“{0}”下载失败！", document.DOC_TITLE));
                    return SystemData.ReturnValue.FAILED;
                }
                shRet = MedDocSys.DataLayer.FsrvAccess.Instance.DownloadFile(szRemoteFile, szLocalFile);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.Show(string.Format("病历“{0}”下载失败！", document.DOC_TITLE));
                    return SystemData.ReturnValue.FAILED;
                }

                if (index == 0 && !this.InitMedEditor(szLocalFile))
                {
                    MessageBoxEx.Show("病历打开失败，无法创建病历编辑器控件！");
                    return SystemData.ReturnValue.FAILED;
                }
                if (index == 0)
                {
                    shRet = this.MedEditor.OpenDocument(szLocalFile);
                }
                else
                {
                    if (this.MedEditor.Readonly)
                        this.MedEditor.Readonly = false;
                }
                GlobalMethods.IO.DeleteFile(szLocalFile);
                if (shRet != MedDocSys.DataLayer.SystemData.ReturnValue.OK)
                    break;
            }
            this.MedEditor.Readonly = true;
            return shRet;
        }

        /// <summary>
        /// 打印当前文档
        /// </summary>
        /// <param name="bNeedPreview">是否需要先预览再打印</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short PrintDocument(bool bNeedPreview)
        {
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 关闭当前文档
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short CloseDocument()
        {
            //清空病历内容以及病历信息数据
            this.m_documents = null;
            if (this.MedEditor != null)
            {
                this.MedEditor.CloseDocument();
                this.MedEditor.Dispose();
            }

            return SystemData.ReturnValue.OK;
        }

        private bool InitMedEditor(string szFilePath)
        {
            this.m_bIsEMRPad3 = true;

            byte[] byteDocData = null;
            if (!GlobalMethods.IO.GetFileBytes(szFilePath, ref byteDocData))
                return false;

            //如果病历数据长度不可能小于5
            if (byteDocData == null || byteDocData.Length < 5)
                return false;

            //如果前2个字节是MR,那么使用EMRPad.ocx打开
            if (byteDocData[0] == 0x4D && byteDocData[1] == 0x52)
            {
                this.m_bIsEMRPad3 = true;
                this.EMRPad3Ctrl1.BringToFront();
            }

            //如果前3个字节是EPR,那么使用EPRPad.ocx打开
            else if (byteDocData[0] == 0x45 && byteDocData[1] == 0x50 && byteDocData[2] == 0x52)
            {
                this.m_bIsEMRPad3 = false;
                this.EPRPad2Ctrl1.BringToFront();
            }
            return true;
        }
    }
}