using Heren.MedQC.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Core
{
    public class AbstractCommand:ICommand
    {
        /// <summary>
        /// 默认为
        /// </summary>
        protected string m_name = "";
        /// <summary>
        /// 获取命令的名称
        /// </summary>
        [Description("获取命令的名称")]
        public virtual string Name
        {
            get { return this.m_name; }
        }

        public virtual bool Execute(object param, object data)
        {
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="data"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public virtual bool Execute(object param, object data, out object result)
        {
            result = null;
            return false;
        }
    }
}
