// ***********************************************************
// 电子病历系统关联元素自动计算脚本抽象类.
// Creator: YangMingkun  Date:2011-11-10
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Libraries.Ftp;

namespace Heren.MedQC.ScriptEngine.Script
{
    public abstract class AbstractElementCalculator : IElementCalculator
    {
        #region "IRuntimeHandler"
        protected GetElementValueCallback m_getElementValueCallback = null;
        /// <summary>
        /// 获取或设置获取元素值的回调委托
        /// </summary>
        public virtual GetElementValueCallback GetElementValueCallback
        {
            get { return this.m_getElementValueCallback; }
            set { this.m_getElementValueCallback = value; }
        }

        protected SetElementValueCallback m_setElementValueCallback = null;
        /// <summary>
        /// 获取或设置设置元素值的回调委托
        /// </summary>
        public virtual SetElementValueCallback SetElementValueCallback
        {
            get { return this.m_setElementValueCallback; }
            set { this.m_setElementValueCallback = value; }
        }

        protected HideElementTipCallback m_hideElementTipCallback = null;
        /// <summary>
        /// 获取或设置隐藏元素提示的回调委托
        /// </summary>
        public virtual HideElementTipCallback HideElementTipCallback
        {
            get { return this.m_hideElementTipCallback; }
            set { this.m_hideElementTipCallback = value; }
        }

        protected ShowElementTipCallback m_showElementTipCallback = null;
        /// <summary>
        /// 获取或设置显示元素提示的回调委托
        /// </summary>
        public virtual ShowElementTipCallback ShowElementTipCallback
        {
            get { return this.m_showElementTipCallback; }
            set { this.m_showElementTipCallback = value; }
        }

        private ThreadInvokeCallback m_threadInvokeCallback = null;
        /// <summary>
        /// 获取或设置委托主线程调用的回调委托
        /// </summary>
        public ThreadInvokeCallback ThreadInvokeCallback
        {
            get { return this.m_threadInvokeCallback; }
            set { this.m_threadInvokeCallback = value; }
        }

        private ExecuteQueryCallback m_executeQueryCallback = null;
        /// <summary>
        /// 获取或设置执行指定的SQL查询的回调委托
        /// </summary>
        public ExecuteQueryCallback ExecuteQueryCallback
        {
            get { return this.m_executeQueryCallback; }
            set { this.m_executeQueryCallback = value; }
        }

        private ExecuteUpdateCallback m_executeUpdateCallback = null;
        /// <summary>
        /// 获取或设置执行指定的SQL更新的回调委托
        /// </summary>
        public ExecuteUpdateCallback ExecuteUpdateCallback
        {
            get { return this.m_executeUpdateCallback; }
            set { this.m_executeUpdateCallback = value; }
        }

        protected GetSystemContextCallback m_getSystemContextCallback = null;
        /// <summary>
        /// 获取或设置获取系统运行上下文数据的回调委托
        /// </summary>
        public virtual GetSystemContextCallback GetSystemContextCallback
        {
            get { return this.m_getSystemContextCallback; }
            set { this.m_getSystemContextCallback = value; }
        }

        private CustomEventCallback m_customEventCallback = null;
        /// <summary>
        /// 获取或设置自定义事件回调委托
        /// </summary>
        public CustomEventCallback CustomEventCallback
        {
            get { return this.m_customEventCallback; }
            set { this.m_customEventCallback = value; }
        }

        private LocateToElementCallback m_locateToElementCallback = null;
        /// <summary>
        /// 获取或设置光标定位到指定元素位置回调委托
        /// </summary>
        public LocateToElementCallback LocateToElementCallback
        {
            get { return this.m_locateToElementCallback; }
            set { this.m_locateToElementCallback = value; }
        }

        /// <summary>
        /// 提供给子类重写的运算方法
        /// </summary>
        /// <param name="szElementName">元素名称</param>
        public virtual void Calculate(string szElementName)
        {

        }

        /// <summary>
        /// 提供给子类重写的运算方法
        /// </summary>
        /// <param name="param">参数名称</param>
        /// <param name="data">参数数据</param>
        public virtual bool Calculate(string param, object data)
        {
            return false;
        }
        #endregion

        #region"IDisposable"
        /// <summary>
        /// 释放脚本中占用的资源
        /// </summary>
        public void Dispose()
        {
            this.StopTimer();
            this.StopAllThreads();
            this.CloseAllFtpServices();
        }
        #endregion

