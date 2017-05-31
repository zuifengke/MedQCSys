using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace HerenControls
{
    public class MultiMergeHeaderDataGridView : DataGridView
    {

        #region 字段定義

        /// <summary>多維列標題的樹結構
        /// 
        /// </summary>
        private TreeView _ColHeaderTreeView;

        /// <summary>樹的最大層數
        /// 
        /// </summary>
        private int iNodeLevels;

        /// <summary>一維列標題的高度
        /// 
        /// </summary>
        private int iCellHeight;

        /// <summary>所有葉節點
        /// 
        /// </summary>
        private IList<TreeNode> ColLists = new List<TreeNode>();

        #endregion

        #region 屬性定義

        /// <summary>多維列標題的樹結構
        /// 
        /// </summary>
        [
          Description("多維列標題的樹結構")
        ]
        public TreeView myColHeaderTreeView
        {
            get { return _ColHeaderTreeView; }
            set { _ColHeaderTreeView = value; }
        }

        #endregion

        #region 方法函數

        /// <summary>遞歸計算樹最大層數，並保存所有葉節點
        /// 
        /// </summary>
        /// <param name="tnc"></param>
        /// <returns></returns>
        private int myGetNodeLevels(TreeNodeCollection tnc)
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
                    myGetNodeLevels(tn.Nodes);
                }
                else
                {
                    ColLists.Add(tn);//葉節點
                }
            }

            return iNodeLevels;
        }

        /// <summary>調用遞歸求最大層數、列頭總高
        /// 
        /// </summary>
        public void myNodeLevels()
        {

            iNodeLevels = 1;//初始為1

            ColLists.Clear();

            int iNodeDeep = myGetNodeLevels(_ColHeaderTreeView.Nodes);

            iCellHeight = this.ColumnHeadersHeight;

            this.ColumnHeadersHeight = this.ColumnHeadersHeight * iNodeDeep;//列頭總高=一維列高*層數

        }

        /// <summary>获得合并标题字段的宽度
        /// 
        /// </summary>
        /// <param name="node">字段节点</param>
        /// <returns>字段宽度</returns>
        private int GetUnitHeaderWidth(TreeNode node)
        {
            int uhWidth = 0;
            //获得最底层字段的宽度
            if (node.Nodes == null)
                return this.Columns[GetColumnListNodeIndex(node)].Width;

            if (node.Nodes.Count == 0)
                return this.Columns[GetColumnListNodeIndex(node)].Width;

            //获得非最底层字段的宽度
            for (int i = 0; i <= node.Nodes.Count - 1; i++)
            {
                uhWidth = uhWidth + GetUnitHeaderWidth(node.Nodes[i]);
            }
            return uhWidth;
        }

        /// <summary>获得底层字段索引
        /// 
        /// </summary>
        ///' <param name="node">底层字段节点</param>
        /// <returns>索引</returns>
        /// <remarks></remarks>
        private int GetColumnListNodeIndex(TreeNode node)
        {
            for (int i = 0; i <= ColLists.Count - 1; i++)
            {
                if (ColLists[i].Equals(node))
                    return i;
            }
            return -1;
        }

        ///<summary>
        ///绘制合并表头
        ///</summary>
        ///<param name="node">合并表头节点</param>
        ///<param name="e">绘图参数集</param>
        ///<param name="level">结点深度</param>
        ///<remarks></remarks>
        public void PaintUnitHeader(
                        TreeNode node,
                        System.Windows.Forms.DataGridViewCellPaintingEventArgs e,
                        int level)
        {
            //根节点时退出递归调用
            if (level == 0)
                return;

            RectangleF uhRectangle;
            int uhWidth;
            SolidBrush gridBrush = new SolidBrush(this.GridColor);
            SolidBrush backColorBrush = new SolidBrush(e.CellStyle.BackColor);
            Pen gridLinePen = new Pen(gridBrush);
            StringFormat textFormat = new StringFormat();

            textFormat.Alignment = StringAlignment.Center;

            uhWidth = GetUnitHeaderWidth(node);

            //与原贴算法有所区别在这。
            if (node.Nodes.Count == 0)
            {
                uhRectangle = new Rectangle(e.CellBounds.Left,
                            e.CellBounds.Top + node.Level * iCellHeight,
                            uhWidth - 1,
                            iCellHeight * (iNodeLevels - node.Level) - 1);
            }
            else
            {
                uhRectangle = new Rectangle(
                            e.CellBounds.Left,
                            e.CellBounds.Top + node.Level * iCellHeight,
                            uhWidth - 1,
                            iCellHeight - 1);
            }

            //画矩形
            e.Graphics.FillRectangle(backColorBrush, uhRectangle);

            //划底线
            e.Graphics.DrawLine(gridLinePen
                                , uhRectangle.Left
                                , uhRectangle.Bottom
                                , uhRectangle.Right
                                , uhRectangle.Bottom);
            //划右端线
            e.Graphics.DrawLine(gridLinePen
                                , uhRectangle.Right
                                , uhRectangle.Top
                                , uhRectangle.Right
                                , uhRectangle.Bottom);

            e.Graphics.DrawString(node.Text, this.ColumnHeadersDefaultCellStyle.Font
                                    , Brushes.Black
                                    , uhRectangle.Left + uhRectangle.Width / 2 -
                                    e.Graphics.MeasureString(node.Text, this.ColumnHeadersDefaultCellStyle.Font).Width / 2 - 1
                                    , uhRectangle.Top +
                                    uhRectangle.Height / 2 - e.Graphics.MeasureString(node.Text, this.ColumnHeadersDefaultCellStyle.Font).Height / 2);

            //递归调用()
            if (node.PrevNode == null)
                if (node.Parent != null)
                    PaintUnitHeader(node.Parent, e, level - 1);
        }

        #endregion

        //重寫表頭
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                //行标题不重写
                if (e.ColumnIndex < 0)
                {
                    base.OnCellPainting(e);
                    return;
                }

                if (iNodeLevels == 1)
                {
                    base.OnCellPainting(e);
                    return;
                }

                //绘制表头
                if (e.RowIndex == -1)
                {
                    if (_ColHeaderTreeView != null)
                    {
                        if (iNodeLevels == 0)
                        {
                            myNodeLevels();
                        }

                        PaintUnitHeader((TreeNode)this.ColLists[e.ColumnIndex], e, iNodeLevels);

                        e.Handled = true;
                    }
                    else
                    {
                        base.OnCellPainting(e);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error");
            }
        }
    }
}
