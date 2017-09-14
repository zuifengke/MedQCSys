using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病案上传状态
        /// </summary>
        public struct UploadStatus
        {
            public const string CnNot = "未上传";
            public const string CnYes = "已上传";

            public const int Not = 0;
            public const int Yes = 1;

            public static string GetCnUploadState(int szStateCode)
            {
                string szMsgState = string.Empty;
                switch (szStateCode)
                {
                    case UploadStatus.Not:
                        szMsgState = UploadStatus.CnNot;
                        break;
                    case UploadStatus.Yes:
                        szMsgState = UploadStatus.CnYes;
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
                    case UploadStatus.CnNot:
                        szMsgStateCode = UploadStatus.Not;
                        break;

                    case UploadStatus.CnYes:
                        szMsgStateCode = UploadStatus.Yes;
                        break;
                    default:
                        break;
                }
                return szMsgStateCode;
            }
        }
    }
}
