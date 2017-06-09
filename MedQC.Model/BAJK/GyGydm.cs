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
    public class GyGydm : DbTypeBase
    {
        /// <summary>
        /// 代码类别
        /// </summary>
        public string DMLB { get; set; }
        /// <summary>
        /// 代码
        /// </summary>
        public  string DM { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public  string MC { get; set; }
        public override string ToString()
        {
            return this.MC;
        }
    }
}
