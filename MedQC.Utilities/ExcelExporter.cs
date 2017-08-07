/********************************************************
 * @FileName   : ExcelExporter.cs
 * @Description: 封装与微软Excel导出有关的函数
 * @Author     : 杨明坤(YangMingkun)
 *               叶慧(YeHui)
 * @Date       : 2016-12-5 15:46:07
 *               2016-12-27
 * @History    : 
 * @Copyright  : 版权所有(C)浙江和仁科技股份有限公司
********************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Heren.Common.Libraries;
using Heren.Common.Controls.TableView;
using Heren.Common.ZipLib.Zip;

namespace Heren.MedQC.Utilities
{
    public partial struct ExcelExporter
    {
        #region"ExcelCotnent"
        /// <summary>
        /// Excel文档对象
        /// </summary>
        private class ExcelCotnent
        {
            private XmlDocument m_workbook = null;
            /// <summary>
            /// 获取或设置workbook.xml文档
            /// </summary>
            public XmlDocument WorkbookContent
            {
                get { return this.m_workbook; }
                set { this.m_workbook = value; }
            }

            private XmlDocument m_worksheets = null;
            /// <summary>
            /// 获取或设置worksheets.xml文档
            /// </summary>
            public XmlDocument WorksheetsContent
            {
                get { return this.m_worksheets; }
                set { this.m_worksheets = value; }
            }

            private XmlDocument m_sharedStrings = null;
            /// <summary>
            /// 获取或设置sharedStrings.xml文档
            /// </summary>
            public XmlDocument SharedStringsContent
            {
                get { return this.m_sharedStrings; }
                set { this.m_sharedStrings = value; }
            }
        }
        #endregion

        /// <summary>
        /// 获取或设置缺省命名空间URI
        /// </summary>
        private static string NamespaceUri
        {
            get
            {
                return "http://schemas.openxmlformats.org/spreadsheetml/2006/main";
            }
        }

        private static XmlNamespaceManager m_xmlNamespaceManager = null;
        /// <summary>
        /// 获取或设置缺省命名空间管理器
        /// </summary>
        private static XmlNamespaceManager NamespaceManager
        {
            get
            {
                if (m_xmlNamespaceManager == null)
                {
                    NameTable table = new NameTable();
                    m_xmlNamespaceManager = new XmlNamespaceManager(table);
                    m_xmlNamespaceManager.AddNamespace("ns", NamespaceUri);
                }
                return m_xmlNamespaceManager;
            }
        }

        /// <summary>
        /// 获取指定行列单元格的名称
        /// </summary>
        /// <param name="row">行索引</param>
        /// <param name="column">列索引</param>
        /// <returns>单元格的名称</returns>
        private static string GetExcelCellName(int row, int column)
        {
            string cellName = GetColumnName(column + 1);
            return string.Concat(cellName, row + 1);
        }

        /// <summary>
        /// 获取指定列的名称
        /// </summary>
        /// <param name="column">列索引</param>
        /// <returns>列的名称</returns>
        private static string GetColumnName(int columnIndex)
        {
            string result = "";
            if (columnIndex <= 26)
            {
                result = (char)(columnIndex + 64) + result;
                return result.ToUpper();
            }

            int modOf26 = columnIndex % 26;
            int left = 0;
            if (modOf26 == 0)
            {
                result = 'Z' + result;
                left = columnIndex - 26;
            }
            else
            {
                result = (char)(modOf26 + 64) + result;
                left = columnIndex - modOf26;
            }

            int nextInputValue = left / 26;
            if (nextInputValue == 0)
                return result.ToUpper();

            if (nextInputValue > 26)
                result = GetColumnName(nextInputValue) + result;
            else
                result = (char)(nextInputValue + 64) + result;
            return result.ToUpper();
        }

        private static ExcelCotnent GetTempletContent()
        {
            ExcelCotnent content = new ExcelCotnent();
            MemoryStream stream = new MemoryStream(Properties.Resources.ExportTemplet);
            ZipInputStream zipstream = new ZipInputStream(stream);
            try
            {
                Heren.Common.ZipLib.Zip.ZipEntry entry = zipstream.GetNextEntry();
                while (entry != null)
                {
                    if (entry.Name == "xl/workbook.xml")
                    {
                        content.WorkbookContent = GlobalMethods.Xml.GetXmlDocument(zipstream);
                    }
                    else if (entry.Name == "xl/sharedStrings.xml")
                    {
                        content.SharedStringsContent = GlobalMethods.Xml.GetXmlDocument(zipstream);
                    }
                    else if (entry.Name == "xl/worksheets/sheet1.xml")
                    {
                        content.WorksheetsContent = GlobalMethods.Xml.GetXmlDocument(zipstream);
                    }
                    entry = zipstream.GetNextEntry();
                }

                XmlNode columnsNode = GetColumnsNode(content);
                columnsNode.RemoveAll();

                XmlNode rowsNode = GetRowsNode(content);
                rowsNode.RemoveAll();

                content.SharedStringsContent.DocumentElement.RemoveAll();
                return content;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("GlobalMethods.ExportExcelFile", ex);
                return null;
            }
            finally
            {
                zipstream.Close();
                zipstream.Dispose();
                stream.Close();
                stream.Dispose();
            }
        }

        private static XmlNode GetRowsNode(ExcelCotnent content)
        {
            return content.WorksheetsContent.SelectSingleNode("/ns:worksheet/ns:sheetData", NamespaceManager);
        }

        private static XmlNode GetGroupsNode(ExcelCotnent content)
        {
            return content.WorksheetsContent.SelectSingleNode("/ns:worksheet/ns:mergeCells", NamespaceManager);
        }

        private static XmlNode GetColumnsNode(ExcelCotnent content)
        {
            return content.WorksheetsContent.SelectSingleNode("/ns:worksheet/ns:cols", NamespaceManager);
        }

        private static bool WriteWorksheetName(ExcelCotnent content, string name)
        {
            if (content.WorkbookContent == null)
                return false;

            string xpath = "/ns:workbook/ns:sheets/ns:sheet[@name='Sheet1']";
            XmlNode sheetNode = content.WorkbookContent.SelectSingleNode(xpath, NamespaceManager);
            sheetNode.Attributes["name"].Value = name;
            return true;
        }

        private static XmlNode WriteRowContent(ExcelCotnent content, XmlNode rowsNode, int index)
        {
            XmlNode rowNode = rowsNode.AppendChild(content.WorksheetsContent.CreateElement("row", NamespaceUri));
            XmlAttribute attr = rowNode.Attributes.Append(content.WorksheetsContent.CreateAttribute("r"));
            attr.Value = (index + 1).ToString();
            return rowNode;
        }

        private static XmlNode WriteColumnContent(ExcelCotnent content, XmlNode columnsNode, int column
            , string name, int width, string styleId)
        {
            //worksheet
            XmlNode columnNode = columnsNode.AppendChild(content.WorksheetsContent.CreateElement("col", NamespaceUri));
            XmlAttribute attr = columnNode.Attributes.Append(content.WorksheetsContent.CreateAttribute("min"));
            attr.Value = (column + 1).ToString();
            attr = columnNode.Attributes.Append(content.WorksheetsContent.CreateAttribute("max"));
            attr.Value = (column + 1).ToString();
            attr = columnNode.Attributes.Append(content.WorksheetsContent.CreateAttribute("width"));
            attr.Value = (GlobalMethods.Convert.Pixel2MM(width, false) / 2.54f).ToString();
            attr = columnNode.Attributes.Append(content.WorksheetsContent.CreateAttribute("customWidth"));
            attr.Value = "1";
            return columnNode;
        }

        private static XmlNode WriteCellContent(ExcelCotnent content, XmlNode rowNode, int row, int column
            , int columnCount, string value, string styleId)
        {
            //sharedStrings
            XmlNode sstNode = content.SharedStringsContent.DocumentElement;
            XmlNode siNode = sstNode.AppendChild(content.SharedStringsContent.CreateElement("si", NamespaceUri));

            XmlNode node = siNode.AppendChild(content.SharedStringsContent.CreateElement("t", NamespaceUri));
            node.InnerText = value;

            node = siNode.AppendChild(content.SharedStringsContent.CreateElement("phoneticPr", NamespaceUri));
            XmlAttribute attr = node.Attributes.Append(content.SharedStringsContent.CreateAttribute("fontId"));
            attr.Value = "1";
            attr = node.Attributes.Append(content.SharedStringsContent.CreateAttribute("type"));
            attr.Value = "noConversion";

            node = rowNode.AppendChild(content.WorksheetsContent.CreateElement("c", NamespaceUri));
            attr = node.Attributes.Append(content.WorksheetsContent.CreateAttribute("r"));
            attr.Value = GetExcelCellName(row, column);
            attr = node.Attributes.Append(content.WorksheetsContent.CreateAttribute("s"));
            attr.Value = styleId;
            attr = node.Attributes.Append(content.WorksheetsContent.CreateAttribute("t"));
            attr.Value = "s";

            node = node.AppendChild(content.WorksheetsContent.CreateElement("v", NamespaceUri));
            node.InnerText = (row * columnCount + column).ToString();
            return siNode;
        }

        private static bool SaveExcelFile(ExcelCotnent content, string fileName)
        {
            string workbookFile = GlobalMethods.IO.GetFilePath(fileName) + "\\workbook.xml";
            if (!GlobalMethods.Xml.SaveXmlDocument(content.WorkbookContent, workbookFile))
                return false;

            string sharedStringsFile = GlobalMethods.IO.GetFilePath(fileName) + "\\sharedStrings.xml";
            if (!GlobalMethods.Xml.SaveXmlDocument(content.SharedStringsContent, sharedStringsFile))
                return false;

            string worksheetsFile = GlobalMethods.IO.GetFilePath(fileName) + "\\worksheets.xml";
            if (!GlobalMethods.Xml.SaveXmlDocument(content.WorksheetsContent, worksheetsFile))
                return false;

            if (!GlobalMethods.IO.WriteFileBytes(fileName, Properties.Resources.ExportTemplet))
                return false;

            try
            {
                ZipFile zipFile = new ZipFile(fileName);
                zipFile.BeginUpdate();
                zipFile.Add(workbookFile, "xl/workbook.xml");
                zipFile.Add(sharedStringsFile, "xl/sharedStrings.xml");
                zipFile.Add(worksheetsFile, "xl/worksheets/sheet1.xml");
                zipFile.CommitUpdate();
                zipFile.Close();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.WriteLog("GlobalMethods.SaveExcelFile"
                    , new string[] { "fileName" }, new string[] { fileName }, ex);
                return false;
            }
            finally
            {
                GlobalMethods.IO.DeleteFile(workbookFile);
                GlobalMethods.IO.DeleteFile(sharedStringsFile);
                GlobalMethods.IO.DeleteFile(worksheetsFile);
            }
        }

        /// <summary>
        /// 将指定表格导出为Excel文件
        /// </summary>
        /// <param name="table">DataTable</param>
        /// <param name="fileName">Excel文件名</param>
        /// <returns>是否成功</returns>
        public static bool ExportExcelFile(DataTable table, string fileName)
        {
            ExcelCotnent content = GetTempletContent();
            if (content == null || content.WorkbookContent == null
                || content.WorksheetsContent == null || content.SharedStringsContent == null)
                return false;

            WriteWorksheetName(content, GlobalMethods.IO.GetFileName(fileName, false));

            XmlNode columnsNode = GetColumnsNode(content);
            XmlNode rowsNode = GetRowsNode(content);
            XmlNode rowNode = WriteRowContent(content, rowsNode, 0);
            for (int columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
            {
                DataColumn column = table.Columns[columnIndex];

                string columnName = column.ColumnName;
                if (string.IsNullOrEmpty(columnName))
                    columnName = string.Concat("Column", columnIndex + 1);

                WriteColumnContent(content, columnsNode, columnIndex, columnName, 100, "1");
                WriteCellContent(content, rowNode, 0, columnIndex, table.Columns.Count, columnName, "1");
            }
            for (int rowIndex = 0; rowIndex < table.Rows.Count; rowIndex++)
            {
                DataRow row = table.Rows[rowIndex];
                rowNode = WriteRowContent(content, rowsNode, rowIndex + 1);

                for (int columnIndex = 0; columnIndex < table.Columns.Count; columnIndex++)
                {
                    string value = row.IsNull(columnIndex) ? string.Empty : row[columnIndex].ToString();
                    WriteCellContent(content, rowNode, rowIndex + 1, columnIndex, table.Columns.Count, value, "2");
                }
            }
            return SaveExcelFile(content, fileName);
        }

        /// <summary>
        /// 将指定表格导出为Excel文件
        /// </summary>
        /// <param name="gridView">DataGridView</param>
        /// <param name="onlySelected">是否仅选中内容</param>
        /// <param name="fileName">Excel文件名</param>
        /// <returns>是否成功</returns>
        public static bool ExportExcelFile(DataGridView gridView, bool onlySelected, string fileName)
        {
            if (gridView == null || string.IsNullOrEmpty(fileName)
                || gridView.Rows.Count <= 0 || gridView.Columns.Count <= 0)
                return false;

            int rowCount = gridView.RowCount, startRow = 0, endRow = rowCount - 1;
            int columnCount = gridView.ColumnCount, startColumn = 0, endColumn = columnCount - 1;
            if (onlySelected)
            {
                if (gridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                {
                    if (gridView.SelectedRows.Count <= 0)
                        return false;
                    startRow = gridView.SelectedRows[gridView.SelectedRows.Count - 1].Index;
                    endRow = gridView.SelectedRows[0].Index;
                    if (startRow > endRow)
                    {
                        startRow = gridView.SelectedRows[0].Index;
                        endRow = gridView.SelectedRows[gridView.SelectedRows.Count - 1].Index;
                    }
                    rowCount = endRow - startRow + 1;
                }
                else if (gridView.SelectionMode == DataGridViewSelectionMode.FullColumnSelect)
                {
                    if (gridView.SelectedColumns.Count <= 0)
                        return false;
                    startColumn = gridView.SelectedColumns[gridView.SelectedColumns.Count - 1].Index;
                    endColumn = gridView.SelectedColumns[0].Index;
                    if (startColumn > endColumn)
                    {
                        startColumn = gridView.SelectedColumns[0].Index;
                        endColumn = gridView.SelectedColumns[gridView.SelectedColumns.Count - 1].Index;
                    }
                    columnCount = endColumn - startColumn + 1;
                }
            }

            ExcelCotnent content = GetTempletContent();
            if (content == null || content.WorkbookContent == null
                || content.WorksheetsContent == null || content.SharedStringsContent == null)
                return false;

            WriteWorksheetName(content, GlobalMethods.IO.GetFileName(fileName, false));

            XmlNode columnsNode = GetColumnsNode(content);
            XmlNode rowsNode = GetRowsNode(content);

            XmlNode rowNode = WriteRowContent(content, rowsNode, 0);
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                
                DataGridViewColumn column = gridView.Columns[startColumn + columnIndex];
                string columnName = column.HeaderText;
                if (string.IsNullOrEmpty(columnName))
                {
                    columnName = string.Concat("Column", columnIndex + 1);
                }
                WriteColumnContent(content, columnsNode, columnIndex, columnName, column.Width + 24, "1");
                WriteCellContent(content, rowNode, 0, columnIndex, columnCount, columnName, "1");
            }
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                DataGridViewRow row = gridView.Rows[startRow + rowIndex];
                if (row.IsNewRow)
                    continue;

                rowNode = WriteRowContent(content, rowsNode, rowIndex + 1);
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    DataGridViewColumn column = gridView.Columns[startColumn + columnIndex];
                    string columnName = column.HeaderText;
                    if (string.IsNullOrEmpty(columnName))
                    {
                        columnName = string.Concat("Column", columnIndex + 1);
                    }
                    string value = row.Cells[column.Index].Value == null ? string.Empty : row.Cells[column.Index].Value.ToString();
                    WriteCellContent(content, rowNode, rowIndex + 1, columnIndex, columnCount, value, "2");
                }
            }
            return SaveExcelFile(content, fileName);
        }

        /// <summary>
        /// 将指定表格导出为Excel文件
        /// </summary>
        /// <param name="gridView">DataGridView</param>
        /// <param name="onlySelected">是否仅选中内容</param>
        /// <param name="fileName">Excel文件名</param>
        /// <returns>是否成功</returns>
        public static bool ExportExcelFile(DataTableView gridView, bool onlySelected, string fileName)
        {
            if (gridView == null || string.IsNullOrEmpty(fileName)
                || gridView.Rows.Count <= 0 || gridView.Columns.Count <= 0)
                return false;

            int rowCount = gridView.RowCount, startRow = 0, endRow = rowCount - 1;
            int columnCount = gridView.ColumnCount, startColumn = 0, endColumn = columnCount - 1;
            if (onlySelected)
            {
                if (gridView.SelectionMode == DataGridViewSelectionMode.FullRowSelect)
                {
                    if (gridView.SelectedRows.Count <= 0)
                        return false;
                    startRow = gridView.SelectedRows[gridView.SelectedRows.Count - 1].Index;
                    endRow = gridView.SelectedRows[0].Index;
                    if (startRow > endRow)
                    {
                        startRow = gridView.SelectedRows[0].Index;
                        endRow = gridView.SelectedRows[gridView.SelectedRows.Count - 1].Index;
                    }
                    rowCount = endRow - startRow + 1;
                }
                else if (gridView.SelectionMode == DataGridViewSelectionMode.FullColumnSelect)
                {
                    if (gridView.SelectedColumns.Count <= 0)
                        return false;
                    startColumn = gridView.SelectedColumns[gridView.SelectedColumns.Count - 1].Index;
                    endColumn = gridView.SelectedColumns[0].Index;
                    if (startColumn > endColumn)
                    {
                        startColumn = gridView.SelectedColumns[0].Index;
                        endColumn = gridView.SelectedColumns[gridView.SelectedColumns.Count - 1].Index;
                    }
                    columnCount = endColumn - startColumn + 1;
                }
            }

            ExcelCotnent content = GetTempletContent();
            if (content == null || content.WorkbookContent == null
                || content.WorksheetsContent == null || content.SharedStringsContent == null)
                return false;

            WriteWorksheetName(content, GlobalMethods.IO.GetFileName(fileName, false));

            XmlNode columnsNode = GetColumnsNode(content);
            XmlNode rowsNode = GetRowsNode(content);
            XmlNode rowNode = null;
            int excelRowIndex = -1;

            //添加mergeCell
            if (gridView.Groups.Count > 0)
            {
                XmlElement groupsNode = content.WorksheetsContent.CreateElement("mergeCells", NamespaceUri);
                groupsNode.SetAttribute("count", gridView.Groups.Count.ToString());
                for (int index = 0; index < gridView.Groups.Count; index++)
                {
                    XmlElement groupNode = content.WorksheetsContent.CreateElement("mergeCell", NamespaceUri);
                    string beginCellName = GetExcelCellName(0, gridView.Groups[index].BeginColumn);
                    string endCellName = GetExcelCellName(0, gridView.Groups[index].EndColumn);
                    groupNode.SetAttribute("ref", string.Format("{0}:{1}", beginCellName, endCellName));
                    groupsNode.AppendChild(groupNode);
                }
                content.WorksheetsContent.DocumentElement.InsertAfter(groupsNode, rowsNode);

                //添加首行表头
                ++excelRowIndex;
                rowNode = WriteRowContent(content, rowsNode, excelRowIndex);
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {
                    if (string.IsNullOrEmpty(gridView.Columns[columnIndex].Name))
                        continue;
                    bool isGroupColumn = false;
                    for (int groupIndex = 0; groupIndex < gridView.Groups.Count; groupIndex++)
                    {
                        int nBeginColumn = gridView.Groups[groupIndex].BeginColumn;
                        int nEndColumn = gridView.Groups[groupIndex].EndColumn;
                        string value = gridView.Groups[groupIndex].Text;
                        if (columnIndex == nBeginColumn)
                        {
                            WriteCellContent(content, rowNode, excelRowIndex, columnIndex, columnCount, value, "3");
                            isGroupColumn = true;
                        }
                        else if (columnIndex > nBeginColumn && columnIndex <= nEndColumn)
                        {
                            WriteCellContent(content, rowNode, excelRowIndex, columnIndex, columnCount, string.Empty, "3");
                            isGroupColumn = true;
                        }
                    }
                    if (!isGroupColumn)
                    {
                        WriteCellContent(content, rowNode, excelRowIndex, columnIndex, columnCount, string.Empty, "1");
                    }
                }
            }

            //添加第二表头
            ++excelRowIndex;
            rowNode = WriteRowContent(content, rowsNode, excelRowIndex);
            for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
            {
                DataGridViewColumn column = gridView.Columns[startColumn + columnIndex];
                string columnName = column.HeaderText;
                if (string.IsNullOrEmpty(columnName))
                {
                    columnName = string.Concat("Column", columnIndex + 1);
                }
                WriteColumnContent(content, columnsNode, columnIndex, columnName, column.Width + 24, "1");
                WriteCellContent(content, rowNode, excelRowIndex, columnIndex, columnCount, columnName, "1");
            }

            //添加数据行
            ++excelRowIndex;
            for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
            {
                DataGridViewRow row = gridView.Rows[startRow + rowIndex];
                if (row.IsNewRow)
                    continue;

                rowNode = WriteRowContent(content, rowsNode, excelRowIndex + rowIndex);
                for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
                {

                    DataGridViewColumn column = gridView.Columns[startColumn + columnIndex];
                    string value = row.Cells[column.Index].Value == null ? string.Empty : row.Cells[column.Index].Value.ToString();
                    WriteCellContent(content, rowNode, excelRowIndex + rowIndex, columnIndex, columnCount, value, "2");
                }
            }
            return SaveExcelFile(content, fileName);
        }
    }
}
