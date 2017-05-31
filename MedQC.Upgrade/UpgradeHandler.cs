/************************************************************
 * @FileName   : UpgradeHandler.cs
 * @Description: 电子病历系统之系统自动升级插件自动升级处理器
 * @Author     : 杨明坤(YangMingkun)
 * @Date       : 2015-12-7 12:56:09
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
************************************************************/
using System;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using Heren.Common.Libraries;
using Heren.Common.Libraries.Ftp;
using Heren.Common.ZipLib.Zip;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.MedQC.Core;

namespace Heren.MedQC.Upgrade
{
    public class UpgradeHandler
    {
        private static UpgradeHandler _Instance = null;
        public static UpgradeHandler Instance
        {
            get {
                if (_Instance == null)
                    _Instance = new UpgradeHandler();
                return _Instance;
            }
        }
        private string m_upgradeVersion = null;
        /// <summary>
        /// 获取服务器上配置的待升级的版本号
        /// </summary>
        public string UpgradeVersion
        {
            get
            {
                if (this.m_upgradeVersion == null)
                    this.InitializeConfig();
                return this.m_upgradeVersion;
            }
        }

        private FtpAccess m_upgradeFtpAccess = null;
        /// <summary>
        /// 获取服务器上配置的待升级的版本号
        /// </summary>
        public FtpAccess UpgradeFtpAccess
        {
            get
            {
                if (this.m_upgradeFtpAccess == null)
                    this.InitializeConfig();
                return this.m_upgradeFtpAccess;
            }
        }

        /// <summary>
        /// 缓存互斥程序列表
        /// </summary>
        private List<Addin> m_mutexSystemList = null;

        /// <summary>
        /// 自动升级版本号
        /// </summary>
        const string CURRENT_VERSION = "Current.Version";

        /// <summary>
        /// 运行自动升级程序
        /// </summary>
        /// <param name="owner">拥有者</param>
        /// <param name="caller">调用者</param>
        /// <param name="args">启动参数</param>
        /// <returns>是否执行成功</returns>
        public string Execute(string args)
        {
            if (this.CheckNewVersion())
            {
                this.StartUpgrade(args);
                return "正在自动升级病案质控系统!";
            }
            return null;
        }

