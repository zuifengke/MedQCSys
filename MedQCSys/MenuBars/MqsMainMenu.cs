// ***********************************************************
// 病案质控系统主菜单条控件.
// Creator:YangMingkun  Date:2009-11-13
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using EMRDBLib;
using Heren.MedQC.Core;
using EMRDBLib.DbAccess;

namespace MedQCSys.MenuBars
{
    internal class MqsMainMenu : MenuStrip
    {
        private MainForm m_mainForm = null;
        public virtual MainForm MainForm
        {
            get { return this.m_mainForm; }
            set
            {
                this.m_mainForm = value;
                this.menuSystem.MainForm = value;
                this.menuStatistic.MainForm = value;
                this.menuSearch.MainForm = value;
                this.menuMaintenance.MainForm = value;
                this.menuSettings.MainForm = value;
                this.menuHelp.MainForm = value;
            }
        }

        #region"主菜单条初始化"
        private SystemMenu menuSystem;
        private SearchMenu menuSearch;
        /// <summary>
        /// 获取查询菜单项
        /// </summary>
        public SearchMenu SearchMenu
        {
            get { return this.menuSearch; }
        }
        private StatisticMenu menuStatistic;
        /// <summary>
        /// 获取统计菜单项
        /// </summary>
        public StatisticMenu StatisticMenu
        {
            get { return this.menuStatistic; }
        }
        private MaintenanceMenu menuMaintenance;
        private SettingsMenu menuSettings;
        private HelpMenu menuHelp;

        private void InitializeComponent()
        {
            this.menuSystem = new SystemMenu(this.m_mainForm);
            this.menuStatistic = new StatisticMenu(this.m_mainForm);
            this.menuSearch = new SearchMenu(this.m_mainForm);
            this.menuMaintenance = new MaintenanceMenu(this.m_mainForm);
            this.menuSettings = new SettingsMenu(this.m_mainForm);
            this.menuHelp = new HelpMenu(this.m_mainForm);
            // 
            // MqsMainMenu
            // 
            this.Text = "MqsMainMenu";
            if (SystemParam.Instance.LocalConfigOption == null)
                return;
            if (!SystemParam.Instance.LocalConfigOption.HdpUse)
            {
                this.Items.Clear();
                this.Items.AddRange(new ToolStripItem[] {
                this.menuSystem,
                this.menuStatistic,
                this.menuSearch,
                this.menuMaintenance,
                this.menuSettings,
                this.menuHelp});
            }
            this.Location = new System.Drawing.Point(0, 0);
        }
        #endregion

        public MqsMainMenu()
            : this(null)
        {
        }

        public MqsMainMenu(MainForm parent)
        {
            this.m_mainForm = parent;
            this.InitializeComponent();
            this.Renderer = new MenuRenderer();
            this.Dock = DockStyle.Top;
            this.AutoSize = false;
            this.ShowItemToolTips = true;
            this.GripStyle = ToolStripGripStyle.Visible;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Padding = new Padding(1, 0, 0, 0);
            //this.Padding = new Padding(1, 0, 0, 0);
            this.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //实现click-through
            if (m.Msg == NativeConstants.WM_MOUSEACTIVATE)
            {
                if (m.Result == (IntPtr)NativeConstants.MA_ACTIVATEANDEAT)
                {
                    m.Result = (IntPtr)NativeConstants.MA_ACTIVATE;
                }
            }
        }

