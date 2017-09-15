using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 新生儿登记记录
    /// </summary>
    public class BabyJustBornRecord : DbTypeBase
    {
        /// <summary>
        /// 父亲民族
        /// </summary>
        public string FATHER_NATION { get; set; }

        /// <summary>
        /// 父亲身份证号
        /// </summary>
        public string FATHER_ID_NO { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        public string HOME_ADDRESS { get; set; }

        /// <summary>
        /// 出生地点分类
        /// </summary>
        public string BIRTH_PLACE_TYPE { get; set; }

        /// <summary>
        /// 接生医疗机构编码
        /// </summary>
        public string BIRTH_FACILITY_CODE { get; set; }

        /// <summary>
        /// 接生机构名称
        /// </summary>
        public string BIRTH_FACILITY { get; set; }

        /// <summary>
        /// 出生证编号
        /// </summary>
        public string BIRTH_CERTIFICATION_NO { get; set; }

        /// <summary>
        /// 签发日期
        /// </summary>
        public DateTime DATE_OF_ISSUE { get; set; }

        /// <summary>
        /// 录入人
        /// </summary>
        public string OPERATOR { get; set; }

        /// <summary>
        /// 录入日期
        /// </summary>
        public DateTime ENTER_DATE { get; set; }

        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string NEXT_OF_KIN { get; set; }

        /// <summary>
        /// 与联系人关系
        /// </summary>
        public string RELATIONSHIP { get; set; }

        /// <summary>
        /// 联系人地址
        /// </summary>
        public string NEXT_OF_KIN_ADDR { get; set; }

        /// <summary>
        /// 联系人邮政编码
        /// </summary>
        public string NEXT_OF_KIN_ZIP_CODE { get; set; }

        /// <summary>
        /// 联系人电话号码
        /// </summary>
        public string NEXT_OF_KIN_PHONE { get; set; }

        /// <summary>
        /// 标准责任护士工号
        /// </summary>
        public string BY_NURSE { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string NATION { get; set; }

        /// <summary>
        /// 母婴同室
        /// </summary>
        public decimal IN_MOTHER_ROOM { get; set; }

        /// <summary>
        /// 婴儿标识号
        /// </summary>
        public string BABY_ID { get; set; }

        /// <summary>
        /// 妈妈住院流水号
        /// </summary>
        public string MUM_VISIT_NO { get; set; }

        /// <summary>
        /// 婴儿序号
        /// </summary>
        public decimal BABY_NO { get; set; }

        /// <summary>
        /// 母亲标识号
        /// </summary>
        public string MOTHER_ID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }

        /// <summary>
        /// 出生时间
        /// </summary>
        public DateTime DATE_OF_BIRTH { get; set; }

        /// <summary>
        /// 出生地地址-省（自治区、直辖市）编码
        /// </summary>
        public string BIRTH_PLACE_PROVINCE_CODE { get; set; }

        /// <summary>
        /// 出生地地址-省（自治区、直辖市）
        /// </summary>
        public string BIRTH_PLACE_PROVINCE { get; set; }

        /// <summary>
        /// 出生地地址-市（地区），编码
        /// </summary>
        public string BIRTH_PLACE_CITY_CODE { get; set; }

        /// <summary>
        /// 出生地地址-市（地区）
        /// </summary>
        public string BIRTH_PLACE_CITY { get; set; }

        /// <summary>
        /// 出生地地址-县（区），编码
        /// </summary>
        public string BIRTH_PLACE_COUNTY_CODE { get; set; }

        /// <summary>
        /// 出生地地址-县（区）
        /// </summary>
        public string BIRTH_PLACE_COUNTY { get; set; }

        /// <summary>
        /// 户口地址-乡（镇、街道办事处）、村（街、路、弄等）、门牌号码
        /// </summary>
        public string BIRTH_PLACE_OTHERS { get; set; }

        /// <summary>
        /// 出生孕周
        /// </summary>
        public decimal GESTATION_WEEK { get; set; }

        /// <summary>
        /// 健康状况
        /// </summary>
        public string HEALTH_STATUS { get; set; }

        /// <summary>
        /// 体重
        /// </summary>
        public decimal WEIGHT { get; set; }

        /// <summary>
        /// 身长
        /// </summary>
        public decimal HEIGHT { get; set; }

        /// <summary>
        /// 分娩方式
        /// </summary>
        public decimal BIRTH_QUOMODO { get; set; }

        /// <summary>
        /// 分娩状态
        /// </summary>
        public decimal BIRTH_STATUE { get; set; }

        /// <summary>
        /// 母亲年龄
        /// </summary>
        public decimal MOTHER_AGE { get; set; }

        /// <summary>
        /// 母亲国籍
        /// </summary>
        public string MOTHER_CITIZENSHIP { get; set; }

        /// <summary>
        /// 母亲民族
        /// </summary>
        public string MOTHER_NATION { get; set; }

        /// <summary>
        /// 母亲身份证号
        /// </summary>
        public string MOTHER_ID_NO { get; set; }

        /// <summary>
        /// 父亲姓名
        /// </summary>
        public string FATHER_NAME { get; set; }

        /// <summary>
        /// 父亲年龄
        /// </summary>
        public decimal FATHER_AGE { get; set; }

        /// <summary>
        /// 父亲国籍
        /// </summary>
        public string FATHER_CITIZENSHIP { get; set; }


        public BabyJustBornRecord()
        {
           
        }
    }
}
