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
    public class EMRDBAccess : DBAccessBase
    {
        private static EMRDBAccess m_Instance = null;
        public static EMRDBAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new EMRDBAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 获取数据库服务器时间
        /// </summary>
        /// <param name="dtSysDate">数据库服务器时间</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetServerTime(ref DateTime dtSysDate)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szSQL = null;
            if (base.DataAccess.DatabaseType == DatabaseType.SQLSERVER)
            {
                szSQL = string.Format(SystemData.SQL.SELECT, "CONVERT(VARCHAR(20), GETDATE(), 20)");
            }
            else if (base.DataAccess.DatabaseType == DatabaseType.ORACLE)
            {
                szSQL = string.Format(SystemData.SQL.SELECT_FROM, "SYSDATE", "DUAL");
            }
            else
            {
                dtSysDate = DateTime.Now;
                return SystemData.ReturnValue.OK;
            }
            object oRet = null;
            try
            {
                oRet = base.DataAccess.ExecuteScalar(szSQL, CommandType.Text);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("CommonAccess.GetServerTime", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            try
            {
                dtSysDate = DateTime.Parse(oRet.ToString());
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("CommonAccess.GetServerTime", new string[] { "szSQL" }, new object[] { szSQL }
                    , string.Format("无法将“{0}”转换为DateTime!", oRet), ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            return SystemData.ReturnValue.OK;
        }

        public short GetDocAdminDeptsList(string szUserID, ref List<DeptInfo> lstDeptInfos)
        {
            if (string.IsNullOrEmpty(szUserID))
                return SystemData.ReturnValue.PARAM_ERROR;
            string szField = string.Format("{0},{1}"
                          , SystemData.DeptView.DEPT_CODE, SystemData.DeptView.DEPT_NAME
                          );

            string szCondition = string.Format(" USER_ID='{0}'", szUserID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataView.DOC_ADMIN_DEPTS_V, szCondition
              );
            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstDeptInfos == null)
                    lstDeptInfos = new List< DeptInfo>();
                do
                {
                     DeptInfo deptInfo = new  DeptInfo();
                    if (!dataReader.IsDBNull(0)) deptInfo.DEPT_CODE = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) deptInfo.DEPT_NAME = dataReader.GetString(1);
                    lstDeptInfos.Add(deptInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetDocAdminDeptsList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
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
                base.DataAccess.CloseConnnection(false);
            }
        }
        #region"检查数据访问接口"
        

       
        #endregion



        /// 获取临床属性的科室列表
        /// </summary>
        /// <param name="lstDeptInfo">返回的科室列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetClinicDeptList(ref List<DeptInfo> lstDeptInfo)
        {
            return this.GetDeptList(SystemData.DeptView.IS_CLINIC, ref lstDeptInfo);
        }

        /// <summary>
        /// 根据科室编号获取用户信息列表
        /// </summary>
        /// <param name="szDeptCode">科室编号</param>
        /// <param name="lstUserInfos">用户信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDeptUserList(string szDeptCode, ref List<UserInfo> lstUserInfos)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            //先获取用户信息
            string szField = string.Format("{0},{1},{2},{3},{4}"
                , SystemData.UserView.USER_ID, SystemData.UserView.USER_NAME
                , SystemData.UserView.DEPT_CODE, SystemData.UserView.DEPT_NAME, SystemData.UserView.USER_PWD);
            string szTable = SystemData.DataView.USER_V;
            string szCondition = string.Format("{0}='{1}'", SystemData.UserView.DEPT_CODE, szDeptCode);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstUserInfos == null)
                    lstUserInfos = new List<UserInfo>();
                do
                {
                    UserInfo userInfo = new UserInfo();
                    if (!dataReader.IsDBNull(0)) userInfo.ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) userInfo.Name = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) userInfo.DeptCode = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) userInfo.DeptName = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) userInfo.Password = dataReader.GetString(4);
                    lstUserInfos.Add(userInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetDeptUserList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 获取全院所有科室信息
        /// </summary>
        /// <param name="lstDeptInfos">科室信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetAllDeptInfos(ref List<DeptInfo> lstDeptInfos)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6}"
                , SystemData.DeptView.DEPT_CODE, SystemData.DeptView.DEPT_NAME
                , SystemData.DeptView.IS_CLINIC, SystemData.DeptView.IS_WARD
                , SystemData.DeptView.IS_OUTP, SystemData.DeptView.IS_NURSE
                , SystemData.DeptView.INPUT_CODE);
            string szTable = SystemData.DataView.DEPT_V;
            string szOrder = SystemData.DeptView.DEPT_NAME;
            string szSQL = string.Format(SystemData.SQL.SELECT_ORDER_ASC, szField, szTable, szOrder);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }

                if (lstDeptInfos == null)
                    lstDeptInfos = new List<DeptInfo>();
                do
                {
                    DeptInfo deptInfo = new DeptInfo();
                    if (!dataReader.IsDBNull(0)) deptInfo.DEPT_CODE = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) deptInfo.DEPT_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) deptInfo.IsClinicDept = (dataReader.GetValue(2).ToString() == "1");
                    if (!dataReader.IsDBNull(3)) deptInfo.IsWardDept = (dataReader.GetValue(3).ToString() == "1");
                    if (!dataReader.IsDBNull(4)) deptInfo.IsOutpDept = (dataReader.GetValue(4).ToString() == "1");
                    if (!dataReader.IsDBNull(5)) deptInfo.IsNurseDept = (dataReader.GetValue(5).ToString() == "1");
                    if (!dataReader.IsDBNull(6)) deptInfo.InputCode = dataReader.GetString(6);
                    lstDeptInfos.Add(deptInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetAllDeptInfos", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 获取病房属性的科室列表
        /// </summary>
        /// <param name="lstDeptInfo">返回的科室列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetWardDeptList(ref List<DeptInfo> lstDeptInfo)
        {
            return this.GetDeptList(SystemData.DeptView.IS_WARD, ref lstDeptInfo);
        }
        /// <summary>
        /// 获取指定属性字段名的科室列表
        /// </summary>
        /// <param name="szAttrField">科室属性字段名</param>
        /// <param name="lstDeptInfo">返回的科室列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short GetDeptList(string szAttrField, ref List<DeptInfo> lstDeptInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szAttrField))
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetDeptList", "科室属性字段名不能为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6}"
                , SystemData.DeptView.DEPT_CODE, SystemData.DeptView.DEPT_NAME
                , SystemData.DeptView.IS_CLINIC, SystemData.DeptView.IS_WARD
                , SystemData.DeptView.IS_OUTP, SystemData.DeptView.IS_NURSE
                , SystemData.DeptView.INPUT_CODE);
            string szCondition = string.Format("{0}=1", szAttrField);
            string szTable = SystemData.DataView.DEPT_V;
            string szOrder = SystemData.DeptView.DEPT_NAME;
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrder);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }

                if (lstDeptInfo == null)
                    lstDeptInfo = new List<DeptInfo>();
                do
                {
                    DeptInfo deptInfo = new DeptInfo();
                    if (!dataReader.IsDBNull(0)) deptInfo.DEPT_CODE = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) deptInfo.DEPT_NAME = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) deptInfo.IsClinicDept = (dataReader.GetValue(2).ToString() == "1");
                    if (!dataReader.IsDBNull(3)) deptInfo.IsWardDept = (dataReader.GetValue(3).ToString() == "1");
                    if (!dataReader.IsDBNull(4)) deptInfo.IsOutpDept = (dataReader.GetValue(4).ToString() == "1");
                    if (!dataReader.IsDBNull(5)) deptInfo.IsNurseDept = (dataReader.GetValue(5).ToString() == "1");
                    if (!dataReader.IsDBNull(6)) deptInfo.InputCode = dataReader.GetString(6);
                    lstDeptInfo.Add(deptInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetDeptList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 获取指定病人指定就诊下的以往病历文档列表.
        /// 需要创建DB_LINK,LINK到旧病历数据库,本接口再通过视图获取以往病历列表.
        /// 注意：该接口不对返回病历列表进行排序,需要外部主动调用Sort方法排序
        /// </summary>
        /// <param name="szPatientID">病人ID</param>
        /// <param name="szVisitID">就诊ID</param>
        /// <param name="lstPastDocInfos">Word病历文档列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetPastDocList(string szPatientID, string szVisitID, ref MedDocList lstPastDocInfos)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}"
                , SystemData.PastDocView.DOC_ID, SystemData.PastDocView.DOC_TYPE, SystemData.PastDocView.DOC_TITLE
                , SystemData.PastDocView.CREATOR_ID, SystemData.PastDocView.CREATOR_NAME, SystemData.PastDocView.CREATE_TIME
                , SystemData.PastDocView.MODIFIER_ID, SystemData.PastDocView.MODIFIER_NAME, SystemData.PastDocView.MODIFY_TIME
                , SystemData.PastDocView.PATIENT_ID, SystemData.PastDocView.PATIENT_NAME, SystemData.PastDocView.VISIT_ID
                , SystemData.PastDocView.VISIT_TIME, SystemData.PastDocView.VISIT_TYPE, SystemData.PastDocView.DEPT_CODE
                , SystemData.PastDocView.DEPT_NAME, SystemData.PastDocView.ORDER_VALUE, SystemData.PastDocView.NEED_COMBIN
                , SystemData.PastDocView.FILE_TYPE, SystemData.PastDocView.FILE_NAME, SystemData.PastDocView.FILE_PATH);
            string szCondition = string.Format("{0}='{1}' AND {2}='{3}' AND {4}!='CHENPAD' AND {4}!='BAODIAN'"
                , SystemData.PastDocView.PATIENT_ID, szPatientID, SystemData.PastDocView.VISIT_ID, szVisitID
                , SystemData.PastDocView.FILE_TYPE);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField
                , SystemData.DataView.PAST_DOC, szCondition, SystemData.PastDocView.CREATE_TIME);
            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstPastDocInfos == null)
                    lstPastDocInfos = new MedDocList();

                do
                {
                    MedDocInfo pastDocInfo = new MedDocInfo();
                    if (!dataReader.IsDBNull(0)) pastDocInfo.DOC_ID = dataReader.GetString(0);
                    if (!dataReader.IsDBNull(1)) pastDocInfo.DOC_TYPE = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2)) pastDocInfo.DOC_TITLE = dataReader.GetString(2);
                    if (!dataReader.IsDBNull(3)) pastDocInfo.CREATOR_ID = dataReader.GetString(3);
                    if (!dataReader.IsDBNull(4)) pastDocInfo.CREATOR_NAME = dataReader.GetString(4);
                    if (!dataReader.IsDBNull(5)) pastDocInfo.DOC_TIME = dataReader.GetDateTime(5);
                    if (!dataReader.IsDBNull(6)) pastDocInfo.MODIFIER_ID = dataReader.GetString(6);
                    if (!dataReader.IsDBNull(7)) pastDocInfo.MODIFIER_NAME = dataReader.GetString(7);
                    if (!dataReader.IsDBNull(8)) pastDocInfo.MODIFY_TIME = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9)) pastDocInfo.PATIENT_ID = dataReader.GetString(9);
                    if (!dataReader.IsDBNull(10)) pastDocInfo.PATIENT_NAME = dataReader.GetString(10);
                    if (!dataReader.IsDBNull(11)) pastDocInfo.VISIT_ID = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12)) pastDocInfo.VISIT_TIME = dataReader.GetDateTime(12);
                    if (!dataReader.IsDBNull(13)) pastDocInfo.VISIT_TYPE = dataReader.GetString(13);
                    if (!dataReader.IsDBNull(14)) pastDocInfo.DEPT_CODE = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15)) pastDocInfo.DEPT_NAME = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16)) pastDocInfo.ORDER_VALUE = int.Parse(dataReader.GetValue(16).ToString());
                    if (!dataReader.IsDBNull(17)) pastDocInfo.NeedCombin = dataReader.GetValue(17).ToString() == "1";
                    if (!dataReader.IsDBNull(18)) pastDocInfo.EMR_TYPE = dataReader.GetString(18);
                    if (!dataReader.IsDBNull(19)) pastDocInfo.FileName = dataReader.GetString(19);
                    if (!dataReader.IsDBNull(20)) pastDocInfo.FilePath = dataReader.GetString(20);

                    if (string.IsNullOrEmpty(pastDocInfo.DOC_ID))
                        pastDocInfo.DOC_ID = string.Concat(pastDocInfo.PATIENT_ID, "_", pastDocInfo.VISIT_ID, "_", pastDocInfo.FileName);
                    lstPastDocInfos.Add(pastDocInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("EMRDBAccess.GetPastDocList", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
            //#endif
        }

    }
}
