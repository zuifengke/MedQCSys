using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;

namespace EMRDBLib
{
    /// <summary>
    /// 键值对表
    /// </summary>
    public class KeyValueData : DbTypeBase
    {
        /// <summary>
        /// 键名
        /// </summary>
        public string DATA_KEY = "DATA_KEY";
        /// <summary>
        /// 键值
        /// </summary>
        public string DATA_VALUE = "DATA_VALUE";
        /// <summary>
        /// 键值对分组名
        /// </summary>
        public string DATA_GROUP = "DATA_GROUP";
        /// <summary>
        /// 扩展字段1
        /// </summary>
        public string VALUE1 = "VALUE1";
        /// <summary>
        /// 主键
        /// </summary>
        public string ID = "ID";

        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
