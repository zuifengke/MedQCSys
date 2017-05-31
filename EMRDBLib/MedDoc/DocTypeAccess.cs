using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace EMRDBLib.DbAccess
{
    public class DocTypeAccess : DBAccessBase
    {
        private static DocTypeAccess m_Instance = null;

        /// <summary>
        /// 获取系统运行上下文实例
        /// </summary>
        public static DocTypeAccess Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new DocTypeAccess();
                return m_Instance;
            }
        }

        /// <summary>
        /// 根据指定文档类型代码获取文档类型信息
        /// </summary>
        /// <param name="szDocTypeID">文档类型代码</param>
        /// <param name="docTypeInfo">文档类型信息</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDocTypeInfo(string szDocTypeID, ref DocTypeInfo docTypeInfo)
        {
            if (GlobalMethods.Misc.IsEmptyString(szDocTypeID))
            {
                return SystemData.ReturnValue.PARAM_ERROR;
            }

            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            szDocTypeID = szDocTypeID.Trim();
            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}"
                , SystemData.DocTypeTable.DOCTYPE_ID, SystemData.DocTypeTable.DOCTYPE_NAME, SystemData.DocTypeTable.HOSTTYPE_ID
                , SystemData.DocTypeTable.IS_REPEATED, SystemData.DocTypeTable.DOC_RIGHT, SystemData.DocTypeTable.APPLY_ENV
                , SystemData.DocTypeTable.SIGN_FLAG, SystemData.DocTypeTable.MODIFY_TIME, SystemData.DocTypeTable.IS_VALID
                , SystemData.DocTypeTable.CAN_CREATE, SystemData.DocTypeTable.IS_TOTAL_PAGE, SystemData.DocTypeTable.IS_STRUCT
                , SystemData.DocTypeTable.IS_END_EMPTY, SystemData.DocTypeTable.NEED_COMBIN, SystemData.DocTypeTable.ORDER_VALUE
                , SystemData.DocTypeTable.AUTO_MAKE_TITLE);
            string szCondition = string.Format("{0}='{1}'", SystemData.DocTypeTable.DOCTYPE_ID, szDocTypeID);
            string szSQL = string.Format(SystemData.SQL.SELECT_WHERE_ORDER_ASC, szField, SystemData.DataTable.DOC_TYPE, szCondition, SystemData.DocTypeTable.ORDER_VALUE);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                {
                    return SystemData.ReturnValue.RES_NO_FOUND;
                }
                if (docTypeInfo == null)
                    docTypeInfo = new DocTypeInfo();
                docTypeInfo.DocTypeID = dataReader.GetString(0);
                docTypeInfo.DocTypeName = dataReader.GetString(1);
                if (!dataReader.IsDBNull(2))
                    docTypeInfo.HostTypeID = dataReader.GetString(2);
                docTypeInfo.IsRepeated = dataReader.GetValue(3).ToString().Equals("1");
                docTypeInfo.DocRight = dataReader.GetString(4);
                docTypeInfo.ApplyEvn = dataReader.GetString(5);
                if (!dataReader.IsDBNull(6))
                    docTypeInfo.SignFlag = dataReader.GetString(6).Trim();
                docTypeInfo.ModifyTime = dataReader.GetDateTime(7);
                if (!dataReader.IsDBNull(8))
                    docTypeInfo.IsValid = dataReader.GetValue(8).ToString().Equals("1");
                if (!dataReader.IsDBNull(9))
                    docTypeInfo.CanCreate = dataReader.GetValue(9).ToString().Equals("1");
                if (!dataReader.IsDBNull(10))
                    docTypeInfo.IsTotalPage = dataReader.GetValue(10).ToString().Equals("1");
                if (!dataReader.IsDBNull(11))
                    docTypeInfo.IsStruct = dataReader.GetValue(11).ToString().Equals("1");
                if (!dataReader.IsDBNull(12))
                    docTypeInfo.IsEndEmpty = dataReader.GetValue(12).ToString().Equals("1");
                if (!dataReader.IsDBNull(13))
                    docTypeInfo.NeedCombin = dataReader.GetValue(13).ToString().Equals("1");
                if (!dataReader.IsDBNull(14))
                    docTypeInfo.OrderValue = int.Parse(dataReader.GetValue(14).ToString());
                if (!dataReader.IsDBNull(15))
                    docTypeInfo.AutoMakeTitle = dataReader.GetValue(15).ToString().Equals("1");
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DocTypeAccess.GetDocTypeInfo", new string[] { "szSQL" }
                    , new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }

        /// <summary>
        /// 获取所有文档类型信息列表
        /// </summary>
        /// <param name="lstDocTypeInfos">文档类型信息列表</param>
        /// <returns>SystemData.ReturnValue</returns>
        public short GetDocTypeInfos(ref List< DocTypeInfo> lstDocTypeInfos)
        {
            if (base.DataAccess == null)
                return SystemData.ReturnValue.PARAM_ERROR;

            string szField = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15}"
                , SystemData.DocTypeTable.DOCTYPE_ID, SystemData.DocTypeTable.DOCTYPE_NAME, SystemData.DocTypeTable.HOSTTYPE_ID
                , SystemData.DocTypeTable.IS_REPEATED, SystemData.DocTypeTable.DOC_RIGHT, SystemData.DocTypeTable.APPLY_ENV
                , SystemData.DocTypeTable.SIGN_FLAG, SystemData.DocTypeTable.MODIFY_TIME, SystemData.DocTypeTable.IS_VALID
                , SystemData.DocTypeTable.CAN_CREATE, SystemData.DocTypeTable.IS_TOTAL_PAGE, SystemData.DocTypeTable.IS_STRUCT
                , SystemData.DocTypeTable.IS_END_EMPTY, SystemData.DocTypeTable.NEED_COMBIN, SystemData.DocTypeTable.ORDER_VALUE
                , SystemData.DocTypeTable.AUTO_MAKE_TITLE);

            string szSQL = string.Format(SystemData.SQL.SELECT_ORDER_ASC, szField, SystemData.DataTable.DOC_TYPE, SystemData.DocTypeTable.ORDER_VALUE);

            IDataReader dataReader = null;
            try
            {
                dataReader = base.DataAccess.ExecuteReader(szSQL, CommandType.Text);
                if (dataReader == null || dataReader.IsClosed || !dataReader.Read())
                    return SystemData.ReturnValue.RES_NO_FOUND;

                if (lstDocTypeInfos == null)
                    lstDocTypeInfos = new List< DocTypeInfo>();
                do
                {
                     DocTypeInfo docTypeInfo = new  DocTypeInfo();
                    docTypeInfo.DocTypeID = dataReader.GetString(0);
                    docTypeInfo.DocTypeName = dataReader.GetString(1);
                    if (!dataReader.IsDBNull(2))
                        docTypeInfo.HostTypeID = dataReader.GetString(2);
                    docTypeInfo.IsRepeated = dataReader.GetValue(3).ToString().Equals("1");
                    docTypeInfo.DocRight = dataReader.GetString(4);
                    docTypeInfo.ApplyEvn = dataReader.GetString(5);
                    if (!dataReader.IsDBNull(6))
                        docTypeInfo.SignFlag = dataReader.GetString(6).Trim();
                    docTypeInfo.ModifyTime = dataReader.GetDateTime(7);
                    if (!dataReader.IsDBNull(8))
                        docTypeInfo.IsValid = dataReader.GetValue(8).ToString().Equals("1");
                    if (!dataReader.IsDBNull(9))
                        docTypeInfo.CanCreate = dataReader.GetValue(9).ToString().Equals("1");
                    if (!dataReader.IsDBNull(10))
                        docTypeInfo.IsTotalPage = dataReader.GetValue(10).ToString().Equals("1");
                    if (!dataReader.IsDBNull(11))
                        docTypeInfo.IsStruct = dataReader.GetValue(11).ToString().Equals("1");
                    if (!dataReader.IsDBNull(12))
                        docTypeInfo.IsEndEmpty = dataReader.GetValue(12).ToString().Equals("1");
                    if (!dataReader.IsDBNull(13))
                        docTypeInfo.NeedCombin = dataReader.GetValue(13).ToString().Equals("1");
                    if (!dataReader.IsDBNull(14))
                        docTypeInfo.OrderValue = int.Parse(dataReader.GetValue(14).ToString());
                    if (!dataReader.IsDBNull(15))
                        docTypeInfo.AutoMakeTitle = dataReader.GetValue(15).ToString().Equals("1");
                    lstDocTypeInfos.Add(docTypeInfo);
                } while (dataReader.Read());
                return SystemData.ReturnValue.OK;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("DocTypeAccess.GetDocTypeInfos", new string[] { "szSQL" }, new object[] { szSQL }, ex);
                return SystemData.ReturnValue.EXCEPTION;
            }
            finally { base.DataAccess.CloseConnnection(false); }
        }

    }
}
