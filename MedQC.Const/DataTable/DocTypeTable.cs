using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 文档类型数据表字段定义
        /// </summary>
        public struct DocTypeTable
        {
            /// <summary>
            /// 文档类型代码
            /// </summary>
            public const string DOCTYPE_ID = "DOCTYPE_ID";
            /// <summary>
            /// 文档类型名
            /// </summary>
            public const string DOCTYPE_NAME = "DOCTYPE_NAME";
            /// <summary>
            /// 文档类型对应的主文档类型
            /// </summary>
            public const string HOSTTYPE_ID = "HOSTTYPE_ID";
            /// <summary>
            /// 排序值
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
            /// <summary>
            /// 文档是否可重复
            /// </summary>
            public const string IS_REPEATED = "IS_REPEATED";
            /// <summary>
            /// DOC 表示医生 NUR 表示护士 CIS表示其它应用系统 ADM 管理人员等
            /// </summary>
            public const string DOC_RIGHT = "DOC_RIGHT";
            /// <summary>
            /// 应用环境(IP住院 OP门诊)
            /// </summary>
            public const string APPLY_ENV = "APPLY_ENV";
            /// <summary>
            /// 标识当前是否有效
            /// </summary>
            public const string IS_VALID = "IS_VALID";
            /// <summary>
            /// 标识当前是否能创建
            /// </summary>
            public const string CAN_CREATE = "CAN_CREATE";
            /// <summary>
            /// 是否独立纸张打印
            /// </summary>
            public const string IS_TOTAL_PAGE = "IS_TOTAL_PAGE";
            /// <summary>
            /// 标识当前病历类型创建的文档打印时末页是否允许接着打印其他病历
            /// </summary>
            public const string IS_END_EMPTY = "IS_END_EMPTY";
            /// <summary>
            /// 表示文档的签名方式
            /// </summary>
            public const string SIGN_FLAG = "SIGN_FLAG";
            /// <summary>
            /// 文档类型的修改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";
            /// <summary>
            /// 是否允许保存结构化数据
            /// </summary>
            public const string IS_STRUCT = "IS_STRUCT";
            /// <summary>
            /// 文档模板数据
            /// </summary>
            public const string TEMPLET_DATA = "TEMPLET_DATA";
            /// <summary>
            /// 是否自动重新生成病历标题
            /// </summary>
            public const string AUTO_MAKE_TITLE = "AUTO_MAKE_TITLE";
            /// <summary>
            /// 是否需要自动合并显示
            /// </summary>
            public const string NEED_COMBIN = "NEED_COMBIN";
        }
    }
}
