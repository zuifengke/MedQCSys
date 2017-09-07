using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病案质量监控日志表相关字段定义
        /// </summary>
        public struct MedicalQCLogTable
        {
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 病人所在科室
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";
            /// <summary>
            /// 审查日期
            /// </summary>
            public const string CHECK_DATE = "CHECK_DATE";
            /// <summary>
            /// 审查者
            /// </summary>
            public const string CHECKED_BY = "CHECKED_BY";
            /// <summary>
            /// 审查者ID
            /// </summary>
            public const string CHECKED_ID = "CHECKED_ID";
            /// <summary>
            /// 病历文档集ID
            /// </summary>
            public const string DOC_SETID = "DOC_SETID";
            /// <summary>
            /// 文档ID
            /// </summary>
            public const string DOC_ID = "DOC_ID";
            /// <summary>
            /// 病历操作者所在科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 病历操作者所在科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 病历操作类型(0-正在读；1-正在写；2-写完成；3-删除完成；4-归档完成)
            /// </summary>
            public const string CHECK_TYPE = "CHECK_TYPE";
            /// <summary>
            /// 日志类型(0-医生读写日志；1-质控读写日志；2-院级读写日志；)
            /// </summary>
            public const string LOG_TYPE = "LOG_TYPE";
            /// <summary>
            /// 日志描述信息
            /// </summary>
            public const string LOG_DESC = "LOG_DESC";
            /// <summary>
            /// 质检问题代码
            /// </summary>
            public const string QC_MSG_CODE = "QC_MSG_CODE";
        }
    }
}
