using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMRDBLib;

namespace Quartz.Server
{
    /// <summary>
    /// 
    /// </summary>
    public class SystemContext
    {
        private static SystemContext  _Instance = null;
        /// <summary>
        /// 
        /// </summary>
        public static SystemContext Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new SystemContext();
                return _Instance;
            }
        }
        /// <summary>
        /// 缺陷检查患者队列
        /// </summary>
        public Queue<PatVisitInfo> QueuePatVisit { get; set; }
        /// <summary>
        /// 时效检查患者队列
        /// </summary>
        public Queue<PatVisitInfo> QueueTimeCheckPatVisit { get; set; }
    }
}
