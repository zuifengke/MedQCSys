using Heren.Common.Libraries;
using Heren.Common.RichEditor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedQCSys.Document
{

    internal class PageProperty
    {
        private string m_szPaperName = string.Empty;
        private float m_fWidth = 210;
        private float m_fHeight = 297;
        private bool m_bLandscape = false;
        private float m_fLeftMargin = 15;
        private float m_fRightMargin = 15;
        private float m_fTopMargin = 20;
        private float m_fBottomMargin = 20;

        private float m_fHeaderMargin = 0;
        private float m_fFooterMargin = 0;
        private float m_fBindMargin = 0;
        private PageLayout m_ePageLayout = PageLayout.Normal;
        private bool m_bDoubleSidePrint = false;

        /// <summary>
        /// 获取或设置纸张名字
        public string PaperName
        {
            get { return this.m_szPaperName; }
            set { this.m_szPaperName = value; }
        }

        /// <summary>
        /// 获取或设置纸张宽度
        /// </summary>
        public float Width
        {
            get { return this.m_fWidth; }
            set { this.m_fWidth = value; }
        }

        /// <summary>
        /// 获取或设置纸张高度
        /// </summary>
        public float Height
        {
            get { return this.m_fHeight; }
            set { this.m_fHeight = value; }
        }

        /// <summary>
        /// 获取或设置纸张是否是横向的
        /// </summary>
        public bool Landscape
        {
            get { return this.m_bLandscape; }
            set { this.m_bLandscape = value; }
        }

        /// <summary>
        /// 获取或设置页面左边距
        /// </summary>
        public float LeftMargin
        {
            get { return this.m_fLeftMargin; }
            set { this.m_fLeftMargin = value; }
        }

        /// <summary>
        /// 获取或设置页面右边距
        /// </summary>
        public float RightMargin
        {
            get { return this.m_fRightMargin; }
            set { this.m_fRightMargin = value; }
        }

        /// <summary>
        /// 获取或设置页面上边距
        /// </summary>
        public float TopMargin
        {
            get { return this.m_fTopMargin; }
            set { this.m_fTopMargin = value; }
        }

        /// <summary>
        /// 获取或设置页面下边距
        /// </summary>
        public float BottomMargin
        {
            get { return this.m_fBottomMargin; }
            set { this.m_fBottomMargin = value; }
        }

        /// <summary>
        /// 获取或设置页眉上边距
        /// </summary>
        public float HeaderMargin
        {
            get { return this.m_fHeaderMargin; }
            set { this.m_fHeaderMargin = value; }
        }

        /// <summary>
        /// 获取或设置页脚下边距
        /// </summary>
        public float FooterMargin
        {
            get { return this.m_fFooterMargin; }
            set { this.m_fFooterMargin = value; }
        }

        /// <summary>
        /// 获取或设置装订线边距
        /// </summary>
        public float BindMargin
        {
            get { return this.m_fBindMargin; }
            set { this.m_fBindMargin = value; }
        }

        /// <summary>
        /// 获取或设置页面布局
        /// </summary>
        public PageLayout PageLayout
        {
            get { return this.m_ePageLayout; }
            set { this.m_ePageLayout = value; }
        }

        /// <summary>
        /// 获取或设置纸张是否是横向的
        /// </summary>
        public bool DoubleSidePrint
        {
            get { return this.m_bDoubleSidePrint; }
            set { this.m_bDoubleSidePrint = value; }
        }

        /// <summary>
        /// 将属性对象转换为字符串
        /// </summary>
        /// <returns>属性字符串</returns>
        public override string ToString()
        {
            return this.GetPropertyText();
        }

        /// <summary>
        /// 获取元素基类定义属性的字符串
        /// </summary>
        /// <returns>属性的字符串</returns>
        public virtual string GetPropertyText()
        {
            StringBuilder sbPropertyText = new StringBuilder();
            sbPropertyText.Append("< ");
            if (!string.IsNullOrEmpty(this.m_szPaperName))
                sbPropertyText.Append(string.Format("pagetype=\"{0}\" ", this.m_szPaperName));
            if (this.m_bLandscape)
                sbPropertyText.Append("orientation=\"landscape\" ");
            else
                sbPropertyText.Append("orientation=\"portrait\" ");

            sbPropertyText.Append(string.Format("width=\"{0}\" ", this.m_fWidth));
            sbPropertyText.Append(string.Format("height=\"{0}\" ", this.m_fHeight));
            sbPropertyText.Append(string.Format("margin-top=\"{0}\" ", this.m_fTopMargin));
            sbPropertyText.Append(string.Format("margin-bottom=\"{0}\" ", this.m_fBottomMargin));
            sbPropertyText.Append(string.Format("margin-left=\"{0}\" ", this.m_fLeftMargin));
            sbPropertyText.Append(string.Format("margin-right=\"{0}\" ", this.m_fRightMargin));

            sbPropertyText.Append(string.Format("margin-header=\"{0}\" ", this.m_fHeaderMargin));
            sbPropertyText.Append(string.Format("margin-footer=\"{0}\" ", this.m_fFooterMargin));

            if (this.m_bDoubleSidePrint)
                sbPropertyText.Append("double-face=\"true\" ");
            else
                sbPropertyText.Append("double-face=\"false\" ");

            sbPropertyText.Append("draw-binding-line=\"false\" ");
            sbPropertyText.Append("draw-binding-line-type=\"0\" ");
            sbPropertyText.Append("draw-binding-line-width=\"0\" ");

            if (this.m_ePageLayout == PageLayout.TopMirrored)
                sbPropertyText.Append("bind-position=\"1\" ");
            else if (this.m_ePageLayout == PageLayout.LeftMirrored)
                sbPropertyText.Append("bind-position=\"2\" ");
            else
                sbPropertyText.Append("bind-position=\"0\" ");

            sbPropertyText.Append(string.Format("margin-bind=\"{0}\" ", this.m_fBindMargin));
            return sbPropertyText.Append("units=\"mm\"/>").ToString();
        }

        /// <summary>
        /// 设置指定的控件内部属性名称的属性值
        /// </summary>
        /// <param name="szPropertyName">控件内部属性名称</param>
        /// <param name="szPropertyValue">属性值</param>
        /// <returns>是否设置成功</returns>
        protected virtual bool SetPropertyValue(string szPropertyName, string szPropertyValue)
        {
            if (GlobalMethods.Misc.IsEmptyString(szPropertyName))
                return false;
            szPropertyName = szPropertyName.Trim();

            if (szPropertyName == "pagetype")
            {
                this.m_szPaperName = szPropertyValue;
                return true;
            }
            else if (szPropertyName == "orientation")
            {
                this.m_bLandscape = (szPropertyValue == "landscape");
                return true;
            }
            else if (szPropertyName == "width")
            {
                float.TryParse(szPropertyValue, out this.m_fWidth);
                return true;
            }
            else if (szPropertyName == "height")
            {
                float.TryParse(szPropertyValue, out this.m_fHeight);
                return true;
            }
            else if (szPropertyName == "margin-top")
            {
                float.TryParse(szPropertyValue, out this.m_fTopMargin);
                return true;
            }
            else if (szPropertyName == "margin-bottom")
            {
                float.TryParse(szPropertyValue, out this.m_fBottomMargin);
                return true;
            }
            else if (szPropertyName == "margin-left")
            {
                float.TryParse(szPropertyValue, out this.m_fLeftMargin);
                return true;
            }
            else if (szPropertyName == "margin-right")
            {
                float.TryParse(szPropertyValue, out this.m_fRightMargin);
                return true;
            }
            else if (szPropertyName == "margin-header")
            {
                float.TryParse(szPropertyValue, out this.m_fHeaderMargin);
                return true;
            }
            else if (szPropertyName == "margin-footer")
            {
                float.TryParse(szPropertyValue, out this.m_fFooterMargin);
                return true;
            }
            else if (szPropertyName == "margin-bind")
            {
                float.TryParse(szPropertyValue, out this.m_fBindMargin);
                return true;
            }
            else if (szPropertyName == "double-face")
            {
                this.m_bDoubleSidePrint = (szPropertyValue == "true");
                return true;
            }
            else if (szPropertyName == "bind-position")
            {
                this.m_ePageLayout = PageLayout.Normal;
                if (szPropertyValue == "1")
                    this.m_ePageLayout = PageLayout.TopMirrored;
                else if (szPropertyValue == "2")
                    this.m_ePageLayout = PageLayout.LeftMirrored;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 解析指定的以控件内部属性字符串形式表示的属性信息
        /// </summary>
        /// <param name="szPropertyText">控件内部属性字符串</param>
        public virtual void SetPropertyText(string szPropertyText)
        {
            if (GlobalMethods.Misc.IsEmptyString(szPropertyText))
                return;
            StringBuilder sbPropertyName = new StringBuilder();
            StringBuilder sbPropertyValue = new StringBuilder();

            int index = 0;
            int count = szPropertyText.Length;

            //引号已出现
            bool bHasQuoteSign = false;
            char quoteChar = char.Parse("\"");

            while (index < count)
            {
                char ch = szPropertyText[index];
                index++;

                if (ch == '<' || ch == '/' || ch == '>')
                    continue;

                if (ch != '=' && ch != quoteChar)
                {
                    if (bHasQuoteSign)
                        sbPropertyValue.Append(ch);
                    else
                        sbPropertyName.Append(ch);
                    if (index < count)
                        continue;
                }

                if (ch == quoteChar && !bHasQuoteSign)
                {
                    bHasQuoteSign = true;
                    continue;
                }
                if ((ch == quoteChar && bHasQuoteSign) || index == count)
                {
                    bHasQuoteSign = false;
                    if (sbPropertyName.Length > 0)
                        this.SetPropertyValue(sbPropertyName.ToString(), sbPropertyValue.ToString());
                    sbPropertyName.Remove(0, sbPropertyName.Length);
                    sbPropertyValue.Remove(0, sbPropertyValue.Length);
                }
            }
        }
    }
}
