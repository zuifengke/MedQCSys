using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    public class QcAdminDepts : DbTypeBase
    {
        /// <summary>
        /// 用户账号
        /// </summary>
        public string USER_ID { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public  string USER_NAME { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public  string DEPT_CODE { get; set; }
        /// <summary>
        /// 科室名称
        /// </summary>
        public  string DEPT_NAME { get; set; }

        public QcAdminDepts()
        {
           
        }
    }


}
