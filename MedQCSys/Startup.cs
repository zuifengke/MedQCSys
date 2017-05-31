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
            Application.SetCompatibleTextRenderingDefault(false);
            Application.EnableVisualStyles();
            LogManager.Instance.TextLogOnly = true;
            SystemConfig.Instance.ConfigFile = SystemParam.Instance.ConfigFile;
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

        private static void StartNewInstance(string[] args)
        {

            MainForm frmMain = new MainForm();
            frmMain.FormClosed += new FormClosedEventHandler(MainForm_FormClosed);

            GlobalMethods.UI.SetCursor(frmMain, Cursors.WaitCursor);
            GC.KeepAlive(frmMain);

            IntPtr hMainWnd = frmMain.Handle;
            if (!Startup.FileMapping.WriteHandleValue(hMainWnd))
                return;
            frmMain.Show();
            frmMain.Update();
            if (frmMain == null || frmMain.IsDisposed)
            {
                Application.Exit();
                return;
            }
            GlobalMethods.UI.SetCursor(frmMain, Cursors.Default);
            Application.Run(frmMain); 
            MedDocSys.DataLayer.SysTimeHelper.Instance.Dispose();
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