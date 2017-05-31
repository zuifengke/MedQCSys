namespace Heren.MedQC.QuestionChat.Forms
{
    partial class TrayMessageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMessageCount = new System.Windows.Forms.Label();
            this.btnDetails = new Heren.Common.Controls.FlatButton();
            this.btnClose = new Heren.Common.Controls.FlatButton();
            this.btnTimeMessage = new Heren.Common.Controls.FlatButton();
            this.SuspendLayout();
            // 
            // lblMessageCount
            // 
            this.lblMessageCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMessageCount.Image = global::Heren.MedQC.QuestionChat.Properties.Resources.Remind;
            this.lblMessageCount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessageCount.Location = new System.Drawing.Point(11, 37);
            this.lblMessageCount.Name = "lblMessageCount";
            this.lblMessageCount.Size = new System.Drawing.Size(206, 43);
            this.lblMessageCount.TabIndex = 0;
            this.lblMessageCount.Text = "         系统共收集到{0}条消息!";
            this.lblMessageCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDetails.ForeColor = System.Drawing.Color.Blue;
            this.btnDetails.Location = new System.Drawing.Point(221, 47);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(76, 22);
            this.btnDetails.TabIndex = 1;
            this.btnDetails.Text = "详细";
            this.btnDetails.ToolTipText = "查看详细消息列表";
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.ForeColor = System.Drawing.Color.Blue;
            this.btnClose.Location = new System.Drawing.Point(297, 47);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 22);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "关闭";
            this.btnClose.ToolTipText = "关闭当前消息框";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTimeMessage
            // 
            this.btnTimeMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimeMessage.ContentCenter = false;
            this.btnTimeMessage.Location = new System.Drawing.Point(9, 88);
            this.btnTimeMessage.Name = "btnTimeMessage";
            this.btnTimeMessage.Size = new System.Drawing.Size(373, 25);
            this.btnTimeMessage.TabIndex = 3;
            this.btnTimeMessage.Text = "待读消息：共{0}份, 需要您查看或回复";
            this.btnTimeMessage.ToolTipText = null;
            // 
            // TrayMessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 153);
            this.Controls.Add(this.lblMessageCount);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDetails);
            this.Controls.Add(this.btnTimeMessage);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "TrayMessageForm";
            this.Text = "质控消息提醒";
            this.Controls.SetChildIndex(this.btnTimeMessage, 0);
            this.Controls.SetChildIndex(this.btnDetails, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.lblMessageCount, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMessageCount;
        private Heren.Common.Controls.FlatButton btnDetails;
        private Heren.Common.Controls.FlatButton btnClose;
        private Heren.Common.Controls.FlatButton btnTimeMessage;
    }
}