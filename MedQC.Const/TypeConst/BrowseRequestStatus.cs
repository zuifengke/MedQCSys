using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病历浏览申请状态
        /// </summary>
        public struct BrowseRequestStatus
        {
            /// <summary>
            /// 已提交
            /// </summary>
            public const decimal Commited = 0;
            /// <summary>
            /// 审批通过
            /// </summary>
            public const decimal Approval = 1;
            /// <summary>
            /// 审批不通过
            /// </summary>
            public const decimal Reject = 2;

            public static string GetStatusName(decimal szCode)
            {
                string szName = string.Empty;
                switch (szCode)
                {
                    case BrowseRequestStatus.Approval:
                        szName = "审批通过";
                        break;
                    case BrowseRequestStatus.Reject:
                        szName = "审批不通过";
                        break;
                    case BrowseRequestStatus.Commited:
                        szName = "已提交";
                        break;
                    default:
                        szName = "未知";
                        break;
                }
                return szName;
            }
            public static decimal GetMrStatusCode(string szName)
            {
                decimal szCode=0;
                switch (szName)
                {
                    case "审批通过":
                        szCode = BrowseRequestStatus.Approval;
                        break;
                    case "审批不通过":
                        szCode = BrowseRequestStatus.Reject;
                        break;
                    case "已提交":
                        szCode = BrowseRequestStatus.Commited;
                        break;
                    default:
                        break;
                }
                return szCode;
            }
        }
    }
}
