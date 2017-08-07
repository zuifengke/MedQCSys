// ***********************************************************
// 质控Excel导出类.
// Creator:TANGCHENG  Date:2011-07-19
// Copyright:supconhealth
// ***********************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Heren.Common.Controls;
using Heren.Common.Libraries;

using EMRDBLib;
using EMRDBLib.DbAccess;

namespace Heren.MedQC.Utilities
{
    public class StatExpExcelHelper
    {
        private static StatExpExcelHelper m_Instance = null;
        /// <summary>
        /// 获取单实例
        /// </summary>
        public static StatExpExcelHelper Instance
        {
            get
            {
                if (m_Instance == null)
                    m_Instance = new StatExpExcelHelper();
                return m_Instance;
            }
        }

        private Hashtable m_htNoExportColIndex = null;
        /// <summary>
        /// 获取或设置不需要导出的列集合
        /// </summary>
        public Hashtable HtNoExportColIndex
        {
            get { return this.m_htNoExportColIndex; }
            set { this.m_htNoExportColIndex = value; }
        }

        /// <summary>
        /// 将DataGridView中的数据导出到Excel中
        /// </summary>
        /// <param name="dgv">要进行导出的DataGridView</param>
        /// <param name="szFileTitle">导出数据表格的标题</param>
        public void ExportToExcel(DataGridView dgv, string szFileTitle)
        {
            string szFileName = szFileTitle + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Excel导出";
            saveDialog.DefaultExt = szFileName;
            saveDialog.FileName = szFileTitle;
            saveDialog.Filter = "Excel文件|*.xls|所有文件|*.*";
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            string szFilePath = saveDialog.FileName;

            if (ExcelExporter.ExportExcelFile(dgv, false, szFilePath))
            {
                if (!GlobalMethods.Win32.Execute(szFilePath, null))
                    MessageBoxEx.ShowMessage("已导出完成!但无法打开,您可能没有安装Excel软件!");
            }
            else
            {
                MessageBoxEx.ShowMessage("导出失败!");
            }
            //this.ExportTo(dgv, szFileTitle);
        }

        /// <summary>
        /// 将检验记录窗口中的DataGridView中的数据导出到Excel中
        /// </summary>
        /// <param name="dgv">要进行导出的检验记录的DataGridView</param>
        /// <param name="dgvResultList">要导出的详细检验信息DataGridView</param>
        /// <param name="szFileTitle">导出数据表格的标题</param>
        public void ExportTestResultToExcel(DataGridView dgv, DataGridView dgvResultList, string szFileTitle)
        {
            if (dgv == null || dgv.Rows.Count == 0)
                return;
            int curColumnIndex = 1;     //当前操作列的索引
            int visibleColumnCount = 0;     //DataGridView可见列数
            string szFileName = szFileTitle + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            System.Drawing.Font headFont = dgv.RowHeadersDefaultCellStyle.Font;
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Excel导出";
            saveDialog.DefaultExt = szFileName;
            saveDialog.FileName = szFileTitle + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveDialog.Filter = "Excel文件|*.xls|所有文件|*.*";
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            string szFilePath = saveDialog.FileName;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible != true || (!(dgv.Columns[i] is DataGridViewTextBoxColumn) && !(dgv.Columns[i] is DataGridViewLinkColumn)))
                    continue;
                if (this.m_htNoExportColIndex != null && this.m_htNoExportColIndex.Contains(i))
                    continue;
                visibleColumnCount++;
            }
            try
            {
                ApplicationClass Mylxls = new ApplicationClass();
                if (Mylxls == null)
                {
                    MessageBoxEx.Show("数据导出失败，请确认您的机子上装有Microsoft Office Excel！", MessageBoxIcon.Information);
                    return;
                }
                Mylxls.Application.Workbooks.Add(true);
                Mylxls.Cells.Font.Size = 10.5;
                Mylxls.Caption = szFileName;       //设置标头
                Mylxls.Cells[1, 1] = szFileName;    //显示表头
                Mylxls.Cells.NumberFormatLocal = "@";//控制首位数字为0导出后消失
                int nSpanCount = 0;
                int rowIndex = 2;            //行索引
                for (int j = 0; j < dgv.Rows.Count; j++)
                {
                    curColumnIndex = 1;
                    LabResult labTestInfo = dgv.Rows[j].Tag as LabResult;
                    if (labTestInfo == null)
                        continue;

                    List<LabResult> lstResultInfo = null;
                    short shRet =LabResultAccess.Instance.GetLabResultList(labTestInfo.TEST_ID, ref lstResultInfo);

                    if (shRet != SystemData.ReturnValue.OK
                        && shRet != SystemData.ReturnValue.RES_NO_FOUND)
                        continue;

                    if (lstResultInfo == null || lstResultInfo.Count <= 0)
                        continue;

                    //从excel的第二行开始写入数据，检查项目表头占两行，检查项目列表填充后空两行,如此循环下去直至遍历完dgv的所有行。
                    if (j > 0)
                        rowIndex = rowIndex + 2;
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i].Visible != true || (!(dgv.Columns[i] is DataGridViewTextBoxColumn) && !(dgv.Columns[i] is DataGridViewLinkColumn)))
                            continue;
                        if (this.m_htNoExportColIndex != null && this.m_htNoExportColIndex.Contains(i))
                            continue;

