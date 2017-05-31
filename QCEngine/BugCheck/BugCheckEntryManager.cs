// ***********************************************************
// 病历文档系统文档质控引擎,原子规则(Entry)管理器
// Creator:YangMingkun  Date:2009-8-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using EMRDBLib;
namespace MedDocSys.QCEngine.BugCheck
{
    internal class BugCheckEntryManager
    {
        private static Hashtable m_htEntryHandlerTable = null;
        public static Hashtable EntryHandlerTable
        {
            get { return m_htEntryHandlerTable; }
        }

        public static void AddEntry(BugCheckEngine qcEngine, MedQCEntry medQCEntry)
        {
            if (qcEngine == null || medQCEntry == null)
                return;
            BugCheckEntry qcEntry = new BugCheckEntry();
            qcEntry.EntryID = medQCEntry.EntryID;
            qcEntry.EntryName = medQCEntry.EntryName;
            qcEntry.EntryType = medQCEntry.EntryType;
            qcEntry.EntryDesc = medQCEntry.EntryDesc;
            qcEntry.Operator = medQCEntry.Operator;
            qcEntry.EntryValue = medQCEntry.EntryValue;
            qcEntry.ValueType = medQCEntry.ValueType;
            qcEntry.OccurCount = 0;

            string szEntryType = qcEntry.EntryType.ToUpper();
            if (szEntryType == SystemData.QCRule.ENTRY_TYPE_DOCUMENT)
            {
                if (m_htEntryHandlerTable == null)
                    m_htEntryHandlerTable = new Hashtable();
                DocumentEntryHanlder documentEntryHandler = m_htEntryHandlerTable[szEntryType] as DocumentEntryHanlder;
                if (documentEntryHandler == null)
                {
                    documentEntryHandler = new DocumentEntryHanlder(qcEngine);
                    m_htEntryHandlerTable.Add(szEntryType, documentEntryHandler);
                }
                documentEntryHandler.AddEntry(qcEntry);
            }
            else if (szEntryType == SystemData.QCRule.ENTRY_TYPE_REFLECTION)
            {
                if (m_htEntryHandlerTable == null)
                    m_htEntryHandlerTable = new Hashtable();
                ReflectionEntryHandler reflectionEntryHandler = m_htEntryHandlerTable[szEntryType] as ReflectionEntryHandler;
                if (reflectionEntryHandler == null)
                {
                    reflectionEntryHandler = new ReflectionEntryHandler(qcEngine);
                    m_htEntryHandlerTable.Add(szEntryType, reflectionEntryHandler);
                }
                reflectionEntryHandler.AddEntry(qcEntry);
            }
        }

        public static BugCheckEntry GetEntry(string szEntryID)
        {
            if (m_htEntryHandlerTable == null)
                return null;
            foreach (object obj in m_htEntryHandlerTable.Values)
            {
                BugCheckEntryHandlerBase entryHandlerBase = obj as BugCheckEntryHandlerBase;
                if (entryHandlerBase == null)
                    continue;
                BugCheckEntry qcEntry = entryHandlerBase.GetEntry(szEntryID);
                if (qcEntry != null)
                    return qcEntry;
            }
            return null;
        }

        public static void ComputeEntryOccurCount()
        {
            if (m_htEntryHandlerTable == null)
                return;
            foreach (object obj in m_htEntryHandlerTable.Values)
            {
                BugCheckEntryHandlerBase entryHandlerBase = obj as BugCheckEntryHandlerBase;
                if (entryHandlerBase == null)
                    continue;
                entryHandlerBase.ComputeEntryOccurCount();
            }
        }

        public static void Dispose()
        {
            if (m_htEntryHandlerTable == null || m_htEntryHandlerTable.Count <= 0)
                return;
            foreach (object obj in m_htEntryHandlerTable.Values)
            {
                BugCheckEntryHandlerBase entryHandlerBase = obj as BugCheckEntryHandlerBase;
                if (entryHandlerBase == null)
                    continue;
                entryHandlerBase.ClearEntry();
            }
            m_htEntryHandlerTable.Clear();
        }
    }
}
