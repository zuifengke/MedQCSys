
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        public struct PatMasterIndexTable
        {
            /// <summary>
            /// 编码类型标识号
            /// </summary>
            public const string CODETYPE_ID = "CODETYPE_ID";
            /// <summary>
            /// 患者标识号
            /// </summary>
            public const string PATIENT_ID = "PATIENT_ID";
            /// <summary>
            /// 门诊号
            /// </summary>
            public const string OUTP_NO = "OUTP_NO";
            /// <summary>
            /// 住院号
            /// </summary>
            public const string INP_NO = "INP_NO";
            /// <summary>
            /// 姓名
            /// </summary>
            public const string NAME = "NAME";
            /// <summary>
            /// 姓名拼音
            /// </summary>
            public const string NAME_PHONETIC = "NAME_PHONETIC";
            /// <summary>
            /// 性别
            /// </summary>
            public const string SEX = "SEX";
            /// <summary>
            /// 出生日期
            /// </summary>
            public const string DATE_OF_BIRTH = "DATE_OF_BIRTH";
            /// <summary>
            /// 身份证号
            /// </summary>
            public const string ID_NO = "ID_NO";
            /// <summary>
            /// 医保账户分类
            /// </summary>
            public const string SECURITY_TYPE = "SECURITY_TYPE";
            /// <summary>
            /// 账户编号
            /// </summary>
            public const string SECURITY_NO = "SECURITY_NO";
            /// <summary>
            /// 国籍
            /// </summary>
            public const string CITIZENSHIP = "CITIZENSHIP";
            /// <summary>
            /// 民族
            /// </summary>
            public const string NATION = "NATION";
            /// <summary>
            /// 身份
            /// </summary>
            public const string IDENTITY = "IDENTITY";
            /// <summary>
            /// 费别
            /// </summary>
            public const string CHARGE_TYPE = "CHARGE_TYPE";
            /// <summary>
            /// 合同单位
            /// </summary>
            public const string UNIT_IN_CONTRACT = "UNIT_IN_CONTRACT";
            /// <summary>
            /// 出生地地址-省（自治区、直辖市）
            /// </summary>
            public const string BIRTH_PLACE_PROVINCE = "BIRTH_PLACE_PROVINCE";
            /// <summary>
            /// 出生地地址-市（地区）
            /// </summary>
            public const string BIRTH_PLACE_CITY = "BIRTH_PLACE_CITY";
            /// <summary>
            ///出生地地址-县（区）
            /// </summary>
            public const string BIRTH_PLACE_COUNTY = "BIRTH_PLACE_COUNTY";
            /// <summary>
            /// 出生地编码
            /// </summary>
            public const string BIRTH_PLACE_CODE = "BIRTH_PLACE_CODE";
            /// <summary>
            /// 籍贯
            /// </summary>
            public const string NATIVE_PLACE = "NATIVE_PLACE";
            /// <summary>
            /// 现住地址-省（自治区、直辖市）
            /// </summary>
            public const string PRESENT_ADDRESS_PROVINCE = "PRESENT_ADDRESS_PROVINCE";
            /// <summary>
            /// 现住地址-市（地区）
            /// </summary>
            public const string PRESENT_ADDRESS_CITY = "PRESENT_ADDRESS_CITY";
            /// <summary>
            /// 现住地址-县（区）
            /// </summary>
            public const string PRESENT_ADDRESS_COUNTY = "PRESENT_ADDRESS_COUNTY";
            /// <summary>
            /// 现住地址-乡（镇、街道办事处）、村（街、路、弄等）、门牌号码
            /// </summary>
            public const string PRESENT_ADDRESS_OTHERS = "PRESENT_ADDRESS_OTHERS";
            /// <summary>
            /// 现住址编码
            /// </summary>
            public const string PRESENT_ADDRESS_CODE = "PRESENT_ADDRESS_CODE";
            /// <summary>
            /// 现住址邮编
            /// </summary>
            public const string PRESENT_ADDRESS_ZIPCODE = "PRESENT_ADDRESS_ZIPCODE";
            /// <summary>
            ///  户口地址-省（自治区、直辖市）
            /// </summary>
            public const string REGISTERED_RESIDENCE_PROVINCE = "REGISTERED_RESIDENCE_PROVINCE";
            /// <summary>
            ///  户口地址-市（地区）
            /// </summary>
            public const string REGISTERED_RESIDENCE_CITY = "REGISTERED_RESIDENCE_CITY";
            /// <summary>
            /// 户口地址-县（区）
            /// </summary>
            public const string REGISTERED_RESIDENCE_COUNTY = "REGISTERED_RESIDENCE_COUNTY";
            /// <summary>
            /// 户口地址-乡（镇、街道办事处）、村（街、路、弄等）、门牌号码
            /// </summary>
            public const string REGISTERED_RESIDENCE_OTHERS = "REGISTERED_RESIDENCE_OTHERS";
            /// <summary>
            /// 户口地址编码
            /// </summary>
            public const string REGISTERED_RESIDENCE_CODE = "REGISTERED_RESIDENCE_CODE";
            /// <summary>
            /// 户口地址邮编
            /// </summary>
            public const string REGISTERED_RESIDENCE_ZIPCODE = "REGISTERED_RESIDENCE_ZIPCODE";
            /// <summary>
            /// 工作单位
            /// </summary>
            public const string SERVICE_AGENCY = "SERVICE_AGENCY";
            /// <summary>
            ///  工作单位地址
            /// </summary>
            public const string WORKING_ADDRESS = "WORKING_ADDRESS";
            /// <summary>
            ///  工作单位地址邮编
            /// </summary>
            public const string WORKING_ADDRESS_ZIPCODE = "WORKING_ADDRESS_ZIPCODE";
            /// <summary>
            ///  单位电话号码
            /// </summary>
            public const string PHONE_NUMBER_BUSINESS = "PHONE_NUMBER_BUSINESS";
            /// <summary>
            ///  电子邮件
            /// </summary>
            public const string EMAIL = "EMAIL";
            /// <summary>
            ///  联系电话
            /// </summary>
            public const string PHONE_NUMBER = "PHONE_NUMBER";
            /// <summary>
            /// 联系人姓名
            /// </summary>
            public const string NEXT_OF_KIN = "NEXT_OF_KIN";
            /// <summary>
            /// 与联系人关系
            /// </summary>
            public const string RELATIONSHIP = "RELATIONSHIP";
            /// <summary>
            ///  联系人地址
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
            /// 不明身份患者标识
            /// </summary>
            public const string UNKNOWN_INDICATOR = "UNKNOWN_INDICATOR";
            /// <summary>
            /// 重要人物标志
            /// </summary>
            public const string VIP_INDICATOR = "VIP_INDICATOR";
            /// <summary>
            /// 保密等级
            /// </summary>
            public const string SECURE_GRADE = "SECURE_GRADE";
            /// <summary>
            /// 主索引合并标志
            /// </summary>
            public const string MERGED_INDICATOR = "MERGED_INDICATOR";
            /// <summary>
            /// 最后就诊日期
            /// </summary>
            public const string LAST_VISIT_DATE = "LAST_VISIT_DATE";
            /// <summary>
            /// 创建日期
            /// </summary>
            public const string CREATE_DATE_TIME = "CREATE_DATE_TIME";
            /// <summary>
            /// 操作员
            /// </summary>
            public const string OPERATOR_NAME = "OPERATOR_NAME";
        }
    }
}
