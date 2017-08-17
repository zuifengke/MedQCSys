// ***********************************************************
// 数据库访问基础方法类之动态SQL参数结构体
// Creator:YangMingkun  Date:2009-6-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Text;
using System.Data;
using System.Runtime.InteropServices;

namespace EMRDBLib.DbAccess
{
    /// <summary>
    /// 动态SQL参数结构体
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public class DbParameter
    {
        private string m_name = null;
        /// <summary>
        /// 获取参数名称
        /// </summary>
        public string Name
        {
            get { return this.m_name; }
        }

        private object m_value = null;
        /// <summary>
        /// 获取或设置参数值
        /// </summary>
        public object Value
        {
            get { return this.m_value; }
            set { this.SetValue(value); }
        }

        private DbType m_dataType = 0;
        /// <summary>
        /// 获取参数数据类型
        /// </summary>
        public DbType DataType
        {
            get { return this.m_dataType; }
        }

        private int m_size = 0;
        /// <summary>
        /// 获取参数数据大小
        /// </summary>
        public int Size
        {
            get { return this.m_size; }
            set { this.m_size = value; }
        }

        private string m_sourceColumn = null;
        /// <summary>
        /// 获取或设置源列名
        /// </summary>
        public string SourceColumn
        {
            get { return this.m_sourceColumn; }
            set { this.m_sourceColumn = value; }
        }

        private ParameterDirection m_direction = ParameterDirection.Input;
        /// <summary>
        /// 获取或设置参数传递方向
        /// </summary>
        public ParameterDirection Direction
        {
            get { return this.m_direction; }
        }

        /// <summary>
        /// 设置参数值.
        /// 并根据参数值自动设置数据库值类型
        /// </summary>
        /// <param name="value">参数值</param>
        private void SetValue(object value)
        {
            this.m_value = value;
            if (value is int)
                this.m_dataType = DbType.Int32;
            else if (value is float)
                this.m_dataType = DbType.Single;
            else if (value is DateTime)
                this.m_dataType = DbType.DateTime;
            else if (value is byte[])
                this.m_dataType = DbType.Binary;
            else
                this.m_dataType = DbType.String;
        }

        /// <summary>
        /// 实例化数据库字符串类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数字符串类型值</param>
        public DbParameter(string name, string value)
        {
            this.m_name = name;
            this.Value = value;
        }

        /// <summary>
        /// 实例化数据库整数类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数整数类型值</param>
        public DbParameter(string name, int value)
        {
            this.m_name = name;
            this.Value = value;
        }

        /// <summary>
        /// 实例化数据库浮点类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数浮点类型值</param>
        public DbParameter(string name, float value)
        {
            this.m_name = name;
            this.Value = value;
        }

        /// <summary>
        /// 实例化数据库字节类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数字节类型值</param>
        public DbParameter(string name, byte[] value)
        {
            this.m_name = name;
            this.Value = value;
        }

        /// <summary>
        /// 实例化数据库日期时间类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数日期时间类型值</param>
        public DbParameter(string name, DateTime value)
        {
            this.m_name = name;
            this.Value = value;
        }

        /// <summary>
        /// 实例化数据库未明确指定类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">未明确指定类型值</param>
        public DbParameter(string name, object value)
        {
            this.m_name = name;
            this.Value = value;
        }

        /// <summary>
        /// 实例化数据库未明确指定类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">未明确指定类型值</param>
        /// <param name="type">指定值的数据类型</param>
        public DbParameter(string name, object value, DbType type)
        {
            this.m_name = name;
            this.Value = value;
            this.m_dataType = type;
        }

        /// <summary>
        /// 实例化数据库字符串类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数字符串类型值</param>
        /// <param name="direction">参数方向</param>
        public DbParameter(string name, string value, ParameterDirection direction)
        {
            this.m_name = name;
            this.Value = value;
            this.m_direction = direction;
        }

        /// <summary>
        /// 实例化数据库整数类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数整数类型值</param>
        /// <param name="direction">参数方向</param>
        public DbParameter(string name, int value, ParameterDirection direction)
        {
            this.m_name = name;
            this.Value = value;
            this.m_direction = direction;
        }

        /// <summary>
        /// 实例化数据库浮点类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数浮点类型值</param>
        /// <param name="direction">参数方向</param>
        public DbParameter(string name, float value, ParameterDirection direction)
        {
            this.m_name = name;
            this.Value = value;
            this.m_direction = direction;
        }

        /// <summary>
        /// 实例化数据库字节类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数字节类型值</param>
        /// <param name="direction">参数方向</param>
        public DbParameter(string name, byte[] value, ParameterDirection direction)
        {
            this.m_name = name;
            this.Value = value;
            this.m_direction = direction;
        }

        /// <summary>
        /// 实例化数据库日期时间类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数日期时间类型值</param>
        /// <param name="direction">参数方向</param>
        public DbParameter(string name, DateTime value, ParameterDirection direction)
        {
            this.m_name = name;
            this.Value = value;
            this.m_direction = direction;
        }

        /// <summary>
        /// 实例化数据库未明确指定类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">未明确指定类型值</param>
        /// <param name="direction">参数方向</param>
        public DbParameter(string name, object value, ParameterDirection direction)
        {
            this.m_name = name;
            this.Value = value;
            this.m_direction = direction;
        }

        /// <summary>
        /// 实例化数据库未明确指定类型参数对象
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">未明确指定类型值</param>
        /// <param name="direction">参数方向</param>
        /// <param name="type">指定值的数据类型</param>
        public DbParameter(string name, object value, DbType type, ParameterDirection direction)
        {
            this.m_name = name;
            this.Value = value;
            this.m_dataType = type;
            this.m_direction = direction;
        }
    }
}
