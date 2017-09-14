// ***********************************************************
// 病案质控系统系统启动程序.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Windows.Forms;
using System.ComponentModel;
using Heren.Common.Libraries;
using MedQCSys.Dialogs;
using MedQCSys.Utility;
using EMRDBLib;
using Heren.MedQC.CheckPoint;
using Heren.MedQC.Core;

namespace MedQCSys
{
    public static class Startup
    {
        private const string SINGLE_INSTANCE_MONIKER_NAME = "mrqc";

        private static FileMapping m_FileMapping = null;
        /// <summary>
        /// 获取或设置内存文件映射对象
        /// </summary>
        private static FileMapping FileMapping
        {
            get { return m_FileMapping; }
            set { m_FileMapping = value; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Application.SetCompatibleTextRenderingDefault(false);
                Application.EnableVisualStyles();
                LogManager.Instance.TextLogOnly = true;
                SystemConfig.Instance.ConfigFile = SystemParam.Instance.ConfigFile;
                System.Data.DataSet ds = null;
                if (EMRDBLib.DbAccess.CommonAccess.Instance.ExecuteQuery("select sysdate from dual", out ds) != SystemData.ReturnValue.OK)
                {
                    MessageBoxEx.ShowMessage("系统无法连接数据库，程序无法正常启动,请联系管理员","在程序根目录下找到dbconfig.exe,进行数据库连接配置");
                    return;
                }
                CommandHandler.Instance.Initialize();
                Startup.FileMapping = new FileMapping(SINGLE_INSTANCE_MONIKER_NAME);
                //  版本更新检查
                string arg = (args != null && args.Length > 0) ? args[0] : null;
                Heren.MedQC.Upgrade.UpgradeHandler.Instance.Execute(arg);
                if (Startup.FileMapping.IsFirstInstance)
                {
                    Startup.StartNewInstance(args);
                }
                else
                {
                    Startup.HandleRunningInstance(args, 30);
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("启动失败", ex);
            }
        }

        private static void StartNewInstance(string[] args)
        {
            //Application.SetCompatibleTextRenderingDefault(false);
            MainForm mainFrame = new MainForm();
            mainFrame.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);
            IntPtr hMainHandle = mainFrame.Handle;
            if (!Startup.FileMapping.WriteHandleValue(hMainHandle))
                return;
            mainFrame.Show();
            mainFrame.Update();
            if (mainFrame == null || mainFrame.IsDisposed)
            {
                Application.Exit();
                return;
            }
            GlobalMethods.UI.SetCursor(mainFrame, Cursors.Default);
            Application.Run(mainFrame);
            LogManager.Instance.Dispose();
        }

        private static void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Startup.FileMapping.Dispose(true);
        }

        private static void HandleRunningInstance(string[] args, int timeoutSeconds)
        {
            IntPtr hMainWnd = Startup.FileMapping.ReadHandleValue(timeoutSeconds);
            if (hMainWnd == IntPtr.Zero)
                return;
            try
            {
                if (NativeMethods.User32.IsIconic(hMainWnd))
                {
                    NativeMethods.User32.ShowWindow(hMainWnd, NativeConstants.SW_RESTORE);
                }
                NativeMethods.User32.SetForegroundWindow(hMainWnd);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("SysStartup.HandleRunningInstance", ex);
            }
        }
    }
}