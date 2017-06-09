using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;

namespace EMRDBLib
{
    public class RecCodeCompasion : DbTypeBase
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 联众代码类别
        /// </summary>
        public  string DMLB { get; set; }
        /// <summary>
        /// 联众字典代码
        /// </summary>
        public  string DM { get; set; }
        /// <summary>
        /// 联众字典名称
        /// </summary>
        public  string MC { get; set; }
        /// <summary>
        /// 和仁字典代码
        /// </summary>
        public  string CODE_ID { get; set; }
        /// <summary>
        /// 和仁字典名称
        /// </summary>
        public  string CODE_NAME { get; set; }
        /// <summary>
        /// 和仁代码类别
        /// </summary>
        public string CODETYPE_NAME { get; set; }
        /// <summary>
        /// 是否为配置类别 0 否 1是
        /// </summary>
        public  decimal IS_CONFIG { get; set; }
        /// <summary>
        /// 查询来源代码sql配置
        /// </summary>
        public  string FORM_SQL { get; set; }
        /// <summary>
        /// 查询目标代码sql配置
        /// </summary>
        public  string TO_SQL { get; set; }
        /// <summary>
        /// 字典类别名称
        /// </summary>
        public  string CONFIG_NAME { get; set; }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }

        public override string ToString()
        {
            return this.CONFIG_NAME.ToString();
        }
    }
}
