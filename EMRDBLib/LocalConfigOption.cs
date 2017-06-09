using Heren.Common.Libraries;
using System.Xml;
using System.IO;

namespace EMRDBLib
{
    /// <summary>
    /// 本地文件配置信息
    /// </summary>
    public class LocalConfigOption
    {
        /// <summary>
        /// 是否显示相同病人的ID,住院次和姓名列
        ///【此配置适用于检查问题清单、按科室统计、按检查者统计、按质检问题统计】 
        /// 默认为true
        /// </summary>
        public bool IsShowSameColumn { get; set; }

        private bool szAllowAddOtherQuestion = true;

        /// <summary>
        /// 是否允许给非病历项目添加质控信息
        /// </summary>
        public bool AllowAddOtherQuestion
        {
            get { return szAllowAddOtherQuestion; }
            set { szAllowAddOtherQuestion = value; }
        }

        private string szShowBugListMode = string.Empty;

        /// <summary>
        /// 检查问题清单显示形式
        /// </summary>
        public string ShowBugListMode
        {
            get { return szShowBugListMode; }
            set { szShowBugListMode = value; }
        }
        private bool bIsShowSpecialCheck = false;

        /// <summary>
        /// 是否显示专家质检
        /// </summary>
        public bool IsShowSpecialCheck
        {
            get { return bIsShowSpecialCheck; }
            set { bIsShowSpecialCheck = value; }
        }

        private bool bIsShowPatientIndex = false;

        /// <summary>
        /// 是否显示病案首页
        /// </summary>
        public bool IsShowPatientIndex
        {
            get { return bIsShowPatientIndex; }
            set { bIsShowPatientIndex = value; }
        }

        private bool bIsSearchByID = false;


        private bool bIsShowQCContentRecord = false;

        /// <summary>
        /// 是否显示系统病历内容检查详情
        /// </summary>
        public bool IsShowQCContentRecord
        {
            get { return bIsShowQCContentRecord; }
            set { bIsShowQCContentRecord = value; }
        }


        private bool bIsShowVitalSignsGraph = false;
        /// <summary>
        /// 是否显示体温单
        /// </summary>
        public bool IsShowVitalSignsGraph
        {
            get { return bIsShowVitalSignsGraph; }
            set { bIsShowVitalSignsGraph = value; }
        }
        private bool bIsShowNursingRecord = false;
        /// <summary>
        /// 是否显示护理记录
        /// </summary>
        public bool IsShowNursingRecord
        {
            get { return bIsShowNursingRecord; }
            set { bIsShowNursingRecord = value; }
        }

        private bool bIsShowMedTemplet = false;

        /// <summary>
        /// 是否显示模板管理菜单
        /// </summary>
        public bool IsShowMedTemplet
        {
            get { return bIsShowMedTemplet; }
            set { bIsShowMedTemplet = value; }
        }

        private bool bAllowAddQuestionToParDocType = false;

        /// <summary>
        /// 允许给病历类型的父类型添加质检问题 默认为false
        /// </summary>
        public bool AllowAddQuestionToParDocType
        {
            get { return bAllowAddQuestionToParDocType; }
            set { bAllowAddQuestionToParDocType = value; }
        }

        private int iSearchTimeSpanDays = 0;
        /// <summary>
        /// 左侧搜索面板天数
        /// </summary>
        public int SearchTimeSpanDays
        {
            get { return iSearchTimeSpanDays; }
            set { iSearchTimeSpanDays = value; }
        }

        private int iSearchTimeSpanMonths = 2;
        /// <summary>
        /// 左侧搜索面板月数
        /// </summary>
        public int SearchTimeSpanMonths
        {
            get { return iSearchTimeSpanMonths; }
            set { iSearchTimeSpanMonths = value; }
        }


        private int iSpecialStartTime = 0;
        /// <summary>
        /// 入院出院搜索起始时间提前天数
        /// </summary>
        public int SpecialStartTime
        {
            get { return iSpecialStartTime; }
            set { iSpecialStartTime = value; }
        }

        private int iSpecialEndTime = 0;
        /// <summary>
        /// 入院出院搜索结束时间提前天数
        /// </summary>
        public int SpecialEndTime
        {
            get { return iSpecialEndTime; }
            set { iSpecialEndTime = value; }
        }

        private bool isShowBedMaxMenu = false;

        /// <summary>
        /// 是否显示修改最大床位数
        /// </summary>
        public bool IsShowBedMaxMenu
        {
            get { return isShowBedMaxMenu; }
            set { isShowBedMaxMenu = value; }
        }

        private bool isShowHospitalTimeCheckStatic = false;
        /// <summary>
        /// 是否显示时效检查问题合格率统计,海总开发后使用 默认为false
        /// </summary>
        public bool IsShowHospitalTimeCheckStatic
        {
            get { return isShowHospitalTimeCheckStatic; }
            set { this.isShowHospitalTimeCheckStatic = value; }
        }


