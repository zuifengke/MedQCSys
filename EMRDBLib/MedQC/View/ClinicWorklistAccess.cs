using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 临床任务列表操作
    /// </summary>
    public class ClinicWorklistAccess : DBAccessBase
    {
        private static ClinicWorklistAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static ClinicWorklistAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new ClinicWorklistAccess();
                return ClinicWorklistAccess.m_Instance;
            }
        }

        public short UpdateClinicWorklist(ClinicWorklist model, string operFlag)
        {
            string szDoctorID = string.Empty;
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            DbParameter[] pmi = new DbParameter[15];
            pmi[0] = new DbParameter("operFlag", operFlag);
            pmi[1] = new DbParameter("rcount", 0, ParameterDirection.Output);
            pmi[2] = new DbParameter("WORKLIST_ID_1", model.WORKLIST_ID);
            pmi[3] = new DbParameter("WORKLIST_TYPE_1", model.WORKLIST_TYPE);
            pmi[4] = new DbParameter("CREATE_TIME_1", model.CREATE_TIME);
            pmi[5] = new DbParameter("CREATE_DEPT_1", model.CREATE_DEPT);
            pmi[6] = new DbParameter("CREATE_STAFF_1", model.CREATE_STAFF);
            pmi[7] = new DbParameter("WORKLIST_CONTENT_1", model.WORKLIST_CONTENT);
            pmi[8] = new DbParameter("TARGET_DEPT_1", model.TARGET_DEPT);
            pmi[9] = new DbParameter("TARGET_STAFF_1", model.TARGET_STAFF);
            pmi[10] = new DbParameter("EXEC_DEPT_1", model.EXEC_DEPT);
            pmi[11] = new DbParameter("EXEC_STAFF_1", model.EXEC_STAFF);
            pmi[12] = new DbParameter("EXEC_TIME_1",model.EXEC_TIME);
            pmi[13] = new DbParameter("EXEC_INDICATOR_1", model.EXEC_INDICATOR);
            pmi[14] = new DbParameter("PARAMETER_1", model.PARAMETER);
            int nResult = 0;
            int rcount = 0;
            try
            {
                nResult = base.MedQCAccess.ExecuteNonQuery("UPDATE_CLINIC_WORKLIST", CommandType.StoredProcedure, ref pmi);
                rcount = int.Parse(pmi[1].Value.ToString());
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
            return rcount <= 0 ? SystemData.ReturnValue.OTHER_ERROR : SystemData.ReturnValue.OK;
        }
    }
}
