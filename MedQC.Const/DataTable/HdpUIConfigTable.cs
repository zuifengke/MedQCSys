using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {

        /// <summary>
        /// 界面元件管理数据表字段定义
        /// </summary>
        public struct HdpUIConfigTable
        {
            /// <summary>
            /// 编号
            /// </summary>
            public const string UI_CONFIG_ID = "UICONFIG_ID";
            /// <summary>
            /// 显示名称
            /// </summary>
            public const string SHOW_NAME = "SHOW_NAME";
            /// <summary>
            /// 属于产品
            /// </summary>
            public const string PRODUCT = "PRODUCT";
            /// <summary>
            /// 快捷键
            /// </summary>
            public const string SHORTCUTS = "SHORTCUTS";
            /// <summary>
            /// 显示方式（图片+文字/图片/文字）
            /// </summary>
            public const string SHOW_TYPE = "SHOW_TYPE";
            /// <summary>
            /// 元件图标
            /// </summary>
            public const string UI_ICON = "UI_ICON";
            /// <summary>
            /// 图标大小
            /// </summary>
            public const string UI_ICON_SIZE = "UI_ICON_SIZE";
            /// <summary>
            /// 元件关联的权限点
            /// </summary>
            public const string UI_RIGHT_KEY = "UI_RIGHT_KEY";
            /// <summary>
            /// 元件关联的权限点说明
            /// </summary>
            public const string UI_RIGHT_DESC = "UI_RIGHT_DESC";
            /// <summary>
            /// 元件关联的命令
            /// </summary>
            public const string UI_COMMAND = "UI_COMMAND";
            /// <summary>
            /// 微帮助
            /// </summary>
            public const string MICRO_HELP = "MICRO_HELP";
            /// <summary>
            /// 元件类型（菜单、工具栏、右键菜单）
            /// </summary>
            public const string UI_TYPE = "UI_TYPE";
            /// <summary>
            /// 父级ID号
            /// </summary>
            public const string PARENT_ID = "PARENT_ID";
            /// <summary>
            /// 排序
            /// </summary>
            public const string SORT_INDEX = "SORT_INDEX";
            /// <summary>
            /// 菜单级别
            /// </summary>
            public const string UI_GRADE = "UI_GRADE";
            /// <summary>
            /// 右键菜单所属资源
            /// </summary>
            public const string POPMENU_RESOURCE = "POPMENU_RESOURCE";

        }
    }
}
