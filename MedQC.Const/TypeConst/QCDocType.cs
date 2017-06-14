using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 添加质检问题时的病历类型
        /// </summary>
        public struct QCDocType
        {
            /// <summary>
            /// 在院病历
            /// </summary>
            public const int INHOSPITAL = 0;
            /// <summary>
            /// 出院病历
            /// </summary>
            public const int OUTHOSPITAL = 1;
            /// <summary>
            /// 死亡病历
            /// </summary>
            public const int DEATH = 2;
          
            public const string CN_INHOSPITAL = "在院病历";
          
            public const string CN_OUTHOSPITAL = "出院病历";
        
            public const string CN_DEATH = "死亡病历";

            public static string GetDesc(int nType)
            {
                if (nType==QCDocType.INHOSPITAL)
                    return QCDocType.CN_INHOSPITAL;
                else if (nType == QCDocType.OUTHOSPITAL)
                    return QCDocType.CN_OUTHOSPITAL;
                else if (nType ==QCDocType.DEATH)
                    return QCDocType.CN_DEATH;
                else
                    return string.Empty;
            }
        }
    }
}
