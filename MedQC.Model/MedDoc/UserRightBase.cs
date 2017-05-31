using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace EMRDBLib
{


    /// <summary>
    /// 用户权限基类
    /// </summary>
    public abstract class UserRightBase : DbTypeBase
    {
        private string m_szUserID = string.Empty;
        /// <summary>
        /// 获取或设置用户代码
        /// </summary>
        public string UserID
        {
            get { return this.m_szUserID; }
            set { this.m_szUserID = value; }
        }

        private string m_szRightDesc = string.Empty;
        /// <summary>
        /// 获取或设置权限描述
        /// </summary>
        public string RightDesc
        {
            get { return this.m_szRightDesc; }
            set { this.m_szRightDesc = value; }
        }

        protected UserRightType m_eRightType = UserRightType.MedDoc;
        /// <summary>
        /// 获取或设置权限类型 编辑器-MEDDOC 质控-MRQC
        /// </summary>
        public UserRightType RightType
        {
            set { }
            get { return this.m_eRightType; }
        }

        /// <summary>
        /// 获取权限类型名称
        /// </summary>
        public static string GetRightTypeName(UserRightType rightType)
        {
            if (rightType == UserRightType.MedQC)
                return "MEDQC";
            else
                return "MEDDOC";
        }

        /// <summary>
        /// 创建指定的用户权限
        /// </summary>
        /// <param name="rightType">用户权限类型</param>
        /// <returns>MDSDBLib.UserRightBase</returns>
        public static UserRightBase Create(UserRightType rightType)
        {
            if (rightType == UserRightType.MedDoc)
                return new UserRight();
            else
                return new QCUserRight();
        }

        /// <summary>
        /// 获取二进制位表示的用户权限代码
        /// </summary>
        /// <returns>权限代码</returns>
        public string GetRightCode()
        {
            PropertyInfo[] propertyInfos = this.GetType().GetProperties();
            if (propertyInfos == null || propertyInfos.Length <= 0)
                return string.Empty;

            StringBuilder sbRightCode = new StringBuilder();
            for (int index = 0; index < propertyInfos.Length; index++)
            {
                PropertyInfo propertyInfo = propertyInfos[index];
                if (propertyInfo.PropertyType != typeof(RightInfo))
                    continue;
                RightInfo rightInfo = propertyInfo.GetValue(this, null) as RightInfo;
                if (rightInfo == null)
                    continue;

                if (sbRightCode.Length <= rightInfo.Index)
                {
                    int count = rightInfo.Index + 1 - sbRightCode.Length;
                    sbRightCode.Append(string.Empty.PadRight(count, '0'));
                }
                if (rightInfo.Value)
                    sbRightCode.Replace('0', '1', rightInfo.Index, 1);
            }
            return sbRightCode.ToString();
        }

        /// <summary>
        /// 设置二进制位表示的权限代码
        /// </summary>
        /// <param name="szRightCode">权限代码</param>
        public void SetRightCode(string szRightCode)
        {
            int nLength = 0;
            if (!string.IsNullOrEmpty(szRightCode))
                nLength = szRightCode.Length;

            PropertyInfo[] propertyInfos = this.GetType().GetProperties();
            if (propertyInfos == null || propertyInfos.Length <= 0)
                return;
            for (int index = 0; index < propertyInfos.Length; index++)
            {
                PropertyInfo propertyInfo = propertyInfos[index];
                if (propertyInfo.PropertyType != typeof(RightInfo))
                    continue;
                RightInfo rightInfo = propertyInfo.GetValue(this, null) as RightInfo;
                if (rightInfo == null)
                    continue;
                rightInfo.Value = false;//默认为false
                if (nLength > rightInfo.Index)
                    rightInfo.Value = (szRightCode[rightInfo.Index] == '1');
            }
        }
    }
}
