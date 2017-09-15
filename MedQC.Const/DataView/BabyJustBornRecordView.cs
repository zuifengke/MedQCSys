using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 新生儿登记记录视图
        /// </summary>
        public struct BabyJustBornRecordView
        {
            /// <summary>
            /// 父亲民族
            /// </summary>
            public const string FATHER_NATION = "FATHER_NATION";
            /// <summary>
            /// 父亲身份证号
            /// </summary>
            public const string FATHER_ID_NO = "FATHER_ID_NO";
            /// <summary>
            /// 家庭住址
            /// </summary>
            public const string HOME_ADDRESS = "HOME_ADDRESS";
            /// <summary>
            /// 出生地点分类
            /// </summary>
            public const string BIRTH_PLACE_TYPE = "BIRTH_PLACE_TYPE";
            /// <summary>
            /// 接生医疗机构编码
            /// </summary>
            public const string BIRTH_FACILITY_CODE = "BIRTH_FACILITY_CODE";
            /// <summary>
            /// 接生机构名称
            /// </summary>
            public const string BIRTH_FACILITY = "BIRTH_FACILITY";
            /// <summary>
            /// 出生证编号
            /// </summary>
            public const string BIRTH_CERTIFICATION_NO = "BIRTH_CERTIFICATION_NO";
            /// <summary>
            /// 签发日期
            /// </summary>
            public const string DATE_OF_ISSUE = "DATE_OF_ISSUE";
            /// <summary>
            /// 录入人
            /// </summary>
            public const string OPERATOR = "OPERATOR";
            /// <summary>
            /// 录入日期
            /// </summary>
            public const string ENTER_DATE = "ENTER_DATE";
            /// <summary>
            /// 联系人姓名
            /// </summary>
            public const string NEXT_OF_KIN = "NEXT_OF_KIN";
            /// <summary>
            /// 与联系人关系
            /// </summary>
            public const string RELATIONSHIP = "RELATIONSHIP";
            /// <summary>
            /// 联系人地址
            /// </summary>
            public const string NEXT_OF_KIN_ADDR = "NEXT_OF_KIN_ADDR";
            /// <summary>
            /// 联系人邮政编码
            /// </summary>
            public const string NEXT_OF_KIN_ZIP_CODE = "NEXT_OF_KIN_ZIP_CODE";
            /// <summary>
            /// 联系人电话号码
            /// </summary>
            public const string NEXT_OF_KIN_PHONE = "NEXT_OF_KIN_PHONE";
            /// <summary>
            /// 标准责任护士工号
            /// </summary>
            public const string BY_NURSE = "BY_NURSE";
            /// <summary>
            /// 民族
            /// </summary>
            public const string NATION = "NATION";
            /// <summary>
            /// 母婴同室
            /// </summary>
            public const string IN_MOTHER_ROOM = "IN_MOTHER_ROOM";
            /// <summary>
            /// 婴儿标识号
            /// </summary>
            public const string BABY_ID = "BABY_ID";
            /// <summary>
            /// 妈妈住院流水号
            /// </summary>
            public const string MUM_VISIT_NO = "MUM_VISIT_NO";
            /// <summary>
            /// 婴儿序号
            /// </summary>
            public const string BABY_NO = "BABY_NO";
            /// <summary>
            /// 母亲标识号
            /// </summary>
            public const string MOTHER_ID = "MOTHER_ID";
            /// <summary>
            /// 姓名
            /// </summary>
            public const string NAME = "NAME";
            /// <summary>
            /// 性别
            /// </summary>
            public const string SEX = "SEX";
            /// <summary>
            /// 出生时间
            /// </summary>
            public const string DATE_OF_BIRTH = "DATE_OF_BIRTH";
            /// <summary>
            /// 出生地地址-省（自治区、直辖市）编码
            /// </summary>
            public const string BIRTH_PLACE_PROVINCE_CODE = "BIRTH_PLACE_PROVINCE_CODE";
            /// <summary>
            /// 出生地地址-省（自治区、直辖市）
            /// </summary>
            public const string BIRTH_PLACE_PROVINCE = "BIRTH_PLACE_PROVINCE";
            /// <summary>
            /// 出生地地址-市（地区），编码
            /// </summary>
            public const string BIRTH_PLACE_CITY_CODE = "BIRTH_PLACE_CITY_CODE";
            /// <summary>
            /// 出生地地址-市（地区）
            /// </summary>
            public const string BIRTH_PLACE_CITY = "BIRTH_PLACE_CITY";
            /// <summary>
            /// 出生地地址-县（区），编码
            /// </summary>
            public const string BIRTH_PLACE_COUNTY_CODE = "BIRTH_PLACE_COUNTY_CODE";
            /// <summary>
            /// 出生地地址-县（区）
            /// </summary>
            public const string BIRTH_PLACE_COUNTY = "BIRTH_PLACE_COUNTY";
            /// <summary>
            /// 户口地址-乡（镇、街道办事处）、村（街、路、弄等）、门牌号码
            /// </summary>
            public const string BIRTH_PLACE_OTHERS = "BIRTH_PLACE_OTHERS";
            /// <summary>
            /// 出生孕周
            /// </summary>
            public const string GESTATION_WEEK = "GESTATION_WEEK";
            /// <summary>
            /// 健康状况
            /// </summary>
            public const string HEALTH_STATUS = "HEALTH_STATUS";
            /// <summary>
            /// 体重
            /// </summary>
            public const string WEIGHT = "WEIGHT";
            /// <summary>
            /// 身长
            /// </summary>
            public const string HEIGHT = "HEIGHT";
            /// <summary>
            /// 分娩方式
            /// </summary>
            public const string BIRTH_QUOMODO = "BIRTH_QUOMODO";
            /// <summary>
            /// 分娩状态
            /// </summary>
            public const string BIRTH_STATUE = "BIRTH_STATUE";
            /// <summary>
            /// 母亲年龄
            /// </summary>
            public const string MOTHER_AGE = "MOTHER_AGE";
            /// <summary>
            /// 母亲国籍
            /// </summary>
            public const string MOTHER_CITIZENSHIP = "MOTHER_CITIZENSHIP";
            /// <summary>
            /// 母亲民族
            /// </summary>
            public const string MOTHER_NATION = "MOTHER_NATION";
            /// <summary>
            /// 母亲身份证号
            /// </summary>
            public const string MOTHER_ID_NO = "MOTHER_ID_NO";
            /// <summary>
            /// 父亲姓名
            /// </summary>
            public const string FATHER_NAME = "FATHER_NAME";
            /// <summary>
            /// 父亲年龄
            /// </summary>
            public const string FATHER_AGE = "FATHER_AGE";
            /// <summary>
            /// 父亲国籍
            /// </summary>
            public const string FATHER_CITIZENSHIP = "FATHER_CITIZENSHIP";

        }
    }
}
