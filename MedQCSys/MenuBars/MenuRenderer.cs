// ***********************************************************
// 文档业务处理层主菜单控件外观润色器.
// Creator:YangMingkun  Date:2009-6-27
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MedQCSys.MenuBars
{
    internal class MenuRenderer : ToolStripProfessionalRenderer
    {
        public MenuRenderer()
        {
            //base.RoundedEdges = false;
            //base.ColorTable.UseSystemColors = true;
        }

        private void PaintBackground(Graphics g, Control control, Rectangle clipRect)
        {
            Control parent = control;

            while (true)
            {
                parent = parent.Parent;
                if (parent == null)
                {
                    return;
                }
                Rectangle screenRect = control.RectangleToScreen(clipRect);
                Rectangle parentRect = parent.RectangleToClient(screenRect);

                int dx = parentRect.Left - clipRect.Left;
                int dy = parentRect.Top - clipRect.Top;

                g.TranslateTransform(-dx, -dy, MatrixOrder.Append);
                this.PaintBackground(g, parentRect);
                g.TranslateTransform(dx, dy, MatrixOrder.Append);
            }
        }

        private void PaintBackground(Graphics g, Rectangle clipRect)
        {
            if (clipRect.Width <= 0 || clipRect.Height <= 0)
                return;
            Color beginColor = ProfessionalColors.ToolStripGradientEnd;
            Color endColor = ProfessionalColors.ToolStripGradientBegin;
            LinearGradientBrush brush = new LinearGradientBrush(clipRect, beginColor, endColor, LinearGradientMode.Horizontal);
            g.FillRectangle(brush, clipRect);
            brush.Dispose();
        }
        protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
        {
            Color beginColor = Color.FromArgb(226, 238, 255); 
            Color endColor = Color.FromArgb(123, 164, 224);
            LinearGradientBrush brush = new LinearGradientBrush(e.AffectedBounds, beginColor, endColor, LinearGradientMode.Horizontal);
            e.Graphics.FillRectangle(brush, e.AffectedBounds);
            brush.Dispose();
        }
        //这里不绘制菜单条背景色,使其支持透明色
        protected override void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        {
            //Rectangle clipRect = new Rectangle(new Point(0, 0), e.ToolStripPanel.Size);
            //this.PaintBackground(e.Graphics, e.ToolStripPanel, clipRect);
            //e.Handled = true;
        }

        //这里不绘制菜单条背景色,使其支持透明色
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Type type = e.ToolStrip.GetType();
            if (type != typeof(MqsMainMenu))
            {
                base.OnRenderToolStripBackground(e);
            }
            else
            {
                //this.PaintBackground(e.Graphics, e.ToolStrip, e.AffectedBounds);
            }
        }

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            //使菜单项文本始终居中显示
            Rectangle textRect = e.TextRectangle;
            textRect.Y = (e.Item.Bounds.Height - textRect.Height) / 2;
            e.TextRectangle = textRect;
            base.OnRenderItemText(e);
        }
    }
}
