using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MedDocSys.QCEngine.TimeCheck;
using Heren.Common.Libraries;
using Heren.MedQC.TimeCheckGener;
using Heren.MedQC.TimeCheckGener.Forms;
using EMRDBLib;

namespace MedQC.TimeCheckGener
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.mainStatusStrip1.MainForm = this;
            //时效内容配置绑定
            string szStartTime = SystemConfig.Instance.Get(SystemData.ConfigKey.TIME_RECORD_START_TIME, string.Empty);
            if (szStartTime != string.Empty
                && szStartTime.Split(':').Length == 2)
            {
                this.nudQCBeginHour.Value = Decimal.Parse(szStartTime.Split(':')[0]);
                this.nudQCBeginMinute.Value = Decimal.Parse(szStartTime.Split(':')[1]);
            }
            this.nudNormalDisCharge.Value = SystemConfig.Instance.Get(SystemData.ConfigKey.TIME_RECORD_DISCHARGE_DAYS, 3);
            this.chkTimeCheckRunning.Checked = SystemConfig.Instance.Get(SystemData.ConfigKey.TIME_CHECK_RUNNING, false);

            //内容内容配置绑定
            szStartTime = SystemConfig.Instance.Get(Config.BugStartTime, string.Empty);
            if (szStartTime != string.Empty
                && szStartTime.Split(':').Length == 2)
            {
                this.nudBugBeginHour.Value = Decimal.Parse(szStartTime.Split(':')[0]);
                this.nudBugBeginMinute.Value = Decimal.Parse(szStartTime.Split(':')[1]);
            }
            this.chkContentCheckRunning.Checked= SystemConfig.Instance.Get(SystemData.ConfigKey.CONTENT_RECORD_RUNNING, false);

        }

        /// <summary>
        /// 显示状态栏信息
        /// </summary>
        /// <param name="szMessage"></param>
        internal void ShowStatusMessage(int nDataIndex, string szMessage, string szCheckType)
        {
            if (szCheckType == CheckType.TimeCheck)
                this.QCProgressBar.Value = nDataIndex;
            else if (szCheckType == CheckType.BugCheck)
                this.BugProgressBar.Value = nDataIndex;
            this.mainStatusStrip1.ShowStatusMessage(szMessage);
        }
        private bool m_bTimerRunning = false;
        private string m_szQCStartTime = string.Empty;
        /// <summary>
        /// 时效开始检查时间
        /// </summary>
        public string QCStartTime
        {
            get
            {
                return this.m_szQCStartTime;
            }
        }

        private string m_szBugStartTime = string.Empty;
        /// <summary>
        /// 内容开始检查时间
        /// </summary>
        public string BugStartTime
        {
            get
            {
                return this.m_szBugStartTime;
            }
        }
        private string m_szDischargeDays = string.Empty;
        public string DischargeDays
        {
            get
            {
                return this.m_szDischargeDays;
            }
        }

        private bool m_szContentRecordRunning = false;
        public bool ContentRecordRunning
        {
            get
            {
                return this.m_szContentRecordRunning;
            }
        }

        private int m_szDocContentDay =1;
        public int DocContentDay
        {
            get
            {
                return this.m_szDocContentDay;
            }
        }
        /// <summary>
        /// 是否开启病历时效检查
        /// </summary>
        public bool bTimeCheckRunning
        {
            get
            {
                return this.chkTimeCheckRunning.Checked;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!this.m_bTimerRunning)
            {
                //时效配置保存
                this.m_szQCStartTime = string.Format("{0}:{1}", this.nudQCBeginHour.Value.ToString(), this.nudQCBeginMinute.Value.ToString());
                this.m_szDischargeDays = this.nudNormalDisCharge.Value.ToString();
                if (!SystemConfig.Instance.Write(SystemData.ConfigKey.TIME_RECORD_START_TIME, this.m_szQCStartTime)
                    || !SystemConfig.Instance.Write(SystemData.ConfigKey.TIME_RECORD_DISCHARGE_DAYS, this.m_szDischargeDays)
                    || !SystemConfig.Instance.Write(SystemData.ConfigKey.TIME_CHECK_RUNNING, this.chkTimeCheckRunning.Checked.ToString()))
                {
                    MessageBoxEx.Show("时效检查设定失败！");
                }
                //内容配置保存
                this.m_szBugStartTime = string.Format("{0}:{1}", this.nudBugBeginHour.Value.ToString(), this.nudBugBeginMinute.Value.ToString());
                this.m_szDocContentDay = int.Parse(this.nudDocContentDay.Value.ToString()) ;
                this.m_szContentRecordRunning = this.chkContentCheckRunning.Checked;
                if (!SystemConfig.Instance.Write(Config.BugStartTime, this.m_szBugStartTime)
                    || !SystemConfig.Instance.Write(SystemData.ConfigKey.CONTENT_RECORD_RUNNING, this.m_szContentRecordRunning.ToString())
                    )
                {
                    MessageBoxEx.Show("内容质控生成时间设定失败！");
                    return;
                }

                SetPlanState(false);
            }
            else
            {
                SetPlanState(true);
            }
        }

        private void SetPlanState(bool bState)
        {
            if (!bState)
            {
                this.mainStatusStrip1.Start();
                this.btnStart.Text = "停止";
            }
            else
            {
                this.mainStatusStrip1.Stop();
                this.btnStart.Text = "启动";
            }

            this.m_bTimerRunning = !bState;
            this.nudQCBeginHour.Enabled = bState;
            this.nudQCBeginMinute.Enabled = bState;
            this.nudNormalDisCharge.Enabled = bState;
            this.nudBugBeginHour.Enabled = bState;
            this.nudBugBeginMinute.Enabled = bState;
        }


        internal void HandStartRun(int nPatCount,string szChekcType)
        {
            if(szChekcType==CheckType.TimeCheck)
            { 
            this.QCProgressBar.Maximum = nPatCount;
            this.QCProgressBar.Value = 0;
            this.QCProgressBar.Step = 1;
            }
            else if (szChekcType == CheckType.BugCheck)
            {
                this.BugProgressBar.Maximum = nPatCount;
                this.BugProgressBar.Value = 0;
                this.BugProgressBar.Step = 1;
            }
        }

        internal void EndStartRun(int nPatCount,string szCheckType)
        {
            string szType = szCheckType == CheckType.TimeCheck? "时效质控" : "内容质控";
            this.ShowStatusMessage(nPatCount, string.Format("{0}/{1} 本次{3}记录已生成.."
                , nPatCount.ToString(), nPatCount.ToString(),szType), szCheckType);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DocumentTimeForm form = new DocumentTimeForm();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DocBugCheckForm form = new DocBugCheckForm();
            form.ShowDialog();
        }
    }


}