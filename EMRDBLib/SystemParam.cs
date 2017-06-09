// ***********************************************************
// 数据库访问层系统运行参数管理类,用于调用层来修改运行参数.
// Creator:YangMingkun  Date:2010-11-18
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.IO;
using EMRDBLib.DbAccess;
using Heren.Common.Libraries;
using Heren.Common.Libraries.DbAccess;
using Heren.Common.Libraries.Ftp;
using System.Text;
using System.Xml;
using EMRDBLib.Entity;
using System.Collections;

namespace EMRDBLib
{
    public partial class SystemParam
    {
        private static SystemParam m_Instance = null;

        /// <summary>
        /// 获取SystemParam对象实例
        /// </summary>
        public static SystemParam Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new SystemParam();
                return m_Instance;
            }
        }

        private SystemParam()
        {
        }

        /// <summary>
        /// 获取或设置默认时间
        /// </summary>
        public DateTime DefaultTime
        {
            get { return DateTime.Parse("1900-1-1"); }
        }
        private string m_szWorkPath = string.Empty;

        /// <summary>
        /// 获取或设置程序工作路径
        /// </summary>
        public string WorkPath
        {
            set { this.m_szWorkPath = value; }
            get
            {
                if (GlobalMethods.Misc.IsEmptyString(this.m_szWorkPath))
                    this.m_szWorkPath = GlobalMethods.Misc.GetWorkingPath();
                return this.m_szWorkPath;
            }
        }


        /// <summary>
        /// 获取指定的文档信息组织医疗文档FTP路径
        /// </summary>
        /// <param name="docInfo">文档信息</param>
        /// <param name="extension">文档扩展名</param>
        /// <returns>文档FTP路径</returns>
        public string GetFtpDocPath(MedDocInfo docInfo, string extension)
        {
            //链接病人根目录
            StringBuilder ftpPath = new StringBuilder();
            ftpPath.Append("/MEDDOC");

            if (docInfo == null || docInfo.PATIENT_ID == null)
                return ftpPath.ToString();

            string szPatientID = docInfo.PATIENT_ID.PadLeft(10, '0');
            for (int index = 0; index < 10; index += 2)
            {
                ftpPath.Append("/");
                ftpPath.Append(szPatientID.Substring(index, 2));
            }

            //链接就诊目录
            ftpPath.Append("/");
            ftpPath.Append(docInfo.VISIT_TYPE);
            if (docInfo.VISIT_TYPE == SystemData.VisitType.OP)
            {
                ftpPath.Append("_");
                ftpPath.Append(docInfo.VISIT_TIME.ToString("yyyyMMddHHmmss"));
            }
            ftpPath.Append("_");
            ftpPath.Append(docInfo.VISIT_ID);
            ftpPath.Append("/");
            if (docInfo.EMR_TYPE == "HEREN")
            {
                ftpPath.Append(string.Format("{0}.{1}", docInfo.DOC_SETID, extension));
            }
            else
                ftpPath.Append(string.Format("{0}.{1}", docInfo.DOC_ID, extension));
            return ftpPath.ToString();
        }


        private QChatArgs m_QChatArgs = null;

        /// <summary>
        /// 沟通平台内部参数
        /// </summary>
        public QChatArgs QChatArgs
        {
            get
            {
                if (m_QChatArgs == null)
                    m_QChatArgs = new QChatArgs();
                return this.m_QChatArgs;
            }
            set { this.m_QChatArgs = value; }
        }


        private UserInfo m_userInfo = null;

        /// <summary>
        /// 获取或设置用户信息
        /// </summary>
        public UserInfo UserInfo
        {
            get { return this.m_userInfo; }
            set { this.m_userInfo = value; }
        }

        private List<DeptInfo> m_UserAdminDepts = null;

        /// <summary>
        /// 当前用户所管辖的科室
        /// </summary>
        public List<DeptInfo> UserAdminDepts
        {
            get { return m_UserAdminDepts; }
            set { m_UserAdminDepts = value; }
        }

        private EMRDBLib.PatVisitInfo m_patVisitLog = null;

        /// <summary>
        /// 获取或设置病人及其就诊相关信息
        /// </summary>
        public EMRDBLib.PatVisitInfo PatVisitInfo
        {
            get { return this.m_patVisitLog; }
            set
            {
                if (this.m_patVisitLog != value)
                    this.m_patVisitLog = value;
            }
        }

        private List<EMRDBLib.PatVisitInfo> m_lstPatVisitLog = null;

        /// <summary>
        /// 获取或设置病人就诊信息列表
        /// </summary>
        public List<EMRDBLib.PatVisitInfo> PatVisitLogList
        {
            get { return this.m_lstPatVisitLog; }
            set
            {
                if (this.m_lstPatVisitLog != value)
                    this.m_lstPatVisitLog = value;
            }
        }

        private Hashtable m_htPatVisitLogTable = null;

        /// <summary>
        /// 获取或设置病人就诊信息哈希表
        /// </summary>
        public Hashtable PatVisitLogTable
        {
            get
            {
                if (this.m_htPatVisitLogTable == null)
                    this.m_htPatVisitLogTable = new Hashtable();
                return this.m_htPatVisitLogTable;
            }
            set
            {
                if (this.m_htPatVisitLogTable != value)
                    this.m_htPatVisitLogTable = value;
            }
        }

        private static DateTime m_dtBeginTime = DateTime.MinValue;

        /// <summary>
        /// 查询开始时间
        /// </summary>
        public static DateTime BeginTime
        {
            get { return m_dtBeginTime; }
            set { m_dtBeginTime = value; }
        }

        private static DateTime m_dtEndTime = DateTime.MinValue;

        /// <summary>
        /// 查询结束时间
        /// </summary>
        public static DateTime EndTime
        {
            get { return m_dtEndTime; }
            set { m_dtEndTime = value; }
        }

        private UserRight m_userRight = null;

        /// <summary>
        /// 获取当前用户的权限信息(该对象不会为空)
        /// </summary>
        public UserRight UserRight
        {
            get
            {
                if (this.m_userInfo == null)
                    return new UserRight();

                //用户权限为空时或用户ID已改变时,重新获取
                if (this.m_userRight == null || this.m_userRight.UserID != this.m_userInfo.ID)
                {
                    UserRightBase userRight = null;
                    RightAccess.Instance.GetUserRight(this.m_userInfo.ID, UserRightType.MedDoc,
                        ref userRight);
                    this.m_userRight = userRight as UserRight;
                }
                if (this.m_userRight == null)
                    return new UserRight();
                return this.m_userRight;
            }
        }

        private QCUserRight m_QCUserRight = null;

        /// <summary>
        /// 获取当前质控用户的权限信息(该对象不会为空)
        /// </summary>
        public QCUserRight QCUserRight
        {
            get
            {
                if (this.m_userInfo == null)
                    return new QCUserRight();

                //用户权限为空时或用户ID已改变时,重新获取
                if (this.m_QCUserRight == null || this.m_QCUserRight.UserID != this.m_userInfo.ID)
                {
                    UserRightBase userRight = null;
                    RightAccess.Instance.GetUserRight(this.m_userInfo.ID, UserRightType.MedQC,
                        ref userRight);
                    this.m_QCUserRight = userRight as QCUserRight;
                }
                if (this.m_QCUserRight == null)
                    return new QCUserRight();
                return this.m_QCUserRight;
            }
        }
        private Hashtable m_htDMLB = null;
        public Hashtable HtDMLB
        {
            get {
                if (this.m_htDMLB == null)
                {
                    this.m_htDMLB = new Hashtable();
                    m_htDMLB.Add("性别", "1");
                    m_htDMLB.Add("婚姻", "7");
                    m_htDMLB.Add("职业", "3");
                    m_htDMLB.Add("国籍", "4");
                    m_htDMLB.Add("籍贯/住址/行政区", "6");
                    m_htDMLB.Add("民族", "8");
                    m_htDMLB.Add("关系", "2");
                    m_htDMLB.Add("病案质量", "21");
                    m_htDMLB.Add("入院情况", "20");
                    m_htDMLB.Add("入出符合标志", "");
                    m_htDMLB.Add("门出符合标志", "");
                    m_htDMLB.Add("是否尸检", "");
                    //m_htDMLB.Add("疾病代码库", "");
                    m_htDMLB.Add("肿瘤M编码", "");
                    m_htDMLB.Add("损伤E编码", "");
                    m_htDMLB.Add("科室代码", "");
                    m_htDMLB.Add("ABO血型", "30");
                    m_htDMLB.Add("RH血型", "RH血型");
                    m_htDMLB.Add("入院方式", "23");
                    m_htDMLB.Add("出院方式", "");
                    m_htDMLB.Add("诊断类别", "");
                    m_htDMLB.Add("转归情况/治疗结果", "28");
                }
                return m_htDMLB;
            }
        }

        private Hashtable m_htBaseCodeDict = null;
        public Hashtable HtBaseCodeDict
        {
            get
            {
                if (this.m_htBaseCodeDict == null)
                {
                    this.m_htBaseCodeDict = new Hashtable();
                    m_htBaseCodeDict.Add("性别", "SEX_DICT");
                    m_htBaseCodeDict.Add("婚姻", "MARITAL_STATUS_DICT");
                    m_htBaseCodeDict.Add("职业", "OCCUPATION_DICT");
                    m_htBaseCodeDict.Add("国籍", "COUNTRY_DICT");
                    m_htBaseCodeDict.Add("籍贯/住址/行政区", "AREA_DICT");
                    m_htBaseCodeDict.Add("民族", "NATION_DICT");
                    m_htBaseCodeDict.Add("关系", "RELATIONSHIP_DICT");
                    m_htBaseCodeDict.Add("病案质量", "MR_QUALITY_DICT");
                    m_htBaseCodeDict.Add("入院情况", "PAT_ADM_CONDITION_DICT");
                    m_htBaseCodeDict.Add("入出符合标志", "");
                    m_htBaseCodeDict.Add("ABO血型", "BLOOD_ABO_TYPE_DICT");
                    m_htBaseCodeDict.Add("RH血型", "BLOOD_RH_TYPE_DICT");
                    m_htBaseCodeDict.Add("入院方式", "PATIENT_CLASS_DICT");
                    m_htBaseCodeDict.Add("出院方式", "DISCHARGE_DISPOSITION_DICT");
                    m_htBaseCodeDict.Add("诊断类别", "DIAGNOSIS_TYPE_DICT");
                    m_htBaseCodeDict.Add("转归情况/治疗结果", "TREATING_RESULT_DICT");
                }
                return m_htBaseCodeDict;
            }
        }

        /// <summary>
        /// 获取质控系统配置文件全路径
        /// </summary>
        public string ConfigFile
        {
            get
            {
                return string.Format(@"{0}\MedQCSys.xml"
                    , GlobalMethods.Misc.GetWorkingPath());
            }
        }

        /// <summary>
        /// 获取指定的文档信息组织医疗文档FTP路径
        /// </summary>
        /// <returns>文档FTP路径</returns>
        public string GetQCFtpDocPath(EMRDBLib.MedicalQcMsg questionInfo, string szFileExt)
        {
            //链接病人根目录
            StringBuilder sbDocPath = new StringBuilder();
            sbDocPath.Append("/MEDDOC/质控病历");
            if (string.IsNullOrEmpty(questionInfo.ISSUED_BY))
                return sbDocPath.ToString();
            sbDocPath.AppendFormat("/{0}", questionInfo.ISSUED_BY);
            if (string.IsNullOrEmpty(questionInfo.PATIENT_ID))
                return sbDocPath.ToString();
            string szPatientID = questionInfo.PATIENT_ID.PadLeft(10, '0');
            for (int index = 0; index < 10; index += 2)
            {
                sbDocPath.Append("/");
                sbDocPath.Append(szPatientID.Substring(index, 2));
            }
            sbDocPath.Append("/");
            sbDocPath.Append(string.Format("{0}_{1}.{2}", questionInfo.TOPIC_ID,
                questionInfo.ISSUED_DATE_TIME.ToString("yyyyMMddHHmmss"), szFileExt));
            return sbDocPath.ToString();
        }

        /// <summary>
        /// 当前用户是否有审核权限 
        /// </summary>
        public bool CurrentUserHasQCCheckRight
        {
            get
            {
                bool bRight = false;
                if (!QCUserRight.ManageAllQC.Value)
                {
                    if (QCUserRight.ManageAdminDeptsQC.Value)
                    {
                        //判断是否用户管辖科室包括病人科室
                        if (UserAdminDepts != null && UserAdminDepts.Count > 0)
                        {
                            foreach (DeptInfo deptInfo in UserAdminDepts)
                            {
                                if (deptInfo.DEPT_CODE == PatVisitInfo.DEPT_CODE)
                                {
                                    bRight = true;
                                    break;
                                }
                            }
                        }
                    }
                    else if (QCUserRight.ManageDeptQC.Value)
                    {
                        //判断是否用户科室与病人科室一致
                        if (UserInfo.DeptCode == PatVisitInfo.DEPT_CODE)
                        {
                            bRight = true;
                        }
                    }
                }
                else
                {
                    bRight = true;
                }
                return bRight;
            }
        }


    }
}
