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
    /// 联众病案接口手术情况
    /// </summary>
    public class BAJK11 : DbTypeBase
    {  /// <summary>
       /// 病人序号
       /// </summary>
        public decimal KEY1101 { get; set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        public decimal KEY1102 { get; set; }
        /// <summary>
        /// 手术日期
        /// </summary>
        public DateTime COL1101 { get; set; }
        /// <summary>
        /// 术前住院天数
        /// </summary>
        public decimal COL1102 { get; set; }
        /// <summary>
        /// 麻醉序号
        /// </summary>
        public decimal COL1104 { get; set; }
        /// <summary>
        /// 切口等级0.0类切口; 1.Ⅰ类切口; 2.Ⅱ类切口;3. Ⅲ类切口
        /// </summary>
        public decimal COL1105 { get; set; }
        /// <summary>
        /// 愈合类别1.甲;2.乙; 3.丙; 4.其他
        /// </summary>
        public decimal COL1106 { get; set; }
        /// <summary>
        /// 手术医生编号
        /// </summary>
        public string COL1107 { get; set; }
        /// <summary>
        /// 手术I助
        /// </summary>
        public string COL1108 { get; set; }
        /// <summary>
        /// 手术II助
        /// </summary>
        public string COL1109 { get; set; }
        /// <summary>
        /// 麻醉医生
        /// </summary>
        public string COL1110 { get; set; }
        /// <summary>
        /// 符合标志0.不符合1.符合2.不确定
        /// </summary>
        public decimal COL1111 { get; set; }
        /// <summary>
        /// 手术组号
        /// </summary>
        public decimal COL1112 { get; set; }
        /// <summary>
        /// 手术诊断全称
        /// </summary>
        public string COL1113 { get; set; }
        /// <summary>
        /// 手术前诊断名称
        /// </summary>
        public string COL1114 { get; set; }
        /// <summary>
        /// 手术后诊断名称
        /// </summary>
        public string COL1115 { get; set; }
        /// <summary>
        /// 手术级别 新增加:1.一级手术; 2.二级手术; 3.三级手术; 4.四级手术
        /// </summary>
        public decimal COL1116 { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
