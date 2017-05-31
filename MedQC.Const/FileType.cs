using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 文件扩展名常量
        /// </summary>
        public struct FileType
        {
            /// <summary>
            /// 医疗文档扩展名"smdf"
            /// </summary>
            public const string MED_DOCUMENT = "smdf";
            /// <summary>
            /// 文档模板文件扩展名"smdt"
            /// </summary>
            public const string DOC_TEMPLET = "smdt";
            /// <summary>
            /// XDB病历文档扩展名"xml"
            /// </summary>
            public const string XML_DOCUMENT = "xml";
            /// <summary>
            /// HTML病历文档扩展名"html"
            /// </summary>
            public const string HTML_DOCUMENT = "html";
            /// <summary>
            /// PDF病历文档扩展名"pdf"
            /// </summary>
            public const string PDF_DOCUMENT = "pdf";
            /// <summary>
            /// 表单
            /// </summary>
            public const string TEMPLET = "DocTemplet";

            /// <summary>
            /// 护理文书打印报表模版
            /// </summary>
            public const string REPORT = "Report";
        }
    }
}
