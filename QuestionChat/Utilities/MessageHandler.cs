using System;
using System.Collections.Generic;
using System.Text;
using Heren.Common.Libraries;
using System.Windows.Forms;
using System.Threading;
using Heren.MedQC.QuestionChat.Forms;
using EMRDBLib.Entity;
using EMRDBLib.DbAccess;
using EMRDBLib;

namespace Heren.MedQC.QuestionChat.Utilities
{
    public class MessageHandler
    {
        public delegate void UpdateCheckProgressInvoker(int count, int index);

        private System.Windows.Forms.Timer m_timer = null;
        private Thread m_thread = null;
        private static MessageHandler m_instance = null;
        /// <summary>
        /// 获取消息收集器单实例
        /// </summary>
        public static MessageHandler Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = new MessageHandler();
                return m_instance;
            }
        }
        private ChatListForm m_chatListForm = null;
        /// <summary>
        /// 获取或设置关联的任务消息窗口
        /// </summary>
        public ChatListForm ChatListForm
        {
            get { return this.m_chatListForm; }
            set { this.m_chatListForm = value; }
        }

        private bool m_bIsRunning = false;
        /// <summary>
        /// 获取当前是否正在执行消息任务检查
        /// </summary>
        public bool IsRunning
        {
            get { return this.m_bIsRunning; }
        }
        /// <summary>
        /// 获取当前显示的消息总数
        /// </summary>
        public int MessageCount
        {
            get
            {
                if (m_qcMsgChatLogList == null)
                    return 0;
                return this.m_qcMsgChatLogList.Count;
            }
        }

        private List<QcMsgChatLog> m_qcMsgChatLogList = null;
        /// <summary>
        /// 质控问题消息列表
        /// </summary>
        public List<QcMsgChatLog> QcMsgChatLogList
        {
            get { return this.m_qcMsgChatLogList; }
        }

        /// <summary>
        /// 启动消息检查计时器
        /// </summary>
        public void StartCheckTimer(ChatListForm form)
        {
            if (this.m_chatListForm != form)
                this.m_chatListForm = form;

            //立即启动一次检查
            this.StartTaskCheckThread();

            //读取定时时间设置
            string key = SystemData.ConfigKey.TASK_REFRESH_INTERVAL;
            int interval = SystemConfig.Instance.Get(key, 30);
            if (interval <= 0)
            {
                if (this.m_timer != null)
                    this.m_timer.Enabled = false;
                return;
            }
            if (interval > 30) interval = 30;

            //初始化Timer计时器
            if (this.m_timer == null)
            {
                this.m_timer = new System.Windows.Forms.Timer();
                this.m_timer.Tick +=
                    delegate { this.StartTaskCheckThread(); };
            }
            this.m_timer.Interval = interval * 60 * 1000;
            if (!this.m_timer.Enabled) this.m_timer.Enabled = true;
        }
        /// <summary>
        /// 启动任务检查线程
        /// </summary>
        private void StartTaskCheckThread()
        {
            if (this.IsRunning)
                return;
            this.m_bIsRunning = true;
            try
            {
                this.m_thread = new Thread(new ThreadStart(this.StartTaskCheck));
                this.m_thread.IsBackground = true;
                this.m_thread.Start();
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("TaskHandler.StartTaskCheckThread", ex);
            }
        }
        /// <summary>
        /// 开始一次任务检查过程
        /// </summary>
        private void StartTaskCheck()
        {
            this.HandleTaskCheckStart();

            ////执行并加载质控问题反馈消息
            this.ExecuteQcQuestionCheck();

            this.HanldeTaskCheckStop();
        }
        /// <summary>
        /// 运行质控问题反馈检查提醒
        /// </summary>
        private void ExecuteQcQuestionCheck()
        {
            if (this.m_chatListForm == null || this.m_chatListForm.IsDisposed)
                return;
            if (SystemParam.Instance.QChatArgs == null)
                return;

            if (this.m_qcMsgChatLogList == null)
                this.m_qcMsgChatLogList = new List<QcMsgChatLog>();
            this.m_qcMsgChatLogList.Clear();
            short shRet;
            //找出发给当前用户未读的信息[当前发送者是别人的接收者对象]
            string szListener = SystemParam.Instance.QChatArgs.Sender;
            bool bIsRead = false;
            shRet = QcMsgChatAccess.Instance.GetQCMsgChatLogList(szListener, bIsRead, ref this.m_qcMsgChatLogList);
            if (this.m_chatListForm != null && !this.m_chatListForm.IsDisposed)
                this.m_chatListForm.Invoke(new MethodInvoker(this.m_chatListForm.LoadQcQuestionMessage));
        }
        /// <summary>
        /// 处理任务启动前事情
        /// </summary>
        private void HandleTaskCheckStart()
        {
            this.m_bIsRunning = true;

            if (this.m_chatListForm != null && !this.m_chatListForm.IsDisposed)
            {
                this.m_chatListForm.Invoke(
                    new MethodInvoker(this.m_chatListForm.HandleTaskCheckStart));
            }
            //PatientHandler.Instance.Initialize(this.m_chatListFormorm);
        }
        /// <summary>
        /// 处理任务消息检查结束过程
        /// </summary>
        private void HanldeTaskCheckStop()
        {
            this.m_bIsRunning = false;
            if (this.m_chatListForm != null && !this.m_chatListForm.IsDisposed)
                this.m_chatListForm.Invoke(new MethodInvoker(this.m_chatListForm.HandleTaskCheckStop));
        }
        /// <summary>
        /// 处理来自命令行的系统启动消息数据
        /// </summary>
        /// <param name="hSatrtupData">启动消息数据</param>
        public void HandleStartupMessage(IntPtr hSatrtupData)
        {
            StartupArgs argsHelper = new StartupArgs();
            try
            {
                argsHelper.ParsePtrArgs(hSatrtupData);
            }
            catch (Exception ex)
            {
                TrayIconHandler.Instance.ShowTrayPopupTip("错误的启动参数", ex.Message);
                return;
            }
            if (argsHelper.QChatArgs.ArgType == "1")
                this.SwtichUserInfo(argsHelper.QChatArgs);
            else
            {
                SystemParam.Instance.QChatArgs = argsHelper.QChatArgs;
                TrayIconHandler.Instance.CloseTaskTray();
                QCQuestionChatForm form = new QCQuestionChatForm();
                form.PatientID = argsHelper.QChatArgs.PatientID;
                form.VisitID = argsHelper.QChatArgs.VisitID;
                form.Sender = argsHelper.QChatArgs.Sender;
                form.Listener = argsHelper.QChatArgs.Listener;
                form.MsgID = argsHelper.QChatArgs.MsgID;
                form.Show();
            }
        }
        /// <summary>
        /// 切换当前用户信息以及病人信息
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="patientInfo">病人信息</param>
        /// <param name="visitInfo">就诊信息</param>
        private void SwtichUserInfo(QChatArgs qChatArgs)
        {
            if (this.m_chatListForm == null || this.m_chatListForm.IsDisposed)
                return;
            if (qChatArgs == null)
                return;

            //如果用户信息发生了改变
            bool bQChatArgshanged = false;
            if (SystemParam.Instance.QChatArgs == null
                || SystemParam.Instance.QChatArgs.Listener != qChatArgs.Listener)
            {
                bQChatArgshanged = true;
                this.StopCheckTimer();
                SystemParam.Instance.QChatArgs = qChatArgs.Clone() as QChatArgs;
            }

            string key = SystemData.ConfigKey.TASK_AUTO_POPOP_MESSAGE;
            bool bAutoPopupMessage = SystemConfig.Instance.Get(key, true);

            //如果用户信息发生了改变,那么立即启动更新
            if (bQChatArgshanged)
            {
                if (this.IsRunning)
                    this.StopCheckTimer();
                this.StartCheckTimer(this.m_chatListForm);
            }
        }
        /// <summary>
        /// 停止消息检查计时器
        /// </summary>
        public void StopCheckTimer()
        {
            if (this.m_timer != null)
            {
                this.m_timer.Enabled = false;
                this.m_timer.Dispose();
                this.m_timer = null;
            }
            this.StopTaskCheck();
        }
        /// <summary>
        /// 停止当前正在进行的任务检查
        /// </summary>
        private void StopTaskCheck()
        {
            bool bIsRunning = this.m_bIsRunning;
            this.m_bIsRunning = false;
            try
            {
                if (this.m_thread != null)
                    this.m_thread.Abort();
                this.m_thread = null;

            }
            catch (Exception ex)
            {
                this.m_thread = null;
                LogManager.Instance.WriteLog("TaskHandler.StopCheck", ex);
            }
            if (bIsRunning) this.HanldeTaskCheckStop();
        }
    }
}
