/********************************************************
 * @FileName   : AutoCalcHandler.cs
 * @Description: 
 * @Author     : 杨明坤(YangMingkun)
 * @Date       : 2015-12-29 12:57:12
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
********************************************************/
using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using Heren.Common.Libraries;
using Heren.MedQC.ScriptEngine.Script;
using Heren.MedQC.Core;
using EMRDBLib;
using EMRDBLib.DbAccess;

namespace Heren.MedQC.ScriptEngine
{
    public class AutoCalcHandler
    {
        private GetElementValueCallback m_getElementValueCallback = null;
        private SetElementValueCallback m_setElementValueCallback = null;
        private ShowElementTipCallback m_showElementTipCallback = null;
        private HideElementTipCallback m_hideElementTipCallback = null;
        private ExecuteQueryCallback m_executeQueryCallback = null;
        private ExecuteUpdateCallback m_executeUpdateCallback = null;
        private GetSystemContextCallback m_getSystemContextCallback = null;

        private static AutoCalcHandler m_Instance = null;
        public static AutoCalcHandler Instance {
            get {
                if (m_Instance == null)
                    m_Instance = new AutoCalcHandler();
                return m_Instance;
            }
        }
        public void Start()
        {
            this.m_getElementValueCallback = new GetElementValueCallback(this.GetElementValue);
            this.m_setElementValueCallback = new SetElementValueCallback(this.SetElementValue);
            this.m_showElementTipCallback = new ShowElementTipCallback(this.ShowElementTip);
            this.m_hideElementTipCallback = new HideElementTipCallback(this.HideElementTip);
            this.m_executeQueryCallback = new ExecuteQueryCallback(this.ExecuteQuery);
            this.m_executeUpdateCallback = new ExecuteUpdateCallback(this.ExecuteUpdate);
            this.m_getSystemContextCallback = new GetSystemContextCallback(this.GetSystemContext);
        }

        #region"元素计算脚本引擎回调"
        private bool GetElementValue(string elementName, out string elementValue)
        {
            elementValue = null;

            //if (activeDocument == null || activeDocument.IsDisposed)
            //    return false;
            //if (activeDocument.DocumentEditor == null || activeDocument.DocumentEditor.IsDisposed)
            //    return false;

            //elementValue = this.m_activeDocumentForm.DocumentEditor.GetElementText(elementName);
            //return elementValue != null;
            return true;
        }

        private bool SetElementValue(string szElementName, string szElementValue)
        {
            //if (this.m_medDocCtrl == null)
            //    return false;
            //ClinicalDocumentForm activeDocument = this.m_medDocCtrl.ActiveDocument;
            //if (activeDocument == null || activeDocument.IsDisposed)
            //    return false;
            //if (activeDocument.DocumentEditor == null || activeDocument.DocumentEditor.IsDisposed)
            //    return false;
            //string nameAndValue = string.Format("{0}={1}|", szElementName, szElementValue);
            //return activeDocument.DocumentEditor.SetElementText(nameAndValue, false);
            return true;
        }

        private bool ShowElementTip(string szTitle, string szTipText)
        {
            //ClinicalDocumentForm activeDocument = this.m_medDocCtrl.ActiveDocument;
            //if (activeDocument == null || activeDocument.IsDisposed)
            //    return false;
            //if (activeDocument.DocumentEditor == null || activeDocument.DocumentEditor.IsDisposed)
            //    return false;
            //activeDocument.DocumentEditor.ShowToolTip(szTitle, szTipText, 3000);
            return true;
        }

        private bool HideElementTip()
        {
            //ClinicalDocumentForm activeDocument = this.m_medDocCtrl.ActiveDocument;
            //if (activeDocument == null || activeDocument.IsDisposed)
            //    return false;
            //if (activeDocument.DocumentEditor == null || activeDocument.DocumentEditor.IsDisposed)
            //    return false;
            //activeDocument.DocumentEditor.HideToolTip();
            return true;
        }

        /// <summary>
        /// 执行一个SQL查询
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>是否查询成功</returns>
        private bool ExecuteQuery(string sql, out DataSet data)
        {
            short result = CommonAccess.Instance.ExecuteQuery(sql, out data);
            LogManager.Instance.WriteLog(sql);
            return result == SystemData.ReturnValue.OK;
        }

