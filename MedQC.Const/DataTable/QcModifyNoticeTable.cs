using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// <summary>
        /// 整改通知单
        /// </summary>
        public struct QcModifyNoticeTable
        {
            /// <summary>
            /// 整改通知单主键
            /// </summary>
            public const string MODIFY_NOTICE_ID = "MODIFY_NOTICE_ID";
            /// <summary>
            /// 整改通知时间
            /// </summary>
            public const string NOTICE_TIME = "NOTICE_TIME";
            /// <summary>
            /// 质控人
            /// </summary>
            public const string QC_MAN = "QC_MAN";
            /// <summary>
            /// 质控人ID
            /// </summary>
            public const string QC_MAN_ID = "QC_MAN_ID";
            /// <summary>
            /// 质控科室名称
            /// </summary>
            public const string QC_DEPT_NAME = "QC_DEPT_NAME";
            /// <summary>
            /// 质控科室代码
            /// </summary>
            public const string QC_DEPT_CODE = "QC_DEPT_CODE";
            /// <summary>
            /// 接收人
            /// </summary>
            public const string RECEIVER = "RECEIVER";
            /// <summary>
            /// 接收人ID
            /// </summary>
            public const string RECEIVER_ID = "RECEIVER_ID";
            /// <summary>
            /// 接收人科室
            /// </summary>
            public const string RECEIVER_DEPT_NAME = "RECEIVER_DEPT_NAME";
            /// <summary>
            /// 接收人科室代码
            /// </summary>
            public const string RECEIVER_DEPT_CODE = "RECEIVER_DEPT_CODE";
            /// <summary>
            /// 通知单状态 0：草稿；1 已发送；2 接收；3 已修改；4 确认合格；5 被驳回
            /// </summary>
            public const string NOTICE_STATUS = "NOTICE_STATUS";
            /// <summary>
            /// 整改扣分
            /// </summary>
            public const string MODIFY_SCORE = "MODIFY_SCORE";
            /// <summary>
            /// 质控级别：O 环节质控；1 终末质控 ；2 专家质控 
            /// </summary>
            public const string QC_LEVEL = "QC_LEVEL";
            /// <summary>
            /// 整改期限
            /// </summary>
            public const string MODIFY_PERIOD = "MODIFY_PERIOD";
            /// <summary>
            /// 患者病案号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 患者入院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 患者姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 患者就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 整改备注
            /// </summary>
            public const string MODIFY_REMARK = "MODIFY_REMARK";
            /// <summary>
            /// 整改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";
        }
    }
}
