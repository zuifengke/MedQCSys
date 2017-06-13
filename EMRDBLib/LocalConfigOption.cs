using Heren.Common.Libraries;
using System.Xml;
using System.IO;
using System.Collections.Generic;

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
        private bool m_IsShowSameColumn = true;
        public bool IsShowSameColumn
        {
            get
            {
                return this.m_IsShowSameColumn;
            }
            set
            {
                this.m_IsShowSameColumn = value;
            }
        }

        private bool szAllowAddOtherQuestion = true;

        /// <summary>
        /// 是否允许给非病历项目添加质控信息
        /// </summary>
        public bool AllowAddOtherQuestion
        {
            get { return szAllowAddOtherQuestion; }
            set { szAllowAddOtherQuestion = value; }
        }
        private string m_HospitalLogo = string.Empty;
        /// <summary>
        /// 医院logo
        /// </summary>
        public string HospitalLogo
        {
            get { return this.m_HospitalLogo; }
            set {
                this.m_HospitalLogo = value;
            }
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
        private bool bIsShowSpecialCheck = true;

        /// <summary>
        /// 是否显示专家质检
        /// </summary>
        public bool IsShowSpecialCheck
        {
            get { return bIsShowSpecialCheck; }
            set { bIsShowSpecialCheck = value; }
        }

        private bool bIsShowPatientIndex = true;

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

        private bool m_IsShowScoreAsSimple = true;
        /// <summary>
        ///  病案评分统计默认展示是否是精简版，默认为false
        /// </summary>
        public bool IsShowScoreAsSimple
        {
            get { return m_IsShowScoreAsSimple; }
            set { m_IsShowScoreAsSimple = value; }
        }
        private bool m_TimeCheckRuleConfig = true;
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

        private string m_DefaultEditor = "2";
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
        /// 定时分析病历内容缺陷时跳过以下DocTypeID列表,拼接sql用，注意格式加上引号和逗号
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
        private bool m_IsOpenQcTrack = false;
        /// <summary>
        /// 开启质控追踪功能 暂时默认为false
        /// </summary>
        public bool IsOpenQcTrack
        {
            get { return this.m_IsOpenQcTrack; }
            set { this.m_IsOpenQcTrack = value; }
        }
        private string m_LoginType = "1";
        /// <summary>
        /// 判断是默认验证方式，还是数据库验证方式 1:默认登录 2:数据库链接登录
        /// </summary>
        public string LoginType
        {
            get { return this.m_LoginType; }
            set { this.m_LoginType = value; }
        }
        private bool m_IsNewTheme = true;
        /// <summary>
        /// 新版界面风格 true:启用 false:不启用
        /// </summary>
        public bool IsNewTheme
        {
            get { return this.m_IsNewTheme; }
            set { this.m_IsNewTheme = value; }
        }
        private bool m_IsOpenFinalQC = false;
        /// <summary>
        /// 是否开启终末质控 该功能以评分表格形式展现，参考掌握科技功能 默认为false
        /// </summary>
        public bool IsOpenFinalQC
        {
            get
            {
                return this.m_IsOpenFinalQC;
            }
            set { this.m_IsOpenFinalQC = value; }
        }
        private bool m_IsOpenOperation = false;
        /// <summary>
        /// 是否开启手术信息 该功能用于查看单患者手术页签 默认为false
        /// </summary>
        public bool IsOpenOperation
        {
            get { return this.m_IsOpenOperation; }
            set { this.m_IsOpenOperation = value; }
        }
        private bool m_IsShowChat = false;
        /// <summary>
        /// 是否启用消息工具 true:启用 false:不启用 默认为不启用
        /// </summary>
        public bool IsShowChat { get; set; }

        private string m_DBLINK = "LINK_EMR";
        /// <summary>
        /// 质控库通过DBLINK连接到HIS库
        /// </summary>
        public string DBLINK { get; set; }

        private string m_HOSPITAL_NAME = "演示版医院";
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HOSPITAL_NAME
        {
            get { return this.m_HOSPITAL_NAME; }
            set { this.m_HOSPITAL_NAME = value; }
        }
        private bool m_IsScoreRightShow = false;
        /// <summary>
        /// 评分界面默认右侧显示
        /// </summary>
        public bool IsScoreRightShow
        {
            get { return this.m_IsScoreRightShow; }
            set { this.m_IsScoreRightShow = value; }
        }
        private bool m_IsDrawingPatientIdentification = true;
        public bool IsDrawingPatientIdentification
        {
            get { return this.m_IsDrawingPatientIdentification; }
            set { this.m_IsDrawingPatientIdentification = value; }
        }
        private bool m_IsOpenHomePage = false;
        /// <summary>
        /// 开启起始页，默认为false
        /// </summary>
        public bool IsOpenHomePage
        {
            get
            { return this.m_IsOpenHomePage; }
            set
            {
                this.m_IsOpenHomePage = value;
            }
        }
        private bool m_IsNewScore = false;
        /// <summary>
        /// 是否开启终末评分新界面 默认为false
        /// </summary>
        public bool IsNewScore
        {
            get
            {
                return this.m_IsNewScore;
            }
            set { this.m_IsNewScore = value; }
        }
        private bool m_RecPrintLog = false;
        /// <summary>
        /// 省人民复印登记 默认为false
        /// </summary>
        public bool RecPrintLog
        {
            get
            {
                return this.m_RecPrintLog;
            }
            set { this.m_RecPrintLog = value; }
        }

        public LocalConfigOption()
        {
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

            //根据医院名称开启默认开关
            List<HdpParameter> lstHdpParameter = null;
            short shRet = DbAccess.HdpParameterAccess.Instance.GetHdpParameters(null, SystemData.ConfigKey.SYSTEM_OPTION, SystemData.ConfigKey.HOSPITAL_NAME, ref lstHdpParameter);
            if (lstHdpParameter != null && lstHdpParameter.Count > 0)
            {
                option.HOSPITAL_NAME = lstHdpParameter[0].CONFIG_VALUE;
            }
            if (option.HOSPITAL_NAME.IndexOf("省人民") >= 0)
            {
                option.RecPrintLog = true;
                option.IsScoreRightShow = true;
                option.IsOpenOperation = true;
            }
            else if (option.HOSPITAL_NAME.IndexOf("浙医健杭州医院") >= 0)
            {
                option.HospitalLogo =string.Format("{0}/HospitalLogo/{1}",GlobalMethods.Misc.GetWorkingPath(), "ZYJHZYY_SysIcon.ico");
                option.IsShowPatientIndex = false;
            }
            else if (option.HOSPITAL_NAME.IndexOf("陆军") >= 0)
            {
                option.DefaultEditor = "1";
            }
            else if (option.HOSPITAL_NAME.IndexOf("胸科") >= 0)
            {
                option.IgnoreDocTypeIDs = "'34763-3','34130'";
            }

#if DEBUG //调试时系统开发设置
            option.IsOpenHomePage = true;
            option.IsOpenFinalQC = true;
            option.IsOpenOperation = true;
            option.IsNewScore = false;
            option.IsShowPatientIndex = true;
            option.IsShowVitalSignsGraph = true;
            option.DefaultEditor = "2";
            option.RecPrintLog = true;
#endif
            return option;
        }

    }
}
