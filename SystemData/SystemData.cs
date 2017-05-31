// ***********************************************************
// 封装客户端解决方案内共享的常量数据集合.
// Creator:YangMingkun  Date:2009-6-22
// Copyright:supconhealth
// ***********************************************************
using MedDocSys.Common;

namespace MedDocSys.DataLayer
{
    /// <summary>
    /// MedDocSys Application Data
    /// </summary>
    public struct SystemData
    {
        /// <summary>
        /// 返回值常量
        /// </summary>
        public struct ReturnValue
        {
            /// <summary>
            /// 返回值=0
            /// </summary>
            public const short OK = 0;
            /// <summary>
            /// 返回值=1
            /// </summary>
            public const short FAILED = 1;
            /// <summary>
            /// 返回值=2
            /// </summary>
            public const short CANCEL = 2;
            /// <summary>
            /// 返回值=3
            /// </summary>
            public const short EXCEPTION = 3;
        }

        /// <summary>
        /// 就诊类型常量
        /// </summary>
        public struct VisitType
        {
            /// <summary>
            /// 住院(IP)
            /// </summary>
            public const string IP = "IP";
            /// <summary>
            /// 门诊(OP)
            /// </summary>
            public const string OP = "OP";
        }

        /// <summary>
        /// 用户类型常量
        /// </summary>
        public struct UserType
        {
            /// <summary>
            /// 门诊医生
            /// </summary>
            public const string OP_DOCTOR = "DOC";
            /// <summary>
            /// 住院医生
            /// </summary>
            public const string IP_DOCTOR = "DOC";
            /// <summary>
            /// 护士
            /// </summary>
            public const string NURSE = "NUR";
            /// <summary>
            /// 其他
            /// </summary>
            public const string OTHER = "OTHER";
        }

        /// <summary>
        /// 共享水平常量
        /// </summary>
        public struct ShareLevel
        {
            /// <summary>
            /// 全院共享"H"
            /// </summary>
            public const string HOSPITAL = "H";
            /// <summary>
            /// 科室共享"D"
            /// </summary>
            public const string DEPART = "D";
            /// <summary>
            /// 个人私有"P"
            /// </summary>
            public const string PERSONAL = "P";
            /// <summary>
            /// 全院共享
            /// </summary>
            public const string HOSPITAL_CN = "全院共享";
            /// <summary>
            /// 科室共享
            /// </summary>
            public const string DEPART_CN = "科室共享";
            /// <summary>
            /// 个人私有
            /// </summary>
            public const string PERSONAL_CN = "个人使用";
            /// <summary>
            /// 转换英文缩写与中文名称对应的共享级别
            /// </summary>
            /// <param name="szShareLevel">共享级别</param>
            /// <returns>共享级别</returns>
            public static string TransShareLevel(string szShareLevel)
            {
                szShareLevel = szShareLevel.Trim().ToUpper();
                if (szShareLevel == HOSPITAL)
                    return HOSPITAL_CN;
                if (szShareLevel == DEPART)
                    return DEPART_CN;
                if (szShareLevel == PERSONAL)
                    return PERSONAL_CN;
                if (szShareLevel == HOSPITAL_CN)
                    return HOSPITAL;
                if (szShareLevel == DEPART_CN)
                    return DEPART;
                if (szShareLevel == PERSONAL_CN)
                    return PERSONAL;
                return szShareLevel;
            }
        }

        /// <summary>
        /// 文件扩展名常量
        /// </summary>
        public struct FileExt
        {
            /// <summary>
            /// 医疗文档扩展名"smdf"
            /// </summary>
            public const string MED_DOCUMENT = "smdf";
            /// <summary>
            /// 文档模板文件扩展名"smdt"
            /// </summary>
            public const string DOC_TEMPLET = "smdt";
        }

        /// <summary>
        /// 文档路径常量
        /// </summary>
        public struct FilePath
        {
            /// <summary>
            /// 模板缓存索引文件全路径.
            /// 路径格式：{0}\Templets\index.xml
            /// </summary>
            public const string TEMPLET_CACHE_INDEX_PATH = @"{0}\Templets\index.xml";
            /// <summary>
            /// 用户自定义模板缓存文件全路径.
            /// 路径格式：根目录\Templets\User\模板ID.模板扩展名
            /// </summary>
            public const string USER_TEMPLET_CACHE_PATH = @"{0}\Templets\User\{1}.{2}";
            /// <summary>
            /// 系统缺省模板缓存文件全路径.
            /// 路径格式：根目录\Templets\Default\文档类型ID.模板扩展名
            /// </summary>
            public const string SYSTEM_TEMPLET_CACHE_PATH = @"{0}\Templets\Default\{1}.{2}";
            /// <summary>
            /// 新建文档界面右下角背景图
            /// </summary>
            public const string DOC_TAG_IMAGE_PATH = @"{0}\Skins\DocTag.png";
        }

