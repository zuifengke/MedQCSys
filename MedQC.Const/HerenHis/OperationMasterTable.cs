using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病人手术信息视图数据字段
        /// </summary>
        public struct OperationMasterTable
        {
            /// <summary>
            /// 手术申请号
            /// </summary>
            public const string OPER_NO = "OPER_NO";
            /// <summary>
            /// 医嘱号
            /// </summary>
            public const string ORDER_ID = "ORDER_ID";
            /// <summary>
            /// 医疗类别
            /// </summary>
            public const string CLINIC_CATE = "CLINIC_CATE";
            /// <summary>
            /// 患者标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 患者就诊流水标识
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 病人本次住院标识
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 手术安排标识
            /// </summary>
            public const string SCHEDULE_ID = "SCHEDULE_ID";
            /// <summary>
            /// 病人所在科室
            /// </summary>
            public const string DEPT_STAYED = "DEPT_STAYED";
            /// <summary>
            /// 预约手术日期及时间
            /// </summary>
            public const string SCHEDULED_DATE_TIME = "SCHEDULED_DATE_TIME";
            /// <summary>
            /// 手术室
            /// </summary>
            public const string OPERATING_ROOM = "OPERATING_ROOM";
            /// <summary>
            /// 手术间
            /// </summary>
            public const string OPERATION_ROOM_NO = "OPERATION_ROOM_NO";
            /// <summary>
            /// 手术台次
            /// </summary>
            public const string OPERATION_SEQUENCE = "OPERATION_SEQUENCE";
            /// <summary>
            /// 术前主要诊断描述
            /// </summary>
            public const string DIAG_BEFORE_OPERATION = "DIAG_BEFORE_OPERATION";
            /// <summary>
            /// 术后主要诊断描述
            /// </summary>
            public const string DIAG_AFTER_OPERATION = "DIAG_AFTER_OPERATION";
            /// <summary>
            /// 病情说明
            /// </summary>
            public const string PATIENT_CONDITION = "PATIENT_CONDITION";
            /// <summary>
            /// 手术等级
            /// </summary>
            public const string OPERATING_SCALE = "OPERATING_SCALE";
            /// <summary>
            /// 隔离标志
            /// </summary>
            public const string ISOLATION_FLAG = "ISOLATION_FLAG";
            /// <summary>
            /// 手术科室
            /// </summary>
            public const string OPERATING_DEPT = "OPERATING_DEPT";
            /// <summary>
            /// 手术医师编码
            /// </summary>
            public const string OPERATOR_DOCTOR_ID = "OPERATOR_DOCTOR_ID";
            /// <summary>
            /// 手术医师
            /// </summary>
            public const string OPERATOR_DOCTOR = "OPERATOR_DOCTOR";
            /// <summary>
            /// 第一助手编码
            /// </summary>
            public const string FIRST_ASSISTANT_ID = "FIRST_ASSISTANT_ID";
            /// <summary>
            /// 第一助手
            /// </summary>
            public const string FIRST_ASSISTANT = "FIRST_ASSISTANT";
            /// <summary>
            /// 第二助手编码
            /// </summary>
            public const string SECOND_ASSISTANT_ID = "SECOND_ASSISTANT_ID";
            /// <summary>
            /// 第二助手
            /// </summary>
            public const string SECOND_ASSISTANT = "SECOND_ASSISTANT";
            /// <summary>
            /// 第三助手编码
            /// </summary>
            public const string THREE_ASSISTANT_ID = "THREE_ASSISTANT_ID";
            /// <summary>
            /// 第三助手
            /// </summary>
            public const string THREE_ASSISTANT = "THREE_ASSISTANT";
            /// <summary>
            /// 第四助手编码
            /// </summary>
            public const string FOUR_ASSISTANT_ID = "FOUR_ASSISTANT_ID";
            /// <summary>
            /// 第四助手
            /// </summary>
            public const string FOUR_ASSISTANT = "FOUR_ASSISTANT";
            /// <summary>
            /// 麻醉方法
            /// </summary>
            public const string ANAESTHESIA_METHOD = "ANAESTHESIA_METHOD";
            /// <summary>
            /// 麻醉医师编码
            /// </summary>
            public const string ANESTHESIA_DOCTOR_ID = "ANAESTHESIA_METHOD";
            /// <summary>
            /// 麻醉医师
            /// </summary>
            public const string ANESTHESIA_DOCTOR = "ANESTHESIA_DOCTOR";
            /// <summary>
            /// 麻醉医师第一助手编码
            /// </summary>
            public const string FIRST_ANESTHESIA_ID = "FIRST_ANESTHESIA_ID";
            /// <summary>
            /// 麻醉医师第一助手
            /// </summary>
            public const string FIRST_ANESTHESIA = "FIRST_ANESTHESIA";
            /// <summary>
            /// 麻醉医师第二助手编码
            /// </summary>
            public const string SECOND_ANESTHESIA_ID = "SECOND_ANESTHESIA_ID";

            /// <summary>
            /// 麻醉医师第二助手
            /// </summary>
            public const string SECOND_ANESTHESIA = "SECOND_ANESTHESIA";

            /// <summary>
            /// 输血医师编码
            /// </summary>
            public const string BLOOD_DOCTOR_ID = "BLOOD_DOCTOR_ID";

            /// <summary>
            /// 输血医师
            /// </summary>
            public const string BLOOD_DOCTOR = "BLOOD_DOCTOR";

            /// <summary>
            /// 台上护士1编码
            /// </summary>
            public const string FIRST_OPERATION_NURSE_ID = "FIRST_OPERATION_NURSE_ID";

            /// <summary>
            /// 台上护士1
            /// </summary>
            public const string FIRST_OPERATION_NURSE = "FIRST_OPERATION_NURSE";

            /// <summary>
            /// 台上护士2编码
            /// </summary>
            public const string SECOND_OPERATION_NURSE_ID = "SECOND_OPERATION_NURSE_ID";

            /// <summary>
            /// 台上护士2
            /// </summary>
            public const string SECOND_OPERATION_NURSE = "SECOND_OPERATION_NURSE";

            /// <summary>
            /// 供应护士1编码
            /// </summary>
            public const string FIRST_SUPPLY_NURSE_ID = "FIRST_SUPPLY_NURSE_ID";

            /// <summary>
            /// 供应护士1
            /// </summary>
            public const string FIRST_SUPPLY_NURSE = "FIRST_SUPPLY_NURSE";

            /// <summary>
            /// 供应护士2编码
            /// </summary>
            public const string SECOND_SUPPLY_NURSE_ID = "SECOND_SUPPLY_NURSE_ID";

            /// <summary>
            /// 供应护士2
            /// </summary>
            public const string SECOND_SUPPLY_NURSE = "SECOND_SUPPLY_NURSE";

            /// <summary>
            /// 备注
            /// </summary>
            public const string NOTES_ON_OPERATION = "NOTES_ON_OPERATION";

            /// <summary>
            /// 申请日期及时间
            /// </summary>
            public const string REQ_DATE_TIME = "REQ_DATE_TIME";

            /// <summary>
            /// 申请来源方向
            /// </summary>
            public const string ACK_DIRECTION = "ACK_DIRECTION";
            /// <summary>
            /// 急诊标志
            /// </summary>
            public const string EMERGENCY_FLAG = "EMERGENCY_FLAG";
            /// <summary>
            /// 申请状态
            /// </summary>
            public const string APPLY_STATUS = "APPLY_STATUS";
            /// <summary>
            /// 取消原因
            /// </summary>
            public const string CANCEL_MEMO = "CANCEL_MEMO";
            /// <summary>
            /// 取消时间
            /// </summary>
            public const string CANCEL_DATE_TIME = "CANCEL_DATE_TIME";
            /// <summary>
            /// 取消医师
            /// </summary>
            public const string CANCEL_DOCTOR = "CANCEL_DATE_TIME";
            /// <summary>
            /// 手术护士换班标志
            /// </summary>
            public const string NURSE_SHIFT_INDICATOR = "NURSE_SHIFT_INDICATOR";
            /// <summary>
            /// 手术开始日期及时间
            /// </summary>
            public const string START_DATE_TIME = "START_DATE_TIME";
            /// <summary>
            /// 手术结束日期及时间
            /// </summary>
            public const string END_DATE_TIME = "END_DATE_TIME";
            /// <summary>
            /// 麻醉满意程度
            /// </summary>
            public const string SATISFACTION_DEGREE = "SATISFACTION_DEGREE";
            /// <summary>
            /// 手术过程顺利标志
            /// </summary>
            public const string SMOOTH_INDICATOR = "SMOOTH_INDICATOR";
            /// <summary>
            /// 总入量
            /// </summary>
            public const string IN_FLUIDS_AMOUNT = "IN_FLUIDS_AMOUNT";
            /// <summary>
            /// 总出量
            /// </summary>
            public const string OUT_FLUIDS_AMOUNT = "OUT_FLUIDS_AMOUNT";
            /// <summary>
            /// 失血量
            /// </summary>
            public const string BLOOD_LOSSED = "BLOOD_LOSSED";
            /// <summary>
            /// 输血量
            /// </summary>
            public const string BLOOD_TRANSFERED = "BLOOD_TRANSFERED";
            /// <summary>
            /// 录入者ID
            /// </summary>
            public const string ENTERED_BY_ID = "ENTERED_BY_ID";
            /// <summary>
            /// 录入者
            /// </summary>
            public const string ENTERED_BY = "ENTERED_BY";
            /// <summary>
            /// 录入时间
            /// </summary>
            public const string ENTERED_DATE = "ENTERED_DATE";
            /// <summary>
            /// 计费标志
            /// </summary>
            public const string CHARGE_INDICATOR = "CHARGE_INDICATOR";
        }
    }
}
