using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.Entity
{
    #region"TimeQCEvent"
    /// <summary>
    /// 病历时效事件源信息类
    /// </summary>
    [System.Serializable]
    public class TimeQCEvent : EMRDBLib.DbTypeBase
    {
        private string m_szEventID = null;
        private string m_szEventName = null;
        private string m_szSqlText = null;
        private string m_szSqlCondition = null;
        private string m_szDependEvent = null;
        private string m_szDependEventName = null;

        /// <summary>
        /// 获取或设置事件编号
        /// </summary>
        public string EventID
        {
            get { return this.m_szEventID; }
            set { this.m_szEventID = value; }
        }

        /// <summary>
        /// 获取或设置事件名称
        /// </summary>
        public string EventName
        {
            get { return this.m_szEventName; }
            set { this.m_szEventName = value; }
        }

        /// <summary>
        /// 获取或设置配置的事件源SQL语句
        /// </summary>
        public string SqlText
        {
            get { return this.m_szSqlText; }
            set { this.m_szSqlText = value; }
        }

        /// <summary>
        /// 获取或设置SQL字符串中的条件
        /// </summary>
        public string SqlCondition
        {
            get { return this.m_szSqlCondition; }
            set { this.m_szSqlCondition = value; }
        }

        /// <summary>
        /// 获取或设置依赖事件编号
        /// </summary>
        public string DependEvent
        {
            get { return this.m_szDependEvent; }
            set { this.m_szDependEvent = value; }
        }

        /// <summary>
        /// 获取或设置依赖事件名称(调用层自行初始化)
        /// </summary>
        public string DependEventName
        {
            get { return this.m_szDependEventName; }
            set { this.m_szDependEventName = value; }
        }

        public override string ToString()
        {
            return this.m_szEventName;
        }

        /// <summary>
        /// 生成新的编号
        /// </summary>
        /// <returns>新编号</returns>
        public string MakeEventID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("E{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
    #endregion
}