        #region"退出排斥系统"
        /// <summary>
        /// 关闭互斥的各个程序
        /// </summary>
        /// <returns>bool</returns>
        private bool ExitMutexSystem()
        {
            if (this.m_mutexSystemList == null)
            {
                this.m_mutexSystemList = new List<Addin>();
                string file = GlobalMethods.Misc.GetWorkingPath()
                    + "\\MutexApps.xml";
                XmlDocument xmldoc = GlobalMethods.Xml.GetXmlDocument(file);
                foreach (XmlNode node in xmldoc.DocumentElement.ChildNodes)
                {
                    this.m_mutexSystemList.Add(Addin.Create(node));
                }
            }

            if (this.m_mutexSystemList.Count <= 0)
                return true;
            foreach (Addin mutexSystemAddin in this.m_mutexSystemList)
            {
                string mutexMode = mutexSystemAddin.GetAttributeValue("MutexMode", "");
                if (mutexMode == "MappingName")
                {
                    if (!this.ExitSystemWithMappingName(mutexSystemAddin.Name))
                        return false;
                }
                else if (mutexMode == "WindowName")
                {
                    if (!this.ExitSystemWithWindowName(mutexSystemAddin.Name))
                        return false;
                }
                else if (mutexMode == "ProcessName")
                {
                    if (!this.ExitSystemWithProcessName(mutexSystemAddin.Name))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 退出指定的系统,如果正在运行
        /// </summary>
        /// <param name="mappingName">系统标识</param>
        /// <returns>是否退出</returns>
        private bool ExitSystemWithMappingName(string mappingName)
        {
            FileMapping fileMapping = new FileMapping(mappingName);
            if (fileMapping.IsFirstInstance)
            {
                fileMapping.Dispose(true);
                return true;
            }
            IntPtr hMainHandle = fileMapping.ReadHandleValue(1);
            fileMapping.Dispose(false);
            return this.ExitSystemWithMainHandle(hMainHandle);
        }

        /// <summary>
        /// 退出指定的系统,如果正在运行
        /// </summary>
        /// <param name="windowName">系统标识</param>
        /// <returns>是否退出</returns>
        private bool ExitSystemWithWindowName(string windowName)
        {
            IntPtr hMainHandle = NativeMethods.User32.FindWindow(windowName, null);
            while (hMainHandle != IntPtr.Zero)
            {
                if (!this.ExitSystemWithMainHandle(hMainHandle))
                    return false;
                hMainHandle = NativeMethods.User32.FindWindow(windowName, null);
            }
            return true;
        }

        /// <summary>
        /// 退出指定的系统,如果正在运行
        /// </summary>
        /// <param name="processName">系统标识</param>
        /// <returns>是否退出</returns>
        private bool ExitSystemWithProcessName(string processName)
        {
            Process[] processes = null;
            try
            {
                processes = Process.GetProcessesByName(processName);
            }
            catch { return true; }
            if (processes == null || processes.Length <= 0)
                return true;
            foreach (Process process in processes)
            {
                IntPtr hMainHandle = IntPtr.Zero;
                try
                {
                    hMainHandle = process.MainWindowHandle;
                }
                catch { }
                if (hMainHandle == IntPtr.Zero)
                {
                    try
                    {
                        process.Kill();
                        continue;
                    }
                    catch { return false; }
                }
                if (!this.ExitSystemWithMainHandle(hMainHandle))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 退出指定的系统,如果正在运行
        /// </summary>
        /// <param name="processName">系统标识</param>
        /// <returns>是否退出</returns>
        private bool ExitSystemWithMainHandle(IntPtr hMainHandle)
        {
            if (hMainHandle == IntPtr.Zero)
                return true;
            if (!NativeMethods.User32.IsWindow(hMainHandle))
                return true;

            if (NativeMethods.User32.IsIconic(hMainHandle))
                NativeMethods.User32.ShowWindow(hMainHandle, NativeConstants.SW_RESTORE);
            NativeMethods.User32.SetForegroundWindow(hMainHandle);
            NativeMethods.User32.SendMessage(hMainHandle, NativeConstants.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);

            int count = 60;
            do
            {
                System.Threading.Thread.Sleep(1000);
                if (!NativeMethods.User32.IsWindow(hMainHandle))
                    return true;
            } while (--count > 0);
            return false;
        }
        #endregion

        private void InitializeConfig()
        {
            this.m_upgradeVersion = null;
            this.m_upgradeFtpAccess = null;
            List<ConfigInfo> configInfos = null;
            ConfigAccess.Instance.GetConfigData("UPGRADE", null, ref configInfos);
            if (configInfos == null || configInfos.Count <= 0)
                return;

            this.m_upgradeFtpAccess = new FtpAccess();
            foreach (ConfigInfo configInfo in configInfos)
            {
                if (configInfo.ConfigName == "IP")
                    this.m_upgradeFtpAccess.FtpIP = configInfo.ConfigValue;
                else if (configInfo.ConfigName == "PORT")
                    this.m_upgradeFtpAccess.FtpPort = GlobalMethods.Convert.StringToValue(configInfo.ConfigValue, 21);
                else if (configInfo.ConfigName == "USER")
                    this.m_upgradeFtpAccess.UserName = configInfo.ConfigValue;
                else if (configInfo.ConfigName == "PWD")
                    this.m_upgradeFtpAccess.Password = configInfo.ConfigValue;
                else if (configInfo.ConfigName == "MEDQC_VERSION")
                    this.m_upgradeVersion = configInfo.ConfigValue;
            }
        }

        /// <summary>
        /// 检测是否有新版本待升级
        /// </summary>
        /// <returns>是否升级</returns>
        public bool CheckNewVersion()
        {
            //升级版本号
            if (GlobalMethods.Misc.IsEmptyString(this.UpgradeVersion))
                return false;

            //当前版本号
            string currentVersion = SystemConfig.Instance.Get(CURRENT_VERSION, string.Empty);
          
            //如果升级版本同当前当前版本信息不符合就升级
            return !currentVersion.Equals(this.UpgradeVersion);
        }

        /// <summary>
        /// 启动自动升级程序
        /// </summary>
        /// <param name="args">参数</param>
        public void StartUpgrade(string args)
        {
            Process proc = new Process();
            proc.StartInfo = new ProcessStartInfo();
            proc.StartInfo.FileName = string.Format(@"{0}\Upgrade.exe", GlobalMethods.Misc.GetWorkingPath());
            proc.StartInfo.Arguments = args;
            try
            {
                proc.Start();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("UpgradeHandler.StartUpgrade", null, null, "升级程序启动失败!", ex);
            }
        }

        internal bool BeginUpgradeSystem(string args)
        {
            //1.结束应用程序
            WorkProcess.Instance.Show(0, false);
            if (!this.ExitMutexSystem())
            {
                WorkProcess.Instance.Close();
                return false;
            }
            if (this.UpgradeFtpAccess == null)
            {
                WorkProcess.Instance.Close();
                return false;
            }

            //2.下载升级文件
            string text = string.Format("正在下载新版本“{0}”，请稍候...", this.UpgradeVersion);
            WorkProcess.Instance.Show(text, 2, false);
            if (GlobalMethods.Misc.IsEmptyString(this.UpgradeVersion))
            {
                WorkProcess.Instance.Close();
                return false;
            }
            string remoteFile = string.Format("/UPGRADE/{0}.zip", this.UpgradeVersion);
            string localFile = string.Format(@"{0}\Upgrade\{1}.zip"
                , GlobalMethods.Misc.GetWorkingPath(), this.UpgradeVersion);
            GlobalMethods.IO.CreateDirectory(GlobalMethods.IO.GetFilePath(localFile));

            if (!this.UpgradeFtpAccess.OpenConnection())
            {
                WorkProcess.Instance.Close();
                return false;
            }
            if (!this.UpgradeFtpAccess.Download(remoteFile, localFile))
            {
                this.UpgradeFtpAccess.CloseConnection();
                WorkProcess.Instance.Close();
                return false;
            }
            this.UpgradeFtpAccess.CloseConnection();

            //3.解压文件
            WorkProcess.Instance.Show("正在分析升级包，请稍候...", 5, false);
            string unzipPath = GlobalMethods.IO.GetFilePath(localFile);
            try
            {
                this.UncompressFile(localFile, unzipPath);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("UpgradeHandler.UncompressFile", null, null, ex);
                WorkProcess.Instance.Close();
                return false;
            }

            //4.更新本地版本信息
            WorkProcess.Instance.Show("正在更新本地版本信息，请稍候...", 8, false);
            string currentVersion = SystemConfig.Instance.Get(CURRENT_VERSION, string.Empty);
            SystemConfig.Instance.Write(CURRENT_VERSION, this.UpgradeVersion);
            string newConfigFile = string.Format(@"{0}\MedQCSys_Bak.xml", GlobalMethods.Misc.GetWorkingPath());
            GlobalMethods.IO.CopyFile(SystemConfig.Instance.ConfigFile, newConfigFile);
            //SystemConfig.Instance.Write(CURRENT_VERSION, currentVersion);

            //5.将解压文件覆盖程序文件
            WorkProcess.Instance.Show("正在更新应用程序文件，请稍候...", 10, false);
            if (!this.ExitMutexSystem())
            {
                WorkProcess.Instance.Close();
                return false;
            }
            WorkProcess.Instance.Close();
            this.UpdateAppcalitionFiles(args);
            return true;
        }

        /// <summary>
        /// 解压指定的压缩文件
        /// </summary>
        /// <param name="zipFile">压缩文件</param>
        /// <param name="unZipDir">解压目录</param>
        /// <returns>解压是否成功</returns>
        private void UncompressFile(string zipFile, string unZipDir)
        {
            if (string.IsNullOrEmpty(zipFile) || !File.Exists(zipFile))
            {
                throw new Exception("压缩文件不存在!");
            }
            ZipInputStream zipInputStream = null;
            FileStream zipFileStream = null;
            FileStream streamWriter = null;
            try
            {
                zipFileStream = File.OpenRead(zipFile);
                zipInputStream = new ZipInputStream(zipFileStream);
                ZipEntry zipEntry = null;
                while ((zipEntry = zipInputStream.GetNextEntry()) != null)
                {
                    if (zipEntry.IsDirectory)
                    {
                        Directory.CreateDirectory(unZipDir + "\\" + zipEntry.Name);
                        continue;
                    }
                    string entryFile = unZipDir + "\\" + zipEntry.Name;
                    streamWriter = File.Create(entryFile);
                    int size = 0;
                    byte[] data = new byte[2048];
                    do
                    {
                        size = zipInputStream.Read(data, 0, data.Length);
                        if (size > 0) streamWriter.Write(data, 0, size);
                    } while (size > 0);
                    streamWriter.Flush();
                    streamWriter.Dispose();
                }
                unZipDir = unZipDir + "\\" + GlobalMethods.IO.GetFileName(zipFile, false);
            }
            finally
            {
                if (streamWriter != null) streamWriter.Close();
                if (streamWriter != null) streamWriter.Dispose();
                if (zipFileStream != null) zipFileStream.Close();
                if (zipFileStream != null) zipFileStream.Dispose();
                if (zipInputStream != null) zipInputStream.Close();
                if (zipInputStream != null) zipInputStream.Dispose();
            }
        }

        /// <summary>
        /// 更新应用程序文件
        /// </summary>
        private void UpdateAppcalitionFiles(string args)
        {
            string szUpgradeBatText = Properties.Resources.ResourceManager.GetObject("Upgrade") as string;
            string szUpgradeBatFile = string.Format(@"{0}\AutoUpgrade.bat", GlobalMethods.Misc.GetWorkingPath());
            szUpgradeBatText = GlobalMethods.Convert.ReplaceText(szUpgradeBatText
                , new string[] { "{app_path}", "{medqc_version}", "{app_args}" }
                , new string[] { GlobalMethods.Misc.GetWorkingPath(), this.UpgradeVersion, args });
            if (!GlobalMethods.IO.WriteFileText(szUpgradeBatFile, szUpgradeBatText))
                return;
            try
            {
                Process.Start(szUpgradeBatFile);
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("UpgradeHandler.UpdateAppcalitionFiles", null, null, "病案质控系统升级失败!", ex);
            }
        }
    }
}
