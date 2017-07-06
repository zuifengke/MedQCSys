using EMRDBLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MedQCSys.PatPage
{
    public class PatientInfoChangingEventArgs : CancelEventArgs
    {
        private PatVisitInfo m_currPatVisit = null;

        /// <summary>
        /// 获取被改变的病人信息
        /// </summary>
        public PatVisitInfo CurrPatVisit
        {
            get { return this.m_currPatVisit; }
        }

        private PatVisitInfo m_newPatVisit = null;

        /// <summary>
        /// 获取即将要改变的病人信息
        /// </summary>
        public PatVisitInfo NewPatVisit
        {
            get { return this.m_newPatVisit; }
        }

        public PatientInfoChangingEventArgs(PatVisitInfo currPatVisit, PatVisitInfo newPatVisit)
        {
            this.Cancel = false;
            this.m_currPatVisit = currPatVisit;
            this.m_newPatVisit = newPatVisit;
        }
    }

    public delegate void PatientInfoChangingEventHandler(object sender, PatientInfoChangingEventArgs e);
}
