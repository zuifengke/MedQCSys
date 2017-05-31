using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        public struct UIDisplayStyle
        {

            public const string TEXT = "文字";

            public const string TEXT_IMAGE = "文字+图片";

            public const string IMAGE = "图片";

            /// <summary>
            /// 工具栏
            /// </summary>
            public const string TOOL = "TOOL";
            public static ToolStripItemDisplayStyle GetDisplayStyle(string szShowType)
            {
                ToolStripItemDisplayStyle style;
                switch (szShowType)
                {
                    case UIDisplayStyle.TEXT:
                        style = ToolStripItemDisplayStyle.Text;
                        break;
                    case UIDisplayStyle.TEXT_IMAGE:
                        style = ToolStripItemDisplayStyle.ImageAndText;
                        break;
                    case UIDisplayStyle.IMAGE:
                        style = ToolStripItemDisplayStyle.Image;
                        break;
                    default:
                        style = ToolStripItemDisplayStyle.Text;
                        break;
                }
                return style;
            }
        }
    }
}
