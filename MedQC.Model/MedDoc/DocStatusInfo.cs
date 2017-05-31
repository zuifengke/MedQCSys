using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{


    /// <summary>
    /// 文档状态信息类
    /// </summary>
    [System.Serializable]
    public class DocStatusInfo : DbTypeBase
    {
        private string m_szDocID = string.Empty;            //文档编号
        private string m_szDocStatus = string.Empty;        //文档类型代码
        private string m_szOperatorID = string.Empty;       //文档标题
        private string m_szOperatorName = string.Empty;     //文档集编号
        private DateTime m_dtOperateTime = DateTime.Now;    //文档创建时间
        private string m_szStatusDesc = string.Empty;       //状态描述
        private string m_szStatusMessage = string.Empty;    //状态描述
        /// <summary>
        /// 获取或设置文档编号
        /// </summary>
        public string DocID
        {
            get { return this.m_szDocID; }
            set { this.m_szDocID = value; }
        }
        /// <summary>
        /// 获取或设置文档状态
        /// </summary>
        public string DocStatus
        {
            get { return this.m_szDocStatus; }
            set { this.m_szDocStatus = value; }
        }
        /// <summary>
        /// 获取或设置操作者ID
        /// </summary>
        public string OperatorID
        {
            get { return this.m_szOperatorID; }
            set { this.m_szOperatorID = value; }
        }
        /// <summary>
        /// 获取或设置操作者姓名
        /// </summary>
        public string OperatorName
        {
            get { return this.m_szOperatorName; }
            set { this.m_szOperatorName = value; }
        }
        /// <summary>
        /// 获取或设置操作时间
        /// </summary>
        public DateTime OperateTime
        {
            get { return this.m_dtOperateTime; }
            set { this.m_dtOperateTime = value; }
        }
        /// <summary>
        /// 获取或设置文档状态描述
        /// </summary>
        public string StatusDesc
        {
            get { return this.m_szStatusDesc; }
            set { this.m_szStatusDesc = value; }
        }
        /// <summary>
        /// 获取或设置用于返回的文档状态消息
        /// </summary>
        public string StatusMessage
        {
            get { return this.m_szStatusMessage; }
            set { this.m_szStatusMessage = value; }
        }

        public DocStatusInfo()
        {
            this.m_dtOperateTime = this.DefaultTime;
        }
    }
}
