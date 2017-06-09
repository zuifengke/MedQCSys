/*************************************************
* 和仁HIS库公用数据访问类
* 作者：yehui
* 时间：2017-06-05
*************************************************/

using EMRDBLib.Entity;
using EMRDBLib.HerenHis;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess.HerenHis
{

    public class BaseCodeDictAccess : DBAccessBase
    {
        private static BaseCodeDictAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static BaseCodeDictAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new BaseCodeDictAccess();
                return BaseCodeDictAccess.m_Instance;
            }
        }
        public short GetBaseCodeDicts(string codeName,string szCodeTypeName, ref List<BaseCodeDict> lstBaseCodeDicts)
        {
            if (base.HerenHisAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' "
                , szCondition
                , SystemData.BaseCodeDictTable.CODETYPE_NAME
                , szCodeTypeName);
            if(!string.IsNullOrEmpty(codeName))
                szCondition = string.Format("{0} AND {1} like '%{2}%' "
                , szCondition
                , SystemData.BaseCodeDictTable.CODE_NAME
                , codeName);
            string szOrderBy = string.Format("{0}", SystemData.BaseCodeDictTable.CODE_ID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC
                    , sbField.ToString(), SystemData.DataTable_HerenHis.BASE_CODE_DICT, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.HerenHisAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstBaseCodeDicts == null)
                    lstBaseCodeDicts = new List<BaseCodeDict>();
                do
                {
                    BaseCodeDict item = new BaseCodeDict();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.BaseCodeDictTable.CODETYPE_ID:
                                item.CODETYPE_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.BaseCodeDictTable.CODE_ID:
                                item.CODE_ID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.BaseCodeDictTable.CODE_NAME:
                                item.CODE_NAME = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.BaseCodeDictTable.INPUT_CODE:
                                item.INPUT_CODE = dataReader.GetValue(i).ToString();
                                break;

                            default: break;
                        }

                    }
                    lstBaseCodeDicts.Add(item);
                } while (dataReader.Read());

                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.HerenHisAccess.CloseConnnection(false); }
        }

    }
}