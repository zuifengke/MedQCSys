// ***********************************************************
// 数据库访问层通用操作有关的数据访问接口.
// Creator:YangMingkun  Date:2010-11-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using EMRDBLib.DbAccess;
using EMRDBLib.BAJK;
using System.Reflection;
using EMRDBLib.HerenHis;

namespace EMRDBLib
{

    public class PatMasterIndexAccess : DBAccessBase
    {
        public const string TableName = SystemData.DataTable_HerenHis.PAT_MASTER_INDEX;
        private static PatMasterIndexAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static PatMasterIndexAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new PatMasterIndexAccess();
                return m_Instance;
            }
        }

        public short GetModel(string patientID, ref PatMasterIndex model)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}'  "
                , szCondition
                , SystemData.PatMasterIndexTable.PATIENT_ID
                , patientID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), TableName, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.HerenHisAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (model == null)
                    model = new PatMasterIndex();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    PropertyInfo property = Reflect.GetPropertyInfo(typeof(PatMasterIndex), dataReader.GetName(i));
                    bool result = Reflect.SetPropertyValue(model, property, dataReader.GetValue(i));
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.HerenHisAccess.CloseConnnection(false); }
        }
        
    }
}
