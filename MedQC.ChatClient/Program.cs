using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Heren.Common.Libraries;
using System.IO;
using EMRDBLib;
using static EMRDBLib.SystemData;

namespace MedQC.ChatClient
{
    static class Program
    {

        private static FileMapping m_FileMapping = null;
        /// <summary>
        /// 获取或设置内存文件映射对象
        /// </summary>
        private static FileMapping FileMapping
        {
            get { return m_FileMapping; }
            set { m_FileMapping = value; }
        }
        static ChatClient form = null;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogManager.Instance.TextLogOnly = true;
            //兼容EMRS调用
            if (File.Exists(string.Format("{0}\\UserData\\MedDocSys.xml", Application.StartupPath)))
                SystemConfig.Instance.ConfigFile = string.Format("{0}\\UserData\\MedDocSys.xml", Application.StartupPath);
            else
                SystemConfig.Instance.ConfigFile = string.Format("{0}\\MedQCSys.xml", Application.StartupPath);
            MessageBoxEx.Caption = "质控反馈提醒";
            SystemParam.Instance.QChatArgs = new EMRDBLib.Entity.QChatArgs();
            //args = new string[] { "WWX;ZZYING;1;病人:吴瓜 住院号：922666病历主题:病案评分质控内容:抢救及成功次数填写不准确内容:抢救及成功次数填写不准确扣分:2.0" };
            FileMapping = new FileMapping(SystemData.MappingName.QUESTION_CHAT_CLIENT_SYS);
            form = new ChatClient();
            GC.KeepAlive(form);
            if (FileMapping.IsFirstInstance)
            {
                StartNewInstance(args);
            }
            else
            {
                HandleRunningInstance(args, 30);
            }
        }
        private static void HandleRunningInstance(string[] args, int timeoutSeconds)
        {
            IntPtr hMainWnd = FileMapping.ReadHandleValue(timeoutSeconds);
            if (hMainWnd == IntPtr.Zero)
                return;
            try
            {
                StartNewInstance(args);
                Application.Run(form);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("Startup.HandleRunningProcess", ex);
            }
        }
        /// <summary>
        /// 显示登录对话框
        /// </summary>
        /// <returns>bool</returns>
        private static bool ShowLogin()
        {
            //如果由其他程序启动此程序,则不需要登录
            LoginForm frmLogin = new LoginForm();
            return (frmLogin.ShowDialog() == DialogResult.OK);
        }

        private static void StartNewInstance(string[] args)
        {

            IntPtr hMainWnd = form.Handle;
            if (!FileMapping.WriteHandleValue(hMainWnd))
                return;
            if (args != null && args.Length > 0)
            {
                SetArgs(args);
                Application.Run(form);
            }
            else
            {
                //登录是否成功
                if (!ShowLogin())
                {
                    form.Close();
                }
                else
                {
                    Application.Run(form);
                }
            }
            LogManager.Instance.Dispose();
            SysTimeHelper.Instance.Dispose();
            FileMapping.Dispose(true);
        }

        private static void SetArgs(string[] args)
        {
            if (args == null || args.Length == 0)
                return;
            string[] arrQChatArgs = args[0].Split(new string[] { ";", "；" }, StringSplitOptions.None);
            if (arrQChatArgs.Length >= 1)
                SystemParam.Instance.QChatArgs.Sender = arrQChatArgs[0];
            if (arrQChatArgs.Length >= 2)
                SystemParam.Instance.QChatArgs.Listener = arrQChatArgs[1];
            if (arrQChatArgs.Length >= 3)
                SystemParam.Instance.QChatArgs.ArgType = arrQChatArgs[2];
            if (arrQChatArgs.Length >= 4)
            {
                SystemParam.Instance.QChatArgs.MsgContent = arrQChatArgs[3];
                if (form != null)
                    form.MsgContent = SystemParam.Instance.QChatArgs.MsgContent;
            }
               
        }
    }
}
