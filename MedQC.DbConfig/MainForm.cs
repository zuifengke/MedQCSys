// ***********************************************************
// 数据库连接配置工具.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;

namespace Heren.MedQC.DbConfig
{
    internal partial class MainForm : Form
    {
        /// <summary>
        /// 配置数据加密密钥
        /// </summary>
        private const string CONFIG_ENCRYPT_KEY = "SUPCON.MEDDOC.ENCRYPT.KEY";

        /// <summary>
        /// 病历数据库类型
        /// </summary>
        private const string MDS_DB_TYPE = "MdsDbType";
        /// <summary>
        /// 病历数据库驱动类型
        /// </summary>
        private const string MDS_PROVIDER_TYPE = "MdsDbProvider";
        /// <summary>
        /// 病历数据库连接串
        /// </summary>
        private const string MDS_CONN_STRING = "MdsDbConnString";
        /// <summary>
        /// 宝典控件数据库连接串
        /// </summary>
        private const string OCX_CONNECTION_STRING = "MedEditorConnString";
        /// <summary>
        /// 护理病历数据库类型
        /// </summary>
        public const string NDS_DB_TYPE = "NdsDbType";
        /// <summary>
        /// 护理病历数据库驱动类型
        /// </summary>
        public const string NDS_PROVIDER_TYPE = "NdsDbProvider";
        /// <summary>
        /// 护理病历数据库连接串
        /// </summary>
        public const string NDS_CONN_STRING = "NdsDbConnString";
        /// <summary>
        /// HIS数据库类型
        /// </summary>
        public const string HIS_DB_TYPE = "HisDbType";
        /// <summary>
        /// HIS数据库驱动类型
        /// </summary>
        public const string HIS_PROVIDER_TYPE = "HisDbProvider";
        /// <summary>
        /// HIS数据库连接串
        /// </summary>
        public const string HIS_CONN_STRING = "HisDbConnString";
        /// <summary>
        /// XML DB数据库类型
        /// </summary>
        private const string XDB_DB_TYPE = "XmlDbType";
        /// <summary>
        /// XML DB数据库驱动类型
        /// </summary>
        private const string XDB_PROVIDER_TYPE = "XmlDbProvider";
        /// <summary>
        /// XML DB数据库连接串
        /// </summary>
        private const string XDB_CONN_STRING = "XmlDbConnString";

        /// <summary>
        /// 新版质控数据库类型
        /// </summary>
        private const string QC_DB_TYPE = "QcDbType";
        /// <summary>
        /// 新版质控数据库驱动类型
        /// </summary>
        private const string QC_PROVIDER_TYPE = "QcDbProvider";
        /// <summary>
        /// 新版质控数据库连接串
        /// </summary>
        private const string QC_CONN_STRING = "QcDbConnString";

        public MainForm()
        {
            this.InitializeComponent();
            this.Icon = Heren.MedQC.DbConfig.Properties.Resources.SysIcon;
            LogManager.Instance.TextLogOnly = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            //if (this.ReadConfigFile(Application.StartupPath + @"\UserData\MedDocSys.xml")) return;
            //if (this.ReadConfigFile(Application.StartupPath + @"\MedQCSys.xml")) return;
            //if (this.ReadConfigFile(Application.StartupPath + @"\MDSDBLib.xml")) return;
            if (this.ReadConfigFile(AppDomain.CurrentDomain.BaseDirectory + @"\UserData\MedDocSys.xml")) return;
            if (this.ReadConfigFile(AppDomain.CurrentDomain.BaseDirectory + @"\MedQCSys.xml")) return;
            if (this.ReadConfigFile(AppDomain.CurrentDomain.BaseDirectory + @"\MDSDBLib.xml")) return;
        }

