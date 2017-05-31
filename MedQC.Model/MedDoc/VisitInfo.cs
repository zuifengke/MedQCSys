using EMRDBLib;
using Heren.Common.Libraries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMRDBLib
{

    /// <summary>
    /// 就诊信息
    /// </summary>
    public class VisitInfo : ICloneable
    {
        private string m_szID = string.Empty;       //就诊号
        private string m_szInpID = string.Empty;     //住院号
        private VisitType m_eType = VisitType.OP;   //就诊类型：0门诊 1急诊 2入院
        private DateTime m_dtTime = DateTime.Now;   //就诊时间
        private string m_szDeptCode = string.Empty; //就诊科室码
        private string m_szDeptName = string.Empty; //就诊科室名称
        private string m_szWardCode = string.Empty; //就诊病区码
        private string m_szWardName = string.Empty; //就诊病区名称
        private string m_szCareCode = string.Empty; //就诊护理单元码
        private string m_szCareName = string.Empty; //就诊护理单元名称
        private string m_szBedCode = string.Empty;  //床位码
        /// <summary>
        /// 获取或设置就诊号(对于住院：传入第几次入院;对于门诊：传入门诊序号)
        /// </summary>
        public string ID
        {
            get { return this.m_szID; }
            set { this.m_szID = value; }
        }
        /// <summary>
        /// 获取或设置住院号
        /// </summary>
        public string InpID
        {
            get { return this.m_szInpID; }
            set { this.m_szInpID = value; }
        }
        /// <summary>
        /// 获取或设置就诊类型
        /// </summary>
        public VisitType Type
        {
            get { return this.m_eType; }
            set { this.m_eType = value; }
        }
        /// <summary>
        /// 获取或设置就诊时间
        /// </summary>
        public DateTime Time
        {
            get { return this.m_dtTime; }
            set { this.m_dtTime = value; }
        }
        /// <summary>
        /// 获取或设置就诊科室码
        /// </summary>
        public string DeptCode
        {
            get { return this.m_szDeptCode; }
            set { this.m_szDeptCode = value; }
        }
        /// <summary>
        /// 获取或设置就诊科室名称
        /// </summary>
        public string DeptName
        {
            get { return this.m_szDeptName; }
            set { this.m_szDeptName = value; }
        }
        /// <summary>
        /// 获取或设置就诊病区码
        /// </summary>
        public string WardCode
        {
            get { return this.m_szWardCode; }
            set { this.m_szWardCode = value; }
        }
        /// <summary>
        /// 获取或设置就诊病区名称
        /// </summary>
        public string WardName
        {
            get { return this.m_szWardName; }
            set { this.m_szWardName = value; }
        }
        /// <summary>
        /// 获取或设置床位，设置了Ward后必要
        /// </summary>
        public string BedCode
        {
            get { return this.m_szBedCode; }
            set { this.m_szBedCode = value; }
        }
        /// <summary>
        /// 获取或设置就诊护理单元码
        /// </summary>
        public string CareCode
        {
            get { return this.m_szCareCode; }
            set { this.m_szCareCode = value; }
        }
        /// <summary>
        /// 获取或设置就诊护理单元名称
        /// </summary>
        public string CareName
        {
            get { return this.m_szCareName; }
            set { this.m_szCareName = value; }
        }

        public VisitInfo()
        {
            this.Initialize();
        }

        public object Clone()
        {
            VisitInfo visitInfo = new VisitInfo();
            visitInfo.ID = this.m_szID;
            visitInfo.InpID = this.m_szInpID;
            visitInfo.Type = this.m_eType;
            visitInfo.Time = this.m_dtTime;
            visitInfo.DeptCode = this.m_szDeptCode;
            visitInfo.DeptName = this.m_szDeptName;
            visitInfo.WardCode = this.m_szWardCode;
            visitInfo.WardName = this.m_szWardName;
            visitInfo.CareCode = this.m_szCareCode;
            visitInfo.CareName = this.m_szCareName;
            visitInfo.BedCode = this.m_szBedCode;
            return visitInfo;
        }

        /// <summary>
        /// 初始化为缺省值
        /// </summary>
        public void Initialize()
        {
            this.m_szID = string.Empty;
            this.m_szInpID = string.Empty;
            this.m_eType = VisitType.OP;
            this.m_dtTime = DateTime.Now;
            this.m_szDeptCode = string.Empty;
            this.m_szDeptName = string.Empty;
            this.m_szWardCode = string.Empty;
            this.m_szWardName = string.Empty;
            this.m_szBedCode = string.Empty;
            this.m_szCareCode = string.Empty;
            this.m_szCareName = string.Empty;
        }
        /// <summary>
        /// 验证VisitInfo数据的合法性(抛出异常信息)
        /// </summary>
        public static void Validate(VisitInfo visitInfo)
        {
            if (visitInfo == null)
                throw new Exception("病人就诊信息数据不能为空!");
            if (GlobalMethods.Misc.IsEmptyString(visitInfo.ID))
                throw new Exception("病人就诊ID参数不能为空!");
            if (GlobalMethods.Misc.IsEmptyString(visitInfo.DeptCode))
                throw new Exception("病人就诊科室代码参数不能为空!");
            if (GlobalMethods.Misc.IsEmptyString(visitInfo.DeptName))
                throw new Exception("病人就诊科室名称参数不能为空!");
        }
        /// <summary>
        /// 比较两个VisitInfo对象
        /// </summary>
        /// <param name="clsVisitInfo">比较的VisitInfo对象</param>
        /// <returns>bool</returns>
        public bool Equals(VisitInfo clsVisitInfo)
        {
            if (clsVisitInfo == null)
                return false;

            return ((this.m_szID == clsVisitInfo.ID)
                && (this.m_szInpID == clsVisitInfo.InpID)
                && (this.m_eType == clsVisitInfo.Type)
                && (DateTime.Compare(this.m_dtTime, clsVisitInfo.Time) == 0)
                && (this.m_szDeptCode == clsVisitInfo.DeptCode)
                && (this.m_szDeptName == clsVisitInfo.DeptName)
                && (this.m_szWardCode == clsVisitInfo.WardCode)
                && (this.m_szWardName == clsVisitInfo.WardName)
                && (this.m_szBedCode == clsVisitInfo.BedCode)
                && (this.m_szCareCode == clsVisitInfo.CareCode)
                && (this.m_szCareName == clsVisitInfo.CareName));
        }
        /// <summary>
        /// 根据就诊类型代码获取就诊类型枚举
        /// </summary>
        /// <param name="shType">就诊类型代码</param>
        /// <returns>bool</returns>
        public static bool GetTypeEnum(string szType, ref VisitType eVisitType)
        {
            if (GlobalMethods.Misc.IsEmptyString(szType))
                return false;
            try
            {
                short shType = short.Parse(szType);
                eVisitType = (VisitType)shType;
            }
            catch
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 获取就诊类型对应的所写
        /// </summary>
        /// <returns></returns>
        public static string GetVisitTypeStr(VisitInfo visitInfo)
        {
            if (visitInfo == null)
                return SystemData.VisitType.IP;
            if (visitInfo.Type == VisitType.OP || visitInfo.Type == VisitType.EP)
                return SystemData.VisitType.OP;
            else
                return SystemData.VisitType.IP;
        }
        /// <summary>
        /// 已重写
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return this.m_szID;
        }
        /// <summary>
        /// 把就诊信息对象转换成就诊信息字符串
        /// </summary>
        /// <param name="visitInfo">就诊信息对象</param>
        /// <param name="szSplitChar">就诊信息字符串</param>
        /// <returns>string</returns>
        public static string GetStrFromVisitInfo(VisitInfo visitInfo, string szSplitChar)
        {
            if (visitInfo == null)
                visitInfo = new VisitInfo();

            StringBuilder sbVisitInfo = new StringBuilder();
            sbVisitInfo.Append(visitInfo.ID);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.InpID);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(((int)visitInfo.Type).ToString());
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.Time);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.DeptCode);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.DeptName);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.WardCode);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.WardName);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.CareCode);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.CareName);
            sbVisitInfo.Append(szSplitChar);
            sbVisitInfo.Append(visitInfo.BedCode);
            sbVisitInfo.Append(szSplitChar);

            return sbVisitInfo.ToString();
        }
        /// <summary>
        /// 把字符串表达的就诊信息转换为就诊信息对象
        /// </summary>
        /// <param name="szVisitData">字符串表达的就诊信息</param>
        /// <param name="szSplitChar">分隔符</param>
        /// <returns>就诊信息对象</returns>
        public static VisitInfo GetVisitInfoFromStr(string szVisitData, string szSplitChar)
        {
            VisitInfo visitInfo = new VisitInfo();

            string[] arrVisitData = szVisitData.Split(new string[] { szSplitChar }, StringSplitOptions.None);

            if (arrVisitData.Length > 0)
                visitInfo.ID = arrVisitData[0];

            if (arrVisitData.Length > 1)
                visitInfo.InpID = arrVisitData[1];

            if (arrVisitData.Length > 2)
            {
                VisitType eType = VisitType.OP;
                if (!VisitInfo.GetTypeEnum(arrVisitData[2], ref eType))
                {
                    throw new Exception("就诊类型参数非法!");
                }
                visitInfo.Type = eType;
            }

            if (arrVisitData.Length > 3)
            {
                try
                {
                    visitInfo.Time = DateTime.Parse(arrVisitData[3]);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.WriteLog("VisitInfo.GetVisitInfoFromStr", new string[] { "szVisitData" }
                        , new object[] { szVisitData }, ex);
                    throw new Exception("就诊时间参数非法!");
                }
            }

            if (arrVisitData.Length > 4)
                visitInfo.DeptCode = arrVisitData[4];

            if (arrVisitData.Length > 5)
                visitInfo.DeptName = arrVisitData[5];

            if (arrVisitData.Length > 6)
                visitInfo.WardCode = arrVisitData[6];

            if (arrVisitData.Length > 7)
                visitInfo.WardName = arrVisitData[7];

            if (arrVisitData.Length > 8)
                visitInfo.CareCode = arrVisitData[8];

            if (arrVisitData.Length > 9)
                visitInfo.CareName = arrVisitData[9];

            if (arrVisitData.Length > 10)
                visitInfo.BedCode = arrVisitData[10];

            return visitInfo;
        }
    }
}
