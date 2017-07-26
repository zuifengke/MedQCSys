// ***********************************************************
// 数据库访问层数据访问基类,本基类负责提供一些共享变量与方法.
// 用于防止重复实例化,提高效率
// Creator:YangMingkun  Date:2010-11-18
// Copyright:supconhealth
// ***********************************************************
using System;
using Heren.Common.Libraries.DbAccess;
using Heren.Common.Libraries.Ftp;
using Heren.Common.Libraries;

namespace EMRDBLib.DbAccess
{
    public abstract class DBAccessBase
    {
        private DataAccess m_MeddocAccess = null;
        private DataAccess m_MedQCAccess = null;
        private DataAccess m_HerenHisAccess = null;
        private DataAccess m_NurDocAccess = null;
        private DataAccess m_HisLoginAccess = null;
        public DBAccessBase()
        {

        }

        private bool m_bAutoClearPool = true;

        /// <summary>
        /// 获取病历文书数据库访问对象实例
        /// </summary>
        protected DataAccess MeddocAccess
        {
            get
            {
                if (this.m_MeddocAccess == null)
                    this.m_MeddocAccess = this.GetMeddocAccess();
                return this.m_MeddocAccess;
            }
        }

        /// <summary>
        /// 获取数据库访问对象
        /// </summary>
        /// <returns></returns>
        public DataAccess GetMeddocAccess()
        {
            if (this.m_MeddocAccess != null)
                return this.m_MeddocAccess;
            //读取配置文件中数据库配置
            string szDBType = SystemConfig.Instance.Get(SystemData.ConfigKey.MDS_DB_TYPE, string.Empty);
            string szDBDriverType = SystemConfig.Instance.Get(SystemData.ConfigKey.MDS_PROVIDER_TYPE, string.Empty);
            string szConnectionString = SystemConfig.Instance.Get(SystemData.ConfigKey.MDS_CONN_STRING, string.Empty);
            szDBType = GlobalMethods.Security.DecryptText(szDBType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szDBDriverType = GlobalMethods.Security.DecryptText(szDBDriverType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szConnectionString = GlobalMethods.Security.DecryptText(szConnectionString,
                SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            if (GlobalMethods.Misc.IsEmptyString(szDBType) || GlobalMethods.Misc.IsEmptyString(szDBDriverType)
                || GlobalMethods.Misc.IsEmptyString(szConnectionString))
            {
                LogManager.Instance.WriteLog("SystemParam.GetDbAccess", new string[] { "ConfigFile" }
                    , new object[] { SystemConfig.Instance.ConfigFile }, "数据库配置参数中包含非法的值!");
                return null;
            }
            this.m_MeddocAccess = new DataAccess();
            this.m_MeddocAccess.ConnectionString = szConnectionString;
            this.m_MeddocAccess.ClearPoolEnabled = this.m_bAutoClearPool;
            this.m_MeddocAccess.DatabaseType = this.GetDatabaseType(szDBType);
            this.m_MeddocAccess.DataProvider = this.GetDataProvider(szDBDriverType);
            return this.m_MeddocAccess;
        }
        private StorageMode m_eStorageMode = StorageMode.Unknown;
        /// <summary>
        /// 获取文档存储模式
        /// </summary>
        /// <returns>StorageMode枚举</returns>
        public StorageMode GetStorageMode()
        {
            if (this.m_eStorageMode != StorageMode.Unknown)
                return this.m_eStorageMode;

            if (this.m_ConfigAccess == null)
                this.m_ConfigAccess = new ConfigAccess();
            this.m_eStorageMode = this.m_ConfigAccess.GetStorageMode();
            return this.m_eStorageMode;
        }
        /// <summary>
        /// 获取数据库访问对象
        /// </summary>
        /// <returns></returns>
        public DataAccess GetMedQCAccess()
        {
            if (this.m_MedQCAccess != null)
                return this.m_MedQCAccess;

            //读取配置文件中数据库配置
            string szDBType = SystemConfig.Instance.Get(SystemData.ConfigKey.QC_DB_TYPE, string.Empty);
            string szDBDriverType = SystemConfig.Instance.Get(SystemData.ConfigKey.QC_PROVIDER_TYPE, string.Empty);
            string szConnectionString = SystemConfig.Instance.Get(SystemData.ConfigKey.QC_CONN_STRING, string.Empty);
            szDBType = GlobalMethods.Security.DecryptText(szDBType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szDBDriverType = GlobalMethods.Security.DecryptText(szDBDriverType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szConnectionString = GlobalMethods.Security.DecryptText(szConnectionString, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);

            if (GlobalMethods.Misc.IsEmptyString(szDBType) || GlobalMethods.Misc.IsEmptyString(szDBDriverType)
                || GlobalMethods.Misc.IsEmptyString(szConnectionString))
            {
                LogManager.Instance.WriteLog("SystemParam.GetNewQCDbAccess", new string[] { "ConfigFile" }
                    , new object[] { SystemConfig.Instance.ConfigFile }, "数据库配置参数中包含非法的值!");
                return null;
            }
            this.m_MedQCAccess = new DataAccess();
            this.m_MedQCAccess.ConnectionString = szConnectionString;
            this.m_MedQCAccess.ClearPoolEnabled = this.m_bAutoClearPool;
            this.m_MedQCAccess.DatabaseType = this.GetDatabaseType(szDBType);
            this.m_MedQCAccess.DataProvider = this.GetDataProvider(szDBDriverType);
            return this.m_MedQCAccess;
        }

        /// <summary>
        /// 获取数据库访问对象
        /// </summary>
        /// <returns></returns>
        public DataAccess GetHerenHisAccess()
        {
            if (this.m_HerenHisAccess != null)
                return this.m_HerenHisAccess;

            //读取配置文件中数据库配置
            string szDBType = SystemConfig.Instance.Get(SystemData.ConfigKey.HIS_DB_TYPE, string.Empty);
            string szDBDriverType = SystemConfig.Instance.Get(SystemData.ConfigKey.HIS_PROVIDER_TYPE, string.Empty);
            string szConnectionString = SystemConfig.Instance.Get(SystemData.ConfigKey.HIS_CONN_STRING, string.Empty);
            szDBType = GlobalMethods.Security.DecryptText(szDBType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szDBDriverType = GlobalMethods.Security.DecryptText(szDBDriverType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szConnectionString = GlobalMethods.Security.DecryptText(szConnectionString, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);

            if (GlobalMethods.Misc.IsEmptyString(szDBType) || GlobalMethods.Misc.IsEmptyString(szDBDriverType)
                || GlobalMethods.Misc.IsEmptyString(szConnectionString))
            {
                LogManager.Instance.WriteLog("SystemParam.GetHerenHisAccess", new string[] { "ConfigFile" }
                    , new object[] { SystemConfig.Instance.ConfigFile }, "数据库配置参数中包含非法的值!");
                return null;
            }
            this.m_HerenHisAccess = new DataAccess();
            this.m_HerenHisAccess.ConnectionString = szConnectionString;
            this.m_HerenHisAccess.ClearPoolEnabled = this.m_bAutoClearPool;
            this.m_HerenHisAccess.DatabaseType = this.GetDatabaseType(szDBType);
            this.m_HerenHisAccess.DataProvider = this.GetDataProvider(szDBDriverType);
            return this.m_HerenHisAccess;
        }

        /// <summary>
        /// 获取数据库访问对象
        /// </summary>
        /// <returns></returns>
        public DataAccess GetNurDocAccess()
        {
            if (this.m_NurDocAccess != null)
                return this.m_NurDocAccess;

            //读取配置文件中数据库配置
            string szDBType = SystemConfig.Instance.Get(SystemData.ConfigKey.NDS_DB_TYPE, string.Empty);
            string szDBDriverType = SystemConfig.Instance.Get(SystemData.ConfigKey.NDS_PROVIDER_TYPE, string.Empty);
            string szConnectionString = SystemConfig.Instance.Get(SystemData.ConfigKey.NDS_CONN_STRING, string.Empty);
            szDBType = GlobalMethods.Security.DecryptText(szDBType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szDBDriverType = GlobalMethods.Security.DecryptText(szDBDriverType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szConnectionString = GlobalMethods.Security.DecryptText(szConnectionString, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);

            if (GlobalMethods.Misc.IsEmptyString(szDBType) || GlobalMethods.Misc.IsEmptyString(szDBDriverType)
                || GlobalMethods.Misc.IsEmptyString(szConnectionString))
            {
                LogManager.Instance.WriteLog("SystemParam.GetHerenHisAccess", new string[] { "ConfigFile" }
                    , new object[] { SystemConfig.Instance.ConfigFile }, "数据库配置参数中包含非法的值!");
                return null;
            }
            this.m_NurDocAccess = new DataAccess();
            this.m_NurDocAccess.ConnectionString = szConnectionString;
            this.m_NurDocAccess.ClearPoolEnabled = this.m_bAutoClearPool;
            this.m_NurDocAccess.DatabaseType = this.GetDatabaseType(szDBType);
            this.m_NurDocAccess.DataProvider = this.GetDataProvider(szDBDriverType);
            return this.m_NurDocAccess;
        }
        /// <summary>
        /// 获取数据库访问对象
        /// </summary>
        /// <returns></returns>
        public DataAccess GetBAJKAccess()
        {
            if (this.m_BAJKAccess != null)
                return this.m_BAJKAccess;

            //读取配置文件中数据库配置
            string szDBType = SystemConfig.Instance.Get(SystemData.ConfigKey.BAJK_DB_TYPE, string.Empty);
            string szDBDriverType = SystemConfig.Instance.Get(SystemData.ConfigKey.BAJK_PROVIDER_TYPE, string.Empty);
            string szConnectionString = SystemConfig.Instance.Get(SystemData.ConfigKey.BAJK_CONN_STRING, string.Empty);
            szDBType = GlobalMethods.Security.DecryptText(szDBType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szDBDriverType = GlobalMethods.Security.DecryptText(szDBDriverType, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);
            szConnectionString = GlobalMethods.Security.DecryptText(szConnectionString, SystemData.ConfigKey.CONFIG_ENCRYPT_KEY);

            if (GlobalMethods.Misc.IsEmptyString(szDBType) || GlobalMethods.Misc.IsEmptyString(szDBDriverType)
                || GlobalMethods.Misc.IsEmptyString(szConnectionString))
            {
                LogManager.Instance.WriteLog("SystemParam.GetBAJKAccess", new string[] { "ConfigFile" }
                    , new object[] { SystemConfig.Instance.ConfigFile }, "数据库配置参数中包含非法的值!");
                return null;
            }
            this.m_BAJKAccess = new DataAccess();
            this.m_BAJKAccess.ConnectionString = szConnectionString;
            this.m_BAJKAccess.ClearPoolEnabled = this.m_bAutoClearPool;
            this.m_BAJKAccess.DatabaseType = this.GetDatabaseType(szDBType);
            this.m_BAJKAccess.DataProvider = this.GetDataProvider(szDBDriverType);
            return this.m_BAJKAccess;
        }
        /// <summary>
        /// 将数据库类型字符串转换为数据库类型枚举
        /// </summary>
        /// <param name="szDbType">数据库类型字符串</param>
        /// <returns>数据库类型枚举</returns>
        private DatabaseType GetDatabaseType(string szDbType)
        {
            if (szDbType == SystemData.DatabaseType.SQLSERVER)
            {
                return DatabaseType.SQLSERVER;
            }
            else if (szDbType == SystemData.DatabaseType.ORACLE)
            {
                return DatabaseType.ORACLE;
            }
            else
            {
                LogManager.Instance.WriteLog("SystemParam.GetDatabaseType", "不支持的数据库驱动!");
                return DatabaseType.ORACLE;
            }
        }

        /// 将数据库访问提供程序类型字符串转换为类型枚举
        /// </summary>
        /// <param name="szDbDriverType">提供程序类型字符串</param>
        /// <returns>提供程序类型枚举</returns>
        private DataProvider GetDataProvider(string szDbDriverType)
        {
            if (szDbDriverType == SystemData.DataProvider.ODBC)
            {
                return DataProvider.Odbc;
            }
            else if (szDbDriverType == SystemData.DataProvider.ODPNET)
            {
                return DataProvider.ODPNET;
            }
            else if (szDbDriverType == SystemData.DataProvider.ORACLE)
            {
                return DataProvider.OracleClient;
            }
            else if (szDbDriverType == SystemData.DataProvider.SQLCLIENT)
            {
                return DataProvider.SqlClient;
            }
            else if (szDbDriverType == SystemData.DataProvider.OLEDB)
            {
                return DataProvider.OleDb;
            }
            else
            {
                LogManager.Instance.WriteLog("SystemParam.GetDataProvider", "不支持的数据库驱动提供程序!");
                return DataProvider.OleDb;
            }
        }

        /// <summary>
        /// 获取His数据库访问对象实例
        /// </summary>
        protected DataAccess HerenHisAccess
        {
            get
            {
                if (this.m_HerenHisAccess == null)
                    this.m_HerenHisAccess = this.GetHerenHisAccess();
                return this.m_HerenHisAccess;
            }
        }

        /// <summary>
        /// 获取His数据库访问对象实例
        /// </summary>
        protected DataAccess NurDocAccess
        {
            get
            {
                if (this.m_NurDocAccess == null)
                    this.m_NurDocAccess = this.GetNurDocAccess();
                return this.m_NurDocAccess;
            }
        }
        /// <summary>
        /// 获取质控数据库访问对象实例
        /// </summary>
        protected DataAccess MedQCAccess
        {
            get
            {
                if (this.m_MedQCAccess == null)
                    this.m_MedQCAccess = this.GetMedQCAccess();
                return this.m_MedQCAccess;
            }
        }
        private DataAccess m_BAJKAccess = null;
        /// <summary>
        /// 获取病案接口数据库访问对象实例
        /// </summary>
        protected DataAccess BAJKDataAccess
        {
            get
            {
                if (this.m_BAJKAccess == null)
                    this.m_BAJKAccess = this.GetBAJKAccess();
                return this.m_BAJKAccess;
            }
        }

        public string ParaHolder(string szParaName)
        {
            switch (this.MeddocAccess.DataProvider)
            {
                case DataProvider.ODPNET:
                case DataProvider.Odbc:
                case DataProvider.OleDb:
                    return "?";
                case DataProvider.OracleClient:
                    return ":" + szParaName;
                case DataProvider.SqlClient:
                    return "@" + szParaName;
                default:
                    return "?";
            }
        }

        private StorageMode m_StorageMode = StorageMode.Unknown;
        /// <summary>
        /// 获取病历及模板的存储模式
        /// </summary>
        protected StorageMode StorageMode
        {
            get
            {
                if (this.m_StorageMode == StorageMode.Unknown)
                    this.m_StorageMode = this.GetStorageMode();
                return this.m_StorageMode;
            }
        }

        private FtpAccess m_FtpAccess = null;
        /// <summary>
        /// 获取FTP服务器访问对象实例
        /// </summary>
        protected FtpAccess FtpAccess
        {
            get
            {
                if (this.m_FtpAccess == null)
                    this.m_FtpAccess = this.GetDocFtpAccess();
                return this.m_FtpAccess;
            }
        }

        private FtpAccess m_DocFtpAccess = null;
        private ConfigAccess m_ConfigAccess = null;
        /// <summary>
        /// 获取Ftp访问类
        /// </summary>
        /// <returns>FtpAccess对象</returns>
        public FtpAccess GetDocFtpAccess()
        {
            if (this.m_DocFtpAccess != null)
                return this.m_DocFtpAccess;

            if (this.m_ConfigAccess == null)
                this.m_ConfigAccess = new ConfigAccess();
            FtpConfig ftpConfig = null;
            short shRet = this.m_ConfigAccess.GetDocFtpParams(ref ftpConfig);
            if (shRet != SystemData.ReturnValue.OK)
                return null;
            if (ftpConfig == null)
                return null;
            this.m_DocFtpAccess = new FtpAccess();
            this.m_DocFtpAccess.FtpIP = ftpConfig.FtpIP;
            this.m_DocFtpAccess.FtpPort = ftpConfig.FtpPort;
            this.m_DocFtpAccess.UserName = ftpConfig.FtpUser;
            this.m_DocFtpAccess.Password = ftpConfig.FtpPwd;
            this.m_DocFtpAccess.FtpMode = ftpConfig.FtpMode;
            return this.m_DocFtpAccess;
        }


        private FtpAccess m_RecPaperFtpAccess = null;
        /// <summary>
        /// 纸质病历翻拍图片存放地址
        /// </summary>
        /// <returns></returns>
        public FtpAccess GetRecPaperFtpAccess()
        {
            if (this.m_RecPaperFtpAccess != null)
                return this.m_RecPaperFtpAccess;

            if (this.m_ConfigAccess == null)
                this.m_ConfigAccess = new ConfigAccess();
            FtpConfig ftpConfig = null;
            short shRet = this.m_ConfigAccess.GetRecPaperFtpParams(ref ftpConfig);
            if (shRet != SystemData.ReturnValue.OK)
                return null;
            if (ftpConfig == null)
                return null;
            this.m_RecPaperFtpAccess = new FtpAccess();
            this.m_RecPaperFtpAccess.FtpIP = ftpConfig.FtpIP;
            this.m_RecPaperFtpAccess.FtpPort = ftpConfig.FtpPort;
            this.m_RecPaperFtpAccess.UserName = ftpConfig.FtpUser;
            this.m_RecPaperFtpAccess.Password = ftpConfig.FtpPwd;
            this.m_RecPaperFtpAccess.FtpMode = ftpConfig.FtpMode;
            return this.m_RecPaperFtpAccess;
        }
        /// <summary>
        /// 获取质控科医生是否可以保存病历
        /// </summary>
        /// <returns></returns>
        public bool CheckQCSaveDocEnable()
        {
            if (this.m_ConfigAccess == null)
                this.m_ConfigAccess = new ConfigAccess();
            return this.m_ConfigAccess.CheckQCCanSaveDoc();
        }
        private FtpAccess m_XDBFtpAccess = null;
        /// <summary>
        /// 获取XDBFtp xml的访问对象
        /// </summary>
        protected FtpAccess XDBFtpAccess
        {
            get
            {

                if (this.m_XDBFtpAccess == null)
                    this.m_XDBFtpAccess = this.GetXDBFtpAccess();
                return this.m_XDBFtpAccess;
            }
           
        }

        /// <summary>
        /// 获取XDBFtp访问类
        /// </summary>
        /// <returns>FtpAccess对象</returns>
        public FtpAccess GetXDBFtpAccess()
        {
            if (this.m_XDBFtpAccess != null)
                return this.m_XDBFtpAccess;

            if (this.m_ConfigAccess == null)
                this.m_ConfigAccess = new ConfigAccess();
            FtpConfig ftpConfig = null;
            short shRet = this.m_ConfigAccess.GetXDBFtpParams(ref ftpConfig);
            if (shRet != SystemData.ReturnValue.OK)
                return null;
            if (ftpConfig == null)
                return null;
            this.m_XDBFtpAccess = new FtpAccess();
            this.m_XDBFtpAccess.FtpIP = ftpConfig.FtpIP;
            this.m_XDBFtpAccess.FtpPort = ftpConfig.FtpPort;
            this.m_XDBFtpAccess.UserName = ftpConfig.FtpUser;
            this.m_XDBFtpAccess.Password = ftpConfig.FtpPwd;
            this.m_XDBFtpAccess.FtpMode = ftpConfig.FtpMode;
            return this.m_XDBFtpAccess;
        }
        private bool m_bQCSaveDocEnable = false;
        protected bool QCSaveDocEnable
        {
            get
            {
                this.m_bQCSaveDocEnable =this.CheckQCSaveDocEnable();
                return this.m_bQCSaveDocEnable;
            }
        }
    }
}
