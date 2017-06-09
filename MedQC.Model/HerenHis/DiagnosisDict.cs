
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    public class DiagnosisDict : DbTypeBase
    {
        /// <summary>
        /// 诊断代码
        /// </summary>
        public string DIAGNOSIS_CODE { get; set; }
        /// <summary>
        /// 诊断名称
        /// </summary>
        public string DIAGNOSIS_NAME { get; set; }
        /// <summary>
        /// 正名标志
        /// </summary>
        public decimal STD_INDICATOR { get; set; }
        /// <summary>
        /// 标准化标志
        /// </summary>
        public decimal APPROVED_INDICATOR { get; set; }
        /// <summary>
        /// 编码体系
        /// </summary>
        public string CODE_VERSION { get; set; }
        /// <summary>
        /// 健康水平
        /// </summary>
        public string HEALTH_LEVEL { get; set; }
        /// <summary>
        /// 感染标志
        /// </summary>
        public string INFECT_INDICATOR { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CREATE_DATE { get; set; }
        /// <summary>
        /// 拼音输入码
        /// </summary>
        public string INPUT_CODE { get; set; }
        /// <summary>
        /// 五笔输入码
        /// </summary>
        public string INPUT_CODE_WB { get; set; }
        /// <summary>
        /// 数字输入码
        /// </summary>
        public string INPUT_CODE_NO { get; set; }
    }
}
