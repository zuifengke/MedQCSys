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
        public struct ReportTypeApplyEnv
        {
            /// <summary>
            /// 体温单 TEMPERATURE
            /// </summary>
            public const string TEMPERATURE = "TEMPERATURE";
            /// <summary>
            /// 病案首页
            /// </summary>
            public const string PATIENT_INDEX = "PATIENT_INDEX";
            /// <summary>
            /// 统计清单
            /// </summary>
            public const string STATISTIC = "STATISTIC";
            /// <summary>
            /// 医嘱单
            /// </summary>
            public const string ORDERS = "ORDRES";
            /// <summary>
            /// 护理记录单 NUR_RECORD
            /// </summary>
            public const string NUR_RECORD = "NUR_RECORD";

            /// <summary>
            /// 护理交接班 NUR_SHIFT
            /// </summary>
            public const string NUR_SHIFT = "NUR_SHIFT";

            /// <summary>
            /// 护理文档表单 NUR_DOC_FORM
            /// </summary>
            public const string NUR_DOC_FORM = "NUR_DOC_FORM";

            /// <summary>
            /// 护理文档列表 NUR_DOC_LIST
            /// </summary>
            public const string NUR_DOC_LIST = "NUR_DOC_LIST";

            /// <summary>
            /// 体征批量录入 BATCH_RECORD
            /// </summary>
            public const string BATCH_RECORD = "BATCH_RECORD";

            public static string[] GetTypeNames()
            {
                return new string[] {
                    "体温单",
                    "病案首页",
                    "统计清单",
                    "医嘱单"};
            }

            public static string GetTypeName(string typeCode)
            {
                if (typeCode == TEMPERATURE)
                    return "体温单";
                else if (typeCode == PATIENT_INDEX)
                    return "病案首页";
                else if (typeCode == STATISTIC)
                    return "统计清单";
                else if (typeCode == ORDERS)
                    return "医嘱单";
                else if (typeCode == NUR_RECORD)
                    return "护理记录单";
                else if (typeCode == NUR_SHIFT)
                    return "护理交接班";
                else if (typeCode == NUR_DOC_FORM)
                    return "护理文档表单";
                else if (typeCode == NUR_DOC_LIST)
                    return "护理文档列表";
                else if (typeCode == BATCH_RECORD)
                    return "体征批量录入";
                return string.Empty;
            }

            public static string GetTypeCode(string typeName)
            {
                if (typeName == "体温单")
                    return TEMPERATURE;
                else if (typeName == "病案首页")
                    return PATIENT_INDEX;
                else if (typeName == "统计清单")
                    return STATISTIC;
                else if (typeName == "医嘱单")
                    return ORDERS;
                else if (typeName == "护理记录单")
                    return NUR_RECORD;
                else if (typeName == "护理交接班")
                    return NUR_SHIFT;
                else if (typeName == "护理文档表单")
                    return NUR_DOC_FORM;
                else if (typeName == "护理文档列表")
                    return NUR_DOC_LIST;
                else if (typeName == "体征批量录入")
                    return BATCH_RECORD;
                return string.Empty;
            }
        }
    }
}
