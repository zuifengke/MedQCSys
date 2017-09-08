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

namespace EMRDBLib
{

    public class BAJK08Access : DBAccessBase
    {
        public const string TableName = SystemData.DataTable_BAJK.BAJK08;
        private static BAJK08Access m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static BAJK08Access Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new BAJK08Access();
                return m_Instance;
            }
        }

        public short GetBAJK08s(string patientID, string visitID, ref BAJK08 bAJK08)
        {
            if (base.BAJKDataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = '{2}' AND {3}={4} "
                , szCondition
                , SystemData.BAJK08Table.COL0801
                , patientID
                , SystemData.BAJK08Table.COL0804
                , visitID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), TableName, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.BAJKDataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (bAJK08 == null)
                    bAJK08 = new BAJK08();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    PropertyInfo property = Reflect.GetPropertyInfo(typeof(BAJK08), dataReader.GetName(i));
                    bool result = Reflect.SetPropertyValue(bAJK08, property, dataReader.GetValue(i));
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.BAJKDataAccess.CloseConnnection(false); }
        }

        public short Insert(BAJK08 model)
        {
            if (model == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { model }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (model.KEY0801 == 0)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            PropertyInfo[] PropertyList = Reflect.GetProperties<BAJK08>(model);
            foreach (var item in PropertyList)
            {
                string name = item.Name;
                object value = item.GetValue(model, null);
           
                switch (item.PropertyType.Name)
                {
                    case "Decimal":
                        sbField.AppendFormat("{0},", name);
                        sbValue.AppendFormat("{0},", value);
                        break;
                    case "DateTime":
                        DateTime dt = DateTime.Parse(value.ToString());
                        if (dt == model.DefaultTime 
                            || dt == model.DefaultTime2
                            || dt == model.DefaultTime3)
                            break;
                        sbField.AppendFormat("{0},", name);
                        sbValue.AppendFormat("{0},", base.BAJKDataAccess.GetSqlTimeFormat(dt));
                        break;
                    default:
                        sbField.AppendFormat("{0},", name);
                        sbValue.AppendFormat("'{0}',", value);
                        break;
                }
            }
            string szField = sbField.ToString().Substring(0, sbField.Length - 1);
            string szValue = sbValue.ToString().Substring(0, sbValue.Length - 1);
            string szSQL = string.Format(SystemData.SQL.INSERT
                , SystemData.DataTable_BAJK.BAJK08
                , szField
                , szValue);
            int nCount = 0;
            try
            {
                nCount = base.BAJKDataAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        public bool Exist(decimal key0801)
        {
            string sql = string.Format("select * from {0} where {1}={2}"
                , TableName
                , SystemData.BAJK08Table.KEY0801
                , key0801);
            try
            {
                DataSet ds = base.BAJKDataAccess.ExecuteDataSet(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "sql" }, new object[] { sql }, ex);
                return false;
            }
        }

        //未了解规则前，按随机数生成,去重
        public decimal MakeKey0801()
        {
            decimal key0801 = 0;
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random((int)DateTime.Now.Ticks);
                key0801 = random.Next(10000000, 19999999);
                if (!this.Exist(key0801))
                    break;
            }

            return key0801;
        }
        public decimal GetNextKey0801()
        {
            decimal key0801 = 0;
            string szSQL = "select max(key0801) from dbo.bajk08";
            IDataReader dataReader = null;
            try
            {
                dataReader = base.BAJKDataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return 0;
                }
                if (GlobalMethods.Convert.StringToDecimal(dataReader.GetValue(0).ToString(), ref key0801))
                    return key0801+1;
                return 0;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return 0;
            }
            finally { base.BAJKDataAccess.CloseConnnection(false); }
        }
        public short Update(BAJK08 model)
        {
            if (model == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { model }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.BAJKDataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            PropertyInfo[] PropertyList = Reflect.GetProperties<BAJK08>(model);
            foreach (var item in PropertyList)
            {
                string name = item.Name;
                object value = item.GetValue(model, null);

                switch (item.PropertyType.Name)
                {
                    case "Decimal":
                        sbField.AppendFormat("{0}={1},", name, value);
                        break;
                    case "int":
                        sbField.AppendFormat("{0}={1},", name, value);
                        break;
                    case "DateTime":
                        DateTime dt = DateTime.Parse(value.ToString());
                        if (dt == model.DefaultTime 
                            || dt == model.DefaultTime2
                            || dt == model.DefaultTime3)
                            break;
                        sbField.AppendFormat("{0}={1},", name, base.BAJKDataAccess.GetSqlTimeFormat(dt));
                        break;
                    default:
                        sbField.AppendFormat("{0}='{1}',", name, value);
                        break;
                }
            }
            string szField = sbField.ToString().Substring(0, sbField.Length - 1);
            string szCondition = string.Format("{0}={1}", SystemData.BAJK08Table.KEY0801, model.KEY0801);
            string szSQL = string.Format(SystemData.SQL.UPDATE, TableName, szField, szCondition);
            int nCount = 0;
            try
            {
                nCount = base.BAJKDataAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        public short Delete(string key0801)
        {
            if (base.BAJKDataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(key0801))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { key0801 }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}={1}", SystemData.BAJK08Table.KEY0801, key0801);
            string szSQL = string.Format(SystemData.SQL.DELETE, TableName, szCondition);
            int nCount = 0;
            try
            {
                nCount = base.BAJKDataAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
    }
}
