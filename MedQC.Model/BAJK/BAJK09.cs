/***************************************************
 * 联众病案接口公用代码实体类
 * 作者：yehui
 * 时间：2017-06-05
 **************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.BAJK
{
    public class BAJK09 : DbTypeBase
    {  /// <summary>
       /// 病人序号
       /// </summary>
        public decimal KEY0901 { get; set; }
        /// <summary>
        /// 诊断类别
        /// </summary>
        public decimal KEY0902 { get; set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        public decimal KEY0903 { get; set; }
        /// <summary>
        /// 疾病序号
        /// </summary>
        public decimal COL0901 { get; set; }
        /// <summary>
        /// 转归情况
        /// </summary>
        public decimal COL0902 { get; set; }
        /// <summary>
        /// 诊断全称
        /// </summary>
        public string COL0903 { get; set; }
        /// <summary>
        /// 入院病情
        /// </summary>
        public decimal COL0904 { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
