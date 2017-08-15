using System;
using System.Collections.Generic;
using System.Text;
using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using Heren.MedQC.Core;

namespace Heren.MedQC.CheckPoint
{
    /// <summary>
    /// 缺陷处理帮助类
    /// </summary>
    public class CheckPointHelper
    {
        private static CheckPointHelper _Instance = null;
        public static CheckPointHelper Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CheckPointHelper();
                return _Instance;
            }

        }
        /// <summary>
        /// 初始化规则检查前的患者资料基础数据
        /// </summary>
        public void InitPatientInfo(PatVisitInfo patVisitLog)
        {
            //1.患者基本信息
            short shRet = PatVisitAccess.Instance.GetPatVisitInfo(patVisitLog.PATIENT_ID, patVisitLog.VISIT_ID, ref patVisitLog);
            //2.初始化文书列表
            List<MedDocInfo> lstMedDocInfo = new List<MedDocInfo>();
            //新系统病历visit_id字段存了visit_no
            shRet = EmrDocAccess.Instance.GetDocList(patVisitLog.PATIENT_ID, patVisitLog.VISIT_NO, ref lstMedDocInfo);
            patVisitLog.MedDocInfos = lstMedDocInfo;
        }

        public QcCheckResult InitQcCheckResult(QcCheckPoint qcCheckPoint, PatVisitInfo patVisitInfo)
        {
            QcCheckResult qcCheckResult = new QcCheckResult();
            qcCheckResult.PATIENT_ID = patVisitInfo.PATIENT_ID;
            qcCheckResult.VISIT_ID = patVisitInfo.VISIT_ID;
            qcCheckResult.VISIT_NO = patVisitInfo.VISIT_NO;
            qcCheckResult.PATIENT_NAME = patVisitInfo.PATIENT_NAME;
            qcCheckResult.DEPT_CODE = patVisitInfo.DEPT_CODE;
            qcCheckResult.DEPT_IN_CHARGE = patVisitInfo.DEPT_NAME;
            qcCheckResult.INCHARGE_DOCTOR = patVisitInfo.INCHARGE_DOCTOR;
            qcCheckResult.CHECK_POINT_ID = qcCheckPoint.CheckPointID;
            qcCheckResult.MSG_DICT_MESSAGE = qcCheckPoint.MsgDictMessage;
            qcCheckResult.CHECK_DATE = DateTime.Now;
            qcCheckResult.SCORE = qcCheckPoint.Score;
            qcCheckResult.QA_EVENT_TYPE = qcCheckPoint.QaEventType;
            qcCheckResult.MSG_DICT_CODE = qcCheckPoint.MsgDictCode;
            qcCheckResult.ORDER_VALUE = qcCheckPoint.OrderValue;
            qcCheckResult.MR_STATUS =string.IsNullOrEmpty( patVisitInfo.MR_STATUS)?"O":patVisitInfo.MR_STATUS;
            qcCheckResult.STAT_TYPE = SystemData.StatType.System;
            return qcCheckResult;
        }

        /// <summary>
        /// 运行某患者病案自动检查缺陷内容
        /// </summary>
        public void CheckPatient(PatVisitInfo patVisitLog)
        {
            //初始化患者病案资料
            Heren.MedQC.CheckPoint.CheckPointHelper.Instance.InitPatientInfo(patVisitLog);
            //获取缺陷自动检查配置规则列表
            List<QcCheckPoint> lstQcCheckPoint = null;
            short shRet = QcCheckPointAccess.Instance.GetQcCheckPoints(ref lstQcCheckPoint);
            if (shRet != SystemData.ReturnValue.OK)
                return;
            foreach (var item in lstQcCheckPoint)
            {
                if (string.IsNullOrEmpty(item.HandlerCommand))
                    continue;
                object result = null;
                CommandHandler.Instance.SendCommand(item.HandlerCommand, item, patVisitLog, out result);
                QcCheckResult qcCheckResult = result as QcCheckResult;
                if (qcCheckResult == null)
                    continue;
                QcCheckResultAccess.Instance.SaveQcCheckResult(qcCheckResult);

            }
        }

    }
}
