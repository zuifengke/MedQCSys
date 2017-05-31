using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 质控时效结果统计到科室
        /// </summary>
        public struct QcTimeRecordStatByDeptTable
        {
            /// <summary>
            /// 检查时间
            /// </summary>
            public const string CHECK_DATE = "CHECK_DATE";
            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 专家姓名
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 文档标题
            /// </summary>
            public const string DOC_TITLE = "DOC_TITLE";
            /// <summary>
            /// 正常书写数量
            /// </summary>
            public const string NORMAL = "NORMAL";
            /// <summary>
            /// 未书写数量
            /// </summary>
            public const string UNWRITE = "UNWRITE";
            /// <summary>
            /// 书写超时
            /// </summary>
            public const string TIMEOUT = "TIMEOUT";
            /// <summary>
            /// 正常未书写
            /// </summary>
            public const string UNWRITE_NORMAL = "UNWRITE_NORMAL";
            /// <summary>
            /// 提前书写数量
            /// </summary>
            public const string EARLY = "EARLY";
            /// <summary>
            /// 全科应写该病历总数
            /// </summary>
            public const string NEEDCOUNT = "NEED_COUNT";
            /// <summary>
            /// 未完成病历涉及的患者数
            /// </summary>
            public const string UNDOPATIENTCOUNT = "UNDO_PATIENT_COUNT";
            /// <summary>
            /// 科室当前在院人数
            /// </summary>
            public const string DEPTPATIENTCOUNT = "DEPT_PATIENT_COUNT";

        }
    }
}