        /// <summary>
        /// 文档机密级别常量
        /// </summary>
        public struct DocSecretLevel
        {
            /// <summary>
            /// 普通
            /// </summary>
            public const string NORMAL = "N";
            /// <summary>
            /// 秘密
            /// </summary>
            public const string SECRET = "R";
            /// <summary>
            /// 机密
            /// </summary>
            public const string VERY_SECRET = "V";
            /// <summary>
            /// 绝密
            /// </summary>
            public const string TOP_SECRET = "T";
        }

        /// <summary>
        /// 时间格式常量
        /// </summary>
        public struct TimeFormat
        {
            /// <summary>
            /// yyyy-MM-ddTHH:mm:ss.000000
            /// </summary>
            public const string CDA_TIME_NODE = "yyyy-MM-ddTHH:mm:ss.000000";
        }

        /// <summary>
        /// 配置文件常量
        /// </summary>
        public struct ConfigKey
        {
            /// <summary>
            /// 启动参数中的组间分隔符
            /// </summary>
            public const string ARGS_GROUP_SPLIT = "ArgsParser.GroupSplit";
            /// <summary>
            /// 启动参数中的组内字段分隔符
            /// </summary>
            public const string ARGS_FIELD_SPLIT = "ArgsParser.FieldSplit";
            /// <summary>
            /// 启动参数字符串内的被转义字符
            /// </summary>
            public const string ARGS_ESCAPED_CHAR = "ArgsParser.EscapedChar";
            /// <summary>
            /// 启动参数字符串内的转义符
            /// </summary>
            public const string ARGS_ESCAPE_CHAR = "ArgsParser.EscapeChar";

            /// <summary>
            /// 系统皮肤文件位置
            /// </summary>
            public const string MAIN_FORM_SKINFILE = "MainForm.SkinFile";
            /// <summary>
            /// 是否显示常用字符工具条
            /// </summary>
            public const string SHOW_CHAR_STRIP = "MainForm.ShowCharStrip";
            /// <summary>
            /// 个人模板功能是否可用
            /// </summary>
            public const string PERSONAL_TEMPLET_ENABLED = "MainForm.PersonalTempletEnabled";
            /// <summary>
            /// 是否允许合并文档可编辑
            /// </summary>
            public const string COMBIN_EDIT_ENABLED = "MainForm.CombinEditEnabled";

            /// <summary>
            /// 文档修订权限等级(只允许创建者修改,只允许创建者和主任医师修改,允许所有人修改)
            /// </summary>
            public const string DOC_EDIT_RIGHT = "MainForm.DocEditRight";
            /// <summary>
            /// 文档版本浏览功能是否可用
            /// </summary>
            public const string DOC_VERSION_SCAN_ENABLED = "MainForm.DocVersionScanEnabled";
            /// <summary>
            /// 文档修订痕迹保留功能是否可用
            /// </summary>
            public const string DOC_EDIT_TRACE_ENABLED = "MainForm.DocEditTraceEnabled";

            /// <summary>
            /// 自动绑定的日期格式
            /// </summary>
            public const string BIND_DATE_FORMAT = "SystemTime.BindDateFormat";
            /// <summary>
            /// 自动绑定的带时间的日期格式
            /// </summary>
            public const string BIND_TIME_FORMAT = "SystemTime.BindTimeFormat";

            /// <summary>
            /// 模板管理系统是否可用
            /// </summary>
            public const string TEMPLET_SYSTEM_ENABLED = "MainForm.TempletSystemEnabled";
            /// <summary>
            /// 模板是否需要审核
            /// </summary>
            public const string CHECK_TEMPLET = "MainForm.CheckTempletEnabled";
            /// <summary>
            /// 是否允许修改模板页眉
            /// </summary>
            public const string MODIFY_TEMPLET_HEADER = "MedTemplet.ModifyTempletHeader";

