using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
//Add new namespace
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MedQCSys.Controls
{
    public partial class CollapseDataGridView : DataGridView
    {
        #region Private fields

        private Color m_clrEven = Color.Gainsboro;  //偶数集合背景色（默认颜色：Gainsboro）
        private Color m_clrOdd = Color.White;       //奇数集合背景色（默认颜色：White）
        private Image m_imgExpand;                  //行首收缩图标
        private Image m_imgCollapse;                //行首展开图片
        private int m_nImageWidth;                  //行首图片宽度（默认15）
        private int m_nImageHeight;                 //行首图片高度（默认15）
        private int m_nGroupCount;                  //所含集合总数
        private int m_nItemCount;                   //所含条目总数
        private Color m_clrLastGroupColor;          //是否是另一集合
        private bool m_bIsInit;                     //是否初始加载数据
        private bool m_bIsFreezeGroupHeader;        //是否冻结集合头
        private bool m_bIsInitCollapsed;        //是否默认折叠

        //当行数量变化时，这里定制检测GroupCount
        private delegate void GroupCountChangedHandler();
        private event GroupCountChangedHandler OnGroupCountChanged;

        #endregion

        #region Public properties

        /// <summary>
        /// 偶数集合背景色（默认颜色：浅灰）
        /// </summary>
        [
        Category("CollapseDataGridViewProperties"),
        Description("偶数集合背景色（默认颜色：浅灰）"),
        Bindable(true)
        ]
        public Color GroupEvenColor
        {
            get { return m_clrEven; }
            set { m_clrEven = value; }
        }

        /// <summary>
        /// 奇数集合背景色（默认颜色：白色）
        /// </summary>
        [
        Category("CollapseDataGridViewProperties"),
        Description("奇数集合背景色（默认颜色：白色）"),
        Bindable(true)
        ]
        public Color GroupOddColor
        {
            get { return m_clrOdd; }
            set { m_clrOdd = value; }
        }

        /// <summary>
        /// 行首收缩图标
        /// </summary>
        [
        Category("CollapseDataGridViewProperties"),
        Description("行首收缩图标"),
        Bindable(true)
        ]
        public Image ImgExpand
        {
            get { return this.m_imgExpand; }
            set { this.m_imgExpand = value; }
        }

        /// <summary>
        /// 行首展开图片
        /// </summary>
        [
        Category("CollapseDataGridViewProperties"),
        Description("行首展开图片"),
        Bindable(true)
        ]
        public Image ImgCollapse
        {
            get { return this.m_imgCollapse; }
            set { this.m_imgCollapse = value; }
        }

        /// <summary>
        /// 行首图片宽度
        /// </summary>
        [
        Category("CollapseDataGridViewProperties"),
        Description("行首图片宽度"),
        Bindable(true)
        ]
        public int ImageWidth
        {
            get { return this.m_nImageWidth; }
            set { this.m_nImageWidth = value; }
        }

        /// <summary>
        /// 行首图片高度
        /// </summary>
        [
        Category("CollapseDataGridViewProperties"),
        Description("行首图片高度"),
        Bindable(true)
        ]
        public int ImageHeight
        {
            get { return this.m_nImageHeight; }
            set { this.m_nImageHeight = value; }
        }

        /// <summary>
        /// 所含集合总数
        /// </summary>
        [
        System.ComponentModel.Browsable(false),
        DefaultValue(0),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public int GroupCount
        {
            get { return this.m_nGroupCount; }
            private set
            {
                this.m_nGroupCount = value;
                //集合数量变化，控制是否冻结首行
                if (this.OnGroupCountChanged != null)
                    this.OnGroupCountChanged();
                //列表数据变化
                if (this.OnDataCountChanged != null)
                    this.OnDataCountChanged();
            }
        }

        /// <summary>
        /// 所含条目总数
        /// </summary>
        [
        System.ComponentModel.Browsable(false),
        DefaultValue(0),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public int ItemCount
        {
            get { return this.m_nItemCount; }
            private set
            {
                this.m_nItemCount = value;
                //列表数据变化
                if (this.OnDataCountChanged != null)
                    this.OnDataCountChanged();
            }
        }

        /// <summary>
        /// 是否冻结集合头
        /// </summary>
        [
        Category("CollapseDataGridViewProperties"),
        Description("是否冻结集合头"),
        DefaultValue(false),
        Bindable(true)
        ]
        public bool IsFreezeGroupHeader
        {
            get { return this.m_bIsFreezeGroupHeader; }
            set
            {
                this.m_bIsFreezeGroupHeader = value;
                if (this.Columns.Count > 0 && this.Rows.Count > 0)
                {
                    this.Columns[0].Frozen = value;
                }
            }
        }
        /// <summary>
        /// 是否冻结集合头
        /// </summary>
        [
        Category("CollapseDataGridViewProperties"),
        Description("是否默认折叠"),
        DefaultValue(false),
        Bindable(true)
        ]
        public bool IsInitCollapsed
        {
            get { return this.m_bIsInitCollapsed; }
            set
            {
                this.m_bIsInitCollapsed = value;
            }
        }
        
        #endregion

        #region Customized constructor

        public CollapseDataGridView()
            : base()
        {
            this.RowHeadersVisible = true;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.IsFreezeGroupHeader = false;
            this.m_nImageHeight = 15;
            this.m_nImageWidth = 15;
            this.m_clrLastGroupColor = Color.Empty;

            //隐藏行标题黑色箭头
            this.RowHeadersDefaultCellStyle.Padding = new Padding(this.RowHeadersWidth);
            this.OnGroupCountChanged += new GroupCountChangedHandler(CollapseDataGridView_OnGroupCountChanged);
        }

        //当集合数变化时
        void CollapseDataGridView_OnGroupCountChanged()
        {
            if (this.Columns.Count > 0 && this.Rows.Count > 0)
            {
                this.Columns[0].Frozen = this.m_bIsFreezeGroupHeader;
            }
            if (this.m_nGroupCount == 0)
            {
                this.m_clrOdd = Color.White;
                this.m_clrLastGroupColor = Color.Empty;
            }
        }

        #endregion

        #region Delegate & Event

        //绑定行委托
        public delegate void BindDataDetailHandler(object item, int rowIndex, bool isMainItem);
        /// <summary>
        /// 当绑定行数据时，由用户自行绑定各Cell值
        /// </summary>
        public event BindDataDetailHandler OnBindDataDetail;

        //删除集合委托
        public delegate void RemoveGroupHandler(object group, CollapseDataGridViewEventArgs e);
        /// <summary>
        /// 删除集合完成后
        /// </summary>
        public event RemoveGroupHandler RemoveGroupCompleted;

        //添加集合委托
        public delegate void AddGroupHandler(object group, CollapseDataGridViewEventArgs e);
        /// <summary>
        /// 添加集合完成后
        /// </summary>
        public event AddGroupHandler AddGroupCompleted;

        //添加元素委托
        public delegate void AddItemHandler(object item, CollapseDataGridViewEventArgs e);
        /// <summary>
        /// 添加元素完成后
        /// </summary>
        public event AddItemHandler AddItemCompleted;

        //移除元素委托
        public delegate void RemoveItemHandler(object item, CollapseDataGridViewEventArgs e);
        /// <summary>
        /// 移除元素完成后
        /// </summary>
        public event RemoveItemHandler RemoveItemCompleted;

        //列表数据发生变化委托事件
        public delegate void DataCountChangedHandler();
        /// <summary>
        /// 列表数据发生变化后
        /// </summary>
        public event DataCountChangedHandler OnDataCountChanged;

        #endregion

        #region Overwrite default methods

        /// <summary>
        /// 重写OnRowPostPaint()方法，以在折叠行前加上状态标识
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowPostPaint(DataGridViewRowPostPaintEventArgs e)
        {
            base.OnRowPostPaint(e);

            DataGridViewRow row = this.Rows[e.RowIndex];
            Rectangle rectBack = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, this.RowHeadersWidth, e.RowBounds.Height - 1);

            Rectangle rectLineBottom = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + e.RowBounds.Height - 1, this.RowHeadersWidth, 1);

            if (row is CollapseDataGridViewRow && (row as CollapseDataGridViewRow).Rows.Count != 0)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Location.X + 4, e.RowBounds.Location.Y + 4, this.m_nImageWidth, this.m_nImageHeight);
                Image img = null;
                if ((row as CollapseDataGridViewRow).IsCollapse)
                {
                    img = this.m_imgExpand;
                }
                else
                {
                    img = this.m_imgCollapse;
                }
                e.Graphics.DrawImage(img, rect);
            }
        }

        /// <summary>
        /// 增加点击行首折叠功能
        /// </summary>
        /// <param name="e"></param>
        protected override void OnRowHeaderMouseClick(DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = this.Rows[e.RowIndex];
            if (row is CollapseDataGridViewRow)
            {
                if ((row as CollapseDataGridViewRow).IsCollapse == true)
                {
                    this.Expand(e.RowIndex);
                }
                else
                {
                    this.Collapse(e.RowIndex);
                }
            }
            base.OnRowHeaderMouseClick(e);
        }

        #endregion

        #region Public methods

        /// <summary>
        /// 绑定集合列表
        /// <para>　　类型GL继承与List`List`T</para>
        /// </summary>
        /// <typeparam name="GL">集合列表类型</typeparam>
        /// <typeparam name="T">条目类型</typeparam>
        /// <param name="groupList">集合列表</param>
        public void BindDataSource<GL, T>(GL groupList) where GL : List<List<T>>
        {
            if (groupList != null)
            {
                for (int index = 0; index < groupList.Count; ++index)
                {
                    this.InitOneGroup<T>(groupList[index]);
                }
                if (this.Columns.Count > 0 && this.Rows.Count > 0 && this.IsFreezeGroupHeader)
                {
                    this.Columns[0].Frozen = true;
                }
            }
        }

        #region 折叠功能

        /// <summary>
        /// 获取折叠节点的rows
        /// </summary>
        /// <param name="nRowIndex">行号</param>
        /// <returns></returns>
        public CollapseDataGridViewRowCollection GetCollapseDataGridViewRow(int nRowIndex)
        {
            CollapseDataGridViewRowCollection collection = null;
            DataGridViewRow row = this.Rows[nRowIndex];
            if (row is CollapseDataGridViewRow)
            {
                collection = (row as CollapseDataGridViewRow).Rows;
            }
            return collection;
        }

        /// <summary>
        /// 展开
        /// </summary>
        /// <param name="nRowIndex">行号</param>
        public void Expand(int nRowIndex)
        {
            //if (this.Rows.Count <= 0)
            //    return;
            DataGridViewRow row = this.Rows[nRowIndex];
            if (row is CollapseDataGridViewRow)
            {
                if ((row as CollapseDataGridViewRow).IsCollapse == true)
                {
                    (row as CollapseDataGridViewRow).IsCollapse = false;

                    if ((row as CollapseDataGridViewRow).Rows.Count != 0)
                    {
                        for (int i = 0; i < (row as CollapseDataGridViewRow).Rows.Count; i++)
                        {
                            this.Rows.Insert(nRowIndex + 1 + i, (row as CollapseDataGridViewRow).Rows[i]);
                            //展开子条目时重绘子条目背景色，防止与主条目背景色不一致
                            //(row as CollapseDataGridViewRow).Rows[i].DefaultCellStyle.BackColor =
                                //(row as CollapseDataGridViewRow).DefaultCellStyle.BackColor;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 折叠
        /// </summary>
        /// <param name="nRowIndex">行号</param>
        public void Collapse(int nRowIndex)
        {
            DataGridViewRow row = this.Rows[nRowIndex];
            if ((row as CollapseDataGridViewRow).IsCollapse == false)
            {
                if ((row as CollapseDataGridViewRow).Rows.Count != 0)
                {
                    this.RemoveAllSubRow((CollapseDataGridViewRow)row, false);
                }
                (row as CollapseDataGridViewRow).IsCollapse = true;
            }
        }

        /// <summary>
        /// 获取集合信息
        /// </summary>
        /// <typeparam name="G">集合类型</typeparam>
        /// <returns>单个集合模型</returns>
        public G GetGroupInfo<G>()
        {
            try
            {
                if (this.SelectedRows.Count > 0)
                {
                    if (this.SelectedRows[0] is CollapseDataGridViewRow)
                    {
                        return (G)(this.SelectedRows[0] as CollapseDataGridViewRow).GroupTag;
                    }
                    else
                    {
                        int aimIndex = this.FindFirstAboveCollapseRow(this.SelectedRows[0].Index);
                        if (aimIndex != -1)
                        {
                            return (G)(this.Rows[aimIndex] as CollapseDataGridViewRow).GroupTag;
                        }
                        else
                        {
                            return default(G);
                        }
                    }
                }
                else
                    return default(G);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 行操作

        /// <summary>
        /// 新增一个条目
        /// <para>　　在列表尾集合追加一个条目，若列表为空，则新增一个集合，目标条目作为该集合的首条目</para>
        /// <para>类型G为集合类型，继承于List`T</para>
        /// <para>类型T为条目类型</para>
        /// </summary>
        /// <typeparam name="G">集合类型</typeparam>
        /// <typeparam name="T">条目类型</typeparam>
        /// <param name="item">条目信息</param>
        public void AddItem<G, T>(T item) where G : List<T>
        {
            if (item == null)
                item = Activator.CreateInstance<T>();
            if (this.Rows.Count > 0)
            {
                //加入新行
                int groupHeaderIndex = this.FindFirstAboveCollapseRow(this.SelectedRows[0].Index);
                int itemCount = (this.Rows[groupHeaderIndex] as CollapseDataGridViewRow).Rows.Count;
                this.AddOneItem<T>(item, groupHeaderIndex + itemCount);
            }
            else
            {
                //加入新集合
                //反射创建集合实例,AddGroup()方法使用多态，父类List<T>的引用指向子类G
                G group = Activator.CreateInstance<G>();
                group.Add(item);

                this.AddOneGroup<T>(group, 0, true);
                this.Rows[0].Selected = true;
                this.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        /// <summary>
        /// 在列表中插入一个条目
        /// <para>　　若列表为空，不操作</para>
        /// <para>　　若列表不为空，且选中集合行首，则在上一集合的尾部添加条目，若选中的是列表第一行，则在第一行作为新集合插入</para>
        /// <para>　　若列表不为空，选中行为普通条目，则在该位置添加一条条目，其他条目顺序下移</para>
        /// <para>类型G为集合类型，继承于List`T</para>
        /// <para>类型T为条目类型</para>
        /// </summary>
        /// <typeparam name="G">集合类型</typeparam>
        /// <typeparam name="T">条目类型</typeparam>
        /// <param name="item">条目信息</param>
        public void InsertItem<G, T>(T item) where G : List<T>
        {
            if (item == null)
                item = Activator.CreateInstance<T>();
            if (this.Rows.Count > 0 && this.SelectedRows.Count > 0)
            {
                if (this.SelectedRows[0] is CollapseDataGridViewRow &&
                    this.SelectedRows[0].Index == 0)
                {
                    //选中行为列表第一行，在第一行插入新组
                    G group = Activator.CreateInstance<G>();
                    group.Add(item);

                    this.AddOneGroup<T>(group, 0, true);
                    this.Rows[0].Selected = true;
                    this.FirstDisplayedScrollingRowIndex = 0;
                }
                else if (this.SelectedRows[0] is CollapseDataGridViewRow && this.SelectedRows[0].Index != 0)
                {
                    //选中行是集合首行，但不是首集合，则向上找出现的第一个集合，并返回集合首行号
                    int groupHeaderIndex = this.FindFirstAboveCollapseRow(this.SelectedRows[0].Index - 1);
                    int itemCount = (this.Rows[groupHeaderIndex] as CollapseDataGridViewRow).Rows.Count;
                    this.AddOneItem<T>(item, groupHeaderIndex + itemCount);
                }
                else if (!(this.SelectedRows[0] is CollapseDataGridViewRow) && this.SelectedRows[0].Index != 0)
                {
                    //找到所属集合首行号
                    int groupHeaderIndex = this.FindFirstAboveCollapseRow(this.SelectedRows[0].Index);
                    int itemCount = (this.Rows[groupHeaderIndex] as CollapseDataGridViewRow).Rows.Count;
                    this.AddOneItem<T>(item, this.SelectedRows[0].Index - 1);
                }
            }
        }

        /// <summary>
        /// 移除一条条目
        /// <para>类型T为条目类型</para>
        /// </summary>
        /// <typeparam name="T">条目类型</typeparam>
        /// <param name="itemIndex"></param>
        public void RemoveItem<T>(int itemIndex)
        {
            if (this.SelectedRows.Count > 0)
            {
                if (this.Rows[itemIndex] is CollapseDataGridViewRow)
                {
                    //展开集合
                    this.ExpendGroup(this.Rows[itemIndex] as CollapseDataGridViewRow);
                    //如果是折叠行，需要将下一行设为集合首行
                    this.RemoveGroupHeaderItem<T>(itemIndex);
                }
                else
                {
                    int startIndex = this.FindFirstAboveCollapseRow(itemIndex);
                    if (startIndex != -1)
                    {
                        //展开集合
                        this.ExpendGroup(this.Rows[startIndex] as CollapseDataGridViewRow);
                    }
                    //如果是普通行
                    this.RemoveNormalItem<T>(itemIndex);
                }
            }
        }

        #endregion

        #region 集合操作

        /// <summary>
        /// 插入一个集合
        /// <para>　　类型G继承与List`T</para>
        /// </summary>
        /// <typeparam name="G">集合类型</typeparam>
        /// <typeparam name="T">条目类型</typeparam>
        /// <param name="group">集合模型</param>
        public void InsertGroup<G, T>(G group) where G : List<T>
        {
            if (this.SelectedRows.Count > 0)
            {
                if (group == null)
                {
                    group = Activator.CreateInstance<G>();
                    T item = Activator.CreateInstance<T>();
                    group.Add(item);
                }

                //查找选中行所属集合的第一行
                int startIndex = 0;
                if (this.SelectedRows[0] is CollapseDataGridViewRow)
                {
                    //如果是折叠行，即为某集合的第一行，跳过查找，直接插入、着色
                    startIndex = this.SelectedRows[0].Index;
                    this.AddOneGroup<T>(group, this.SelectedRows[0].Index, false);
                }
                else
                {
                    //子条目行，向上查找集合首行
                    for (int rowIndex = this.SelectedRows[0].Index - 1; rowIndex >= 0; --rowIndex)
                    {
                        if (this.Rows[rowIndex] is CollapseDataGridViewRow)
                        {
                            startIndex = this.Rows[rowIndex].Index;
                            break;
                        }
                    }
                    this.AddOneGroup<T>(group, startIndex, false);
                }
                //行选中最后一个集合的首行
                this.Rows[startIndex].Selected = true;
            }
        }

        /// <summary>
        /// 在列表结尾新增一个集合
        /// <para>　　类型G继承与List`T</para>
        /// </summary>
        /// <typeparam name="G">集合类型</typeparam>
        /// <typeparam name="T">条目类型</typeparam>
        /// <param name="group">集合模型</param>
        public void AddGroup<G, T>(G group) where G : List<T>
        {
            int startIndex = this.Rows.Count;

            if (group == null)
            {
                group = Activator.CreateInstance<G>();
                T item = Activator.CreateInstance<T>();
                group.Add(item);
            }
            this.AddOneGroup<T>(group, this.Rows.Count, false);
            //行选中最后一个集合的首行
            this.Rows[startIndex].Selected = true;
            //设置滚动条
            this.FirstDisplayedScrollingRowIndex = startIndex;
        }

        /// <summary>
        /// 删除选中的集合
        /// </summary>
        /// <param name="itemIndex">选中的行号</param>
        public void RemoveGroup(int itemIndex)
        {
            if (this.SelectedRows.Count > 0)
            {
                //查找选中行所属集合的第一行
                int startIndex = 0;
                if (this.Rows[itemIndex] is CollapseDataGridViewRow)
                {
                    //展开集合
                    this.ExpendGroup(this.Rows[itemIndex] as CollapseDataGridViewRow);
                    //如果是折叠行，即为某集合的第一行，跳过查找，直接删除、重绘UI
                    startIndex = itemIndex;
                    this.RemoveOneGroup(itemIndex);
                }
                else
                {
                    startIndex = this.FindFirstAboveCollapseRow(itemIndex);
                    if (startIndex != -1)
                    {
                        //展开集合
                        this.ExpendGroup(this.Rows[startIndex] as CollapseDataGridViewRow);
                        this.RemoveOneGroup(startIndex);
                    }
                    else
                        return;//列表数据错误
                }
                //设置行选中位置
                if (this.Rows.Count > 0)
                {
                    if (startIndex == 0 || (startIndex != 0 && this.m_nGroupCount == 0))
                    {
                        //选中首集合的首行
                        this.Rows[0].Selected = true;
                    }
                    else if (startIndex != 0)
                    {
                        //删除的是尾集合，向上查找第一次出现的集合，并选中该集合首行
                        int aimIndex = this.FindFirstAboveCollapseRow(startIndex - 1);
                        if (aimIndex != -1)
                        {
                            this.Rows[aimIndex].Selected = true;
                            //设置滚动条
                            this.FirstDisplayedScrollingRowIndex = aimIndex;
                        }
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Private methods

        #region 着色区

        /// <summary>
        /// 新增、插入集合时设置集合颜色
        /// </summary>
        /// <param name="startIndex">主条目行号</param>
        /// <param name="itemCount">条目总数</param>
        private void RedrawGroupColor(int startIndex, int itemCount)
        {
            return;
            /*****************************
             * 只会有3种情况，除非垃圾数据
             *****************************/
            if (startIndex == 0 && this.Rows.Count - itemCount == 0)
            {
                //说明是在第一行，空列表
                if (this.m_clrLastGroupColor.Equals(Color.Empty) || this.m_clrLastGroupColor.Equals(this.m_clrEven))
                {
                    this.m_clrLastGroupColor = this.m_clrOdd;
                }
                else
                {
                    this.m_clrLastGroupColor = this.m_clrEven;
                }
                this.OperateRedraw(startIndex, itemCount);
            }
            else if (startIndex == 0 && this.Rows.Count - itemCount > 0)
            {
                //在第一行，非空列表，第一集合默认奇数集合（白色）
                this.m_clrLastGroupColor = this.m_clrOdd;
                this.OperateRedraw(startIndex, itemCount);
                //翻转其他集合颜色
                for (int index = itemCount; index < this.Rows.Count; index++)
                {
                    if (this.Rows[index].DefaultCellStyle.BackColor.Equals(this.m_clrOdd))
                    {
                        this.Rows[index].DefaultCellStyle.BackColor = this.m_clrEven;
                        this.m_clrLastGroupColor = this.m_clrEven;
                    }
                    else
                    {
                        this.Rows[index].DefaultCellStyle.BackColor = this.m_clrOdd;
                        this.m_clrLastGroupColor = this.m_clrOdd;
                    }
                }
            }
            else if (startIndex != 0 && this.Rows.Count - itemCount > 0)
            {
                //非第一行，设置为不同于上一集合的颜色，并变换之后集合的颜色
                //获取上一行颜色
                if (this.Rows[startIndex - 1].DefaultCellStyle.BackColor.Equals(this.m_clrEven))
                {
                    this.m_clrLastGroupColor = this.m_clrOdd;
                }
                else
                {
                    this.m_clrLastGroupColor = this.m_clrEven;
                }
                this.OperateRedraw(startIndex, startIndex + itemCount);
                //跳过初始绑定
                if (!this.m_bIsInit)
                {
                    //向下翻转所有集合颜色
                    this.ReverseGroupColor(startIndex + itemCount, this.Rows.Count);
                }
            }
        }

        /// <summary>
        /// 删除单个集合时重绘UI
        /// </summary>
        /// <param name="startIndex">删除起始行号</param>
        private void RedrawGroupColor(int startIndex)
        {
            return;
            if (startIndex <= this.Rows.Count)
            {
                //向下翻转所有集合颜色
                this.ReverseGroupColor(startIndex, this.Rows.Count);
            }
        }

        /// <summary>
        /// 翻转集合颜色
        /// </summary>
        /// <param name="startIndex">起始行号</param>
        /// <param name="totalCount">翻转范围</param>
        private void ReverseGroupColor(int startIndex, int totalCount)
        {
            return;
            for (int rowIndex = startIndex; rowIndex < totalCount; ++rowIndex)
            {
                if (this.Rows[rowIndex].DefaultCellStyle.BackColor.Equals(this.m_clrOdd))
                {
                    this.Rows[rowIndex].DefaultCellStyle.BackColor = this.m_clrEven;
                    this.m_clrLastGroupColor = this.m_clrEven;
                }
                else
                {
                    this.Rows[rowIndex].DefaultCellStyle.BackColor = this.m_clrOdd;
                    this.m_clrLastGroupColor = this.m_clrOdd;
                }
            }
        }

        /// <summary>
        /// 执行着色任务
        /// </summary>
        /// <param name="theColor">目标颜色</param>
        /// <param name="startIndex">起始行号</param>
        /// <param name="TotalCount">迭代条数</param>
        private void OperateRedraw(int startIndex, int totalCount)
        {
            return;
            for (int rowIndex = startIndex; rowIndex < totalCount; ++rowIndex)
            {
                this.Rows[rowIndex].DefaultCellStyle.BackColor = this.m_clrLastGroupColor;
            }
        }

        #endregion

        #region 条目操作

        /// <summary>
        /// 添加一条信息
        /// </summary>
        /// <typeparam name="T">条目类型</typeparam>
        /// <param name="item">条目模型</param>
        /// <param name="item">目标行号</param>
        private void AddOneItem<T>(T item, int currentIndex)
        {
            try
            {
                int groupIndex = this.FindFirstAboveCollapseRow(currentIndex);
                if (groupIndex != -1)
                    ((this.Rows[groupIndex] as CollapseDataGridViewRow).GroupTag as List<T>).Add(item);
                else
                    throw new Exception("No data found...");

                //创建当前行
                DataGridViewRow currentRow = new DataGridViewRow();
                /*********************************************************************
                 * 下面这两句必须这么写，先插入行，再用行号去获取行的实例
                 * 如果不写语句（2），在折叠操作时，在方法RemoveAllSubRow中
                 * this.Rows.Remove(row.Rows[i]);将会报“提供的行必须先取消共享”错误
                 * 可以对比一下（1）和（3）位置不同而带来的BUG
                 *********************************************************************/
                this.Rows.Insert(currentIndex + 1, currentRow);     //（1）
                currentRow = this.Rows[currentIndex + 1];           //（2）
                currentRow.Tag = item;
                //获取当前集合
                DataGridViewRow currentGroup = this.Rows[groupIndex];
                //设置行颜色
                currentRow.DefaultCellStyle.BackColor = this.Rows[groupIndex].DefaultCellStyle.BackColor;

                //this.Rows.Insert(currentIndex + 1, currentRow);   //（3）
                (currentGroup as CollapseDataGridViewRow).Rows.Add(currentRow);
                this.ItemCount++;

                if (this.OnBindDataDetail != null)
                {
                    //使用用户自定义绑定数据模式
                    this.OnBindDataDetail(item, currentIndex + 1, false);
                }
                else
                {
                    //使用默认绑定方式
                    this.BindDataDetails<T>
                        (
                            item,
                            (currentGroup as CollapseDataGridViewRow).Rows.Count,
                            currentIndex + 1
                        );
                }


                this.Rows[currentIndex + 1].Selected = true;
                this.FirstDisplayedScrollingRowIndex = currentIndex;

                if (this.AddItemCompleted != null)
                {
                    this.AddItemCompleted
                         (
                             item,
                             new CollapseDataGridViewEventArgs
                             {
                                 Result = true,
                                 RowIndex = currentIndex + 1,
                                 ErrorMessage = string.Empty
                             }
                         );
                }
            }
            catch (Exception ex)
            {
                if (this.AddItemCompleted != null)
                {
                    this.AddItemCompleted
                         (
                             null,
                             new CollapseDataGridViewEventArgs
                             {
                                 Result = false,
                                 RowIndex = currentIndex + 1,
                                 ErrorMessage = ex.Message
                             }
                         );
                }
            }
        }

        /// <summary>
        /// 删除普通行
        /// </summary>
        /// <typeparam name="T">条目类型</typeparam>
        /// <param name="itemIndex">条目行号</param>
        private void RemoveNormalItem<T>(int itemIndex)
        {
            try
            {
                //缓存Tag内容
                object tag = this.Rows[itemIndex].Tag;

                //向上查找所属集合的首行号
                int groupHeaderIndex = this.FindFirstAboveCollapseRow(itemIndex);

                //将该条目从集合的列表中删除
                if (this.Rows[groupHeaderIndex].Tag != null)
                {
                    //这里用Single是不保险的，要做数据模拟
                    bool IsExistModel =
                        (
                            (this.Rows[groupHeaderIndex] as CollapseDataGridViewRow).GroupTag as List<T>
                        ).Exists(I => I.Equals((T)tag));

                    if (IsExistModel)
                    {
                        //获取选中行相对于集合首行的位置，从而判断出选中行Tag在列表中的位置
                        int itemPosToHeader = itemIndex - groupHeaderIndex;
                        ((this.Rows[groupHeaderIndex] as CollapseDataGridViewRow).GroupTag as List<T>).RemoveAt(itemPosToHeader);

                        #region 另一种方法 -- 使用Single
                        //T resultItem =
                        //    (
                        //        (this.Rows[groupHeaderIndex] as CollapseDataGridViewRow).GroupTag as List<T>
                        //    ).Single
                        //    (
                        //        I =>
                        //            (
                        //                I.Equals(tag) &&
                        //                (
                        //                    (this.Rows[groupHeaderIndex] as CollapseDataGridViewRow).GroupTag as List<T>
                        //                ).IndexOf((T)tag).Equals(itemIndex - groupHeaderIndex)
                        //            )
                        //    );

                        //if (resultItem != null)
                        //    ((this.Rows[groupHeaderIndex] as CollapseDataGridViewRow).GroupTag as List<T>).Remove((T)resultItem);
                        #endregion
                    }
                }

                /******************************************************************************
                 * 从折叠行中删除此条目
                 * 应当先删除折叠行CollapseDataGridViewRowCollection中的对象
                 * 再从UI中删除，否则在折叠方法中，会报“所提供的行不属于当前DataGridView”错误
                 ******************************************************************************/
                (this.Rows[groupHeaderIndex] as CollapseDataGridViewRow).Rows.Remove(this.Rows[itemIndex]);
                this.Rows.Remove(this.Rows[itemIndex]);

                //设置统计条目的属性
                this.ItemCount--;

                if (this.RemoveItemCompleted != null)
                {
                    this.RemoveItemCompleted
                        (
                            tag,
                            new CollapseDataGridViewEventArgs
                            {
                                Result = true,
                                RowIndex = itemIndex,
                                ErrorMessage = String.Empty
                            }
                        );
                }
            }
            catch (Exception ex)
            {
                if (this.RemoveItemCompleted != null)
                {
                    this.RemoveItemCompleted
                        (
                            null,
                            new CollapseDataGridViewEventArgs
                            {
                                Result = false,
                                RowIndex = itemIndex,
                                ErrorMessage = ex.Message
                            }
                        );
                }
            }
        }

        /// <summary>
        /// 删除集合首行
        /// </summary>
        /// <typeparam name="T">条目类型</typeparam>
        /// <param name="itemIndex">条目行号</param>
        private void RemoveGroupHeaderItem<T>(int itemIndex)
        {
            try
            {
                //缓存Tag内容
                object tag = this.Rows[itemIndex].Tag;
                //缓存GroupTag内容
                List<T> groupTag = (this.Rows[itemIndex] as CollapseDataGridViewRow).GroupTag as List<T>;

                if ((this.Rows[itemIndex] as CollapseDataGridViewRow).Rows.Count != 0)
                {
                    //如果有下一行，从groupTag删除集合首行的tag
                    bool IsExistModel = groupTag.Exists(I => I.Equals((T)tag));

                    if (IsExistModel)
                    {
                        //从GroupTag中删除首行对应的模型
                        groupTag.RemoveAt(groupTag.IndexOf((T)tag));
                    }
                    //使CollapseDataGridViewRow的Tag保存下一行对应的模型
                    object nextTag = this.Rows[itemIndex + 1].Tag;
                    (this.Rows[itemIndex] as CollapseDataGridViewRow).Tag = nextTag;
                    //重新绑定集合行数据
                    if (this.OnBindDataDetail != null)
                    {
                        //使用用户自定义绑定数据模式
                        this.OnBindDataDetail(nextTag, itemIndex, true);
                    }
                    else
                    {
                        //使用默认绑定方式
                        this.BindDataDetails<T>
                            (
                                (T)nextTag,
                                0,//集合[0,0]显示集合分组
                                itemIndex
                            );
                    }
                    //从集合行中移除itemIndex + 1行
                    (this.Rows[itemIndex] as CollapseDataGridViewRow).Rows.Remove(this.Rows[itemIndex + 1]);
                    this.Rows.Remove(this.Rows[itemIndex + 1]);
                    this.ItemCount--;
                }
                else
                {
                    //如果仅剩下该行，直接移除
                    this.Rows.Remove(this.Rows[itemIndex]);
                    //设置列表属性
                    this.ItemCount--;
                    this.GroupCount--;
                    //向下重绘UI
                    //this.RedrawGroupColor(itemIndex);
                    //设置选中行
                    if (itemIndex >= this.Rows.Count)
                    {
                        this.Rows[this.Rows.Count - 1].Selected = true;
                    }
                }

                if (this.RemoveItemCompleted != null)
                {
                    this.RemoveItemCompleted
                        (
                            tag,
                            new CollapseDataGridViewEventArgs
                            {
                                Result = true,
                                RowIndex = itemIndex,
                                ErrorMessage = string.Empty
                            }
                        );
                }
            }
            catch (Exception ex)
            {
                if (this.RemoveItemCompleted != null)
                {
                    this.RemoveItemCompleted
                        (
                            null,
                            new CollapseDataGridViewEventArgs
                            {
                                Result = false,
                                RowIndex = itemIndex,
                                ErrorMessage = ex.Message
                            }
                        );
                }
            }
        }

        #endregion

        #region 集合操作

        /// <summary>
        /// 增加一个集合
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="itemList">单个集合（多条目）</param>
        /// <param name="startIndex">插入起始点</param>
        /// <param name="isFromAddItem">是否来自于添加条目</param>
        private void AddOneGroup<T>(List<T> itemList, int startIndex, bool isFromAddItem)
        {
            try
            {
                CollapseDataGridViewRow collapseRow = new CollapseDataGridViewRow();
                collapseRow.IsCollapse = true;
                collapseRow.GroupTag = itemList;//GroupTag作为集合信息宿主
                collapseRow.Tag = itemList[0];  //Tag缓存第一条条目信息

                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = "1";
                collapseRow.Cells.Add(cell);    //插入空行，否则无法折叠
                for (int itemIndex = 1; itemIndex < itemList.Count; itemIndex++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    cell = new DataGridViewTextBoxCell();
                    cell.Value = itemIndex + 1;
                    row.Cells.Add(cell);        //插入空行，否则无法折叠
                    row.Tag = itemList[itemIndex];
                    collapseRow.Rows.Add(row);
                }
                this.Rows.Insert(startIndex, collapseRow);//插入折叠行
                this.Expand(collapseRow.Index); //展开以填充数据

                //填充数据
                int rowIndex = startIndex + itemList.Count - 1;
                bool isMainItem = false;        //是否是第一行
                for (int itemIndex = itemList.Count - 1; itemIndex >= 0; --itemIndex)
                {
                    this.ItemCount++;
                    if (itemIndex == 0)
                    {
                        isMainItem = true;
                    }

                    //进行行数据绑定
                    if (this.OnBindDataDetail != null)
                    {
                        //使用用户自定义绑定数据模式
                        this.OnBindDataDetail(itemList[itemIndex], rowIndex, isMainItem);
                    }
                    else
                    {
                        //默认绑定数据模式
                        this.BindDataDetails<T>(itemList[itemIndex], itemIndex, rowIndex);
                    }
                    rowIndex--;
                }
                //this.RedrawGroupColor(startIndex, itemList.Count);

                //增加集合信息
                this.GroupCount++;

                #region 返回事件信息

                if (isFromAddItem)
                {
                    //如果是添加条目引发的加入新组，则出发新增条目事件
                    if (this.AddItemCompleted != null)
                    {
                        this.AddItemCompleted
                         (
                             itemList[0],
                             new CollapseDataGridViewEventArgs
                             {
                                 Result = true,
                                 RowIndex = startIndex,
                                 ErrorMessage = string.Empty
                             }
                         );
                    }
                }
                else
                {
                    //将添加的内容通知UI
                    if (this.AddGroupCompleted != null)
                    {
                        this.AddGroupCompleted
                            (
                                itemList,
                                new CollapseDataGridViewEventArgs
                                {
                                    Result = true,
                                    RowIndex = startIndex,
                                    ErrorMessage = string.Empty
                                }
                            );
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                #region 返回事件信息

                if (isFromAddItem)
                {
                    if (this.AddItemCompleted != null)
                    {
                        this.AddItemCompleted
                             (
                                 null,
                                 new CollapseDataGridViewEventArgs
                                 {
                                     Result = false,
                                     RowIndex = startIndex,
                                     ErrorMessage = ex.Message
                                 }
                             );
                    }
                }
                else
                {
                    if (this.AddGroupCompleted != null)
                    {
                        this.AddGroupCompleted
                             (
                                 null,
                                 new CollapseDataGridViewEventArgs
                                 {
                                     Result = false,
                                     RowIndex = startIndex,
                                     ErrorMessage = ex.Message
                                 }
                             );
                    }
                }

                #endregion
            }
        }

        /// <summary>
        /// 加载单个集合数据
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="itemList">单个集合（多条目）</param>
        private void InitOneGroup<T>(List<T> itemList)
        {
            this.m_bIsInit = true;
            this.GroupCount++;
            CollapseDataGridViewRow collapseRow = new CollapseDataGridViewRow();
            collapseRow.IsCollapse = true;
            collapseRow.GroupTag = itemList;//GroupTag作为集合信息宿主
            collapseRow.Tag = itemList[0];  //Tag缓存第一条条目信息

            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            cell.Value = "1";
            collapseRow.Cells.Add(cell);//不预先添加则无法折叠--相当于插入了空行

            for (int itemIndex = 1; itemIndex < itemList.Count; itemIndex++)
            {
                DataGridViewRow row = new DataGridViewRow();
                cell = new DataGridViewTextBoxCell();
                cell.Value = itemIndex + 1;
                row.Cells.Add(cell);//不预先添加则无法折叠
                row.Tag = itemList[itemIndex];
                collapseRow.Rows.Add(row);
            }
            this.Rows.Add(collapseRow);
            this.Expand(collapseRow.Index);//展开来填充数

            //填充数据
            int rowIndex = this.Rows.Count - 1;//行索引
            bool isMainItem = false;//是否是第一行

            for (int itemIndex = itemList.Count - 1; itemIndex >= 0; --itemIndex)
            {
                this.ItemCount++;
                if (itemIndex == 0)
                {
                    isMainItem = true;
                }

                //进行行数据绑定
                if (this.OnBindDataDetail != null)
                {
                    //使用用户自定义绑定数据模式
                    OnBindDataDetail(itemList[itemIndex], rowIndex, isMainItem);
                }
                else
                {
                    //默认绑定数据模式
                    this.BindDataDetails<T>(itemList[itemIndex], itemIndex, rowIndex);
                }
                rowIndex--;
            }
            this.RedrawGroupColor(this.Rows.Count - itemList.Count, itemList.Count);
            this.m_bIsInit = false;
            if (this.IsInitCollapsed)
                this.Collapse(collapseRow.Index);
        }

        /// <summary>
        /// 删除集合除首条外的所有子条目
        /// </summary>
        /// <param name="row">折叠行对象</param>
        /// <param name="flag"></param>
        private void RemoveAllSubRow(CollapseDataGridViewRow row, bool flag)
        {
            if (row.Rows.Count != 0)
            {
                if (!row.IsCollapse)
                {
                    for (int i = 0; i < row.Rows.Count; i++)
                    {
                        if (row.Rows[i] is CollapseDataGridViewRow)
                        {
                            RemoveAllSubRow((CollapseDataGridViewRow)row.Rows[i], true);
                        }
                        else
                        {
                            this.Rows.Remove(row.Rows[i]);
                        }
                    }
                }
                if (flag)
                {
                    row.IsCollapse = true;
                    this.Rows.Remove(row);
                }
            }
        }

        /// <summary>
        /// 删除指定集合
        /// </summary>
        /// <param name="startIndex">集合首行号</param>
        private void RemoveOneGroup(int startIndex)
        {
            try
            {
                //缓存Tag内容
                object tag = (this.Rows[startIndex] as CollapseDataGridViewRow).GroupTag;

                //(this.Rows[startIndex] as CollapseDataGridViewRow).Rows.Count只是集合所含的子条目
                //并没有包含集合首条目本身，所以要追加1
                this.ItemCount -= ((this.Rows[startIndex] as CollapseDataGridViewRow).Rows.Count + 1);

                //折叠行
                this.Collapse(startIndex);

                //移除折叠行
                this.Rows.Remove(this.Rows[startIndex]);

                //重绘UI
                this.RedrawGroupColor(startIndex);

                //设置DataGridView属性
                this.GroupCount--;

                //执行删除委托事件，先删除数据源，再重绘UI
                if (this.RemoveGroupCompleted != null)
                {
                    this.RemoveGroupCompleted
                        (
                            tag,
                            new CollapseDataGridViewEventArgs
                            {
                                Result = true,
                                RowIndex = startIndex,
                                ErrorMessage = String.Empty
                            }
                        );
                }
            }
            catch (Exception ex)
            {
                if (this.RemoveGroupCompleted != null)
                {
                    this.RemoveGroupCompleted
                        (
                            null,
                            new CollapseDataGridViewEventArgs
                            {
                                Result = false,
                                RowIndex = startIndex,
                                ErrorMessage = ex.Message
                            }
                        );
                }
            }
        }

        #endregion

        #region 其他

        /// <summary>
        /// 展开集合
        /// </summary>
        /// <param name="row">集合首行</param>
        private void ExpendGroup(CollapseDataGridViewRow row)
        {
            if ((row as CollapseDataGridViewRow).IsCollapse == true)
            {
                this.Expand(row.Index);
            }
        }

        /// <summary>
        /// 向上查找第一次出现的CollapseDataGridViewRow的行号
        /// </summary>
        /// <param name="startIndex">起始行号</param>
        /// <returns>-1: 未找到</returns>
        private int FindFirstAboveCollapseRow(int startIndex)
        {
            if (this.Rows[startIndex] is CollapseDataGridViewRow)
                return startIndex;
            for (int rowIndex = startIndex - 1; rowIndex >= 0; --rowIndex)
            {
                if (this.Rows[rowIndex] is CollapseDataGridViewRow)
                {
                    return this.Rows[rowIndex].Index;
                }
            }
            return -1;
        }

        /// <summary>
        /// 默认数据绑定模式
        /// <para>以CollapseDataGridView第一列DataPropertyName为分组标识进行分组</para>
        /// </summary>
        /// <typeparam name="T">类型名</typeparam>
        /// <param name="originalModel">原始数据模型</param>
        /// <param name="itemIndex">在集合中所处的位置号</param>
        /// <param name="rowIndex">行号</param>
        private void BindDataDetails<T>(T originalModel, int itemIndex, int rowIndex)
        {
            for (int cellIndex = 0; cellIndex < this.Columns.Count; ++cellIndex)
            {
                if (cellIndex == 0)
                {
                    //只有集合[0,0]显示集合分组标识
                    if (itemIndex != 0)
                    {
                        this.Rows[rowIndex].Cells[cellIndex].Value = "";
                        this.Rows[rowIndex].Cells[cellIndex].ReadOnly = true;//集合[i,0]列设为只读，其中i != 0
                    }
                    else
                    {
                        //由CollapseDataGridView的Columns的DataPropertyName反射出模型中某属性的值
                        if (originalModel.GetType().GetProperty(this.Columns[cellIndex].DataPropertyName) != null)
                        {
                            this.Rows[rowIndex].Cells[cellIndex].Value =
                                originalModel.GetType().
                                GetProperty(this.Columns[cellIndex].DataPropertyName).
                                GetValue(originalModel, null);
                        }
                        else
                        {
                            this.Rows[rowIndex].Cells[cellIndex].Value = null;
                        }
                    }
                }
                else
                {
                    //由CollapseDataGridView的Columns的DataPropertyName反射出模型中某属性的值
                    if (originalModel.GetType().GetProperty(this.Columns[cellIndex].DataPropertyName) != null)
                    {
                        this.Rows[rowIndex].Cells[cellIndex].Value =
                            originalModel.GetType().
                            GetProperty(this.Columns[cellIndex].DataPropertyName).
                            GetValue(originalModel, null);
                    }
                    else
                    {
                        this.Rows[rowIndex].Cells[cellIndex].Value = null;
                    }
                }
            }
        }

        #endregion

        #endregion
    }

    public class CollapseDataGridViewRow : DataGridViewRow
    {
        #region Private fields

        private CollapseDataGridViewRowCollection m_rowCollection = new CollapseDataGridViewRowCollection();
        private bool m_IsCollapse = false;
        private object m_oGroupTag = new object();

        #endregion

        #region Public Properties

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool IsCollapse
        {
            get { return m_IsCollapse; }
            set { m_IsCollapse = value; }
        }

        /// <summary>
        /// 折叠控件的集合
        /// </summary>
        public CollapseDataGridViewRowCollection Rows
        {
            get { return m_rowCollection; }
            set { m_rowCollection = value; }
        }

        /// <summary>
        /// 集合行的Tag，用于存储集合所有的信息
        /// </summary>
        public object GroupTag
        {
            get { return m_oGroupTag; }
            set { m_oGroupTag = value; }
        }

        #endregion
    }

    public class CollapseDataGridViewRowCollection : IEnumerable<DataGridViewRow>, ICollection<DataGridViewRow>
    {
        private List<DataGridViewRow> m_list = new List<DataGridViewRow>();

        public DataGridViewRow this[int index]
        {
            get
            {
                if (index >= m_list.Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return m_list[index];
            }
        }

        #region IEnumerable<DataGridViewRow> Member

        public IEnumerator<DataGridViewRow> GetEnumerator()
        {
            if (m_list.Count == 0)
            {
                throw new ArgumentOutOfRangeException("collection is null");
            }
            for (int i = 0; i < m_list.Count; i++)
            {
                yield return m_list[i];
            }
        }

        #endregion

        #region IEnumerable Member

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            if (m_list.Count == 0)
            {
                throw new ArgumentOutOfRangeException("collection is null");
            }
            for (int i = 0; i < m_list.Count; i++)
            {
                yield return m_list[i];
            }
        }

        #endregion

        #region ICollection<DataGridViewRow> Member

        public void Add(DataGridViewRow item)
        {
            m_list.Add(item);
        }

        public void Clear()
        {
            m_list.Clear();
        }

        public bool Contains(DataGridViewRow item)
        {
            return m_list.Contains(item);
        }

        public void CopyTo(DataGridViewRow[] array, int arrayIndex)
        {
            m_list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return m_list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(DataGridViewRow item)
        {
            return m_list.Remove(item);
        }

        #endregion
    }

    public class CollapseDataGridViewEventArgs : EventArgs
    {
        #region Private fields

        private bool m_bResult;
        private int m_nRowIndex;
        private string m_strErrorMessage;

        #endregion

        #region Public properties

        /// <summary>
        /// 事件处理结果
        /// </summary>
        public bool Result
        {
            get { return m_bResult; }
            set { m_bResult = value; }
        }


        /// <summary>
        /// 所在行号
        /// </summary>
        public int RowIndex
        {
            get { return m_nRowIndex; }
            set { m_nRowIndex = value; }
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorMessage
        {
            get { return m_strErrorMessage; }
            set { m_strErrorMessage = value; }
        }

        #endregion
    }
}
