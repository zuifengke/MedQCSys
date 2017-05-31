using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// <summary>
        /// 病案打包信息表
        /// </summary>
        public struct RecPackTable
        {
            /// <summary>
            /// 主键ID
            /// </summary>
            public const string PACK_ID = "PACK_ID";
            /// <summary>
            /// 包号
            /// </summary>
            public const string PACK_NO = "PACK_NO";
            /// <summary>
            /// 病案号
            /// </summary>
            public const string PATIENT_ID   = "PATIENT_ID";
            /// <summary>
            /// 入院次
            /// </summary>
            public const string VISIT_ID = "VISIT_ID";
            /// <summary>
            /// 就诊流水号
            /// </summary>
            public const string VISIT_NO = "VISIT_NO";
            /// <summary>
            /// 患者姓名
            /// </summary>
            public const string PATIENT_NAME = "PATIENT_NAME";
            /// <summary>
            /// 患者出院时间
            /// </summary>
            public const string DISCHARGE_TIME = "DISCHARGE_TIME";
            /// <summary>
            /// 张数
            /// </summary>
            public const string PAPER_NUMBER = "PAPER_NUMBER";
            /// <summary>
            /// 打包人
            /// </summary>
            public const string PACKER = "PACKER";
            /// <summary>
            /// 打包人ID
            /// </summary>
            public const string PACKER_ID = "PACKER_ID";
            /// <summary>
            /// 打包时间
            /// </summary>
            public const string PACK_TIME = "PACK_TIME";
            /// <summary>
            /// 院区
            /// </summary>
            public const string HOSPITAL_DISTRICT = "HOSPITAL_DISTRICT";
            /// <summary>
            /// 箱号
            /// </summary>
            public const string CASE_NO = "CASE_NO";
        }
    }
}
