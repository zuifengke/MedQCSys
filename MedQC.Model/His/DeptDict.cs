using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 新系统科室字典
    /// </summary>
    public class DeptDict : DbTypeBase
    {
        /// <summary>
        /// 此序号反映了科室的排列顺序
        /// </summary>
        public string SERIAL_NO { get; set; }
        /// <summary>
        /// 医嘱号
        /// </summary>
        public string DEPT_CODE { get; set; }
        /// <summary>
        /// 科室的正式名称
        /// </summary>
        public string DEPT_NAME { get; set; }
        /// <summary>
        /// 科室别名
        /// </summary>
        public string DEPT_ALIAS{ get; set; }
        /// <summary>
        /// 临床科室属性0-临床1-辅诊2-护理单元3-机关9-其他
        /// </summary>
        public string CLINIC_ATTR { get; set; }
    }
}