            /// <summary>
            /// 系统起始页是否默认显示可停靠的窗口
            /// </summary>
            public const string STARTPAGE_DOCK_FORM = "StartPageForm.DisplayDockForm";
            /// <summary>
            /// 系统起始页是否默认显示新视图
            /// </summary>
            public const string STARTPAGE_NEW_VIEW = "StartPageForm.DisplayNewView";
            /// <summary>
            /// 系统起始页中文档类型列表的宽度
            /// </summary>
            public const string DOC_TYPE_LIST_WIDTH = "StartPageForm.SplitterDistance";
            /// <summary>
            /// 系统起始页中文档类型列表是否以流式布局
            /// </summary>
            public const string DOC_TYPE_LAYOUT_FLOW = "StartPageForm.DocTypeButtonFlowLayout";

            /// <summary>
            /// 编辑器分割栏窗口高度
            /// </summary>
            public const string EDITOR_SPLIT_HEIGHT = "MedEditor.EditorSplitHeight";
            /// <summary>
            /// 编辑器是否允许多病人拷贝
            /// </summary>
            public const string MULTI_PAT_COPY = "MedEditor.MultiPatCopy";
            /// <summary>
            /// 病历中结构化元素标记颜色
            /// </summary>
            public const string ELEMENT_TAG_COLOR = "MedEditor.ElementTagColor";
            /// <summary>
            /// 病历中默认字体名称
            /// </summary>
            public const string DEFAULT_FONT_NAME = "MedEditor.DefaultFontName";
            /// <summary>
            /// 病历中默认字体大小
            /// </summary>
            public const string DEFAULT_FONT_SIZE = "MedEditor.DefaultFontSize";
            /// <summary>
            /// 病历中默认行距
            /// </summary>
            public const string DEFAULT_LINE_SPACE = "MedEditor.DefaultLineSpace";

            /// <summary>
            /// 是否开启自动缓存
            /// </summary>
            public const string AUTO_CACHE = "AutoCache.Enabled";
            /// <summary>
            /// 自动缓存间隔
            /// </summary>
            public const string AUTO_CACHE_INTERVAL = "AutoCache.Interval";

            /// <summary>
            /// 功能工具条位置X
            /// </summary>
            public const string FUNC_TOOL_STRIP_LEFT = "FuncToolStrip.Left";
            /// <summary>
            /// 功能工具条位置Y
            /// </summary>
            public const string FUNC_TOOL_STRIP_TOP = "FuncToolStrip.Top";
            /// <summary>
            /// 编辑工具条位置X
            /// </summary>
            public const string EDIT_TOOL_STRIP_LEFT = "EditToolStrip.Left";
            /// <summary>
            /// 编辑工具条位置Y
            /// </summary>
            public const string EDIT_TOOL_STRIP_TOP = "EditToolStrip.Top";

            /// <summary>
            /// 任务提醒系统任务列表刷新后是否弹出气泡提示
            /// </summary>
            public const string TASK_POPUP_TIP = "MedTask.ShowPopupTip";
            /// <summary>
            /// 任务提醒系统任务列表刷新后是否闪动托盘图标
            /// </summary>
            public const string TASK_ICON_BLINK = "MedTask.TaskIconBlink";
            /// <summary>
            /// 任务提醒系统任务列表刷新时间间隔
            /// </summary>
            public const string TASK_REFRESH_INTERVAL = "MedTask.TaskRefreshInterval";
            /// <summary>
            /// 任务提醒系统查询入院日期时间限
            /// </summary>
            public const string TASK_ADM_START_TIMESPAN = "MedTask.TaskAdmStartTimeSpan";

            /// <summary>
            /// 小模板导入窗口是否始终保持在顶端
            /// </summary>
            public const string SMALL_TEMPLET_FORM_TOPMOST = "SmallTempletForm.TopMost";
            /// <summary>
            /// 小模板导入窗口是否在导入后选项设置
            /// </summary>
            public const string SMALL_TEMPLET_FORM_OPTIONS = "SmallTempletForm.OptionAfterImport";
            /// <summary>
            /// 小模板导入窗口小模板列表中鼠标单击节点后是否打开模板
            /// </summary>
            public const string SMALL_TEMPLET_OPEN_BYCLICK = "SmallTempletForm.OpenByClick";
            /// <summary>
            /// 小模板导入窗口小模板列表中是否是鼠标双击节点就导入到病历
            /// </summary>
            public const string SMALL_TEMPLET_IMPORT_BYDBCLICK = "SmallTempletForm.ImportByDbClick";

            /// <summary>
            /// 是否自动弹出剪切板收集窗口
            /// </summary>
            public const string AUTO_POPUP_CLIPBOARD_FORM = "ClipboardForm.AutoPopup";

