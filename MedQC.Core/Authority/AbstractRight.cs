// **************************************************************
// 平台公用模块之资源抽象类
// Creator:YangMingkun  Date:2013-9-5
// Copyright : Heren Health Services Co.,Ltd.
// **************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Heren.MedQC.Core
{
    public abstract partial class AbstractRight
    {
        /// <summary>
        /// 获得权限点
        /// </summary>
        /// <returns></returns>
        public virtual RightPoint[] GetRightPoints(string szProduct)
        {
            return null;
        }

        public virtual string[] GetModuleResources(string szProduct)
        {
            return null;
        }
    }
}
