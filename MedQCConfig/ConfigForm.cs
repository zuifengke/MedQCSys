using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MedQCConfig
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoadMedQCConfigFile();
        }

        private void LoadMedQCConfigFile()
        {
            string szFileName = string.Format(@"{0}\MedQCConfig.xml", System.Environment.CurrentDirectory);
            if (!File.Exists(szFileName))
                return;
            this.txtFile.Text = szFileName;
            XmlDocument doc = new XmlDocument();
            doc.Load(szFileName);
            XmlNodeList nodeList = doc.SelectNodes("SystemConfig/key");
            if (nodeList == null)
                return;
            for (int index = nodeList.Count - 1; index >= 0; index--)
            {
                XmlNode node = nodeList[index];
                string szName = node.Attributes["name"]?.Value;
                string szValue = node.Attributes["value"]?.Value;
                string szDesc = node.PreviousSibling.Value;
                string szDefault = node.Attributes["default"]?.Value;
                AddPanle(index, szName, szValue, szDesc, szDefault);
            }
        }

        private void AddPanle(int index, string szName, string szValue, string szDesc, string szDefault)
        {
            Label labDesc = new Label();
            labDesc.AutoSize = true;
            labDesc.Location = new Point(21, 9);
            labDesc.Name = "labDesc_" + index.ToString();
            labDesc.Size = new Size(49, 14);
            labDesc.Text = "描述：";

            TextBox txtBoxDesc = new TextBox();
            txtBoxDesc.Location = new Point(67, 5);
            txtBoxDesc.Name = "txtBoxDesc_" + index.ToString();
            txtBoxDesc.Size = new Size(683, 23);
            txtBoxDesc.BackColor = SystemColors.Control;
            txtBoxDesc.Text = szDesc;

            Label labName = new Label();
            labName.AutoSize = true;
            labName.Location = new Point(21, 36);
            labName.Name = "labName_" + index.ToString();
            labName.Size = new Size(49, 14);
            labName.Text = "Name：";

            TextBox txtBoxName = new TextBox();
            txtBoxName.Location = new Point(67, 32);
            txtBoxName.Name = "txtBoxName_" + index.ToString();
            txtBoxName.Size = new Size(377, 23);
            txtBoxName.Text = szName;

            Label labValue = new Label();
            labValue.AutoSize = true;
            labValue.Location = new Point(464, 36);
            labValue.Name = "labValue_" + index.ToString();
            labValue.Size = new Size(56, 14);
            labValue.TabIndex = 4;
            labValue.Text = "Value：";

            TextBox txtBoxValue = new TextBox();
            txtBoxValue.Location = new Point(516, 32);
            txtBoxValue.Name = "txtBoxValue_" + index.ToString();
            txtBoxValue.Size = new Size(80, 23);
            txtBoxValue.Text = szValue;
            txtBoxValue.Tag = szDefault;//Tag保存默认值


            Label labDefault = new Label();
            labDefault.AutoSize = true;
            labDefault.Location = new Point(600, 36);
            labDefault.Name = "labValue_" + index.ToString();
            labDefault.Size = new Size(56, 14);
            labDefault.TabIndex = 4;
            labDefault.Text = "default：";

            TextBox txtBoxDefaultValue = new TextBox();
            txtBoxDefaultValue.Location = new Point(670, 32);
            txtBoxDefaultValue.Name = "txtBoxDefaultValue" + index.ToString();
            txtBoxDefaultValue.Size = new Size(80, 23);
            txtBoxDefaultValue.ReadOnly = true;
            txtBoxDefaultValue.Text = szDefault;

            Button btnDelete = new Button();
            btnDelete.Location = new Point(800, 32);
            btnDelete.Text = "移除";
            btnDelete.Click += BtnDelete_Click;


            Panel panel = new Panel();
            panel.Name = "panelSub_" + index.ToString();
            if (!string.IsNullOrEmpty(szName))
                panel.Dock = DockStyle.Top;
            else
                panel.Dock = DockStyle.Bottom;
            panel.Controls.Add(txtBoxValue);
            panel.Controls.Add(labValue);
            panel.Controls.Add(txtBoxName);
            panel.Controls.Add(labName);
            panel.Controls.Add(txtBoxDesc);
            panel.Controls.Add(labDefault);
            panel.Controls.Add(txtBoxDefaultValue);
            panel.Controls.Add(labDesc);
            panel.Controls.Add(btnDelete);
            panel.Location = new Point(4, 3 + 63 * (index));
            panel.Size = new Size(862, 63);
            this.mainPanel.Controls.Add(panel);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否删除此配置项？", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.mainPanel.Controls.Remove(((Button)sender).Parent);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddPanle(this.mainPanel.Controls.Count, string.Empty, string.Empty, string.Empty, string.Empty);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveDocument())
                    MessageBox.Show("保存成功！");
                else
                    MessageBox.Show("保存失败！");
            }
            catch (Exception)
            {
                MessageBox.Show("保存失败！");
            }
        }

        private bool SaveDocument()
        {
            if (this.mainPanel.Controls.Count == 0)
                return true;
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declartion = doc.CreateXmlDeclaration("1.0", "GBK", "");
            doc.AppendChild(declartion);
            XmlElement rootElement = doc.CreateElement("SystemConfig");
            doc.AppendChild(rootElement);
            for (int index = this.mainPanel.Controls.Count - 1; index >= 0; index--)
            {
                Control control = this.mainPanel.Controls[index];
                Panel panel = (Panel)control;
                if (panel == null)
                    continue;
                if (panel.BackColor != SystemColors.Control)
                    panel.BackColor = SystemColors.Control;
                string szName = string.Empty;
                string szValue = string.Empty;
                string szDefaultValue = string.Empty;
                string szDesc = string.Empty;
                foreach (Control subControl in panel.Controls)
                {
                    TextBox box = subControl as TextBox;
                    if (box == null)
                        continue;

                    if (box.Name.ToUpper().Contains("NAME"))
                        szName = box.Text.Trim();
                    if (box.Name.ToUpper().Contains("TXTBOXVALUE"))
                    {
                        szValue = box.Text.Trim();
                        szDefaultValue = box.Tag as string;
                    }
                    if (box.Name.ToUpper().Contains("DESC"))
                        szDesc = box.Text.Trim();
                }
                if (string.IsNullOrEmpty(szName))
                {
                    MessageBox.Show("请输入配置名称！");
                    panel.BackColor = Color.LightBlue;
                    return false;
                }
                if (string.IsNullOrEmpty(szDesc))
                {
                    MessageBox.Show("请输入配置描述！");
                    panel.BackColor = Color.LightBlue;
                    return false;
                }
                //if (string.IsNullOrEmpty(szValue))
                //{
                //    MessageBox.Show("请输入配置值！");
                //    panel.BackColor = Color.LightBlue;
                //    return false;
                //}
                XmlElement element = doc.CreateElement("key");
                element.SetAttribute("name", szName);
                element.SetAttribute("value", szValue);
                element.SetAttribute("default", szDefaultValue);
                XmlComment comment = doc.CreateComment(szDesc);
                rootElement.AppendChild(comment);
                rootElement.AppendChild(element);
            }
            doc.Save(string.Format(@"{0}\MedQCConfig.xml", System.Environment.CurrentDirectory)); 
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否将所有配置项重置为默认值?", "", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            for (int index = this.mainPanel.Controls.Count - 1; index >= 0; index--)
            {
                Control control = this.mainPanel.Controls[index];
                Panel panel = (Panel)control;
                if (panel == null)
                    continue;
                foreach (Control subControl in panel.Controls)
                {
                    TextBox box = subControl as TextBox;
                    if (box == null)
                        continue;

                    if (box.Name.ToUpper().Contains("TXTBOXVALUE"))
                        box.Text = box.Tag as string;
                }
            }
        }
    }
}
