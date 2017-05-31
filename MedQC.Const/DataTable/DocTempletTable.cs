using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 用户自定义模板数据表字段定义
        /// </summary>
        public struct DocTempletTable
        {
            /// <summary>
            /// 模板ID
            /// </summary>
            public const string TEMPLET_ID = "TEMPLET_ID";
            /// <summary>
            /// 文档类型代码
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            /// <summary>
            /// 模板的描述名，用户自定义录入内容。
            /// </summary>
            public const string TEMPLET_NAME = "TEMPLET_NAME";
            /// <summary>
            /// 共享水平：个人P，科室D,全院H
            /// </summary>
            public const string SHARE_LEVEL = "SHARE_LEVEL";
            /// <summary>
            /// 所属的科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 所属的科室病区
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";
            /// <summary>
            /// 创建者ID
            /// </summary>
            public const string CREATOR_ID = "CREATOR_ID";
            /// <summary>
            /// 创建者名称
            /// </summary>
            public const string CREATOR_NAME = "CREATOR_NAME";
            /// <summary>
            /// 创建时间
            /// </summary>
            public const string CREATE_TIME = "CREATE_TIME";
            /// <summary>
            /// 修改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";
            /// <summary>
            /// 模板的状态: 0废弃的 1当前可用的
            /// </summary>
            public const string IS_VALID = "IS_VALID";
            /// <summary>
            /// 模板文档数据
            /// </summary>
            public const string TEMPLET_DATA = "TEMPLET_DATA";
            /// <summary>
            /// 标识当前模板或者文件夹的父节点ID
            /// </summary>
            public const string PARENT_ID = "PARENT_ID";
            /// <summary>
            /// 标识当前记录是否为文件夹:1文件夹
            /// </summary>
            public const string IS_FOLDER = "IS_FOLDER";
            /// <summary>
            /// 审核状态
            /// </summary>
            public const string CHECK_STATUS = "CHECK_STATUS";
            /// <summary>
            /// 审核人ID
            /// </summary>
            public const string CHECKER_ID = "CHECKER_ID";
            /// <summary>
            /// 审核人姓名
            /// </summary>
            public const string CHECKER_NAME = "CHECKER_NAME";
            /// <summary>
            /// 审核时间
            /// </summary>
            public const string CHECK_TIME = "CHECK_TIME";
            /// <summary>
            /// 审核消息
            /// </summary>
            public const string CHECK_MESSAGE = "CHECK_MESSAGE";
            /// <summary>
            /// 上级审核ID
            /// </summary>
            public const string SUPER_CHECK_ID = "SUPER_CHECKER_ID";
            /// <summary>
            /// 上级审核姓名
            /// </summary>
            public const string SUPER_CHECK_NAME = "SUPER_CHECKER_NAME";
            /// <summary>
            /// 上级审核时间
            /// </summary>
            public const string SUPER_CHECK_TIME = "SUPER_CHECK_TIME";
        }

    }
}
