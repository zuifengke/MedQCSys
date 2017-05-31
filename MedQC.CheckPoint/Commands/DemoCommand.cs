using Heren.MedQC.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Heren.MedQC.CheckPoint.Commands
{
    public class DemoCommand:AbstractCommand
    {
        public DemoCommand()
        {
            this.m_name = "测试命令";
        }
        public override bool Execute(object param, object data, out object result)
        {
            result = "返回demo结果集";
            return true;
        }
        
    }
}
