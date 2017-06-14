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
    /// 联众病案病人转科情况
    /// </summary>
    public class BAJK13 : DbTypeBase
    {

        /// <summary>
        /// 病人序号
        /// </summary>
        public decimal  KEY1301 { get;set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        public decimal  KEY1302 { get;set; }
        /// <summary>
        /// 转科日期
        /// </summary>
        public DateTime  COL1301 { get;set; }
        /// <summary>
        /// 转入科室代码
        /// </summary>
        public  string COL1302 { get;set; }
        /// <summary>
        /// 转出日期
        /// </summary>
        public  DateTime COL1303 { get;set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
