using EMRDBLib;
using EMRDBLib.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml;
using Heren.MedQC.Core;
using Heren.MedQC.ScriptEngine;

namespace Heren.MedQC.CheckPoint.Commands
{

    public class 脚本引擎处理Command : AbstractCommand
    {
        public 脚本引擎处理Command()
        {
            this.m_name = "通用-脚本引擎处理";
        }
        public override bool Execute(object param, object data, out object result)
        {
            QcCheckPoint qcCheckPoint = param as QcCheckPoint;
            PatVisitInfo patVisitLog = data as PatVisitInfo;
            result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);

            QcCheckResult qcCheckResult = result as QcCheckResult;
            if (patVisitLog == null || qcCheckPoint == null || qcCheckResult == null)
                return true;
            if (string.IsNullOrEmpty(qcCheckPoint.ScriptID))
                return true;
            AutoCalcHandler autoCalcHandler = new AutoCalcHandler();
            autoCalcHandler.Start();
            autoCalcHandler.ExecuteElementCalculator(qcCheckPoint.ScriptID, patVisitLog,qcCheckPoint,qcCheckResult);
            result = qcCheckResult;
            return true;
        }
    }
}
