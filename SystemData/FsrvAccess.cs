// *****************************************************************************
// 病历文档系统用于访问军卫系统中病历服务器访问程序(通过fsrv.dll)
// Creator:YangMingkun  Date:2009-11-25
// Copyright:supconhealth
// *****************************************************************************
using System;
using System.Runtime.InteropServices;
using MedDocSys.Common;

namespace MedDocSys.DataLayer
{
    public class FsrvAccess
    {
        private static FsrvAccess m_Instance = null;
        private string m_szServerIP = null;
        private string m_szRootPath = null;

        [DllImport("fsrv.dll")]
        extern static int get_file(string szHostAddr, string szRemoteFile, string szLocalFile, int flag);
        [DllImport("fsrv.dll")]
        extern static int put_file(string szHostAddr, string szLocalFile, string szRemoteFile, int flag);

        /// <summary>
        /// 获取MedFileAccess对象实例
        /// </summary>
        public static FsrvAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new FsrvAccess();
                return m_Instance;
            }
        }
        private FsrvAccess()
        {
        }

        private bool Initialize()
        {
            if (!GlobalMethods.AppMisc.IsEmptyString(this.m_szServerIP))
                return true;
            string szServerIP = null;
            string szRootPath = null;
            short shRet = DataAccess.GetMedFileSrvConfig(ref szServerIP, ref szRootPath);
            if (shRet != SystemData.ReturnValue.OK)
                return false;
            this.m_szServerIP = szServerIP;
            this.m_szRootPath = szRootPath;

            string szFsrvDllPath = string.Concat(GlobalMethods.AppMisc.GetWorkingPath(), "\\fsrv.dll");
            if (!System.IO.File.Exists(szFsrvDllPath))
            {
                LogManager.Instance.WriteLog("MedFileAccess.Initialize", string.Concat("未找到文件:", szFsrvDllPath));
                return false;
            }
            return true;
        }

        /// <summary>
        /// 下载指定的远程共享文件到指定的本地文件
        /// </summary>
        /// <param name="szRemoteFile">远程共享文件</param>
        /// <param name="szLocalFile">指定的本地文件</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short DownloadFile(string szRemoteFile, string szLocalFile)
        {
            if (!this.Initialize())
                return SystemData.ReturnValue.FAILED;
            szRemoteFile = string.Format("{0}\\{1}", this.m_szRootPath, szRemoteFile);
            if (get_file(this.m_szServerIP, szRemoteFile, szLocalFile, 1) < 0)
            {
                LogManager.Instance.WriteLog("MedFileAccess.GetFileByFsrvdll", "get_file执行失败!");
                return SystemData.ReturnValue.FAILED;
            }
            return SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 上传指定的远程共享文件到指定的本地文件
        /// </summary>
        /// <param name="szLocalFile">指定的本地文件</param>
        /// <param name="szRemoteFile">远程共享文件</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        public short UploadFile(string szLocalFile, string szRemoteFile)
        {
            if (!this.Initialize())
                return SystemData.ReturnValue.FAILED;
            szRemoteFile = string.Format("{0}\\{1}", this.m_szRootPath, szRemoteFile);
            string szCompareFile = string.Format("{0}_{1}_server", szLocalFile, SysTimeHelper.Instance.Now.ToString("yyMMddHHmmss"));
            int nPutResult = -1;
            int nRetryCount = 3;
            while (nPutResult < 0 && nRetryCount > 0)
            {
                nPutResult = put_file(this.m_szServerIP, szLocalFile, szRemoteFile, 1);
                nRetryCount--;
                if (nPutResult < 0)
                {
                    LogManager.Instance.WriteLog("MedFileAccess.PutFileByFsrvdll", "put_file执行失败!");
                    continue;
                }
                int nGetResult = get_file(this.m_szServerIP, szRemoteFile, szCompareFile, 1);
                if (nGetResult < 0)
                {
                    nPutResult = -1;
                    LogManager.Instance.WriteLog("MedFileAccess.PutFileByFsrvdll", "get_file执行失败!");
                    continue;
                }
                if (GlobalMethods.IO.CompareFileLength(szLocalFile, szCompareFile))
                    break;
                nPutResult = -1;
            }
            GlobalMethods.IO.DeleteFile(szCompareFile);
            return nPutResult < 0 ? SystemData.ReturnValue.FAILED : SystemData.ReturnValue.OK;
        }
    }
}
