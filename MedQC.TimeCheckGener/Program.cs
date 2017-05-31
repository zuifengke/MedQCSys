using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Heren.Common.Libraries;

namespace MedQC.TimeCheckGener
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            LogManager.Instance.TextLogOnly = true;
            SystemConfig.Instance.ConfigFile = string.Format("{0}\\MedQCSys.xml", Application.StartupPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}