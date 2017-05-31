using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 科室信息
    /// </summary>
    [System.Serializable]
    public class DeptInfo : DbTypeBase
    {
        private string m_szDeptCode = string.Empty;
        private string m_szDeptName = string.Empty;
        private bool m_bIsClinicDept = true;
        private bool m_bIsWardDept = true;
        private bool m_bIsOutpDept = false;
        private bool m_bIsNurseDept = false;
        private string m_szInputCode = string.Empty;

        /// <summary>
        /// 获取或设置科室代码
        /// </summary>
        public string DEPT_CODE
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }
        /// <summary>
        /// 获取或设置科室名称
        /// </summary>
        public string DEPT_NAME
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        /// <summary>
        /// 获取或设置是否是临床科室
        /// </summary>
        public bool IsClinicDept
        {
            get { return this.m_bIsClinicDept; }
            set { this.m_bIsClinicDept = value; }
        }
        /// <summary>
        /// 获取或设置是否是住院科室
        /// </summary>
        public bool IsWardDept
        {
            get { return this.m_bIsWardDept; }
            set { this.m_bIsWardDept = value; }
        }
        /// <summary>
        /// 获取或设置是否是门诊科室
        /// </summary>
        public bool IsOutpDept
        {
            get { return this.m_bIsOutpDept; }
            set { this.m_bIsOutpDept = value; }
        }
        /// <summary>
        /// 获取或设置是否是护理单元
        /// </summary>
        public bool IsNurseDept
        {
            get { return this.m_bIsNurseDept; }
            set { this.m_bIsNurseDept = value; }
        }
        /// <summary>
        /// 获取或设置科室名称输入码
        /// </summary>
        public string InputCode
        {
            get { return this.m_szInputCode; }
            set { this.m_szInputCode = value; }
        }

        public override string ToString()
        {
            return this.m_szDeptName;
        }
    }

}
