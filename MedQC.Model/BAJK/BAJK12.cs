/***************************************************
 * 联众病案接口实体类
 * 作者：yehui
 * 时间：2017-06-05
 **************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.BAJK
{
    /// <summary>
    /// 联众病案接口过敏药物情况
    /// </summary>
    public class BAJK12 : DbTypeBase
    {
        /// <summary>
        /// 病人序号
        /// </summary>
        public decimal KEY1201 { get; set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        public decimal KEY1202 { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
