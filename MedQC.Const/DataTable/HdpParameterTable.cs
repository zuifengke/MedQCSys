using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 产品参数数据表字段定义
        /// </summary>
        public struct HdpParameterTable
        {
            public const string GROUP_NAME = "GROUP_NAME";
            public const string CONFIG_NAME = "CONFIG_NAME";
            public const string CONFIG_VALUE = "CONFIG_VALUE";
            public const string CONFIG_DESC = "CONFIG_DESC";
            public const string PRODUCT = "PRODUCT";
        }
    }
}
