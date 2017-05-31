using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 手术是否需要隔离，0：正常1：隔离2：放射
        /// </summary>
        public struct IsolationFlag
        {

            public static string GetCnIsoLationFlag(string szStateCode)
            {
                string result = string.Empty;
                switch (szStateCode)
                {
                    case "0":
                        result = "正常";
                        break;
                    case "1":
                        result = "隔离";
                        break;
                    case "2":
                        result = "放射";
                        break;
                    default:
                        break;
                }
                return result;
            }
        
        }
    }
}
