using EMRDBLib;
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heren.MedQC.Core
{
    public class SystemContext
    {
        private static SystemContext m_instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static SystemContext Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new SystemContext();
                return m_instance;
            }
        }
        public bool GetSystemContext(string name, ref object value)
        {
            #region"系统上下文数据"
            if (name == "医院名称")
            {
                if (SystemParam.Instance.LocalConfigOption == null)
                    return false;
                value = SystemParam.Instance.LocalConfigOption.HOSPITAL_NAME;
                return true;
            }
            if (name == "用户ID号" || name == "用户编号")
            {
                if (SystemParam.Instance.UserInfo == null)
                    return false;
                value = SystemParam.Instance.UserInfo.USER_ID;
                return true;
            }
            if (name == "用户姓名")
            {
                if (SystemParam.Instance.UserInfo == null)
                    return false;
                value = SystemParam.Instance.UserInfo.USER_NAME;
                return true;
            }
            if (name == "用户密码")
            {
                if (SystemParam.Instance.UserInfo == null)
                    return false;
                value = SystemParam.Instance.UserInfo.Password;
                return true;
            }
            if (name == "用户科室代码")
            {
                if (SystemParam.Instance.UserInfo == null)
                    return false;
                value = SystemParam.Instance.UserInfo.DEPT_CODE;
                return true;
            }
            if (name == "用户科室名称")
            {
                if (SystemParam.Instance.UserInfo == null)
                    return false;
                value = SystemParam.Instance.UserInfo.DEPT_NAME;
                return true;
            }
            if (name == "病人ID号" || name == "病人编号" || name == "患者ID" || name == "患者ID号")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                return true;
            }
            if (name == "病人姓名")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_NAME;
                return true;
            }
            if (name == "病人性别")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_SEX;
                return true;
            }
            if (name == "病人生日")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.BIRTH_TIME;
                return true;
            }
            if (name == "病人年龄")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = GlobalMethods.SysTime.GetAgeText(
                    SystemParam.Instance.PatVisitInfo.BIRTH_TIME,
                    SystemParam.Instance.PatVisitInfo.VISIT_TIME);
                return true;
            }
            //if (name == "病人民族")
            //{
            //    if (SystemParam.Instance.PatVisitInfo == null)
            //        return false;
            //    value = SystemParam.Instance.PatVisitInfo.Nation;
            //    return true;
            //}
            if (name == "病人病情")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.PATIENT_CONDITION;
                return true;
            }
            if (name == "护理等级")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.NURSING_CLASS;
                return true;
            }
            if (name == "入院次" || name == "就诊号")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_ID;
                return true;
            }
            if (name == "入院时间")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_TIME;
                return true;
            }
            if (name == "就诊科室代码")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.DEPT_CODE;
                return true;
            }
            if (name == "就诊科室名称")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.DEPT_NAME;
                return true;
            }
            if (name == "就诊病区名称")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.WardName;
                return true;
            }
            if (name == "就诊类型")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.VISIT_TYPE;
                return true;
            }
            if (name == "床号")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                if (string.IsNullOrEmpty(SystemParam.Instance.PatVisitInfo.BED_CODE))
                {
                    //出院患者从转科记录中查询床号
                    string szPatientID =SystemParam.Instance.PatVisitInfo.PATIENT_ID;
                    string szVisitNO = SystemParam.Instance.PatVisitInfo.VISIT_NO;
                    List<Transfer> lstTransfer = null;
                    TransferAccess.Instance.GetList(szPatientID, szVisitNO, ref lstTransfer);
                    if (lstTransfer == null||lstTransfer.Count<=0)
                        return false;
                    value = lstTransfer.LastOrDefault().BED_LABEL;
                    return true;
                }
                value = SystemParam.Instance.PatVisitInfo.BED_CODE;

                return true;
            }
            if (name == "住院号")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.INP_NO;
                return true;
            }
            if (name == "诊断")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.DIAGNOSIS;
                return true;
            }
            if (name == "过敏药物")
            {
                if (SystemParam.Instance.PatVisitInfo == null)
                    return false;
                value = SystemParam.Instance.PatVisitInfo.ALLERGY_DRUGS;
                return true;
            }
            if (name == "当前时间")
            {
                value =SysTimeHelper.Instance.Now;
                return true;
            }
            return false;
            #endregion
        }

    }
}
