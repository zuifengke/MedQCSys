using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MedQC.Test
{
    public class CardPanel : Control,IContainer
    {
        private ContentAlignment alignmentValue = ContentAlignment.MiddleLeft;
        [
          Category("Alignment")
        , Description("Specifies the alignment of text.")
        ]
        public ContentAlignment TextAlignment
        {

            get
            {
                return alignmentValue;
            }
            set
            {
                alignmentValue = value;

　　　　　　　　　　　　　　　 // The Invalidate method invokes the OnPaint method described 
　　　　　　　　　　　　　　　 // in step 3.
　　　　　　　　　　　　　　　 Invalidate();
            }
        }
        private String text = string.Empty;
        [
          Category("Card")
         , Description("标题文本")
         ,DefaultValue("标题")
        ]
        public  String TitleText
        {

            get
            {
                return text;
            }
            set
            {
                text = value;

　　　　　　　　　　　　　　　 // The Invalidate method invokes the OnPaint method described 
　　　　　　　　　　　　　　　 // in step 3.
　　　　　　　　　　　　　　　 Invalidate();
            }
        }

        public ComponentCollection Components => throw new NotImplementedException();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            StringFormat style = new StringFormat();
            style.Alignment = StringAlignment.Near;
            switch (alignmentValue)
            {
                case ContentAlignment.MiddleLeft:
                    style.Alignment = StringAlignment.Near;
                    break;
                case ContentAlignment.MiddleRight:
                    style.Alignment = StringAlignment.Far;
                    break;
                case ContentAlignment.MiddleCenter:
                    style.Alignment = StringAlignment.Center;
                    break;
            }

　　　　　　　　　　　 // Call the DrawString method of the System.Drawing class to write　　 
　　　　　　　　　　　 // text. Text and ClientRectangle are properties inherited from
　　　　　　　　　　　 // Control.
　　　　　　　　　　　 e.Graphics.DrawString(this.TitleText, Font, new SolidBrush(ForeColor),
                         ClientRectangle, style);

        }

        public void Add(IComponent component)
        {
            
        }

        public void Add(IComponent component, string name)
        {
            
        }

        public void Remove(IComponent component)
        {
            
        }
    }
}
