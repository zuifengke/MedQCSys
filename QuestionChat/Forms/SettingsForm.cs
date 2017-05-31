using System;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using EMRDBLib;

namespace Heren.MedQC.QuestionChat.Forms
{
    internal partial class SettingsForm : HerenForm
    {
        public SettingsForm()
        {
            this.InitializeComponent();
            GlobalMethods.UI.LocateScreenCenter(this);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            this.cboRefreshInterval.Items.Clear();
            this.cboRefreshInterval.Items.Add(0);
#if DEBUG
            this.cboRefreshInterval.Items.Add(1);
#endif
            for (int index = 5; index <= 30; index++)
            {
                this.cboRefreshInterval.Items.Add(index);
            }
            this.chkShowPopupTip.Checked = SystemConfig.Instance.Get(SystemData.ConfigKey.TASK_POPUP_TIP, true);
            this.chkTrayIconBlink.Checked = SystemConfig.Instance.Get(SystemData.ConfigKey.TASK_ICON_BLINK, true);
            this.chkIsAutoPopupWindow.Checked = SystemConfig.Instance.Get(SystemData.ConfigKey.TASK_AUTO_POPOP_MESSAGE, true);
            this.cboRefreshInterval.Text = SystemConfig.Instance.Get(SystemData.ConfigKey.TASK_REFRESH_INTERVAL, "10");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (GlobalMethods.Misc.IsEmptyString(this.cboRefreshInterval.Text))
            {
                MessageBoxEx.Show("您没有设置任务列表刷新时间间隔!");
                return;
            }
            SystemConfig.Instance.Write(SystemData.ConfigKey.TASK_POPUP_TIP, this.chkShowPopupTip.Checked.ToString());
            SystemConfig.Instance.Write(SystemData.ConfigKey.TASK_ICON_BLINK, this.chkTrayIconBlink.Checked.ToString());
            SystemConfig.Instance.Write(SystemData.ConfigKey.TASK_REFRESH_INTERVAL, this.cboRefreshInterval.Text);
            SystemConfig.Instance.Write(SystemData.ConfigKey.TASK_AUTO_POPOP_MESSAGE, this.chkIsAutoPopupWindow.Checked.ToString());
            this.DialogResult = DialogResult.OK;
        }
    }
}