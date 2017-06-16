// ***********************************************************
// 数据库访问层与质检问题类型数据相关的访问类.
// Creator:yehui  Date:2016-5-27
// Copyright:heren
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;

namespace EMRDBLib.DbAccess
{
    public class QcAdminDeptsAccess : DBAccessBase
    {
        private static QcAdminDeptsAccess m_Instance = null;
        public static QcAdminDeptsAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new QcAdminDeptsAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 病历质控系统,获取质控管辖科室
        /// </summary>
        /// <param name="lstQCMessageTemplets">质控反馈信息字典列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetQcAdminDeptsList(ref List<QcAdminDepts> lstQcAdminDepts)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3}"
               , SystemData.QcAdminDeptsTable.USER_ID
               , SystemData.QcAdminDeptsTable.USER_NAME
               , SystemData.QcAdminDeptsTable.DEPT_CODE
               , SystemData.QcAdminDeptsTable.DEPT_NAME
               );
            string szCondtion = string.Format("1=1");
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataTable.QC_ADMIN_DEPTS, szCondtion);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcAdminDepts == null)
                    lstQcAdminDepts = new List<QcAdminDepts>();
                do
                {
                    QcAdminDepts qcAdminDepts = new QcAdminDepts();
                    if (!dataReader.IsDBNull(0)) qcAdminDepts.USER_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) qcAdminDepts.USER_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcAdminDepts.DEPT_CODE = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcAdminDepts.DEPT_NAME = dataReader.GetString(3);
                    lstQcAdminDepts.Add(qcAdminDepts);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("MedQCAccess.GetQCMessageTempletList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }
      
        public short GetQcAdminDeptsList(string szUserID, ref List<EMRDBLib.QcAdminDepts> lstQcAdminDepts)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("{0},{1},{2},{3}"
               , SystemData.QcAdminDeptsTable.DEPT_CODE, SystemData.QcAdminDeptsTable.DEPT_NAME, SystemData.QcAdminDeptsTable.USER_ID,SystemData.QcAdminDeptsTable.USER_NAME);
            string szCondition = string.Format(" 1=1 AND {0}='{1}'",SystemData.QcAdminDeptsTable.USER_ID,szUserID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                , SystemData.DataTable.QC_ADMIN_DEPTS, szCondition, SystemData.QcAdminDeptsTable.DEPT_NAME);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstQcAdminDepts == null)
                    lstQcAdminDepts = new List<QcAdminDepts>();
                do
                {
                    QcAdminDepts qcAdminDepts = new QcAdminDepts();
                    if (!dataReader.IsDBNull(0)) qcAdminDepts.DEPT_CODE = dataReader.GetValue(0).ToString();
                    if (!dataReader.IsDBNull(1)) qcAdminDepts.DEPT_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) qcAdminDepts.USER_ID = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) qcAdminDepts.USER_NAME = dataReader.GetString(3);
                    lstQcAdminDepts.Add(qcAdminDepts);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                    dataReader.Dispose();
                    dataReader = null;
                }
                base.MedQCAccess.CloseConnnection(false);
            }
        }
        /// <summary>
        /// 新增一条自动核查规则配置信息
        /// </summary>
        /// <param name="qcAdminDepts">自动核查规则配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short Insert(QcAdminDepts qcAdminDepts)
        {
            if (qcAdminDepts == null)
            {
                LogManager.Instance.WriteLog("QcCheckPointAccess.Insert", new string[] { "timeQCRule" }
                    , new object[] { qcAdminDepts }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szField = string.Format("{0},{1},{2},{3}"
                , SystemData.QcAdminDeptsTable.DEPT_CODE
                , SystemData.QcAdminDeptsTable.DEPT_NAME
                , SystemData.QcAdminDeptsTable.USER_ID
                , SystemData.QcAdminDeptsTable.USER_NAME);

            string szValue = string.Format("'{0}','{1}','{2}','{3}'"
                , qcAdminDepts.DEPT_CODE
                , qcAdminDepts.DEPT_NAME
                , qcAdminDepts.USER_ID 
                , qcAdminDepts.USER_NAME);

            string szSQL = string.Format(SystemData.SQL.INSERT, SystemData.DataTable.QC_ADMIN_DEPTS, szField, szValue);
            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
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
        
        public short SaveQcAdminDeptsList(string szUserID, List<QcAdminDepts> lstQcAdminDepts)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            //开始数据库事务
            if (!base.MedQCAccess.BeginTransaction(IsolationLevel.ReadCommitted))
                return SystemData.ReturnValue.EXCEPTION;

            //删除原有关联信息
            short shRet = this.Delete(szUserID);
            if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
            {
                base.MedQCAccess.AbortTransaction();
                return shRet;
            }

            //保存用户角色关联信息
            foreach (QcAdminDepts item in lstQcAdminDepts)
            {
                shRet = this.Insert(item);
                if (shRet != SystemData.ReturnValue.OK)
                {
                    base.MedQCAccess.AbortTransaction();
                    return shRet;
                }
            }
            //提交数据库更新
            if (!base.MedQCAccess.CommitTransaction(true))
                return SystemData.ReturnValue.EXCEPTION;
            return SystemData.ReturnValue.OK;
        }

        public short Delete(string szUserID)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (GlobalMethods.Misc.IsEmptyString(szUserID))
            {
                LogManager.Instance.WriteLog("", new string[] { "szRuleID" }
                    , new object[] { szUserID }, "参数不能为空");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            string szCondition = string.Format("{0}='{1}'", SystemData.QcAdminDeptsTable.USER_ID, szUserID);
            string szSQL = string.Format(SystemData.SQL.DELETE, SystemData.DataTable.QC_ADMIN_DEPTS, szCondition);

            int nCount = 0;
            try
            {
                nCount = base.MedQCAccess.ExecuteNonQuery(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            
            return SystemData.ReturnValue.OK;
        }
    }
}
