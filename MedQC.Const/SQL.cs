using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// SQL命令常量
        /// </summary>
        public struct SQL
        {
            /// <summary>
            /// "SELECT {0}"
            /// </summary>
            public const string SELECT = "SELECT {0}";
            /// <summary>
            /// "SELECT {0} FROM {1}"
            /// </summary>
            public const string SELECT_FROM = "SELECT {0} FROM {1}";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2}"
            /// </summary>
            public const string SELECT_WHERE = "SELECT {0} FROM {1} WHERE {2}";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2} IN({3})"
            /// </summary>
            public const string SELECT_WHERE_IN = "SELECT {0} FROM {1} WHERE {2} IN({3})";
            /// <summary>
            /// "SELECT {0} FROM {1} ORDER BY {2} ASC"
            /// </summary>
            public const string SELECT_ORDER_ASC = "SELECT {0} FROM {1} ORDER BY {2} ASC";
            /// <summary>
            /// "SELECT {0} FROM {1} ORDER BY {2} DESC"
            /// </summary>
            public const string SELECT_ORDER_DESC = "SELECT {0} FROM {1} ORDER BY {2} DESC";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2} ORDER BY {3} ASC"
            /// </summary>
            public const string SELECT_WHERE_ORDER_ASC = "SELECT {0} FROM {1} WHERE {2} ORDER BY {3} ASC";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2} ORDER BY {3} DESC"
            /// </summary>
            public const string SELECT_WHERE_ORDER_DESC = "SELECT {0} FROM {1} WHERE {2} ORDER BY {3} DESC";
            /// <summary>
            /// "SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {3} ASC"
            /// </summary>
            public const string SELECT_DISTINCT_WHERE_ORDER_ASC = "SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {3} ASC";
            /// <summary>
            /// "SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {3} DESC"
            /// </summary>
            public const string SELECT_DISTINCT_WHERE_ORDER_DESC = "SELECT DISTINCT {0} FROM {1} WHERE {2} ORDER BY {3} DESC";
            /// <summary>
            /// "INSERT INTO {0}({1}) VALUES({2})"
            /// </summary>
            public const string INSERT = "INSERT INTO {0}({1}) VALUES({2})";
            /// <summary>
            /// "UPDATE {0} SET {1} WHERE {2}"
            /// </summary>
            public const string UPDATE = "UPDATE {0} SET {1} WHERE {2}";
            /// <summary>
            /// "DELETE FROM {0} WHERE {1}"
            /// </summary>
            public const string DELETE = "DELETE FROM {0} WHERE {1}";
            /// <summary>
            /// "{0} UNION {1}"
            /// </summary>
            public const string UNION = "{0} UNION {1}";
            /// <summary>
            /// "SELECT {0} FROM {1} WHERE {2} GROUP BY {3}"
            /// </summary>
            public const string SELECT_FROM_WHERE_GROUP = "SELECT {0} FROM {1} WHERE {2} GROUP BY {3}";
        }
    }
}
