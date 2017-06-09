using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        public struct DataTable_HerenHis
        {

            /// <summary>
            /// 疾病字典库
            /// </summary>
            public const string diagnosis_dict = "diagnosis_dict";
            /// <summary>
            /// 患者主索引
            /// </summary>
            public const string PAT_MASTER_INDEX = "PAT_MASTER_INDEX";
            /// <summary>
            /// 病案首页信息表
            /// </summary>
            public const string INP_VISIT = "INP_VISIT";
            /// <summary>
            /// 码表
            /// </summary>
            public const string BASE_CODE_DICT = "BASE_CODE_DICT";
            /// <summary>
            /// 诊断信息表
            /// </summary>
            public const string DIAGNOSIS = "DIAGNOSIS";
        }

        public struct DataTable_BAJK
        {
            /// <summary>
            /// 疾病代码    
            /// </summary>
            public const string BA_ICDDM = "BA_ICDDM";
            /// <summary>
            /// 病人基本信息库
            /// </summary>
            public const string BAJK08 = "BAJK08";
            /// <summary>
            /// 诊断情况
            /// </summary>
            public const string BAJK09 = "BAJK09";
            /// <summary>
            /// 公用代码库
            /// </summary>
            public const string gy_gydm = "gy_gydm";

        }
        public struct DataTable
        {
            /// <summary>
            /// 病案上传编码对照表
            /// </summary>
            public const string REC_CODE_COMPASION = "REC_CODE_COMPASION";
            /// <summary>
            /// 病案上传记录
            /// </summary>
            public const string REC_UPLOAD = "REC_UPLOAD";
            /// <summary>
            /// 键值对表
            /// </summary>
            public const string KEY_VALUE_DATA = "KEY_VALUE_DATA";
            /// <summary>
            /// 表单
            /// </summary>
            public const string TEMPLET_TYPE = "TEMPLET_TYPE";
            /// <summary>
            /// 报表
            /// </summary>
            public const string REPORT_TYPE = "REPORT_TYPE";
            /// <summary>
            /// 病案打包信息表
            /// </summary>
            public const string REC_PACK = "REC_PACK";
            /// <summary>
            /// 复印记录表
            /// </summary>
            public const string REC_PRINT_LOG = "REC_PRINT_LOG";
            /// <summary>
            /// 纸质病历信息表
            /// </summary>
            public const string REC_PAPER = "REC_PAPER";
            /// <summary>
            /// 纸质病历批次发送信息表
            /// </summary>
            public const string REC_MR_BATCH = "REC_MR_BATCH";
            /// <summary>
            /// 病案索引补充表
            /// </summary>
            public const string QC_MR_INDEX = "QC_MR_INDEX";
            /// <summary>
            /// 整改通知单
            /// </summary>
            public const string QC_MODIFY_NOTICE = "QC_MODIFY_NOTICE";
            /// <summary>
            /// 质控管辖科室
            /// </summary>
            public const string QC_ADMIN_DEPTS = "QC_ADMIN_DEPTS";
            /// <summary>
            /// 系统参数配置表
            /// </summary>
            public const string HDP_PARAMETER_T = "HDP_PARAMETER_T";
            /// <summary>
            /// 菜单配置表
            /// </summary>
            public const string HDP_UICONFIG_T = "HDP_UICONFIG_T";
            /// <summary>
            /// 产品配置表
            /// </summary>
            public const string HDP_PRODUCT_T = "HDP_PRODUCT_T";
            /// <summary>
            /// 用户角色分配表
            /// </summary>
            public const string HDP_ROLE_USER_T = "HDP_ROLE_USER_T";
            /// <summary>
            /// 角色授权表
            /// </summary>
            public const string HDP_ROLE_GRANT_T = "HDP_ROLE_GRANT_T";
            /// <summary>
            /// 角色表
            /// </summary>
            public const string HDP_ROLE_T = "HDP_ROLE_T";
            /// <summary>
            /// 文书模板表
            /// </summary>
            public const string DOC_TEMPLET = "DOC_TEMPLET_T";
            /// <summary>
            /// 质控规则数据表
            /// </summary>
            public const string QC_RULE = "QC_RULE_T";
            /// <summary>
            /// 质控规则Entry数据表
            /// </summary>
            public const string QC_ENTRY = "QC_ENTRY_T";
            /// <summary>
            /// 质控评分结果表
            /// </summary>
            public const string QC_SCORE = "QC_SCORE";
            /// <summary>
            /// 质控消息表
            /// </summary>
            public const string MEDICAL_QC_MSG = "MEDICAL_QC_MSG";
            /// <summary>
            /// 质控日志表
            /// </summary>
            public const string MEDICAL_QC_LOG = "MEDICAL_QC_LOG";
            /// <summary>
            /// 反馈信息类别视图
            /// </summary>
            public const string QA_EVENT_TYPE_DICT = "QA_EVENT_TYPE_DICT";
            /// <summary>
            /// 自动核查结果表
            /// </summary>
            public const string QC_CHECK_RESULT = "QC_CHECK_RESULT";
            /// <summary>
            /// 自动核查缺陷点配置表
            /// </summary>
            public const string QC_CHECK_POINT = "QC_CHECK_POINT";
            /// <summary>
            /// 时效规则表
            /// </summary>
            public const string TIME_RULE = "MEDDOC.TIME_RULE_T";
            /// <summary>
            /// 时效事件表
            /// </summary>
            public const string TIME_EVENT = "MEDDOC.TIME_EVENT_T";
            /// <summary>
            /// 文档类型表
            /// </summary>
            public const string DOC_TYPE = "DOC_TYPE_DICT";
            /// <summary>
            /// 用户权限控制表
            /// </summary>
            public const string USER_RIGHT = "USER_RIGHT_T";
            /// <summary>
            /// 质控问题沟通信息记录表
            /// </summary>
            public const string QC_MSG_CHAT_LOG = "QC_MSG_CHAT_LOG_T";
            /// <summary>
            /// 时效性质控记录表
            /// </summary>
            public const string QC_TIME_RECORD = "QC_TIME_RECORD_T";
            /// <summary>
            /// 统计到个人的时效性质控记录表
            /// </summary>
            public const string QC_TIMERECORD_STATBYPATIENT = "QC_TIMERECORD_STATBYPATIENT_T";
            /// <summary>
            /// 统计到科室的时效性质控记录表
            /// </summary>
            public const string QC_TIMERECORD_STATBYDEPT = "QC_TIMERECORD_STATBYDEPT_T";
            /// <summary>
            /// 专家质控病案分配详情表
            /// </summary>
            public const string QC_SPECIAL_DETAIL = "QC_SPECIAL_DETAIL_T";
            /// <summary>
            /// 专家质控表
            /// </summary>
            public const string QC_SPECIAL_CHECK = "QC_SPECIAL_CHECK_T";
            /// <summary>
            /// 质控自动扣分规则配置表
            /// </summary>
            public const string QC_SCORE_CHECK = "QC_SCORE_CHECK_T";
            /// <summary>
            /// 病历时效扣分信息
            /// </summary>
            public const string QC_TIME_CHECK = "QC_TIME_CHECK";
            /// <summary>
            /// 病历文档状态信息
            /// </summary>
            public const string DOC_STATUS_T = "DOC_STATUS_T";
            /// <summary>
            /// 文档索引信息表
            /// </summary>
            public const string EMR_DOC = "EMR_DOC_T";
            /// <summary>
            /// 文档状态表
            /// </summary>
            public const string DOC_STATUS = "DOC_STATUS_T";
            /// <summary>
            /// 系统配置字典表
            /// </summary>
            public const string CONFIG_DICT = "CONFIG_DICT";
            /// <summary>
            /// 时效记录表
            /// </summary>
            public const string QC_TIME_RECORD_T = "QC_TIME_RECORD_T";
            /// <summary>
            /// 质控问题字典类
            /// </summary>
            public const string QC_MSG_DICT = "QC_MSG_DICT";
        }
    }
}
