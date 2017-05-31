using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 编辑器用户权限信息
    /// </summary>
    [System.Serializable]
    public class UserRight : UserRightBase
    {
        private RightInfo m_MedDocSystem = null;
        /// <summary>
        /// 获取或设置是否允许使用病历编辑器
        /// </summary>
        public RightInfo MedDocSystem
        {
            set { }
            get { return this.m_MedDocSystem; }
        }

        private RightInfo m_TempletSystem = null;
        /// <summary>
        /// 获取或设置是否允许使用模板系统
        /// </summary>
        public RightInfo TempletSystem
        {
            set { }
            get { return this.m_TempletSystem; }
        }

        private RightInfo m_SearchSystem = null;
        /// <summary>
        /// 获取或设置是否允许使用检索系统
        /// </summary>
        public RightInfo SearchSystem
        {
            set { }
            get { return this.m_SearchSystem; }
        }

        private RightInfo m_CreateDocument = null;
        /// <summary>
        /// 获取或设置是否允许创建病历
        /// </summary>
        public RightInfo CreateDocument
        {
            set { }
            get { return this.m_CreateDocument; }
        }

        private RightInfo m_SaveDocument = null;
        /// <summary>
        /// 获取或设置是否允许保存病历
        /// </summary>
        public RightInfo SaveDocument
        {
            set { }
            get { return this.m_SaveDocument; }
        }

        private RightInfo m_OpenDocument = null;
        /// <summary>
        /// 获取或设置是否允许打开病历
        /// </summary>
        public RightInfo OpenDocument
        {
            set { }
            get { return this.m_OpenDocument; }
        }

        private RightInfo m_OpenHistoryDocument = null;
        /// <summary>
        /// 获取或设置是否允许打开历史病历
        /// </summary>
        public RightInfo OpenHistoryDocument
        {
            set { }
            get { return this.m_OpenHistoryDocument; }
        }

        private RightInfo m_EditDocument = null;
        /// <summary>
        /// 获取或设置是否允许编辑病历
        /// </summary>
        public RightInfo EditDocument
        {
            set { }
            get { return this.m_EditDocument; }
        }

        private RightInfo m_PrintDocument = null;
        /// <summary>
        /// 获取或设置是否允许打印病历
        /// </summary>
        public RightInfo PrintDocument
        {
            set { }
            get { return this.m_PrintDocument; }
        }

        private RightInfo m_DeleteDocument = null;
        /// <summary>
        /// 获取或设置是否允许删除病历
        /// </summary>
        public RightInfo DeleteDocument
        {
            set { }
            get { return this.m_DeleteDocument; }
        }

        private RightInfo m_ExportDocument = null;
        /// <summary>
        /// 获取或设置是否允许导出病历
        /// </summary>
        public RightInfo ExportDocument
        {
            set { }
            get { return this.m_ExportDocument; }
        }

        private RightInfo m_ArchiveDocument = null;
        /// <summary>
        /// 获取或设置是否允许执行病历归档操作
        /// </summary>
        public RightInfo ArchiveDocument
        {
            set { }
            get { return this.m_ArchiveDocument; }
        }

        private RightInfo m_RollbackDocument = null;
        /// <summary>
        /// 获取或设置是否允许执行病历退回操作
        /// </summary>
        public RightInfo RollbackDocument
        {
            set { }
            get { return this.m_RollbackDocument; }
        }

        private RightInfo m_CopyToDocument = null;
        /// <summary>
        /// 获取或设置是否允许拷贝到病历
        /// </summary>
        public RightInfo CopyToDocument
        {
            set { }
            get { return this.m_CopyToDocument; }
        }

        private RightInfo m_CopyToSmallTemplet = null;
        /// <summary>
        /// 获取或设置是否允许拷贝到小模板
        /// </summary>
        public RightInfo CopyToSmallTemplet
        {
            set { }
            get { return this.m_CopyToSmallTemplet; }
        }

        private RightInfo m_CopyFormDocument = null;
        /// <summary>
        /// 获取或设置是否允许从病历中复制出去权限
        /// </summary>
        public RightInfo CopyFormDocument
        {
            set { }
            get { return this.m_CopyFormDocument; }
        }
        private RightInfo m_PasteFromOutSys = null;
        /// <summary>
        /// 设置是否允许拷贝外部数据的内容
        /// </summary>
        public RightInfo PasteFromOutSys
        {
            get
            {
                return m_PasteFromOutSys;
            }

            set
            {

            }
        }

        private RightInfo m_EditDeptDocument = null;
        /// <summary>
        /// 获取或设置是否允许修改本科室他人文档
        /// </summary>
        public RightInfo EditDeptDocument
        {
            set { }
            get { return this.m_EditDeptDocument; }
        }

        private RightInfo m_EditAllDocument = null;
        /// <summary>
        /// 获取或设置是否允许修改其他科室文档
        /// </summary>
        public RightInfo EditAllDocument
        {
            set { }
            get { return this.m_EditAllDocument; }
        }

        private RightInfo m_EditTemplet = null;
        /// <summary>
        /// 获取或设置是否允许创建/编辑模板
        /// </summary>
        public RightInfo EditTemplet
        {
            set { }
            get { return this.m_EditTemplet; }
        }

        private RightInfo m_EditDeptTemplet = null;
        /// <summary>
        /// 获取或设置是否允许修改本科室他人模板
        /// </summary>
        public RightInfo EditDeptTemplet
        {
            set { }
            get { return this.m_EditDeptTemplet; }
        }

        private RightInfo m_EditAllTemplet = null;
        /// <summary>
        /// 获取或设置是否允许修改其他科室模板
        /// </summary>
        public RightInfo EditAllTemplet
        {
            set { }
            get { return this.m_EditAllTemplet; }
        }

        /// <summary>
        /// 获取是否允许提交模板
        /// </summary>
        private RightInfo m_CommitTemplet = null;
        public RightInfo CommitTemplet
        {
            set { }
            get { return this.m_CommitTemplet; }
        }
        private RightInfo m_CheckDeptTemplet = null;
        /// <summary>
        /// 获取或设置是否允许审核本科模板
        /// </summary>
        public RightInfo CheckDeptTemplet
        {
            set { }
            get { return this.m_CheckDeptTemplet; }
        }

        private RightInfo m_CheckAllTemplet = null;
        /// <summary>
        /// 获取或设置是否允许审核所有模板
        /// </summary>
        public RightInfo CheckAllTemplet
        {
            set { }
            get { return this.m_CheckAllTemplet; }
        }

        private RightInfo m_ModifyTempletSettings = null;
        /// <summary>
        /// 获取或设置是否允许修改模板设置
        /// </summary>
        public RightInfo ModifyTempletSettings
        {
            set { }
            get { return this.m_ModifyTempletSettings; }
        }

        private RightInfo m_ManageDeptPicture = null;
        /// <summary>
        /// 获取或设置是否允许管理本科图像库
        /// </summary>
        public RightInfo ManageDeptPicture
        {
            set { }
            get { return this.m_ManageDeptPicture; }
        }

        private RightInfo m_ManageAllPicture = null;
        /// <summary>
        /// 获取或设置是否允许管理所有图像库
        /// </summary>
        public RightInfo ManageAllPicture
        {
            set { }
            get { return this.m_ManageAllPicture; }
        }

        private RightInfo m_ManageDeptElement = null;
        /// <summary>
        /// 获取或设置是否允许管理本科元素库
        /// </summary>
        public RightInfo ManageDeptElement
        {
            set { }
            get { return this.m_ManageDeptElement; }
        }

        private RightInfo m_ManageAllElement = null;
        /// <summary>
        /// 获取或设置是否允许管理所有元素库
        /// </summary>
        public RightInfo ManageAllElement
        {
            set { }
            get { return this.m_ManageAllElement; }
        }

        private RightInfo m_MRBorrowManage = null;
        /// <summary>
        /// 获取或设置是否允许病案借阅管理权限
        /// </summary>
        public RightInfo MRBorrowManage
        {
            set { }
            get { return this.m_MRBorrowManage; }
        }

        private RightInfo m_ViewQCRPT = null;
        /// <summary>
        /// 获取或设置是否允许查看质控时效等相关报告
        /// </summary>
        public RightInfo ViewQCRPT
        {
            set { }
            get { return this.m_ViewQCRPT; }
        }

        public UserRight()
        {
            this.m_eRightType = UserRightType.MedDoc;

            //注意：权限索引编号禁止重复,同时禁止修改已存在权限的索引编号
            //由于系统不断的升级完善,期间可能会有权限点的增删改,故索引索引可能不连续
            this.m_MedDocSystem = new RightInfo("电子病历系统", 0, false, "是否允许使用电子病历系统");
            this.m_TempletSystem = new RightInfo("病历模板系统", 2, false, "是否允许使用病历模板系统");
            this.m_CreateDocument = new RightInfo("创建病历", 3, false, "是否允许创建新的病历");
            this.m_SaveDocument = new RightInfo("保存病历", 4, false, "是否允许保存病历");
            this.m_OpenDocument = new RightInfo("浏览病历", 5, false, "是否允许浏览已写的病历");
            this.m_EditDocument = new RightInfo("修改病历", 6, false, "是否允许修改已存在的病历");
            this.m_PrintDocument = new RightInfo("打印病历", 7, false, "是否允许打印当前病历");
            this.m_DeleteDocument = new RightInfo("删除病历", 8, false, "是否允许删除当前病历");
            this.m_ExportDocument = new RightInfo("导出病历", 9, false, "是否允许将病历导出为其他格式");
            this.m_ArchiveDocument = new RightInfo("归档病历", 10, false, "是否允许将当前就诊下的所有病历归档(是否允许上层调用归档接口)");
            this.m_RollbackDocument = new RightInfo("回退病历", 11, false, "是否允许将当前就诊下的所有病历取消归档(是否允许上层调用回退接口)");

            this.m_CopyToDocument = new RightInfo("病人间病历拷贝", 12, false, "是否允许将其他病人的病历内容拷贝到当前病人的病历");
            this.m_CopyToSmallTemplet = new RightInfo("拷贝到小模板", 13, false, "是否允许将其他任意内容拷贝到小模板等处");

            this.m_EditDeptDocument = new RightInfo("修改本科室病历", 14, false, "是否允许修改本科室的所有病历");
            this.m_EditAllDocument = new RightInfo("修改全院病历", 15, false, "是否允许修改全院的所有病历");
            this.m_EditTemplet = new RightInfo("创建与修改模板", 16, false, "是否允许创建与修改模板");
            this.m_EditDeptTemplet = new RightInfo("修改本科室模板", 17, false, "是否允许修改本科室的所有模板(仅模板内容)");
            this.m_EditAllTemplet = new RightInfo("修改全院模板", 18, false, "是否允许修改全院的所有模板(仅模板内容)");

            this.m_CheckDeptTemplet = new RightInfo("审核本科室模板", 19, false, "是否允许审核本科室所有模板(启用审核时有效)");
            this.m_CheckAllTemplet = new RightInfo("审核全院模板", 20, false, "是否允许审核全院所有模板(启用审核时有效)");

            this.m_ModifyTempletSettings = new RightInfo("修改模板设置", 21, false, "是否允许修改模板设置(主要指页眉和页面设置)");
            this.m_ManageDeptPicture = new RightInfo("管理本科室图库", 22, false, "是否允许添加、修改、删除本科室医学图像库");
            this.m_ManageAllPicture = new RightInfo("管理全院图库", 23, false, "是否允许添加、修改、删除全院通用的医学图像库");
            this.m_ManageDeptElement = new RightInfo("管理本科室元素库", 24, false, "是否允许添加、修改、删除本科室的元素库");
            this.m_ManageAllElement = new RightInfo("管理全院元素库", 25, false, "是否允许添加、修改、删除全院通用的元素库");

            this.m_OpenHistoryDocument = new RightInfo("浏览历史病历", 26, false, "是否允许浏览历史病历");
            this.m_SearchSystem = new RightInfo("病历检索系统", 27, false, "是否允许使用病历检索系统");
            this.m_CopyFormDocument = new RightInfo("从病历中拷贝", 30, true, "是否允许用户将病历内容拷贝出去");

            this.m_CommitTemplet = new RightInfo("提交病历模板", 31, false, "是否允许用户提交模板至上级审核");
            this.m_ViewQCRPT = new RightInfo("查看质控报告", 32, false, "是否允许查看质控时效等相关报告");
            this.m_PasteFromOutSys = new RightInfo("拷贝外部数据", 33, false, "是否允许拷贝外部数据到病历");
        }
    }
}
