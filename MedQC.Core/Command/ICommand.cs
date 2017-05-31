using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Core
{
    public interface ICommand
    {
        string Name { get;  }
        bool Execute(object param, object data, out object result);
        bool Execute(object param, object data);
    }
}
