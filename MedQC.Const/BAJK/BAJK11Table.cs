
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病人手术情况
        /// </summary>
        public struct BAJK11Table
        {
            /// <summary>
            /// 病人序号
            /// </summary>
            public const string KEY1101 = "KEY1101";
            /// <summary>
            /// 顺序号
            /// </summary>
            public const string KEY1102 = "KEY1102";
            /// <summary>
            /// 手术日期
            /// </summary>
            public const string COL1101 = "COL1101";
            /// <summary>
            /// 术前住院天数
            /// </summary>
            public const string COL1102 = "COL1102";
            /// <summary>
            /// 麻醉序号
            /// </summary>
            public const string COL1104 = "COL1104";
            /// <summary>
            /// 切口等级0.0类切口; 1.Ⅰ类切口; 2.Ⅱ类切口;3. Ⅲ类切口
            /// </summary>
            public const string COL1105 = "COL1105";
            /// <summary>
            /// 愈合类别1.甲;2.乙; 3.丙; 4.其他
            /// </summary>
            public const string COL1106 = "COL1106";
            /// <summary>
            /// 手术医生编号
            /// </summary>
            public const string COL1107 = "COL1107";
            /// <summary>
            /// 手术I助
            /// </summary>
            public const string COL1108 = "COL1108";
            /// <summary>
            /// 手术II助
            /// </summary>
            public const string COL1109 = "COL1109";
            /// <summary>
            /// 麻醉医生
            /// </summary>
            public const string COL1110 = "COL1110";
            /// <summary>
            /// 符合标志0.不符合1.符合2.不确定
            /// </summary>
            public const string COL1111 = "COL1111";
            /// <summary>
            /// 手术组号
            /// </summary>
            public const string COL1112 = "COL1112";
            /// <summary>
            /// 手术诊断全称
            /// </summary>
            public const string COL1113 = "COL1113";
            /// <summary>
            /// 手术前诊断名称
            /// </summary>
            public const string COL1114 = "COL1114";
            /// <summary>
            /// 手术后诊断名称
            /// </summary>
            public const string COL1115 = "COL1115";
            /// <summary>
            /// 手术级别 新增加:1.一级手术; 2.二级手术; 3.三级手术; 4.四级手术
            /// </summary>
            public const string COL1116 = "COL1116";
        }
    }
}
