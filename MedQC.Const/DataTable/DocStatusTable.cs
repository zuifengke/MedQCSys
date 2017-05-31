using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 文档状态数据表字段定义
        /// </summary>
        public struct DocStatusTable
        {
            /// <summary>
            /// 文档唯一标识
            /// </summary>
            public const string DOC_ID = "DOC_ID";
            /// <summary>
            /// 文档的状态(编辑中，已作废，可编辑，已归档)
            /// </summary>
            public const string DOC_STATUS = "DOC_STATUS";
            /// <summary>
            /// 操作者ID
            /// </summary>
            public const string OPERATOR_ID = "OPERATOR_ID";
            /// <summary>
            /// 操作者姓名
            /// </summary>
            public const string OPERATOR_NAME = "OPERATOR_NAME";
            /// <summary>
            /// 操作时间
            /// </summary>
            public const string OPERATE_TIME = "OPERATE_TIME";
            /// <summary>
            /// 状态描述
            /// </summary>
            public const string STATUS_DESC = "STATUS_DESC";
        }
    }
}