        #region"消息框函数"
        /// <summary>
        /// 弹出一条错误对话消息框
        /// </summary>
        /// <param name="message">消息内容</param>
        protected virtual void ShowError(string message)
        {
            MessageBoxEx.ShowError(message);
        }

        /// <summary>
        /// 弹出一条错误对话消息框
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="details">详细消息</param>
        protected virtual void ShowError(string message, string details)
        {
            MessageBoxEx.ShowError(message, details);
        }

        /// <summary>
        /// 弹出警告消息对话框
        /// </summary>
        /// <param name="message">消息内容</param>
        protected virtual void ShowWarning(string message)
        {
            MessageBoxEx.ShowWarning(message);
        }

        /// <summary>
        /// 弹出警告消息对话框
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="details">详细消息</param>
        protected virtual void ShowWarning(string message, string details)
        {
            MessageBoxEx.ShowWarning(message, details);
        }

        /// <summary>
        /// 弹出普通消息对话框
        /// </summary>
        /// <param name="message">消息内容</param>
        protected virtual void ShowMessage(string message)
        {
            MessageBoxEx.ShowMessage(message);
        }

        /// <summary>
        /// 弹出普通消息对话框
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="details">详细消息</param>
        protected virtual void ShowMessage(string message, string details)
        {
            MessageBoxEx.ShowMessage(message, details);
        }

        /// <summary>
        /// 弹出确认消息对话框
        /// </summary>
        /// <param name="confirm">消息内容</param>
        protected virtual DialogResult ShowConfirm(string confirm)
        {
            return MessageBoxEx.ShowConfirm(confirm);
        }

        /// <summary>
        /// 弹出确认消息对话框
        /// </summary>
        /// <param name="confirm">消息内容</param>
        /// <param name="details">详细消息</param>
        protected virtual DialogResult ShowConfirm(string confirm, string details)
        {
            return MessageBoxEx.ShowConfirm(confirm, details);
        }

        /// <summary>
        /// 弹出是否消息对话框
        /// </summary>
        /// <param name="confirm">消息内容</param>
        protected virtual DialogResult ShowYesNo(string confirm)
        {
            return MessageBoxEx.ShowYesNo(confirm);
        }

        /// <summary>
        /// 弹出是否消息对话框
        /// </summary>
        /// <param name="confirm">消息内容</param>
        /// <param name="details">详细消息</param>
        protected virtual DialogResult ShowYesNo(string confirm, string details)
        {
            return MessageBoxEx.ShowYesNo(confirm, details);
        }

        /// <summary>
        /// 弹出询问消息对话框
        /// </summary>
        /// <param name="question">消息内容</param>
        protected virtual DialogResult ShowQuestion(string question)
        {
            return MessageBoxEx.ShowQuestion(question);
        }

        /// <summary>
        /// 弹出询问消息对话框
        /// </summary>
        /// <param name="question">消息内容</param>
        /// <param name="details">详细消息</param>
        protected virtual DialogResult ShowQuestion(string question, string details)
        {
            return MessageBoxEx.ShowQuestion(question, details);
        }
        #endregion

        #region"定时器接口"
        private System.Windows.Forms.Timer m_timer = null;
        /// <summary>
        /// 启动定时器
        /// </summary>
        /// <param name="interval">时长</param>
        public void StartTimer(int interval)
        {
            if (this.m_timer == null)
            {
                this.m_timer = new System.Windows.Forms.Timer();
                this.m_timer.Interval = interval;
                this.m_timer.Tick += new EventHandler(this.Timer_Tick);
            }
            if (!this.m_timer.Enabled)
                this.m_timer.Start();
        }

        /// <summary>
        /// 终止并销毁定时器
        /// </summary>
        public void StopTimer()
        {
            if (this.m_timer != null)
            {
                this.m_timer.Stop();
                this.m_timer.Dispose();
            }
            this.m_timer = null;
        }

        /// <summary>
        /// 定时器定时执行的方法
        /// </summary>
        protected virtual void TimerTick()
        {
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.TimerTick();
        }
        #endregion

