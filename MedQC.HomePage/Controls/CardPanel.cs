using Heren.Common.Libraries;
using Heren.MedQC.Model.MedDoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.HomePage.Controls
{
    public class CardPanel:Control
    {
        protected bool m_autoZoom = false;
        /// <summary>
        /// 获取或设置病历自动缩放
        /// </summary>
        [Browsable(false)]
        public virtual bool AutoZoom
        {
            get { return this.m_autoZoom; }
            set { this.m_autoZoom = value; }
        }

        protected float m_zoom = 1f;
        /// <summary>
        /// 获取或设置病历自动缩放
        /// </summary>
        [Browsable(false)]
        public virtual float Zoom
        {
            get { return this.m_zoom; }
            set { this.m_zoom = value; }
        }

        private string m_Title;
        /// <summary>
        /// 卡片标题
        /// </summary>
        [
        Category("CardProperties"),
        Description("卡片标题"),
        Bindable(true)]
        public string Title
        {
            get { return m_Title; }
            set { this.m_Title = value; }
        }

        public event EventHandler SelectionChanged;
        protected virtual void OnSelectionChanged()
        {
            if (this.SelectionChanged != null)
                this.SelectionChanged(this, EventArgs.Empty);
        }

    }
}
