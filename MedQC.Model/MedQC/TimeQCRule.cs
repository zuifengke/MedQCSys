using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.Entity
{
    /// <summary>
    /// 病历时效规则配置信息类
    /// </summary>
    [System.Serializable]
    public class TimeQCRule : DbTypeBase
    {
        private string m_szRuleID = null;
        private string m_szDocTypeID = null;
        private string m_szDocTypeName = null;
        private string m_szDocTypeAlias = null;
        private bool m_bIsValid = true;
        private string m_szEventID = null;
        private string m_szEventName = null;
        private string m_szWrittenPeriod = null;
        private bool m_bIsRepeat = false;
        private float m_fQCScore = 0f;
        private int m_nOrderValue = 0;
        private string m_szRuleDesc = null;
        private DateTime m_dtValidateTime;
        private bool m_bIsStopRight = false;
        private bool m_bIsVeto = false;

        /// <summary>
        /// 获取或设置配置ID
        /// </summary>
        public string RuleID
        {
            get { return this.m_szRuleID; }
            set { this.m_szRuleID = value; }
        }

        /// <summary>
        /// 获取或设置发生事件时应完成文档类型ID号列表,";"隔开
        /// </summary>
        public string DocTypeID
        {
            get { return this.m_szDocTypeID; }
            set { this.m_szDocTypeID = value; }
        }

        /// <summary>
        /// 获取或设置发生事件时应完成文档类型名称列表,";"隔开
        /// </summary>
        public string DocTypeName
        {
            get { return this.m_szDocTypeName; }
            set { this.m_szDocTypeName = value; }
        }

        /// <summary>
        /// 获取或设置发生事件时应完成文档类型名别名
        /// </summary>
        public string DocTypeAlias
        {
            get { return this.m_szDocTypeAlias; }
            set { this.m_szDocTypeAlias = value; }
        }

        /// <summary>
        /// 获取或设置是否启用此时效，true启用，false不启用
        /// </summary>
        public bool IsValid
        {
            get { return this.m_bIsValid; }
            set { this.m_bIsValid = value; }
        }

        /// <summary>
        /// 获取或设置关联事件CODE
        /// </summary>
        public string EventID
        {
            get { return this.m_szEventID; }
            set { this.m_szEventID = value; }
        }

        /// <summary>
        /// 获取或设置关联事件名称(调用层自行初始化)
        /// </summary>
        public string EventName
        {
            get { return this.m_szEventName; }
            set { this.m_szEventName = value; }
        }

        /// <summary>
        /// 获取或设置最晚完成时间，如：24H表示，开始书写时间后24小时内。
        /// </summary>
        public string WrittenPeriod
        {
            get { return this.m_szWrittenPeriod; }
            set { this.m_szWrittenPeriod = value; }
        }

        /// <summary>
        /// 获取或设置是否循环检查时效
        /// </summary>
        public bool IsRepeat
        {
            get { return this.m_bIsRepeat; }
            set { this.m_bIsRepeat = value; }
        }

        /// <summary>
        /// 获取或设置质控扣分
        /// </summary>
        public float QCScore
        {
            get { return this.m_fQCScore; }
            set { this.m_fQCScore = value; }
        }

        /// <summary>
        /// 获取或设置排序序号
        /// </summary>
        public int OrderValue
        {
            get { return this.m_nOrderValue; }
            set { this.m_nOrderValue = value; }
        }

        /// <summary>
        /// 获取或设置时效定义名称描述字符串
        /// </summary>
        public string RuleDesc
        {
            get { return this.m_szRuleDesc; }
            set { this.m_szRuleDesc = value; }
        }
        /// <summary>
        /// 获取或设置规则有效截止时间
        /// <para>对于已出院病人，在监控时规则无效</para>
        /// </summary>
        public DateTime ValidateTime
        {
            get { return this.m_dtValidateTime; }
            set { this.m_dtValidateTime = value; }
        }

        /// <summary>
        /// 获取或设置是否启用此时效，true启用，false不启用
        /// </summary>
        public bool IsStopRight
        {
            get { return this.m_bIsStopRight; }
            set { this.m_bIsStopRight = value; }
        }
        /// <summary>
        /// 单项否决
        /// </summary>
        public bool IsVeto
        {
            get { return m_bIsVeto; }
            set { m_bIsVeto = value; }
        }

        public override string ToString()
        {
            return this.m_szRuleDesc;
        }

        public string MakeRuleID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("R{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
        
    }
}
