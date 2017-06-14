using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 返回值常量
        /// </summary>
        public struct ReturnValue
        {
            /// <summary>
            /// 正常(0)
            /// </summary>
            public const short OK = 0;
            /// <summary>
            /// 参数错误(1)
            /// </summary>
            public const short PARAM_ERROR = 1;
            /// <summary>
            /// 取消
            /// </summary>
            public const short CANCEL = 2;
            /// <summary>
            /// 接口内部异常(3)
            /// </summary>
            public const short EXCEPTION = 3;
            /// <summary>
            /// 资源未发现(4)
            /// </summary>
            public const short RES_NO_FOUND = 4;
            /// <summary>
            /// 资源已经存在(5)
            /// </summary>
            public const short RES_IS_EXIST = 5;
            /// <summary>
            /// 失败
            /// </summary>
            public const short FAILED = 7;
            /// <summary>
            /// 数据库访问错误(2)
            /// </summary>
            public const short ACCESS_ERROR = 6;
            /// <summary>
            /// 其他错误(9)
            /// </summary>
            public const short OTHER_ERROR = 9;
        }
    }
}
