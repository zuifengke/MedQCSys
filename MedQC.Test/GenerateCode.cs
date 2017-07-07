using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMRDBLib.DbAccess;
using EMRDBLib.HerenHis;
using EMRDBLib;

namespace MedQC.Test
{
    public partial class GenerateCode : Form
    {
        public GenerateCode()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateCode2("herenhis");
        }

        private string GenerateCode2(string dbname)
        {
            string tableName = this.txtTableName.Text;
            string sql = string.Format(" select table_name,column_name,comments from user_col_comments where Table_Name='{0}'", tableName);
            DataSet ds = null;
            if (dbname == "herenhis")
                HerenHisCommonAccess.Instance.ExecuteQuery(sql, out ds);
            else if (dbname == "medqc")
                CommonAccess.Instance.ExecuteQuery(sql, out ds);
            List<UserColComments> lstUserColComments = new List<UserColComments>();
            if (ds != null)
            {
                this.richTextBox1.Clear();

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string table_name = ds.Tables[0].Rows[i]["table_name"].ToString();
                    string column_name = ds.Tables[0].Rows[i]["column_name"].ToString();
                    string comments = ds.Tables[0].Rows[i]["comments"].ToString();
                    this.richTextBox1.AppendText("/// <summary>\n");
                    this.richTextBox1.AppendText("/// " + comments + "\n");
                    this.richTextBox1.AppendText("/// </summary>\n");
                    this.richTextBox1.AppendText("public const string " + column_name + " = \"" + column_name + "\";\n");
                    this.richTextBox1.AppendText("");

                    UserColComments userColComments = new UserColComments();
                    userColComments.column_name = column_name;
                    userColComments.comments = comments;
                    userColComments.table_name = table_name;
                    lstUserColComments.Add(userColComments);
                }
            }
            sql = string.Format("SELECT TABLE_NAME,COLUMN_NAME,t.DATA_TYPE FROM user_tab_columns t where t.table_name ='" + tableName + "'");
            if (dbname == "herenhis")
                HerenHisCommonAccess.Instance.ExecuteQuery(sql, out ds);
            else if (dbname == "medqc")
                CommonAccess.Instance.ExecuteQuery(sql, out ds);
            if (ds != null)
            {
                this.richTextBox2.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string table_name = ds.Tables[0].Rows[i]["table_name"].ToString();
                    string column_name = ds.Tables[0].Rows[i]["column_name"].ToString();
                    string DATA_TYPE = ds.Tables[0].Rows[i]["DATA_TYPE"].ToString();
                    UserColComments userColComments = lstUserColComments.Where(m => m.column_name == column_name).FirstOrDefault();
                    this.richTextBox2.AppendText("/// <summary>\n");
                    this.richTextBox2.AppendText("/// " + userColComments.comments + "\n");
                    this.richTextBox2.AppendText("/// </summary>\n");
                    if (DATA_TYPE == "VARCHAR2")
                        this.richTextBox2.AppendText("public string " + column_name + "{get;set;}\n");
                    else if (DATA_TYPE == "NUMBER")
                        this.richTextBox2.AppendText("public decimal " + column_name + "{get;set;}\n");
                    else if (DATA_TYPE == "DATE")
                        this.richTextBox2.AppendText("public DateTime " + column_name + "{get;set;}\n");
                    this.richTextBox2.AppendText("\n");
                }
            }

            return sql;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GenerateCode2("medqc");
        }
    }
    public class UserColComments
    {
        public string table_name { get; set; }
        public string column_name { get; set; }
        public string comments { get; set; }
    }
}