        /// <summary>
        /// 执行指定的一系列的SQL更新
        /// </summary>
        /// <param name="isProc">传入的SQL是否是存储过程</param>
        /// <param name="sqlArray">SQL语句数组</param>
        /// <returns>是否更新成功</returns>
        private bool ExecuteUpdate(bool isProc, params string[] sqlArray)
        {
            short result = CommonAccess.Instance.ExecuteUpdate(isProc, sqlArray);
            return result == SystemData.ReturnValue.OK;
        }
        public PatVisitInfo PatVisitInfo { get; set; }
        public QcCheckPoint QcCheckPoint { get; set; }
        public QcCheckResult QcCheckResult { get; set; }
        private bool GetSystemContext(string name, out object value)
        {
            value = null;
            if (name == "当前患者")
            {
                value = this.PatVisitInfo;
            }
            if (name == "质控结果")
            {
                value = this.QcCheckResult;
            }
            if (name == "质控规则")
            {
                value = this.QcCheckPoint;
            }
            //if (name == "用户ID号")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.UserInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.UserInfo.ID;
            //}
            //else if (name == "用户姓名")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.VisitInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.UserInfo.Name;
            //}
            //else if (name == "用户科室代码")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.VisitInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.UserInfo.DeptCode;
            //}
            //else if (name == "用户科室名称")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.VisitInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.UserInfo.DeptName;
            //}
            //else if (name == "病人ID号")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.PatientInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.PatientInfo.ID;
            //}
            //else if (name == "病人姓名")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.PatientInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.PatientInfo.Name;
            //}
            //else if (name == "病人性别")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.PatientInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.PatientInfo.Gender;
            //}
            //else if (name == "病人生日")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.PatientInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.PatientInfo.BirthTime;
            //}
            //else if (name == "入院次")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.VisitInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.VisitInfo.ID;
            //}
            //else if (name == "入院时间")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.VisitInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.VisitInfo.Time;
            //}
            //else if (name == "就诊科室代码")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.VisitInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.VisitInfo.DeptCode;
            //}
            //else if (name == "就诊科室名称")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.VisitInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.VisitInfo.DeptName;
            //}
            //else if (name == "就诊类型")
            //{
            //    if (this.m_activeDocumentForm.MedDocCtrl.VisitInfo == null)
            //        return false;
            //    value = this.m_activeDocumentForm.MedDocCtrl.VisitInfo.Type.ToString();
            //}
            return true;
        }
        #endregion

        /// <summary>
        /// 获取传入的Hash表里的元素别名列表分别对应的元素信息,并对其赋值
        /// </summary>
        /// <param name="htElements">元素别名列表HashTable</param>
        /// <returns>true-获取成功;false-获取失败</returns>
        private bool GetRelatedElementsValue(ref Hashtable htElements)
        {
            if (htElements == null || htElements.Count <= 0)
                return false;
           

            //StructElement element = this.m_activeDocumentForm.DocumentEditor.GetCurrentElement();
            //if (element == null)
            //    return false;

            //string szElementValue = this.m_activeDocumentForm.DocumentEditor.GetElementText();
            //if (string.IsNullOrEmpty(szElementValue))
            //    return false;

            //if (!htElements.Contains(element.ElementName))
            //    return false;
            //htElements[element.ElementName] = szElementValue;

            ////循环从病历中将哈希表中存放的每一个别名对应的元素信息获取出来
            //string[] arrKeys = new string[htElements.Count];
            //try
            //{
            //    htElements.Keys.CopyTo(arrKeys, 0);
            //}
            //catch (Exception ex)
            //{
            //    LogManager.Instance.WriteLog("CalcHelper.GetRelatedElementsValue", ex);
            //    return false;
            //}
            //for (int index = 0; index < arrKeys.Length; index++)
            //{
            //    string szElementName = arrKeys[index];
            //    if (string.IsNullOrEmpty(szElementName))
            //        continue;
            //    if (htElements[szElementName] != null)
            //        continue;

            //    string value = this.m_activeDocumentForm.DocumentEditor.GetElementText(szElementName);
            //    htElements[szElementName] = value;
            //}
            return true;
        }

        /// <summary>
        /// 当用户修改文档内的记录时间时,自动更新文档信息中的记录时间属性
        /// </summary>
        /// <param name="szElementName">当前被修改的元素名称</param>
        private void HandleRecordTimeElement(string szElementName)
        {
            //if (this.m_activeDocumentForm == null || this.m_activeDocumentForm.IsDisposed)
            //    return;
            //if (this.m_activeDocumentForm.Document == null || szElementName == null)
            //    return;

            //string szElementValue = this.m_activeDocumentForm.DocumentEditor.GetElementText();
            //if (string.IsNullOrEmpty(szElementValue))
            //    return;

            //szElementValue = GlobalMethods.Convert.SBCToDBC(szElementValue, null).Replace("，", " ");
            //DateTime dtRecordTime = DateTime.Now;
            //if (GlobalMethods.Convert.StringToDate(szElementValue, ref dtRecordTime))
            //{
            //    ClinicalDocument document = this.m_activeDocumentForm.Document;
            //    if (this.m_activeDocumentForm.Document.Combined)
            //        document = this.m_activeDocumentForm.GetCurrentChildDocument();
            //    if (document != null)
            //        document.ModifyRecordTime(dtRecordTime);
            //}
        }

