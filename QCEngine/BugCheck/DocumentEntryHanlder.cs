// ***********************************************************
// 病历文档系统文档质控引擎,文档类型的原子规则(Entry)处理器
// Creator:YangMingkun  Date:2009-8-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using EMRDBLib;
namespace MedDocSys.QCEngine.BugCheck
{
    internal class DocumentEntryHanlder : BugCheckEntryHandlerBase
    {
        private Hashtable m_htDocumentEntry = null;

        private int m_nEntryMinLen = 0;
        private int m_nEntryMaxLen = 0;

        public DocumentEntryHanlder(BugCheckEngine clsQCEngine)
            : base(clsQCEngine)
        {
            this.m_nEntryMinLen = int.MaxValue;
            this.m_nEntryMaxLen = int.MinValue;
            this.m_htDocumentEntry = new Hashtable();
        }

        public override void AddEntry(BugCheckEntry qcEntry)
        {
            base.AddEntry(qcEntry);
            if (qcEntry == null || qcEntry.EntryValue == null)
                return;
            if (qcEntry.EntryValue.Trim() == string.Empty)
                return;
            List<BugCheckEntry> lstEntrys = null;

            //把关键字添加到Hashtable中,以便在遍历文档时可由关键字快速获取Entry
            string szEntryValue = qcEntry.EntryValue.Trim();
            object obj = this.m_htDocumentEntry[szEntryValue];
            if (obj != null)
            {
                lstEntrys = obj as List<BugCheckEntry>;
                if (lstEntrys != null)
                    lstEntrys.Add(qcEntry);
                return;
            }

            if (szEntryValue.Length < this.m_nEntryMinLen)
                this.m_nEntryMinLen = szEntryValue.Length;
            if (szEntryValue.Length > this.m_nEntryMaxLen)
                this.m_nEntryMaxLen = szEntryValue.Length;

            //这里做成一个Entry列表,是因为有些Entry的关键字是相相同的
            lstEntrys = new List<BugCheckEntry>();
            lstEntrys.Add(qcEntry);
            this.m_htDocumentEntry.Add(szEntryValue, lstEntrys);
        }

        /// <summary>
        /// 恢复各Entry项为默认值
        /// </summary>
        private void ResumeEntry()
        {
            if (this.EntryTable == null)
                return;
            foreach (object obj in this.EntryTable.Values)
            {
                BugCheckEntry qcEntry = obj as BugCheckEntry;
                if (qcEntry == null)
                    continue;
                if (qcEntry.Operator == SystemData.Operator.NOCONTAINS)
                    qcEntry.OccurCount = 1;
                else
                    qcEntry.OccurCount = 0;
            }
        }

        public override void ComputeEntryOccurCount()
        {
            base.ComputeEntryOccurCount();

            //恢复各Entry项为默认值
            this.ResumeEntry();

            if (this.QCEngine == null || this.QCEngine.DocText == null)
                return;

            //遍历文档,检索并设置Entry发生次数
            int nDocTotalLength = this.QCEngine.DocText.Length;
            for (int nCharIndex = 0; nCharIndex < nDocTotalLength; nCharIndex++)
            {
                int nSkipLength = 0;
                for (int nWordLen = this.m_nEntryMinLen; nWordLen <= this.m_nEntryMaxLen; nWordLen++)
                {
                    if (nCharIndex > nDocTotalLength - nWordLen)
                        break;
                    string szWord = this.QCEngine.DocText.Substring(nCharIndex, nWordLen);
                    object obj = this.m_htDocumentEntry[szWord];
                    if (obj == null)
                        continue;

                    nSkipLength = szWord.Length - 1;

                    List<BugCheckEntry> lstEntrys = obj as List<BugCheckEntry>;
                    if (lstEntrys == null)
                        continue;

                    for (int index = 0; index < lstEntrys.Count; index++)
                    {
                        BugCheckEntry qcEntry = lstEntrys[index];
                        if (qcEntry.Operator == SystemData.Operator.NOCONTAINS)
                            qcEntry.OccurCount = 0;
                        else if (qcEntry.Operator == SystemData.Operator.CONTAINS)
                            qcEntry.OccurCount++;
                    }
                }
                nCharIndex += nSkipLength;
            }
        }
    }
}
