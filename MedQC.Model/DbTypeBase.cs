using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{
    /// <summary>
    /// 对象基类
    /// </summary>
    [Serializable]
    public class DbTypeBase : Object, ICloneable
    {
        /// <summary>
        /// 获取缺省时间
        /// </summary>
        public DateTime DefaultTime
        {
            get { return DateTime.Parse("1900-1-1"); }
            set { }
        }

        /// <summary>
        /// 获取缺省时间
        /// </summary>
        public DateTime DefaultTime2
        {
            get { return DateTime.Parse("0001-1-1"); }
            set { }
        }
        public object Clone()
        {
            object instance = Activator.CreateInstance(this.GetType());
            GlobalMethods.Reflect.CopyProperties(this, instance);
            return instance;
        }
    }

}
