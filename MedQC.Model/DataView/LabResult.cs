using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public class LabResult : DbTypeBase
    {
        /// <summary>
        /// 申请序号
        /// </summary>
        public string TEST_ID { get; set; }
        /// <summary>
        /// 检验报告项目名称
        /// </summary>
        public  int ITEM_NO { get; set; }
        /// <summary>
        /// 检验报告项目名称
        /// </summary>
        public  string ITEM_NAME { get; set; }
        /// <summary>
        /// 检验结果值
        /// </summary>
        public  string ITEM_RESULT { get; set; }
        /// <summary>
        /// 检验结果单位
        /// </summary>
        public  string ITEM_UNITS { get; set; }
        /// <summary>
        /// 检验结果参考值
        /// </summary>
        public  string ITEM_REFER { get; set; }
        /// <summary>
        /// 结果正常标志
        /// </summary>
        public  string ABNORMAL_INDICATOR { get; set; }
        public LabResult()
        {
            this.ABNORMAL_INDICATOR = string.Empty;

        }
    }
}
