using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.Entity
{
    /// <summary>
    /// 质控内容缺陷检查记录类
    /// </summary>
    public class QcContentRecord:EMRDBLib.DbTypeBase
    {
        /// <summary>
        /// 主键序号
        /// </summary>
        public int ContentRecordID { get; set; }
        /// <summary>
        /// 病案号
        /// </summary>
        public string PatientID { get; set; }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 就诊号
        /// </summary>
        public string VisitID { get; set; }
        /// <summary>
        /// 文档类型号
        /// </summary>
        public string DocTypeID { get; set; }
        /// <summary>
        /// 扣分值
        /// </summary>
        public float Point { get; set; }
        /// <summary>
        /// 检查者
        /// </summary>
        public string CheckerName { get; set; }
        /// <summary>
        /// 检查者ID
        /// </summary>
        public string CheckerID { get; set; }
        /// <summary>
        /// 检查时间
        /// </summary>
        public DateTime CheckDate { get; set; }
        /// <summary>
        /// 文档id号
        /// </summary>
        public string DocSetID { get; set; }
        /// <summary>
        /// 文档标题
        /// </summary>
        public string DocTitle { get; set; }
        /// <summary>
        /// 文书最近的修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; }
        /// <summary>
        /// Bug记录时间
        /// </summary>
        public DateTime BugCreateTime { get; set; }
        /// <summary>
        /// 创建者ID
        /// </summary>
        public string CreateID { get; set; }
        /// <summary>
        /// 创建者姓名
        /// </summary>
        public string CreateName { get; set; }
        /// <summary> 
        /// 创建时间
        /// </summary>
        public DateTime DocTime { get; set; }
        /// <summary>
        /// 错误类型 1内容错误 2元素错误
        /// </summary>
        public string BugType { get; set; }
        /// <summary>
        /// 错误级别 0 警告;1 错误
        /// </summary>
        public int BugClass { get; set; }
        /// <summary>
        /// 错误描述
        /// </summary>
        public string QCExplain { get; set; }
       /// <summary>
       /// 责任医生
       /// </summary>
        public string DocIncharge { get; set; }
        /// <summary>
        /// 责任科室
        /// </summary>
        public string DeptIncharge { get; set; }
        /// <summary>
        /// 文档签名代码
        /// </summary>
        public string SignCode { get; set; }
        /// <summary>
        /// 科室代码
        /// </summary>
        public string DeptCode { get; set; }
        public string MakeID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }

        public QcContentRecord()
        {
            CheckDate = base.DefaultTime;
            ModifyTime = base.DefaultTime;
            BugCreateTime = base.DefaultTime;
            DocTime = base.DefaultTime;
        }
    }
}
