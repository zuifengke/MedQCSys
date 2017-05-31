// ***********************************************************
// 护理病历配置管理系统,模板、报表等的脚本编辑窗口类的接口.
// Author : YangMingkun, Date : 2012-6-6
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Designers
{
    internal interface IScriptEditForm
    {
        /// <summary>
        /// 获取当前脚本编辑器窗口是否已被释放
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// 获取当前脚本编辑器窗口是否已被修改
        /// </summary>
        bool IsModified { get; }

        /// <summary>
        /// 将当前脚本编辑器窗口光标定位到指定行列
        /// </summary>
        /// <param name="line">行号</param>
        /// <param name="column">列号</param>
        void LocateTo(int line, int column);

        /// <summary>
        /// 将当前脚本编辑器窗口光标定位到指定的文本
        /// </summary>
        /// <param name="offset">索引位置</param>
        /// <param name="length">长度</param>
        void LocateToText(int offset, int length);

        /// <summary>
        /// 获取当前选中的文本
        /// </summary>
        /// <returns>选中的文本</returns>
        string GetSelectedText();

        /// <summary>
        /// 查找与指定的文本匹配的所有文本
        /// </summary>
        /// <param name="szFindText">文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        void FindText(string szFindText, bool bMatchCase);

        /// <summary>
        /// 在所有模板脚本中查找与指定的文本匹配的所有文本
        /// </summary>
        /// <param name="szFindText">文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        void FindTextInAllTemplet(string szFindText, bool bMatchCase);

        /// <summary>
        /// 查找并替换指定的文本
        /// </summary>
        /// <param name="szFindText">查找文本</param>
        /// <param name="szReplaceText">替换文本</param>
        /// <param name="bMatchCase">是否匹配大小写</param>
        /// <param name="bReplaceAll">是否替换所有</param>
        /// <returns>DataLayer.SystemData.ReturnValue</returns>
        void ReplaceText(string szFindText, string szReplaceText, bool bMatchCase, bool bReplaceAll);
    }
}
