using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 结构化元素类型
    /// </summary>
    [System.Serializable]
    public enum ElementType
    {
        /// <summary>
        /// -1-未知元素
        /// </summary>
        None = -1,
        /// <summary>
        /// 0-病历提纲类元素
        /// </summary>
        Outline = 0,
        /// <summary>
        /// 1-输入类元素;
        /// </summary>
        InputBox = 1,
        /// <summary>
        /// 2-简单选项类元素;
        /// </summary>
        SimpleOption = 2,
        /// <summary>
        /// 3-复杂选项类元素;
        /// </summary>
        ComplexOption = 3,
        /// <summary>
        /// 4-复选框元素
        /// </summary>
        CheckBox = 4
    }

}
