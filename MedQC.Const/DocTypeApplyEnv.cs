using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 报告应用环境常量
        /// </summary>
        public struct DocTypeApplyEnv
        {
            /// <summary>
            /// 病案上传
            /// </summary>
            public const string REC_UPLOAD = "REC_UPLOAD";
            /// <summary>
            /// 患者信息
            /// </summary>
            public const string PATIENT_INFO = "PATIENT_INFO";
            /// <summary>
            /// 全局功能模块插件 GLOBAL_MODULE
            /// </summary>
            public const string GLOBAL_MODULE = "GLOBAL_MODULE";

            /// <summary>
            /// 病人功能模块插件 PATIENT_MODULE
            /// </summary>
            public const string PATIENT_MODULE = "PATIENT_MODULE";

            /// <summary>
            /// 护理记录 NURSING_RECORD
            /// </summary>
            public const string NURSING_RECORD = "NURSING_RECORD";

            /// <summary>
            /// 护理文档 NURSING_DOCUMENT
            /// </summary>
            public const string NURSING_DOCUMENT = "NURSING_DOCUMENT";

            /// <summary>
            /// 专科护理 NURSING_SPECIAL
            /// </summary>
            public const string NURSING_SPECIAL = "NURSING_SPECIAL";

            /// <summary>
            /// 护理评估 NURSING_ASSESSMENT
            /// </summary>
            public const string NURSING_ASSESSMENT = "NURSING_ASSESSMENT";

            /// <summary>
            /// 文书列表1 NURDOC_LIST1
            /// </summary>
            public const string NURDOC_LIST1 = "NURDOC_LIST1";

            /// <summary>
            /// 文书列表2 NURDOC_LIST2
            /// </summary>
            public const string NURDOC_LIST2 = "NURDOC_LIST2";

            /// <summary>
            /// 文书列表3 NURDOC_LIST3
            /// </summary>
            public const string NURDOC_LIST3 = "NURDOC_LIST3";

            /// <summary>
            /// 文书列表4 NURDOC_LIST4
            /// </summary>
            public const string NURDOC_LIST4 = "NURDOC_LIST4";

            /// <summary>
            /// 床卡视图 BED_VIEW
            /// </summary>
            public const string BED_VIEW = "BED_VIEW";

            /// <summary>
            /// 白板视图 WHITEBOARD_VIEW
            /// </summary>
            public const string WHITEBOARD_VIEW = "WHITEBOARD_VIEW";

            /// <summary>
            /// 体征快捷录入 SIGNS_DATA_RECORD
            /// </summary>
            public const string SIGNS_DATA_RECORD = "SIGNS_DATA_RECORD";

            /// <summary>
            /// 批量录入筛选 BATCH_RECORD_FILTER
            /// </summary>
            public const string BATCH_RECORD_FILTER = "BATCH_RECORD_FILTER";

            /// <summary>
            /// 护理记录内容显示区 NURSING_REC_CONTENT
            /// </summary>
            public const string NURSING_REC_CONTENT = "NURSING_REC_CONTENT";

            /// <summary>
            /// 护理交班志
            /// </summary>
            public const string NURSING_WORKSHIFT = "NURSING_WORKSHIFT";

            /// <summary>
            /// 专科一览表
            /// </summary>
            public const string SPECIAL_PATIENT = "SPECIAL_PATIENT";

            /// <summary>
            /// 待办任务 NURSING_TASK
            /// </summary>
            public const string NURSING_TASK = "NURSING_TASK";

            /// <summary>
            /// 护理会诊 NURSING_CONSULT
            /// </summary>
            public const string NURSING_CONSULT = "NURSING_CONSULT";

            /// <summary>
            /// 查询统计 NURSING_STATISTIC
            /// </summary>
            public const string NURSING_STATISTIC = "NURSING_STATISTIC";

            /// <summary>
            /// 护理计划 NURSING_CARE_PLAN
            /// </summary>
            public const string NURSING_CARE_PLAN = "NURSING_CARE_PLAN";

            /// <summary>
            /// 护理首页 NURSING_HOME_PAGE
            /// </summary>
            public const string NURSING_HOME_PAGE = "NURSING_HOME_PAGE";

            /// <summary>
            /// 综合查询 INTEGRATE_QUERY
            /// </summary>
            public const string INTEGRATE_QUERY = "INTEGRATE_QUERY";

            /// <summary>
            /// 护理质控 NURSING_QC
            /// </summary>
            public const string NURSING_QC = "NURSING_QC";

            /// <summary>
            /// 护理记录小结 NURSING_SUMMARY
            /// </summary>
            public const string NURSING_SUMMARY = "NURSING_SUMMARY";

            public static string[] GetApplyEnvNames()
            {
                return new string[] {
                    "患者信息",
                    "病案上传",
                    "全局功能模块插件"};
            }

            public static string GetApplyEnvName(string applyEnvCode)
            {
                if (applyEnvCode == REC_UPLOAD)
                    return "病案上传";
                else if (applyEnvCode == NURSING_DOCUMENT)
                    return "护理文书";
                else if (applyEnvCode == PATIENT_INFO)
                    return "患者信息";
                else if (applyEnvCode == NURSING_ASSESSMENT)
                    return "护理评估";
                else if (applyEnvCode == NURDOC_LIST1)
                    return "文书列表1";
                else if (applyEnvCode == NURDOC_LIST2)
                    return "文书列表2";
                else if (applyEnvCode == NURDOC_LIST3)
                    return "文书列表3";
                else if (applyEnvCode == NURDOC_LIST4)
                    return "文书列表4";
                else if (applyEnvCode == NURSING_SPECIAL)
                    return "专科护理";
                else if (applyEnvCode == BED_VIEW)
                    return "床卡视图";
                else if (applyEnvCode == NURSING_TASK)
                    return "待办任务";
                else if (applyEnvCode == NURSING_STATISTIC)
                    return "查询统计";
                else if (applyEnvCode == INTEGRATE_QUERY)
                    return "综合查询";
                else if (applyEnvCode == NURSING_CONSULT)
                    return "护理会诊";
                else if (applyEnvCode == NURSING_CARE_PLAN)
                    return "护理计划";
                else if (applyEnvCode == NURSING_QC)
                    return "护理质控";
                else if (applyEnvCode == NURSING_HOME_PAGE)
                    return "系统起始页";
                else if (applyEnvCode == NURSING_WORKSHIFT)
                    return "护理交接班";
                else if (applyEnvCode == SPECIAL_PATIENT)
                    return "专科一览表";
                else if (applyEnvCode == NURSING_SUMMARY)
                    return "护理记录小结";
                else if (applyEnvCode == WHITEBOARD_VIEW)
                    return "护士站白板视图";
                else if (applyEnvCode == SIGNS_DATA_RECORD)
                    return "体征快捷录入窗口";
                else if (applyEnvCode == BATCH_RECORD_FILTER)
                    return "批量录入筛选窗口";
                else if (applyEnvCode == NURSING_REC_CONTENT)
                    return "护理记录内容窗口";
                else if (applyEnvCode == PATIENT_MODULE)
                    return "病人功能模块插件";
                else if (applyEnvCode == GLOBAL_MODULE)
                    return "全局功能模块插件";
                return string.Empty;
            }

            public static string GetApplyEnvCode(string applyEnvName)
            {
                if (applyEnvName == "病案上传")
                    return REC_UPLOAD;
                else if (applyEnvName == "患者信息")
                    return PATIENT_INFO;
                else if (applyEnvName == "护理评估")
                    return NURSING_ASSESSMENT;
                else if (applyEnvName == "文书列表1")
                    return NURDOC_LIST1;
                else if (applyEnvName == "文书列表2")
                    return NURDOC_LIST2;
                else if (applyEnvName == "文书列表3")
                    return NURDOC_LIST3;
                else if (applyEnvName == "文书列表4")
                    return NURDOC_LIST4;
                else if (applyEnvName == "专科护理")
                    return NURSING_SPECIAL;
                else if (applyEnvName == "床卡视图")
                    return BED_VIEW;
                else if (applyEnvName == "待办任务")
                    return NURSING_TASK;
                else if (applyEnvName == "查询统计")
                    return NURSING_STATISTIC;
                else if (applyEnvName == "综合查询")
                    return INTEGRATE_QUERY;
                else if (applyEnvName == "护理会诊")
                    return NURSING_CONSULT;
                else if (applyEnvName == "护理计划")
                    return NURSING_CARE_PLAN;
                else if (applyEnvName == "护理质控")
                    return NURSING_QC;
                else if (applyEnvName == "护理记录小结")
                    return NURSING_SUMMARY;
                else if (applyEnvName == "系统起始页")
                    return NURSING_HOME_PAGE;
                else if (applyEnvName == "护理交接班")
                    return NURSING_WORKSHIFT;
                else if (applyEnvName == "专科一览表")
                    return SPECIAL_PATIENT;
                else if (applyEnvName == "护理记录小结")
                    return NURSING_SUMMARY;
                else if (applyEnvName == "护士站白板视图")
                    return WHITEBOARD_VIEW;
                else if (applyEnvName == "体征快捷录入窗口")
                    return SIGNS_DATA_RECORD;
                else if (applyEnvName == "批量录入筛选窗口")
                    return BATCH_RECORD_FILTER;
                else if (applyEnvName == "护理记录内容窗口")
                    return NURSING_REC_CONTENT;
                else if (applyEnvName == "病人功能模块插件")
                    return PATIENT_MODULE;
                else if (applyEnvName == "全局功能模块插件")
                    return GLOBAL_MODULE;
                return string.Empty;
            }
        }
    }
}
