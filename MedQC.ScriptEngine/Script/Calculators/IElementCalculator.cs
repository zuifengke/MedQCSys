// ***********************************************************
// 电子病历系统关联元素自动计算脚本接口.
// Creator: YangMingkun  Date:2011-11-10
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using EMRDBLib;

namespace Heren.MedQC.ScriptEngine.Script
{
    public interface IElementCalculator : IDisposable
    {
        /// <summary>
        /// 获取或设置显示元素提示的回调委托
        /// </summary>
        ShowElementTipCallback ShowElementTipCallback { get; set; }
        /// <summary>
        /// 获取或设置隐藏元素提示的回调委托
        /// </summary>
        HideElementTipCallback HideElementTipCallback { get; set; }
        /// <summary>
        /// 获取或设置获取元素值的回调委托
        /// </summary>
        GetElementValueCallback GetElementValueCallback { get; set; }
        /// <summary>
        /// 获取或设置设置元素值的回调委托
        /// </summary>
        SetElementValueCallback SetElementValueCallback { get; set; }
        /// <summary>
        /// 获取或设置委托主线程调用的回调委托
        /// </summary>
        ThreadInvokeCallback ThreadInvokeCallback { get; set; }
        /// <summary>
        /// 获取或设置获取系统运行上下文数据的回调委托
        /// </summary>
        GetSystemContextCallback GetSystemContextCallback { get; set; }
        /// <summary>
        /// 获取或设置执行指定的SQL查询的回调委托
        /// </summary>
        ExecuteQueryCallback ExecuteQueryCallback { get; set; }
        /// <summary>
        /// 获取或设置指定指定的SQL更新的回调委托
        /// </summary>
        ExecuteUpdateCallback ExecuteUpdateCallback { get; set; }
        /// <summary>
        /// 获取或设置自定义事件的回调委托
        /// </summary>
        CustomEventCallback CustomEventCallback { get; set; }
        /// <summary>
        /// 获取或设置定位到指定元素位置的回调委托
        /// </summary>
        LocateToElementCallback LocateToElementCallback { get; set; }
        /// <summary>
        /// 提供给子类重写的运算方法
        /// </summary>
        /// <param name="szElementName">元素名称</param>
        void Calculate(object patVisitInfo, object checkPoint, object checkresult);
        /// <summary>
        /// 提供给子类重写的运算方法
        /// </summary>
        /// <param name="param">参数名称</param>
        /// <param name="data">参数数据</param>
        bool Calculate(string param, object data);
        /// <summary>
        /// 提供给子类重写的运算方法
        /// </summary>
        /// <param name="param">参数名称</param>
        /// <param name="data">参数数据</param>
        bool Calculate(string param);

    }

    /// <summary>
    /// 隐藏当前元素提示的回调委托
    /// </summary>
    /// <returns>执行结果</returns>
    public delegate bool HideElementTipCallback();
    /// <summary>
    /// 显示当前元素提示的回调委托
    /// </summary>
    /// <param name="szTitle">提示标题</param>
    /// <param name="szTipText">提示文本</param>
    /// <returns>执行结果</returns>
    public delegate bool ShowElementTipCallback(string szTitle, string szTipText);
    /// <summary>
    /// 获取指定元素的值的回调委托
    /// </summary>
    /// <param name="szName">元素名称</param>
    /// <param name="szValue">返回的元素值</param>
    /// <returns>执行结果</returns>
    public delegate bool GetElementValueCallback(QcCheckPoint qcCheckPoint,PatVisitInfo patVisitInfo, string szElementName, out string szElementValue);
    /// <summary>
    /// 设置指定元素的值的回调委托
    /// </summary>
    /// <param name="szName">元素名称</param>
    /// <param name="szValue">元素值</param>
    /// <returns>执行结果</returns>
    public delegate bool SetElementValueCallback(string szElementName, string szElementValue);
    /// <summary>
    /// 光标定位到指定元素位置回调委托
    /// </summary>
    ///<param name="elementName">元素名称</param>
    public delegate bool LocateToElementCallback(string elementName);
    /// <summary>
    /// 委托主线程调用的委托
    /// </summary>
    /// <param name="method">委托方法</param>
    /// <param name="args">参数</param>
    /// <returns>返回参数</returns>
    public delegate object ThreadInvokeCallback(Delegate method, params object[] args);
    /// <summary>
    /// 执行指定的SQL查询
    /// </summary>
    /// <param name="sql">SQL语句</param>
    /// <returns>查询结果集</returns>
    public delegate bool ExecuteQueryCallback(string sql, out DataSet data);
    /// <summary>
    /// 执行指定的SQL更新
    /// </summary>
    /// <param name="isProc">传入的SQL是否是存储过程</param>
    /// <param name="sql">SQL语句</param>
    /// <returns>被更新行数</returns>
    public delegate bool ExecuteUpdateCallback(bool isProc, params string[] sql);
    /// <summary>
    /// 获取系统运行上下文数据的回调委托
    /// </summary>
    /// <param name="szContextName">上下文名称</param>
    /// <param name="objContextValue">上下文数据</param>
    /// <returns>执行结果</returns>
    public delegate bool GetSystemContextCallback(string szContextName, out object objContextValue);
    /// <summary>
    /// 自定义事件回调委托
    /// </summary>
    /// <param name="sender">触发者</param>
    /// <param name="name">事件名称</param>
    /// <param name="param">事件参数</param>
    /// <param name="data">事件数据</param>
    /// <param name="result">事件结果</param>
    public delegate bool CustomEventCallback(object sender, string name, object param, object data, ref object result);
}
