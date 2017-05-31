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
        public struct PaperState
        {
            public const string CnUnReceive = "未接收";
            public const string CnReceive = "已接收";
            public const int UnReceive = 0;
            public const int Receive = 1;
            public static string GetCnPaperState(int nPaperState)
            {
                string szMsgState = string.Empty;
                switch (nPaperState)
                {
                    case PaperState.UnReceive:
                        szMsgState = PaperState.CnUnReceive;
                        break;
                    case PaperState.Receive:
                        szMsgState = PaperState.CnReceive;
                        break;
                    default:
                        break;
                }
                return szMsgState;
            }
            public static int GetPaperState(string szState)
            {
                int nMsgStateCode =0;
                switch (szState)
                {
                    case PaperState.CnReceive:
                        nMsgStateCode =PaperState.Receive;
                        break;
                    case PaperState.CnUnReceive:
                        nMsgStateCode = PaperState.UnReceive;
                        break;
                    default:
                        break;
                }
                return nMsgStateCode;
            }
        }
    }
}
