using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Heren.MedQC.Core;

namespace Heren.MedQC.CheckPoint.Commands.newhis
{
    /// <summary>
    /// 缺陷内容：未完成术前常规检查 过程复杂，未实现
    /// 核查方法：择期中等全麻手术开始前，在检验结果中须有“肝功”、“肾功”、“出凝血时间”、“输血前四项”、“血常规”、“尿常规”项目的检验结果，并且报告返回时间在手术开始之前。在检查记录中需有心电图或动态心电图之一和胸片、胸透、胸部CT之一的检验报告，并且报告返回时间在手术开始之前。如无上述检查检验报告，需在入院记录辅助检查中有“血常规”、“尿常规”、“肝功”、“肾功”、“出凝血时间”、“输血”、“心电图”和“胸片”、“胸透”、“胸部CT”三者之一的关键词。
    /// </summary>
    public class shuqianjianchaCommand : AbstractCommand
    {
        
        public shuqianjianchaCommand()
        {
            this.m_name = "新军卫-未完成术前常规检查";
        }
        public override bool Execute(object param, object data, out object result)
        {
            result = null;
            return true;
        }
    }
}