        private bool bIsShowDocLock = true;
        /// <summary>
        /// 强制锁定，问题未修改，设置强制锁定后，必须修改问题才能新建文档。
        /// </summary>
        public bool IsShowDocLock
        {
            get { return bIsShowDocLock; }
            set { bIsShowDocLock = value; }
        }
        /// <summary>
        /// 工作量统计界面是否按照姓名查询【新增了质检者ID,之后统计不会被重名者影响，
        /// 但是现在直接换ID统计会造成之前的数据统计错误，
        /// 等历史数据不再需要时，可以换成按照ID统计】,默认false[按姓名统计]，true[按ID]
        /// </summary>
        public bool IsSearchByID
        {
            get { return bIsSearchByID; }
            set { bIsSearchByID = value; }
        }



        private bool m_IsShowVisitID = true;
        /// <summary>
        /// 是否在患者列表床卡中显示就诊次数，默认为ture
        /// </summary>
        public bool IsShowVisitID
        {
            get { return m_IsShowVisitID; }
            set { m_IsShowVisitID = value; }
        }

        /// <summary>
        ///  病案评分统计默认展示是否是精简版，默认为false
        /// </summary>
        public bool IsShowScoreAsSimple
        {
            get { return m_IsShowScoreAsSimple; }
            set { m_IsShowScoreAsSimple = value; }
        }

        private bool m_IsShowScoreAsSimple = false;
        private bool m_TimeCheckRuleConfig = false;
        /// <summary>
        /// 新军卫版本时效规则配置放到质控系统中，true:开启，false:关闭
        /// </summary>
        public bool TimeCheckRuleConfig
        {
            get { return m_TimeCheckRuleConfig; }
            set { m_TimeCheckRuleConfig = value; }
        }

        /// <summary>
        /// 打印和导出Excel按钮默认显示
        /// </summary>
        private bool m_PrintAndExcel = true;
        /// <summary>
        /// 新军卫版本是否显示患者信息打印和导出excel功能，true:显示，false:隐藏
        /// </summary>
        public bool PrintAndExcel
        {
            get { return m_PrintAndExcel; }
            set { m_PrintAndExcel = value; }
        }
        /// <summary>
        /// 右键病人列表显示召回病人菜单项
        /// </summary>
        private bool m_RightClickCallback = false;
        /// <summary>
        /// 右键病人列表显示召回病人菜单项，默认false（不显示）
        /// </summary>
        public bool RightClickCallback
        {
            get { return m_RightClickCallback; }
            set { m_RightClickCallback = value; }
        }

        private bool m_IsCheckPoint = true;
        public bool IsCheckPoint
        {
            get { return m_IsCheckPoint; }
            set { m_IsCheckPoint = value; }
        }

        private string m_DefaultEditor = "0";
        /// <summary>
        /// 编辑器版本0：地方 1：军队 2：和仁
        /// </summary>
        public string DefaultEditor
        {
            get { return m_DefaultEditor; }
            set { m_DefaultEditor = value; }
        }

        private string m_IgnoreDocTypeIDs = string.Empty;
        /// <summary>
        /// 定时分析病历内容缺陷时跳过以下DocTypeID列表
        /// </summary>
        public string IgnoreDocTypeIDs
        {
            get { return m_IgnoreDocTypeIDs; }
            set { m_IgnoreDocTypeIDs = value; }
        }

        private int m_GradingHigh = 90;
        /// <summary>
        /// 评分标准高分
        /// </summary>
        public int GradingHigh
        {
            get { return m_GradingHigh; }
            set { m_GradingHigh = value; }
        }
        private int m_GradingLow = 76;
        /// <summary>
        /// 评分标准低分
        /// </summary>
        public int GradingLow
        {
            get { return m_GradingLow; }
            set { m_GradingLow = value; }
        }
        private int m_VetoHigh = 1;
        /// <summary>
        /// 含有单项否决乙标准
        /// </summary>
        public int VetoHigh
        {
            get { return m_VetoHigh; }
            set { m_VetoHigh = value; }
        }
        private int m_VetoLow = 2;
        /// <summary>
        /// 含有单项否决丙标准
        /// </summary>
        public int VetoLow
        {
            get { return m_VetoLow; }
            set { m_VetoLow = value; }
        }
        public bool IsOpenQcTrack { get; set; }
        /// <summary>
        /// 判断是默认验证方式，还是数据库验证方式 1:默认登录 2:数据库链接登录
        /// </summary>
        public string LoginType { get; set; }
        public bool IsNewTheme { get; set; }
        public bool SinglePatientMode { get; set; }
        public bool IsOpenFinalQC { get; set; }
        public bool IsOpenOperation { get; set; }
        public bool IsShowChat { get; set; }
        public string DBLINK { get; set; }
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HOSPITAL_NAME { get; set; }
        public bool HdpUse { get; set; }
        public bool IsScoreRightShow { get; set; }
        public bool IsDrawingPatientIdentification { get; set; }
        public bool IsOpenHomePage { get; set; }
        public bool IsNewScore { get; set; }
        public bool RecPrintLog { get; set; }
        public bool BAJK_DBConfig { get; set; }


