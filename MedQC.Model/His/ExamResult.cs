using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public class ExamResult : DbTypeBase
    {
        /// <summary>
        /// 申请序号
        /// </summary>
        public  string EXAM_ID { get; set; }
        /// <summary>
        /// 检查参数
        /// </summary>
        public  string PARAMETERS { get; set; }
        /// <summary>
        /// 检查所见
        /// </summary>
        public  string DESCRIPTION { get; set; }
        /// <summary>
        /// 检查印象
        /// </summary>
        public  string IMPRESSION { get; set; }
        /// <summary>
        /// 检查建议
        /// </summary>
        public  string RECOMMENDATION { get; set; }
        /// <summary>
        /// 是否阳性
        /// </summary>
        public  string IS_ABNORMAL { get; set; }
        /// <summary>
        /// 使用仪器
        /// </summary>
        public  string DEVICE { get; set; }
        /// <summary>
        /// 报告中图象编号
        /// </summary>
        public string USE_IMAGE { get; set; }
        public ExamResult()
        {

        }
    }
}
