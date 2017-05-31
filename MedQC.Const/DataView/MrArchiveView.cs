using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病案归档情况视图
        /// </summary>
        public struct MrArchiveView
        {
            /// <summary>
            /// 患者标识
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 就诊号
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 患者姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 患者性别
            /// </summary>
            public const string PATIENT_SEX = "PATIENT_SEX";
            /// <summary>
            /// 新军卫就诊流水号，其他HIS库字段值和Visit_ID一样
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 病案状态 反映病案的存贮状态：O-工作C-关闭 A-归档 F-脱机(目前只使用工作，关闭两个状态，工作为正常病历在线的状态，关闭则为病历已提交的状态)
            /// </summary>
            public const string MR_STATUS = "MR_STATUS";
            /// <summary>
            /// 病案类别
            /// </summary>
            public const string MR_CLASS = "MR_CLASS";
            /// <summary>
            /// 病案核对者
            /// </summary>
            public const string HOS_QCMAN = "HOS_QCMAN";
            /// <summary>
            /// 出院科室代码
            /// </summary>
            public const string DEPT_DISCHARGE_FROM = "DEPT_DISCHARGE_FROM";
            /// <summary>
            /// 出院科室名称
            /// </summary>
            public const string DEPT_DISCHARGE_NAME = "DEPT_DISCHARGE_NAME";
            /// <summary>
            /// 出院时间
            /// </summary>
            public const string DISCHARGE_DATE_TIME = "DISCHARGE_DATE_TIME";
            /// <summary>
            /// 入院时间
            /// </summary>
            public const string ADMISSION_DATE_TIME = "ADMISSION_DATE_TIME";
            /// <summary>
            /// 入院科室代码
            /// </summary>
            public const string DEPT_ADMISSION_TO = "DEPT_ADMISSION_TO";
            /// <summary>
            /// 入院科室名称
            /// </summary>
            public const string DEPT_ADMISSION_NAME = "DEPT_ADMISSION_NAME";
            /// <summary>
            /// 提交医生ID
            /// </summary>
            public const string SUBMIT_DOCTOR_ID = "SUBMIT_DOCTOR_ID";
            /// <summary>
            /// 提交医生
            /// </summary>
            public const string SUBMIT_DOCTOR = "SUBMIT_DOCTOR";
            /// <summary>
            /// 提交时间
            /// </summary>
            public const string SUBMIT_TIME = "SUBMIT_TIME";
            /// <summary>
            /// 归档时间
            /// </summary>
            public const string ARCHIVE_TIME = "ARCHIVE_TIME";
            /// <summary>
            /// 归档医生
            /// </summary>
            public const string ARCHIVE_DOCTOR = "ARCHIVE_DOCTOR";
            /// <summary>
            /// 归档医生ID
            /// </summary>
            public const string ARCHIVE_DOCTOR_ID = "ARCHIVE_DOCTOR_ID";
            /// <summary>
            /// 退回次数
            /// </summary>
            public const string RETURN_COUNT = "RETURN_COUNT";
            /// <summary>
            /// 纸质接收 0-未发送 1-已发送 2-已接收
            /// </summary>
            public const string PAPER_RECEIVE = "PAPER_RECEIVE";
        }
    }
}
