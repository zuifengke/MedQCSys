using System;
using System.Threading;
using Common.Logging;

namespace Quartz.Server
{
    /// <summary>
    /// A sample job that just prints info on console for demostration purposes.
    /// </summary>
    public class SampleJob2 : IJob
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SampleJob2));

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
            logger.Info("SampleJob2 running...");
            //Thread.Sleep(TimeSpan.FromSeconds(1));
            logger.Info("SampleJob2 run finished.");
        }
    }
}