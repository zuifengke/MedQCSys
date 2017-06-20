using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 质控反馈信息模板类
    /// </summary>
    public class QcMsgDict : DbTypeBase
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int OrderNo { get; set; }
        private string m_szSerialNo = string.Empty;      //序号
        private string m_szQCMsgCode = string.Empty;     //反馈信息代码
        private string m_szQaEventType = string.Empty;   //问题分类
        private string m_szMessage = string.Empty;       //信息描述
        private string m_szMessageTitle = string.Empty;  //信息标题
        private string m_szScore = string.Empty;         //扣分
        private string m_szHosScore = string.Empty;      //科室扣分
        private string m_szInputCode = string.Empty;     //输入码
        private bool m_IsVeto = false;          //是否单项否决
        private int m_QCDocType = 0;//病历类型,在院病历，出院病历，死亡病历
        /// <summary>
        /// 获取或设置序号
        /// </summary>
        public int SERIAL_NO { get; set; }
        /// <summary>
        /// 获取或设置反馈信息代码
        /// </summary>
        public string QC_MSG_CODE { get; set; }
        /// <summary>
        /// 病历类型在院病历，出院病历，死亡病历
        /// </summary>
        public int QCDocType
        {
            get { return this.m_QCDocType; }
            set { this.m_QCDocType = value; }
        }
        /// <summary>
        /// 获取或设置问题分类
        /// </summary>
        public string QA_EVENT_TYPE { get; set; }
        /// <summary>
        /// 获取或设置信息描述
        /// </summary>
        public string MESSAGE { get; set; }
        /// <summary>
        /// 获取或设置信息标题
        /// </summary>
        public string MESSAGE_TITLE { get; set; }
        /// <summary>
        /// 获取或设置扣分
        /// </summary>
        public float SCORE { get; set; }
        /// <summary>
        /// 获取或设置全院扣分
        /// </summary>
        public string HosScore { get; set; }
        /// <summary>
        /// 获取或设置输入码
        /// </summary>
        public string INPUT_CODE { get; set; }

        /// <summary>
        /// 是否单项否决
        /// </summary>
        public bool ISVETO { get; set; }
        public string APPLY_ENV { get; set; }
        public QcMsgDict()
        {
            this.MESSAGE_TITLE = string.Empty;
            this.MESSAGE = string.Empty;
        }
        public override string ToString()
        {
            return this.MESSAGE;
        }
    }
}
