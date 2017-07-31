using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    public class HolidayKeyValue : DbTypeBase
    {
        /// <summary>
        /// 键名
        /// </summary>
        public string DATA_KEY { get; set; }
        /// <summary>
        /// 键值
        /// </summary>
        public DateTime DATA_VALUE { get; set; }
        /// <summary>
        /// 键值对分组名
        /// </summary>
        public string DATA_GROUP { get; set; }
        /// <summary>
        /// 扩展字段1
        /// </summary>
        public string VALUE1 { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public string ID { get; set; }
        public HolidayKeyValue()
        {
            this.DATA_VALUE = this.DefaultTime;
        }
    }
}
