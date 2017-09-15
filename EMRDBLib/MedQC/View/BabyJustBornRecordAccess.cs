// ***********************************************************
// 数据库访问层与病案索引补充表数据相关的访问类.补充病案的归档、退回、纸质接收等操作的记录
// Creator:yehui  Date:2017-4-18
// Copyright:heren
// ***********************************************************
using EMRDBLib.Entity;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
namespace EMRDBLib.DbAccess
{

    public class BabyJustBornRecordAccess : DBAccessBase
    {
        private static BabyJustBornRecordAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static BabyJustBornRecordAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new BabyJustBornRecordAccess();
                return BabyJustBornRecordAccess.m_Instance;
            }
        }

        public short GetModel(string szPatientID, string szVisitNO, ref BabyJustBornRecord model)
        {
            if (base.MedQCAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            StringBuilder sbField = new StringBuilder();
            sbField.AppendFormat("{0},", SystemData.BabyJustBornRecordView.BABY_ID);
            sbField.AppendFormat("{0},", SystemData.BabyJustBornRecordView.MOTHER_ID);
            sbField.AppendFormat("{0},", SystemData.BabyJustBornRecordView.MUM_VISIT_NO);
            sbField.AppendFormat("{0},", SystemData.BabyJustBornRecordView.WEIGHT);
            sbField.AppendFormat("{0},", SystemData.BabyJustBornRecordView.SEX);
            sbField.AppendFormat("{0},", SystemData.BabyJustBornRecordView.NAME);
            sbField.AppendFormat("{0}", SystemData.BabyJustBornRecordView.BABY_NO);
            string szCondition = string.Format("1=1");

            szCondition = string.Format("{0} AND {1} = '{2}' AND {3} = '{4}'"
                , szCondition
                , SystemData.BabyJustBornRecordView.MOTHER_ID
                , szPatientID
                , SystemData.BabyJustBornRecordView.MUM_VISIT_NO
                , szVisitNO);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE
                    , sbField.ToString(), SystemData.DataView.BABY_JUST_BORN_RECORD_V, szCondition);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MedQCAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (model == null)
                    model = new BabyJustBornRecord();

                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    if (dataReader.IsDBNull(i))
                        continue;
                    switch (dataReader.GetName(i))
                    {
                        case SystemData.BabyJustBornRecordView.BABY_ID:
                            model.BABY_ID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.BabyJustBornRecordView.MOTHER_ID:
                            model.MOTHER_ID = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.BabyJustBornRecordView.MUM_VISIT_NO:
                            model.MUM_VISIT_NO = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.BabyJustBornRecordView.NAME:
                            model.NAME = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.BabyJustBornRecordView.SEX:
                            model.SEX = dataReader.GetValue(i).ToString();
                            break;
                        case SystemData.BabyJustBornRecordView.WEIGHT:
                            model.WEIGHT = decimal.Parse(dataReader.GetValue(i).ToString());
                            break;
                        default: break;
                    }
                }
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MedQCAccess.CloseConnnection(false); }
        }
    }
}