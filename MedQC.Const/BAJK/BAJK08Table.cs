
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 病人基本信息库
        /// </summary>
        public struct BAJK08Table
        {
            /// <summary>
            /// 病人序号
            /// </summary>
            public const string KEY0801 = "KEY0801";
            /// <summary>
            /// 病案号
            /// </summary>
            public const string COL0801 = "COL0801";
            /// <summary>
            /// 病人姓名
            /// </summary>
            public const string COL0802 = "COL0802";
            /// <summary>
            /// 性别
            /// </summary>
            public const string COL0803 = "COL0803";
            /// <summary>
            /// 住院次数
            /// </summary>
            public const string COL0804 = "COL0804";
            /// <summary>
            /// 出生日期
            /// </summary>
            public const string COL0805 = "COL0805";
            /// <summary>
            /// 婚姻序号
            /// </summary>
            public const string COL0806 = "COL0806";
            /// <summary>
            /// 职业序号
            /// </summary>
            public const string COL0807 = "COL0807";
            /// <summary>
            /// 籍贯序号
            /// </summary>
            public const string COL0808 = "COL0808";
            /// <summary>
            /// 民族序号
            /// </summary>
            public const string COL0809 = "COL0809";
            /// <summary>
            /// 身份证号
            /// </summary>
            public const string COL0810 = "COL0810";
            /// <summary>
            /// 工作单位
            /// </summary>
            public const string COL0811 = "COL0811";
            /// <summary>
            /// 单位电话
            /// </summary>
            public const string COL0812 = "COL0812";
            /// <summary>
            /// 单位邮编
            /// </summary>
            public const string COL0813 = "COL0813";
            /// <summary>
            /// 家庭住址
            /// </summary>
            public const string COL0814 = "COL0814";
            /// <summary>
            /// 住址邮编
            /// </summary>
            public const string COL0815 = "COL0815";
            /// <summary>
            /// 关系人姓名
            /// </summary>
            public const string COL0816 = "COL0816";
            /// <summary>
            /// 关系序号
            /// </summary>
            public const string COL0817 = "COL0817";
            /// <summary>
            /// 关系人住址
            /// </summary>
            public const string COL0818 = "COL0818";
            /// <summary>
            /// 关系人电话
            /// </summary>
            public const string COL0819 = "COL0819";
            /// <summary>
            /// 血型序号1.A  2.B  3.O  4.AB  5.不详  6.未查
            /// </summary>
            public const string COL0820 = "COL0820";
            /// <summary>
            /// RH 血型1.阴 2.阳 3.不详 4.未查
            /// </summary>
            public const string COL0821 = "COL0821";
            /// <summary>
            /// 抢救次数
            /// </summary>
            public const string COL0822 = "COL0822";
            /// <summary>
            /// 成功次数
            /// </summary>
            public const string COL0823 = "COL0823";
            /// <summary>
            /// 病案质量
            /// </summary>
            public const string COL0827 = "COL0827";
            /// <summary>
            /// 质控医师
            /// </summary>
            public const string COL0828 = "COL0828";
            /// <summary>
            /// 质控护士
            /// </summary>
            public const string COL0829 = "COL0829";
            /// <summary>
            /// 治疗类别1.中医 2.中西医3.西医4. 民族医
            /// </summary>
            public const string COL0830 = "COL0830";
            /// <summary>
            /// 入院途径1.急诊  2.门诊  3.其他医疗机构转入  9.其他
            /// </summary>
            public const string COL0831 = "COL0831";
            /// <summary>
            /// 输血情况1.有输血无反应 2. 有输血有反应  3.未输
            /// </summary>
            public const string COL0832 = "COL0823";
            /// <summary>
            /// 科主任编号
            /// </summary>
            public const string COL0834 = "COL0834";
            /// <summary>
            /// 主任医师编号
            /// </summary>
            public const string COL0835 = "COL0835";
            /// <summary>
            /// 主治医师编号
            /// </summary>
            public const string COL0836 = "COL0836";
            /// <summary>
            /// 住院医师编号
            /// </summary>
            public const string COL0837 = "COL0837";
            /// <summary>
            /// 进修医师编号
            /// </summary>
            public const string COL0838 = "COL0838";
            /// <summary>
            /// 实习医师编号
            /// </summary>
            public const string COL0839 = "COL0839";
            /// <summary>
            /// 录入日期
            /// </summary>
            public const string COL0841 = "COL0841";
            /// <summary>
            /// 操作员
            /// </summary>
            public const string COL0842 = "COL0842";
            /// <summary>
            /// 手术标志
            /// </summary>
            public const string COL0843 = "COL0843";
            /// <summary>
            /// 入院科室
            /// </summary>
            public const string COL0844 = "COL0844";
            /// <summary>
            /// 入院日期
            /// </summary>
            public const string COL0845 = "COL0845";
            /// <summary>
            /// 出院科室
            /// </summary>
            public const string COL0847 = "COL0847";
            /// <summary>
            /// 出院日期
            /// </summary>
            public const string COL0848 = "COL0848";
            /// <summary>
            /// 确诊天数
            /// </summary>
            public const string COL0849 = "COL0849";
            /// <summary>
            /// 确诊日期
            /// </summary>
            public const string COL0850 = "COL0850";
            /// <summary>
            /// 住院天数
            /// </summary>
            public const string COL0851 = "COL0851";
            /// <summary>
            /// 其他方式
            /// </summary>
            public const string COL0852 = "COL0852";
            /// <summary>
            /// 总费用
            /// </summary>
            public const string COL0853 = "COL0853";
            /// <summary>
            /// 疾病序号
            /// </summary>
            public const string COL0854 = "COL0854";
            /// <summary>
            /// 转归情况 1.治愈; 2.好转; 3.未愈; 4.死亡; 9.其他
            /// </summary>
            public const string COL0855 = "COL0855";
            /// <summary>
            /// 入出符合标志 0.未做1.符合2.不符合3.不确定
            /// </summary>
            public const string COL0856 = "COL0856";
            /// <summary>
            /// 门出符合标志 0.未做1.符合2.不符合3.不确定
            /// </summary>
            public const string COL0857 = "COL0857";
            /// <summary>
            /// E序号
            /// </summary>
            public const string COL0858 = "COL0858";
            /// <summary>
            /// M序号
            /// </summary>
            public const string COL0859 = "COL0859";
            /// <summary>
            /// 是否尸检
            /// </summary>
            public const string COL0866 = "COL0866";
            /// <summary>
            /// 病人序号－审核时使用，与接口无关
            /// </summary>
            public const string BRXH = "BRXH";
            /// <summary>
            /// 审核标志（默认值为0）
            /// </summary>
            public const string FLAG = "FLAG";
            /// <summary>
            /// 唯一号
            /// </summary>
            public const string COL0871 = "COL0871";
            /// <summary>
            /// 国籍
            /// </summary>
            public const string COL0873 = "COL0873";
            /// <summary>
            /// 入院病室
            /// </summary>
            public const string COL0882 = "COL0882";
            /// <summary>
            /// 出院病室
            /// </summary>
            public const string COL0883 = "COL0883";
            /// <summary>
            /// 临床与病理0.未做1.符合2.不符合3.不确定
            /// </summary>
            public const string COL0884 = "COL0884";
            /// <summary>
            /// 放射与病理0.未做1.符合2.不符合3.不确定
            /// </summary>
            public const string COL0885 = "COL0885";
            /// <summary>
            /// 主诊断全称
            /// </summary>
            public const string COL0887 = "COL0887";
            /// <summary>
            /// 结帐标识
            /// </summary>
            public const string COL0888 = "COL0888";
            /// <summary>
            /// 术前与术后0.未做1.符合2.不符合3.不确定
            /// </summary>
            public const string COL0889 = "COL0889";
            /// <summary>
            /// 自动出院
            /// </summary>
            public const string COL0890 = "COL0890";
            /// <summary>
            /// 健康卡号
            /// </summary>
            public const string COL0891 = "COL0891";
            /// <summary>
            /// 新生儿体重
            /// </summary>
            public const string COL0892 = "COL0892";
            /// <summary>
            /// 新生儿入院体重
            /// </summary>
            public const string COL0893 = "COL0893";
            /// <summary>
            /// 出生地序号
            /// </summary>
            public const string COL0894 = "COL0894";
            /// <summary>
            /// 现住址
            /// </summary>
            public const string COL0895 = "COL0895";
            /// <summary>
            /// 现住址电话
            /// </summary>
            public const string COL0896 = "COL0896";
            /// <summary>
            /// 现住址邮编
            /// </summary>
            public const string COL0897 = "COL0897";
            /// <summary>
            /// 质控日期
            /// </summary>
            public const string COL0898 = "COL0898";
            /// <summary>
            /// 离院方式1.医嘱离院; 2.医嘱转院; 3.医嘱转社区卫生服务机构/乡镇卫生院; 4.非医嘱离院; 5.死亡; 9.其他
            /// </summary>
            public const string COL0899 = "COL0899";
            /// <summary>
            /// 拟接收医疗机构名称1
            /// </summary>
            public const string COL0900 = "COL0900";
            /// <summary>
            /// 再住院计划
            /// </summary>
            public const string COL0902 = "COL0902";
            /// <summary>
            /// 再住院目的
            /// </summary>
            public const string COL0903 = "COL0903";
            /// <summary>
            /// 入院前昏迷时间
            /// </summary>
            public const string COL0904 = "COL0904";
            /// <summary>
            /// 入院后昏迷时间
            /// </summary>
            public const string COL0905 = "COL0905";
            /// <summary>
            /// 入院病情(主诊断) 1.有; 2.临床未确定; 3.情况不明; 4.无
            /// </summary>
            public const string COL0906 = "COL0906";
            /// <summary>
            /// 药物过敏标志
            /// </summary>
            public const string COL0907 = "COL0907";
            /// <summary>
            /// 责任护士编号
            /// </summary>
            public const string COL0908 = "COL0908";
            /// <summary>
            /// 临床路径1. 中医 2. 西医 3 否
            /// </summary>
            public const string COL0909 = "COL0909";
            /// <summary>
            /// 住院期间有无告病危1.有2.无
            /// </summary>
            public const string COL0914 = "COL0914";
            /// <summary>
            /// 非计划再次手术1.有2.无
            /// </summary>
            public const string COL0915 = "COL0915";
            /// <summary>
            /// 并发症情况1.有2.无
            /// </summary>
            public const string COL0916 = "COL0915";
            /// <summary>
            /// 并发症部位1.肺栓塞2.深静脉血栓形成3.败血症4.出血或血肿 5.伤口裂开6.猝死7.其它
            /// </summary>
            public const string COL0917 = "COL0917";
            /// <summary>
            /// 是否院内感染1. 有 2. 无
            /// </summary>
            public const string COL0918 = "COL0918";
            /// <summary>
            /// 感染部位 1.呼吸系统2.腹腔3.手术切口4.血流  5.其它
            /// </summary>
            public const string COL0919 = "COL0919";
            /// <summary>
            /// 单病种管理 1.有2.无
            /// </summary>
            public const string COL0920 = "COL0920";
            /// <summary>
            /// 临床路径：是否进入： 
            /// </summary>
            public const string COL0921 = "COL0921";
            /// <summary>
            /// 是否完成临床路径 
            /// </summary>
            public const string COL0922 = "COL0922";
            /// <summary>
            /// 是否发生压疮 1.是2.否
            /// </summary>
            public const string COL0923 = "COL0923";
            /// <summary>
            /// 是否住院期间发生 1.是2.否
            /// </summary>
            public const string COL0924 = "COL0924";
            /// <summary>
            /// 住院发生跌倒或坠床 1.是2.否
            /// </summary>
            public const string COL0925 = "COL0925";
            /// <summary>
            /// 住院期间身体约束 1.有2.无
            /// </summary>
            public const string COL0926 = "COL0926";
            /// <summary>
            /// 入住ICU情况 1.有2.无
            /// </summary>
            public const string COL0927 = "COL0927";
            /// <summary>
            /// 临床路径管理 1.完成2.变异3.退出4.未入
            /// </summary>
            public const string COL0928 = "COL0928";
            /// <summary>
            /// 手术1.急诊 2.择期（黑龙江省用）
            /// </summary>
            public const string COL0929 = "COL0929";
            /// <summary>
            /// 新技术1.是 2.否（黑龙江省用）
            /// </summary>
            public const string COL0930 = "COL0930";
            /// <summary>
            /// 危重1.是 2.否（黑龙江省用）
            /// </summary>
            public const string COL0931 = "COL0931";
            /// <summary>
            /// 会诊1.有 2.无（黑龙江省用）
            /// </summary>
            public const string COL0932 = "COL0932";
            /// <summary>
            /// 放疗方式0.根治 1.姑息性 2.辅助性 3.核素
            /// </summary>
            public const string COL0933 = "COL0933";
            /// <summary>
            /// 放疗照射技术 0.常规1.超分割2.适形3.调强4.IGRT5.VAMT6.TOMO7.Cyberknife8.其他（浙江省肿瘤医院用）
            /// </summary>
            public const string COL0934 = "COL0934";
            /// <summary>
            /// 放疗装置0.加速器1.后装2.热疗3.其他（浙江省肿瘤医院用）
            /// </summary>
            public const string COL0935 = "COL0935";
            /// <summary>
            /// 化疗方式0.根治 1.姑息性 2.辅助性 3.新药试用 4.其他（浙江省肿瘤医院用）
            /// </summary>
            public const string COL0936 = "COL0936";
            /// <summary>
            /// 病理诊断1.有 2.无（黑龙江省用）
            /// </summary>
            public const string COL0938 = "COL0938";
            /// <summary>
            /// 抢救方法（中医版本用）1.中医2.西医3.中西医
            /// </summary>
            public const string COL0939 = "COL0939";
        }
    }
}
