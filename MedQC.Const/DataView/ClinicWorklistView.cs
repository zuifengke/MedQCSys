using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 临床任务列表视图
        /// </summary>
        public struct ClinicWorklistView
        {
            /// <summary>
            /// ID
            /// </summary>
            public const string WORKLIST_ID = "WORKLIST_ID";
            /// <summary>
            /// 任务类型
            /// </summary>
            public const string WORKLIST_TYPE = "WORKLIST_TYPE";
            /// <summary>
            /// 创建时间
            /// </summary>
            public const string CREATE_TIME = "CREATE_TIME";
            /// <summary>
            /// 创建科室
            /// </summary>
            public const string CREATE_DEPT = "CREATE_DEPT";
            /// <summary>
            /// 创建人员
            /// </summary>
            public const string CREATE_STAFF = "CREATE_STAFF";
            /// <summary>
            /// 任务内容
            /// </summary>
            public const string WORKLIST_CONTENT = "WORKLIST_CONTENT";
            /// <summary>
            /// 目地科室
            /// </summary>
            public const string TARGET_DEPT = "TARGET_DEPT";
            /// <summary>
            /// 目地人员
            /// </summary>
            public const string TARGET_STAFF = "TARGET_STAFF";
            /// <summary>
            /// 处理科室
            /// </summary>
            public const string EXEC_DEPT = "EXEC_DEPT";
            /// <summary>
            /// 处理人员
            /// </summary>
            public const string EXEC_STAFF = "EXEC_STAFF";
            /// <summary>
            /// 处理时间
            /// </summary>
            public const string EXEC_TIME = "EXEC_TIME";
            /// <summary>
            /// 处理标志
            /// </summary>
            public const string EXEC_INDICATOR = "EXEC_INDICATOR";
            /// <summary>
            /// 参数
            /// </summary>
            public const string PARAMETER = "PARAMETER";
        }
    }
}
