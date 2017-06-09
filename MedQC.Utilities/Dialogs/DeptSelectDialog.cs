// ***********************************************************
// 护理电子病历系统公用模块之科室病区选择窗口.
// Creator:YangMingkun  Date:2012-9-22
// Copyright : Heren Health Services Co.,Ltd.
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;
using EMRDBLib;
using EMRDBLib.DbAccess;
namespace Heren.MedQC.Utilities.Dialogs
{
    public partial class DeptSelectDialog : HerenForm
    {
        private int m_defaultDeptType = 0;

        /// <summary>
        /// 获取或设置默认科室类型
        /// </summary>
        [Browsable(false)]
        public int DefaultDeptType
        {
            get { return this.m_defaultDeptType; }
            set { this.m_defaultDeptType = value; }
        }

        private bool m_bMultiSelect = true;

        /// <summary>
        /// 获取或设置是否允许多选
        /// </summary>
        [Browsable(false)]
        public bool MultiSelect
        {
            get { return this.m_bMultiSelect; }
            set { this.m_bMultiSelect = value; }
        }

        private DeptInfo[] m_arrDeptInfo = null;

        /// <summary>
        /// 获取或设置需要勾选的科室信息列表
        /// </summary>
        [Browsable(false)]
        public DeptInfo[] DeptInfos
        {
            get { return this.m_arrDeptInfo; }
            set { this.m_arrDeptInfo = value; }
        }

        private Hashtable m_htDeptItem = null;

        public DeptSelectDialog()
        {
            this.InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            if (!this.m_bMultiSelect)
            {
                this.listView1.CheckBoxes = false;
                this.listView1.MultiSelect = false;
                this.chkCheckAll.Visible = false;
            }
            else
            {
                this.listView1.CheckBoxes = true;
                this.listView1.MultiSelect = true;
                this.chkCheckAll.Visible = true;
            }
            if (this.m_defaultDeptType >= 0
                && this.m_defaultDeptType < this.cboDeptType.Items.Count)
                this.cboDeptType.SelectedIndex = this.m_defaultDeptType;
            this.InitDeptCheckState();
            this.listView1.Focus();
        }

        /// <summary>
        /// 加载需要显示的科室名称项目
        /// </summary>
        private void LoadDeptList()
        {
            if (this.cboDeptFind == null || this.cboDeptFind.IsDisposed)
                return;
            this.cboDeptFind.Items.Clear();
            if (this.listView1 == null || this.listView1.IsDisposed)
                return;
            this.listView1.Items.Clear();

            List<DeptInfo> lstDeptInfos = null;
            short shRet = SystemData.ReturnValue.OK;
            shRet =DeptAccess.Instance.GetClinicInpDeptList(ref lstDeptInfos);
            if (shRet != SystemData.ReturnValue.OK)
            {
                MessageBoxEx.Show("临床科室列表下载失败!");
                return;
            }
            if (lstDeptInfos == null || lstDeptInfos.Count <= 0)
                return;

            if (this.m_htDeptItem == null)
                this.m_htDeptItem = new Hashtable();
            this.m_htDeptItem.Clear();

            for (int index = 0; index < lstDeptInfos.Count; index++)
            {
                DeptInfo deptInfo = lstDeptInfos[index];
                if (deptInfo == null || string.IsNullOrEmpty(deptInfo.DEPT_CODE))
                    continue;
                if (this.m_htDeptItem.Contains(deptInfo.DEPT_CODE))
                    continue;
                ListViewItem item = this.listView1.Items.Add(deptInfo.DEPT_NAME);
                item.Tag = deptInfo;
                this.m_htDeptItem.Add(deptInfo.DEPT_CODE, item);
                this.cboDeptFind.Items.Add(deptInfo);
            }
        }

        /// <summary>
        /// 初始化科室勾选状态
        /// </summary>
        private void InitDeptCheckState()
        {
            for (int index = 0; index < this.listView1.Items.Count; index++)
            {
                this.listView1.Items[index].Checked = false;
            }
            if (this.m_arrDeptInfo == null || this.m_arrDeptInfo.Length <= 0)
                return;
            if (this.m_htDeptItem == null || this.m_htDeptItem.Count <= 0)
                return;
            for (int index = 0; index < this.m_arrDeptInfo.Length; index++)
            {
                DeptInfo deptInfo = this.m_arrDeptInfo[index];
                if (deptInfo == null || string.IsNullOrEmpty(deptInfo.DEPT_CODE))
                    continue;
                if (!this.m_htDeptItem.Contains(deptInfo.DEPT_CODE))
                    continue;
                ListViewItem item = this.m_htDeptItem[deptInfo.DEPT_CODE] as ListViewItem;
                if (item != null) item.Checked = true;
            }
        }

        /// <summary>
        /// 根据科室名称查找科室项目,并将其选中
        /// </summary>
        /// <param name="szDeptName">科室名称</param>
        private void FindDeptItem(string szDeptName)
        {
            this.listView1.SelectedItems.Clear();
            ListViewItem item = this.listView1.FindItemWithText(szDeptName);
            if (item != null)
            {
                item.Focused = true;
                item.Selected = true;
                item.EnsureVisible();
                this.listView1.Focus();
            }
        }

        private void cboDeptType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.LoadDeptList();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void cboDeptFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData != Keys.Enter)
                return;
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindDeptItem(this.cboDeptFind.Text);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void cboDeptFind_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.FindDeptItem(this.cboDeptFind.Text);
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            for (int index = 0; index < this.listView1.Items.Count; index++)
            {
                this.listView1.Items[index].Checked = this.chkCheckAll.Checked;
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.btnOK.PerformClick();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.m_arrDeptInfo = null;
            if (!this.m_bMultiSelect)
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    this.m_arrDeptInfo = new DeptInfo[1];
                    this.m_arrDeptInfo[0] = this.listView1.SelectedItems[0].Tag as DeptInfo;
                }
            }
            else
            {
                ListView.CheckedListViewItemCollection lstCheckedItems = this.listView1.CheckedItems;
                this.m_arrDeptInfo = new DeptInfo[lstCheckedItems.Count];
                for (int index = 0; index < lstCheckedItems.Count; index++)
                {
                    this.m_arrDeptInfo[index] = lstCheckedItems[index].Tag as DeptInfo;
                }
            }
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
            this.DialogResult = DialogResult.OK;
        }
    }
}