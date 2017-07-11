using System;
using System.Collections.Generic;
using System.Text;

namespace Heren.MedQC.Model
{
    public static class DateTimeExtensions
    {
        public static string ToDefaultString(DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd HH:mm");
        }
    }
}
