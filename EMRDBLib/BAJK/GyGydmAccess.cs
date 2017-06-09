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

namespace EMRDBLib
{

    public class GyGydmAccess : DBAccessBase
    {
        public const string TableName = SystemData.DataTable_BAJK.gy_gydm;
        private static GyGydmAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static GyGydmAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new GyGydmAccess();
                return m_Instance;
            }
        }

        public short GetGyGydms(string mc,string dmlb, ref List<GyGydm> lstGyGydms)
        {
            if (base.BAJKDataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},",SystemData.GyGydmTable.DM);
            sbField.AppendFormat("{0},", SystemData.GyGydmTable.DMLB);
            sbField.AppendFormat("{0}", SystemData.GyGydmTable.MC);
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' "
                , szCondition
                , SystemData.GyGydmTable.DMLB
                , dmlb);
            if (!string.IsNullOrEmpty(mc))
                szCondition = string.Format("{0} AND {1} like '%{2}%' "
                    ,szCondition
                    , SystemData.GyGydmTable.MC
                    ,mc);
            string szOrderBy = string.Format("{0}", SystemData.GyGydmTable.DM);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(),TableName , szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.BAJKDataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstGyGydms == null)
                    lstGyGydms = new List<GyGydm>();
                do
                {
                    GyGydm item = new GyGydm();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.GyGydmTable.DM:
                                item.DM = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.GyGydmTable.DMLB:
                                item.DMLB = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.GyGydmTable.MC:
                                item.MC = dataReader.GetValue(i).ToString();
                                break;
                            default: break;
                        }

                    }
                    lstGyGydms.Add(item);
                } while (dataReader.Read());

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.BAJKDataAccess.CloseConnnection(false); }
        }
    }
}
