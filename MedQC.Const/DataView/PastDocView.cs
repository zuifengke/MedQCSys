using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 以往病历信息数据视图字段定义
        /// </summary>
        public struct PastDocView
        {
            /// <summary>
            /// 文档的唯一标识
            /// </summary>
            public const string DOC_ID = "DOC_ID";
            /// <summary>
            /// 文档的类型
            /// </summary>
            public const string DOC_TYPE = "DOC_TYPE";
            /// <summary>
            /// 文档的显示标题
            /// </summary>
            public const string DOC_TITLE = "DOC_TITLE";

            /// <summary>
            /// 文档作者ID
            /// </summary>
            public const string CREATOR_ID = "CREATOR_ID";
            /// <summary>
            /// 文档作者姓名
            /// </summary>
            public const string CREATOR_NAME = "CREATOR_NAME";
            /// <summary>
            /// 文档生成的时间
            /// </summary>
            public const string CREATE_TIME = "DOC_TIME";
            /// <summary>
            /// 文档修改者ID
            /// </summary>
            public const string MODIFIER_ID = "MODIFIER_ID";
            /// <summary>
            /// 文档修改者姓名
            /// </summary>
            public const string MODIFIER_NAME = "MODIFIER_NAME";
            /// <summary>
            /// 文档修改时间
            /// </summary>
            public const string MODIFY_TIME = "MODIFY_TIME";

            /// <summary>
            /// 文档所属的病人号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 文档所属病人姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";

            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊时间
            /// </summary>
            public const string VISIT_TIME = "VISIT_TIME";
            /// <summary>
            /// 就诊类型
            /// </summary>
            public const string VISIT_TYPE = "VISIT_TYPE";

            /// <summary>
            /// 科室代码
            /// </summary>
            public const string DEPT_CODE = "DEPT_CODE";
            /// <summary>
            /// 科室名称
            /// </summary>
            public const string DEPT_NAME = "DEPT_NAME";

            /// <summary>
            /// 文档次序编号
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
            /// <summary>
            /// 是否需要合并
            /// </summary>
            public const string NEED_COMBIN = "NEED_COMBIN";
            /// <summary>
            /// 病历文件类型
            /// </summary>
            public const string FILE_TYPE = "FILE_TYPE";
            /// <summary>
            /// 病历文件名
            /// </summary>
            public const string FILE_NAME = "FILE_NAME";
            /// <summary>
            /// 病历文件路径
            /// </summary>
            public const string FILE_PATH = "FILE_PATH";
            /// <summary>
            /// 病历文档数据
            /// </summary>
            public const string FILE_DATA = "FILE_DATA";
        }
    }
}
