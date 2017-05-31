using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MedQC.ChatServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Heren.Common.Libraries.SystemConfig.Instance.ConfigFile = EMRDBLib.SystemParam.Instance.ConfigFile;
            Application.Run(new ChatServer());
        }
    }
}
