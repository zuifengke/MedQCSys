// ***********************************************************
// 病案质控系统用于患者列表窗口中显示患者信息列表的控件.
// Creator:YangMingkun  Date:2009-11-3
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using EMRDBLib;
using System.Collections.Generic;

namespace MedQCSys.Controls.PatInfoList
{
    internal class PatInfoList : Panel
    {
        /// <summary>
        /// 当用户切换选中项时触发
        /// </summary>
        [Description("当用户切换选中项时触发")]
        public event EventHandler CardSelectedChanged = null;

        /// <summary>
        /// 当用户切换选中项时触发
        /// </summary>
        [Description("当用户切换选中项时触发")]
        public event CancelEventHandler CardSelectedChanging = null;

        /// <summary>
        /// 当用户单击列表项时触发
        /// </summary>
        [Description("当用户单击列表项时触发")]
        public event MouseEventHandler CardMouseClick = null;
        public List<PatInfoCard> PatInfoCards { get; set; }
        private PatInfoCard m_selectedCard = null;
        /// <summary>
        /// 获取或设置当前选中的患者信息卡
        /// </summary>
        [Browsable(false)]
        [Description("获取或设置当前选中的患者信息卡")]
        public PatInfoCard SelectedCard
        {
            get { return this.m_selectedCard; }
            set
            {
                if (this.m_selectedCard == value)
                    return;

                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                if (this.CardSelectedChanging != null)
                    this.CardSelectedChanging(this, cancelEventArgs);
                if (cancelEventArgs.Cancel)
                    return;

                this.SuspendLayout();
                if (this.m_selectedCard != null && !this.m_selectedCard.IsDisposed)
                    this.m_selectedCard.Selected = false;
                this.m_selectedCard = value;
                if (this.m_selectedCard != null && !this.m_selectedCard.IsDisposed)
                    this.m_selectedCard.Selected = true;
                this.ResumeLayout(true);

                if (this.m_selectedCard != null)
                    this.ScrollControlIntoView(this.m_selectedCard);

                this.Update();
                if (this.CardSelectedChanged != null)
                    this.CardSelectedChanged(this, EventArgs.Empty);
            }
        }

        public PatInfoList()
        {
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.Fixed3D;
            this.AutoScroll = true;
            this.Padding = new Padding(1);
            if (this.PatInfoCards == null)
                this.PatInfoCards = new List<PatInfoCard>();
        }
        /// <summary>
        /// 当焦点控件不可见时自动滚动到可见区域.
        /// 重写此方法也用于取消当点击子控件时自动滚动的行为
        /// </summary>
        /// <param name="activeControl">焦点控件</param>
        /// <returns>滚动位置</returns>
        protected override Point ScrollToControl(Control activeControl)
        {
            return this.AutoScrollPosition;
        }
        public PatInfoCard AddPatInfo(EMRDBLib.PatVisitInfo patVisitLog)
        {
            PatInfoCard patInfoCard = new PatInfoCard();
            patInfoCard.Dock = DockStyle.Top;
           // patInfoCard.MinimumSize = new Size(500, 28);
            patInfoCard.PatVisitLog = patVisitLog;
            patInfoCard.MouseUp += new MouseEventHandler(this.patInfoCard_MouseUp);
            patInfoCard.Tag = patVisitLog;
            this.Controls.Add(patInfoCard);
            if (this.PatInfoCards == null)
                this.PatInfoCards = new List<PatInfoCard>();
            this.PatInfoCards.Add(patInfoCard);
            return patInfoCard;
        }

        public void ClearPatInfo()
        {
            this.SuspendLayout();
            this.Controls.Clear();
            this.PatInfoCards.Clear();
            this.ResumeLayout(true);
        }

        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            this.Update();
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            this.Focus();
        }

        private void patInfoCard_MouseUp(object sender, MouseEventArgs e)
        {
            Control ctrl = sender as Control;
            if (!ctrl.ClientRectangle.Contains(e.Location))
                return;
            this.SelectedCard = sender as PatInfoCard;
            if (this.CardMouseClick != null) this.CardMouseClick(sender, e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
    }
}
