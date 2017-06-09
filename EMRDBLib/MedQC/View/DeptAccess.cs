using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 方法只支持新系统
    /// </summary>
    public class DeptAccess : DBAccessBase
    {
        private static DeptAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static DeptAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new DeptAccess();
                return DeptAccess.m_Instance;
            }
        }
        public short GetDeptInfo(string szDeptCode, ref DeptInfo deptInfo)
        {
            IDataReader dataReader = null;
            string szField = string.Format("{0},{1}"
                , SystemData.DeptView.DEPT_CODE
                , SystemData.DeptView.DEPT_NAME);
            string szCondition = string.Format("1=1 AND {0}='{1}'"
                , SystemData.DeptView.DEPT_CODE
                , szDeptCode);
            string szTable = SystemData.DataView.DEPT_V;
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, szTable, szCondition);
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (deptInfo == null)
                    deptInfo = new DeptInfo();
                if (!dataReader.IsDBNull(0)) deptInfo.DEPT_CODE = dataReader.GetString(0);
                if (!dataReader.IsDBNull(1)) deptInfo.DEPT_NAME = dataReader.GetString(1);
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "SQL" }
                        , new object[] { szSQL }, "查询失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
        /// <summary>
        /// 获取临床住院科室
        /// </summary>
        /// <param name="lstDeptInfos"></param>
        /// <returns></returns>
        public short GetClinicInpDeptList(ref List<DeptInfo> lstDeptInfos)
        {

            if (base.QCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            if (lstDeptInfos == null)
                lstDeptInfos = new List<DeptInfo>();
            else
                lstDeptInfos.Clear();

            string szField = string.Format("{0},{1}"
                , SystemData.DeptView.DEPT_CODE
                , SystemData.DeptView.DEPT_NAME);
            string szTable = SystemData.DataView.DEPT_V;
            string szCondition = string.Format("{0}={1}"
                , SystemData.DeptView.IS_CLINIC, "1");
            string szOrderBy = SystemData.DeptView.DEPT_NAME;
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, szTable, szCondition, szOrderBy);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.QCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;
                do
                {
                    DeptInfo DeptInfo = new DeptInfo();
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        if (dataReader.IsDBNull(i))
                            continue;
                        switch (dataReader.GetName(i))
                        {
                            case SystemData.DeptView.DEPT_CODE:
                                DeptInfo.DEPT_CODE = dataReader.GetString(i);
                                break;
                            case SystemData.DeptView.DEPT_NAME:
                                DeptInfo.DEPT_NAME = dataReader.GetString(i);
                                break;
                            default: break;
                        }
                    }
                    lstDeptInfos.Add(DeptInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, "查询检查列表时出现异常!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.QCAccess.CloseConnnection(false); }
        }
    }
}