        private bool m_IsHideFuncTool = false;
        public bool IsHideFuncTool
        {
            get
            {
                return this.m_IsHideFuncTool;
            }
        }
        private Dictionary<string, HdpUIConfig> m_dicHdpUIConfig = new Dictionary<string, HdpUIConfig>();
        private List<HdpUIConfig> lstHdpUIConfig = null;
        public void RefreshUIConfig()
        {

            if (lstHdpUIConfig == null)
                lstHdpUIConfig = new List<HdpUIConfig>();
            lstHdpUIConfig.Clear();
            string szProductShortName = DataCache.Instance.HdpProduct.NAME_SHORT;
            if (string.IsNullOrEmpty(szProductShortName))
            {
                szProductShortName = RightResource.PRODUCT_MEDQC;
            }
            short shRet = HdpUIConfigAccess.Instance.GetHdpUIConfigList(szProductShortName, SystemData.UIType.MENU, string.Empty, ref lstHdpUIConfig);
            this.Items.Clear();
            this.InitializeComponent();
            this.m_IsHideFuncTool = SystemConfig.Instance.Get(SystemData.ConfigKey.SHOW_TOOL_STRIP, false);
            this.m_dicHdpUIConfig.Clear();
            foreach (HdpUIConfig item in lstHdpUIConfig)
            {
                if (!this.m_dicHdpUIConfig.ContainsKey(item.UIConfigID)) this.m_dicHdpUIConfig.Add(item.UIConfigID, item);
            }

            foreach (HdpUIConfig item in lstHdpUIConfig)
            {
                //跳过没权限的菜单
                //if (!RightHandler.Instance.HasRight(item.UIRightKey)) continue;
                //显示根菜单
                if (string.IsNullOrEmpty(item.ParentID))
                {
                    MqsMenuItemBase toolbtn = null;
                    //检查是否有子菜单
                    toolbtn = new MqsMenuItemBase();

                    if (this.CheckIsParent(item.UIConfigID))
                    {
                        ToolStripRecursion(toolbtn, item.UIConfigID);
                    }
                    toolbtn.Text = item.ShowName;
                    toolbtn.Name = item.UIConfigID;
                    if (item.ShortCuts.Contains("ALt+"))
                    {
                        toolbtn.Text += string.Format("(&{0})", item.ShortCuts.Replace("ALt+", ""));
                    }
                    if (string.IsNullOrEmpty(item.UIIcon))
                    {
                        toolbtn.DisplayStyle = SystemData.UIDisplayStyle.GetDisplayStyle(SystemData.UIDisplayStyle.TEXT);

                    }
                    else
                    {
                        toolbtn.DisplayStyle = SystemData.UIDisplayStyle.GetDisplayStyle(SystemData.UIDisplayStyle.TEXT_IMAGE);
                    }
                    toolbtn.TextImageRelation = TextImageRelation.ImageAboveText;
                    toolbtn.Click += new EventHandler(toolbtn_Click);
                    toolbtn.AutoSize = true;
                    if (!RightHandler.Instance.HasRight(item.UIRightKey)) toolbtn.Enabled = false;
                    this.Items.Add(toolbtn);
                }
            }
#if DEBUG
            // 增加调试快捷入口
            MqsMenuItemBase menu = new MqsMenuItemBase();
            menu.Click += new EventHandler(toolbtn_Click);
            menu.Text = "快捷入口";
            menu.Name = "快捷入口";
            HdpUIConfig hdpUIConfig = new HdpUIConfig() { UICommand = "快捷入口", UIConfigID="111" };
            if (!this.m_dicHdpUIConfig.ContainsKey("快捷入口"))
                this.m_dicHdpUIConfig.Add("快捷入口", hdpUIConfig);
            this.Items.Add(menu);
#endif
            menuCommon = new MqsMenuItemBase[this.Items.Count];
            for (int i = 0; i < menuCommon.Length; i++)
            {
                menuCommon[i] = (MqsMenuItemBase)this.Items[i];
            }
            this.Show();
        }
        private MqsMenuItemBase[] menuCommon;
        public void ToolStripRecursion(MqsMenuItemBase parentMenuItem, string szParentID)
        {
            foreach (HdpUIConfig item in this.lstHdpUIConfig)
            {
                //if (!RightHandler.Instance.HasRight(item.UIRightKey)) continue;
                if (item.ParentID == szParentID)
                {
                    MqsMenuItemBase mnuItem = null;
                    if (item.ShowName == "————")
                    {
                        ToolStripSeparator toolStripSeparator = new ToolStripSeparator();
                        parentMenuItem.DropDownItems.Add(toolStripSeparator);
                        continue;
                    }
                    mnuItem = new MqsMenuItemBase();
                    if (this.CheckIsParent(item.UIConfigID))
                    {
                        ToolStripRecursion(mnuItem, item.UIConfigID);
                    }
                    if (mnuItem is ToolStripMenuItem)
                    {
                        if (!string.IsNullOrEmpty(item.ShortCuts))
                        {
                            (mnuItem as ToolStripMenuItem).ShortcutKeys = SystemData.ShortcutKeys.GetShortcutKeys(item.ShortCuts);
                        }
                    }
                    mnuItem.Name = item.UIConfigID;
                    mnuItem.Text = item.ShowName;
                    mnuItem.Click += new EventHandler(this.toolbtn_Click);
                    if (!RightHandler.Instance.HasRight(item.UIRightKey)) mnuItem.Enabled = false;
                    parentMenuItem.DropDownItems.Add(mnuItem);
                }
            }
        }

        public bool CheckIsParent(string szParentID)
        {
            if (this.lstHdpUIConfig == null) return false;
            if (this.lstHdpUIConfig.Exists(m => m.ParentID == szParentID))
                return true;
            return false;
        }

        private void toolbtn_Click(object sender, System.EventArgs e)
        {
            ToolStripItem toolbtn = sender as ToolStripItem;
            if (toolbtn == null)
                return;
            HdpUIConfig hdp = this.m_dicHdpUIConfig[toolbtn.Name];
            if (hdp.UICommand == string.Empty)
                return;

            CommandHandler.Instance.SendCommand(hdp.UICommand, this.m_mainForm, null);
        }
    }
}