        /// <summary>
        /// 当用户修改文档内的主诉时,自动检查主诉内容的字符数目
        /// </summary>
        /// <param name="szElementName">当前被修改的元素名称</param>
        private void HandlePatientDescElement(string szElementName)
        {
            //this.HideElementTip();
            //if (this.m_activeDocumentForm == null || this.m_activeDocumentForm.IsDisposed)
            //    return;
            //if (this.m_activeDocumentForm.Document == null || szElementName == null)
            //    return;

            //string szElementValue = this.m_activeDocumentForm.DocumentEditor.GetElementText();
            //if (string.IsNullOrEmpty(szElementValue))
            //    return;
            //szElementValue = szElementValue.Trim();
            //if (szElementValue.Length > 20)
            //{
            //    string text = "您输入的主诉内容已经超过20个字符,建议您精炼一些!";
            //    this.m_activeDocumentForm.DocumentEditor.ShowToolTip("违反医疗常规的输入", text, 3000);
            //}
        }

        /// <summary>
        /// 根据文档中的身高和体重结构化元素值自动计算BMI值
        /// </summary>
        /// <param name="szElementName">当前被修改的元素名称</param>
        private void HandleBodyElement(string szElementName)
        {
            //if (this.m_activeDocumentForm == null || this.m_activeDocumentForm.IsDisposed)
            //    return;
            //if (GlobalMethods.Misc.IsEmptyString(szElementName))
            //    return;

            //Hashtable htElements = new Hashtable();
            //htElements.Add(SystemConsts.ElementName.BODY_HEIGHT, null);
            //htElements.Add(SystemConsts.ElementName.BODY_WEIGHT, null);
            //if (!this.GetRelatedElementsValue(ref htElements))
            //    return;

            //string szElementValue = htElements[SystemConsts.ElementName.BODY_HEIGHT] as string;
            //if (GlobalMethods.Misc.IsEmptyString(szElementValue))
            //    return;

            //double dBodyHeight = 0;
            //if (!double.TryParse(szElementValue.Trim(), out dBodyHeight))
            //    return;
            //if (dBodyHeight >= 3) //如果不小于3,则认为单位是cm,需要转换为m
            //    dBodyHeight = dBodyHeight / 100;
            //if (dBodyHeight <= 0)
            //    return;

            //szElementValue = htElements[SystemConsts.ElementName.BODY_WEIGHT] as string;
            //if (GlobalMethods.Misc.IsEmptyString(szElementValue))
            //    return;

            //double dBodyWeight = 0;
            //if (!double.TryParse(szElementValue.Trim(), out dBodyWeight))
            //    return;

            //double dBmiValue = dBodyWeight / (dBodyHeight * dBodyHeight);
            //dBmiValue = Math.Round(dBmiValue, 2, MidpointRounding.ToEven);

            //double dAreaValue = 0.0061 * dBodyHeight * 100 + 0.0128 * dBodyWeight - 0.1529;
            //dAreaValue = Math.Round(dAreaValue, 2, MidpointRounding.ToEven);

            //string nameValueExpression = string.Format("{0}={1}|{2}={3}"
            //    , SystemConsts.ElementName.BODY_BMI, dBmiValue
            //    , SystemConsts.ElementName.BODY_AREA, dAreaValue);
            //this.m_activeDocumentForm.DocumentEditor.SetElementText(nameValueExpression, false);
        }

