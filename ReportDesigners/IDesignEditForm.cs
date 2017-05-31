// ***********************************************************
// 护理病历配置管理系统,模板、报表等设计器窗口类的接口.
// Author : YangMingkun, Date : 2012-6-6
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Designers
{
    internal interface IDesignEditForm
    {
        bool IsDisposed { get; }

        bool IsModified { get; }

        PropertyGrid PropertyGrid { get; set; }
    }
}
