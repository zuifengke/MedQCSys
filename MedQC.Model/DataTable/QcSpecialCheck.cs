using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    public class QcSpecialCheck : DbTypeBase
    {
        private string m_szConfigID = string.Empty;
        /// <summary>
        /// 抽检批次号
        /// </summary>
        public string ConfigID
        {
            get { return this.m_szConfigID; }
            set { this.m_szConfigID = value; }
        }
        private string m_szName = string.Empty;
        /// <summary>
        /// 名称
        /// </summary>
        public string Name
        {
            get { return this.m_szName; }
            set { this.m_szName = value; }
        }

        private DateTime m_dtStartTime;
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return this.m_dtStartTime; }
            set { this.m_dtStartTime = value; }
        }

        private DateTime m_dtEndTime;
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return this.m_dtEndTime; }
            set { this.m_dtEndTime = value; }
        }
        private string m_szPatientCondition = string.Empty;
        /// <summary>
        /// 病人病情
        /// </summary>
        public string PatientCondition
        {
            get { return this.m_szPatientCondition; }
            set { this.m_szPatientCondition = value; }
        }
        private string m_szDischargeMode = string.Empty;
        /// <summary>
        /// 出院方式
        /// </summary>
        public string DischargeMode
        {
            get { return this.m_szDischargeMode; }
            set { this.m_szDischargeMode = value; }
        }
        private int m_nPerCount;
        /// <summary>
        /// 每科室抽取
        /// </summary>
        public int PerCount
        {
            get { return this.m_nPerCount; }
            set { this.m_nPerCount = value; }
        }

        private int m_nPatientCount;
        /// <summary>
        /// 抽取的病案总数
        /// </summary>
        public int PatientCount
        {
            get { return this.m_nPatientCount; }
            set { this.m_nPatientCount = value; }
        }

        private int m_nSpecialCount;
        /// <summary>
        /// 参与的专家数量
        /// </summary>
        public int SpecialCount
        {
            get { return this.m_nSpecialCount; }
            set { this.m_nSpecialCount = value; }
        }
        private string m_szCreater;
        /// <summary>
        /// 创建人
        /// </summary>
        public string Creater
        {
            get { return this.m_szCreater; }
            set { this.m_szCreater = value; }
        }
        private DateTime m_dtCreateTime;
        /// <summary>
        /// 创建人
        /// </summary>
        public DateTime CreateTime
        {
            get { return this.m_dtCreateTime; }
            set { this.m_dtCreateTime = value; }
        }
        private bool b_Checked = false;
        /// <summary>
        /// 是否已完成质检
        /// </summary>
        public bool Checked
        {
            get { return this.b_Checked; }
            set { this.b_Checked = value; }
        }
        public string MakeConfigID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("R{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }

        public QcSpecialCheck()
        {
            this.m_dtStartTime = this.DefaultTime;
            this.m_dtEndTime = this.DefaultTime;
            this.m_dtCreateTime = this.DefaultTime;
        }
        public override string ToString()
        {
            return this.m_szName;
        }
    }


}
