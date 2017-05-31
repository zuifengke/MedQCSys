using EMRDBLib;
using Heren.Common.Libraries;
using Heren.MedQC.CheckPoint;
using Heren.MedQC.Core;
using System.IO;
using System.Threading;
using System.Windows.Forms;
namespace Quartz.Server
{
    /// <summary>
    /// The server's main entry point.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main.
        /// </summary>
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SystemConfig.Instance.ConfigFile = SystemParam.Instance.ConfigFile;
            CommandHandler.Instance.Initialize();
            Application.Run(new Form1());

        }
    }
}