namespace MedQC.ChatClient
{
    partial class ChatClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatClient));
            this.vTreeChating = new Heren.Common.Controls.VirtualTreeView.VirtualTree();
            this.vTreeAlluser = new Heren.Common.Controls.VirtualTreeView.VirtualTree();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rtbView = new System.Windows.Forms.RichTextBox();
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.rtbEdit = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.聊天记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导入截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabChating = new System.Windows.Forms.TabPage();
            this.tabAllUser = new System.Windows.Forms.TabPage();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabChating.SuspendLayout();
            this.tabAllUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // vTreeChating
            // 
            this.vTreeChating.AutoScrollMinSize = new System.Drawing.Size(234, 24);
            this.vTreeChating.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vTreeChating.Location = new System.Drawing.Point(3, 3);
            this.vTreeChating.Name = "vTreeChating";
            this.vTreeChating.Size = new System.Drawing.Size(234, 552);
            this.vTreeChating.TabIndex = 4;
            this.vTreeChating.NodeMouseDoubleClick += new Heren.Common.Controls.VirtualTreeView.VirtualTreeEventHandler(this.vTreeChating_NodeMouseDoubleClick);
            // 
            // vTreeAlluser
            // 
            this.vTreeAlluser.AutoScrollMinSize = new System.Drawing.Size(234, 24);
            this.vTreeAlluser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vTreeAlluser.Location = new System.Drawing.Point(3, 3);
            this.vTreeAlluser.Name = "vTreeAlluser";
            this.vTreeAlluser.Size = new System.Drawing.Size(234, 552);
            this.vTreeAlluser.TabIndex = 1;
            this.vTreeAlluser.NodeMouseDoubleClick += new Heren.Common.Controls.VirtualTreeView.VirtualTreeEventHandler(this.vTreeAlluser_NodeMouseDoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Location = new System.Drawing.Point(253, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnSendMsg);
            this.splitContainer1.Panel2.Controls.Add(this.rtbEdit);
            this.splitContainer1.Panel2.Controls.Add(this.menuStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(703, 562);
            this.splitContainer1.SplitterDistance = 315;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 2;
            // 
            // rtbView
            // 
            this.rtbView.BackColor = System.Drawing.Color.White;
            this.rtbView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbView.HideSelection = false;
            this.rtbView.Location = new System.Drawing.Point(0, 0);
            this.rtbView.Name = "rtbView";
            this.rtbView.ReadOnly = true;
            this.rtbView.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.rtbView.Size = new System.Drawing.Size(703, 315);
            this.rtbView.TabIndex = 0;
            this.rtbView.Text = "";
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMsg.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSendMsg.Image = global::MedQC.ChatClient.Properties.Resources.SendMessge;
            this.btnSendMsg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendMsg.Location = new System.Drawing.Point(631, 209);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(68, 30);
            this.btnSendMsg.TabIndex = 6;
            this.btnSendMsg.Text = "发送";
            this.btnSendMsg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSendMsg.UseVisualStyleBackColor = false;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // rtbEdit
            // 
            this.rtbEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbEdit.Location = new System.Drawing.Point(1, 28);
            this.rtbEdit.Name = "rtbEdit";
            this.rtbEdit.Size = new System.Drawing.Size(701, 214);
            this.rtbEdit.TabIndex = 1;
            this.rtbEdit.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.聊天记录ToolStripMenuItem,
            this.导入截图ToolStripMenuItem,
            this.截图ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(703, 25);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 聊天记录ToolStripMenuItem
            // 
            this.聊天记录ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("聊天记录ToolStripMenuItem.Image")));
            this.聊天记录ToolStripMenuItem.Name = "聊天记录ToolStripMenuItem";
            this.聊天记录ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.聊天记录ToolStripMenuItem.Text = "聊天记录";
            this.聊天记录ToolStripMenuItem.Click += new System.EventHandler(this.聊天记录ToolStripMenuItem_Click);
            // 
            // 导入截图ToolStripMenuItem
            // 
            this.导入截图ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("导入截图ToolStripMenuItem.Image")));
            this.导入截图ToolStripMenuItem.Name = "导入截图ToolStripMenuItem";
            this.导入截图ToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.导入截图ToolStripMenuItem.Text = "导入截图";
            this.导入截图ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.导入截图ToolStripMenuItem.Click += new System.EventHandler(this.导入截图ToolStripMenuItem_Click);
            // 
            // 截图ToolStripMenuItem
            // 
            this.截图ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("截图ToolStripMenuItem.Image")));
            this.截图ToolStripMenuItem.Name = "截图ToolStripMenuItem";
            this.截图ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.截图ToolStripMenuItem.Text = "截图";
            this.截图ToolStripMenuItem.Click += new System.EventHandler(this.截图ToolStripMenuItem_Click);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserInfo.ForeColor = System.Drawing.Color.Blue;
            this.lblUserInfo.Location = new System.Drawing.Point(254, 5);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(76, 16);
            this.lblUserInfo.TabIndex = 6;
            this.lblUserInfo.Text = "用户信息";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabChating);
            this.tab.Controls.Add(this.tabAllUser);
            this.tab.Location = new System.Drawing.Point(0, 3);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(248, 586);
            this.tab.TabIndex = 7;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_SelectedIndexChanged);
            // 
            // tabChating
            // 
            this.tabChating.BackColor = System.Drawing.Color.White;
            this.tabChating.Controls.Add(this.vTreeChating);
            this.tabChating.Location = new System.Drawing.Point(4, 24);
            this.tabChating.Name = "tabChating";
            this.tabChating.Padding = new System.Windows.Forms.Padding(3);
            this.tabChating.Size = new System.Drawing.Size(240, 558);
            this.tabChating.TabIndex = 0;
            this.tabChating.Text = "沟通消息";
            // 
            // tabAllUser
            // 
            this.tabAllUser.BackColor = System.Drawing.Color.White;
            this.tabAllUser.Controls.Add(this.vTreeAlluser);
            this.tabAllUser.Location = new System.Drawing.Point(4, 24);
            this.tabAllUser.Name = "tabAllUser";
            this.tabAllUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllUser.Size = new System.Drawing.Size(240, 558);
            this.tabAllUser.TabIndex = 1;
            this.tabAllUser.Text = "所有用户";
            // 
            // ChatClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(958, 591);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ChatClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "病案问题沟通";
            this.Activated += new System.EventHandler(this.ChatClient_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatClient_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tabChating.ResumeLayout(false);
            this.tabAllUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox rtbView;
        private System.Windows.Forms.RichTextBox rtbEdit;
        private System.Windows.Forms.Button btnSendMsg;
        private Heren.Common.Controls.VirtualTreeView.VirtualTree vTreeAlluser;
        private Heren.Common.Controls.VirtualTreeView.VirtualTree vTreeChating;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabChating;
        private System.Windows.Forms.TabPage tabAllUser;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 聊天记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导入截图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 截图ToolStripMenuItem;
    }
}

