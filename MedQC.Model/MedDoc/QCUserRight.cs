using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 质控用户权限表
    /// </summary>
    public class QCUserRight : UserRightBase
    {
        private RightInfo m_MedQCSystem = null;
        /// <summary>
        /// 获取或设置是否允许使用质控系统
        /// </summary>
        public RightInfo MedQCSystem
        {
            set { }
            get { return this.m_MedQCSystem; }
        }

        private RightInfo m_BrowsePatientInfo = null;
        /// <summary>
        ///  获取或设置是否显示病人信息窗口
        /// </summary>
        public RightInfo BrowsePatientInfo
        {
            set { }
            get { return this.m_BrowsePatientInfo; }
        }

        private RightInfo m_BrowseDocumentList = null;
        /// <summary>
        /// 获取或设置是否显示病程记录窗口
        /// </summary>
        public RightInfo BrowseDocumentList
        {
            set { }
            get { return this.m_BrowseDocumentList; }
        }

        private RightInfo m_BrowseDocumentTime = null;
        /// <summary>
        ///  获取或设置是否显示病历时效窗口
        /// </summary>
        public RightInfo BrowseDocumentTime
        {
            set { }
            get { return this.m_BrowseDocumentTime; }
        }

        private RightInfo m_BrowseOrdersList = null;
        /// <summary>
        /// 获取或设置是否显示医嘱记录窗口
        /// </summary>
        public RightInfo BrowseOrdersList
        {
            set { }
            get { return this.m_BrowseOrdersList; }
        }

        private RightInfo m_BrowseExamList = null;
        /// <summary>
        /// 获取或设置是否显示检查记录窗口
        /// </summary>
        public RightInfo BrowseExamList
        {
            set { }
            get { return this.m_BrowseExamList; }
        }

        private RightInfo m_PrintExamList = null;
        /// <summary>
        /// 获取或设置是否显示检查记录窗口
        /// </summary>
        public RightInfo PrintExamList
        {
            set { }
            get { return this.m_PrintExamList; }
        }

        private RightInfo m_BrowseLabTestList = null;
        /// <summary>
        /// 获取或设置是否浏览检验记录
        /// </summary>
        public RightInfo BrowseLabTestList
        {
            set { }
            get { return this.m_BrowseLabTestList; }
        }

        private RightInfo m_PrintLabTestList = null;
        /// <summary>
        /// 获取或设置是否打印检验记录
        /// </summary>
        public RightInfo PrintLabTestList
        {
            set { }
            get { return this.m_PrintLabTestList; }
        }

        private RightInfo m_BrowseDiagnosisList = null;
        /// <summary>
        /// 获取或设置是否显示患者诊断信息窗口
        /// </summary>
        public RightInfo BrowseDiagnosisList
        {
            set { }
            get { return this.m_BrowseDiagnosisList; }
        }

        private RightInfo m_BrowseMRScore = null;
        /// <summary>
        /// 获取或设置是否显示病案评分窗口
        /// </summary>
        public RightInfo BrowseMRScore
        {
            set { }
            get { return this.m_BrowseMRScore; }
        }

        private RightInfo m_BrowseNurDocList = null;
        /// <summary>
        /// 获取或设置是否显示护理文书窗口
        /// </summary>
        public RightInfo BrowseNurDocList
        {
            set { }
            get { return this.m_BrowseNurDocList; }
        }

        private RightInfo m_BrowseQCQuestion = null;
        /// <summary>
        /// 获取或设置是否显示反馈信息窗口
        /// </summary>
        public RightInfo BrowseQCQuestion
        {
            set { }
            get { return this.m_BrowseQCQuestion; }
        }

        private RightInfo m_CommitQCQuestion = null;
        /// <summary>
        /// 获取或设置是否允许提交质控问题权限
        /// </summary>
        public RightInfo CommitQCQuestion
        {
            set { }
            get { return this.m_CommitQCQuestion; }
        }

        private RightInfo m_BrowseQCQuestionType = null;
        /// <summary>
        /// 获取或设置是否显示问题类型窗口
        /// </summary>
        public RightInfo BrowseQCQuestionType
        {
            set { }
            get { return this.m_BrowseQCQuestionType; }
        }

        private RightInfo m_ManageQCQuestionType = null;
        /// <summary>
        /// 获取或设置是否显示问题模板维护窗口
        /// </summary>
        public RightInfo ManageQCQuestionType
        {
            set { }
            get { return this.m_ManageQCQuestionType; }
        }

        private RightInfo m_BrowseQCQuestionTemplet = null;
        /// <summary>
        /// 获取或设置是否显示问题模板维护窗口
        /// </summary>
        public RightInfo BrowseQCQuestionTemplet
        {
            set { }
            get { return this.m_BrowseQCQuestionTemplet; }
        }

        private RightInfo m_ManageQCQuestionTemplet = null;
        /// <summary>
        /// 获取或设置是否显示问题模板维护窗口
        /// </summary>
        public RightInfo ManageQCQuestionTemplet
        {
            set { }
            get { return this.m_ManageQCQuestionTemplet; }
        }

        private RightInfo m_ManageDeptQC = null;
        /// <summary>
        ///  获取或设置科级病案质控
        /// </summary>
        public RightInfo ManageDeptQC
        {
            set { }
            get { return this.m_ManageDeptQC; }
        }

        private RightInfo m_ManageAdminDeptsQC = null;

        /// <summary>
        /// 获取或者设置管辖科室病案
        /// </summary>
        public RightInfo ManageAdminDeptsQC
        {
            get { return m_ManageAdminDeptsQC; }
            set { }
        }

        private RightInfo m_ManageAllQC = null;
        /// <summary>
        ///  获取或设置院级病案质控
        /// </summary>
        public RightInfo ManageAllQC
        {
            set { }
            get { return this.m_ManageAllQC; }
        }

        private RightInfo m_BrowseQCStatistics = null;
        /// <summary>
        /// 获取或设置是否允许使用查询统计功能
        /// </summary>
        public RightInfo BrowseQCStatistics
        {
            set { }
            get { return this.m_BrowseQCStatistics; }
        }

        private RightInfo m_ManageRollbackSubmitDoc = null;
        /// <summary>
        /// 获取或设置是否允许回退已提交病历
        /// </summary>
        public RightInfo ManageRollbackSubmitDoc
        {
            set { }
            get { return this.m_ManageRollbackSubmitDoc; }
        }

        private RightInfo m_BrowsUnCheckTempletList = null;
        /// <summary>
        /// 获取或设置是否允许查看待审核的模板列表
        /// </summary>
        public RightInfo BrowseUnCheckTempletList
        {
            set { }
            get { return this.m_BrowsUnCheckTempletList; }
        }

        private RightInfo m_EditAbleDoc = null;
        /// <summary>
        /// 获取或设置是否允许修改病历内容
        /// </summary>
        public RightInfo EditAbleDoc
        {
            set { }
            get { return this.m_EditAbleDoc; }
        }

        private RightInfo m_SecretDeptList = null;
        /// <summary>
        /// 获取或设置是否允许查看受保密控制的科室列表
        /// </summary>
        public RightInfo SecretDeptList
        {
            set { }
            get { return this.m_SecretDeptList; }
        }
        private RightInfo m_DeleteConfirmMsg = null;
        /// <summary>
        /// 获取或设置是否允许删除已被医生确认的质检信息
        /// </summary>
        public RightInfo DeleteConfirmMsg
        {
            set { }
            get { return this.m_DeleteConfirmMsg; }
        }
        private RightInfo m_IsSpecialDoc = null;

        /// <summary>
        /// 是否是质控专家
        /// </summary>
        public RightInfo IsSpecialDoc
        {
            set { }
            get { return this.m_IsSpecialDoc; }
        }

        private RightInfo m_BrowsChecker = null;
        /// <summary>
        /// 是否有权限查看检查者
        /// </summary>
        public RightInfo BrowsChecker
        {
            get { return m_BrowsChecker; }
            set { m_BrowsChecker = value; }
        }

        private RightInfo m_UseDocModifyApply;
        /// <summary>
        /// 是否有权限使用病历修改审核
        /// </summary>
        public RightInfo UseDocModifyApply
        {
            get { return m_UseDocModifyApply; }
            set { m_UseDocModifyApply = value; }
        }
        private RightInfo m_BrowsTemperatureChart = null;
        /// <summary>
        /// 是否有权查看体温单
        /// </summary>
        public RightInfo BrowsTemperatureChart
        {
            get { return m_BrowsTemperatureChart; }
            set { m_BrowsTemperatureChart = value; }
        }
        private RightInfo m_BrowsNursingRecord = null;
        /// <summary>
        /// 是否有权查看护理记录
        /// </summary>
        public RightInfo BrowsNursingRecord
        {
            get { return m_BrowsNursingRecord; }
            set { m_BrowsNursingRecord = value; }
        }
        private RightInfo m_DeleteQCQutionNoLimit = null;
        /// <summary>
        /// 无条件删除质检问题
        /// </summary>
        public RightInfo DeleteQCQutionNoLimit
        {
            get { return m_DeleteQCQutionNoLimit; }
            set { m_DeleteQCQutionNoLimit = value; }
        }
        private RightInfo m_IsQCDeptUser = null;
        /// <summary>
        /// 是否是质检科人员
        /// </summary>
        public RightInfo IsQCDeptUser
        {
            get { return m_IsQCDeptUser; }
            set { m_IsQCDeptUser = value; }
        }
        public QCUserRight()
        {
            this.m_eRightType = UserRightType.MedQC;

            //注意：权限索引编号禁止重复,同时禁止修改已存在权限的索引编号
            //由于系统不断的升级完善,期间可能会有权限点的增删改,故索引索引可能不连续
            this.m_MedQCSystem = new RightInfo("病案质控系统", 0, false, "是否允许使用病案质控系统");
            this.m_BrowsePatientInfo = new RightInfo("查看患者信息", 1, false, "是否允许查看患者信息");
            this.m_BrowseDocumentList = new RightInfo("查看病程记录", 2, false, "是否允许查看患者病程记录");
            this.m_BrowseDocumentTime = new RightInfo("查看病历时效", 3, false, "是否允许查看病历时效");
            this.m_BrowseOrdersList = new RightInfo("查看医嘱记录", 4, false, "是否允许查看患者医嘱记录");
            this.m_BrowseExamList = new RightInfo("查看检查记录", 5, false, "是否允许查看患者检查记录");
            this.m_PrintExamList = new RightInfo("打印检查记录", 6, false, "是否允许打印患者检查记录");
            this.m_BrowseLabTestList = new RightInfo("查看检验记录", 7, false, "是否允许查看患者检验记录");
            this.m_PrintLabTestList = new RightInfo("打印检验记录", 8, false, "是否允许打印患者检验记录");
            this.m_BrowseDiagnosisList = new RightInfo("查看诊断记录", 9, false, "是否允许查看患者诊断记录");
            this.m_BrowseMRScore = new RightInfo("查看病案评分", 10, false, "是否允许查看病人的病案评分");
            this.m_BrowseQCQuestion = new RightInfo("查看质控问题", 11, false, "是否允许查看质控反馈问题");
            this.m_CommitQCQuestion = new RightInfo("提交质控问题", 12, false, "是否允许提交质控反馈问题");
            this.m_BrowseQCQuestionType = new RightInfo("查看质控问题类型", 13, false, "是否允许查看质控问题类型");
            this.m_ManageQCQuestionType = new RightInfo("维护质控问题类型", 14, false, "是否允许维护质控问题类型");
            this.m_BrowseQCQuestionTemplet = new RightInfo("查看质控问题模板", 15, false, "是否允许查看质控问题模板");
            this.m_ManageQCQuestionTemplet = new RightInfo("维护质控问题模板", 16, false, "是否允许维护质控问题模板");
            this.m_ManageDeptQC = new RightInfo("科级病案质控", 17, false, "是否开启科级病案质控");
            this.m_ManageAllQC = new RightInfo("院级病案质控", 18, false, "是否开启院级病案质控");
            this.m_BrowseQCStatistics = new RightInfo("查询统计功能", 19, false, "是否允许使用查询统计功能");
            this.m_ManageRollbackSubmitDoc = new RightInfo("回退已提交病历", 20, false, "是否允许使用回退已提交病历功能");
            this.m_BrowsUnCheckTempletList = new RightInfo("查看待审核模板", 21, false, "是否允许查看待审核模板");
            this.m_EditAbleDoc = new RightInfo("修改病历内容", 22, false, "是否允许修改病历内容");
            this.m_BrowseNurDocList = new RightInfo("护理质控", 23, false, "是否允许进行护理质控");
            this.m_SecretDeptList = new RightInfo("查看受保密控制科室的病历", 24, false, "是否允许查看受保密控制科室的病历");
            this.m_DeleteConfirmMsg = new RightInfo("删除已被医生确认的质检信息", 25, false, "是否允许删除已被医生确认的质检信息");
            this.m_IsSpecialDoc = new RightInfo("质控专家", 26, false, "是否是质控专家");
            this.m_ManageAdminDeptsQC = new RightInfo("管辖科室病案质控", 27, false, "是否开启管辖科室病案质控");
            this.m_BrowsChecker = new RightInfo("查看检查者", 28, false, "是否有权限查看检查者");
            this.m_UseDocModifyApply = new RightInfo("病历修改申请审核", 29, false, "是否有权限使用病历修改审核");
            this.m_BrowsTemperatureChart = new RightInfo("查看体温单", 30, false, "是否有权限查看体温单");
            this.m_BrowsNursingRecord = new RightInfo("查看护理记录", 31, false, "是否有权限查看护理记录");
            this.m_DeleteQCQutionNoLimit = new RightInfo("无条件删除质检信息", 32, false, "是否有权限无条件删除质检信息");
            this.m_IsQCDeptUser = new RightInfo("质控科人员", 33, false, "是否属于质控科人员");
        }
    }

}
