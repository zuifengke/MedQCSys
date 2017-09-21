using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Heren.Common.Libraries;
using EMRDBLib;
namespace Designers
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            LogManager.Instance.TextLogOnly = true;
            SystemConfig.Instance.ConfigFile = string.Format("{0}\\MedQCSys.xml", Application.StartupPath);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string szFile = string.Empty;
            if (args != null && args.Length > 0)
            {
                szFile = args[0];
            }
            SystemParam.Instance.LocalConfigOption.IsMainProgram = false;
            Application.Run(new DesignForm() {FilePath= szFile });
        }
    }
}