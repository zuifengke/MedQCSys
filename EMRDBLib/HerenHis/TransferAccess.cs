// ***********************************************************
// ���ݿ���ʲ�ͨ�ò����йص����ݷ��ʽӿ�.
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

namespace EMRDBLib.HerenHis
{

    public class TransferAccess : DBAccessBase
    {
        public const string TableName = SystemData.DataTable_HerenHis.TRANSFER;
        private static TransferAccess m_Instance = null;

        /// <summary>
        /// ��ȡϵͳ����������ʵ��
        /// </summary>
        public static TransferAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new TransferAccess();
                return m_Instance;
            }
        }

        public short GetList(string patientID, string szVisitNO, ref List<Transfer> lstTransfer)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' and {3}='{4}' "
                , szCondition
                , SystemData.TransferTable.PATIENT_ID
                , patientID
                , SystemData.TransferTable.VISIT_NO
                , szVisitNO);
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
                if (lstTransfer == null)
                    lstTransfer = new List<Transfer>();
                lstTransfer.Clear();
                do
                {
                    Transfer model = new Transfer();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        PropertyInfo property = Reflect.GetPropertyInfo(typeof(Transfer), dataReader.GetName(i));
                        bool result = Reflect.SetPropertyValue(model, property, dataReader.GetValue(i));
                    }
                    lstTransfer.Add(model);
                } while (dataReader.Read());
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