using System;
using System.Threading;
using Common.Logging;
using Heren.MedQC.CheckPoint;
using System.Collections.Generic;
using EMRDBLib.DbAccess;
using EMRDBLib;
using System.Linq;

namespace Quartz.Server
{
    /// <summary>
    /// A sample job that just prints info on console for demostration purposes.
    /// </summary>
    public class JobCheckPoint : IJob
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(JobCheckPoint));
       

        /// <summary>
        /// Called by the <see cref="IScheduler" /> when a <see cref="ITrigger" />
        /// fires that is associated with the <see cref="IJob" />.
        /// </summary>
        /// <remarks>
        /// The implementation may wish to set a  result object on the 
        /// JobExecutionContext before this method exits.  The result itself
        /// is meaningless to Quartz, but may be informative to 
        /// <see cref="IJobListener" />s or 
        /// <see cref="ITriggerListener" />s that are watching the job's 
        /// execution.
        /// </remarks>
        /// <param name="context">The execution context.</param>
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                logger.Info("全院运行病历缺陷分析开始...");

                if (SystemContext.Instance.QueuePatVisit == null)
                    SystemContext.Instance.QueuePatVisit = new Queue<EMRDBLib.PatVisitInfo>();
                if (SystemContext.Instance.QueuePatVisit.Count <= 0)
                {
                    List<PatVisitInfo> lstPatVisitInfo = null;
                    //从数据库中读取
                    short shRet= InpVisitAccess.Instance.GetInpVisitInfos(ref lstPatVisitInfo);
                    //插入队列
                    foreach (var item in lstPatVisitInfo.ToList())
                    {
                        SystemContext.Instance.QueuePatVisit.Enqueue(item);
                    }
                }
                int index = 0;
                do
                {
                    index++;
                    PatVisitInfo patVisitInfo = SystemContext.Instance.QueuePatVisit.Dequeue();
                    CheckPointHelper.Instance.CheckPatient(patVisitInfo);
                } while (SystemContext.Instance.QueuePatVisit.Count>0&&index<3);
                logger.Info("全院运行病历缺陷分析结束 run finished.");
            }
            catch (Exception ex)
            {
                logger.Info(ex);
            }
        }
    }
}