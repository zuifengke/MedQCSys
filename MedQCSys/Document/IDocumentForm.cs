// ***********************************************************
// 文档窗口接口定义.用于规范可能接入的各种编辑控件的接口.
// Creator:YangMingkun  Date:2010-10-14
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Text;
using Heren.Common.Controls;
using Heren.Common.Libraries;
using EMRDBLib;

namespace MedQCSys.Document
{
    public interface IDocumentForm
    {
        #region"属性"
        /// <summary>
        /// 获取或设置文档信息列表,如果当前文档由一系列文档合并组成
        /// </summary>
        MedDocList Documents { get; }

        /// <summary>
        /// 获取或设置当前文档信息
        /// </summary>
        MedDocInfo Document { get; }

        /// <summary>
        /// 获取病历窗口是否已经被释放
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// 获取文档文本处理器
        /// </summary>
        MedDocSys.PadWrapper.IMedEditor MedEditor { get; }

        /// <summary>
        /// 获取DockContent对象Dock处理类
        /// </summary>
        Heren.Common.DockSuite.DockContentHandler DockHandler { get; }
        #endregion

        #region"方法"
        /// <summary>
        /// 刷新窗口标题
        /// </summary>
        /// <param name="szDocTitle">文档显示标题</param>
        void RefreshFormTitle(string szDocTitle);

        /// <summary>
        /// 打开指定的文档
        /// </summary>
        /// <param name="document">文档信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        short OpenDocument(MedDocInfo document);

        /// <summary>
        /// 合并打开指定的一系列文档
        /// </summary>
        /// <param name="documents">文档信息</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        short OpenDocument(MedDocList documents);

        /// <summary>
        /// 质控人员打开历史病历
        /// </summary>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        short OpenHistoryDocument(MedicalQcMsg questionInfo);
        #endregion
    }
}