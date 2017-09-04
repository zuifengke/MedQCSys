using EMRDBLib;
using Heren.Common.Libraries;
using Heren.MedQC.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Heren.MedQC.Utilities
{
    public class ShareFolderRead
    {
        public static bool Download(string srcFilePath,string dstFilePath,string ip, string userName, string password)
        {
            try
            {
                string shareFolder = @"\\"+ ip;
                string dstDir = dstFilePath.Substring(0, dstFilePath.LastIndexOf("\\") + 1);
                string fileName = dstFilePath.Replace(dstDir, "");
                bool status = ShareFolderRead.connectState(shareFolder, userName, password);
                if (status)
                {
                    //执行方法
                    ShareFolderRead.Transport(srcFilePath, dstDir, fileName);
                }
                else
                {
                    //ListBox1.Items.Add("未能连接！");
                }
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
                return false;
            }
        }
        public static bool Download(string srcFilePath, string dstFilePath)
        {
            try
            {
                string ip = DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.PACS_SHARE_FOLDER_IP];
                string userName= DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.PACS_SHARE_FOLDER_USER];
                string password = DataCache.Instance.DicHdpParameter[SystemData.ConfigKey.PACS_SHARE_FOLDER_PWD];
                if (string.IsNullOrEmpty(ip)
                    || string.IsNullOrEmpty(userName)
                    || string.IsNullOrEmpty(password))
                {
                    LogManager.Instance.WriteLog("pdf共享目录访问地址未配置", new string[] { "ip", "username", "password" }, new object[] { ip, userName, password }, "");
                    return false;
                }
                return Download(srcFilePath, dstFilePath, ip, userName, password);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog(ex.ToString());
                return false;
            }
        }
        public static bool connectState(string path)
        {
            return connectState(path, "", "");
        }
        /// <summary>
        /// 连接远程共享文件夹
        /// </summary>
        /// <param name="path">远程共享文件夹的路径</param>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>
        /// <returns></returns>
        public static bool connectState(string path, string userName, string passWord)
        {
            bool Flag = false;
            Process proc = new Process();
            try
            {
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                string dosLine = "net use " + path + " " + passWord + " /user:" + userName;
                proc.StandardInput.WriteLine(dosLine);
                proc.StandardInput.WriteLine("exit");
                while (!proc.HasExited)
                {
                    proc.WaitForExit(1000);
                }
                string errormsg = proc.StandardError.ReadToEnd();
                proc.StandardError.Close();
                if (string.IsNullOrEmpty(errormsg))
                {
                    Flag = true;
                }
                else
                {
                    throw new Exception(errormsg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                proc.Close();
                proc.Dispose();
            }
            return Flag;
        }

        /// <summary>
        /// 向远程文件夹保存本地内容，或者从远程文件夹下载文件到本地
        /// </summary>
        /// <param name="src">要保存的文件的路径，如果保存文件到共享文件夹，这个路径就是本地文件路径如：@"D:\1.avi"</param>
        /// <param name="dst">保存文件的路径，不含名称及扩展名</param>
        /// <param name="fileName">保存文件的名称以及扩展名</param>
        public static void Transport(string src, string dst, string fileName)
        {

            FileStream inFileStream = new FileStream(src, FileMode.Open);
            if (!Directory.Exists(dst))
            {
                Directory.CreateDirectory(dst);
            }
            dst = dst + fileName;
            FileStream outFileStream = new FileStream(dst, FileMode.OpenOrCreate);

            byte[] buf = new byte[inFileStream.Length];

            int byteCount;

            while ((byteCount = inFileStream.Read(buf, 0, buf.Length)) > 0)
            {

                outFileStream.Write(buf, 0, byteCount);

            }

            inFileStream.Flush();

            inFileStream.Close();

            outFileStream.Flush();

            outFileStream.Close();

        }
    }
}
