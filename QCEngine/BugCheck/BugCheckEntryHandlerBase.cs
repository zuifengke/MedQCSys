// ***********************************************************
// 病历文档系统文档质控引擎,原子规则(Entry)处理器基类
// Creator:YangMingkun  Date:2009-8-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;

namespace MedDocSys.QCEngine.BugCheck
{
    internal class BugCheckEntryHandlerBase
    {
        private BugCheckEngine m_qcEngine = null;
        protected BugCheckEngine QCEngine
        {
            get { return this.m_qcEngine; }
        }

        private Hashtable m_htEntryTable = null;
        protected Hashtable EntryTable
        {
            get { return this.m_htEntryTable; }
        }

        public BugCheckEntryHandlerBase(BugCheckEngine qcEngine)
        {
            this.m_qcEngine = qcEngine;
            this.m_htEntryTable = new Hashtable();
        }

        public virtual void AddEntry(BugCheckEntry qcEntry)
        {
            if (qcEntry == null)
                return;
            if (this.m_htEntryTable == null)
                this.m_htEntryTable = new Hashtable();
            if (this.m_htEntryTable.Contains(qcEntry.EntryID))
                return;

            this.m_htEntryTable.Add(qcEntry.EntryID, qcEntry);
        }

        public virtual void ClearEntry()
        {
            if (this.m_htEntryTable != null)
                this.m_htEntryTable.Clear();
        }

        public BugCheckEntry GetEntry(string szEntryID)
        {
            if (this.m_htEntryTable == null)
                return null;
            return this.m_htEntryTable[szEntryID] as BugCheckEntry;
        }

        public virtual void ComputeEntryOccurCount()
        {
            
        }
    }
}
