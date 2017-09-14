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
using Heren.MedQC.Model.BAJK;

namespace EMRDBLib
{
    /// <summary>
    /// 联众病案接口费用情况
    /// </summary>
    public class BAJK15Access : DBAccessBase
    {
        public const string TableName = SystemData.DataTable_BAJK.BAJK15;
        private static BAJK15Access m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static BAJK15Access Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new BAJK15Access();
                return m_Instance;
            }
        }

        public short GetBAJK15s(decimal brxh, ref List<BAJK15> lstBAJK15s)
        {
            if (base.BAJKDataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = {2} "
                , szCondition
                , SystemData.BAJK15Table.KEY1501
                , brxh);
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
                if (lstBAJK15s == null)
                    lstBAJK15s = new List<BAJK15>();
                do
                {
                    BAJK15 BAJK15 = new BAJK15();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        PropertyInfo property = Reflect.GetPropertyInfo(typeof(BAJK15), dataReader.GetName(i));
                        bool result = Reflect.SetPropertyValue(BAJK15, property, dataReader.GetValue(i));
                    }
                    lstBAJK15s.Add(BAJK15);
                } while (dataReader.Read());
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
        

        public short GetModel(decimal brxh, ref BAJK15 model)
        {
            if (base.BAJKDataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("*");
            string szCondition = string.Format("1=1");
            szCondition = string.Format("{0} AND {1} = {2} "
                , szCondition
                , SystemData.BAJK15Table.KEY1501
                , brxh);
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
                if (model == null)
                    model = new BAJK15();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    PropertyInfo property = Reflect.GetPropertyInfo(typeof(BAJK15), dataReader.GetName(i));
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
            finally { base.BAJKDataAccess.CloseConnnection(false); }
        }
        public short Insert(BAJK15 model)
        {
            if (model == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { model }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (model.KEY1501 == 0 || model.KEY1501 == 0)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            PropertyInfo[] PropertyList = Reflect.GetProperties<BAJK15>(model);
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
                , SystemData.DataTable_BAJK.BAJK15
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

        public short Update(BAJK15 model)
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
            PropertyInfo[] PropertyList = Reflect.GetProperties<BAJK15>(model);
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
                        if (dt == model.DefaultTime || dt == model.DefaultTime2
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
            string szCondition = string.Format("{0}={1}", SystemData.BAJK15Table.KEY1501, model.KEY1501);
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
        /// <summary>
        /// 清除患者所有已上传的手术情况
        /// </summary>
        /// <param name="brxh"></param>
        /// <returns></returns>
        public short Delete(decimal brxh)
        {
            if (base.BAJKDataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(brxh))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { brxh }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}={1}", SystemData.BAJK15Table.KEY1501, brxh);
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
