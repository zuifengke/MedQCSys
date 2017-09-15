using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// RDB数据视图
        /// </summary>
        public struct DataView
        {
            /// <summary>
            /// 转科记录视图
            /// </summary>
            public const string TRANSFER_V = "TRANSFER_V";
            /// <summary>
            /// 病案归档视图
            /// </summary>
            public const string MR_ARCHIVE_V = "MR_ARCHIVE_V";
            /// <summary>
            /// 输血记录表
            /// </summary>
            public const string BLOOD_TRANSFUSION_V = "BLOOD_TRANSFUSION_V";
            /// <summary>
            /// 新生儿登记表
            /// </summary>
            public const string BABY_JUST_BORN_RECORD_V = "BABY_JUST_BORN_RECORD_V";
            /// <summary>
            /// 病案索引表
            /// </summary>
            public const string MR_INDEX_V = "MR_INDEX_V";
         
            /// <summary>
            /// 以往病历数据视图
            /// </summary>
            public const string PAST_DOC = "PAST_DOC_V";
            /// <summary>
            /// 医嘱数据视图
            /// </summary>
            public const string ORDERS = "ORDERS_V";
            /// <summary>
            /// ICD诊断数据视图
            /// </summary>
            public const string ICD_DIAGNOSIS = "ICD_DIAGNOSIS_V";
            /// <summary>
            /// 检查主索引数据视图
            /// </summary>
            public const string EXAM_MASTER = "EXAM_MASTER_V";
            /// <summary>
            /// 检查报告数据视图
            /// </summary>
            public const string EXAM_RESULT = "EXAM_RESULT_V";
            /// <summary>
            /// 检验主记录数据视图
            /// </summary>
            public const string LAB_MASTER = "LAB_MASTER_V";
            /// <summary>
            /// 检验结果数据视图
            /// </summary>
            public const string LAB_RESULT = "LAB_RESULT_V";
            /// <summary>
            /// 病案质量监控日志
            /// </summary>
            public const string QC_LOG_V = "QC_LOG_V";
            /// <summary>
            /// 病人就诊视图
            /// </summary>
            public const string PAT_VISIT_V = "PAT_VISIT_V";
            /// <summary>
            /// 病人反馈信息视图
            /// </summary>
            public const string QC_MSG_V = "QC_MSG_V";
            /// <summary>
            /// 病人诊断信息视图
            /// </summary>
            public const string DIAGNOSIS_V = "DIAGNOSIS_V";
            /// <summary>
            /// 患者体征视图
            /// </summary>
            public const string VITAL_SIGNS_V = "VITAL_SIGNS_V";
            /// <summary>
            /// 在院病人信息视图
            /// </summary>
            public const string INP_VISIT_V = "INP_VISIT_V";
            /// <summary>
            /// 科室视图
            /// </summary>
            public const string DEPT_V = "DEPT_V";
            /// <summary>
            /// 医疗组名称视图
            /// </summary>
            public const string DOCTOR_GROUP_V = "DOCTOR_GROUP_V";
            /// <summary>
            /// 病人病情变化视图
            /// </summary>
            public const string ADT_LOG_V = "ADT_LOG_V";
            /// <summary>
            /// 病人手术视图
            /// </summary>
            public const string OPERATION_V = "OPERATION_V";
            /// <summary>
            /// 病人手术信息视图
            /// </summary>
            public const string OPERATION_MASTER_V = "OPERATION_MASTER_V";
            /// <summary>
            /// 病人手术名称视图
            /// </summary>
            public const string OPERATION_NAME_V = "OPERATION_NAME_V";
            /// <summary>
            /// 手术操作字典视图
            /// </summary>
            public const string OPERATION_DICT_V = "OPERATION_DICT_V";
            /// <summary>
            /// 用户视图
            /// </summary>
            public const string USER_V = "USER_V";
            /// <summary>
            /// 责任医生视图
            /// </summary>
            public const string PAT_DOCTOR_V = "PAT_DOCTOR_V";
            /// <summary>
            /// 费别字典视图
            /// </summary>
            public const string CHARGE_TYPE_DICT_V = "CHARGE_TYPE_DICT_V";
            /// <summary>
            /// 身份字典视图
            /// </summary>
            public const string IDENTITY_DICT_V = "IDENTITY_DICT_V";
            /// <summary>
            /// 字典视图
            /// </summary>
            public const string DICT_V = "DICT_V";
            /// <summary>
            /// 医生管辖科室视图
            /// </summary>
            public const string DOC_ADMIN_DEPTS_V = "DOC_ADMIN_DEPTS_V";
            /// <summary>
            /// 病历审核申请表视图
            /// </summary>
            public const string DOC_RECORD_MODIFY_APPLY_V = "DOC_RECORD_MODIFY_APPLY_V";

        }

    }
}
