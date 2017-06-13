
using System;
using System.Threading;
using Common.Logging;
using System.Collections.Generic;
using EMRDBLib.DbAccess;
using EMRDBLib;
using System.Linq;
using MedDocSys.QCEngine.TimeCheck;

namespace Quartz.Server
{
    /// <summary>
    /// 时效检查定时任务
    /// </summary>
    public class JobTimeCheck : IJob
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(JobTimeCheck));
       

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
                logger.Info("全院病历时效分析开始...");
               
                if (SystemContext.Instance.QueueTimeCheckPatVisit == null)
                    SystemContext.Instance.QueueTimeCheckPatVisit = new Queue<EMRDBLib.PatVisitInfo>();
                if (SystemContext.Instance.QueueTimeCheckPatVisit.Count <= 0)
                {
                    List<PatVisitInfo> lstPatVisitInfo = null;
                    short shRet = QcTimeRecordAccess.Instance.GetPatsListByInHosptial(ref lstPatVisitInfo);
                    if (shRet != SystemData.ReturnValue.OK && shRet != SystemData.ReturnValue.RES_NO_FOUND)
                    {
                        logger.Error("未查询到在院病人或失败");
                        return;
                    }
                    DateTime dtDischargeBeginTime = DateTime.Parse(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd 00:00:00"));
                    DateTime dtDischargeEndTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
                    shRet = QcTimeRecordAccess.Instance.GetPatsListByOutHosptial(dtDischargeBeginTime, dtDischargeEndTime,
                  ref lstPatVisitInfo);
                    if (shRet!=SystemData.ReturnValue.OK 
                        && shRet!=SystemData.ReturnValue.RES_NO_FOUND
                        && lstPatVisitInfo==null)
                    {
                        logger.Info("全院病历时效分析获取出院患者列表数据为空...");
                    }
                    //插入队列
                    foreach (var item in lstPatVisitInfo.ToList())
                    {
                        SystemContext.Instance.QueueTimeCheckPatVisit.Enqueue(item);
                    }
                }
                int index = 0;
                int successCount = 0;
                int errorCount = 0;
                DateTime now = DateTime.Now;
                do
                {
                    index++;
                    PatVisitInfo patVisitInfo = SystemContext.Instance.QueueTimeCheckPatVisit.Dequeue();
                   short shRet =TimeCheckHelper.Instance.GenerateTimeRecord(patVisitInfo, now);
                    if (shRet == SystemData.ReturnValue.OK)
                    {
                        successCount++;
                    }
                    else if (shRet != SystemData.ReturnValue.RES_NO_FOUND)
                    {
                        errorCount++;
                    }
                } while (SystemContext.Instance.QueueTimeCheckPatVisit.Count>0&&index<5);
                logger.Info(string.Format("全院病历时效分析结束 成功：{0}份；错误：{1}份\n",successCount,errorCount));
            }
            catch (Exception ex)
            {
                logger.Info(ex);
            }
        }
    }
}