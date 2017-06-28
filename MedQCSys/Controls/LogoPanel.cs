using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using MedQCSys.Dialogs;
using EMRDBLib;
using Heren.Common.Libraries;

namespace MedQCSys.Controls
{
    public class LogoPanel : ToolStripPanel
    {
        private Image m_Image = null;
        /// <summary>
        /// 获取或设置背景Logo
        /// </summary>
        [Description("获取或设置背景Logo")]
        [DefaultValue(null)]
        public Image LogoImage
        {
            get { return this.m_Image; }
            set { this.m_Image = value; }
        }

        private Color m_GradientBeginColor = ProfessionalColors.ToolStripGradientEnd;
        /// <summary>
        /// 获取或设置背景渐变起始色
        /// </summary>
        [DefaultValue(typeof(ProfessionalColors), "ToolStripGradientEnd")]
        [Description("获取或设置背景渐变起始色")]
        public Color GradientBeginColor
        {
            get { return this.m_GradientBeginColor; }
            set { this.m_GradientBeginColor = value; }
        }

        private Color m_GradientEndColor = ProfessionalColors.ToolStripGradientBegin;
        /// <summary>
        /// 获取或设置背景渐变结束色
        /// </summary>
        [DefaultValue(typeof(ProfessionalColors), "ToolStripGradientBegin")]
        [Description("获取或设置背景渐变结束色")]
        public Color GradientEndColor
        {
            get { return this.m_GradientEndColor; }
            set { this.m_GradientEndColor = value; }
        }

        private LinearGradientMode m_eLinearGradientMode = LinearGradientMode.Horizontal;
        /// <summary>
        /// 获取或设置背景渐变模式
        /// </summary>
        [Description("获取或设置背景渐变模式")]
        [DefaultValue(LinearGradientMode.Horizontal)]
        public LinearGradientMode LinearGradientMode
        {
            get { return this.m_eLinearGradientMode; }
            set { this.m_eLinearGradientMode = value; }
        }

        public LogoPanel()
        {
            this.RowMargin = new Padding(0, 0, 0, 4);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint
                | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Invalidate();
            int index = 0;
            while (index < this.Controls.Count)
            {
                Control ctrl = this.Controls[index++];
                if (ctrl != null && !ctrl.IsDisposed)
                    ctrl.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.PaintBackground(e.Graphics);

            if (SystemParam.Instance.LocalConfigOption == null)
                return;
            if (string.IsNullOrEmpty(SystemParam.Instance.LocalConfigOption.HOSPITAL_NAME))
                return;
            SolidBrush brush = new SolidBrush(Color.DarkBlue);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Far;
            this.Font = new Font("Microsoft YaHei UI", 9.5f);
            RectangleF rect = new RectangleF(0, 6, this.Width - 8, 24);
            e.Graphics.DrawString(SystemParam.Instance.LocalConfigOption.HOSPITAL_NAME, this.Font, brush, rect, format);
            if (this.m_Image != null)
            {
                int nLeft = this.ClientSize.Width - this.m_Image.Width - 8;
                //当不显示工具条时，logo往左绘制
                bool result = SystemConfig.Instance.Get(SystemData.ConfigKey.SHOW_TOOL_STRIP, true);
                if (!result)
                    nLeft = nLeft - SystemParam.Instance.LocalConfigOption.HOSPITAL_NAME.Length * 15;
                e.Graphics.DrawImage(this.m_Image, nLeft, this.ClientSize.Height - this.m_Image.Height);
            }
            brush.Dispose();
            format.Dispose();

        }

        private void PaintBackground(Graphics graphics)
        {
            Rectangle clipRect = this.ClientRectangle;
            Color beginColor = Color.FromArgb(123, 164, 224);
            Color endColor = Color.FromArgb(226, 238, 255);
            LinearGradientMode gradientMode = LinearGradientMode.Vertical;
            LinearGradientBrush brush = new LinearGradientBrush(clipRect, beginColor, endColor, gradientMode);
            graphics.FillRectangle(brush, clipRect);
            brush.Dispose();
        }
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (this.m_Image == null)
                return;
            Rectangle rectLogo = Rectangle.Empty;
            rectLogo.Size = this.m_Image.Size;
            int left = this.ClientSize.Width - rectLogo.Width - 8;
          
            bool result = SystemConfig.Instance.Get(SystemData.ConfigKey.SHOW_TOOL_STRIP, true);
            if (!result)
            {
                left = left - SystemParam.Instance.LocalConfigOption.HOSPITAL_NAME.Length * 15;
            }
            rectLogo.Location = new Point(left, this.ClientSize.Height - rectLogo.Height);
            if (rectLogo.Contains(e.Location))
                (new SystemAboutForm()).ShowDialog();
        }
    }
}
