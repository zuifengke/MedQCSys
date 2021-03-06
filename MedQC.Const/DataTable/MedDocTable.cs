﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 文档索引信息数据表字段定义
        /// </summary>
        public struct EmrDocTable
        {
            /// <summary>
            /// 所用的模版ID号
            /// </summary>
            public const string TEMPLET_ID = "TEMPLET_ID";
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
            /// 文档生成的时间
            /// </summary>
            public const string DOC_TIME = "DOC_TIME";
            /// <summary>
            /// 文档集编号
            /// </summary>
            public const string DOC_SETID = "DOC_SETID";
            /// <summary>
            /// 文档版本
            /// </summary>
            public const string DOC_VERSION = "DOC_VERSION";
            /// <summary>
            /// 文档法定作者的标号
            /// </summary>
            public const string CREATOR_ID = "CREATOR_ID";
            /// <summary>
            /// 文档法定作者姓名
            /// </summary>
            public const string CREATOR_NAME = "CREATOR_NAME";
            /// <summary>
            /// 文档修改者的标号
            /// </summary>
            public const string MODIFIER_ID = "MODIFIER_ID";
            /// <summary>
            /// 文档修改者的标号
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
            /// 签名代码
            /// </summary>
            public const string SIGN_CODE = "SIGN_CODE";
            /// <summary>
            /// 隐私等级代码
            /// </summary>
            public const string CONFID_CODE = "CONFID_CODE";
            /// <summary>
            /// 文档次序编号
            /// </summary>
            public const string ORDER_VALUE = "ORDER_VALUE";
            /// <summary>
            /// 病历医生记录的时间
            /// </summary>
            public const string RECORD_TIME = "RECORD_TIME";
            /// <summary>
            /// 文档数据
            /// </summary>
            public const string DOC_DATA = "DOC_DATA";
            /// <summary>
            /// 编辑器内部控件类型
            /// </summary>
            public const string EMR_TYPE = "EMR_TYPE";
           
           
        }
    }
}
