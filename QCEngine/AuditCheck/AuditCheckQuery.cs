// ***********************************************************
// 病历时效质控引擎时效检查查询类
// 主要用于外部传入给引擎用来查询病人医疗数据
// Creator:YangMingkun  Date:2012-1-3
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace MedDocSys.QCEngine.AuditCheck
{
    public class AuditCheckQuery
    {
        private string m_currentUserID = string.Empty;
        /// <summary>
        /// 获取或设置当前用户ID
        /// </summary>
        public string CurrentUserID
        {
            get { return this.m_currentUserID; }
            set { this.m_currentUserID = value; }
        }

        private string m_requestDoctorID = string.Empty;
        /// <summary>
        /// 获取或设置三级检诊经治医师
        /// </summary>
        public string RequestDoctorID
        {
            get { return this.m_requestDoctorID; }
            set { this.m_requestDoctorID = value; }
        }

        private string m_parentDoctorID = string.Empty;
        /// <summary>
        /// 获取或设置三级检诊主治医师
        /// </summary>
        public string ParentDoctorID
        {
            get { return this.m_parentDoctorID; }
            set { this.m_parentDoctorID = value; }
        }

        private string m_superDoctorID = string.Empty;
        /// <summary>
        /// 获取或设置三级检诊主任医师
        /// </summary>
        public string SuperDoctorID
        {
            get { return this.m_superDoctorID; }
            set { this.m_superDoctorID = value; }
        }

        private DateTime m_dtBeginDocTime = DateTime.Now;
        /// <summary>
        /// 获取或设置审核起始文档时间
        /// </summary>
        public DateTime BeginDocTime
        {
            get { return this.m_dtBeginDocTime; }
            set { this.m_dtBeginDocTime = value; }
        }
    }
}
