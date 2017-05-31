using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 病人责任医师信息类
    /// </summary>
    [System.Serializable]
    public class PatDoctorInfo : DbTypeBase
    {
        //public PatDoctorInfo();
        private string sz_PatientID = string.Empty;
        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientID
        {
            get
            {
                return this.sz_PatientID;
            }
            set
            {
                this.sz_PatientID = value;
            }
        }

        private string sz_PatientName = string.Empty;
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName
        {
            get
            { return this.sz_PatientName; }
            set
            {
                this.sz_PatientName = value;
            }
        }

        private string sz_VisitID = string.Empty;
        /// <summary>
        /// 就诊ID
        /// </summary>
        public string VisitID
        {
            get
            {
                return this.sz_VisitID;
            }
            set
            {
                this.sz_VisitID = value;
            }
        }

        private DateTime dtVisitTime = DateTime.Parse("1900-1-1");

        /// <summary>
        /// 入院时间
        /// </summary>
        public DateTime VisitTime
        {
            get
            {
                return this.dtVisitTime;
            }
            set
            {
                this.dtVisitTime = value;
            }
        }

        private string szDeptCode = string.Empty;
        /// <summary>
        /// 责任医师科室（经治医师）
        /// </summary>
        public string DeptCode
        {
            get
            {
                return this.szDeptCode;
            }
            set
            {
                this.szDeptCode = value;
            }
        }

        private string szDischarge_DeptCode = string.Empty;
        /// <summary>
        /// 出院科室
        /// </summary>
        public string DischargeDeptCode
        {
            get
            {
                return this.szDischarge_DeptCode;
            }
            set
            {
                this.szDischarge_DeptCode = value;
            }
        }

        private DateTime dtDisChargeTime = DateTime.Parse("1900-1-1");
        /// <summary>
        /// 出院时间
        /// </summary>
        public DateTime DischargeTime
        {
            get
            {
                return this.dtDisChargeTime;
            }
            set
            {
                this.dtDisChargeTime = value;
            }
        }

        private string szRequestDoctorID = string.Empty;
        /// <summary>
        /// 获取或设置经治医师ID
        /// </summary>
        public string RequestDoctorID
        {
            get
            {
                return this.szRequestDoctorID;
            }
            set
            {
                this.szRequestDoctorID = value;
            }
        }

        private string szRequestDoctorName = string.Empty;
        /// <summary>
        /// 获取或设置经治医师姓名
        /// </summary>
        public string RequestDoctorName
        {
            get
            {
                return this.szRequestDoctorName;
            }
            set
            {
                this.szRequestDoctorName = value;
            }
        }

        private string szParentDoctorID = string.Empty;
        /// <summary>
        /// 获取或设置上级医师ID
        /// </summary>
        public string ParentDoctorID
        {
            get
            {
                return this.szParentDoctorID;
            }
            set
            {
                this.szParentDoctorID = value;
            }
        }

        private string szParentDoctorName = string.Empty;
        /// <summary>
        /// 获取或设置上级医师姓名
        /// </summary>
        public string ParentDoctorName
        {
            get
            {
                return this.szParentDoctorName;
            }
            set
            {
                this.szParentDoctorName = value;
            }
        }
        private string szSuperDoctorID = string.Empty;

        /// <summary>
        /// 主治医生ID
        /// </summary>
        public string SuperDoctorID
        {
            get { return szSuperDoctorID; }
            set { szSuperDoctorID = value; }
        }

        private string szSuperDoctorName = string.Empty;
        /// <summary>
        /// 主任医师姓名
        /// </summary>
        public string SuperDoctorName
        {
            get
            {
                return this.szSuperDoctorName;
            }
            set
            {
                this.szSuperDoctorName = value;
            }
        }
    }
}
