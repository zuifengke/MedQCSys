using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// <summary>
        /// 病历浏览申请表
        /// </summary>
        public struct RecBrowseRequestTable
        {
            /// <summary>
            /// 主键
            /// </summary>
            public const string ID = "ID";
            /// <summary>
            /// 病案号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 入院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 患者姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 申请人ID
            /// </summary>
            public const string REQUEST_ID = "REQUEST_ID";
            /// <summary>
            /// 申请人姓名
            /// </summary>
            public const string REQUEST_NAME = "REQUEST_NAME";
            /// <summary>
            /// 申请时间
            /// </summary>
            public const string REQUEST_TIME = "REQUEST_TIME";
            /// <summary>
            /// 审批人ID
            /// </summary>
            public const string APPROVAL_ID = "APPROVAL_ID";
            /// <summary>
            /// 审批人姓名
            /// </summary>
            public const string APPROVAL_NAME = "APPROVAL_NAME";
            /// <summary>
            /// 审批时间
            /// </summary>
            public const string APPROVAL_TIME = "APPROVAL_TIME";
            /// <summary>
            /// 申请状态，0：未通过 1：审批通过
            /// </summary>
            public const string STATUS = "STATUS";
            /// <summary>
            /// 出院时间
            /// </summary>
            public const string DISCHARGE_TIME = "DISCHARGE_TIME";
            /// <summary>
            /// 备注
            /// </summary>
            public const string REMARK = "REMARK";

        }
    }
}
