using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// <summary>
        /// 自动核查缺陷点结果表
        /// </summary>
        public struct QcCheckResultTable
        {
            public const string QA_EVENT_TYPE = "QA_EVENT_TYPE";
            public const string ERROR_COUNT = "ERROR_COUNT";
            public const string MSG_DICT_MESSAGE = "MSG_DICT_MESSAGE";
            public const string MSG_DICT_CODE = "MSG_DICT_CODE";
            public const string ORDER_VALUE = "ORDER_VALUE";
            public const string CHECK_RESULT_ID = "CHECK_RESULT_ID";
            public const string CHECK_POINT_ID = "CHECK_POINT_ID";
            public const string PATIENT_ID = "PATIENT_ID";
            public const string VISIT_ID = "VISIT_ID";
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            public const string SOCRE = "SCORE";
            public const string CHECKER_NAME = "CHECKER_NAME";
            public const string CHECKER_ID = "CHECKER_ID";
            public const string CHECK_DATE = "CHECK_DATE";
            public const string DOC_SETID = "DOC_SETID";
            public const string DOC_TITLE = "DOC_TITLE";
            /// <summary>
            /// 文书最近的修改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";
            /// <summary>
            /// 错误级别 0 警告;1 错误
            /// </summary>
            public const string BUG_CLASS = "BUG_CLASS";
            /// <summary>
            /// 文档创建账号
            /// </summary>
            public const string CREATE_ID = "CREATE_ID";
            /// <summary>
            /// 文档创建者姓名
            /// </summary>
            public const string CREATE_NAME = "CREATE_NAME";
            /// <summary>
            /// 错误描述
            /// </summary>
            public const string QC_EXPLAIN = "QC_EXPLAIN";
            /// <summary>
            /// 质控结果 1:通过 0：不通过
            /// </summary>
            public const string QC_RESULT = "QC_RESULT";
            /// <summary>
            /// 责任医生
            /// </summary>
            public const string INCHARGE_DOCTOR = "INCHARGE_DOCTOR";
            /// <summary>
            /// 责任医生ID
            /// </summary>
            public const string INCHARGE_DOCTOR_ID = "INCHARGE_DOCTOR_ID";
            /// <summary>
            /// 责任科室
            /// </summary>
            public const string DEPT_IN_CHARGE = "DEPT_IN_CHARGE";
            /// <summary>
            /// 责任科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 患者姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 创建时间
            /// </summary>
            public const string DOC_TIME = "DOC_TIME";
            /// <summary>
            /// 检查类型：时效性 完整性 一致性 合理性
            /// </summary>
            public const string CHECK_TYPE = "CHECK_TYPE";
            public const string STAT_TYPE = "STAT_TYPE";
            public const string MR_STATUS = "MR_STATUS";
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 是否为单项否决 0:否;1:是
            /// </summary>
            public const string ISVETO = "ISVETO";
            /// <summary>
            /// 备注，人工质控时用户填写
            /// </summary>
            public const string REMARKS = "REMARKS";
        }
    }
}