        #region"多线程接口"
        private Dictionary<string, Thread> m_threads = null;
        /// <summary>
        /// 启动一个线程
        /// </summary>
        /// <param name="name">线程名称</param>
        public void StartThread(string name)
        {
            if (GlobalMethods.Misc.IsEmptyString(name))
                return;

            if (this.m_threads == null)
                this.m_threads = new Dictionary<string, Thread>();
            this.StopThread(name);

            ParameterizedThreadStart threadStart =
                new ParameterizedThreadStart(this.ThreadCallback);
            try
            {
                Thread thread = new Thread(threadStart);
                thread.IsBackground = true;
                thread.Name = name;
                thread.Start(name);
                this.m_threads.Add(name, thread);
            }
            catch (Exception ex)
            {
                MessageBoxEx.ShowError("无法启动线程!", ex.ToString());
            }
        }

        /// <summary>
        /// 停止当前运行的所有子线程
        /// </summary>
        public void StopAllThreads()
        {
            if (this.m_threads == null || this.m_threads.Count <= 0)
                return;
            string[] names = new string[this.m_threads.Count];
            this.m_threads.Keys.CopyTo(names, 0);
            foreach (string name in names)
                this.StopThread(name);
        }

        /// <summary>
        /// 终止并销毁线程
        /// </summary>
        /// <param name="name">线程名称</param>
        public void StopThread(string name)
        {
            if (GlobalMethods.Misc.IsEmptyString(name))
                return;
            if (!this.m_threads.ContainsKey(name))
                return;
            try
            {
                Thread thread = this.m_threads[name];
                if (this.IsThreadRunning(name))
                    thread.Abort();
                this.m_threads.Remove(name);
            }
            catch (Exception ex)
            {
                MessageBoxEx.ShowError("无法终止线程!", ex.ToString());
            }
        }

        /// <summary>
        /// 线程回调方法接口
        /// </summary>
        /// <param name="name">线程名称</param>
        protected virtual void ThreadCallback(object name)
        {
        }

        /// <summary>
        /// 判断当前线程是否正在运行
        /// </summary>
        /// <param name="name">线程名称</param>
        protected virtual bool IsThreadRunning(string name)
        {
            if (GlobalMethods.Misc.IsEmptyString(name))
                return false;
            if (!this.m_threads.ContainsKey(name))
                return false;
            Thread thread = this.m_threads[name];
            return (thread != null && thread.IsAlive);
        }

        /// <summary>
        /// 委托主线程调用的委托
        /// </summary>
        /// <param name="method">委托方法</param>
        /// <param name="args">参数</param>
        /// <returns>返回参数</returns>
        protected virtual object Invoke(Delegate method, params object[] args)
        {
            if (this.m_threadInvokeCallback != null)
                return this.m_threadInvokeCallback(method, args);
            return string.Empty;
        }
        #endregion

        #region"FTP服务接口"
        private Dictionary<string, FtpAccess> m_ftpAccessDict = null;
        /// <summary>
        /// 创建一个新的FTP服务
        /// </summary>
        /// <param name="name">FTP服务名称</param>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <param name="user">用户名</param>
        /// <param name="pwd">密码</param>
        protected void CreateFtpService(string name, string ip, int port, string user, string pwd)
        {
            if (GlobalMethods.Misc.IsEmptyString(name))
                return;
            if (this.m_ftpAccessDict == null)
                this.m_ftpAccessDict = new Dictionary<string, FtpAccess>();
            if (!this.m_ftpAccessDict.ContainsKey(name))
            {
                FtpAccess ftpAccess = new FtpAccess();
                ftpAccess.FtpIP = ip;
                ftpAccess.FtpPort = port;
                ftpAccess.UserName = user;
                ftpAccess.Password = pwd;
                this.m_ftpAccessDict.Add(name, ftpAccess);
            }
        }

        /// <summary>
        /// 停止当前运行的所有FTP服务
        /// </summary>
        protected void CloseAllFtpServices()
        {
            if (this.m_ftpAccessDict == null || this.m_ftpAccessDict.Count <= 0)
                return;
            string[] names = new string[this.m_ftpAccessDict.Count];
            this.m_ftpAccessDict.Keys.CopyTo(names, 0);
            foreach (string name in names)
                this.CloseFtpService(name);
        }

        /// <summary>
        /// 终止并销毁FTP服务
        /// </summary>
        /// <param name="name">FTP服务名称</param>
        protected void CloseFtpService(string name)
        {
            if (GlobalMethods.Misc.IsEmptyString(name))
                return;
            if (this.m_ftpAccessDict == null || this.m_ftpAccessDict.Count <= 0)
                return;
            if (this.m_ftpAccessDict.ContainsKey(name))
            {
                this.m_ftpAccessDict[name].CloseConnection();
                this.m_ftpAccessDict.Remove(name);
            }
        }

