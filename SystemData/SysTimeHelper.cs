// ***********************************************************
// 系统内部时钟维护辅助类.获取时间时尽量减少与服务器的交互
// Creator:YangMingkun  Date:2009-7-6
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace MedDocSys.DataLayer
{
    /// <summary>
    /// 维护系统内部时钟，获取时间时尽量减少与服务器的交互
    /// </summary>
    public class SysTimeHelper : IDisposable
    {
        private System.Windows.Forms.Timer m_Timer = null;
        private DateTime m_dtDefaultTime;
        private DateTime m_dtLastSyncTime;

        /// <summary>
        /// 禁止外部实例化
        /// </summary>
        private SysTimeHelper()
        {
            this.m_dtDefaultTime = DateTime.Parse("1900-1-1");
            this.m_dtNow = this.m_dtDefaultTime;
            this.m_dtLastSyncTime = this.m_dtDefaultTime;
        }

        private static SysTimeHelper m_TimerHelper = null;
        /// <summary>
        /// 获取SysTimeHelper实例
        /// </summary>
        public static SysTimeHelper Instance
        {
            get
            {
                if (m_TimerHelper == null)
                    m_TimerHelper = new SysTimeHelper();
                return m_TimerHelper;
            }
        }

        private DateTime m_dtNow;
        /// <summary>
        /// 获取或设置当前时间
        /// </summary>
        public DateTime Now
        {
            get
            {
                if (!this.m_bAutoSyncEnabled || this.m_Timer == null)
                    this.SyncTime();
                else if (this.m_dtNow.CompareTo(this.m_dtDefaultTime) == 0)
                    this.SyncTime();
                if (this.m_Timer == null && this.m_bAutoSyncEnabled)
                    this.InstallTimer();
                return this.m_dtNow;
            }
        }

        private bool m_bAutoSyncEnabled = true;
        /// <summary>
        /// 获取或设置是否激活定时同步功能
        /// </summary>
        public bool AutoSyncEnabled
        {
            get { return this.m_bAutoSyncEnabled; }
            set
            {
                this.m_bAutoSyncEnabled = value;
                if (!this.m_bAutoSyncEnabled)
                {
                    this.CloseTimer();
                }
                else
                {
                    this.SyncTime();
                    this.InstallTimer();
                }
            }
        }

        private int m_nAutoSyncInterval = 24;
        /// <summary>
        /// 获取或设置与服务器时间同步间隔时长(单位:小时)
        /// </summary>
        public int AutoSyncInterval
        {
            get { return this.m_nAutoSyncInterval; }
            set { this.m_nAutoSyncInterval = value; }
        }

        public void Dispose()
        {
            this.CloseTimer();
        }

        private void CloseTimer()
        {
            if (this.m_Timer != null)
            {
                this.m_Timer.Tick -= new EventHandler(this.Timer_Tick);
                this.m_Timer.Stop();
                this.m_Timer.Dispose();
                this.m_Timer = null;
            }
            this.m_bAutoSyncEnabled = false;
        }

        public void SyncTime()
        {
            DataAccess.GetServerTime(ref this.m_dtNow);
            this.m_dtLastSyncTime = this.m_dtNow;
        }

        private void InstallTimer()
        {
            this.m_Timer = new System.Windows.Forms.Timer();
            this.m_Timer.Interval = 1000;
            this.m_Timer.Tick += new EventHandler(this.Timer_Tick);
            this.m_Timer.Start();
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            this.m_dtNow = this.m_dtNow.AddSeconds(1);
            DateTime dtNextSyncTime = this.m_dtLastSyncTime.AddHours(this.m_nAutoSyncInterval);
            if (this.m_dtNow.CompareTo(dtNextSyncTime) >= 0)
                this.SyncTime();
        }
    }
}
