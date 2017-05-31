using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public class ExamResultInfo : DbTypeBase
    {
        public string IsAbnormal { get; set; }
        public string Discription { get; set; }
        public string ExamID { get; set; }
        public string Impression { get; set; }
        public string Parameters { get; set; }
        public string Recommendation { get; set; }
        public string Device { get; set; }
        public string UseImage { get; set; }
    }
}
