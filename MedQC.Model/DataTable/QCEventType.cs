using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 病案质量问题分类
    /// </summary>
    public class QaEventTypeDict : DbTypeBase
    {
       
        private string m_szQaEventType = string.Empty;     //问题分类
        private string m_szInputCode = string.Empty;    //输入码
        private string m_szParnetCode = string.Empty;   //上级代码
        private double m_szMaxScore = 0.0;     //扣分上限
        public string APPLY_ENV { get; set; }
        /// <summary>
        /// 上级输入码
        /// </summary>
        public string PARENT_CODE
        {
            get { return m_szParnetCode; }
            set { m_szParnetCode = value; }
        }

        /// <summary>
        /// 扣分上限
        /// </summary>
        public double MAX_SCORE
        {
            get { return m_szMaxScore; }
            set { m_szMaxScore = value; }
        }
        /// <summary>
        /// 获取或设置序号
        /// </summary>
        public int SERIAL_NO { get; set; }
        /// <summary>
        /// 获取或设置问题分类
        /// </summary>
        public string QA_EVENT_TYPE
        {
            get { return this.m_szQaEventType; }
            set { this.m_szQaEventType = value; }
        }
        /// <summary>
        /// 获取或设置输入码
        /// </summary>
        public string INPUT_CODE
        {
            get { return this.m_szInputCode; }
            set { this.m_szInputCode = value; }
        }

        public override string ToString()
        {
            return this.m_szQaEventType;
        }
    }
}