                        //填充检验单名称、标本、申请医生对应的数据
                        if (i < 5)
                        {
                            Mylxls.Cells[rowIndex, curColumnIndex] = dgv.Columns[i].HeaderText;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, curColumnIndex], Mylxls.Cells[rowIndex, curColumnIndex]).Cells.Borders.LineStyle = 1;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, curColumnIndex], Mylxls.Cells[rowIndex, curColumnIndex]).Cells.Interior.ColorIndex = 37;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, curColumnIndex], Mylxls.Cells[rowIndex, curColumnIndex]).Font.Bold = true;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, curColumnIndex], Mylxls.Cells[rowIndex, curColumnIndex]).Font.Size = headFont.Size;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, curColumnIndex], Mylxls.Cells[rowIndex, curColumnIndex]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            Mylxls.Cells[rowIndex, curColumnIndex + 1] = dgv[i, j].Value.ToString();
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, curColumnIndex + 1], Mylxls.Cells[rowIndex, curColumnIndex + 1]).Cells.Borders.LineStyle = 1;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, curColumnIndex + 1], Mylxls.Cells[rowIndex, curColumnIndex + 1]).Cells.Interior.ColorIndex = 37;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, curColumnIndex + 1], Mylxls.Cells[rowIndex, curColumnIndex + 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        }
                        //换行，填充报告状态、报告日期、报告人对应的数据，curColumnIndex重新计数。
                        else
                        {
                            if (i == 5)
                                curColumnIndex = 1;
                            Mylxls.Cells[rowIndex + 1, curColumnIndex] = dgv.Columns[i].HeaderText;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex + 1, curColumnIndex], Mylxls.Cells[rowIndex + 1, curColumnIndex]).Cells.Interior.ColorIndex = 37;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex + 1, curColumnIndex], Mylxls.Cells[rowIndex + 1, curColumnIndex]).Cells.Borders.LineStyle = 1;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex + 1, curColumnIndex], Mylxls.Cells[rowIndex + 1, curColumnIndex]).Font.Bold = true;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex + 1, curColumnIndex], Mylxls.Cells[rowIndex + 1, curColumnIndex]).Font.Size = headFont.Size;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex + 1, curColumnIndex], Mylxls.Cells[rowIndex + 1, curColumnIndex]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                            Mylxls.Cells[rowIndex + 1, curColumnIndex + 1] = dgv[i, j].Value.ToString();
                            Mylxls.get_Range(Mylxls.Cells[rowIndex + 1, curColumnIndex + 1], Mylxls.Cells[rowIndex + 1, curColumnIndex + 1]).Cells.Interior.ColorIndex = 37;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex + 1, curColumnIndex + 1], Mylxls.Cells[rowIndex + 1, curColumnIndex + 1]).Cells.Borders.LineStyle = 1;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex + 1, curColumnIndex + 1], Mylxls.Cells[rowIndex + 1, curColumnIndex + 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;

                        }
                        curColumnIndex = curColumnIndex + 2;
                    }
                    //填充检查项目列表
                    this.BindResultList(dgvResultList, lstResultInfo);
                    for (int colIndex = 0; colIndex < dgvResultList.Columns.Count + 1; colIndex++)
                    {
                        //给excel添加"序号"列。
                        if (colIndex == 0)
                            Mylxls.Cells[rowIndex + 2, colIndex + 1] = "序号";
                        else
                            Mylxls.Cells[rowIndex + 2, colIndex + 1] = dgvResultList.Columns[colIndex - 1].HeaderText;
                        Mylxls.get_Range(Mylxls.Cells[rowIndex + 2, colIndex + 1], Mylxls.Cells[rowIndex + 2, colIndex + 1]).Cells.Borders.LineStyle = 1;
                        Mylxls.get_Range(Mylxls.Cells[rowIndex + 2, colIndex + 1], Mylxls.Cells[rowIndex + 2, colIndex + 1]).Font.Bold = true;
                        Mylxls.get_Range(Mylxls.Cells[rowIndex + 2, colIndex + 1], Mylxls.Cells[rowIndex + 2, colIndex + 1]).Font.Size = headFont.Size;
                        Mylxls.get_Range(Mylxls.Cells[rowIndex + 2, colIndex + 1], Mylxls.Cells[rowIndex + 2, colIndex + 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    }

                    rowIndex = rowIndex + 3;
                    for (int ii = 0; ii < lstResultInfo.Count; ii++)
                    {
                        for (int colIndex = 0; colIndex < dgvResultList.Columns.Count + 1; colIndex++)
                        {
                            if (colIndex == 0)
                                Mylxls.Cells[rowIndex, colIndex + 1] = ii + 1;
                            else
                                Mylxls.Cells[rowIndex, colIndex + 1] = (string)dgvResultList[colIndex - 1, ii].Value;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, colIndex + 1], Mylxls.Cells[rowIndex, colIndex + 1]).Cells.Borders.LineStyle = 1;
                            Mylxls.get_Range(Mylxls.Cells[rowIndex, colIndex + 1], Mylxls.Cells[rowIndex, colIndex + 1]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        }
                        rowIndex++;
                    }
                    dgvResultList.Rows.Clear();
                    nSpanCount++;
                }
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visibleColumnCount]).MergeCells = true;
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).RowHeight = 30;
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Name = "黑体";
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Size = 14;
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visibleColumnCount]).HorizontalAlignment = XlHAlign.xlHAlignCenter;

                Workbook workBook = Mylxls.Workbooks.get_Item(1);
                if (workBook == null)
                {
                    MessageBoxEx.Show("数据导出发生错误， 请重试！");
                    return;
                }
                workBook.Saved = true;
                workBook.SaveCopyAs(szFilePath);
                Mylxls.Workbooks.Close();
                Mylxls.Quit();
                Mylxls = null;
                MessageBoxEx.Show("导出Excel成功!", MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("数据导出失败，请确认您的机子上装有Microsoft Office Excel！", MessageBoxIcon.Error);
                LogManager.Instance.WriteLog("StatExpExcelHelper.ExportTo", new string[] { "dgv", "szFileTitle" }
                    , new string[] { dgv.Name.ToString(), szFileTitle }, "数据导出失败，请确认您的机子上装有Microsoft Office Excel!\n" + ex.ToString());
            }
        }

        /// <summary>
        /// 将查询到的检查项目列表绑定到gridview中
        /// </summary>
        /// <param name="dgvResultList">gridview</param>
        /// <param name="lstResultInfo">检查项目列表</param>
        private void BindResultList(DataGridView dgvResultList, List<LabResult> lstResultInfo)
        {
            dgvResultList.Rows.Clear();
            for (int index = lstResultInfo.Count - 1; index >= 0; index--)
            {
                LabResult resultInfo = lstResultInfo[index];
                if (resultInfo == null)
                    continue;
                int nRowIndex = dgvResultList.Rows.Add();
                DataGridViewRow row = dgvResultList.Rows[nRowIndex];
                row.Cells[0].Value = resultInfo.ITEM_NAME;
                row.Cells[1].Value = resultInfo.ITEM_RESULT;
                row.Cells[2].Value = resultInfo.ITEM_UNITS;
                row.Cells[3].Value = resultInfo.ABNORMAL_INDICATOR;
                row.Cells[4].Value = resultInfo.ITEM_REFER;
            }
        }

        public void ExportTo(DataGridView dgv, string szFileTitle)
        {
            if (dgv == null || dgv.Rows.Count == 0)
                return;

            int curColumnIndex = 1;     //当前操作列的索引
            int visibleColumnCount = 0;     //DataGridView可见列数
            string szFileName = szFileTitle + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            System.Drawing.Font headFont = dgv.RowHeadersDefaultCellStyle.Font;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Title = "Excel导出";
            saveDialog.DefaultExt = szFileName;
            saveDialog.FileName = szFileTitle + DateTime.Now.ToString("yyyyMMddHHmmss");
            saveDialog.Filter = "Excel文件|*.xls|所有文件|*.*";
            if (saveDialog.ShowDialog() != DialogResult.OK)
                return;
            string szFilePath = saveDialog.FileName;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible != true || (!(dgv.Columns[i] is DataGridViewTextBoxColumn) && !(dgv.Columns[i] is DataGridViewLinkColumn)))
                    continue;
                if (this.m_htNoExportColIndex != null && this.m_htNoExportColIndex.Contains(i))
                    continue;
                visibleColumnCount++;
            }

            try
            {
                ApplicationClass Mylxls = new ApplicationClass();
                if (Mylxls == null)
                {
                    MessageBoxEx.Show("数据导出失败，请确认您的机子上装有Microsoft Office Excel！", MessageBoxIcon.Information);
                    return;
                }
                Mylxls.Application.Workbooks.Add(true);
                Mylxls.Cells.Font.Size = 10.5;
                Mylxls.Caption = szFileName;       //设置标头
                Mylxls.Cells[1, 1] = szFileName;    //显示表头
                Mylxls.Cells.NumberFormatLocal = "@";//控制首位数字为0导出后消失

                //设置数据列头
                //判断是否是MultiMergeHeaderDataGridView，如果是那么列头可能多行

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    if (dgv.Columns[i].HeaderText.IndexOf("入院后第二天病程记录") > 0)
                    {

                    }
                    if (dgv.Columns[i].Visible != true || (!(dgv.Columns[i] is DataGridViewTextBoxColumn) && !(dgv.Columns[i] is DataGridViewLinkColumn)))
                        continue;
                    if (this.m_htNoExportColIndex != null && this.m_htNoExportColIndex.Contains(i))
                        continue;
                    
                    Mylxls.Cells[2, curColumnIndex] = dgv.Columns[i].HeaderText;
                    Mylxls.get_Range(Mylxls.Cells[2, curColumnIndex], Mylxls.Cells[2, curColumnIndex]).Cells.Borders.LineStyle = 1;
                    Mylxls.get_Range(Mylxls.Cells[2, curColumnIndex], Mylxls.Cells[2, curColumnIndex]).ColumnWidth = dgv.Columns[i].Width / 8;
                    Mylxls.get_Range(Mylxls.Cells[2, curColumnIndex], Mylxls.Cells[2, curColumnIndex]).Font.Bold = true;
                    Mylxls.get_Range(Mylxls.Cells[2, curColumnIndex], Mylxls.Cells[2, curColumnIndex]).Font.Size = headFont.Size;
                    Mylxls.get_Range(Mylxls.Cells[2, curColumnIndex], Mylxls.Cells[2, curColumnIndex]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    curColumnIndex++;
                }
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visibleColumnCount]).MergeCells = true;
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).RowHeight = 30;
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Name = "黑体";
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, 1]).Font.Size = 14;
                Mylxls.get_Range(Mylxls.Cells[1, 1], Mylxls.Cells[1, visibleColumnCount]).HorizontalAlignment = XlHAlign.xlHAlignCenter;

                object[,] dataArray = new object[dgv.Rows.Count, visibleColumnCount];
                //Exc版本不同，时间格式的数据有可能会被改成小数
                //记录数据为时间格式的列index，在赋值完数据后修改格式
                Hashtable hsDateTime = new Hashtable();//记录列index为时间格式的数据
                Hashtable hsDate = new Hashtable();//记录列index为日期的数据
                Hashtable hsUnShowColumns = new Hashtable();//不需要显示的列数据
                for (int i = 0; i < dgv.Rows.Count; i++)   //循环填充数据
                {
                    curColumnIndex = 1;
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Columns[j].Visible != true || (!(dgv.Columns[j] is DataGridViewTextBoxColumn) && !(dgv.Columns[j] is DataGridViewLinkColumn)))
                        {
                            if (!hsUnShowColumns.ContainsKey(j))
                                hsUnShowColumns.Add(j, j);
                            continue;
                        }
                        if (this.m_htNoExportColIndex != null && this.m_htNoExportColIndex.Contains(j))
                        {
                            if (!hsUnShowColumns.ContainsKey(j))
                                hsUnShowColumns.Add(j, j);
                            continue;
                        }
                        if (dgv[j, i].Value != null)  //如果单元格内容不为空
                        {
                            dataArray[i, curColumnIndex - 1] = dgv[j, i].Value.ToString();
                            //将列数据为日期的列记录
                            DateTime defaultTime = new DateTime();
                            bool IsTimeValue = DateTime.TryParse(dgv[j, i].Value.ToString(), out defaultTime);
                            if (IsTimeValue && !hsDateTime.ContainsKey(j - hsUnShowColumns.Count))
                            {
                                hsDateTime.Add(j - hsUnShowColumns.Count, j - hsUnShowColumns.Count);//排除隐藏列
                                if (defaultTime.Hour == 0 && defaultTime.Minute == 0 && defaultTime.Second == 0)
                                {
                                    hsDate.Add(j - hsUnShowColumns.Count, j - hsUnShowColumns.Count);//排除隐藏列
                                }
                            }
                        }
                        curColumnIndex++;
                    }
                }

                Mylxls.get_Range(Mylxls.Cells[3, 1], Mylxls.Cells[dgv.Rows.Count + 2, visibleColumnCount]).Value2 = dataArray;          //设置边框
                Mylxls.get_Range(Mylxls.Cells[3, 1], Mylxls.Cells[dgv.Rows.Count + 2, visibleColumnCount]).Cells.Borders.LineStyle = 1; //设置边框
                if (hsDateTime != null && hsDateTime.Count > 0)//设置时间格式
                {
                    foreach (object obj in hsDateTime.Values)
                    {
                        int i = (int)obj;
                        if (i <= 0)
                            continue;
                        if (hsDate.ContainsKey(i))//年月日
                        {
                            Mylxls.get_Range(Mylxls.Cells[3, i + 1], Mylxls.Cells[dgv.Rows.Count + 2, i + 1]).NumberFormat = "yyyy/M/d";
                        }
                        else//年月日时分秒
                        {
                            Mylxls.get_Range(Mylxls.Cells[3, i + 1], Mylxls.Cells[dgv.Rows.Count + 2, i + 1]).NumberFormat = "yyyy/M/d HH:mm:ss";
                        }
                    }
                }

                Workbook workBook = Mylxls.Workbooks.get_Item(1);
                if (workBook == null)
                {
                    MessageBoxEx.Show("数据导出发生错误， 请重试！");
                    return;
                }
                workBook.Saved = true;
                workBook.SaveCopyAs(szFilePath);
                Mylxls.Workbooks.Close();
                Mylxls.Quit();
                Mylxls = null;
                if (!GlobalMethods.Win32.Execute(szFilePath, null))
                    MessageBoxEx.ShowMessage("已导出完成!但无法打开,您可能没有安装Excel软件!");
                //MessageBoxEx.Show("导出Excel成功!", MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("数据导出失败，请确认您的机子上装有Microsoft Office Excel！", MessageBoxIcon.Error);
                LogManager.Instance.WriteLog("StatExpExcelHelper.ExportTo", new string[] { "dgv", "szFileTitle" }
                    , new string[] { dgv.Name.ToString(), szFileTitle }, "数据导出失败，请确认您的机子上装有Microsoft Office Excel!\n" + ex.ToString());
            }
            finally
            {

            }
        }

        /// <summary>
        /// 获取Nodes最高层级
        /// </summary>
        /// <param name="tnc"></param>
        /// <param name="iNodeLevels"></param>
        /// <returns></returns>
        public int GetNodeLevels(TreeNodeCollection tnc, ref int iNodeLevels)
        {
            if (tnc == null) return 0;

            foreach (TreeNode tn in tnc)
            {
                if ((tn.Level + 1) > iNodeLevels)//tn.Level是從0開始的
                {
                    iNodeLevels = tn.Level + 1;
                }

                if (tn.Nodes.Count > 0)
                {
                    GetNodeLevels(tn.Nodes, ref iNodeLevels);
                }
            }

            return iNodeLevels;
        }

        private int GetSubNodeCount(TreeNode node, int count)
        {
            if (node.Nodes != null)
            {
                foreach (TreeNode nd in node.Nodes)
                {
                    count += GetSubNodeCount(nd, count);
                }
            }
            else
            {
                return 1;
            }
            return count;
        }

    }
}
