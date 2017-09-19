/***************************************************
 * 联众病案接口病人基本信息实体类
 * 作者：yehui
 * 时间：2017-06-07
 **************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.BAJK
{
    /// <summary>
    /// 病人基本信息
    /// </summary>
    public class BAJK08 : DbTypeBase
    {
        /// <summary>
        /// 病人序号[8]
        /// </summary>
        public decimal KEY0801 { get; set; }
        /// <summary>
        /// 病案号[40]
        /// </summary>
        public string COL0801 { get; set; }
        /// <summary>
        /// 病人姓名[50]
        /// </summary>
        public string COL0802 { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public decimal COL0803 { get; set; }
        /// <summary>
        /// 住院次数
        /// </summary>
        public decimal COL0804 { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime COL0805 { get; set; }
        /// <summary>
        /// 婚姻序号
        /// </summary>
        public decimal COL0806 { get; set; }
        /// <summary>
        /// 职业序号
        /// </summary>
        public decimal COL0807 { get; set; }
        /// <summary>
        /// 籍贯序号
        /// </summary>
        public decimal COL0808 { get; set; }
        /// <summary>
        /// 民族序号
        /// </summary>
        public decimal COL0809 { get; set; }
        /// <summary>
        /// 身份证号[18]
        /// </summary>
        public string COL0810 { get; set; }
        /// <summary>
        /// 工作单位[200]
        /// </summary>
        public string COL0811 { get; set; }
        /// <summary>
        /// 单位电话[26]
        /// </summary>
        public string COL0812 { get; set; }
        /// <summary>
        /// 单位邮编[6]
        /// </summary>
        public string COL0813 { get; set; }
        /// <summary>
        /// 家庭住址[200]
        /// </summary>
        public string COL0814 { get; set; }
        /// <summary>
        /// 住址邮编[6]
        /// </summary>
        public string COL0815 { get; set; }
        /// <summary>
        /// 关系人姓名[20]
        /// </summary>
        public string COL0816 { get; set; }
        /// <summary>
        /// 关系序号
        /// </summary>
        public decimal COL0817 { get; set; }
        /// <summary>
        /// 关系人住址[200]
        /// </summary>
        public string COL0818 { get; set; }
        /// <summary>
        /// 关系人电话[26]
        /// </summary>
        public string COL0819 { get; set; }
        /// <summary>
        /// 血型序号1.A  2.B  3.O  4.AB  5.不详  6.未查
        /// </summary>
        public decimal COL0820 { get; set; }
        /// <summary>
        /// RH 血型1.阴 2.阳 3.不详 4.未查
        /// </summary>
        public decimal COL0821 { get; set; }
        /// <summary>
        /// 抢救次数
        /// </summary>
        public decimal COL0822 { get; set; }
        /// <summary>
        /// 成功次数
        /// </summary>
        public decimal COL0823 { get; set; }
        /// <summary>
        /// 病案质量
        /// </summary>
        public decimal COL0827 { get; set; }
        /// <summary>
        /// 质控医师[8]
        /// </summary>
        public string COL0828 { get; set; }
        /// <summary>
        /// 质控护士[8]
        /// </summary>
        public string COL0829 { get; set; }
        /// <summary>
        /// 治疗类别1.中医 2.中西医3.西医4. 民族医
        /// </summary>
        public decimal COL0830 { get; set; }
        /// <summary>
        /// 入院途径1.急诊  2.门诊  3.其他医疗机构转入  9.其他
        /// </summary>
        public decimal COL0831 { get; set; }
        /// <summary>
        /// 输血情况1.有输血无反应 2. 有输血有反应  3.未输
        /// </summary>
        public decimal COL0832 { get; set; }
        /// <summary>
        /// 科主任编号[8]
        /// </summary>
        public string COL0834 { get; set; }
        /// <summary>
        /// 主任医师编号[8]
        /// </summary>
        public string COL0835 { get; set; }
        /// <summary>
        /// 主治医师编号[8]
        /// </summary>
        public string COL0836 { get; set; }
        /// <summary>
        /// 住院医师编号[8]
        /// </summary>
        public string COL0837 { get; set; }
        /// <summary>
        /// 进修医师编号[8]
        /// </summary>
        public string COL0838 { get; set; }
        /// <summary>
        /// 实习医师编号[8]
        /// </summary>
        public string  COL0839 { get; set; }
        /// <summary>
        /// 录入日期
        /// </summary>
        public DateTime COL0841 { get; set; }
        /// <summary>
        /// 操作员[8]
        /// </summary>
        public string COL0842 { get; set; }
        /// <summary>
        /// 手术标志
        /// </summary>
        public decimal COL0843 { get; set; }
        /// <summary>
        /// 入院科室[10]
        /// </summary>
        public string COL0844 { get; set; }
        /// <summary>
        /// 入院日期
        /// </summary>
        public DateTime COL0845 { get; set; }
        /// <summary>
        /// 出院科室[10]
        /// </summary>
        public string COL0847 { get; set; }
        /// <summary>
        /// 出院日期
        /// </summary>
        public DateTime COL0848 { get; set; }
        /// <summary>
        /// 确诊天数
        /// </summary>
        public decimal COL0849 { get; set; }
        /// <summary>
        /// 确诊日期
        /// </summary>
        public DateTime COL0850 { get; set; }
        /// <summary>
        /// 住院天数
        /// </summary>
        public decimal COL0851 { get; set; }
        /// <summary>
        /// 其他方式
        /// </summary>
        public decimal COL0852 { get; set; }
        /// <summary>
        /// 总费用
        /// </summary>
        public decimal COL0853 { get; set; }
        /// <summary>
        /// 疾病序号
        /// </summary>
        public decimal COL0854 { get; set; }
        /// <summary>
        /// 转归情况 1.治愈; 2.好转; 3.未愈; 4.死亡; 9.其他
        /// </summary>
        public decimal COL0855 { get; set; }
        /// <summary>
        /// 入出符合标志 0.未做1.符合2.不符合3.不确定
        /// </summary>
        public decimal COL0856 { get; set; }
        /// <summary>
        /// 门出符合标志 0.未做1.符合2.不符合3.不确定
        /// </summary>
        public decimal COL0857 { get; set; }
        /// <summary>
        /// E序号
        /// </summary>
        public decimal COL0858 { get; set; }
        /// <summary>
        /// M序号
        /// </summary>
        public decimal COL0859 { get; set; }
        /// <summary>
        /// 是否尸检
        /// </summary>
        public decimal COL0866 { get; set; }
        /// <summary>
        /// 病人序号－审核时使用，与接口无关
        /// </summary>
        public decimal BRXH { get; set; }
        /// <summary>
        /// 审核标志（默认值为0）
        /// </summary>
        public decimal FLAG { get; set; }
        /// <summary>
        /// 唯一号[20]
        /// </summary>
        public string COL0871 { get; set; }
        /// <summary>
        /// 国籍
        /// </summary>
        public decimal COL0873 { get; set; }
        /// <summary>
        /// 入院病室[30]
        /// </summary>
        public string COL0882 { get; set; }
        /// <summary>
        /// 出院病室[30]
        /// </summary>
        public string COL0883 { get; set; }
        /// <summary>
        /// 临床与病理0.未做1.符合2.不符合3.不确定
        /// </summary>
        public decimal COL0884 { get; set; }
        /// <summary>
        /// 放射与病理0.未做1.符合2.不符合3.不确定
        /// </summary>
        public decimal COL0885 { get; set; }
        /// <summary>
        /// 主诊断全称[50]
        /// </summary>
        public string COL0887 { get; set; }
        /// <summary>
        /// 结帐标识
        /// </summary>
        public decimal COL0888 { get; set; }
        /// <summary>
        /// 术前与术后0.未做1.符合2.不符合3.不确定
        /// </summary>
        public decimal COL0889 { get; set; }
        /// <summary>
        /// 自动出院
        /// </summary>
        public decimal COL0890 { get; set; }
        /// <summary>
        /// 健康卡号[30]
        /// </summary>
        public string COL0891 { get; set; }
        /// <summary>
        /// 新生儿体重
        /// </summary>
        public decimal COL0892 { get; set; }
        /// <summary>
        /// 新生儿入院体重
        /// </summary>
        public decimal COL0893 { get; set; }
        /// <summary>
        /// 出生地序号
        /// </summary>
        public decimal COL0894 { get; set; }
        /// <summary>
        /// 现住址[200]
        /// </summary>
        public string COL0895 { get; set; }
        /// <summary>
        /// 现住址电话[26]
        /// </summary>
        public string COL0896 { get; set; }
        /// <summary>
        /// 现住址邮编[26]
        /// </summary>
        public string COL0897 { get; set; }
        /// <summary>
        /// 质控日期
        /// </summary>
        public DateTime COL0898 { get; set; }
        /// <summary>
        /// 离院方式1.医嘱离院; 2.医嘱转院; 3.医嘱转社区卫生服务机构/乡镇卫生院; 4.非医嘱离院; 5.死亡; 9.其他
        /// </summary>
        public decimal COL0899 { get; set; }
        /// <summary>
        /// 拟接收医疗机构名称1[94]
        /// </summary>
        public string COL0900 { get; set; }
        /// <summary>
        /// 再住院计划
        /// </summary>
        public decimal COL0902 { get; set; }
        /// <summary>
        /// 再住院目的[94]
        /// </summary>
        public string COL0903 { get; set; }
        /// <summary>
        /// 入院前昏迷时间[26]
        /// </summary>
        public string COL0904 { get; set; }
        /// <summary>
        /// 入院后昏迷时间[26]
        /// </summary>
        public string COL0905 { get; set; }
        /// <summary>
        /// 入院病情(主诊断) 1.有; 2.临床未确定; 3.情况不明; 4.无
        /// </summary>
        public decimal COL0906 { get; set; }
        /// <summary>
        /// 药物过敏标志
        /// </summary>
        public decimal COL0907 { get; set; }
        /// <summary>
        /// 责任护士编号[10]
        /// </summary>
        public string COL0908 { get; set; }
        ///// <summary>
        ///// 临床路径1. 中医 2. 西医 3 否
        ///// </summary>
        //public decimal COL0909 { get; set; }
        /// <summary>
        /// 住院期间有无告病危1.有2.无
        /// </summary>
        public decimal COL0914 { get; set; }
        /// <summary>
        /// 非计划再次手术1.有2.无
        /// </summary>
        public decimal COL0915 { get; set; }
        /// <summary>
        /// 并发症情况1.有2.无
        /// </summary>
        public decimal COL0916 { get; set; }
        /// <summary>
        /// 并发症部位1.肺栓塞2.深静脉血栓形成3.败血症4.出血或血肿 5.伤口裂开6.猝死7.其它
        /// </summary>
        public decimal COL0917 { get; set; }
        /// <summary>
        /// 是否院内感染1. 有 2. 无
        /// </summary>
        public decimal COL0918 { get; set; }
        /// <summary>
        /// 感染部位 1.呼吸系统2.腹腔3.手术切口4.血流  5.其它
        /// </summary>
        public decimal COL0919 { get; set; }
        /// <summary>
        /// 单病种管理 1.有2.无
        /// </summary>
        public decimal COL0920 { get; set; }
        /// <summary>
        /// 临床路径：是否进入： 
        /// </summary>
        public decimal COL0921 { get; set; }
        /// <summary>
        /// 是否完成临床路径 
        /// </summary>
        public decimal COL0922 { get; set; }
        /// <summary>
        /// 是否发生压疮 1.是2.否
        /// </summary>
        public decimal COL0923 { get; set; }
        /// <summary>
        /// 是否住院期间发生 1.是2.否
        /// </summary>
        public decimal COL0924 { get; set; }
        /// <summary>
        /// 住院发生跌倒或坠床 1.是2.否
        /// </summary>
        public decimal COL0925 { get; set; }
        /// <summary>
        /// 住院期间身体约束 1.有2.无
        /// </summary>
        public decimal COL0926 { get; set; }
        /// <summary>
        /// 入住ICU情况 1.有2.无
        /// </summary>
        public decimal COL0927 { get; set; }
        /// <summary>
        /// 临床路径管理 1.完成2.变异3.退出4.未入
        /// </summary>
        public decimal COL0928 { get; set; }
        /// <summary>
        /// 手术1.急诊 2.择期（黑龙江省用）
        /// </summary>
        public decimal COL0929 { get; set; }
        /// <summary>
        /// 新技术1.是 2.否（黑龙江省用）
        /// </summary>
        public decimal COL0930 { get; set; }
        /// <summary>
        /// 危重1.是 2.否（黑龙江省用）
        /// </summary>
        public decimal COL0931 { get; set; }
        /// <summary>
        /// 会诊1.有 2.无（黑龙江省用）
        /// </summary>
        public decimal COL0932 { get; set; }
        /// <summary>
        /// 放疗方式0.根治 1.姑息性 2.辅助性 3.核素
        /// </summary>
        public decimal COL0933 { get; set; }
        /// <summary>
        /// 放疗照射技术 0.常规1.超分割2.适形3.调强4.IGRT5.VAMT6.TOMO7.Cyberknife8.其他（浙江省肿瘤医院用）
        /// </summary>
        public decimal COL0934 { get; set; }
        /// <summary>
        /// 放疗装置0.加速器1.后装2.热疗3.其他（浙江省肿瘤医院用）
        /// </summary>
        public decimal COL0935 { get; set; }
        /// <summary>
        /// 化疗方式0.根治 1.姑息性 2.辅助性 3.新药试用 4.其他（浙江省肿瘤医院用）
        /// </summary>
        public decimal COL0936 { get; set; }
        /// <summary>
        /// 病理诊断1.有 2.无（黑龙江省用）
        /// </summary>
        //public decimal COL0938 { get; set; }
        /// <summary>
        /// 抢救方法（中医版本用）1.中医2.西医3.中西医
        /// </summary>
        //public decimal COL0939 { get; set; }
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
