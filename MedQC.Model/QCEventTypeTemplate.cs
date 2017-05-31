using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public class QCEventTypeTemplate
    {
        /// <summary>
        /// 是否是一级问题
        /// </summary>
        bool m_IsParent;
        List<EMRDBLib.QcMsgDict> lstQCMessageTemplets = new List<QcMsgDict>();
        private List<QCEventTypeTemplate> lstQCEventTypeTemplate = new List<QCEventTypeTemplate>();
        private EMRDBLib.QaEventTypeDict m_qcEventType;
        /// <summary>
        /// 是否是一级问题
        /// </summary>
        public bool IsParent
        {
            get { return m_IsParent; }
            set { m_IsParent = value; }
        }

        public List<QcMsgDict> LstQcMessageTemplets
        {
            get { return lstQCMessageTemplets; }
            set { lstQCMessageTemplets = value; }
        }

        public List<QCEventTypeTemplate> LstQCEventTypeTemplate
        {
            get { return lstQCEventTypeTemplate; }
            set { lstQCEventTypeTemplate = value; }
        }

        public QaEventTypeDict QcEventType
        {
            get { return m_qcEventType; }
            set { m_qcEventType = value; }
        }
    }

}
