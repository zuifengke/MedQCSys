using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 维护系统内部时钟，获取时间时尽量减少与服务器的交互
    /// </summary>
    public class SysTimeHelper : IDisposable
    {
        private SystemClock m_systemClock = null;
        /// <summary>
        /// 禁止外部实例化
        /// </summary>
        private SysTimeHelper()
        {
            SystemClock.SyncTimeCallback syncTimeCallback =
                new SystemClock.SyncTimeCallback(this.SyncTime);
            this.m_systemClock = new SystemClock(syncTimeCallback);
        }

        private static SysTimeHelper m_instance = null;
        /// <summary>
        /// 获取SysTimeHelper实例
        /// </summary>
        public static SysTimeHelper Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new SysTimeHelper();
                return m_instance;
            }
        }

        /// <summary>
        /// 获取或设置当前时间
        /// </summary>
        public DateTime Now
        {
            get { return this.m_systemClock.Now; }
        }
        public DateTime DefaultTime
        {
            get { return DateTime.Parse("1900-1-1"); }
                 
        }
        public void Dispose()
        {
            this.m_systemClock.Dispose();
        }

        private bool SyncTime(ref DateTime dtNow)
        {

            return EMRDBAccess.Instance.GetServerTime(ref dtNow) == SystemData.ReturnValue.OK;
        }

        public string DateDiff(string szMessage, DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            TimeSpan ts = DateTime1.Subtract(DateTime2).Duration();
            dateDiff = szMessage + "用时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒" + ts.Milliseconds + "毫秒";
            return dateDiff;
        }
    }
}
