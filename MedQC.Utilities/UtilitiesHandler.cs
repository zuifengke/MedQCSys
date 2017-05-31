// **************************************************************
// 护理电子病历系统公用模块之公用模块调用管理器
// Creator:YangMingkun  Date:2012-9-5
// Copyright : Heren Health Services Co.,Ltd.
// **************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.MedQC.Utilities.Dialogs;
using EMRDBLib;

namespace Heren.MedQC.Utilities
{
    public class UtilitiesHandler
    {
        private static UtilitiesHandler m_instance = null;

        /// <summary>
        /// 获取公用模块管理器实例
        /// </summary>
        public static UtilitiesHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new UtilitiesHandler();
                return m_instance;
            }
        }

        private UtilitiesHandler()
        {
        }

        private DeptSelectDialog m_DeptSelectDialog = null;


        public DataTable ShowDeptSelectDialog(int defaultDeptType
            , bool multiSelect, DataTable defaultDeptList)
        {
            if (this.m_DeptSelectDialog == null || this.m_DeptSelectDialog.IsDisposed)
                this.m_DeptSelectDialog = new DeptSelectDialog();
            this.m_DeptSelectDialog.MultiSelect = multiSelect;
            this.m_DeptSelectDialog.DefaultDeptType = defaultDeptType;
            if (defaultDeptList != null)
            {
                List<DeptInfo> result = new List<DeptInfo>();
                foreach (DataRow row in defaultDeptList.Rows)
                {
                    DeptInfo deptInfo = new DeptInfo();
                    if (!row.IsNull("dept_code"))
                        deptInfo.DEPT_CODE = row["dept_code"].ToString();
                    if (!row.IsNull("dept_name"))
                        deptInfo.DEPT_NAME = row["dept_name"].ToString();
                    result.Add(deptInfo);
                }
                this.m_DeptSelectDialog.DeptInfos = result.ToArray();
            }
            if (this.m_DeptSelectDialog.ShowDialog() == DialogResult.OK)
            {
                DataTable table = new DataTable("depts");
                table.Columns.Add("dept_code", typeof(string));
                table.Columns.Add("dept_name", typeof(string));
                table.Columns.Add("is_clinic_dept", typeof(bool));
                table.Columns.Add("is_ward_dept", typeof(bool));
                table.Columns.Add("is_outp_dept", typeof(bool));
                table.Columns.Add("is_nurse_dept", typeof(bool));
                table.Columns.Add("is_user_group", typeof(bool));

                DeptInfo[] arrDeptList = this.m_DeptSelectDialog.DeptInfos;
                if (arrDeptList == null || arrDeptList.Length <= 0)
                    return null;
                foreach (DeptInfo deptInfo in arrDeptList)
                {
                    table.Rows.Add(deptInfo.DEPT_CODE, deptInfo.DEPT_NAME, deptInfo.IsClinicDept
                        , deptInfo.IsWardDept, deptInfo.IsOutpDept, deptInfo.IsNurseDept);
                }
                return table;
            }
            return defaultDeptList;
        }

    }
}
