using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{


    /// <summary>
    /// 文档质控原子规则Entry对象定义
    /// </summary>
    [System.Serializable]
    public class MedQCEntry : DbTypeBase, ICloneable
    {
        private string m_szEntryID = string.Empty;          //原子规则Entry的ID
        private string m_szEntryName = string.Empty;        //原子规则Entry的名称
        private string m_szEntryType = string.Empty;        //原子规则Entry的类型
        private string m_szEntryDesc = string.Empty;        //原子规则Entry的描述
        private string m_szOperator = string.Empty;         //原子规则Entry的值和实际数据的运算符
        private string m_szEntryValue = string.Empty;       //原子规则Entry的值
        private string m_szValueType = string.Empty;        //原子规则Entry的值的数据类型

        /// <summary>
        /// 获取或设置原子规则Entry的ID
        /// </summary>
        public string EntryID
        {
            get { return this.m_szEntryID; }
            set { this.m_szEntryID = value; }
        }
        /// <summary>
        /// 获取或设置原子规则Entry的名称
        /// </summary>
        public string EntryName
        {
            get { return this.m_szEntryName; }
            set { this.m_szEntryName = value; }
        }
        /// <summary>
        /// 获取或设置原子规则Entry的类型
        /// </summary>
        public string EntryType
        {
            get { return this.m_szEntryType; }
            set { this.m_szEntryType = value; }
        }
        /// <summary>
        /// 获取或设置原子规则Entry的描述
        /// </summary>
        public string EntryDesc
        {
            get { return this.m_szEntryDesc; }
            set { this.m_szEntryDesc = value; }
        }
        /// <summary>
        /// 获取或设置原子规则Entry的值和实际数据的运算符
        /// </summary>
        public string Operator
        {
            get { return this.m_szOperator; }
            set { this.m_szOperator = value; }
        }
        /// <summary>
        /// 获取或设置原子规则Entry的值
        /// </summary>
        public string EntryValue
        {
            get { return this.m_szEntryValue; }
            set { this.m_szEntryValue = value; }
        }
        /// <summary>
        /// 获取或设置原子规则Entry的值的数据类型
        /// </summary>
        public string ValueType
        {
            get { return this.m_szValueType; }
            set { this.m_szValueType = value; }
        }

        public override string ToString()
        {
            return this.m_szEntryDesc;
        }

        public object Clone()
        {
            MedQCEntry qcEntry = new MedQCEntry();
            qcEntry.EntryID = this.m_szEntryID;
            qcEntry.EntryName = this.m_szEntryName;
            qcEntry.EntryType = this.m_szEntryType;
            qcEntry.EntryDesc = this.m_szEntryDesc;
            qcEntry.Operator = this.m_szOperator;
            qcEntry.EntryValue = this.m_szEntryValue;
            qcEntry.ValueType = this.m_szValueType;
            return qcEntry;
        }

        public string MakeEntryID()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            string szRand = rand.Next(0, 9999).ToString().PadLeft(4, '0');
            return string.Format("E{0}{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), szRand);
        }
    }
}
