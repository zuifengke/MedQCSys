using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 临床任务列表
    /// </summary>
    public class ClinicWorklist : DbTypeBase
    {
        /// <summary>
        /// ID
        /// </summary>
        public string WORKLIST_ID { get; set; }

        /// <summary>
        /// 任务类型
        /// </summary>
        public string WORKLIST_TYPE { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_TIME { get; set; }

        /// <summary>
        /// 创建科室
        /// </summary>
        public string CREATE_DEPT { get; set; }

        /// <summary>
        /// 创建人员
        /// </summary>
        public string CREATE_STAFF { get; set; }

        /// <summary>
        /// 任务内容
        /// </summary>
        public string WORKLIST_CONTENT { get; set; }

        /// <summary>
        /// 目地科室
        /// </summary>
        public string TARGET_DEPT { get; set; }

        /// <summary>
        /// 目地人员
        /// </summary>
        public string TARGET_STAFF { get; set; }

        /// <summary>
        /// 处理科室
        /// </summary>
        public string EXEC_DEPT { get; set; }

        /// <summary>
        /// 处理人员
        /// </summary>
        public string EXEC_STAFF { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime EXEC_TIME { get; set; }

        /// <summary>
        /// 处理标志
        /// </summary>
        public decimal EXEC_INDICATOR { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public string PARAMETER { get; set; }
        public ClinicWorklist()
        {
            this.EXEC_TIME = base.DefaultTime;
            this.CREATE_TIME = this.DefaultTime;
        }
    }
}
