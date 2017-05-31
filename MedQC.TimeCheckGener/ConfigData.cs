using System;
using System.Collections.Generic;
using System.Text;

namespace Heren.MedQC.TimeCheckGener
{
    struct Config
    {
        public const string BugStartTime = "TimeCheckGener.BugStartTime";
    }

    struct CheckType
    {
        public const string BugCheck = "QCBugCheck";
        public const string TimeCheck = "QCTimeCheck";
    }
}