            /// <summary>
            /// 保存病历到XDB时schema文件EmrDoc的uri地址
            /// </summary>
            public const string XDB_SCHEMA_URI = "XmlDocHelper.EmrDocSchemaUri";

            /// <summary>
            /// 保存病历到XDB时标准schema文件的uri地址
            /// </summary>
            public const string XML_SCHEMA_URI = "XmlDocHelper.XMLSchemaUri";

            /// <summary>
            /// 登录对话框缺省登录用户
            /// </summary>
            public const string DEFAULT_LOGIN_USERID = "MTS.LoginForm.DefaultUserID";

            /// <summary>
            /// 所有模板修改权限
            /// </summary>
            public const string CAN_MODIFY_ALL_TEMPLETS = "MainForm.CanModifyAllTemplets";
            /// <summary>
            /// 模板检查权限
            /// </summary>
            public const string CAN_CHECK_TEMPLET = "MainForm.CanCheckTemplet";
            /// <summary>
            /// 最近选择的科室代码
            /// </summary>
            public const string DEFAULT_USER_DEPT = "TempletListForm.DefaultUserDept";

            /// <summary>
            /// 模板审核统计页面查询起始时间
            /// </summary>
            public const string CHECK_QUERY_BEGIN_TIME = "TempletStatForm.CheckQueryBeginTime";
            /// <summary>
            /// 模板审核统计页面查询结束时间
            /// </summary>
            public const string CHECK_QUERY_END_TIME = "TempletStatForm.CheckQueryEndTime";
            /// <summary>
            /// 模板审核统计页面缺省检索科室
            /// </summary>
            public const string CHECK_DEPT_CODE = "TempletStatForm.CheckDeptCode";
            /// <summary>
            /// 模板审核统计页面是否显示未审核的模板
            /// </summary>
            public const string CONTAINS_UNCHECK = "TempletStatForm.ContainsUncheck";
            /// <summary>
            /// 模板审核统计页面是否显示已审核通过的模板
            /// </summary>
            public const string CONTAINS_PASSED = "TempletStatForm.ContainsPassed";
            /// <summary>
            /// 模板审核统计页面是否显示审核有缺陷的模板
            /// </summary>
            public const string CONTAINS_HASBUGS = "TempletStatForm.ContainsHasBugs";
            /// <summary>
            /// 模板审核统计页面是否显示已经医生校正的模板
            /// </summary>
            public const string CONTAINS_CORRECTED = "TempletStatForm.ContainsCorrected";
            /// <summary>
            /// 基本输入框元素ID
            /// </summary>
            public const string INPUT_ELEMENT_ID = "TempletDocForm.InputElementID";
        }

        /// <summary>
        /// 与文档缓存有关的常量
        /// </summary>
        public struct DocCache
        {
            /// <summary>
            /// 缓存文档路径.0-系统运行目录,1-用户id,2-缓存文档id
            /// </summary>
            public static string CACHE_PATH = @"{0}\Documents\{1}\{2}.cache";
            /// <summary>
            /// 缓存索引文件路径.0-系统运行目录
            /// </summary>
            public static string INDEX_PATH = @"{0}\Documents\CacheDetails.xml";
            /// <summary>
            /// 缓存没有页眉的模板文件路径。0-系统运行目录
            /// </summary>
            public static string DOCTYPELIST_PATH = @"{0}\DocTypeList.xml";
            /// <summary>
            /// xml格式病历缓存路径 0-系统运行目录 
            /// </summary>
            public static string XMLDOC_PATH = @"{0}\Documents\Xml";
        }

        /// <summary>
        /// 文档内容质控规则相关常量
        /// </summary>
        public struct QCRule
        {
            /// <summary>
            /// ENTRY类型之DOCUMENT
            /// </summary>
            public const string ENTRY_TYPE_DOCUMENT = "DOCUMENT";
            /// <summary>
            /// ENTRY类型之REFLECTION
            /// </summary>
            public const string ENTRY_TYPE_REFLECTION = "REFLECTION";

            /// <summary>
            /// ENTRY值类型之int
            /// </summary>
            public const string ENTRY_VALUE_TYPE_INT = "int";
            /// <summary>
            /// ENTRY值类型之bool
            /// </summary>
            public const string ENTRY_VALUE_TYPE_BOOL = "bool";
            /// <summary>
            /// ENTRY值类型之datetime
            /// </summary>
            public const string ENTRY_VALUE_TYPE_DATE = "datetime";
            /// <summary>
            /// ENTRY值类型之string
            /// </summary>
            public const string ENTRY_VALUE_TYPE_TEXT = "string";

