using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{



    /// <summary>
    /// 医嘱信息类
    /// </summary>
    [System.Serializable]
    public class MedOrderInfo : DbTypeBase
    {
        private bool m_bIsRepeat = false;
        /// <summary>
        /// 获取或设置长期/临时医嘱
        /// </summary>
        public bool IsRepeat
        {
            get { return this.m_bIsRepeat; }
            set { this.m_bIsRepeat = value; }
        }

        private string m_szOrderNO = string.Empty;
        /// <summary>
        /// 获取或设置医嘱号
        /// </summary>
        public string OrderNO
        {
            get { return this.m_szOrderNO; }
            set { this.m_szOrderNO = value; }
        }

        private string m_szOrderSubNO = string.Empty;
        /// <summary>
        /// 获取或设置子医嘱号
        /// </summary>
        public string OrderSubNO
        {
            get { return this.m_szOrderSubNO; }
            set { this.m_szOrderSubNO = value; }
        }

        private string m_szOrderClass = string.Empty;
        /// <summary>
        /// 获取或设置医嘱类别
        /// </summary>
        public string OrderClass
        {
            get { return this.m_szOrderClass; }
            set { this.m_szOrderClass = value; }
        }

        private string m_szOrderText = string.Empty;
        /// <summary>
        /// 获取或设置医嘱内容
        /// </summary>
        public string OrderText
        {
            get { return this.m_szOrderText; }
            set { this.m_szOrderText = value; }
        }

        private DateTime m_dtEnterTime = DateTime.Now;
        /// <summary>
        /// 获取或设置医嘱下达时间
        /// </summary>
        public DateTime EnterTime
        {
            get { return this.m_dtEnterTime; }
            set { this.m_dtEnterTime = value; }
        }

        private DateTime m_dtStopTime = DateTime.MinValue;
        /// <summary>
        /// 获取或设置医嘱停止时间
        /// </summary>
        public DateTime StopTime
        {
            get { return this.m_dtStopTime; }
            set { this.m_dtStopTime = value; }
        }

        private string m_szDrugBillingAttr = string.Empty;
        /// <summary>
        /// 获取或设置是否自带
        /// </summary>
        public string DrugBillingAttr
        {
            get { return this.m_szDrugBillingAttr; }
            set { this.m_szDrugBillingAttr = value; }
        }

        private float m_fDosage = 0;
        /// <summary>
        /// 获取或设置剂量
        /// </summary>
        public float Dosage
        {
            get { return this.m_fDosage; }
            set { this.m_fDosage = value; }
        }

        private string m_szDosageUnits = string.Empty;
        /// <summary>
        /// 获取或设置单位
        /// </summary>
        public string DosageUnits
        {
            get { return this.m_szDosageUnits; }
            set { this.m_szDosageUnits = value; }
        }

        private string m_szAdministration = string.Empty;
        /// <summary>
        /// 获取或设置途径
        /// </summary>
        public string Administration
        {
            get { return this.m_szAdministration; }
            set { this.m_szAdministration = value; }
        }

        private string m_szFrequency = string.Empty;
        /// <summary>
        /// 获取或设置频次
        /// </summary>
        public string Frequency
        {
            get { return this.m_szFrequency; }
            set { this.m_szFrequency = value; }
        }

        private string m_szFreqDetail = string.Empty;
        /// <summary>
        /// 获取或设置医生说明
        /// </summary>
        public string FreqDetail
        {
            get { return this.m_szFreqDetail; }
            set { this.m_szFreqDetail = value; }
        }

        private string m_szPackCount = string.Empty;
        /// <summary>
        /// 获取或设置带药量
        /// </summary>
        public string PackCount
        {
            get { return this.m_szPackCount; }
            set { this.m_szPackCount = value; }
        }

        private string m_szDoctor = string.Empty;
        /// <summary>
        /// 获取或设置医生
        /// </summary>
        public string Doctor
        {
            get { return this.m_szDoctor; }
            set { this.m_szDoctor = value; }
        }

        private string m_szNurse = string.Empty;
        /// <summary>
        /// 获取或设置护士
        /// </summary>
        public string Nurse
        {
            get { return this.m_szNurse; }
            set { this.m_szNurse = value; }
        }

        private bool m_bIsStartStop = false;
        /// <summary>
        /// 获取或设置新开停止医嘱标志
        /// </summary>
        public bool IsStartStop
        {
            get { return this.m_bIsStartStop; }
            set { this.m_bIsStartStop = value; }
        }

        private string m_szOrderStatus = string.Empty;
        /// <summary>
        /// 获取或设置医嘱状态
        /// </summary>
        public string OrderStatus
        {
            get { return this.m_szOrderStatus; }
            set { this.m_szOrderStatus = value; }
        }

        private string m_szOrderFlag = string.Empty;
        /// <summary>
        /// 获取或设置医嘱标识
        /// </summary>
        public string OrderFlag
        {
            get { return this.m_szOrderFlag; }
            set { this.m_szOrderFlag = value; }
        }

        private string m_szOrderTypeName = string.Empty;
        /// <summary>
        /// 获取或设置医嘱类型名称
        /// </summary>
        public string OrderTypeName
        {
            get { return this.m_szOrderTypeName; }
            set { this.m_szOrderTypeName = value; }
        }

        public MedOrderInfo()
        {
            this.m_dtEnterTime = this.DefaultTime;
            this.m_dtStopTime = this.DefaultTime;
        }
    }

}
