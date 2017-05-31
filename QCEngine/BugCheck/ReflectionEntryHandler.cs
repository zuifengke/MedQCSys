// ***********************************************************
// 病历文档系统文档质控引擎,映射类型的原子规则(Entry)处理器
// Creator:YangMingkun  Date:2009-8-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Reflection;
using Heren.Common.Libraries;
using EMRDBLib;

namespace MedDocSys.QCEngine.BugCheck
{
    internal class ReflectionEntryHandler : BugCheckEntryHandlerBase
    {
        public ReflectionEntryHandler(BugCheckEngine clsQCEngine)
            : base(clsQCEngine)
        {
        }

        public override void AddEntry(BugCheckEntry entryInfo)
        {
            base.AddEntry(entryInfo);
        }

        public override void ComputeEntryOccurCount()
        {
            base.ComputeEntryOccurCount();
            if (this.EntryTable == null)
                return;

            foreach (object obj in this.EntryTable.Values)
            {
                BugCheckEntry qcEntry = obj as BugCheckEntry;
                if (qcEntry == null)
                    return;
                qcEntry.OccurCount = 0;

                bool bResult = false;
                if (qcEntry.ValueType == SystemData.QCRule.ENTRY_VALUE_TYPE_INT)
                {
                    bResult = this.CompareIntEntry(qcEntry);
                }
                else if (qcEntry.ValueType == SystemData.QCRule.ENTRY_VALUE_TYPE_BOOL)
                {
                    bResult = this.CompareBoolEntry(qcEntry);
                }
                else if (qcEntry.ValueType == SystemData.QCRule.ENTRY_VALUE_TYPE_DATE)
                {
                    bResult = this.CompareDatetimeEntry(qcEntry);
                }
                else if (qcEntry.ValueType == SystemData.QCRule.ENTRY_VALUE_TYPE_TEXT)
                {
                    bResult = this.CompareStringEntry(qcEntry);
                }
                if (bResult)
                {
                    qcEntry.OccurCount++;
                }
            }
        }

        private bool CompareIntEntry(BugCheckEntry qcEntry)
        {
            int nNormalValue = 0;
            if (!int.TryParse(qcEntry.EntryValue, out nNormalValue))
                return false;

            int nRealValue = 0;
            if (!this.GetPropertyValue(qcEntry, ref nRealValue))
                return false;

            if (qcEntry.Operator == SystemData.Operator.EQUAL)
            {
                return (nRealValue == nNormalValue);
            }
            else if (qcEntry.Operator == SystemData.Operator.MORE)
            {
                return (nRealValue > nNormalValue);
            }
            else if (qcEntry.Operator == SystemData.Operator.LESS)
            {
                return (nRealValue < nNormalValue);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOLESS)
            {
                return (nRealValue >= nNormalValue);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOMORE)
            {
                return (nRealValue <= nNormalValue);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOEQUAL)
            {
                return (nRealValue != nNormalValue);
            }
            return false;
        }

        private bool CompareBoolEntry(BugCheckEntry qcEntry)
        {
            bool bNormalValue = false;
            if (!bool.TryParse(qcEntry.EntryValue, out bNormalValue))
                return false;

            bool bRealValue = false;
            if (!this.GetPropertyValue(qcEntry, ref bRealValue))
                return false;

            if (qcEntry.Operator == SystemData.Operator.EQUAL)
            {
                return (bRealValue == bNormalValue);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOEQUAL)
            {
                return (bRealValue != bNormalValue);
            }
            return false;
        }

