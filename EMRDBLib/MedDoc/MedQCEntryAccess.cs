// ***********************************************************
// 数据库访问层与用户相关数据的访问类.
// Creator:YangAiping  Date:2014-05-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using System.Data.OleDb;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    public class MedQCEntryAccess : DBAccessBase
    {
        private static MedQCEntryAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static MedQCEntryAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new MedQCEntryAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 获取文档质控规则Entry列表
        /// </summary>
        /// <param name="lstQCEntrys">质控规则Entry列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQCEntryList(ref List<MedQCEntry> lstQCEntrys)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6}"
                , SystemData.QCEntryTable.ENTRY_ID, SystemData.QCEntryTable.ENTRY_NAME, SystemData.QCEntryTable.ENTRY_TYPE
                , SystemData.QCEntryTable.ENTRY_DESC, SystemData.QCEntryTable.OPERATOR, SystemData.QCEntryTable.ENTRY_VALUE
                , SystemData.QCEntryTable.VALUE_TYPE);
            string szSQL = string.Format(SystemData.SQL.SELECT_FROM, szField, SystemData.DataTable.QC_ENTRY);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQCEntrys == null)
                    lstQCEntrys = new List<MedQCEntry>();
                do
                {
                    MedQCEntry clsQCEntry = new MedQCEntry();
                    clsQCEntry.EntryID = dataReader.GetString(0).Trim();
                    clsQCEntry.EntryName = dataReader.GetString(1).Trim();
                    clsQCEntry.EntryType = dataReader.GetString(2).Trim();
                    clsQCEntry.EntryDesc = dataReader.GetString(3).Trim();
                    clsQCEntry.Operator = dataReader.GetString(4).Trim();
                    clsQCEntry.EntryValue = dataReader.GetString(5).Trim();
                    clsQCEntry.ValueType = dataReader.GetString(6).Trim();
                    lstQCEntrys.Add(clsQCEntry);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCEntryList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }

    }
}
