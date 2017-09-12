using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 规则计算脚本配置
    /// </summary>
    public class ScriptConfig : DbTypeBase
    {
        /// <summary>
        /// 脚本ID
        /// </summary>
        public string SCRIPT_ID { get; set; }
        /// <summary>
        /// 语言类型
        /// </summary>
        public string SCRIPT_LANG { get; set; }
        /// <summary>
        /// 功能描述
        /// </summary>
        public string SCRIPT_NAME { get; set; }
        /// <summary>
        /// 脚本引用的外部程序集
        /// </summary>
        public string SCRIPT_USING { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public string CREATOR_ID { get; set; }
        /// <summary>
        /// 创建者名称
        /// </summary>
        public string CREATOR_NAME { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_TIME { get; set; }
        /// <summary>
        /// 修改者ID
        /// </summary>
        public string MODIFIER_ID { get; set; }
        /// <summary>
        /// 修改者名称
        /// </summary>
        public string MODIFIER_NAME { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime MODIFY_TIME { get; set; }
        /// <summary>
        /// 脚本源码
        /// </summary>
        public byte[] SCRIPT_SOURCE { get; set; }
        /// <summary>
        /// 上级节点
        /// </summary>
        public string PARENT_ID { get; set; }
        /// <summary>
        /// 顺序号
        /// </summary>
        public int SCRIPT_NO { get; set; }
        /// <summary>
        /// 是否是文件夹 
        /// </summary>
        public decimal IS_FOLDER { get; set; }
        public byte[] ScriptData { get; set; }
        public ScriptConfig()
        {
            this.MODIFY_TIME = this.DefaultTime;
        }
        public string MakeScriptID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
