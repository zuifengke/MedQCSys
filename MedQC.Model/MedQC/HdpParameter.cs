using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public class HdpParameter : DbTypeBase
    {

        public string GROUP_NAME { get; set; }
        public  string CONFIG_NAME { get; set; }
        public  string CONFIG_VALUE { get; set; }
        public  string CONFIG_DESC { get; set; }
        public  string PRODUCT { get; set; }

    }
}
