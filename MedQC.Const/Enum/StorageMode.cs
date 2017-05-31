using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 文档存储模式
    /// </summary>
    [System.Serializable]
    public enum StorageMode
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = -1,
        /// <summary>
        /// 数据库存储
        /// </summary>
        DB = 0,
        /// <summary>
        /// FTP存储
        /// </summary>
        FTP = 1
    }

}