            /// <summary>
            /// ENTRY实际值与期望值之间的运算符(等于)
            /// </summary>
            public const string ENTRY_OPERATOR_EQUAL = "等于";
            /// <summary>
            /// ENTRY实际值与期望值之间的运算符(小于)
            /// </summary>
            public const string ENTRY_OPERATOR_LESS = "小于";
            /// <summary>
            /// ENTRY实际值与期望值之间的运算符(大于)
            /// </summary>
            public const string ENTRY_OPERATOR_MORE = "大于";
            /// <summary>
            /// ENTRY实际值与期望值之间的运算符(小于等于)
            /// </summary>
            public const string ENTRY_OPERATOR_NOMORE = "小于等于"; //不大于
            /// <summary>
            /// ENTRY实际值与期望值之间的运算符(大于等于)
            /// </summary>
            public const string ENTRY_OPERATOR_NOLESS = "大于等于"; //不小于
            /// <summary>
            /// ENTRY实际值与期望值之间的运算符(不等于)
            /// </summary>
            public const string ENTRY_OPERATOR_NOEQUAL = "不等于";
            /// <summary>
            /// ENTRY实际值与期望值之间的运算符(包含)
            /// </summary>
            public const string ENTRY_OPERATOR_CONTAINS = "包含";
            /// <summary>
            /// ENTRY实际值与期望值之间的运算符(不包含)
            /// </summary>
            public const string ENTRY_OPERATOR_NOCONTAINS = "不包含";

            /// <summary>
            /// 复合规则运算符(并且)
            /// </summary>
            public const string RULE_OPERATOR_AND = "并且";
            /// <summary>
            /// 复合规则运算符(或者)
            /// </summary>
            public const string RULE_OPERATOR_OR = "或者";

            #region"数据显示值与实际值转换"
            /// <summary>
            /// 获取ENTRY类型之中文名称(用于界面显示)
            /// </summary>
            /// <param name="szEntryType">ENTRY类型英文名称</param>
            /// <returns>ENTRY类型中文名称</returns>
            public static string GetEntryTypeZH(string szEntryType)
            {
                if (GlobalMethods.AppMisc.IsEmptyString(szEntryType))
                    return "从文档提取";
                if (szEntryType.Trim() == QCRule.ENTRY_TYPE_REFLECTION)
                    return "从系统映射";
                else
                    return "从文档提取";
            }

            /// <summary>
            /// 获取ENTRY类型之英文名称(用于数据存储)
            /// </summary>
            /// <param name="szEntryType">ENTRY类型中文名称</param>
            /// <returns>ENTRY类型英文名称</returns>
            public static string GetEntryTypeEN(string szEntryType)
            {
                if (GlobalMethods.AppMisc.IsEmptyString(szEntryType))
                    return QCRule.ENTRY_TYPE_DOCUMENT;
                if (szEntryType.Trim() == "从系统映射")
                    return QCRule.ENTRY_TYPE_REFLECTION;
                else
                    return QCRule.ENTRY_TYPE_DOCUMENT;
            }

            /// <summary>
            /// 获取ENTRY值数据类型之中文名称(用于界面显示)
            /// </summary>
            /// <param name="szValueType">ENTRY值数据类型英文名称</param>
            /// <returns>ENTRY值数据类型之中文名称</returns>
            public static string GetValueTypeZH(string szValueType)
            {
                if (GlobalMethods.AppMisc.IsEmptyString(szValueType))
                    return "字符串";
                szValueType = szValueType.Trim().ToLower();
                if (szValueType.Trim() == QCRule.ENTRY_VALUE_TYPE_INT)
                    return "数值";
                else if (szValueType.Trim() == QCRule.ENTRY_VALUE_TYPE_BOOL)
                    return "布尔值";
                else if (szValueType.Trim() == QCRule.ENTRY_VALUE_TYPE_DATE)
                    return "日期时间";
                else
                    return "字符串";
            }

