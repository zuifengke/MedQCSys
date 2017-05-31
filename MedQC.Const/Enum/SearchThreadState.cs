using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 线程状态枚举
    /// </summary>
    public enum SearchThreadState
    {
        ready = 0,
        running,
        cancelled,
        finished
    }


}
