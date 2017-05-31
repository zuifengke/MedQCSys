using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 时效性质控记录表
        /// </summary>
        public struct QcTimeRecordTable
        {
            /// <summary>
            /// 病人ID号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 住院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 诊疗事件ID号
            /// </summary>
            public const string EVENT_ID = "EVENT_ID";
            /// <summary>
            /// 诊疗事件名称
            /// </summary>
            public const string EVENT_NAME = "EVENT_NAME";
            /// <summary>
            /// 诊疗事件时间
            /// </summary>
            public const string EVENT_TIME = "EVENT_TIME";
            /// <summary>
            /// 文书类型ID号
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            /// <summary>
            /// 文书类型名
            /// </summary>
            public const string DOCTYPE_NAME = "DOCTYPE_NAME";
            /// <summary>
            /// 正常书写开始时间
            /// </summary>
            public const string BEGIN_DATE = "BEGIN_DATE";
            /// <summary>
            /// 正常书写截止时间
            /// </summary>
            public const string END_DATE = "END_DATE";
            /// <summary>
            /// 扣分
            /// </summary>
            public const string POINT = "POINT";
            /// <summary>
            /// 检查者姓名
            /// </summary>
            public const string CHECKER_NAME = "CHECKER_NAME";
            /// <summary>
            /// 检查时间
            /// </summary>
            public const string CHECK_DATE = "CHECK_DATE";
            /// <summary>
            /// 文档ID号
            /// </summary>
            public const string DOC_ID = "DOC_ID";
            /// <summary>
            /// 文档标题
            /// </summary>
            public const string DOC_TITLE = "DOC_TITLE";
            /// <summary>
            /// 份数
            /// </summary>
            public const string REC_NO = "REC_NO";
            /// <summary>
            /// 病历记录时间
            /// </summary>
            public const string RECORD_TIME = "RECORD_TIME";
            /// <summary>
            /// 病历创建时间
            /// </summary>
            public const string DOC_TIME = "DOC_TIME";
            /// <summary>
            /// <summary>
            /// 时效质控结果
            /// </summary>
            public const string QC_RESULT = "QC_RESULT";
            /// <summary>
            /// 病历书写者ID
            /// </summary>
            public const string CREATE_ID = "CREATE_ID";
            /// <summary>
            /// 病历书写者姓名
            /// </summary>
            public const string CREATE_NAME = "CREATE_NAME";
            /// <summary>
            /// 质控依据说明
            /// </summary>
            public const string QC_EXPLAIN = "QC_EXPLAIN";
            /// <summary>
            /// 书写此病历的责任医生(经治)_统计
            /// </summary>
            public const string DOCTOR_IN_CHARGE = "DOCTOR_IN_CHARGE";
            /// <summary>
            /// 书写此病历的责任科室_统计
            /// </summary>
            public const string DEPT_IN_CHARGE = "DEPT_IN_CHARGE";
            /// <summary>
            /// 当前病人所在科室_综合查询
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";
            /// <summary>
            /// 出院时间
            /// </summary>
            public const string DISCHARGE_TIME = "DISCHARGE_TIME";
            /// <summary>
            /// 是否短信已通知 0：未通知 1：已通知
            /// </summary>
            public const string MESSAGE_NOTIFY = "MESSAGE_NOTIFY";
            /// <summary>
            /// 是否是单项否决  1 是 0 否
            /// </summary>
            public const string IS_VETO = "IS_VETO";

        }
    }
}
