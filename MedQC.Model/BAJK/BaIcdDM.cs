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
    public class BaIcdDM : DbTypeBase
    {
        /// <summary>
        /// 疾病序号    
        /// </summary>
        public decimal JBXH { get; set; }
        /// <summary>
        /// 疾病名称
        /// </summary>
        public string JBMC { get; set; }
        /// <summary>
        /// ICD9码
        /// </summary>
        public string ICD9 { get; set; }
        /// <summary>
        /// ICD10码
        /// </summary>
        public string ICD10 { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