        public LocalConfigOption()
        {
            this.HdpUse = false;
            this.IsDrawingPatientIdentification = false;
            this.IsOpenHomePage = false;
        }
    }
    public partial class SystemParam
    {
        private LocalConfigOption m_LocalConfigOption;

        /// <summary>
        /// 本地配置文件信息
        /// </summary>
        public LocalConfigOption LocalConfigOption
        {
            get
            {
                if (m_LocalConfigOption == null)
                    m_LocalConfigOption = this.GetLocalConfigOption();
                return m_LocalConfigOption;
            }

        }

        private LocalConfigOption GetLocalConfigOption()
        {
            LocalConfigOption option = new LocalConfigOption();
            string szFileName = string.Format(@"{0}\MedQCConfig.xml", GlobalMethods.Misc.GetWorkingPath());
            if (!File.Exists(szFileName))
                return null;
            XmlDocument doc = new XmlDocument();
            doc.Load(szFileName);
            XmlNodeList nodeList = doc.SelectNodes("SystemConfig/key");
            foreach (XmlNode node in nodeList)
            {
                string szName = node.Attributes["name"].Value;
                string szValue = node.Attributes["value"].Value;
                if (szName == "IsShowSpecialCheck")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowSpecialCheck = true;
                    }
                    else
                    {
                        option.IsShowSpecialCheck = false;
                    }
                }
                if (szName == "IsOpenHomePage")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsOpenHomePage = true;
                    }
                    else
                    {
                        option.IsOpenHomePage = false;
                    }

                }
                if (szName == "IsNewScore")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsNewScore = true;
                    }
                    else
                    {
                        option.IsNewScore = false;
                    }
                }
                if (szName == "IsScoreRightShow")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsScoreRightShow = true;
                    }
                    else
                    {
                        option.IsScoreRightShow = false;
                    }
                }
                if (szName == "IsDrawingPatientIdentification")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsDrawingPatientIdentification = true;
                    }
                    else
                    {
                        option.IsDrawingPatientIdentification = false;
                    }
                }
                if (szName == "IsOpenOperation")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsOpenOperation = true;
                    }
                    else
                    {
                        option.IsOpenOperation = false;
                    }
                }
                else if (szName == "IsShowVitalSignsGraph")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowVitalSignsGraph = true;
                    }
                    else
                    {
                        option.IsShowVitalSignsGraph = false;
                    }
                }
                else if (szName == "IsShowNursingRecord")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowNursingRecord = true;
                    }
                    else
                    {
                        option.IsShowNursingRecord = false;
                    }
                }
                else if (szName == "IsShowMedTemplet")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowMedTemplet = true;
                    }
                    else
                    {
                        option.IsShowMedTemplet = false;
                    }
                }
                else if (szName == "IsShowPatientIndex")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowPatientIndex = true;
                    }
                    else
                    {
                        option.IsShowPatientIndex = false;
                    }
                }
                else if (szName == "SearchTimeSpanDays")
                {
                    int iNo = 0;
                    if (!string.IsNullOrEmpty(szValue))
                    {
                        if (int.TryParse(szValue, out iNo))
                        {
                            option.SearchTimeSpanDays = -iNo;
                        }
                    }
                }
                else if (szName == "SearchTimeSpanMonths")
                {
                    int iNo = 0;
                    if (!string.IsNullOrEmpty(szValue))
                    {
                        if (int.TryParse(szValue, out iNo))
                        {
                            option.SearchTimeSpanMonths = -iNo;
                        }
                    }
                }
                else if (szName == "SpecialStartTime")
                {
                    int iNo = 0;
                    if (!string.IsNullOrEmpty(szValue))
                    {
                        if (int.TryParse(szValue, out iNo))
                        {
                            option.SpecialStartTime = -iNo;
                        }
                    }
                }
                else if (szName == "SpecialEndTime")
                {
                    int iNo = 0;
                    if (!string.IsNullOrEmpty(szValue))
                    {
                        if (int.TryParse(szValue, out iNo))
                        {
                            option.SpecialEndTime = -iNo;
                        }
                    }
                }
                else if (szName == "ShowBugListMode")
                {
                    option.ShowBugListMode = szValue.Trim();
                }
                else if (szName == "AllowAddQuestionToParDocType")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.AllowAddQuestionToParDocType = true;
                    }
                    else
                    {
                        option.AllowAddQuestionToParDocType = false;
                    }
                }
                else if (szName == "AllowAddOtherQuestion")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.AllowAddOtherQuestion = true;
                    }
                    else
                    {
                        option.AllowAddOtherQuestion = false;
                    }
                }
                else if (szName == "IsShowBedMaxMenu")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowBedMaxMenu = true;
                    }
                    else
                    {
                        option.IsShowBedMaxMenu = false;
                    }
                }

                else if (szName == "IsShowHospitalTimeCheckStatic")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowHospitalTimeCheckStatic = true;
                    }
                    else
                    {
                        option.IsShowHospitalTimeCheckStatic = false;
                    }
                }
                else if (szName == "IsShowSameColumn")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowSameColumn = true;
                    }
                    else
                    {
                        option.IsShowSameColumn = false;
                    }
                }

                else if (szName == "IsShowQCContentRecord")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowQCContentRecord = true;
                    }
                    else
                    {
                        option.IsShowQCContentRecord = false;
                    }
                }
                else if (szName == "IsShowDocLock")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowDocLock = true;
                    }
                    else
                    {
                        option.IsShowDocLock = false;
                    }
                }
                else if (szName == "IsSearchByID")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsSearchByID = true;
                    }
                    else
                    {
                        option.IsSearchByID = false;
                    }
                }
                else if (szName == "IsShowVisitID")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowVisitID = true;
                    }
                    else
                    {
                        option.IsShowVisitID = false;
                    }
                }
                else if (szName == "IsShowScoreAsSimple")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsShowScoreAsSimple = true;
                    }
                    else
                    {
                        option.IsShowScoreAsSimple = false;
                    }
                }
                else if (szName == "TimeCheckRuleConfig")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.TimeCheckRuleConfig = true;
                    }
                    else
                    {
                        option.TimeCheckRuleConfig = false;
                    }
                }
                else if (szName == "PrintAndExcel")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.PrintAndExcel = true;
                    }
                    else
                    {
                        option.PrintAndExcel = false;
                    }
                }
                else if (szName == "RecPrintLog")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.RecPrintLog = true;
                    }
                    else
                    {
                        option.RecPrintLog = false;
                    }
                }
                else if (szName == "DefaultEditor")
                {
                    option.DefaultEditor = szValue;
                }
                else if (szName == "IgnoreDocTypeIDs")
                {
                    option.IgnoreDocTypeIDs = szValue.Trim();
                }
                else if (szName == "GradingStandard")
                {
                    option.GradingHigh = int.Parse(szValue.Trim().Split('|')[0]);
                    option.GradingLow = int.Parse(szValue.Trim().Split('|')[1]);
                }
                else if (szName == "RightClickCallback")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.RightClickCallback = true;
                    }
                    else
                    {
                        option.RightClickCallback = false;
                    }
                }
                else if (szName == "IsCheckPoint")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsCheckPoint = true;
                    }
                    else
                    {
                        option.IsCheckPoint = false;
                    }
                }
                else if (szName == "VetoStandard")
                {
                    option.VetoHigh = int.Parse(szValue.Trim().Split('|')[0]);
                    option.VetoLow = int.Parse(szValue.Trim().Split('|')[1]);
                }
                else if (szName == "IsOpenQcTrack")
                {
                    option.IsOpenQcTrack = bool.Parse(szValue);
                }
                else if (szName == "LoginType")
                {
                    option.LoginType = szValue;
                }
                else if (szName == "IsNewTheme")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                    {
                        option.IsNewTheme = true;
                    }
                    else
                    {
                        option.IsNewTheme = false;
                    }
                }
                else if (szName == "SinglePatientMode")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                        option.SinglePatientMode = true;
                    else
                        option.SinglePatientMode = false;
                }
                else if (szName == "IsOpenFinalQC")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                        option.IsOpenFinalQC = true;
                    else
                        option.IsOpenFinalQC = false;
                }
                else if (szName == "IsShowChat")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                        option.IsShowChat = true;
                    else
                        option.IsShowChat = false;
                }
                else if (szName.ToUpper() == "DBLINK")
                {
                    option.DBLINK = szValue;
                }
                else if (szName == "HOSPITAL_NAME")
                {
                    option.HOSPITAL_NAME = szValue;
                }
                else if (szName == "HdpUse")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                        option.HdpUse = true;
                    else
                        option.HdpUse = false;
                }
                else if (szName == "BAJK_DBConfig")
                {
                    if (szValue.Trim().ToUpper() == "TRUE")
                        option.BAJK_DBConfig = true;
                    else
                        option.BAJK_DBConfig = false;
                }
                
            }
            return option;
        }

    }
}