        private bool ReadConfigFile(string szConfigFile)
        {
            this.txtConfigFile.Text = szConfigFile;
            this.tpNds.TabPages.Remove(this.tpMdsConfig);
            this.tpNds.TabPages.Remove(this.tpXdbConfig);
            this.tpNds.TabPages.Remove(this.tpNdsConfig);
            this.tpNds.TabPages.Remove(this.tpHisConfig);
            this.tpNds.TabPages.Remove(this.tpMedQC);
            if (!System.IO.File.Exists(szConfigFile))
                return false;

            string szFileName = GlobalMethods.IO.GetFileName(szConfigFile, true).ToLower();
            if (szFileName == "meddocsys.xml" )
            {
                this.tpNds.TabPages.Add(this.tpMdsConfig);
            }
            else if (szFileName == "medqcsys.xml")
            {
                this.tpNds.TabPages.Add(this.tpMedQC);
                this.tpNds.TabPages.Add(this.tpMdsConfig);
            }
            else if (szFileName == "mdsdblib.xml")
            {
                this.tpNds.TabPages.Add(this.tpMdsConfig);
                this.tpNds.TabPages.Add(this.tpXdbConfig);
            }
            else
            {
                return false;
            }

            SystemConfig.Instance.ConfigFile = szConfigFile;
            if (this.tpNds.TabPages.Contains(this.tpMdsConfig))
            {
                string szDbType = SystemConfig.Instance.Get(MainForm.MDS_DB_TYPE, string.Empty);
                this.cboMdsDbType.Text = GlobalMethods.Security.DecryptText(szDbType, CONFIG_ENCRYPT_KEY);

                string szDbDriverType = SystemConfig.Instance.Get(MainForm.MDS_PROVIDER_TYPE, string.Empty);
                this.cboMdsDbProvider.Text = GlobalMethods.Security.DecryptText(szDbDriverType, CONFIG_ENCRYPT_KEY);

                string szConnectionString = SystemConfig.Instance.Get(MainForm.MDS_CONN_STRING, string.Empty);
                this.cboMdsConnString.Text = GlobalMethods.Security.DecryptText(szConnectionString, CONFIG_ENCRYPT_KEY);

                string szOcxConnectionString = SystemConfig.Instance.Get(MainForm.OCX_CONNECTION_STRING, string.Empty);
                this.cboOcxConnString.Text = GlobalMethods.Security.DecryptText(szOcxConnectionString, CONFIG_ENCRYPT_KEY);
            }

            if (this.tpNds.TabPages.Contains(this.tpXdbConfig))
            {
                string szDbType = SystemConfig.Instance.Get(MainForm.XDB_DB_TYPE, string.Empty);
                this.cboXdbDbType.Text = GlobalMethods.Security.DecryptText(szDbType, CONFIG_ENCRYPT_KEY);

                string szDbDriverType = SystemConfig.Instance.Get(MainForm.XDB_PROVIDER_TYPE, string.Empty);
                this.cboXdbDbProvider.Text = GlobalMethods.Security.DecryptText(szDbDriverType, CONFIG_ENCRYPT_KEY);

                string szConnectionString = SystemConfig.Instance.Get(MainForm.XDB_CONN_STRING, string.Empty);
                this.cboXdbConnString.Text = GlobalMethods.Security.DecryptText(szConnectionString, CONFIG_ENCRYPT_KEY);
            }

            if (this.tpNds.TabPages.Contains(this.tpNdsConfig))
            {

                string szDbType = SystemConfig.Instance.Get(MainForm.NDS_DB_TYPE, string.Empty);
                this.cboNdsDbType.Text = GlobalMethods.Security.DecryptText(szDbType, CONFIG_ENCRYPT_KEY);

                string szDbDriverType = SystemConfig.Instance.Get(MainForm.NDS_PROVIDER_TYPE, string.Empty);
                this.cboNdsDbProvider.Text = GlobalMethods.Security.DecryptText(szDbDriverType, CONFIG_ENCRYPT_KEY);

                string szConnectionString = SystemConfig.Instance.Get(MainForm.NDS_CONN_STRING, string.Empty);
                this.cboNdsConnString.Text = GlobalMethods.Security.DecryptText(szConnectionString, CONFIG_ENCRYPT_KEY);
            }
            if (this.tpNds.TabPages.Contains(this.tpHisConfig))
            {

                string szDbType = SystemConfig.Instance.Get(MainForm.HIS_DB_TYPE, string.Empty);
                this.cboHisDbType.Text = GlobalMethods.Security.DecryptText(szDbType, CONFIG_ENCRYPT_KEY);

                string szDbDriverType = SystemConfig.Instance.Get(MainForm.HIS_PROVIDER_TYPE, string.Empty);
                this.cboHisDbProvider.Text = GlobalMethods.Security.DecryptText(szDbDriverType, CONFIG_ENCRYPT_KEY);

                string szConnectionString = SystemConfig.Instance.Get(MainForm.HIS_CONN_STRING, string.Empty);
                this.cboHisConnString.Text = GlobalMethods.Security.DecryptText(szConnectionString, CONFIG_ENCRYPT_KEY);
            }
            if (this.tpNds.TabPages.Contains(this.tpMedQC))
            {
                string szDbType = SystemConfig.Instance.Get(MainForm.QC_DB_TYPE, string.Empty);
                this.cboQcDbType.Text = GlobalMethods.Security.DecryptText(szDbType, CONFIG_ENCRYPT_KEY);

                string szDbDriverType = SystemConfig.Instance.Get(MainForm.QC_PROVIDER_TYPE, string.Empty);
                this.cboQcProvider.Text = GlobalMethods.Security.DecryptText(szDbDriverType, CONFIG_ENCRYPT_KEY);

                string szConnectionString = SystemConfig.Instance.Get(MainForm.QC_CONN_STRING, string.Empty);
                this.cboQcConnString.Text = GlobalMethods.Security.DecryptText(szConnectionString, CONFIG_ENCRYPT_KEY);
            }
            return true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "配置文件(*.xml)|*.xml";
            openDialog.Multiselect = false;
            if (openDialog.ShowDialog() == DialogResult.OK)
                this.ReadConfigFile(openDialog.FileName);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.tpNds.TabPages.Contains(this.tpMdsConfig))
            {
                string szDbType = GlobalMethods.Security.EncryptText(this.cboMdsDbType.Text, CONFIG_ENCRYPT_KEY);
                string szDbDriverType = GlobalMethods.Security.EncryptText(this.cboMdsDbProvider.Text, CONFIG_ENCRYPT_KEY);
                string szConnectionString = GlobalMethods.Security.EncryptText(this.cboMdsConnString.Text, CONFIG_ENCRYPT_KEY);
                string szOcxConnectionString = GlobalMethods.Security.EncryptText(this.cboOcxConnString.Text, CONFIG_ENCRYPT_KEY);
                SystemConfig.Instance.Write(MainForm.MDS_DB_TYPE, szDbType);
                SystemConfig.Instance.Write(MainForm.MDS_PROVIDER_TYPE, szDbDriverType);
                SystemConfig.Instance.Write(MainForm.MDS_CONN_STRING, szConnectionString);
                SystemConfig.Instance.Write(MainForm.OCX_CONNECTION_STRING, szOcxConnectionString);
            }
            if (this.tpNds.TabPages.Contains(this.tpXdbConfig))
            {
                string szDbType = GlobalMethods.Security.EncryptText(this.cboXdbDbType.Text, CONFIG_ENCRYPT_KEY);
                string szDbDriverType = GlobalMethods.Security.EncryptText(this.cboXdbDbProvider.Text, CONFIG_ENCRYPT_KEY);
                string szConnectionString = GlobalMethods.Security.EncryptText(this.cboXdbConnString.Text, CONFIG_ENCRYPT_KEY);
                SystemConfig.Instance.Write(MainForm.XDB_DB_TYPE, szDbType);
                SystemConfig.Instance.Write(MainForm.XDB_PROVIDER_TYPE, szDbDriverType);
                SystemConfig.Instance.Write(MainForm.XDB_CONN_STRING, szConnectionString);
            }
            if (this.tpNds.TabPages.Contains(this.tpNdsConfig))
            {
                string szDbType = GlobalMethods.Security.EncryptText(this.cboNdsDbType.Text, CONFIG_ENCRYPT_KEY);
                string szDbDriverType = GlobalMethods.Security.EncryptText(this.cboNdsDbProvider.Text, CONFIG_ENCRYPT_KEY);
                string szConnectionString = GlobalMethods.Security.EncryptText(this.cboNdsConnString.Text, CONFIG_ENCRYPT_KEY);
               
                SystemConfig.Instance.Write(MainForm.NDS_DB_TYPE, szDbType);
                SystemConfig.Instance.Write(MainForm.NDS_PROVIDER_TYPE, szDbDriverType);
                SystemConfig.Instance.Write(MainForm.NDS_CONN_STRING, szConnectionString);
            }
            if (this.tpNds.TabPages.Contains(this.tpHisConfig))
            {
                string szDbType = GlobalMethods.Security.EncryptText(this.cboHisDbType.Text, CONFIG_ENCRYPT_KEY);
                string szDbDriverType = GlobalMethods.Security.EncryptText(this.cboHisDbProvider.Text, CONFIG_ENCRYPT_KEY);
                string szConnectionString = GlobalMethods.Security.EncryptText(this.cboHisConnString.Text, CONFIG_ENCRYPT_KEY);

                SystemConfig.Instance.Write(MainForm.HIS_DB_TYPE, szDbType);
                SystemConfig.Instance.Write(MainForm.HIS_PROVIDER_TYPE, szDbDriverType);
                SystemConfig.Instance.Write(MainForm.HIS_CONN_STRING, szConnectionString);
            }
            if (this.tpNds.TabPages.Contains(this.tpMedQC))
            {
                string szDbType = GlobalMethods.Security.EncryptText(this.cboQcDbType.Text, CONFIG_ENCRYPT_KEY);
                string szDbDriverType = GlobalMethods.Security.EncryptText(this.cboQcProvider.Text, CONFIG_ENCRYPT_KEY);
                string szConnectionString = GlobalMethods.Security.EncryptText(this.cboQcConnString.Text, CONFIG_ENCRYPT_KEY);

                SystemConfig.Instance.Write(MainForm.QC_DB_TYPE, szDbType);
                SystemConfig.Instance.Write(MainForm.QC_PROVIDER_TYPE, szDbDriverType);
                SystemConfig.Instance.Write(MainForm.QC_CONN_STRING, szConnectionString);
            }
            MessageBox.Show("配置保存完成!", "系统配置", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}