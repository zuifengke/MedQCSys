// ***********************************************************
// 病案质控系统Word文档显示窗口,主要兼容以前的Word病历.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Windows.Forms;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using MedDocSys.PadWrapper;
 
using MedQCSys.DockForms;
using Heren.Common.DockSuite;
using EMRDBLib;

namespace MedQCSys.Document
{
    internal partial class WinWordDocForm : DockContentBase, IDocumentForm
    {
        public WinWordDocForm(MainForm mainForm)
            : base(mainForm)
        {
            this.InitializeComponent();
            this.ShowHint = DockState.Document;
            this.DockAreas = DockAreas.Document;
            this.winWordCtrl1.ShowInternalMenuStrip = true;
            this.Icon = MedQCSys.Properties.Resources.WordDocIcon;
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

        /// <summary>
        /// 获取本窗口中编辑器控件
        /// </summary>
        public IMedEditor MedEditor
        {
            get
            {
                if (this.winWordCtrl1 == null || this.winWordCtrl1.IsDisposed)
                    return null;
                return this.winWordCtrl1;
            }
        }
        #endregion

        /// <summary>
        /// 打开的word文档本地缓存路径
        /// </summary>
        private string m_szCacheFile = string.Empty;

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (this.DockPanel == null && this.ContainsFocus)
                this.BringToFront();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            this.CloseDocument();
            if (this.winWordCtrl1 != null && !this.winWordCtrl1.IsDisposed)
                this.winWordCtrl1.Dispose();
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

            this.Text = string.Concat(szTabText, "(Word)");

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
        /// 打开指定的Word文档
        /// </summary>
        /// <param name="document">文档信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenDocument( MedDocInfo document)
        {
            if (document == null)
            {
                MessageBoxEx.Show("无法打开文档！文档信息非法！");
                return SystemData.ReturnValue.FAILED;
            }
            this.m_documents = new  MedDocList();
            this.m_documents.Add(document);
            this.RefreshFormTitle(null);
            if (this.Document.FilePath == MedDocSys.DataLayer.SystemData.StorageMode.DB)
                return this.OpenDocumentFromDB();
            else
                return this.OpenDocumentFromFS();
        }

        /// <summary>
        /// 从数据库二进制字段中打开指定的Word文档
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        private short OpenDocumentFromDB()
        {
            if (this.Document == null || string.IsNullOrEmpty(this.Document.DOC_ID))
            {
                MessageBoxEx.Show("无法打开文档！文档信息非法！");
                return SystemData.ReturnValue.FAILED;
            }

            string szLocalDocDir = string.Format("{0}\\Cache\\Word", GlobalMethods.Misc.GetWorkingPath());
            GlobalMethods.IO.CreateDirectory(szLocalDocDir);
            string szLocalFile = string.Format("{0}\\{1}{2}.doc", szLocalDocDir
                , this.Document.PATIENT_ID, this.Document.FileName);

            byte[] byteDocData = null;
            short shRet = MedDocSys.DataLayer.DataAccess.GetPastDocData(this.Document.DOC_ID, ref byteDocData);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show(string.Format("病历“{0}”下载失败！", this.Document.DOC_TITLE));
                return SystemData.ReturnValue.FAILED;
            }
            if (!GlobalMethods.IO.WriteFileBytes(szLocalFile, byteDocData))
            {
                MessageBoxEx.Show(string.Format("病历“{0}”本地写入失败！", this.Document.DOC_TITLE));
                return SystemData.ReturnValue.FAILED;
            }
            this.m_szCacheFile = szLocalFile;
            this.winWordCtrl1.OpenDocument(this.m_szCacheFile);
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 从文件服务器上打开指定的Word文档
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        private short OpenDocumentFromFS()
        {
            if (this.Document == null || string.IsNullOrEmpty(this.Document.FileName))
            {
                MessageBoxEx.Show("无法打开文档！文档信息非法！");
                return SystemData.ReturnValue.FAILED;
            }

            if (GlobalMethods.Misc.IsEmptyString(this.Document.PATIENT_ID))
            {
                MessageBoxEx.Show("无法打开Word病历！患者ID为空！");
                return SystemData.ReturnValue.FAILED;
            }
            if (GlobalMethods.Misc.IsEmptyString(this.Document.VISIT_ID))
            {
                MessageBoxEx.Show("无法打开Word病历！患者就诊ID非法！");
                return SystemData.ReturnValue.FAILED;
            }

            string szLocalDocDir = string.Format("{0}\\Cache\\Word", GlobalMethods.Misc.GetWorkingPath());
            GlobalMethods.IO.CreateDirectory(szLocalDocDir);

            string szPatientID = this.Document.PATIENT_ID.Trim().PadLeft(10, '0');
            string szLastTwoChars = szPatientID.Substring(szPatientID.Length - 2);
            string szPrefixChars = szPatientID.Substring(0, szPatientID.Length - 2);
            string szRemoteFile = string.Format("{0}\\{1}\\{2}", szLastTwoChars, szPrefixChars, this.Document.FileName);
            string szLocalFile = string.Format("{0}\\{1}{2}.doc", szLocalDocDir
                , this.Document.PATIENT_ID, this.Document.FileName);
            short shRet;
            
            if (!GlobalMethods.IO.DeleteFile(szLocalFile))
            {
                MessageBoxEx.Show(string.Format("病历“{0}”下载失败！", this.Document.DOC_TITLE));
                return SystemData.ReturnValue.FAILED;
            }
            shRet = MedDocSys.DataLayer.FsrvAccess.Instance.DownloadFile(szRemoteFile, szLocalFile);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show(string.Format("病历“{0}”下载失败！", this.Document.DOC_TITLE));
                return SystemData.ReturnValue.FAILED;
            }
            this.m_szCacheFile = szLocalFile;
            this.winWordCtrl1.OpenDocument(this.m_szCacheFile);
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 合并打开指定的一系列文档
        /// </summary>
        /// <param name="documents">文档信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short OpenDocument( MedDocList documents)
        {
            return SystemData.ReturnValue.OK;
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
            if (this.winWordCtrl1 != null && !this.winWordCtrl1.IsDisposed)
            {
                this.winWordCtrl1.CloseDocument();
                this.winWordCtrl1.CloseWordApplication();
            }
            GlobalMethods.IO.DeleteFile(this.m_szCacheFile);
            this.m_szCacheFile = string.Empty;
            this.m_documents = null;
            return SystemData.ReturnValue.OK;
        }
    }
}