        /// <summary>
        /// 上传指定的本地文件到ftp服务器
        /// </summary>
        /// <param name="name">FTP名称</param>
        /// <param name="name">本地文件</param>
        /// <param name="name">远程文件</param>
        protected virtual bool UploadFile(string name, string localFile, string remoteFile)
        {
            if (GlobalMethods.Misc.IsEmptyString(name))
                return false;
            if (this.m_ftpAccessDict == null || this.m_ftpAccessDict.Count <= 0)
                return false;
            if (!this.m_ftpAccessDict.ContainsKey(name))
                return false;
            bool success = false;
            FtpAccess ftpAccess = this.m_ftpAccessDict[name];
            if (ftpAccess.OpenConnection())
            {
                string remoteDirectory = GlobalMethods.IO.GetFilePath(remoteFile);
                if (ftpAccess.CreateDirectory(remoteDirectory))
                    success = ftpAccess.Upload(localFile, remoteFile);
            }
            ftpAccess.CloseConnection();
            return success;
        }

        /// <summary>
        /// 从指定的ftp服务器下载指定的文件到本地
        /// </summary>
        /// <param name="name">FTP名称</param>
        /// <param name="name">远程文件</param>
        /// <param name="name">本地文件</param>
        protected virtual bool DownloadFile(string name, string remoteFile, string localFile)
        {
            if (GlobalMethods.Misc.IsEmptyString(name))
                return false;
            if (this.m_ftpAccessDict == null || this.m_ftpAccessDict.Count <= 0)
                return false;
            if (!this.m_ftpAccessDict.ContainsKey(name))
                return false;
            bool success = false;
            FtpAccess ftpAccess = this.m_ftpAccessDict[name];
            if (ftpAccess.OpenConnection())
            {
                string localDirectory = GlobalMethods.IO.GetFilePath(localFile);
                if (GlobalMethods.IO.CreateDirectory(localDirectory))
                    success = ftpAccess.Download(remoteFile, localFile);
            }
            ftpAccess.CloseConnection();
            return false;
        }
        #endregion

        /// <summary>
        /// 全角字符转半角字符.
        /// </summary>
        /// <param name="value">初始字符串</param>
        /// <returns>转换后的半角字符串</returns>
        /// <remarks>这个转换可能每个脚本都会用到,所以放到基类中</remarks>
        protected virtual string SBCToDBC(string value)
        {
            return Heren.Common.Libraries.GlobalMethods.Convert.SBCToDBC(value);
        }

        /// <summary>
        /// 将指定双精度数值四舍五入.
        /// </summary>
        /// <param name="value">双精度数值</param>
        /// <param name="digits">小数位数</param>
        /// <returns>转换后的半角字符串</returns>
        /// <remarks>这个转换可能每个脚本都会用到,所以放到基类中</remarks>
        protected virtual double RoundValue(double value, int digits)
        {
            try
            {
                return Math.Round(value, digits, MidpointRounding.ToEven);
            }
            catch { return value; }
        }

        /// <summary>
        /// 将指定单精度数值四舍五入.
        /// </summary>
        /// <param name="value">单精度数值</param>
        /// <param name="digits">小数位数</param>
        /// <returns>转换后的半角字符串</returns>
        /// <remarks>这个转换可能每个脚本都会用到,所以放到基类中</remarks>
        protected virtual float RoundValue(float value, int digits)
        {
            try
            {
                return (float)Math.Round(value, digits, MidpointRounding.ToEven);
            }
            catch { return value; }
        }

        /// <summary>
        /// 调用外部应用程序
        /// </summary>
        /// <param name="appFile">程序文件路径</param>
        /// <param name="args">调用参数</param>
        /// <returns>执行结果</returns>
        protected virtual bool InvokeApp(string appFile, string args)
        {
            try
            {
                System.Diagnostics.Process.Start(appFile, args);
                return true;
            }
            catch (Exception ex)
            {
                Heren.Common.Libraries.LogManager.Instance.WriteLog(
                    "ElementCalculator.InvokeApplication",
                    new string[] { "appFile" }, new object[] { appFile },
                    "无法启动外部应用程序", ex);
                return false;
            }
        }

