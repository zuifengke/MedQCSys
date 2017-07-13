using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病案质量监控信息表相关字段定义
        /// </summary>
        public struct MedicalQcMsgTable
        {
            /// <summary>
            /// 问题文档创建者ID
            /// </summary>
            public const string CREATOR_ID = "CREATOR_ID";
            /// <summary>
            /// 质检问题ID
            /// </summary>
            public const string MSG_ID = "MSG_ID";
            /// <summary>
            /// 病人标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊流水号，新军卫有，其他his数据库和VISIT_ID一样
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 病人所在科室代码
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 病人经治医师
            /// </summary>
            public const string DOCTOR_IN_CHARGE = "DOCTOR_IN_CHARGE";
            /// <summary>
            /// 上级医生
            /// </summary>
            public const string PARENT_DOCTOR = "PARENT_DOCTOR";
            /// <summary>
            /// 主任医生
            /// </summary>
            public const string SUPER_DOCTOR = "SUPER_DOCTOR";
            /// <summary>
            /// 病案质量问题分类
            /// </summary>
            public const string QA_EVENT_TYPE = "QA_EVENT_TYPE";
            /// <summary>
            /// 反馈信息代码
            /// </summary>
            public const string QC_MSG_CODE = "QC_MSG_CODE";
            /// <summary>
            /// 反馈信息描述
            /// </summary>
            public const string MESSAGE = "MESSAGE";
            /// <summary>
            /// 发出者
            /// </summary>
            public const string ISSUED_BY = "ISSUED_BY";
            /// <summary>
            /// 发出者ID
            /// </summary>
            public const string ISSUED_ID = "ISSUED_ID";
            /// <summary>
            /// 发出时间
            /// </summary>
            public const string ISSUED_DATE_TIME = "ISSUED_DATE_TIME";
            /// <summary>
            /// 信息状态0 未确认/未接收  1 已确认/已接受 2 已修改 3合格
            /// </summary>
            public const string MSG_STATUS = "MSG_STATUS";
            /// <summary>
            /// 信息确认时间
            /// </summary>
            public const string ASK_DATE_TIME = "ASK_DATE_TIME";
            /// <summary>
            /// 病案质控类型
            /// </summary>
            public const string QC_MODULE = "QC_MODULE";
            /// <summary>
            /// 病历主题代码
            /// </summary>
            public const string TOPIC_ID = "TOPIC_ID";
            /// <summary>
            /// 病历主题
            /// </summary>
            public const string TOPIC = "TOPIC";
            /// <summary>
            /// 医生反馈信息
            /// </summary>
            public const string DOCTOR_COMMENT = "DOCTOR_COMMENT";
            /// <summary>
            /// 扣分值
            /// </summary>
            public const string POINT = "POINT";
            /// <summary>
            /// 扣分类型  0-自动扣分 1-手动输入扣分
            /// </summary>
            public const string POINT_TYPE = "POINT_TYPE";
            /// <summary>
            /// 强制锁定状态，0:不锁定 1:锁定，必须修改问题才能创建病历
            /// </summary>
            public const string LOCK_STATUS = "LOCK_STATUS";
            /// <summary>
            /// 应用环境 MEDDOC  NURDOC
            /// </summary>
            public const string APPLY_ENV = "APPLY_ENV";
            /// <summary>
            /// 添加问题者类型，0:普通医生，1专家医生
            /// </summary>
            public const string ISSUED_TYPE = "ISSUED_TYPE";
            /// <summary>
            /// 添加问题时的病历状态(运行病历，终末病历)：0，在院病历，1，出院病历，2，死亡病历
            /// </summary>
            public const string QCDOC_TYPE = "QCDOC_TYPE";
            /// <summary>
            /// 整改通知书ID
            /// </summary>
            public const string MODIFY_NOTICE_ID = "MODIFY_NOTICE_ID";
            /// <summary>
            /// 错误次数
            /// </summary>
            public const string ERROR_COUNT = "ERROR_COUNT";
            /// <summary>
            /// 病历ID号
            /// </summary>
            public const string DOC_ID = "DOC_ID";
        }
    }
}