        private bool CompareDatetimeEntry(BugCheckEntry qcEntry)
        {
            DateTime dtNormalValue = DateTime.Now;
            if (!DateTime.TryParse(qcEntry.EntryValue, out dtNormalValue))
                return false;

            DateTime dtRealValue = DateTime.Now;
            if (!this.GetPropertyValue(qcEntry, ref dtRealValue))
                return false;

            if (qcEntry.Operator == SystemData.Operator.EQUAL)
            {
                return (DateTime.Compare(dtRealValue, dtNormalValue) == 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.MORE)
            {
                return (DateTime.Compare(dtRealValue, dtNormalValue) > 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.LESS)
            {
                return (DateTime.Compare(dtRealValue, dtNormalValue) < 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOLESS)
            {
                return (DateTime.Compare(dtRealValue, dtNormalValue) >= 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOMORE)
            {
                return (DateTime.Compare(dtRealValue, dtNormalValue) <= 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOEQUAL)
            {
                return (DateTime.Compare(dtRealValue, dtNormalValue) != 0);
            }
            return false;
        }

        private bool CompareStringEntry(BugCheckEntry qcEntry)
        {
            string szNormalValue = qcEntry.EntryValue;
            if (GlobalMethods.Misc.IsEmptyString(szNormalValue))
                return false;

            string szRealValue = string.Empty;
            if (!this.GetPropertyValue(qcEntry, ref szRealValue))
                return false;

            if (qcEntry.Operator == SystemData.Operator.EQUAL)
            {
                return (string.Compare(szRealValue, szNormalValue) == 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.MORE)
            {
                return (string.Compare(szRealValue, szNormalValue) > 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.LESS)
            {
                return (string.Compare(szRealValue, szNormalValue) < 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOLESS)
            {
                return (string.Compare(szRealValue, szNormalValue) >= 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOMORE)
            {
                return (string.Compare(szRealValue, szNormalValue) <= 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOEQUAL)
            {
                return (string.Compare(szRealValue, szNormalValue) != 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.CONTAINS)
            {
                return (szRealValue.IndexOf(szNormalValue) >= 0);
            }
            else if (qcEntry.Operator == SystemData.Operator.NOCONTAINS)
            {
                return (szRealValue.IndexOf(szNormalValue) < 0);
            }
            return false;
        }

        private bool GetPropertyValue(BugCheckEntry qcEntry, ref string value)
        {
            object obj = null;
            if (!this.GetPropertyValue(qcEntry, ref obj) || obj == null)
                return false;
            value = obj.ToString();
            return true;
        }

        private bool GetPropertyValue(BugCheckEntry qcEntry, ref int value)
        {
            object obj = null;
            if (!this.GetPropertyValue(qcEntry, ref obj) || obj == null)
                return false;
            return int.TryParse(obj.ToString(), out value);
        }

        private bool GetPropertyValue(BugCheckEntry qcEntry, ref bool value)
        {
            object obj = null;
            if (!this.GetPropertyValue(qcEntry, ref obj) || obj == null)
                return false;
            return bool.TryParse(obj.ToString(), out value);
        }

        private bool GetPropertyValue(BugCheckEntry qcEntry, ref DateTime value)
        {
            object obj = null;
            if (!this.GetPropertyValue(qcEntry, ref obj) || obj == null)
                return false;
            return DateTime.TryParse(obj.ToString(), out value);
        }

        private bool GetPropertyValue(BugCheckEntry qcEntry, ref object value)
        {
            if (qcEntry == null || GlobalMethods.Misc.IsEmptyString(qcEntry.EntryName))
                return false;
            string[] arrEntryName = qcEntry.EntryName.Split('.');
            if (arrEntryName == null)
                return false;
            object desObject = this.QCEngine;
            for (int index = 0; index < arrEntryName.Length; index++)
            {
                string szPropertyName = arrEntryName[index];
                if (desObject == null || GlobalMethods.Misc.IsEmptyString(szPropertyName))
                    continue;
                PropertyInfo propertyInfo = this.GetPropertyInfo(desObject.GetType(), szPropertyName);
                if (propertyInfo == null)
                    continue;
                desObject = this.GetPropertyValue(desObject, propertyInfo);
            }
            value = desObject;
            return true;
        }

        /// <summary>
        /// 从指定类型中获取指定名称的属性信息
        /// </summary>
        /// <param name="type">指定类型</param>
        /// <param name="szPropertyName">指定的属性名称</param>
        /// <returns>PropertyInfo</returns>
        private PropertyInfo GetPropertyInfo(Type type, string szPropertyName)
        {
            if (type == null || GlobalMethods.Misc.IsEmptyString(szPropertyName))
                return null;
            try
            {
                return type.GetProperty(szPropertyName);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ReflectionEntryHandler.GetPropertyInfo", ex);
                return null;
            }
        }

        /// <summary>
        /// 从指定的对象实例中获取指定的属性的值
        /// </summary>
        /// <param name="obj">指定的对象实例</param>
        /// <param name="propertyInfo">指定的属性</param>
        /// <returns>object</returns>
        private object GetPropertyValue(object obj, PropertyInfo propertyInfo)
        {
            if (obj == null || propertyInfo == null)
                return null;
            try
            {
                return propertyInfo.GetValue(obj, null);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("ReflectionEntryHandler.GetPropertyValue", ex);
                return null;
            }
        }
    }
}