        /// <summary>
        /// 根据文档中的入院和出院时间结构化元素值自动计算在院天数
        /// </summary>
        /// <param name="szElementName">当前被修改的元素名称</param>
        private void HandleInpDaysElement(string szElementName)
        {
            //if (this.m_activeDocumentForm == null || this.m_activeDocumentForm.IsDisposed)
            //    return;
            //if (GlobalMethods.Misc.IsEmptyString(szElementName))
            //    return;

            //Hashtable htElements = new Hashtable();
            //htElements.Add(SystemConsts.ElementName.ADMISSION_DATE, null);
            //htElements.Add(SystemConsts.ElementName.ADMISSION_TIME, null);
            //htElements.Add(SystemConsts.ElementName.DISCHARGE_DATE, null);
            //htElements.Add(SystemConsts.ElementName.DISCHARGE_TIME, null);
            //if (!this.GetRelatedElementsValue(ref htElements))
            //    return;

            //string szElementValue = htElements[SystemConsts.ElementName.ADMISSION_DATE] as string;
            //if (szElementValue == null)
            //    szElementValue = htElements[SystemConsts.ElementName.ADMISSION_TIME] as string;

            //if (GlobalMethods.Misc.IsEmptyString(szElementValue))
            //    return;

            //DateTime dtAdmissionDate = DateTime.Now;
            //if (!GlobalMethods.Convert.StringToDate(szElementValue, ref dtAdmissionDate))
            //    return;

            //szElementValue = htElements[SystemConsts.ElementName.DISCHARGE_DATE] as string;
            //if (szElementValue == null)
            //    szElementValue = htElements[SystemConsts.ElementName.DISCHARGE_TIME] as string;

            //if (GlobalMethods.Misc.IsEmptyString(szElementValue))
            //    return;

            //DateTime dtDischargeDate = DateTime.Now;
            //if (!GlobalMethods.Convert.StringToDate(szElementValue, ref dtDischargeDate))
            //    return;

            //long lInpDays = GlobalMethods.SysTime.GetInpDays(dtAdmissionDate, dtDischargeDate);
            //string nameValueExpression = string.Format("{0}={1}|{2}={3}"
            //    , SystemConsts.ElementName.IN_HOSPITAL_DAYS1, lInpDays
            //    , SystemConsts.ElementName.IN_HOSPITAL_DAYS2, lInpDays);
            //this.m_activeDocumentForm.DocumentEditor.SetElementText(nameValueExpression, false);
        }
        public bool CalcularTest(IElementCalculator instance,PatVisitInfo patVisitInfo,QcCheckPoint qcCheckPoint,QcCheckResult checkResult)
        {
            if (instance == null)
                return false;
            if (instance.GetElementValueCallback == null)
                instance.GetElementValueCallback = this.m_getElementValueCallback;
            if (instance.SetElementValueCallback == null)
                instance.SetElementValueCallback = this.m_setElementValueCallback;
            if (instance.ShowElementTipCallback == null)
                instance.ShowElementTipCallback = this.m_showElementTipCallback;
            if (instance.HideElementTipCallback == null)
                instance.HideElementTipCallback = this.m_hideElementTipCallback;
            if (instance.ExecuteQueryCallback == null)
                instance.ExecuteQueryCallback = this.m_executeQueryCallback;
            if (instance.ExecuteUpdateCallback == null)
                instance.ExecuteUpdateCallback = this.m_executeUpdateCallback;
            if (instance.GetSystemContextCallback == null)
                instance.GetSystemContextCallback = this.m_getSystemContextCallback;
            try
            {
                instance.Calculate(patVisitInfo, qcCheckPoint,checkResult);
                //if (!instance.Calculate(szElementName))
                //    return false;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("Heren.MedDoc.AutoCalc.AutoCalcHandler.ExecuteElementCalculator", ex);
                return false;
            }
            return true;
        }
        /// <summary>
        /// 执行指定病历类型的元素自动计算脚本DLL
        /// </summary>
        /// <param name="szExecuteTime">执行时机</param>
        /// <param name="szDocTypeID">病历类型ID</param>
        /// <param name="szElementName">元素别名</param>
        /// <returns>SystemData.ReturnValue</returns>
        public bool ExecuteElementCalculator(string szScriptID,PatVisitInfo patVisitInfo,QcCheckPoint checkPoint, QcCheckResult qcCheckResult)
        {
            List<IElementCalculator> calculatorInstances = null;
            short result = ScriptCache.Instance.GetScriptInstances(szScriptID, ref calculatorInstances);
            if (result != SystemData.ReturnValue.OK)
                return true;
            if (calculatorInstances == null)
                return true;
            for (int index = 0; index < calculatorInstances.Count; index++)
            {
                IElementCalculator instance = calculatorInstances[index];
                if (instance == null)
                    continue;
                if (instance.GetElementValueCallback == null)
                    instance.GetElementValueCallback = this.m_getElementValueCallback;
                if (instance.SetElementValueCallback == null)
                    instance.SetElementValueCallback = this.m_setElementValueCallback;
                if (instance.ShowElementTipCallback == null)
                    instance.ShowElementTipCallback = this.m_showElementTipCallback;
                if (instance.HideElementTipCallback == null)
                    instance.HideElementTipCallback = this.m_hideElementTipCallback;
                if (instance.ExecuteQueryCallback == null)
                    instance.ExecuteQueryCallback = this.m_executeQueryCallback;
                if (instance.ExecuteUpdateCallback == null)
                    instance.ExecuteUpdateCallback = this.m_executeUpdateCallback;
                if (instance.GetSystemContextCallback == null)
                    instance.GetSystemContextCallback = this.m_getSystemContextCallback;
                try
                {
                    instance.Calculate(patVisitInfo,checkPoint, qcCheckResult);
                    //if (!instance.Calculate(szElementName))
                    //    return false;
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteLog("Heren.MedDoc.AutoCalc.AutoCalcHandler.ExecuteElementCalculator", ex);
                    return false;
                }
            }
            return true;
        }
    }
}
