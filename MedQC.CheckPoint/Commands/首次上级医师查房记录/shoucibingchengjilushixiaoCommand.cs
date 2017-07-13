using EMRDBLib;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Heren.MedQC.Core;

namespace Heren.MedQC.CheckPoint.Commands.oldhis
{
    /// <summary>
    /// 缺陷内容：上级医师首次查房记录未在患者入院后48小时内完成
    /// 核查方法：患者入院48小时后核查，病程文件中“上级医师首次查房记录”的医生审签时间未在患者进入院48小时内。
    /// </summary>
    public class shoucishangjibingchengjilushixiaoCommand : AbstractCommand
    {
        public shoucishangjibingchengjilushixiaoCommand()
        {
            this.m_name = "新军卫-首次上级医师查房记录48小时内完成";
        }
        public override bool Execute(object param, object data, out object result)
        {
            try
            {
                QcCheckPoint qcCheckPoint = param as QcCheckPoint;
                PatVisitInfo patVisitLog = data as PatVisitInfo;
                result = CheckPointHelper.Instance.InitQcCheckResult(qcCheckPoint, patVisitLog);
                QcCheckResult qcCheckResult = result as QcCheckResult;
                //查询患者指定文书类型ID号
                string szPeriodDesc = string.Empty;
                DateTime dtEndTime = TimeCheckHelper.Instance.GetWrittenPeriod(qcCheckPoint.WrittenPeriod, patVisitLog.VISIT_TIME, ref szPeriodDesc);

                List<MedDocInfo> documentlist = TimeCheckHelper.Instance.GetDocumentList(qcCheckPoint.DocTypeID, patVisitLog.MedDocInfos);
                foreach (var item in documentlist)
                {
                    //找到文书入院记录相关的文书，判断文档创建时间是否在入院24小时之内
                    if (item.DOC_TIME > dtEndTime)
                    {
                        qcCheckResult.QC_RESULT = 0;
                        qcCheckResult.QC_EXPLAIN = string.Format("患者{0}入院，书写{1}时间{2},截止时间{3},结果超时"
                            , patVisitLog.VISIT_TIME.ToString()
                            , item.DOC_TITLE
                            , item.DOC_TIME.ToString()
                            , dtEndTime.ToString()
                            );

                        qcCheckResult.ERROR_COUNT = 1;
                    }
                    else
                    {
                        qcCheckResult.QC_RESULT = 1;
                        qcCheckResult.QC_EXPLAIN = string.Format("患者{0}入院，书写{1}时间{2},截止时间{3},结果正常"
                            , patVisitLog.VISIT_TIME.ToString()
                            , item.DOC_TITLE
                            , item.DOC_TIME.ToString()
                            , dtEndTime.ToString()
                            );
                    }
                    qcCheckResult.DOC_TITLE = item.DOC_TITLE;
                    qcCheckResult.DOC_TIME = item.DOC_TIME;
                    qcCheckResult.DOC_SETID = item.DOC_SETID;
                    qcCheckResult.DOCTYPE_ID = item.DOC_TYPE;
                    qcCheckResult.MODIFY_TIME = item.MODIFY_TIME;
                    qcCheckResult.CREATE_ID = item.CREATOR_ID;
                    qcCheckResult.CREATE_NAME = item.CREATOR_NAME;
                    break;
                }
                if (string.IsNullOrEmpty(qcCheckResult.QC_EXPLAIN) && DateTime.Now > dtEndTime)
                {
                    qcCheckResult.QC_RESULT = 0;
                    qcCheckResult.QC_EXPLAIN = string.Format("患者{0}入院，{1}未书写，期限已到，结果超时"
                        , patVisitLog.VISIT_TIME.ToString()
                        , qcCheckPoint.DocTypeName);

                    qcCheckResult.ERROR_COUNT = 1;

                }
                else if (string.IsNullOrEmpty(qcCheckResult.QC_EXPLAIN))
                {
                    qcCheckResult.QC_RESULT = 1;
                    qcCheckResult.QC_EXPLAIN = string.Format("患者{0}入院，{1}未书写，期限未到，结果正常"
                        , patVisitLog.VISIT_TIME.ToString()
                        , qcCheckPoint.DocTypeName);

                }
                return true;
            }
            catch (Exception ex)
            {
                result = null;
                LogManager.Instance.WriteLog("新军卫-首次上级医师查房记录48小时内完成处理命令发生异常", ex);
                return false;
            }
        }

    }
}
