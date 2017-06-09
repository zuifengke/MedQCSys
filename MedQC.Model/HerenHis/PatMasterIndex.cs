/***************************************************
 * 和仁HIS患者首页实体类
 * 作者：yehui
 * 时间：2017-06-05
 **************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib.HerenHis
{
    public class PatMasterIndex : DbTypeBase
    {
        /// <summary>
        /// 编码类型标识号
        /// </summary>
        public string CODETYPE_ID { get; set; }
        /// <summary>
        /// 患者标识号
        /// </summary>
        public string PATIENT_ID { get; set; }
        /// <summary>
        /// 门诊号
        /// </summary>
        public string OUTP_NO { get; set; }
        /// <summary>
        /// 住院号
        /// </summary>
        public string INP_NO { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string NAME { get; set; }
        /// <summary>
        /// 姓名拼音
        /// </summary>
        public string NAME_PHONETIC { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string SEX { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime DATE_OF_BIRTH { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string ID_NO { get; set; }
        /// <summary>
        /// 医保账户分类
        /// </summary>
        public string SECURITY_TYPE { get; set; }
        /// <summary>
        /// 账户编号
        /// </summary>
        public string SECURITY_NO { get; set; }
        /// <summary>
        /// 国籍
        /// </summary>
        public string CITIZENSHIP { get; set; }
        /// <summary>
        /// 民族
        /// </summary>
        public string NATION { get; set; }
        /// <summary>
        /// 身份
        /// </summary>
        public string IDENTITY { get; set; }
        /// <summary>
        /// 费别
        /// </summary>
        public string CHARGE_TYPE { get; set; }
        /// <summary>
        /// 合同单位
        /// </summary>
        public string UNIT_IN_CONTRACT { get; set; }
        /// <summary>
        /// 出生地地址-省（自治区、直辖市）
        /// </summary>
        public string BIRTH_PLACE_PROVINCE { get; set; }
        /// <summary>
        /// 出生地地址-市（地区）
        /// </summary>
        public string BIRTH_PLACE_CITY { get; set; }
        /// <summary>
        ///出生地地址-县（区）
        /// </summary>
        public string BIRTH_PLACE_COUNTY { get; set; }
        /// <summary>
        /// 出生地编码
        /// </summary>
        public string BIRTH_PLACE_CODE { get; set; }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string NATIVE_PLACE { get; set; }
        /// <summary>
        /// 现住地址-省（自治区、直辖市）
        /// </summary>
        public string PRESENT_ADDRESS_PROVINCE { get; set; }
        /// <summary>
        /// 现住地址-市（地区）
        /// </summary>
        public string PRESENT_ADDRESS_CITY { get; set; }
        /// <summary>
        /// 现住地址-县（区）
        /// </summary>
        public string PRESENT_ADDRESS_COUNTY { get; set; }
        /// <summary>
        /// 现住地址-乡（镇、街道办事处）、村（街、路、弄等）、门牌号码
        /// </summary>
        public string PRESENT_ADDRESS_OTHERS { get; set; }
        /// <summary>
        /// 现住址编码
        /// </summary>
        public string PRESENT_ADDRESS_CODE { get; set; }
        /// <summary>
        /// 现住址邮编
        /// </summary>
        public string PRESENT_ADDRESS_ZIPCODE { get; set; }
        /// <summary>
        ///  户口地址-省（自治区、直辖市）
        /// </summary>
        public string REGISTERED_RESIDENCE_PROVINCE { get; set; }
        /// <summary>
        ///  户口地址-市（地区）
        /// </summary>
        public string REGISTERED_RESIDENCE_CITY { get; set; }
        /// <summary>
        /// 户口地址-县（区）
        /// </summary>
        public string REGISTERED_RESIDENCE_COUNTY { get; set; }
        /// <summary>
        /// 户口地址-乡（镇、街道办事处）、村（街、路、弄等）、门牌号码
        /// </summary>
        public string REGISTERED_RESIDENCE_OTHERS { get; set; }
        /// <summary>
        /// 户口地址编码
        /// </summary>
        public string REGISTERED_RESIDENCE_CODE { get; set; }
        /// <summary>
        /// 户口地址邮编
        /// </summary>
        public string REGISTERED_RESIDENCE_ZIPCODE { get; set; }
        /// <summary>
        /// 工作单位
        /// </summary>
        public string SERVICE_AGENCY { get; set; }
        /// <summary>
        ///  工作单位地址
        /// </summary>
        public string WORKING_ADDRESS { get; set; }
        /// <summary>
        ///  工作单位地址邮编
        /// </summary>
        public string WORKING_ADDRESS_ZIPCODE { get; set; }
        /// <summary>
        ///  单位电话号码
        /// </summary>
        public string PHONE_NUMBER_BUSINESS { get; set; }
        /// <summary>
        ///  电子邮件
        /// </summary>
        public string EMAIL { get; set; }
        /// <summary>
        ///  联系电话
        /// </summary>
        public string PHONE_NUMBER { get; set; }
        /// <summary>
        /// 联系人姓名
        /// </summary>
        public string NEXT_OF_KIN { get; set; }
        /// <summary>
        /// 与联系人关系
        /// </summary>
        public string RELATIONSHIP { get; set; }
        /// <summary>
        ///  联系人地址
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
        /// 不明身份患者标识
        /// </summary>
        public decimal UNKNOWN_INDICATOR { get; set; }
        /// <summary>
        /// 重要人物标志
        /// </summary>
        public decimal VIP_INDICATOR { get; set; }
        /// <summary>
        /// 保密等级
        /// </summary>
        public decimal SECURE_GRADE { get; set; }
        /// <summary>
        /// 主索引合并标志
        /// </summary>
        public decimal MERGED_INDICATOR { get; set; }
        /// <summary>
        /// 最后就诊日期
        /// </summary>
        public DateTime LAST_VISIT_DATE { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CREATE_DATE_TIME { get; set; }
        /// <summary>
        /// 操作员
        /// </summary>
        public string OPERATOR_NAME { get; set; }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
