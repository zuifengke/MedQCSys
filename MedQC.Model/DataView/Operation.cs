using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 手术记录
    /// </summary>
    public class Operation : DbTypeBase
    {
        public string PatientID { get; set; }
        public int VisitID { get; set; }
        public string PatientName { get; set; }
        public string PATIENT_SEX { get; set; }
        public string BedNo { get; set; }
        public string SECOND_ASSISTANT { get; set; }
        
        public string Sex { get; set; }
        public string Diagnosis { get; set; }
        public string DeptName { get; set; }
        public string FIRST_ASSISTANT { get; set; }
        
        public string DEPT_CODE { get; set; }
        public int OperationNo { get; set; }
        public string Age { get; set; }
        public string OperationDesc { get; set; }
        public string OperationCode { get; set; }
        public string Heal { get; set; }
        public string WoundGrade { get; set; }
        public DateTime OperationDate { get; set; }
        public string AnaesthesiaMethod { get; set; }
        public string Operator { get; set; }
        public string ANESTHESIA_DOCTOR { get; set; }

    }
}
