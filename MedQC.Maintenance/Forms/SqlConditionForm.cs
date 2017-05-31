// ***********************************************************
// 病历编辑器配置管理系统元素绑定功能之SQL查询条件编辑窗口.
// Creator:YangMingkun  Date:2010-11-29
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using Heren.Common.Libraries;
using Heren.Common.Controls;

namespace Heren.MedQC.Maintenance
{
    internal partial class SqlConditionForm : HerenForm
    {
        private Dictionary<string, Type> m_properties = null;
        /// <summary>
        /// 获取或设置当前窗口中的SQL条件数据属性对象
        /// </summary>
        public Dictionary<string, Type> Properties
        {
            get { return this.m_properties; }
            set
            {
                if (value == null)
                    this.m_properties.Clear();
                else
                    this.m_properties = value;
            }
        }

        private string m_szSqlCondition = string.Empty;
        /// <summary>
        /// 获取或设置当前窗口中的SQL条件数据字符串
        /// </summary>
        public string SqlCondition
        {
            get { return this.m_szSqlCondition; }
            set { this.m_szSqlCondition = value; }
        }

        public SqlConditionForm()
        {
            this.InitializeComponent();
            this.m_properties = new Dictionary<string, Type>();
            this.btnLeftToRight.Image = Heren.MedQC.Maintenance.Properties.Resources.ToRight;
            this.txtBindProperties.Font = new Font("宋体", 9f, FontStyle.Regular);
        }

        private void LoadSqlCondition()
        {
            this.txtBindProperties.Clear();
            if (GlobalMethods.Misc.IsEmptyString(this.m_szSqlCondition))
                return;
            string[] arrSqlCondition = this.m_szSqlCondition.Split(';');
            if (arrSqlCondition == null || arrSqlCondition.Length <= 0)
                return;
            for (int index = 0; index < arrSqlCondition.Length; index++)
            {
                if (GlobalMethods.Misc.IsEmptyString(arrSqlCondition[index]))
                    continue;
                string szSqlCondition = arrSqlCondition[index].Trim();
                this.txtBindProperties.AppendText(szSqlCondition + "\n");
            }
        }

        private void LoadPropertyTypeList()
        {
            this.cboPropertyType.Items.Clear();
            IEnumerator enumerator = this.m_properties.Keys.GetEnumerator();
            while (enumerator.MoveNext())
                this.cboPropertyType.Items.Add(enumerator.Current as string);
            if (this.cboPropertyType.Items.Count > 0)
                this.cboPropertyType.SelectedIndex = 0;
        }

        private void UpdatePropertyNameList()
        {
            this.lbxPropertyList.Items.Clear();

            string szPropertyType = string.Empty;
            object objSelectedItem = this.cboPropertyType.SelectedItem;
            if (objSelectedItem != null)
                szPropertyType = objSelectedItem.ToString();
            if(string.IsNullOrEmpty(szPropertyType))
                return;

            if (!this.m_properties.ContainsKey(szPropertyType))
                return;
            Type type = this.m_properties[szPropertyType];
            PropertyInfo[] propertys = type.GetProperties();
            string szTypeName = type.Name;
            for (int index = 0; index < propertys.Length; index++)
            {
                PropertyInfo propertyInfo = propertys[index];
                this.lbxPropertyList.Items.Add(szTypeName + "." + propertyInfo.Name);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Update();
            GlobalMethods.UI.SetCursor(this, Cursors.WaitCursor);
            this.LoadSqlCondition();
            this.LoadPropertyTypeList();
            GlobalMethods.UI.SetCursor(this, Cursors.Default);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            StringBuilder sbSqlCondition = new StringBuilder();
            string[] arrBindProperties = this.txtBindProperties.Lines;
            for (int index = 0; index < arrBindProperties.Length; index++)
            {
                string szPropertyName = arrBindProperties[index].Trim();
                if (!GlobalMethods.Misc.IsEmptyString(szPropertyName))
                    sbSqlCondition.Append(szPropertyName + ";");
            }
            this.m_szSqlCondition = sbSqlCondition.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void cboPropertyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdatePropertyNameList();
        }

        private void btnLeftToRight_Click(object sender, EventArgs e)
        {
            if (this.lbxPropertyList.SelectedIndex < 0)
                return;
            this.txtBindProperties.AppendText(this.lbxPropertyList.SelectedItem.ToString());
            this.txtBindProperties.AppendText("\n");
        }

        private void lbxPropertyList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.lbxPropertyList.SelectedIndex < 0)
                return;
            this.txtBindProperties.AppendText(this.lbxPropertyList.SelectedItem.ToString());
            this.txtBindProperties.AppendText("\n");
        }
    }
}