            /// <summary>
            /// 获取ENTRY值数据类型之英文名称(用于数据存储)
            /// </summary>
            /// <param name="szValueType">ENTRY值数据类型中文名称</param>
            /// <returns>ENTRY值数据类型之中文名称</returns>
            public static string GetValueTypeEN(string szValueType)
            {
                if (GlobalMethods.AppMisc.IsEmptyString(szValueType))
                    return QCRule.ENTRY_VALUE_TYPE_TEXT;
                szValueType = szValueType.Trim().ToLower();
                if (szValueType.Trim() == "数值")
                    return QCRule.ENTRY_VALUE_TYPE_INT;
                else if (szValueType.Trim() == "布尔值")
                    return QCRule.ENTRY_VALUE_TYPE_BOOL;
                else if (szValueType.Trim() == "日期时间")
                    return QCRule.ENTRY_VALUE_TYPE_DATE;
                else
                    return QCRule.ENTRY_VALUE_TYPE_TEXT;
            }
            #endregion
        }

        /// <summary>
        /// 文档修改权限常量
        /// </summary>
        public struct EditRights
        {
            /// <summary>
            /// 仅文档创建者可以修改(0)
            /// </summary>
            public const int Creator = 0;
            /// <summary>
            /// 文档创建者和主任医师可以修改(1)
            /// </summary>
            public const int Chief = 1;
            /// <summary>
            /// 文档创建者、主任医师以及同级医生都可以修改(2)
            /// </summary>
            public const int Normal = 2;
        }

        /// <summary>
        /// 病历文档系统命令列表
        /// </summary>
        public struct WinCommand
        {
            /// <summary>
            /// 病历保存成功消息
            /// </summary>
            public const string DOCUMENT_SAVED = "DOCUMENT_SAVED";
            /// <summary>
            /// 病历更新成功消息
            /// </summary>
            public const string DOCUMENT_UPDATED = "DOCUMENT_UPDATED";
            /// <summary>
            /// 病历删除成功消息
            /// </summary>
            public const string DOCUMENT_CANCELED = "DOCUMENT_CANCELED";
            /// <summary>
            /// 小模板请求导入前消息
            /// </summary>
            public const string SMALL_TEMPLET_IMPORTING = "SMALL_TEMPLET_IMPORTING";
            /// <summary>
            /// 小模板请求导入后消息
            /// </summary>
            public const string SMALL_TEMPLET_IMPORTED = "SMALL_TEMPLET_IMPORTED";
        }

        /// <summary>
        /// 小模板导入选项
        /// </summary>
        public struct SmallTempletImportOption
        {
            /// <summary>
            /// 导入后不做任何操作
            /// </summary>
            public const string NONE = "NONE";
            /// <summary>
            /// 导入后关闭窗口
            /// </summary>
            public const string CLOSE_FORM = "CLOSE_FORM";
            /// <summary>
            /// 导入后切换到病历窗口
            /// </summary>
            public const string SWITCH_TO_DOCUMENT = "SWITCH_TO_DOCUMENT";
        }

        /// <summary>
        /// 配置字典表中配置的结构化元素名称
        /// </summary>
        public struct ElementName
        {
            /// <summary>
            /// 身高元素名称
            /// </summary>
            public const string BODY_HEIGHT = "BODY_HEIGHT";
            /// <summary>
            /// 体重元素名称
            /// </summary>
            public const string BODY_WEIGHT = "BODY_WEIGHT";
            /// <summary>
            /// BMI元素名称
            /// </summary>
            public const string BODY_BMI = "BODY_BMI";
            /// <summary>
            /// 入院时间元素名称
            /// </summary>
            public const string ADMISSION_DATE = "ADMISSION_DATE";
            /// <summary>
            /// 出院时间元素名称
            /// </summary>
            public const string DISCHARGE_DATE = "DISCHARGE_DATE";
            /// <summary>
            /// 在院天数元素名称
            /// </summary>
            public const string IN_HOSPITAL_DAYS = "IN_HOSPITAL_DAYS";
        }

        /// <summary>
        /// 其他一些混杂的常量
        /// </summary>
        public struct MiscConst
        {
            /// <summary>
            /// 系统应用程序名称
            /// </summary>
            public const string APPLICATION_NAME = "病历文档系统";
            /// <summary>
            /// 弹出消息对话框默认标题
            /// </summary>
            public const string MESSAGE_DEFAULT_TITLE = "病历文档系统";
            /// <summary>
            /// 用于分页的空白文档ID
            /// </summary>
            public const string BLANK_DOCUMENT_ID = "BLANK";
            /// <summary>
            /// 病历文档打开时保存于本地的根目录
            /// </summary>
            public const string DOCUMENT_TEMP_DIR = "Documents";
        }
    }
}
