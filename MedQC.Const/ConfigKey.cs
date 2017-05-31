using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    public partial struct SystemData
    {
        /// <summary>
        /// 配置文件常量
        /// </summary>
        public struct ConfigKey
        {
            /// <summary>
            /// 默认登录产品名称
            /// </summary>
            public const string DEFAULT_LOGIN_PRODUCT = "DEFAULT_LOGIN_PRODUCT";
            /// <summary>
            /// 配置字典表中病历可选功能配置组【审签配置相关】
            /// </summary>
            public const string AUDIT_OPTION = "AUDIT_OPTION";
            /// <summary>
            /// 配置字典表中病历可选功能配置组【各种格式配置相关】
            /// </summary>
            public const string STYLE_OPTION = "STYLE_OPTION";
            /// <summary>
            /// 配置字典表中病历可选功能配置组【病历痕迹配置相关】
            /// </summary>
            public const string TRACE_OPTION = "TRACE_OPTION";
            /// <summary>
            /// 配置字典表中质控可选功能配置组【质控系统选项】
            /// </summary>
            public const string QCSYS_OPTION = "QCSYS_OPTION";
            /// <summary>
            /// 登录对话框缺省登录用户
            /// </summary>
            public const string DEFAULT_LOGIN_USERID = "LoginForm.DefaultUserID";

            /// <summary>
            /// 患者列表窗口缺省检索类型
            /// </summary>
            public const string DEFAULT_SEARCH_TYPE = "PatientList.SearchType";
            /// <summary>
            /// 患者列表窗口缺省科室代码
            /// </summary>
            public const string DEFAULT_DEPT_CODE = "PatientList.DeptCode";
            /// 患者列表窗口按科室检索入院时间段起始值
            /// </summary>
            public const string DEPT_DEFAULT_ADMISSION_BEGIN = "PatientList.AdmissionTimeBegin";
            /// <summary>
            /// 患者列表窗口按科室检索入院时间段截止值
            /// </summary>
            public const string DEPT_DEFAULT_ADMISSION_END = "PatientList.AdmissionTimeEnd";

            /// <summary>
            /// 患者列表窗口缺省病人ID
            /// </summary>
            public const string DEFAULT_PATIENT_ID = "PatientList.PatientID";

            /// <summary>
            /// 新格式病历窗口病历是否合并显示
            /// </summary>
            public const string DOC_COMBIN_DISPLAY = "MedDocumentForm.DisplayByCombin";

            /// <summary>
            /// 主程序是否显示工具条
            /// </summary>
            public const string SHOW_TOOL_STRIP = "MainForm.ShowToolStrip";

            /// <summary>
            /// 主程序是否显示状态条
            /// </summary>
            public const string SHOW_STATUS_STRIP = "MainForm.ShowStatusStrip";

            /// <summary>
            /// 文档窗口是否是以嵌入到主窗口的方式显示
            /// </summary>
            public const string DOCUMENT_FORM_EMBED = "MainForm.DocumentFormEmbed";

            /// <summary>
            /// 是否在同一个窗口中显示多个病人的病历记录
            /// </summary>
            public const string SHOW_MANY_PATIENT_DOCLIST = "MainForm.ShowPatsDocList";

            /// <summary>
            /// 是否限定患者列表检索方式，如果是配置的值是true则默认使用病人ID检索方式。
            /// </summary>
            public const string RESTRICTSEARCHTYPE = "RestrictSearchType.Enabled";
            /// <summary>
            /// 是否有允许通过adt_log表查询危重患者列表
            /// </summary>
            public const string SERIOUSPATLIST_BY_ADTLOG = "SeriousPatListByAdtLog.Enabled";
            /// <summary>
            /// 是否以只读状态打开病历
            /// </summary>
            public const string DOCUMENT_READONLY = "Document.ReadOnly";
            /// <summary>
            /// 是否允许用户删除或修改非本人添加的反馈信息
            /// </summary>
            public const string MODIFY_OR_DELETE_QUESTION = "ModifyOrDeleteQuestion.Enabled";
            /// <summary>
            /// 科室质控查看统计是否显示除本人以外的检查者姓名
            /// </summary>
            public const string STAT_SHOW_CHECKER_NAME = "StatShowCheckerName.Enabled";
            /// <summary>
            /// 配置版本更新FTP
            /// </summary>
            public const string UPGRADE_FTP = "UPGRADE_FTP";
            /// <summary>
            /// 当前版本号
            /// </summary>
            public const string CURRENT_VERSION = "Current.Version";
            /// <summary>
            /// 有消息变化时是否自动弹出消息框配置项
            /// </summary>
            public const string TASK_AUTO_POPOP_MESSAGE = "MedTask.TaskAutoPopupMessage";
            /// <summary>
            /// 任务提醒系统任务列表刷新时间间隔
            /// </summary>
            public const string TASK_REFRESH_INTERVAL = "MedTask.TaskRefreshInterval";
            /// <summary>
            /// 任务提醒系统任务列表刷新后是否闪动托盘图标
            /// </summary>
            public const string TASK_ICON_BLINK = "MedTask.TaskIconBlink";
            /// <summary>
            /// 任务提醒系统任务列表刷新后是否弹出消息提示
            /// </summary>
            public const string TASK_POPUP_TIP = "MedTask.ShowPopupTip";

            /// <summary>
            /// EMR数据库类型
            /// </summary>
            public const string EMR_DB_TYPE = "EmrDbType";
            /// <summary>
            /// EMR数据库驱动类型
            /// </summary>
            public const string EMR_PROVIDER = "EmrDbProvider";
            /// <summary>
            /// EMR数据库连接串
            /// </summary>
            public const string EMR_CONN_STRING = "EmrDbConnString";
            /// <summary>
            /// EMR数据库连接串加密key
            /// </summary>
            public const string CONFIG_ENCRYPT_KEY = "SUPCON.MEDDOC.ENCRYPT.KEY";
            /// <summary>
            /// 病历数据库类型
            /// </summary>
            public const string MDS_DB_TYPE = "MdsDbType";
            /// <summary>
            /// 病历数据库驱动类型
            /// </summary>
            public const string MDS_PROVIDER_TYPE = "MdsDbProvider";
            /// <summary>
            /// 病历数据库连接串
            /// </summary>
            public const string MDS_CONN_STRING = "MdsDbConnString";
            /// <summary>
            /// 新版质控数据库类型
            /// </summary>
            public const string QC_DB_TYPE = "QcDbType";
            /// <summary>
            /// 新版质控数据库驱动类型
            /// </summary>
            public const string QC_PROVIDER_TYPE = "QcDbProvider";
            /// <summary>
            /// 新版质控数据库连接串
            /// </summary>
            public const string QC_CONN_STRING = "QcDbConnString";
            /// <summary>
            /// 宝典控件数据库连接串
            /// </summary>
            public const string OCX_CONNECTION_STRING = "MedEditorConnString";
            /// <summary>
            /// 配置字典表中文档存储模式配置
            /// </summary>
            public const string STORAGE_MODE = "STORAGE_MODE";
            /// <summary>
            /// 配置字典表中文档存储模式FTP
            /// </summary>
            public const string STORAGE_MODE_FTP = "FTP";
            /// <summary>
            /// 配置字典表中文档存储模式DB
            /// </summary>
            public const string STORAGE_MODE_DB = "DB";
            /// <summary>
            /// 配置字典表中oracle xdb
            /// </summary>
            public const string XML_DB = "XML_DB";
            /// <summary>
            /// 配置字典表中FTP文档库访问参数配置组名称
            /// </summary>
            public const string DOC_FTP = "DOCFTP";
            /// <summary>
            /// 配置字典表中FTP纸质病历翻拍图片地址访问参数配置组名称
            /// </summary>
            public const string RECPAPER_FTP = "RECPAPER_FTP";
            /// <summary>
            /// 配置字典表中FTP文档库IP
            /// </summary>
            public const string FTP_IP = "IP";
            /// <summary>
            /// 配置字典表中FTP文档库端口
            /// </summary>
            public const string FTP_PORT = "PORT";
            /// <summary>
            /// 配置字典表中FTP文档库用户名
            /// </summary>
            public const string FTP_USER = "USER";
            /// <summary>
            /// 配置字典表中FTP文档库密码
            /// </summary>
            public const string FTP_PWD = "PWD";
            /// <summary>
            /// 配置版本更新ftp地址 FTP_DIR
            /// </summary>
            public const string FTP_DIR = "FTP_DIR";
            /// <summary>
            /// 配置字典表中FTP协议模式
            /// </summary>
            public const string FTP_MODE = "FTP_MODE";
            /// <summary>
            /// 配置字典表中SYSTEM_OPTION配置组名称
            /// </summary>
            public const string SYSTEM_OPTION = "SYSTEM_OPTION";
            /// <summary>
            /// 配置字典表中QC(质控科)能否保存文档
            /// </summary>
            public const string QC_SAVE_DOC_ENABLE = "QC_SAVE_DOC_ENABLE";
            /// <summary>
            /// 病案范围从病人入科至出院天数
            /// </summary>
            public const string TIME_RECORD_DISCHARGE_DAYS = "TimeRecord.DischargeDays";
            /// <summary>
            /// 时效质控开始生成时间
            /// </summary>
            public const string TIME_RECORD_START_TIME = "TimeRecord.StartTime";
            /// <summary>
            /// 是否开启时效检查
            /// </summary>
            public const string TIME_CHECK_RUNNING = "TimeCheck.Running";
            /// <summary>
            /// 是否开启内容检查
            /// </summary>
            public const string CONTENT_RECORD_RUNNING = "ContentRecord.Running";
            /// <summary>
            /// 提醒系统登录对话框缺省登录用户
            /// </summary>
            public const string MEDTASK_DEFAULT_USERID = "MedTask.DefaultUserID";
            #region SystemOption
            /// <summary>
            /// 病历编辑器系统产品授权代码
            /// </summary>
            public const string SYSTEM_OPTION_CERT_CODE = "CERT_CODE";
            /// <summary>
            /// 外部程序调用结构化病历检索工具授权码
            /// </summary>
            public const string SYSTEM_OPTION_MEDSEARCH_CODE = "MEDSEARCH_CODE";
            /// <summary>
            /// 病历编辑器系统产品授权医院名称
            /// </summary>
            public const string SYSTEM_OPTION_HOSPITAL_NAME = "HOSPITAL_NAME";
            /// <summary>
            /// 编辑器系统缺省文本编辑器
            /// </summary>
            public const string SYSTEM_OPTION_DEFAULT_EDITOR = "DEFAULT_EDITOR";
            /// <summary>
            /// 配置医生文书上下两条诊断的时间差(单位:天)
            /// </summary>
            public const string SYSTEM_OPTION_DIAGNOSIS_TIME_INTERVAL = "DIAGNOSIS_TIME_INTERVAL";
            /// <summary>
            /// 配置字典表中病历可选功能配置组之基本输入框元素ID
            /// </summary>
            public const string SYSTEM_OPTION_BIND_REFRESH_ELEMENT = "BIND_REFRESH_ELEMENT";

            /// <summary>
            /// 编辑器系统病历记录等是否允许连续书写病历
            /// </summary>
            public const string SYSTEM_OPTION_WRITING_BY_SERIAL = "WRITING_BY_SERIAL";
            /// <summary>
            /// 病历数据访问服务URL地址
            /// </summary>
            public const string SYSTEM_OPTION_WEB_SERVICE_URL = "MD_SERVICE_URL";
            /// <summary>
            /// 病历的文档时间是否显示为病历内部的实际记录时间
            /// </summary>
            public const string SYSTEM_OPTION_SHOWAS_RECORD_TIME = "SHOWAS_RECORD_TIME";

            /// <summary>
            /// 病历合并列表是否仅显示归档病历配置组
            /// </summary>
            public const string SYSTEM_OPTION_COMBIN_NOT_ARICHVE_DOC = "COMBIN_NOT_ARICHVE_DOC";
            /// <summary>
            /// 合并文档列表是否从选中的文档开始续打
            /// </summary>
            public const string SYSTEM_OPTION_AUTO_NEXT_PRINT = "AUTO_NEXT_PRINT";

            /// <summary>
            /// 导入医嘱、检验等是否默认按自定义格式导入
            /// </summary>
            public const string SYSTEM_OPTION_IMPORT_DEFINE_STYLE = "IMPORT_DEFINE_STYLE";
            /// <summary>
            /// 病历中选择类型的元素:1-单击弹出元素选择器,0-双击弹出元素选择器
            /// </summary>
            public const string SYSTEM_OPTION_ELEMENT_SELECTOR_CLICK = "ELEMENT_SELECTOR_CLICK";

            /// <summary>
            /// 是否启用打开文档自动插入图片签名.0-关闭,1-启用
            /// </summary>
            public const string SYSTEM_OPTION_DOC_SIGN_PIC = "DOC_SIGN_PIC";

            /// <summary>
            /// 签名图片缩放
            /// </summary>
            public const string SYSTEM_OPTION_SIGN_IMAGE_ZOOM = "SIGN_IMAGE_ZOOM";


            /// <summary>
            /// 会诊病历类型,多个病历类型用半角逗号隔开，eg,123_1,456_1
            /// </summary>
            public const string SYSTEM_OPTION_CONSULTATION_TYPES = "CONSULTATION_TYPES";
            /// <summary>
            /// 质控科人员是否可以保持病历
            /// </summary>
            public const string SYSTEM_OPTION_QC_DOC_SAVE_ENABLE = "QC_DOC_SAVE_ENABLE";
            /// <summary>
            /// 是否启动将出院诊断插入K21表中
            /// </summary>
            public const string SYSTEM_OPTION_OUT_HOUSPITAL_DIAG_K21 = "OUT_HOUSPITAL_DIAG_K21";


            /// <summary>
            /// 初步诊断所在单元格宽度
            /// </summary>
            public const string SYSTEM_OPTION_FIRST_DIAGNOSIS_WIDTH = "FIRST_DIAGNOSIS_WIDTH";
            /// <summary>
            /// 最后诊断所在单元格宽度
            /// </summary>
            public const string SYSTEM_OPTION_LAST_DIAGNOSIS_WIDTH = "LAST_DIAGNOSIS_WIDTH";
            /// <summary>
            /// 病历正常书写判断标准
            /// </summary>
            public const string SYSTEM_OPTION_DOC_WRITE_RULE = "DOC_WRITE_RULE";
            /// <summary>
            /// 是否在打印或者预览前删除签名图片
            /// </summary>
            public const string SYSTEM_OPTION_DEL_SIGNPIC_BEFOREPRINT = "DEL_SIGNPIC_BEFOREPRINT";

            /// <summary>
            /// 是否存在历史病历服务器
            /// </summary>
            public const string SYSTEM_OPTION_HAS_HISFTP = "HAS_HISFTP";
            /// <summary>
            /// 是否异步保存病历及XML文档
            /// </summary>
            public const string SYSTEM_OPTION_IS_ASYNCH_SAVE_DOC = "IS_ASYNCH_SAVE_DOC";
            /// <summary>
            /// 保密科室列表
            /// </summary>
            public const string SYSTEM_OPTION_SECRET_DEPT_LIST = "SECRET_DEPT_LIST";
            /// <summary>
            /// 合并打开病历类型IDS
            /// </summary>
            public const String SYSTEM_OPTION_COMBIN_EDIT_DOCTYPEIDS = "COMBIN_EDIT_DOCTYPEIDS";
            /// <summary>
            /// 需要上级审核病历后才能打印的用户等级
            /// 多个用户等级用逗号分隔
            /// </summary>
            public const string SYSTEM_OPTION_PRINT_AUDIT_USER_GRADE = "PRINT_AUDIT_USER_GRADE";
            /// <summary>
            /// 用户验证WebService地址
            /// </summary>
            public const string SYSTEM_OPTION_USER_VALIDATION_SERVICE_URL = "USER_VALIDATION_SERVICE_URL";
            /// <summary>
            /// 还允许召回病人的最大天数
            /// 通常意义还要限制最多允许召回多少天之前出院的病人
            /// </summary>
            public const string SYSTEM_OPTION_RECALL_UP_TO_DAYS = "RECALL_UP_TO_DAYS";
            /// <summary>
            /// 入院|转科后可编辑遍历的时效（小时）
            /// </summary>
            public const string SYSTEM_OPTION_WRITE_DOC_HOURS = "WRITE_DOC_HOURS";
            /// <summary>
            /// 新建病历的时候是否将所有元素设置为不可删除（复杂元素除外）
            /// </summary>
            public const string SYSTEM_OPTION_ALLOW_DELETE_TEMPLET_ELEMENTS = "ALLOW_DELETE_TEMPLET_ELEMENTS";
            /// <summary>
            /// 是否允许不提交病历就直接修改确认诊断元素
            /// </summary>
            public const string SYSTEM_OPTION_ALLOW_UPDATE_LASTDIAGNOSIS_NOLIMIT = "ALLOW_UPDATE_LASTDIAGNOSIS__NOLIMIT";
            /// <summary>
            /// 是否允许提交病历后可继续修改初步诊断元素
            /// </summary>
            public const string SYSTEM_OPTION_ALLOW_UPDATE_FIRSTDIAGNOSIS_NOLIMIT = "ALLOW_UPDATE_FIRSTDIAGNOSIS__NOLIMIT";
            /// <summary>
            /// 是否允许手动输入诊断信息
            /// </summary>
            public const string SYSTEM_OPTION_ALLOW_INPUT_DIAGNOSIS = "ALLOW_INPUT_TDIAGNOSIS";
            /// <summary>
            /// 需要记录文档份数的文档类型ID
            /// </summary>
            public const string SYSTEM_OPTION_NEED_SUM_DOCTYPEIDS = "NEED_SUM_DOCTYPEIDS";
            /// <summary>
            /// 允许任何人编辑的文档类型ID集合
            /// </summary>
            public const string SYSTEM_OPTION_ALL_EDITABLE_DOC_TYPE_IDS = "ALL_EDITABLE_DOC_TYPE_IDS";
            /// <summary>
            /// 是否启用新质控监控病历相关事件
            /// </summary>
            public const string SYSTEM_OPTION_NEW_QC_ENABLE = "NEW_QC_ENABLE";
            /// <summary>
            /// 是否在更新病历时更新质检问题状态为已修改
            /// </summary>
            public const string SYSTEM_OPTION_IS_UPDATE_QCSTATUS = "IS_UPDATE_QCSTATUS";
            /// <summary>
            /// 病案评分甲乙分标准
            /// </summary>
            public const string SYSTEM_OPTION_GRADING_STANDARD = "GRADING_STANDARD";
            /// <summary>
            /// 诊断类型文书类型ID
            /// </summary>
            public const string SYSTEM_OPTION_DIAGNOSIS_DOC_TYPE_IDS = "DIAGNOSIS_DOC_TYPE_IDS";
            #endregion
            /// <summary>
            /// 复印内容关键词
            /// </summary>
            public const string PrintContent = "PrintContent";
            /// <summary>
            /// 患者手签病历标题关键词
            /// </summary>
            public const string SignKeyName = "SignKeyName";
        }
    }
}
