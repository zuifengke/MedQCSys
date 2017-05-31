using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病历审核申请表视图结构
        /// </summary>
        public struct DocRecordModifyApplyView
        {
            /// <summary>
            /// 病人ID
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 住院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 入院时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            public const string DOC_ID = "DOC_ID";
            public const string DOC_TITLE = "DOC_TITLE";
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 修改理由
            /// </summary>
            public const string MODIFY_REASON = "MODIFY_REASON";
            /// <summary>
            /// 修改/更换前内容
            /// </summary>
            public const string BEFORE_CONTENT = "BEFORE_CONTENT";
            /// <summary>
            /// 修改/更换后内容
            /// </summary>
            public const string AFTER_CONTENT = "AFTER_CONTENT";
            /// <summary>
            /// 申请者ID
            /// </summary>
            public const string APPLICANT_ID = "APPLICANT_ID";
            /// <summary>
            /// 申请时间
            /// </summary>
            public const string APPLY_DATE = "APPLY_DATE";
            /// <summary>
            /// 科主任/护士长签字
            /// </summary>
            public const string HEADER_ID = "HEADER_ID";
            /// <summary>
            /// 科主任/护士长签字时间
            /// </summary>
            public const string HEADER_TIME = "HEADER_TIME";
            /// <summary>
            /// 科主任备注
            /// </summary>
            public const string HEADER_REMARK = "HEADER_REMARK";
            /// <summary>
            /// 审核状态【保存、已申请、撤销、退回、主任审核、质控科审核、完成】
            ///                            --BC、YSQ、CX、TH、ZSH、QCSH、WC
            /// </summary>
            public const string AUDIT_STATUS = "AUDIT_STATUS";
            /// <summary>
            /// 申请科室 
            /// </summary>
            public const string APPLY_DEPT_CODE = "APPLY_DEPT_CODE";
            /// <summary>
            /// 质控科签字ID
            /// </summary>
            public const string QC_ID = "QC_ID";
            /// <summary>
            /// 质控科时间
            /// </summary>
            public const string QC_TIME = "QC_TIME";
            /// <summary>
            /// 质控科备注
            /// </summary>
            public const string QC_REMARK = "QC_REMARK";
        }
    }
}
