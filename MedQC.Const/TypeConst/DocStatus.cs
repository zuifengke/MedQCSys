using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    { /// <summary>
      /// 文档状态数据
      /// </summary>
        public struct DocStatus
        {
            /// <summary>
            /// 正常可编辑状态0
            /// </summary>
            public const string NORMAL = "0";
            /// <summary>
            /// 已锁定.正在被别人编辑1
            /// </summary>
            public const string LOCKED = "1";
            /// <summary>
            /// 已作废2
            /// </summary>
            public const string CANCELED = "2";
            /// <summary>
            /// 已归档3
            /// </summary>
            public const string ARCHIVED = "3";

            /// <summary>
            /// "警告：\r\n"
            /// "您可能正在其他机器上修改该病历,修改开始于{0},未正常关闭!\r\n"
            /// "在不同机器上同时修改同一份病历,可能会造成文档覆盖,所以还请您保存前先确认!"
            /// </summary>
            public const string LOCKED_STATUS_DESC1 = "警告：\r\n"
                + "您可能正在其他机器上修改该病历,修改开始于{0},未正常关闭!\r\n"
                + "在不同机器上同时修改同一份病历,可能会造成文档覆盖,所以还请您保存前先确认!";
            /// <summary>
            /// 文档已锁定状态描述
            /// “当前病历正在被{0}修订,修订开始于{1}”
            /// </summary>
            public const string LOCKED_STATUS_DESC2 = "当前病历正在被{0}修订,修订开始于{1}!";
            /// <summary>
            /// "警告：\r\n"
            /// "当前病历被{0}编辑超过24小时,目前已被系统自动解锁允许您编辑,\r\n"
            /// "如果您保存当前病历,那么会使对方无法保存,所以您保存前最好先和对方确认下!"
            /// </summary>
            public const string LOCKED_STATUS_DESC3 = "警告：\r\n"
                + "当前病历被{0}编辑已超过了24小时,目前已被系统自动解锁允许您编辑,\r\n"
                + "如果您保存当前病历,就会使对方无法保存,所以在您保存前最好先和对方确认一下!";
            /// <summary>
            /// 文档已作废状态描述
            /// “当前病历已经被{0}于{1}更新或删除”
            /// </summary>
            public const string CANCELED_STATUS_DESC = "当前病历已经被{0}于{1}更新或删除!";
            /// <summary>
            /// 文档已归档状态描述
            /// “当前病历已经被{0}于{1}归档”
            /// </summary>
            public const string ARCHIVED_STATUS_DESC = "当前病历已经被{0}于{1}归档!";

        }
    }
}
