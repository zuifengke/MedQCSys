using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 新系统手术信息
    /// </summary>
    public class OperationMaster : DbTypeBase
    {
        /// <summary>
        /// 手术申请号
        /// </summary>
        public string OPER_NO { get; set; }
        /// <summary>
        /// 医嘱号
        /// </summary>
        public string ORDER_ID { get; set; }
        /// <summary>
        /// 医疗类别
        /// </summary>
        public int CLINIC_CATE { get; set; }
        /// <summary>
        /// 患者标识
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 患者就诊流水标识
        /// </summary>
        public string VISIT_NO { get; set; }
        /// <summary>
        /// 病人本次住院标识
        /// </summary>
        public int VISIT_ID { get; set; }
        /// <summary>
        /// 手术安排标识
        /// </summary>
        public int SCHEDULE_ID { get; set; }
        /// <summary>
        /// 病人所在科室
        /// </summary>
        public string DEPT_STAYED { get; set; }
        /// <summary>
        /// 预约手术日期及时间
        /// </summary>
        public DateTime SCHEDULED_DATE_TIME { get; set; }
        /// <summary>
        /// 手术室
        /// </summary>
        public string OPERATING_ROOM { get; set; }
        /// <summary>
        /// 手术间
        /// </summary>
        public string OPERATION_ROOM_NO { get; set; }
        /// <summary>
        /// 手术台次
        /// </summary>
        public int OPERATION_SEQUENCE { get; set; }
        /// <summary>
        /// 术前主要诊断描述
        /// </summary>
        public string DIAG_BEFORE_OPERATION { get; set; }
        /// <summary>
        /// 术后主要诊断描述
        /// </summary>
        public string DIAG_AFTER_OPERATION { get; set; }
        /// <summary>
        /// 病情说明
        /// </summary>
        public string PATIENT_CONDITION { get; set; }
        /// <summary>
        /// 手术等级
        /// </summary>
        public string OPERATING_SCALE { get; set; }
        /// <summary>
        /// 隔离标志
        /// </summary>
        public string ISOLATION_FLAG { get; set; }
        /// <summary>
        /// 手术科室
        /// </summary>
        public string OPERATING_DEPT { get; set; }
        /// <summary>
        /// 手术医师编码
        /// </summary>
        public string OPERATOR_DOCTOR_ID { get; set; }
        /// <summary>
        /// 手术医师
        /// </summary>
        public string OPERATOR_DOCTOR { get; set; }
        /// <summary>
        /// 第一助手编码
        /// </summary>
        public string FIRST_ASSISTANT_ID { get; set; }
        /// <summary>
        /// 第一助手
        /// </summary>
        public string FIRST_ASSISTANT { get; set; }
        /// <summary>
        /// 第二助手编码
        /// </summary>
        public string SECOND_ASSISTANT_ID { get; set; }
        /// <summary>
        /// 第二助手
        /// </summary>
        public string SECOND_ASSISTANT { get; set; }
        /// <summary>
        /// 第三助手编码
        /// </summary>
        public string THREE_ASSISTANT_ID { get; set; }
        /// <summary>
        /// 第三助手
        /// </summary>
        public string THREE_ASSISTANT { get; set; }
        /// <summary>
        /// 第四助手编码
        /// </summary>
        public string FOUR_ASSISTANT_ID { get; set; }
        /// <summary>
        /// 第四助手
        /// </summary>
        public string FOUR_ASSISTANT { get; set; }
        /// <summary>
        /// 麻醉方法
        /// </summary>
        public string ANAESTHESIA_METHOD { get; set; }
        /// <summary>
        /// 麻醉医师编码
        /// </summary>
        public string ANESTHESIA_DOCTOR_ID { get; set; }
        /// <summary>
        /// 麻醉医师
        /// </summary>
        public string ANESTHESIA_DOCTOR { get; set; }
        /// <summary>
        /// 麻醉医师第一助手编码
        /// </summary>
        public string FIRST_ANESTHESIA_ID { get; set; }
        /// <summary>
        /// 麻醉医师第一助手
        /// </summary>
        public string FIRST_ANESTHESIA { get; set; }
        /// <summary>
        /// 麻醉医师第二助手编码
        /// </summary>
        public string SECOND_ANESTHESIA_ID { get; set; }

        /// <summary>
        /// 麻醉医师第二助手
        /// </summary>
        public string SECOND_ANESTHESIA { get; set; }

        /// <summary>
        /// 输血医师编码
        /// </summary>
        public string BLOOD_DOCTOR_ID { get; set; }

        /// <summary>
        /// 输血医师
        /// </summary>
        public string BLOOD_DOCTOR { get; set; }

        /// <summary>
        /// 台上护士1编码
        /// </summary>
        public string FIRST_OPERATION_NURSE_ID { get; set; }

        /// <summary>
        /// 台上护士1
        /// </summary>
        public string FIRST_OPERATION_NURSE { get; set; }

        /// <summary>
        /// 台上护士2编码
        /// </summary>
        public string SECOND_OPERATION_NURSE_ID { get; set; }

        /// <summary>
        /// 台上护士2
        /// </summary>
        public string SECOND_OPERATION_NURSE { get; set; }

        /// <summary>
        /// 供应护士1编码
        /// </summary>
        public string FIRST_SUPPLY_NURSE_ID { get; set; }

        /// <summary>
        /// 供应护士1
        /// </summary>
        public string FIRST_SUPPLY_NURSE { get; set; }

        /// <summary>
        /// 供应护士2编码
        /// </summary>
        public string SECOND_SUPPLY_NURSE_ID { get; set; }

        /// <summary>
        /// 供应护士2
        /// </summary>
        public string SECOND_SUPPLY_NURSE { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string NOTES_ON_OPERATION { get; set; }

        /// <summary>
        /// 申请日期及时间
        /// </summary>
        public DateTime REQ_DATE_TIME { get; set; }

        /// <summary>
        /// 申请来源方向
        /// </summary>
        public int ACK_DIRECTION { get; set; }
        /// <summary>
        /// 急诊标志
        /// </summary>
        public string EMERGENCY_FLAG { get; set; }
        /// <summary>
        /// 申请状态
        /// </summary>
        public string APPLY_STATUS { get; set; }
        /// <summary>
        /// 取消原因
        /// </summary>
        public string CANCEL_MEMO { get; set; }
        /// <summary>
        /// 取消时间
        /// </summary>
        public DateTime CANCEL_DATE_TIME { get; set; }
        /// <summary>
        /// 取消医师
        /// </summary>
        public string CANCEL_DOCTOR { get; set; }
        /// <summary>
        /// 手术护士换班标志
        /// </summary>
        public int NURSE_SHIFT_INDICATOR { get; set; }
        /// <summary>
        /// 手术开始日期及时间
        /// </summary>
        public DateTime START_DATE_TIME { get; set; }
        /// <summary>
        /// 手术结束日期及时间
        /// </summary>
        public DateTime END_DATE_TIME { get; set; }
        /// <summary>
        /// 麻醉满意程度
        /// </summary>
        public int SATISFACTION_DEGREE { get; set; }
        /// <summary>
        /// 手术过程顺利标志
        /// </summary>
        public int SMOOTH_INDICATOR { get; set; }
        /// <summary>
        /// 总入量
        /// </summary>
        public int IN_FLUIDS_AMOUNT { get; set; }
        /// <summary>
        /// 总出量
        /// </summary>
        public int OUT_FLUIDS_AMOUNT { get; set; }
        /// <summary>
        /// 失血量
        /// </summary>
        public int BLOOD_LOSSED { get; set; }
        /// <summary>
        /// 输血量
        /// </summary>
        public int BLOOD_TRANSFERED { get; set; }
        /// <summary>
        /// 录入者ID
        /// </summary>
        public string ENTERED_BY_ID { get; set; }
        /// <summary>
        /// 录入者
        /// </summary>
        public string ENTERED_BY { get; set; }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime ENTERED_DATE { get; set; }
        /// <summary>
        /// 计费标志
        /// </summary>
        public int CHARGE_INDICATOR { get; set; }
        public OperationMaster(){
            this.START_DATE_TIME = this.DefaultTime;
            this.END_DATE_TIME = this.DefaultTime;
            this.REQ_DATE_TIME = this.DefaultTime;
        }
    }
}
