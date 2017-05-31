// ***********************************************************
// 病历质控结果数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{

    public class TempletTypeAccess : DBAccessBase
    {
        private static TempletTypeAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static TempletTypeAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new TempletTypeAccess();
                return TempletTypeAccess.m_Instance;
            }
        }
        
        public short GetTempletTypes(string szApplyEnv, ref List<TempletType> lstTempletTypes)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.APPLY_ENV);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.IS_FOLDER);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.IS_VALID);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.MODIFY_TIME);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.PARENT_ID);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.TEMPLET_TYPE_ID);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.TEMPLET_TYPE_NAME);

            sbField.AppendFormat("{0}", SystemData.TempletTypeTable.TEMPLET_TYPE_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szApplyEnv))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.TempletTypeTable.APPLY_ENV
                    , szApplyEnv);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.TEMPLET_TYPE, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstTempletTypes == null)
                    lstTempletTypes = new List<TempletType>();
                do
                {
                    TempletType TempletType = new TempletType();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.TempletTypeTable.APPLY_ENV:
                                TempletType.ApplyEnv = dataReader.GetString(i).ToString();
                                break;
                            case SystemData.TempletTypeTable.IS_FOLDER:
                                TempletType.IsFolder = dataReader.GetValue(i).ToString() == "1";
                                break;
                            case SystemData.TempletTypeTable.IS_VALID:
                                TempletType.IsValid = dataReader.GetValue(i).ToString() == "1";
                                break;
                            case SystemData.TempletTypeTable.MODIFY_TIME:
                                TempletType.ModifyTime = dataReader.GetDateTime(i);
                                break;
                            case SystemData.TempletTypeTable.PARENT_ID:
                                TempletType.ParentID = dataReader.GetValue(i).ToString();
                                break;
                            case SystemData.TempletTypeTable.TEMPLET_TYPE_ID:
                                TempletType.DocTypeID = dataReader.GetString(i);
                                break;
                            case SystemData.TempletTypeTable.TEMPLET_TYPE_NAME:
                                TempletType.DocTypeName = dataReader.GetString(i);
                                break;
                            case SystemData.TempletTypeTable.TEMPLET_TYPE_NO:
                                TempletType.DocTypeNo = int.Parse(dataReader.GetValue(i).ToString());
                                break;
                            default: break;
                        }
                    }
                    lstTempletTypes.Add(TempletType);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
    }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
        
        public short GetTempletType(string szTempletTypeID, ref TempletType TempletType)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            if (string.IsNullOrEmpty(szTempletTypeID))
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.APPLY_ENV);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.IS_FOLDER);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.IS_VALID);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.MODIFY_TIME);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.PARENT_ID);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.TEMPLET_TYPE_ID);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.TEMPLET_TYPE_NAME);
            sbField.AppendFormat("{0}", SystemData.TempletTypeTable.TEMPLET_TYPE_NO);
            string szCondition = string.Format("1=1");
            if (!string.IsNullOrEmpty(szTempletTypeID))
            {
                szCondition = string.Format("{0} AND {1} = '{2}'"
                    , szCondition
                    , SystemData.TempletTypeTable.TEMPLET_TYPE_ID
                    , szTempletTypeID);
            }
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataTable.TEMPLET_TYPE, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (TempletType == null)
                    TempletType = new TempletType();
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.TempletTypeTable.APPLY_ENV:
                            TempletType.ApplyEnv = dataReader.GetString(i).ToString();
                            break;
                        case SystemData.TempletTypeTable.IS_FOLDER:
                            TempletType.IsFolder = dataReader.GetValue(i).ToString() == "1";
                            break;
                        case SystemData.TempletTypeTable.IS_VALID:
                            TempletType.IsValid = dataReader.GetValue(i).ToString() == "1";
                            break;
                        case SystemData.TempletTypeTable.MODIFY_TIME:
                            TempletType.ModifyTime = dataReader.GetDateTime(i);
                            break;
                        case SystemData.TempletTypeTable.PARENT_ID:
                            TempletType.ParentID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.TempletTypeTable.TEMPLET_TYPE_ID:
                            TempletType.DocTypeID = dataReader.GetString(i);
                            break;
                        case SystemData.TempletTypeTable.TEMPLET_TYPE_NAME:
                            TempletType.DocTypeName = dataReader.GetString(i);
                            break;
                        case SystemData.TempletTypeTable.TEMPLET_TYPE_NO:
                            TempletType.DocTypeNo = int.Parse(dataReader.GetValue(i).ToString());
                            break;
                        default: break;
                    }
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL
}, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
        public short GetTempletData(string szTempletID, ref byte[] byteTempletData)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szCondition = string.Format("{0}='{1}'", SystemData.TempletTypeTable.TEMPLET_TYPE_ID, szTempletID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, SystemData.TempletTypeTable.TEMPLET_DATA, SystemData.DataTable.TEMPLET_TYPE, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    LogManager.Instance.WriteLog("TempletAccess.GetTempletTempletFromDB", new string[] { "szSQL" }, new object[] { szSQL }, "没有查询到记录!");
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                return GlobalMethods.IO.GetBytes(dataReader, 0, ref byteTempletData)
                    ? SystemData.ReturnValue.OK : SystemData.ReturnValue.EXCEPTION;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }


        /// <summary>
        /// 保存系统缺省模板到数据库服务器
        /// </summary>
        /// <param name="szDocTypeID">报表类型ID</param>
        /// <param name="byteTempletData">系统缺省模板</param>
        /// <returns>ServerData.ExecuteResult</returns>
        public short SaveTempletDataToDB(string szDocTypeID, byte[] byteTempletData)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0}={1}", SystemData.TempletTypeTable.MODIFY_TIME, base.QCAccess.GetSystemTimeSql());

            DbParameter[] pmi = null;
            if (byteTempletData != null)
            {
                szField = string.Format("{0},{1}={2}", szField, SystemData.TempletTypeTable.TEMPLET_DATA, base.QCAccess.GetSqlParamName("Templet_DATA"));

                pmi = new DbParameter[1];
                pmi[0] = new DbParameter("Templet_DATA", byteTempletData);
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.TempletTypeTable.TEMPLET_TYPE_ID, szDocTypeID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.TEMPLET_TYPE, szField, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text, ref pmi);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            if (nCount <= 0)
            {
                LogManager.Instance.WriteLog("TempletAccess.SaveSystemTempletToDB", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行后返回0!");
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }
        public short Insert(TempletType TempletType)
        {
            if (TempletType == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { TempletType }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (TempletType.DocTypeID == string.Empty)
            {
                return SystemData.ReturnValue.EXCEPTION;
            }
            StringBuilder sbField = new StringBuilder();
            StringBuilder sbValue = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.APPLY_ENV);
            sbValue.AppendFormat("'{0}',", TempletType.ApplyEnv);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.IS_FOLDER);
            sbValue.AppendFormat("{0},", TempletType.IsFolder ? 1 : 0);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.IS_VALID);
            sbValue.AppendFormat("{0},", TempletType.IsValid ? 1 : 0);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.MODIFY_TIME);
            sbValue.AppendFormat("{0},", base.QCAccess.GetSqlTimeFormat(TempletType.ModifyTime));
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.PARENT_ID);
            sbValue.AppendFormat("'{0}',", TempletType.ParentID);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.TEMPLET_TYPE_ID);
            sbValue.AppendFormat("'{0}',", TempletType.DocTypeID);
            sbField.AppendFormat("{0},", SystemData.TempletTypeTable.TEMPLET_TYPE_NAME);
            sbValue.AppendFormat("'{0}',", TempletType.DocTypeName);
            sbField.AppendFormat("{0}", SystemData.TempletTypeTable.TEMPLET_TYPE_NO);
            sbValue.AppendFormat("{0}", TempletType.DocTypeNo);
            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.TEMPLET_TYPE, sbField.ToString(), sbValue.ToString());
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
        /// 更新一条整改通知单
        /// </summary>
        /// <param name="timeQCRule">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Update(TempletType TempletType)
        {
            if (TempletType == null)
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { TempletType }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.TempletTypeTable.APPLY_ENV, TempletType.ApplyEnv);
            sbField.AppendFormat("{0}={1},"
                , SystemData.TempletTypeTable.IS_FOLDER, TempletType.IsFolder ? 1 : 0);
            sbField.AppendFormat("{0}={1},"
                , SystemData.TempletTypeTable.IS_VALID, TempletType.IsValid ? 1 : 0);
            sbField.AppendFormat("{0}={1},"
                , SystemData.TempletTypeTable.MODIFY_TIME, base.QCAccess.GetSqlTimeFormat(TempletType.ModifyTime));
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.TempletTypeTable.PARENT_ID, TempletType.ParentID);
            sbField.AppendFormat("{0}='{1}',"
                , SystemData.TempletTypeTable.TEMPLET_TYPE_NAME, TempletType.DocTypeName);
            sbField.AppendFormat("{0}={1}"
                , SystemData.TempletTypeTable.TEMPLET_TYPE_NO, TempletType.DocTypeNo);
            string szCondition = string.Format("{0}='{1}'", SystemData.TempletTypeTable.TEMPLET_TYPE_ID, TempletType.DocTypeID);
            string szSQL = string.Format(SystemData.SQL.UPDATE, SystemData.DataTable.TEMPLET_TYPE, sbField.ToString(), szCondition);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
        /// 删除一条整改通知单
        /// </summary>
        /// <param name="szRuleID">自动核查结果ID</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Delete(string szTempletTypeID)
        {
            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szTempletTypeID))
            {
                LogManager.Instance.WriteLog("", new string[] { "" }
                    , new object[] { szTempletTypeID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.TempletTypeTable.TEMPLET_TYPE_ID, szTempletTypeID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.TEMPLET_TYPE, szCondition);
            int nCount = 0;
            try
            {
                nCount = base.QCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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

        public short DeleteAll(List<string> lstTempletTypeID)
        {
            try
            {
                if (base.QCAccess == null)
                    return SystemData.ReturnValue.PARAM_ERROR;

                //开始数据库事务
                if (!base.QCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                    return SystemData.ReturnValue.EXCEPTION;
                foreach (var item in lstTempletTypeID)
                {
                    //删除原有关联信息
                    short shRet = this.Delete(item);
                    if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
                    {
                        base.QCAccess.AbortTransaction();
                        return shRet;
                    }
                }
                //提交数据库更新
                if (!base.QCAccess.CommitTransaction(true))
                    return SystemData.ReturnValue.EXCEPTION;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", ex);
            }
            finally
            {
                base.QCAccess.CloseConnnection(false);
            }
            return SystemData.ReturnValue.OK;
        }
    }
}