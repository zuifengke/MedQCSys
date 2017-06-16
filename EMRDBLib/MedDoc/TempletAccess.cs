// ***********************************************************
// 数据库访问层与用户相关数据的访问类.
// Creator:YangAiping  Date:2014-05-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Heren.Common.Libraries;
using System.Data.OleDb;
using Heren.Common.Libraries.DbAccess;
namespace EMRDBLib.DbAccess
{
    public class TempletAccess : DBAccessBase
    {
        private static TempletAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static TempletAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new TempletAccess();
                return m_Instance;
            }
        }
        /// <summary>
        /// 根据文档模板ID获取文档模板信息
        /// </summary>
        /// <param name="szTempletID">文档模板ID</param>
        /// <param name="templetInfo">文档模板信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetUserTempletInfo(string szTempletID, ref TempletInfo templetInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szTempletID))
            {
                LogManager.Instance.WriteLog("TempletAccess.GetUserTempletInfo", new string[] { "szTempletID" }, new object[] { szTempletID }, "参数不能为空!");
                return SystemData.ReturnValue.PARAM_ERROR;
            }
            DbParameter[] param = new DbParameter[1] { new DbParameter(SystemData.DocTempletTable.TEMPLET_ID, szTempletID) };
            string szCondition = string.Format("{0}={1}", SystemData.DocTempletTable.TEMPLET_ID, base.ParaHolder(SystemData.DocTempletTable.TEMPLET_ID));
            List<TempletInfo> lstTempletInfos = null;
            short shRet = this.GetUserTempletInfosInternal(szCondition, string.Empty, ref lstTempletInfos, param);
            if (shRet != SystemData.ReturnValue.OK)
                return shRet;
            if (lstTempletInfos == null || lstTempletInfos.Count <= 0)
                return SystemData.ReturnValue.RES_NO_FOUND;
            templetInfo = lstTempletInfos[0];
            return SystemData.ReturnValue.OK;
        }
        /// <summary>
        /// 获取指定查询条件下的用户保存的病历大模板列表
        /// </summary>
        /// <param name="szCondition">查询条件</param>
        /// <param name="szOrderSQL">排序字段</param>
        /// <param name="lstTempletInfos">病历大模板信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        private short GetUserTempletInfosInternal(string szCondition, string szOrderSQL, ref List<TempletInfo> lstTempletInfos, DbParameter[] param)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20}"
                , SystemData.DocTempletTable.TEMPLET_ID, SystemData.DocTempletTable.DOCTYPE_ID
                , SystemData.DocTempletTable.TEMPLET_NAME, SystemData.DocTempletTable.SHARE_LEVEL
                , SystemData.DocTempletTable.DEPT_CODE, SystemData.DocTempletTable.DEPT_NAME
                , SystemData.DocTempletTable.CREATOR_ID, SystemData.DocTempletTable.CREATOR_NAME
                , SystemData.DocTempletTable.CREATE_TIME, SystemData.DocTempletTable.MODIFY_TIME
                , SystemData.DocTempletTable.IS_VALID, SystemData.DocTempletTable.PARENT_ID
                , SystemData.DocTempletTable.IS_FOLDER, SystemData.DocTempletTable.CHECK_STATUS
                , SystemData.DocTempletTable.CHECKER_ID, SystemData.DocTempletTable.CHECKER_NAME
                , SystemData.DocTempletTable.CHECK_TIME, SystemData.DocTempletTable.CHECK_MESSAGE
                , SystemData.DocTempletTable.SUPER_CHECK_ID, SystemData.DocTempletTable.SUPER_CHECK_NAME
                , SystemData.DocTempletTable.SUPER_CHECK_TIME);

            string szSQL = string.Empty;
            if (GlobalMethods.Misc.IsEmptyString(szCondition))
                szSQL = string.Format(SystemData.SQL.SELECT_FROM, szField, SystemData.DataTable.DOC_TEMPLET);
            else
                szSQL = string.Format(SystemData.SQL.SELECT_WHERE, szField, SystemData.DataTable.DOC_TEMPLET, szCondition);

            if (!GlobalMethods.Misc.IsEmptyString(szOrderSQL))
                szSQL = string.Concat(szSQL, " ", szOrderSQL);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.MeddocAccess.ExecuteReader(szSQL, CommandType.Text, ref param);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (lstTempletInfos == null)
                    lstTempletInfos = new List<TempletInfo>();
                do
                {
                    TempletInfo templetInfo = new TempletInfo();
                    templetInfo.TempletID = dataReader.GetString(0);
                    templetInfo.DocTypeID = dataReader.GetString(1);
                    templetInfo.TempletName = dataReader.GetString(2);
                    templetInfo.ShareLevel = dataReader.GetString(3);
                    templetInfo.DeptCode = dataReader.GetString(4);
                    templetInfo.DeptName = dataReader.GetString(5);
                    templetInfo.CreatorID = dataReader.GetString(6);
                    templetInfo.CreatorName = dataReader.GetString(7);
                    templetInfo.CreateTime = dataReader.GetDateTime(8);
                    if (!dataReader.IsDBNull(9))
                        templetInfo.ModifyTime = dataReader.GetDateTime(9);
                    if (!dataReader.IsDBNull(10))
                        templetInfo.IsValid = dataReader.GetValue(10).ToString().Equals("1");
                    if (!dataReader.IsDBNull(11))
                        templetInfo.ParentID = dataReader.GetString(11);
                    if (!dataReader.IsDBNull(12))
                        templetInfo.IsFolder = dataReader.GetValue(12).ToString().Equals("1");
                    if (!dataReader.IsDBNull(13))
                        templetInfo.CheckStatus = TempletInfo.GetCheckStatus(dataReader.GetString(13));
                    if (!dataReader.IsDBNull(14))
                        templetInfo.CheckerID = dataReader.GetString(14);
                    if (!dataReader.IsDBNull(15))
                        templetInfo.CheckerName = dataReader.GetString(15);
                    if (!dataReader.IsDBNull(16))
                        templetInfo.CheckTime = dataReader.GetDateTime(16);
                    if (!dataReader.IsDBNull(17))
                        templetInfo.CheckMessage = dataReader.GetString(17);
                    if (!dataReader.IsDBNull(18))
                        templetInfo.SuperCheckerID = dataReader.GetString(18);
                    if (!dataReader.IsDBNull(19))
                        templetInfo.SuperCheckerName = dataReader.GetString(19);
                    if (!dataReader.IsDBNull(20))
                        templetInfo.SuperCheckTime = dataReader.GetDateTime(20);
                    lstTempletInfos.Add(templetInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("TempletAccess.GetUserTempletInfosInternal", new string[] { "szSQL" }, new object[] { szSQL }, "SQL语句执行失败!", ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.MeddocAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 查询指定审核状态的模板列表
        /// </summary>
        /// <param name="szCheckStatus">审核状态</param>
        /// <param name="lstTempletInfos">文档模板信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetUserTempletInfos(string szCheckStatus, ref List<TempletInfo> lstTempletInfos)
        {
            if (base.MeddocAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;
            DbParameter[] param = new DbParameter[1] { new DbParameter(SystemData.DocTempletTable.CHECK_STATUS, szCheckStatus) };
            string szCondition = string.Format("{0}={1} AND {2}=1", SystemData.DocTempletTable.CHECK_STATUS, base.ParaHolder(SystemData.DocTempletTable.CHECK_STATUS)
                , SystemData.DocTempletTable.IS_VALID);

            string szOrderSQL = string.Format("ORDER BY {0},{1} ASC", SystemData.DocTempletTable.DEPT_NAME, SystemData.DocTempletTable.DOCTYPE_ID);
            return this.GetUserTempletInfosInternal(szCondition, szOrderSQL, ref lstTempletInfos, param);
        }
    }
}
