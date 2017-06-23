using Heren.Common.Libraries;
using Heren.Common.RichEditor;
using Heren.MedQC.Model.MedDoc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Heren.MedQC.Frame.Document
{
    public class DocumentEditor:Control
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

        public event EventHandler SelectionChanged;
        protected virtual void OnSelectionChanged()
        {
            if (this.SelectionChanged != null)
                this.SelectionChanged(this, EventArgs.Empty);
        }
        #region 元素操作
        public virtual StructElement GetCurrentElement()
        {
            return null;
        }

        #endregion
        #region 模板操作
        public virtual bool OpenTemplet(byte[] fileData)
        {
            return false;
        }

        /// <summary>
        /// 获取或设置病历页面设置
        /// </summary>
        [Browsable(false)]
        public virtual PageSettings PageSettings
        {
            get { return new PageSettings(); }
        }
        #endregion
        #region 文档操作
        public virtual bool OpenDocument(byte[] fileData)
        {
            return false;
        }

        /// <summary>
        /// 应用文档自动缩放功能
        /// </summary>
        public virtual void ApplyAutoZoom()
        {
            if (!this.AutoZoom || this.PageSettings == null)
                return;
            float mmWidth = this.PageSettings.Width;
            if (this.PageSettings.Landscape)
                mmWidth = this.PageSettings.Height;
            int width = GlobalMethods.Convert.MMToPixel(mmWidth, false);
            if (this.Width >= width + 48)
            {
                if (this.Zoom < 1f)
                    this.Zoom = 1f;
            }
            else
            {
                float zoomWidth = (float)(this.Width - 48);
                float zoomValue = (float)Math.Round(zoomWidth / width, 2);
                if (zoomValue < 0.1f)
                    zoomValue = 0.1f;
                this.Zoom = zoomValue;
            }
        }

        #endregion

    }
}
