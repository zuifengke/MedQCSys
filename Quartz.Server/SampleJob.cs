using System;
using System.Threading;
using Common.Logging;
using Heren.MedQC.CheckPoint;

namespace Quartz.Server
{
    /// <summary>
    /// A sample job that just prints info on console for demostration purposes.
    /// </summary>
    public class SampleJob : IJob
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SampleJob));

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
                logger.Info("单患者规则运行测试分析开始...");
                //Thread.Sleep(TimeSpan.FromSeconds(1));
                EMRDBLib.PatVisitInfo patVisitLog = new EMRDBLib.PatVisitInfo();
                patVisitLog.PATIENT_ID = "P101210";
                patVisitLog.VISIT_NO = "20170300005";
                patVisitLog.VISIT_ID = "2";
                //CheckPointHelper.Instance.CheckPatient(patVisitLog);
                logger.Info("单患者规则运行测试分析结束 run finished.");
            }
            catch (Exception ex)
            {
                logger.Info(ex);
            }
        }
    }
}