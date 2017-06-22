using EMRDBLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heren.MedQC.Model.MedDoc
{
    /// <summary>
    /// 结构化元素信息类
    /// 对应我们自定义的结构化表
    /// </summary>
    [System.Serializable]
    public class StructElement : DbTypeBase
    {
        private string m_elementID = string.Empty;
        /// <summary>
        /// 获取或设置元素ID号
        /// </summary>
        public string ElementID
        {
            get { return this.m_elementID; }
            set { this.m_elementID = value; }
        }

        private int m_elementNo = -1;
        /// <summary>
        /// 获取或设置元素显示序号
        /// </summary>
        public int ElementNo
        {
            get { return this.m_elementNo; }
            set { this.m_elementNo = value; }
        }

        private string m_elementName = string.Empty;
        /// <summary>
        /// 获取或设置元素名称
        /// </summary>
        public string ElementName
        {
            get { return this.m_elementName; }
            set { this.m_elementName = value; }
        }

        private ElementType m_elementType = ElementType.InputBox;
        /// <summary>
        /// 获取或设置元素类型
        /// </summary>
        public ElementType ElementType
        {
            get { return this.m_elementType; }
            set { this.m_elementType = value; }
        }

        private string m_creatorID = string.Empty;
        /// <summary>
        /// 获取或设置创建者ID号
        /// </summary>
        public string CreatorID
        {
            get { return this.m_creatorID; }
            set { this.m_creatorID = value; }
        }

        private string m_creatorName = string.Empty;
        /// <summary>
        /// 获取或设置创建者名称
        /// </summary>
        public string CreatorName
        {
            get { return this.m_creatorName; }
            set { this.m_creatorName = value; }
        }

        private DateTime m_createTime;
        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return this.m_createTime; }
            set { this.m_createTime = value; }
        }

        private string m_modifierID = string.Empty;
        /// <summary>
        /// 获取或设置修改人ID号
        /// </summary>
        public string ModifierID
        {
            get { return this.m_modifierID; }
            set { this.m_modifierID = value; }
        }

        private string m_modifierName = string.Empty;
        /// <summary>
        /// 获取或设置修改人姓名
        /// </summary>
        public string ModifierName
        {
            get { return this.m_modifierName; }
            set { this.m_modifierName = value; }
        }

        private DateTime m_modifyTime;
        /// <summary>
        /// 获取或设置修改时间
        /// </summary>
        public DateTime ModifyTime
        {
            get { return this.m_modifyTime; }
            set { this.m_modifyTime = value; }
        }

        private string m_deptCode = string.Empty;
        /// <summary>
        /// 获取或设置所属科室代码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_deptCode; }
            set { this.m_deptCode = value; }
        }

        private string m_deptName = string.Empty;
        /// <summary>
        /// 获取或设置所属科室名称
        /// </summary>
        public string DeptName
        {
            get { return this.m_deptName; }
            set { this.m_deptName = value; }
        }

        private bool m_isDirectory = false;
        /// <summary>
        /// 获取或设置是否是目录
        /// </summary>
        public bool IsDirectory
        {
            get { return this.m_isDirectory; }
            set { this.m_isDirectory = value; }
        }

        private string m_parentID = string.Empty;
        /// <summary>
        /// 获取或设置父目录ID号
        /// </summary>
        public string ParentID
        {
            get { return this.m_parentID; }
            set { this.m_parentID = value; }
        }

        private string m_inputCode = string.Empty;
        /// <summary>
        /// 获取或设置名称输入码
        /// </summary>
        public string InputCode
        {
            get { return this.m_inputCode; }
            set { this.m_inputCode = value; }
        }

        public StructElement()
        {
            this.m_createTime = this.DefaultTime;
            this.m_modifyTime = this.DefaultTime;
        }

        /// <summary>
        /// 重写过的ToString方法
        /// </summary>
        /// <returns>元素信息</returns>
        public override string ToString()
        {
            return this.m_elementName;
        }

        /// <summary>
        /// 设置元素类型
        /// </summary>
        /// <param name="type">数据类型数值</param>
        public void SetElementType(int type)
        {
            if (type == (int)ElementType.InputBox)
                this.m_elementType = ElementType.InputBox;
            else if (type == (int)ElementType.SimpleOption)
                this.m_elementType = ElementType.SimpleOption;
            else if (type == (int)ElementType.ComplexOption)
                this.m_elementType = ElementType.ComplexOption;
            else
                this.m_elementType = ElementType.None;
        }

        /// <summary>
        /// 生成一个元素的ID号
        /// </summary>
        /// <param name="szUserID">作者ID</param>
        /// <param name="elementType">元素类型</param>
        /// <returns>元素ID号</returns>
        public string MakeElementID(string szUserID, ElementType elementType)
        {
            if (szUserID == null) szUserID = string.Empty;
            Random rand = new Random();
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("{0}.{1}.{2}.{3}", szUserID.ToUpper()
                , (int)elementType, DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
