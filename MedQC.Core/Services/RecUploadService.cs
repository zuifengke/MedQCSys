using EMRDBLib;
using EMRDBLib.DbAccess;
using EMRDBLib.HerenHis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heren.Common.Libraries;
using EMRDBLib.BAJK;
using Heren.MedQC.Model.BAJK;

namespace Heren.MedQC.Core.Services
{
    /// <summary>
    /// 病案上传服务
    /// </summary>
    public class RecUploadService
    {
        private static RecUploadService m_instance = null;
        /// <summary>
        /// 病案上传服务
        /// </summary>
        public static RecUploadService Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new RecUploadService();
                return m_instance;
            }
        }

        private RecUploadService()
        {

        }
        /// <summary>
        /// 性别对照字典集合
        /// </summary>
        private List<RecCodeCompasion> SexDict = null;
        /// <summary>
        /// 婚姻对照字典集合
        /// </summary>
        private List<RecCodeCompasion> MaritalStatusDict = null;
        /// <summary>
        /// 职业
        /// </summary>
        private List<RecCodeCompasion> OccupationDict = null;
        /// <summary>
        /// 行政区域/籍贯/住址等字典对照集合
        /// </summary>
        private List<RecCodeCompasion> AreaDict = null;
        /// <summary>
        /// 民族字典对照集合
        /// </summary>
        private List<RecCodeCompasion> NationDict = null;
        /// <summary>
        /// 关系字典对照集合
        /// </summary>
        private List<RecCodeCompasion> RelationShipDict = null;
        /// <summary>
        /// ABO血型字典对照集合
        /// </summary>
        private List<RecCodeCompasion> BloodABOTypeDict = null;
        /// <summary>
        /// RH血型字典对照集合
        /// </summary>
        private List<RecCodeCompasion> BloodRHTypeDict = null;
        /// <summary>
        /// 病案质量
        /// </summary>
        private List<RecCodeCompasion> MrQualityDict = null;
        /// <summary>
        /// 入院方式
        /// </summary>
        private List<RecCodeCompasion> PatientClassDict = null;
        /// <summary>
        /// 国籍
        /// </summary>
        private List<RecCodeCompasion> CountryDict = null;
        /// <summary>
        /// 出院方式
        /// </summary>
        private List<RecCodeCompasion> DischargeDisPositionDict = null;
        /// <summary>
        /// 诊断类别
        /// </summary>
        private List<RecCodeCompasion> DiagnosisTypeDict = null;
        /// <summary>
        /// 转归情况/治疗结果
        /// </summary>
        private List<RecCodeCompasion> TreatingResultDict = null;
        /// <summary>
        /// 麻醉方法
        /// </summary>
        private List<RecCodeCompasion> ANAESTHESIA_DICT = null;
        /// <summary>
        /// 切口等级
        /// </summary>
        private List<RecCodeCompasion> WOUND_GRADE_DICT = null;
        /// <summary>
        /// 愈合情况
        /// </summary>
        private List<RecCodeCompasion> HEAL_DICT = null;
        /// <summary>
        /// 手术等级
        /// </summary>
        private List<RecCodeCompasion> OPERATION_SCALE_DICT = null;
        /// <summary>
        /// 过敏药物
        /// </summary>
        private List<RecCodeCompasion> ALLERGEN_DRUG_DICT = null;
        /// <summary>
        /// 付款方式/费别
        /// </summary>
        private List<RecCodeCompasion> CHARGE_TYPE_DICT = null;
        /// <summary>
        /// 诊断对照组字典
        /// </summary>
        private List<RecCodeCompasion> DIAG_COMP_GROUP_DICT = null;
        /// <summary>
        /// 科室字典
        /// </summary>
        private List<RecCodeCompasion> DEPT_DICT = null;
        /// <summary>
        /// 首页病案费用分类
        /// </summary>
        private List<RecCodeCompasion> MR_FEE_CLASS_DICT = null;
        /// <summary>
        /// 入院病情
        /// </summary>
        private List<RecCodeCompasion> PAT_ADM_CONDITION_DICT = null;
        public bool InitializeDict()
        {
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("SEX_DICT", ref this.SexDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("MARITAL_STATUS_DICT", ref this.MaritalStatusDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("OCCUPATION_DICT", ref this.OccupationDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("AREA_DICT", ref this.AreaDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("NATION_DICT", ref this.NationDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("RELATIONSHIP_DICT", ref this.RelationShipDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("BLOOD_ABO_TYPE_DICT", ref this.BloodABOTypeDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("BLOOD_RH_TYPE_DICT", ref this.BloodRHTypeDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("MR_QUALITY_DICT", ref this.MrQualityDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("PATIENT_CLASS_DICT", ref this.PatientClassDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("COUNTRY_DICT", ref this.CountryDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("DISCHARGE_DISPOSITION_DICT", ref this.DischargeDisPositionDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("DIAGNOSIS_TYPE_DICT", ref this.DiagnosisTypeDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("TREATING_RESULT_DICT", ref this.TreatingResultDict);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("ANAESTHESIA_DICT", ref this.ANAESTHESIA_DICT);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("WOUND_GRADE_DICT", ref this.WOUND_GRADE_DICT);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("HEAL_DICT", ref this.HEAL_DICT);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("OPERATION_SCALE_DICT", ref this.OPERATION_SCALE_DICT);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("ALLERGEN_DRUG_DICT", ref this.ALLERGEN_DRUG_DICT);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("CHARGE_TYPE_DICT", ref this.CHARGE_TYPE_DICT);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("DIAG_COMP_GROUP_DICT", ref this.DIAG_COMP_GROUP_DICT);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("DEPT_DICT", ref this.DEPT_DICT);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("MR_FEE_CLASS_DICT", ref this.MR_FEE_CLASS_DICT);
            RecCodeCompasionAccess.Instance.GetRecCodeCompasions("PAT_ADM_CONDITION_DICT", ref this.PAT_ADM_CONDITION_DICT);
            return true;
        }
        /// <summary>
        /// 省人民病案上传接口
        /// </summary>
        /// <param name="szPatientID"></param>
        /// <param name="szVisitID"></param>
        /// <returns></returns>
        public bool Upload(string szPatientID, string szVisitID, ref string error)
        {
            try
            {
                StringBuilder sbField = new StringBuilder();
                InpVisit inpVisit = null;
                PatMasterIndex patMasterIndex = null;
                short shRet = EMRDBLib.DbAccess.HerenHis.InpVisitAccess.Instance.GetInpVisit(szPatientID, szVisitID, ref inpVisit);
                shRet = PatMasterIndexAccess.Instance.GetModel(szPatientID, ref patMasterIndex);
                if (inpVisit == null || patMasterIndex == null)
                    return false;

                string patientID = inpVisit.PATIENT_ID;
                string visitNo = inpVisit.VISIT_NO;
                string visitID = inpVisit.VISIT_ID.ToString();
                string inpNo = inpVisit.INP_NO;
                //1、获取和仁his患者诊断信息
                List<Diagnosis> lstDiagnosis = null;
                shRet = DiagnosisAccess.Instance.GetList(patientID, visitNo, ref lstDiagnosis);
                //2、获取和仁his患者诊断对照记录
                List<DiagComparing> lstDiagComparing = null;
                shRet = DiagComparingAccess.Instance.GetList(patientID, visitNo, ref lstDiagComparing);
                if (inpVisit == null)
                    return false;
                #region 上传患者基本信息
                EMRDBLib.BAJK.BAJK08 bajk08 = null;
                shRet = BAJK08Access.Instance.GetBAJK08s(szPatientID, szVisitID, ref bajk08);
                if (bajk08 == null)
                    bajk08 = new EMRDBLib.BAJK.BAJK08();
                //bajk08.COL0801 = szPatientID;
                //病案号
                bajk08.COL0801 = szPatientID;
                if (string.IsNullOrEmpty(inpVisit.NAME))
                    bajk08.COL0802 = patMasterIndex.NAME;
                else
                    bajk08.COL0802 = inpVisit.NAME;
                if (SexDict != null)
                {
                    var result = SexDict.Where(m => m.CODE_NAME == patMasterIndex.SEX).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0803 = decimal.Parse(result.DM);
                    }
                }
                bajk08.COL0804 = inpVisit.VISIT_ID;
                bajk08.COL0805 = patMasterIndex.DATE_OF_BIRTH;
                if (MaritalStatusDict != null && !string.IsNullOrEmpty(inpVisit.MARITAL_STATUS))
                {
                    var result = MaritalStatusDict.Find(m => m.CODE_NAME == inpVisit.MARITAL_STATUS);
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0806 = decimal.Parse(result.DM);
                    }
                }
                if (OccupationDict != null && !string.IsNullOrEmpty(inpVisit.OCCUPATION))
                {
                    var result = OccupationDict.Where(m => m.CODE_ID == inpVisit.OCCUPATION).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        //职业序号
                        bajk08.COL0807 = decimal.Parse(result.DM);
                    }
                }
                if (this.AreaDict != null && !string.IsNullOrEmpty(patMasterIndex.NATIVE_PLACE))
                {
                    var result = this.AreaDict.Where(m => m.CODE_ID == patMasterIndex.NATIVE_PLACE).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        //籍贯序号
                        bajk08.COL0808 = decimal.Parse(result.DM);
                    }
                }

                if (this.NationDict != null && !string.IsNullOrEmpty(patMasterIndex.NATION))
                {
                    var result = this.NationDict.Where(m => m.CODE_NAME == patMasterIndex.NATION).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        //民族序号
                        bajk08.COL0809 = decimal.Parse(result.DM);
                    }
                }
                //身份证
                bajk08.COL0810 = patMasterIndex.ID_NO;
                bajk08.COL0811 = patMasterIndex.WORKING_ADDRESS;
                bajk08.COL0812 = patMasterIndex.PHONE_NUMBER_BUSINESS;
                bajk08.COL0813 = patMasterIndex.WORKING_ADDRESS_ZIPCODE;
                bajk08.COL0814 = patMasterIndex.PRESENT_ADDRESS_COUNTY + patMasterIndex.PRESENT_ADDRESS_OTHERS;//县+街道门牌
                bajk08.COL0815 = patMasterIndex.PRESENT_ADDRESS_ZIPCODE;
                bajk08.COL0816 = patMasterIndex.NEXT_OF_KIN;

                if (this.RelationShipDict != null && !string.IsNullOrEmpty(patMasterIndex.RELATIONSHIP))
                {
                    var result = this.RelationShipDict.Where(m => m.CODE_ID == patMasterIndex.RELATIONSHIP).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0817 = decimal.Parse(result.DM);
                    }
                }
                bajk08.COL0818 = patMasterIndex.NEXT_OF_KIN_ADDR;
                bajk08.COL0819 = patMasterIndex.NEXT_OF_KIN_PHONE;
                if (this.BloodABOTypeDict != null && !string.IsNullOrEmpty(inpVisit.BLOOD_TYPE))
                {
                    var result = this.BloodABOTypeDict.Where(m => m.CODE_NAME == inpVisit.BLOOD_TYPE).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0820 = decimal.Parse(result.DM);
                    }
                }
                if (this.BloodRHTypeDict != null && !string.IsNullOrEmpty(inpVisit.BLOOD_TYPE_RH))
                {
                    var result = this.BloodRHTypeDict.Where(m => m.CODE_ID == inpVisit.BLOOD_TYPE_RH).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0821 = decimal.Parse(result.DM);
                    }
                }
                bajk08.COL0822 = inpVisit.EMER_TREAT_TIMES;
                bajk08.COL0823 = inpVisit.ESC_EMER_TIMES;

                if (this.MrQualityDict != null && !string.IsNullOrEmpty(inpVisit.MR_QUALITY))
                {
                    var result = this.MrQualityDict.Where(m => m.CODE_NAME == inpVisit.MR_QUALITY).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0827 = decimal.Parse(result.DM);
                    }
                }

                bajk08.COL0828 = inpVisit.DOCTOR_OF_CONTROL_QUALITY;
                bajk08.COL0829 = inpVisit.NURSE_OF_CONTROL_QUALITY;
                //bajk08.COL0830 治疗类别没有
                if (this.PatientClassDict != null && !string.IsNullOrEmpty(inpVisit.PATIENT_CLASS))
                {
                    var result = this.MrQualityDict.Where(m => m.CODE_ID == inpVisit.PATIENT_CLASS).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0831 = decimal.Parse(result.DM);
                    }
                }
                if (inpVisit.BLOOD_TRAN_TIMES > 0 && inpVisit.BLOOD_TRAN_REACT_TIMES == 0)
                {
                    bajk08.COL0832 = 1;
                }
                else if (inpVisit.BLOOD_TRAN_TIMES > 0 && inpVisit.BLOOD_TRAN_REACT_TIMES > 0)
                {
                    bajk08.COL0832 = 2;
                }
                else if (inpVisit.BLOOD_TRAN_TIMES == 0)
                {
                    bajk08.COL0832 = 3;
                }
                bajk08.COL0834 = inpVisit.DIRECTOR_ID;
                bajk08.COL0835 = inpVisit.CHIEF_DOCTOR_ID;
                bajk08.COL0836 = inpVisit.ATTENDING_DOCTOR_ID;
                bajk08.COL0837 = inpVisit.DOCTOR_IN_CHARGE_ID;
                //bajk08.COL0838 = inpVisit.ADVANCED_STUDIES_DOCTOR;//进修医师编号未获取
                //bajk08.COL0839 = inpVisit.PRACTICE_DOCTOR;//实习医师编号未获取
                if (inpVisit.CATALOG_DATE != inpVisit.DefaultTime2)
                    bajk08.COL0841 = inpVisit.CATALOG_DATE;
                bajk08.COL0842 = inpVisit.CATALOGER;
                bajk08.COL0844 = inpVisit.DEPT_ADMISSION_TO;//未对照科室代码
                if (inpVisit.ADMISSION_DATE_TIME != inpVisit.DefaultTime2)
                    bajk08.COL0845 = inpVisit.ADMISSION_DATE_TIME;
                bajk08.COL0847 = inpVisit.DEPT_DISCHARGE_FROM;//未对照出院科室代码
                if (inpVisit.DISCHARGE_DATE_TIME != inpVisit.DefaultTime2)
                    bajk08.COL0848 = inpVisit.DISCHARGE_DATE_TIME;
               
                if (inpVisit.DISCHARGE_DATE_TIME != inpVisit.DefaultTime2
                    && inpVisit.ADMISSION_DATE_TIME != inpVisit.DefaultTime2)
                    bajk08.COL0851 = GlobalMethods.SysTime.GetInpDays(inpVisit.ADMISSION_DATE_TIME, inpVisit.DISCHARGE_DATE_TIME);
                //bajk08.COL0852=其他方式未获取

                //总费用
                bajk08.COL0853 = inpVisit.TOTAL_COSTS;
               
                //bajk08.COL0855 转归情况，
                if (this.TreatingResultDict != null)
                {
                    var result = this.TreatingResultDict.Where(m => m.CODE_NAME == inpVisit.PROGNOSIS).FirstOrDefault();
                    if (result != null)
                    {
                        decimal d = 0;
                        if (GlobalMethods.Convert.StringToDecimal(result.DM, ref d))
                        {
                            bajk08.COL0855 = d;
                        }
                    }
                }
                //bajk08.COL0858 E序号未获取，搞不清含义
                //bajk08.COL0859 M序号未获取，
                bajk08.COL0866 = inpVisit.AUTOPSY_INDICATOR; //是否尸检
                bajk08.BRXH = bajk08.KEY0801;
                bajk08.FLAG = 0;
                bajk08.COL0871 = inpVisit.VISIT_NO;//唯一号设为就诊流水号
                //bajk08.COL0873 国籍
                if (this.CountryDict != null && !string.IsNullOrEmpty(patMasterIndex.CITIZENSHIP))
                {
                    var result = this.CountryDict.Where(m => m.CODE_ID == patMasterIndex.CITIZENSHIP).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        decimal d = 0;
                        if (GlobalMethods.Convert.StringToDecimal(result.DM, ref d))
                            bajk08.COL0873 = d;
                    }
                }
                bajk08.COL0882 = inpVisit.DEPT_ADMISSION_TO;
                bajk08.COL0883 = inpVisit.DEPT_DISCHARGE_FROM;

                if (this.DIAG_COMP_GROUP_DICT != null && lstDiagComparing != null)
                {
                    #region 诊断对照记录上传

                    //bajk08.COL0884 临床与病理未获取
                    var result = this.DIAG_COMP_GROUP_DICT.Where(m => m.CODE_NAME == "临床与病理").FirstOrDefault();
                    if (result != null)
                    {
                        var diagComparing = lstDiagComparing.Where(m => m.DIAG_COMPARE_GROUP_CODE == result.CODE_ID).FirstOrDefault();
                        if (diagComparing != null)
                        {
                            decimal d = 0;
                            if (GlobalMethods.Convert.StringToDecimal(diagComparing.DIAG_CORRESPONDENCE, ref d))
                            {
                                bajk08.COL0884 = d;
                            }
                        }
                    }
                    //bajk08.COL0885 放射与病理未获取
                    result = this.DIAG_COMP_GROUP_DICT.Where(m => m.CODETYPE_NAME == "放射与病理").FirstOrDefault();
                    if (result != null)
                    {
                        var diagComparing = lstDiagComparing.Where(m => m.DIAG_COMPARE_GROUP_CODE == result.CODE_ID).FirstOrDefault();
                        if (diagComparing != null)
                        {
                            decimal d = 0;
                            if (GlobalMethods.Convert.StringToDecimal(diagComparing.DIAG_CORRESPONDENCE, ref d))
                            {
                                bajk08.COL0885 = d;
                            }
                        }
                    }
                    //bajk08.COL0885 放射与病理未获取
                    result = this.DIAG_COMP_GROUP_DICT.Where(m => m.CODE_NAME == "放射与病理").FirstOrDefault();
                    if (result != null)
                    {
                        var diagComparing = lstDiagComparing.Where(m => m.DIAG_COMPARE_GROUP_CODE == result.CODE_ID).FirstOrDefault();
                        if (diagComparing != null)
                        {
                            decimal d = 0;
                            if (GlobalMethods.Convert.StringToDecimal(diagComparing.DIAG_CORRESPONDENCE, ref d))
                            {
                                bajk08.COL0885 = d;
                            }
                        }
                    }
                    //bajk08.COL0889 术前与术后
                    result = this.DIAG_COMP_GROUP_DICT.Where(m => m.CODE_NAME == "术前与术后").FirstOrDefault();
                    if (result != null)
                    {
                        var diagComparing = lstDiagComparing.Where(m => m.DIAG_COMPARE_GROUP_CODE == result.CODE_ID).FirstOrDefault();
                        if (diagComparing != null)
                        {
                            decimal d = 0;
                            if (GlobalMethods.Convert.StringToDecimal(diagComparing.DIAG_CORRESPONDENCE, ref d))
                            {
                                bajk08.COL0889 = d;
                            }
                        }
                    }
                    //bajk08.COL0856 入出符合标志未获取
                    result = this.DIAG_COMP_GROUP_DICT.Where(m => m.CODE_NAME == "入院与出院").FirstOrDefault();
                    if (result != null)
                    {
                        var diagComparing = lstDiagComparing.Where(m => m.DIAG_COMPARE_GROUP_CODE == result.CODE_ID).FirstOrDefault();
                        if (diagComparing != null)
                        {
                            decimal d = 0;
                            if (GlobalMethods.Convert.StringToDecimal(diagComparing.DIAG_CORRESPONDENCE, ref d))
                            {
                                bajk08.COL0856 = d;
                            }
                        }
                    }
                    //bajk08.COL0857 门出符合标志未获取 
                    result = this.DIAG_COMP_GROUP_DICT.Where(m => m.CODE_NAME == "门诊与出院").FirstOrDefault();
                    if (result != null)
                    {
                        var diagComparing = lstDiagComparing.Where(m => m.DIAG_COMPARE_GROUP_CODE == result.CODE_ID).FirstOrDefault();
                        if (diagComparing != null)
                        {
                            decimal d = 0;
                            if (GlobalMethods.Convert.StringToDecimal(diagComparing.DIAG_CORRESPONDENCE, ref d))
                            {
                                bajk08.COL0857 = d;
                            }
                        }
                    }
                    #endregion
                }
                //bajk08.COL0887 主要诊断
                if (this.DiagnosisTypeDict != null)
                {
                    var result = this.DiagnosisTypeDict.Where(m => m.CODE_NAME == "主要诊断").FirstOrDefault();
                    if (result != null)
                    {
                        var diagnosis = lstDiagnosis.Where(m => m.DIAG_TYPE == result.CODE_ID).FirstOrDefault();
                        if (diagnosis != null)
                        {
                            bajk08.COL0887 = diagnosis.DIAG_DESC;
                        }

                        //bajk08.COL0906入院病情(主诊断)1.有; 2.临床未确定; 3.情况不明; 4.无
                        if (this.PAT_ADM_CONDITION_DICT != null && !string.IsNullOrEmpty(diagnosis.ADMISSION_CONDITION))
                        {
                            decimal d = 0;
                            if (GlobalMethods.Convert.StringToDecimal(diagnosis.ADMISSION_CONDITION, ref d))
                                bajk08.COL0906 = d;
                        }
                        //bajk08.COL0854=疾病序号未获取，
                        BaIcdDM baicdDM = null;
                        shRet = BaIcdDMAccess.Instance.GetModel(diagnosis.DIAG_CODE, ref baicdDM);
                        if (baicdDM != null)//代码库中未找到，则不上传（暂定）
                        {
                            bajk08.COL0854 = baicdDM.JBXH;
                        }
                        //bajk08.COL0843 手术标志
                        bajk08.COL0843 = diagnosis.OPER_TREAT_INDICATOR;
                        //bajk08.COL0849= 确诊天数
                        bajk08.COL0849 = GlobalMethods.SysTime.GetInpDays(inpVisit.ADMISSION_DATE_TIME, diagnosis.DIAG_DATE);
                        //bajk08.COL0850 确诊日期
                        bajk08.COL0850 = diagnosis.DIAG_DATE;
                    }

                }
                //bajk08.COL0888 结帐标识未获取
                //bajk08.COL0890 自动出院
                bajk08.COL0891 = inpVisit.SECURITY_NO;
                //bajk08.COL0892 新生儿体重未获取
                //bajk08.COL0893 新生儿入院体重未获取
                if (this.AreaDict != null && !string.IsNullOrEmpty(patMasterIndex.BIRTH_PLACE_CODE))
                {
                    var result = this.AreaDict.Where(m => m.CODE_ID == patMasterIndex.BIRTH_PLACE_CODE).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0894 = decimal.Parse(result.DM);
                    }
                }
                if (this.AreaDict != null && !string.IsNullOrEmpty(patMasterIndex.PRESENT_ADDRESS_CODE))
                {
                    var result = this.AreaDict.Where(m => m.CODE_ID == patMasterIndex.PRESENT_ADDRESS_CODE).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0895 = patMasterIndex.PRESENT_ADDRESS_COUNTY
+ patMasterIndex.PRESENT_ADDRESS_OTHERS;
                    }
                }
                bajk08.COL0896 = patMasterIndex.PHONE_NUMBER;
                bajk08.COL0897 = patMasterIndex.PRESENT_ADDRESS_CODE;
                if (inpVisit.DATE_OF_CONTROL_QUALITY != inpVisit.DefaultTime2)
                    bajk08.COL0898 = inpVisit.DATE_OF_CONTROL_QUALITY;
                //bajk08.COL0899 出院方式/离院方式
                if (this.DischargeDisPositionDict != null && !string.IsNullOrEmpty(inpVisit.DISCHARGE_DISPOSITION))
                {
                    var result = this.AreaDict.Where(m => m.CODE_ID == inpVisit.DISCHARGE_DISPOSITION).FirstOrDefault();
                    if (result != null && !string.IsNullOrEmpty(result.DM))
                    {
                        bajk08.COL0899 = decimal.Parse(result.DM);
                    }
                }
                //bajk08.COLni0900= 拟接收医疗机构名称1未获取
                //bajk08.COL0902再住院计划未获取
                decimal HAS_ADMISSION_AGAIN_PLAN = 0;
                if (GlobalMethods.Convert.StringToDecimal(inpVisit.HAS_ADMISSION_AGAIN_PLAN, ref HAS_ADMISSION_AGAIN_PLAN))
                {
                    bajk08.COL0902 = HAS_ADMISSION_AGAIN_PLAN;
                }
                //bajk08.COL0903再住院目的
                bajk08.COL0903 = inpVisit.FOR_INPATIENT_PURPOSES;
                //bajk08.COL0904入院前昏迷时间

                //bajk08.COL0905入院后昏迷时间
                //bajk08.COL0907 药物过敏标志
                if (!string.IsNullOrEmpty(inpVisit.ALERGY_DRUGS))
                {
                    bajk08.COL0907 = 1;
                }
                //bajk08.COL0908 责任护士编号
                //bajk08.COL0914
                //bajk08.COL0915
                //bajk08.COL0916
                //bajk08.COL0917
                //bajk08.COL0918
                //bajk08.COL0919
                //bajk08.COL0920
                //bajk08.COL0921
                //bajk08.COL0922
                //bajk08.COL0923
                //bajk08.COL0924
                //bajk08.COL0925
                //bajk08.COL0926
                //bajk08.COL0927
                //bajk08.COL0928
                //bajk08.COL0929
                //bajk08.COL0930
                //bajk08.COL0931
                //bajk08.COL0932
                //bajk08.COL0933
                //bajk08.COL0934
                //bajk08.COL0935
                //bajk08.COL0936
                if (bajk08.KEY0801 == 0)
                {
                    //bajk08.KEY0801 = BAJK08Access.Instance.MakeKey0801();
                    bajk08.KEY0801 = BAJK08Access.Instance.GetNextKey0801();
                    if (bajk08.KEY0801 == 0)
                    {
                        error = "获取病案接口库的病人序号失败";
                        return false;
                    }
                    shRet = BAJK08Access.Instance.Insert(bajk08);
                    if (shRet != SystemData.ReturnValue.OK)
                        return false;
                }
                else
                {
                    shRet = BAJK08Access.Instance.Update(bajk08);
                }
                #endregion
                #region 上传诊断
                //1、获取和仁his患者诊断信息
                //List<Diagnosis> lstDiagnosis = null;
                //shRet = DiagnosisAccess.Instance.GetList(patientID, visitNo, ref lstDiagnosis);
                //2、获取联众已经上传的诊断情况
                List<EMRDBLib.BAJK.BAJK09> lstBajk09 = null;
                shRet = BAJK09Access.Instance.GetBAJK09s(bajk08.KEY0801, ref lstBajk09);
                //3、清理已经上传的诊断情况
                if (lstBajk09 != null && lstBajk09.Count > 0)
                {
                    shRet = BAJK09Access.Instance.Delete(bajk08.KEY0801);
                }
                //4、上传诊断情况
                if (lstDiagnosis != null)
                {
                    foreach (var item in lstDiagnosis)
                    {
                        string jbmc = item.DIAG_DESC;
                        DiagnosisDict diagnosisDict = new DiagnosisDict();
                        shRet = DiagnosisDictAccess.Instance.GetModel(item.DIAG_DESC, ref diagnosisDict);
                        if (diagnosisDict == null)//首页诊断不标准，不上传
                            continue;
                        //查询联众疾病代码库疾病序号
                        BaIcdDM baicdDM = null;
                        shRet = BaIcdDMAccess.Instance.GetModel(diagnosisDict.DIAGNOSIS_CODE, ref baicdDM);
                        if (baicdDM == null)//代码库中未找到，则不上传（暂定）
                            continue;
                        EMRDBLib.BAJK.BAJK09 bajk09 = new EMRDBLib.BAJK.BAJK09();
                        bajk09.COL0901 = baicdDM.JBXH;
                        if (this.TreatingResultDict != null && !string.IsNullOrEmpty(item.TREAT_RESULT))
                        {
                            var result = this.TreatingResultDict.Where(m => m.CODE_NAME == item.TREAT_RESULT).FirstOrDefault();
                            if (result != null && !string.IsNullOrEmpty(result.DM))
                            {
                                bajk09.COL0902 = decimal.Parse(result.DM);
                            }
                        }
                        //诊断全称
                        bajk09.COL0903 = item.DIAG_DESC;
                        //bajk09.COL0904 入院病情
                        decimal d = 0;
                        if (!string.IsNullOrEmpty(item.ADMISSION_CONDITION)
                            && GlobalMethods.Convert.StringToDecimal(item.ADMISSION_CONDITION, ref d))
                            bajk09.COL0904 = d;
                        bajk09.KEY0901 = bajk08.KEY0801;
                        if (this.DiagnosisTypeDict != null && !string.IsNullOrEmpty(item.DIAG_TYPE))
                        {
                            var result = this.DiagnosisTypeDict.Where(m => m.CODE_ID == item.DIAG_TYPE).FirstOrDefault();
                            if (result != null && !string.IsNullOrEmpty(result.DM))
                            {
                                bajk09.KEY0902 = decimal.Parse(result.DM);
                            }
                        }
                        bajk09.KEY0903 = item.DIAG_NO;
                        shRet = BAJK09Access.Instance.Insert(bajk09);
                    }
                }
                #endregion
                #region 上传手术 当前方式可能存在问题
                List<OperationName> lstOperationNames = null;
                shRet = OperationNameAccess.Instance.GetOperationNames(patientID, visitID, ref lstOperationNames);
                //List<EMRDBLib.HerenHis.Operation> lstOperation = null;
                //shRet = EMRDBLib.DbAccess.HerenHis.OperationAccess.Instance.GetList(patientID, visitNo, ref lstOperation);
                //2、获取联众已经上传的手术情况
                List<EMRDBLib.BAJK.BAJK11> lstBajk11 = null;
                shRet = BAJK11Access.Instance.GetBAJK11s(bajk08.KEY0801, ref lstBajk11);
                //3、清理已经上传的手术情况
                if (lstBajk11 != null && lstBajk11.Count > 0)
                {
                    shRet = BAJK11Access.Instance.Delete(bajk08.KEY0801);
                }

                if (lstOperationNames != null)
                {
                    foreach (var item in lstOperationNames)
                    {
                        EMRDBLib.HerenHis.Operation operation = null;
                        shRet = EMRDBLib.DbAccess.HerenHis.OperationAccess.Instance.GetModel(item.PATIENT_ID, item.VISIT_ID.ToString(), item.OPERATION_NO.ToString(), ref operation);
                        OperationMaster operationMaster = null;
                        shRet = OperationMasterAccess.Instance.GetOperationMaster(item.OPER_NO, ref operationMaster);
                        if (operation != null && operationMaster != null)
                        {
                            BAJK11 bajk11 = new BAJK11();
                            bajk11.COL1101 = operation.OPERATING_DATE.Date;
                            bajk11.COL1102 = GlobalMethods.SysTime.GetInpDays(inpVisit.ADMISSION_DATE_TIME, operation.OPERATING_DATE);
                            if (this.ANAESTHESIA_DICT != null)
                            {
                                var result = this.ANAESTHESIA_DICT.Where(m => m.CODE_NAME == operation.ANAESTHESIA_METHOD).FirstOrDefault();
                                if (result != null)
                                {
                                    bajk11.COL1104 = decimal.Parse(result.DM);
                                }
                            }
                            if (this.WOUND_GRADE_DICT != null)
                            {
                                var result = this.WOUND_GRADE_DICT.Where(m => m.CODE_ID == operation.WOUND_GRADE).FirstOrDefault();
                                if (result != null)
                                {
                                    bajk11.COL1105 = decimal.Parse(result.DM);
                                }
                            }
                            if (this.HEAL_DICT != null)
                            {
                                var result = this.HEAL_DICT.Where(m => m.CODE_ID == operation.HEAL).FirstOrDefault();
                                if (result != null)
                                {
                                    //bajk11.COL1106 切口愈合情况
                                    bajk11.COL1106 = decimal.Parse(result.DM);
                                }
                            }
                            bajk11.COL1107 = operationMaster.OPERATOR_DOCTOR_ID;
                            bajk11.COL1108 = operationMaster.FIRST_ANESTHESIA_ID;
                            bajk11.COL1109 = operationMaster.SECOND_ANESTHESIA_ID;
                            bajk11.COL1110 = operationMaster.ANESTHESIA_DOCTOR_ID;
                            //bajk11.COL1111=符合标志未获取
                            //bajk11.COL1112 手术组号未获取
                            bajk11.COL1112 = operation.OPERATION_NO;
                            //bajk11.COL1113
                            bajk11.COL1114 = operationMaster.DIAG_BEFORE_OPERATION;
                            bajk11.COL1115 = operationMaster.DIAG_AFTER_OPERATION;
                            if (this.OPERATION_SCALE_DICT != null)
                            {
                                var result = this.OPERATION_SCALE_DICT.Where(m => m.CODE_ID == item.OPERATION_SCALE).FirstOrDefault();
                                if (result != null)
                                {
                                    bajk11.COL1116 = decimal.Parse(result.DM);
                                }
                            }
                            bajk11.KEY1101 = bajk08.KEY0801;
                            bajk11.KEY1102 = operation.OPERATION_NO;
                            shRet = BAJK11Access.Instance.Insert(bajk11);
                        }
                    }
                }
                //if (lstOperation != null)
                //{
                //    foreach (var item in lstOperation)
                //    {
                //        BAJK11 bajk11 = new BAJK11();
                //        bajk11.COL1101 = item.OPERATING_DATE.Date;
                //        bajk11.COL1102 = GlobalMethods.SysTime.GetInpDays(inpVisit.ADMISSION_DATE_TIME, item.OPERATING_DATE);
                //        if (this.ANAESTHESIA_DICT != null)
                //        {
                //            var result = this.ANAESTHESIA_DICT.Where(m => m.CODE_NAME == item.ANAESTHESIA_METHOD).FirstOrDefault();
                //            if (result != null)
                //            {
                //                bajk11.COL1104 = decimal.Parse(result.DM);
                //            }
                //        }
                //        if (this.WOUND_GRADE_DICT != null)
                //        {
                //            var result = this.WOUND_GRADE_DICT.Where(m => m.CODE_ID == item.WOUND_GRADE).FirstOrDefault();
                //            if (result != null)
                //            {
                //                bajk11.COL1105 = decimal.Parse(result.DM);
                //            }
                //        }
                //        if (this.HEAL_DICT != null)
                //        {
                //            var result = this.HEAL_DICT.Where(m => m.CODE_ID == item.HEAL).FirstOrDefault();
                //            if (result != null)
                //            {
                //                bajk11.COL1106 = decimal.Parse(result.DM);
                //            }
                //        }
                //        bajk11.COL1107 = operationMaster.OPERATOR_DOCTOR_ID;
                //        bajk11.COL1108 = operationMaster.FIRST_ANESTHESIA_ID;
                //        bajk11.COL1109 = operationMaster.SECOND_ANESTHESIA_ID;
                //        bajk11.COL1110 = operationMaster.ANESTHESIA_DOCTOR_ID;
                //        //bajk11.COL1111=符合标志未获取
                //        //bajk11.COL1112 手术组号未获取
                //        //bajk11.COL1113
                //        bajk11.COL1114 = operationMaster.DIAG_BEFORE_OPERATION;
                //        bajk11.COL1115 = operationMaster.DIAG_AFTER_OPERATION;
                //        if (this.OPERATION_SCALE_DICT != null)
                //        {
                //            var result = this.OPERATION_SCALE_DICT.Where(m => m.CODE_ID == item.OPERATION_SCALE).FirstOrDefault();
                //            if (result != null)
                //            {
                //                bajk11.COL1116 = decimal.Parse(result.DM);
                //            }
                //        }
                //        bajk11.KEY1101 = bajk08.BRXH;
                //        bajk11.KEY1102 = operation.OPERATION_NO;
                //        //bajk11.COL1106
                //        shRet = BAJK11Access.Instance.Insert(bajk11);
                //    }
                //}
                #endregion
                #region 上传过敏药物
                //获取和仁his过敏史
                List<PatientAllergy> lstPatientAllergy = null;
                shRet = PatientAllergyAccess.Instance.GetList(patientID, visitNo, ref lstPatientAllergy);
                //获取已经上传给联众接口库的过敏情况信息
                List<BAJK12> lstBAJK12 = null;
                shRet = BAJK12Access.Instance.GetBAJK12s(bajk08.KEY0801, ref lstBAJK12);
                if (lstBAJK12 != null)
                {
                    BAJK12Access.Instance.Delete(bajk08.KEY0801);
                }
                //上传过敏药物
                if (lstPatientAllergy != null)
                {
                    foreach (var item in lstPatientAllergy)
                    {
                        //查找过敏药物序号
                        if (string.IsNullOrEmpty(item.ALLERGEN_DRUG_CODE))
                            continue;
                        var result = ALLERGEN_DRUG_DICT.Where(m => m.CODE_ID == item.ALLERGEN_DRUG_CODE).FirstOrDefault();
                        if (result != null)
                        {
                            BAJK12 bajk12 = new BAJK12();
                            bajk12.KEY1201 = bajk08.KEY0801;
                            bajk12.KEY1202 = decimal.Parse(result.DM);
                            shRet = BAJK12Access.Instance.Insert(bajk12);
                        }
                    }
                }
                #endregion
                #region 上传转科情况
                List<EMRDBLib.HerenHis.Transfer> lstTransfers = null;
                shRet = EMRDBLib.HerenHis.TransferAccess.Instance.GetList(patientID, visitNo, ref lstTransfers);
                List<BAJK13> lstBAJK13 = null;
                shRet = BAJK13Access.Instance.GetBAJK13s(bajk08.KEY0801, ref lstBAJK13);
                if (lstBAJK13 != null && lstBAJK13.Count > 0)
                {
                    //清空已上传记录
                    BAJK13Access.Instance.Delete(bajk08.KEY0801);
                }
                if (lstTransfers != null && lstTransfers.Count > 0)
                {
                    int orderNo = 1;
                    lstTransfers = lstTransfers.OrderBy(m => m.ADMISSION_DATE_TIME).ToList();
                    foreach (var item in lstTransfers)
                    {
                        BAJK13 bajk13 = new BAJK13();
                        bajk13.COL1301 = item.ADMISSION_DATE_TIME;
                        bajk13.COL1302 = item.DEPT_TRANSFER_TO;
                        bajk13.COL1303 = item.DISCHARGE_DATE_TIME;
                        bajk13.KEY1301 = bajk08.KEY0801;
                        bajk13.KEY1302 = orderNo;
                        shRet = BAJK13Access.Instance.Insert(bajk13);
                        orderNo++;
                    }
                }
                #endregion
                #region 上传费用

                List<InpBillDetail> lstInpBillDetail = null;
                shRet = InpBillDetailAccess.Instance.GetList(patientID, visitNo, ref lstInpBillDetail);
                if (lstInpBillDetail != null)
                {
                    BAJK15 bajk15 = null;
                    shRet = BAJK15Access.Instance.GetModel(bajk08.KEY0801, ref bajk15);
                    bool bajk15Exise = true;
                    if (bajk15 == null)
                    {
                        bajk15 = new BAJK15();
                        bajk15Exise = false;
                    }
                    bajk15.KEY1501 = bajk08.KEY0801;
                    if (this.CHARGE_TYPE_DICT != null && !string.IsNullOrEmpty(inpVisit.CHARGE_TYPE))
                    {
                        var result = this.CHARGE_TYPE_DICT.Where(m => m.CODE_NAME == inpVisit.CHARGE_TYPE).FirstOrDefault();
                        if (result != null && !string.IsNullOrEmpty(result.DM))
                        {
                            //bajk15.COL1501 费用类别
                            bajk15.COL1501 = decimal.Parse(result.DM);
                        }

                    }
                    if (this.MR_FEE_CLASS_DICT != null)
                    {
                        var result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "西药费").FirstOrDefault();
                        if (result != null)
                        {
                            //西药费
                            bajk15.COL1503 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "中成药费").FirstOrDefault();
                        if (result != null)
                        {
                            //中药费
                            bajk15.COL1504 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "草药费").FirstOrDefault();
                        if (result != null)
                        {
                            //草药费
                            bajk15.COL1505 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "血费").FirstOrDefault();
                        if (result != null)
                        {
                            //输血费
                            bajk15.COL1508 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "手术费").FirstOrDefault();
                        if (result != null)
                        {
                            //手术费
                            bajk15.COL1510 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "麻醉费").FirstOrDefault();
                        if (result != null)
                        {
                            //麻醉费
                            bajk15.COL1514 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }

                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "护理费").FirstOrDefault();
                        if (result != null)
                        {
                            //护理费
                            bajk15.COL1517 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "其他费用").FirstOrDefault();
                        if (result != null)
                        {
                            //其他费用
                            bajk15.COL1518 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }

                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "一般医疗服务费").FirstOrDefault();
                        if (result != null)
                        {
                            //一般医疗服务费
                            bajk15.COL1521 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "一般治疗操作费").FirstOrDefault();
                        if (result != null)
                        {
                            //一般治疗操作费
                            bajk15.COL1522 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        //bajk15.COL1523 综合其他费用未获取
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "病理诊断费").FirstOrDefault();
                        if (result != null)
                        {
                            //病理诊断费
                            bajk15.COL1524 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "实验室诊断费").FirstOrDefault();
                        if (result != null)
                        {
                            //实验室诊断费
                            bajk15.COL1525 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "影像学诊断费").FirstOrDefault();
                        if (result != null)
                        {
                            //影像学诊断费
                            bajk15.COL1526 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "临床诊断项目费").FirstOrDefault();
                        if (result != null)
                        {
                            //临床诊断项目费
                            bajk15.COL1527 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "非手术治疗项目费").FirstOrDefault();
                        if (result != null)
                        {
                            //非手术治疗项目费
                            bajk15.COL1528 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "手术治疗费").FirstOrDefault();
                        if (result != null)
                        {
                            //手术治疗费
                            bajk15.COL1529 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "康复费").FirstOrDefault();
                        if (result != null)
                        {
                            //康复费
                            bajk15.COL1530 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "中医治疗").FirstOrDefault();
                        if (result != null)
                        {
                            //中医治疗费
                            bajk15.COL1531 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "白蛋白类制品费").FirstOrDefault();
                        if (result != null)
                        {
                            //白蛋白类制品费
                            bajk15.COL1532 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "球蛋白类制品费").FirstOrDefault();
                        if (result != null)
                        {
                            //球蛋白类制品费
                            bajk15.COL1533 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "凝血因子类制品费").FirstOrDefault();
                        if (result != null)
                        {
                            //凝血因子类制品费
                            bajk15.COL1534 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "细胞因子类制品费").FirstOrDefault();
                        if (result != null)
                        {
                            //细胞因子类制品费
                            bajk15.COL1535 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "检查用一次性医用材料费").FirstOrDefault();
                        if (result != null)
                        {
                            //检查用一次性医用材料费
                            bajk15.COL1536 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "治疗用一次性医用材料费").FirstOrDefault();
                        if (result != null)
                        {
                            //治疗用一次性医用材料费
                            bajk15.COL1537 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                        result = this.MR_FEE_CLASS_DICT.Where(m => m.CODE_NAME == "手术用一次性医用材料费").FirstOrDefault();
                        if (result != null)
                        {
                            //手术用一次性医用材料费
                            bajk15.COL1538 = lstInpBillDetail.Where(m => m.CLASS_ON_MR == result.CODE_ID).Sum(m => m.COSTS);
                        }
                    }
                    if (!bajk15Exise)
                    {
                        shRet = BAJK15Access.Instance.Insert(bajk15);
                    }
                    else
                    {
                        shRet = BAJK15Access.Instance.Update(bajk15);
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("RecUploadSercvice.Upload", new string[] { "szPatientID", "szVisitID" }, new object[] { szPatientID, szVisitID }, "病案上传出错", ex);
                return false;
            }
            return true;
        }

    }
}
