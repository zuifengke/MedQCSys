// ***********************************************************
// 病历文档系统病历时效控制时效事件管理类
// Creator:Tangcheng  Date:2011-12-21
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Heren.Common.Libraries;
using EMRDBLib.Entity;
using EMRDBLib;
using EMRDBLib.DbAccess;

namespace MedDocSys.QCEngine.TimeCheck
{
    public class TimeEventHandler : IDisposable
    {
        private static TimeEventHandler m_instance = null;
        /// <summary>
        /// 获取时效事件处理器实例
        /// </summary>
        public static TimeEventHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new TimeEventHandler();
                return m_instance;
            }
        }

        private TimeCheckQuery m_timeCheckQuery = null;
        /// <summary>
        /// 获取或设置事件查询信息
        /// </summary>
        public TimeCheckQuery TimeCheckQuery
        {
            get { return this.m_timeCheckQuery; }
            set { this.m_timeCheckQuery = value; }
        }

        /// <summary>
        /// 缓存病历时效事件ID对应的事件信息
        /// </summary>
        private Dictionary<string, TimeQCEvent> m_dicTimeQCEvents = null;

        /// <summary>
        /// 缓存当次轮询过程中事件执行结果列表
        /// </summary>
        private Dictionary<string, List<TimeQCEventResult>> m_dicEventResults = null;

        /// <summary>
        /// 用于防止用户将依赖事件设置成死循环的事件执行堆栈
        /// </summary>
        private Stack<string> m_stkEventStack = null;

        private TimeEventHandler()
        {
        }

        /// <summary>
        /// 释放引用的资源
        /// </summary>
        public void Dispose()
        {
            if (this.m_dicEventResults != null)
                this.m_dicEventResults.Clear();
            this.m_dicEventResults = null;
            if (this.m_dicTimeQCEvents != null)
                this.m_dicTimeQCEvents.Clear();
            this.m_dicTimeQCEvents = null;
        }

        /// <summary>
        /// 清除缓存的事件执行结果
        /// </summary>
        public void ClearEventResult()
        {
            if (this.m_dicEventResults != null)
                this.m_dicEventResults.Clear();
        }
        public void ClearTimeQCEvent()
        {
            if (this.m_dicTimeQCEvents != null)
                this.m_dicTimeQCEvents.Clear();
        }
        /// <summary>
        /// 获取指定ID号的时效质控事件信息
        /// </summary>
        /// <param name="szEventID">事件ID</param>
        /// <returns>MDSDBLib.TimeQCEvent</returns>
        public TimeQCEvent GetTimeQCEvent(string szEventID)
        {
            if (this.m_dicTimeQCEvents != null&&this.m_dicTimeQCEvents.Count>0)
            {
                if (this.m_dicTimeQCEvents.ContainsKey(szEventID))
                    return this.m_dicTimeQCEvents[szEventID];
                return null;
            }

            this.m_dicTimeQCEvents =
                new Dictionary<string, TimeQCEvent>();

            List<TimeQCEvent> lstTimeQCEvents = null;
            TimeQCEventAccess.Instance.GetTimeQCEvents(ref lstTimeQCEvents);
            if (lstTimeQCEvents == null)
                return null;
            for (int index = 0; index < lstTimeQCEvents.Count; index++)
            {
                TimeQCEvent timeQCEvent = lstTimeQCEvents[index];
                if (this.m_dicTimeQCEvents.ContainsKey(timeQCEvent.EventID))
                    continue;
                this.m_dicTimeQCEvents.Add(timeQCEvent.EventID, timeQCEvent);
            }
            if (this.m_dicTimeQCEvents.ContainsKey(szEventID))
                return this.m_dicTimeQCEvents[szEventID];
            return null;
        }

        /// <summary>
        /// 运行指定的时效事件,并返回事件中定义的SQL的执行结果
        /// </summary>
        /// <param name="szEventID">事件ID</param>
        /// <param name="lstTimeQCEventResults">事件执行结果</param>
        /// <returns>MDSDBLib.TimeQCEventResultList</returns>
        public List<TimeQCEventResult> PerformTimeEvent(string szEventID)
        {
            //准备事件重复依赖检查堆栈
            if (this.m_stkEventStack == null)
                this.m_stkEventStack = new Stack<string>();
            this.m_stkEventStack.Clear();

            List<TimeQCEventResult> lstTimeQCEventResults = null;
            lstTimeQCEventResults = this.PerformEventInternal(szEventID);
            return lstTimeQCEventResults;
        }

        /// <summary>
        /// 获取指定事件ID的事件发生时间
        /// </summary>
        /// <param name="szEventID">事件ID</param>
        /// <param name="lstTimeQCEventResults">事件执行结果</param>
        /// <returns>事件信息列表</returns>
        private List<TimeQCEventResult> PerformEventInternal(string szEventID)
        {
            if (GlobalMethods.Misc.IsEmptyString(szEventID))
                return null;

            //将当前事件入栈
            if (!this.m_stkEventStack.Contains(szEventID))
                this.m_stkEventStack.Push(szEventID);

            //当前事件已执行过
            this.m_dicEventResults =
                new Dictionary<string, List<TimeQCEventResult>>();
            if (this.m_dicEventResults.ContainsKey(szEventID))
                return this.m_dicEventResults[szEventID];

            //获取当前事件信息
            TimeQCEvent timeQCEvent = this.GetTimeQCEvent(szEventID);
            if (timeQCEvent == null)
                return null;

            //先执行当前事件的依赖事件
             List<TimeQCEventResult> lstTimeQCEventResults = null;
            if (!string.IsNullOrEmpty(timeQCEvent.DependEvent))
            {
                if (this.m_stkEventStack.Contains(timeQCEvent.DependEvent))
                {
                    string szLogText = "非法的时效事件配置,发现循环设置依赖事件!";
                    szLogText += "事件编号=" + szEventID;
                    LogManager.Instance.WriteLog(szLogText);
                    return null;
                }
                lstTimeQCEventResults = this.PerformEventInternal(timeQCEvent.DependEvent);
                if (lstTimeQCEventResults == null || lstTimeQCEventResults.Count <= 0)
                    return null;
            }
            lstTimeQCEventResults = this.ExecuteEventSQL(timeQCEvent);
            if (!this.m_dicEventResults.ContainsKey(timeQCEvent.EventID))
                this.m_dicEventResults.Add(timeQCEvent.EventID, lstTimeQCEventResults);
            return lstTimeQCEventResults;
        }

        /// <summary>
        /// 从当前系统中的用户、病人等数据对象中获取的指定属性的值
        /// </summary>
        /// <param name="szPropertyText">属性名称列表</param>
        /// <param name="objValue">返回的属性值</param>
        /// <returns>bool</returns>
        private bool GetPropertyValue(string szPropertyText, ref object objValue)
        {
            if (this.m_timeCheckQuery == null)
                return false;
            string[] arrPropertyName = szPropertyText.Split('.');
            if (arrPropertyName == null)
                return false;

            object target = this;
            PropertyInfo propertyInfo = null;
            for (int index = 0; index < arrPropertyName.Length; index++)
            {
                string szPropertyName = arrPropertyName[index];
                if (target == null || string.IsNullOrEmpty(szPropertyName))
                    continue;
                propertyInfo = this.GetPropertyInfo(target.GetType(), szPropertyName);
                if (propertyInfo != null)
                    target = this.GetPropertyValue(target, propertyInfo);
            }
            if (target != this) objValue = target;
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
                LogManager.Instance.WriteLog("TimeEventHandler.GetPropertyInfo", ex);
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
                LogManager.Instance.WriteLog("TimeEventHandler.GetPropertyValue", ex);
                return null;
            }
        }

        /// <summary>
        /// 使用args数组内的数据逐个替换szFormatText字符串中以"{}"表示的占位符
        /// </summary>
        /// <param name="szFormatText">指定的字符串</param>
        /// <param name="args">用于替换占位符的参数</param>
        /// <returns>当替换成功那么返回非null,否则出现异常则返回null</returns>
        private string FormatString(string szFormatText, params string[] args)
        {
            try
            {
                return string.Format(szFormatText, args);
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("TimeEventHandler.FormatString", ex);
                return null;
            }
        }

        /// <summary>
        /// 执行后台配置的事件SQL,获取事件发生的时间
        /// </summary>
        /// <param name="timeQCEvent">事件配置信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        private List<TimeQCEventResult> ExecuteEventSQL(TimeQCEvent timeQCEvent)
        {
            if (timeQCEvent == null)
                return null;

            string szSqlCondition = timeQCEvent.SqlCondition;
            if (szSqlCondition == null)
                szSqlCondition = string.Empty;
            else
                szSqlCondition = szSqlCondition.Trim();

            string[] arrPropertyName = szSqlCondition.Split(';');
            string[] arrPropertyData = new string[arrPropertyName.Length];
            string level = "1"; //默认是监控经治医生 1 经治医师，2 上级医生，3 主任医生
            bool bExistLevelDefinition = false;
            int i = 0;
            for (i = 0; i < arrPropertyName.Length; i++)
            {
                if (arrPropertyName[i] == "TimeCheckQuery.DoctorLevel")
                {
                    bExistLevelDefinition = true;
                    break;
                }
            }
            for (int nField = 0; nField < arrPropertyName.Length; nField++)
            {
                string szPropertyData = arrPropertyName[nField].Trim();
                if (GlobalMethods.Misc.IsEmptyString(szPropertyData))
                    continue;
                object objValue = null;
                if (this.GetPropertyValue(szPropertyData, ref objValue))
                    arrPropertyData[nField] = objValue as string;
                if (bExistLevelDefinition && nField == i)
                {
                    level = arrPropertyData[nField];
                }
            }

            //将取出的数据设置到SQL语句中
            string szQuerySQL = timeQCEvent.SqlText.Trim();
            szQuerySQL = this.FormatString(szQuerySQL, arrPropertyData);
            List<TimeQCEventResult> lstTimeQCEventResults = null;
            if (!string.IsNullOrEmpty(szQuerySQL)
                && szQuerySQL!="null")
                TimeQCEventAccess.Instance.ExecuteTimeEventSQL(szQuerySQL, ref lstTimeQCEventResults);
            if (lstTimeQCEventResults != null)
            {
                foreach (TimeQCEventResult result in lstTimeQCEventResults)
                {
                    result.DoctorLevel = level;
                }
            }
            return lstTimeQCEventResults;
        }
    }
}
