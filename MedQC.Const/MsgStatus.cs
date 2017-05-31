using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 问题状态
        /// </summary>
        public struct MsgStatus
        {
            public const string CnUnCheck = "未接收";
            public const string CnChecked = "已确认";
            public const string CnModified = "已修改";
            public const string CnPass = "合格";

            public const int UnCheck = 0;
            public const int Checked = 1;
            public const int Modified = 2;
            public const int Pass = 3;

            public static string GetCnMsgState(int szStateCode)
            {
                string szMsgState = string.Empty;
                switch (szStateCode)
                {
                    case MsgStatus.UnCheck:
                        szMsgState = MsgStatus.CnUnCheck;
                        break;
                    case MsgStatus.Checked:
                        szMsgState = MsgStatus.CnChecked;
                        break;

                    case MsgStatus.Modified:
                        szMsgState = MsgStatus.CnModified;
                        break;

                    case MsgStatus.Pass:
                        szMsgState = MsgStatus.CnPass;
                        break;

                    default:
                        break;
                }
                return szMsgState;
            }
            public static int GetMsgStateCode(string szState)
            {
                int szMsgStateCode =0;
                switch (szState)
                {
                    case MsgStatus.CnChecked:
                        szMsgStateCode = MsgStatus.Checked;
                        break;

                    case MsgStatus.CnUnCheck:
                        szMsgStateCode = MsgStatus.UnCheck;
                        break;

                    case MsgStatus.CnModified:
                        szMsgStateCode = MsgStatus.Modified;
                        break;

                    case MsgStatus.CnPass:
                        szMsgStateCode = MsgStatus.Pass;
                        break;

                    default:
                        break;
                }
                return szMsgStateCode;
            }
        }
    }
}
