/***************************************************
 * 联众病案接口实体类
 * 作者：yehui
 * 时间：2017-06-05
 **************************************************/
using EMRDBLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heren.MedQC.Model.BAJK
{
    /// <summary>
    /// 联众病案费用情况
    /// </summary>
    public class BAJK15 : DbTypeBase
    {
        /// <summary>
        /// 病人序号
        /// </summary>
        public decimal KEY1501 { get; set; }
        /// <summary>
        /// 费用类别
        /// </summary>
        public decimal COL1501 { get; set; }
        /// <summary>
        /// 西药费
        /// </summary>
        public decimal COL1503 { get; set; }
        /// <summary>
        /// 中药费
        /// </summary>
        public decimal COL1504 { get; set; }
        /// <summary>
        /// 草药费
        /// </summary>
        public decimal COL1505 { get; set; }
        /// <summary>
        /// 输血费
        /// </summary>
        public decimal COL1508 { get; set; }
        /// <summary>
        /// 手术费
        /// </summary>
        public decimal COL1510 { get; set; }
        /// <summary>
        /// 麻醉费
        /// </summary>
        public decimal COL1514 { get; set; }
        /// <summary>
        /// 护理费
        /// </summary>
        public decimal COL1517 { get; set; }
        /// <summary>
        /// 其他费
        /// </summary>
        public decimal COL1518 { get; set; }
        /// <summary>
        /// 一般医疗服务费
        /// </summary>
        public decimal COL1521 { get; set; }
        /// <summary>
        /// 一般治疗操作费
        /// </summary>
        public decimal COL1522 { get; set; }
        /// <summary>
        /// 综合其他费用
        /// </summary>
        public decimal COL1523 { get; set; }
        /// <summary>
        /// 病理诊断费
        /// </summary>
        public decimal COL1524 { get; set; }
        /// <summary>
        /// 实验室诊断费
        /// </summary>
        public decimal COL1525 { get; set; }
        /// <summary>
        /// 影像学诊断费
        /// </summary>
        public decimal COL1526 { get; set; }
        /// <summary>
        /// 临床诊断项目费
        /// </summary>
        public decimal COL1527 { get; set; }
        /// <summary>
        /// 非手术治疗项目费
        /// </summary>
        public decimal COL1528 { get; set; }
        /// <summary>
        /// 手术治疗费
        /// </summary>
        public decimal COL1529 { get; set; }
        /// <summary>
        /// 康复费
        /// </summary>
        public decimal COL1530 { get; set; }
        /// <summary>
        /// 中医治疗费
        /// </summary>
        public decimal COL1531 { get; set; }
        /// <summary>
        /// 白蛋白类制品费
        /// </summary>
        public decimal COL1532 { get; set; }
        /// <summary>
        /// 球蛋白类制品费
        /// </summary>
        public decimal COL1533 { get; set; }
        /// <summary>
        /// 凝血因子类制品费
        /// </summary>
        public decimal COL1534 { get; set; }
        /// <summary>
        /// 细胞因子类制品费
        /// </summary>
        public decimal COL1535 { get; set; }
        /// <summary>
        /// 检查用一次性医用材料费
        /// </summary>
        public decimal COL1536 { get; set; }
        /// <summary>
        /// 治疗用一次性医用材料费
        /// </summary>
        public decimal COL1537 { get; set; }
        /// <summary>
        /// 手术用一次性医用材料费
        /// </summary>
        public decimal COL1538 { get; set; }
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal COL1540 { get; set; }
        /// <summary>
        /// 临床物理治疗费
        /// </summary>
        public decimal COL1541 { get; set; }
        /// <summary>
        /// 抗菌药物费用
        /// </summary>
        public decimal COL1542 { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
