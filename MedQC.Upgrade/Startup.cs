/************************************************************
 * @FileName   : Startup.cs
 * @Description: 电子病历系统之系统自动升级插件程序入口
 * @Author     : 杨明坤(YangMingkun)
 * @Date       : 2015-12-7 12:56:09
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using EMRDBLib;

namespace Heren.MedQC.Upgrade
{
    public class Startup
    {
        [STAThread]
        public static void Main(string[] args)
        {
            LogManager.Instance.TextLogOnly = true;
            SystemConfig.Instance.ConfigFile = SystemParam.Instance.ConfigFile;
            MessageBoxEx.Caption = "病案质控系统";

            FileMapping fileMapping = new FileMapping(SystemData.MappingName.UPGRADE_SYS);
            if (fileMapping.IsFirstInstance)
            {
                Application.SetCompatibleTextRenderingDefault(false);
                Application.EnableVisualStyles();
                WorkProcess.Instance.Initialize(null, 10, "正在准备升级病案病历系统，请稍候...");
                (new UpgradeHandler()).BeginUpgradeSystem(args.Length > 0 ? args[0] : null);
                fileMapping.Dispose(true);
            }
        }
    }
}