        /// <summary>
        /// 获取编辑器系统当前运行路径
        /// </summary>
        /// <param name="szStartupPath">当前运行路径</param>
        /// <returns>执行结果</returns>
        protected virtual bool GetStartupPath(out string szStartupPath)
        {
            szStartupPath = Heren.Common.Libraries.GlobalMethods.Misc.GetWorkingPath();
            return true;
        }

        /// <summary>
        /// 执行一个SQL查询
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>是否查询成功</returns>
        protected virtual bool ExecuteQuery(string sql, out DataSet data)
        {
            data = null;
            if (this.m_executeQueryCallback != null)
                return this.m_executeQueryCallback.Invoke(sql, out data);
            return false;
        }

        /// <summary>
        /// 执行指定的一系列的SQL更新
        /// </summary>
        /// <param name="isProc">传入的SQL是否是存储过程</param>
        /// <param name="sql">SQL语句数组</param>
        /// <returns>是否更新成功</returns>
        protected virtual bool ExecuteUpdate(bool isProc, params string[] sql)
        {
            if (this.m_executeUpdateCallback != null)
                return this.m_executeUpdateCallback.Invoke(isProc, sql);
            return false;
        }

        /// <summary>
        /// 隐藏当前元素提示
        /// </summary>
        /// <returns>执行结果</returns>
        protected virtual bool HideElementTip()
        {
            if (this.m_hideElementTipCallback != null)
                return this.m_hideElementTipCallback.Invoke();
            return false;
        }

        /// <summary>
        /// 显示当前元素提示
        /// </summary>
        /// <param name="szTitle">提示标题</param>
        /// <param name="szTipText">提示文本</param>
        /// <returns>执行结果</returns>
        protected virtual bool ShowElementTip(string szTitle, string szTipText)
        {
            if (this.m_showElementTipCallback != null)
                return this.m_showElementTipCallback.Invoke(szTitle, szTipText);
            return false;
        }

        /// <summary>
        /// 设置指定元素的值
        /// </summary>
        /// <param name="szElementName">元素名称</param>
        /// <param name="szElementValue">元素值</param>
        /// <returns>执行结果</returns>
        protected virtual bool SetElementValue(string szElementName, string szElementValue)
        {
            if (this.m_setElementValueCallback != null)
                return this.m_setElementValueCallback.Invoke(szElementName, szElementValue);
            return false;
        }

        /// <summary>
        /// 获取指定元素的值
        /// </summary>
        /// <param name="szElementName">元素名称</param>
        /// <param name="szElementValue">返回的元素值</param>
        /// <returns>执行结果</returns>
        protected virtual bool GetElementValue(string szElementName, out string szElementValue)
        {
            szElementValue = string.Empty;
            if (this.m_getElementValueCallback != null)
                return this.m_getElementValueCallback.Invoke(szElementName, out szElementValue);
            return false;
        }

        /// <summary>
        /// 将光标定位到指定元素
        /// </summary>
        /// <param name="szElementName">元素名称</param>
        /// <returns>执行结果</returns>
        protected virtual bool LocateToElement(string szElementName)
        {
            if (this.m_locateToElementCallback != null)
                return this.m_locateToElementCallback.Invoke(szElementName);
            return false;
        }

        /// <summary>
        /// 获取系统运行上下文数据
        /// </summary>
        /// <param name="szContextName">上下文名称</param>
        /// <param name="objContextValue">返回的上下文值</param>
        /// <returns>执行结果</returns>
        protected virtual bool GetSystemContext(string szContextName, out object objContextValue)
        {
            objContextValue = string.Empty;
            if (this.m_getSystemContextCallback != null)
                return this.m_getSystemContextCallback.Invoke(szContextName, out objContextValue);
            return false;
        }

        /// <summary>
        /// 触发一次自定义事件
        /// </summary>
        /// <param name="sender">触发者</param>
        /// <param name="name">事件名称</param>
        /// <param name="param">事件参数</param>
        /// <param name="data">事件数据</param>
        /// <param name="result">事件结果</param>
        /// <returns>是否执行成功</returns>
        protected virtual bool RaiseCustomEvent(object sender
            , string name, object param, object data, ref object result)
        {
            if (this.m_customEventCallback != null)
                return this.m_customEventCallback.Invoke(sender, name, param, data, ref result);
            return false;
        }
    }
}
