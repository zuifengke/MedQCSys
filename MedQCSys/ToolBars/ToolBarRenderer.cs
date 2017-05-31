// ***********************************************************
// 业务处理层工具条外观润色器.
// Creator:YangMingkun  Date:2009-7-4
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MedQCSys.ToolBars
{
    internal class ToolBarRenderer : ToolStripProfessionalRenderer
    {
        public ToolBarRenderer()
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
            Color beginColor = Color.FromArgb(226, 238, 255);
            Color endColor = Color.FromArgb(123, 164, 224);
            LinearGradientBrush brush = new LinearGradientBrush(clipRect, beginColor, endColor, LinearGradientMode.Vertical);
            g.FillRectangle(brush, clipRect);
            brush.Dispose();
        }

        //protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        //{
        //    ToolStripOverflowButton overflowButton = e.Item as ToolStripOverflowButton;
        //    Color beginColor = Color.LightGray;
        //    Color endColor = Color.Gray;
        //    Rectangle clipRect = new Rectangle(0,0,e.Item.Width,e.Item.Height);
        //    LinearGradientBrush brush = new LinearGradientBrush(clipRect, beginColor, endColor, LinearGradientMode.Vertical);
        //    e.Graphics.FillRectangle(brush, clipRect);
        //    brush.Dispose();
        //}

        //不绘制工具条边界
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
        }

        protected override void OnRenderToolStripPanelBackground(ToolStripPanelRenderEventArgs e)
        {
            Rectangle clipRect = new Rectangle(new Point(0, 0), e.ToolStripPanel.Size);
            this.PaintBackground(e.Graphics, e.ToolStripPanel, clipRect);
            e.Handled = true;
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            Type type = e.ToolStrip.GetType();
            if (type != typeof(MqsToolStripBase) && type != typeof(MainToolStrip))
            {
                base.OnRenderToolStripBackground(e);
            }
            else
            {
                this.PaintBackground(e.Graphics, e.ToolStrip, e.AffectedBounds);
            }
        }
    }
}
