using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Heren.Common.RichEditor;
using Heren.MedQC.TimeCheckGener.Controls;
using EMRDBLib;
using EMRDBLib.DbAccess;

namespace Heren.MedQC.TimeCheckGener
{
    public class Editor
    {
        private System.Windows.Forms.Control control = null;
        private static Editor m_Instance = null;

        public static Editor Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new Editor();
                return m_Instance;
            }
        }

        private MedDocSys.PadWrapper.ChenPad.ChenPadCtrl m_ChenPadEditor;

        private MedDocSys.PadWrapper.ChenPad.ChenPadCtrl ChenPadEditor
        {
            get
            {
                if (m_ChenPadEditor == null || m_ChenPadEditor.IsDisposed)
                {
                    m_ChenPadEditor = new MedDocSys.PadWrapper.ChenPad.ChenPadCtrl();
                    m_ChenPadEditor.Size = new System.Drawing.Size(1,1);
                    if (!ParentControl.Controls.Contains(m_ChenPadEditor))
                        ParentControl.Controls.Add(m_ChenPadEditor);
                }
                return m_ChenPadEditor;
            }
        }
        private MedDocSys.PadWrapper.Baodian.BaodianCtrl m_BaodianEditor;

        private MedDocSys.PadWrapper.Baodian.BaodianCtrl BaodianEditor
        {
            get
            {
                if (m_BaodianEditor == null || m_BaodianEditor.IsDisposed)
                {
                    m_BaodianEditor = new MedDocSys.PadWrapper.Baodian.BaodianCtrl();
                    m_BaodianEditor.Size = new System.Drawing.Size(1, 1);
                    if (!ParentControl.Controls.Contains(m_BaodianEditor))
                        ParentControl.Controls.Add(m_BaodianEditor);
                }

                return m_BaodianEditor;
            }
        }

        private HerenEditor m_HerenEditor;

        private HerenEditor HerenEditor
        {
            get
            {
                if (m_HerenEditor == null )
                    m_HerenEditor = new HerenEditor();
                if (!ParentControl.Controls.Contains(m_HerenEditor))
                    ParentControl.Controls.Add(m_HerenEditor);
                return m_HerenEditor;
            }
        }
        public Control ParentControl
        {
            get { return control; }
            set { control = value; }
        }
        private bool LoadMeddoc(MedDocInfo meddocInfo, ref byte[] docBytes)
        {
            if (meddocInfo == null || string.IsNullOrEmpty(meddocInfo.EMR_TYPE))
                return false;
            
            short shRet = EmrDocAccess.Instance.GetDocByID(meddocInfo.DOC_ID, ref docBytes);
            if (shRet != SystemData.ReturnValue.OK || docBytes == null || docBytes.Length <= 0)
                return false;

            return true;
        }

        public string GetDocText(MedDocInfo meddocInfo)
        {
            string szDcoText = string.Empty;
            byte[] docBytes = null;
            if (meddocInfo.EMR_TYPE == "CHENPAD")
            {
                if (!LoadMeddoc(meddocInfo, ref docBytes))
                    return string.Empty;
                ChenPadEditor.OpenDocument(docBytes, false);
                ChenPadEditor.Readonly = false;
                ChenPadEditor.GetPureTextData(ref szDcoText);
            }
            else if (meddocInfo.EMR_TYPE == "BAODIAN")
            {
                if (!LoadMeddoc(meddocInfo, ref docBytes))
                    return string.Empty;
                BaodianEditor.OpenDocument(docBytes, null, false);
                BaodianEditor.GetPureTextData(ref szDcoText);
            }
            else if (meddocInfo.EMR_TYPE == "HEREN")
            {
                if (meddocInfo.DOC_ID != meddocInfo.DOC_SETID)
                    return string.Empty;
                if (!LoadMeddoc(meddocInfo, ref docBytes))
                    return string.Empty;
                HerenEditor.TextEditor.LoadDocument2(docBytes);
                szDcoText = HerenEditor.TextEditor.Text;
            }
            return szDcoText;
        }

        internal void CheckElementBugs(string fileType, ref List<ElementBugInfo> lstElementBugList)
        {
            List<MedDocSys.PadWrapper.ElementBugInfo> bugs = new List<MedDocSys.PadWrapper.ElementBugInfo>();
            if (fileType == "CHENPAD")
            {
                ChenPadEditor.Readonly = false;
                ChenPadEditor.CheckElementBugs(ref bugs);
            }
            else if (fileType == "BAODIAN")
            {
                BaodianEditor.CheckElementBugs(ref bugs);
            }
            else if (fileType == "HEREN")
            {
                lstElementBugList = HerenEditor.GetElementBugs();
            }
            foreach (var item in bugs)
            {
                ElementBugInfo bug = new ElementBugInfo();
                bug.BugDesc = item.BugDesc;
                bug.ElementID = item.ElementID;
                bug.ElementName = item.ElementName;
                bug.ElementType = ElementType.SimpleOption;
                bug.IsFatalBug = item.IsFatalBug;
            }
        }
    }
}
