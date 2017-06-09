/***************************************************
 * 和仁HIS患者首页实体类
 * 作者：yehui
 * 时间：2017-06-05
 **************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.HerenHis
{
    public class BaseCodeDict : DbTypeBase
    {
        /// <summary>
        /// 编码类型标识号
        /// </summary>
        public string CODETYPE_ID { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public  string CODE_ID { get; set; }
        /// <summary>
        /// 编码类型名称
        /// </summary>
        public  string CODETYPE_NAME { get; set; }
        /// <summary>
        /// 编码名称
        /// </summary>
        public  string CODE_NAME { get; set; }
        /// <summary>
        /// 输入码
        /// </summary>
        public  string INPUT_CODE { get; set; }
        public override string ToString()
        {
            return this.CODE_NAME;
        }
    }
}
