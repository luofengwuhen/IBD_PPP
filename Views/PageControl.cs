using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace UserControls
{
    public partial class PageControl : UserControl
    {
 

        public PageControl()
        {
            InitializeComponent();
        }

        #region 分页字段和属性

        private int pageIndex = 1;
        /// <summary>
        /// 当前页面
        /// </summary>
        public virtual int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        private int pageSize = 20;
        /// <summary>
        /// 每页记录数
        /// </summary>
        public virtual int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }

        private int recordCount = 0;
        /// <summary>
        /// 总记录数
        /// </summary>
        public virtual int RecordCount
        {
            get { return recordCount; }
            set { recordCount = value; }
        }

        private int pageCount = 0;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (pageSize != 0)
                {
                    pageCount = GetPageCount();
                }
                return pageCount;
            }
        }  
        #endregion


        #region 页码变化触发事件

        public event EventHandler OnPageChanged;

        #endregion

        #region 分页及相关事件功能实现

        private void SetFormCtrEnabled(bool bl)
        {
            bindingNavigatorPositionPage.Enabled = bl;
            bindingNavigatorMoveFirstPage.Enabled = bl;
            bindingNavigatorMovePreviousPage.Enabled = bl;
            bindingNavigatorMoveNextPage.Enabled = bl;
            bindingNavigatorMoveLastPage.Enabled = bl; 
        }

        /// <summary>
        /// 计算总页数
        /// </summary>
        /// <returns></returns>
        private int GetPageCount()
        {
            if (PageSize == 0)
            {
                return 0;
            }
            int pageCount = RecordCount / PageSize;
            if (RecordCount % PageSize == 0)
            {
                pageCount = RecordCount / PageSize;
            }
            else
            {
                pageCount = RecordCount / PageSize + 1;
            }
            return pageCount;
        }
        /// <summary>
        /// 外部调用
        /// </summary>
        public void DrawControl(int count)
        {
            recordCount = count;
            DrawControl(false);
        }
        /// <summary>
        /// 页面控件呈现
        /// </summary>
        private void DrawControl(bool callEvent)
        {
            bindingNavigatorPositionPage.Text = PageIndex.ToString();
            bindingNavigatorCountPages.Text = PageCount.ToString();
            tslCounts.Text = RecordCount.ToString();
            tstPageCounts.Text = PageSize.ToString();

            if (callEvent && OnPageChanged != null)
            {
                OnPageChanged(this, null);//当前分页数字改变时，触发委托事件
            }
            if (PageCount == 0)
            {
                SetFormCtrEnabled(false);
            }
            else
            {
                SetFormCtrEnabled(true);
            }
           
            if (PageCount == 1)//有且仅有一页
            {
                bindingNavigatorMoveFirstPage.Enabled = false;
                bindingNavigatorMovePreviousPage.Enabled = false;
                bindingNavigatorMoveNextPage.Enabled = false;
                bindingNavigatorMoveLastPage.Enabled = false; 
            }
            else if (PageIndex == 1)//第一页
            {
                bindingNavigatorMoveFirstPage.Enabled = false;
                bindingNavigatorMovePreviousPage.Enabled = false;
            }
            else if (PageIndex == PageCount && PageCount != 0)//最后一页
            {
                bindingNavigatorMoveNextPage.Enabled = false;
                bindingNavigatorMoveLastPage.Enabled = false;
            }
            
        }

        #endregion

        #region 相关控件事件
        /// <summary>
        /// 移动到第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveFirstPage_Click(object sender, EventArgs e)
        {
            PageIndex = 1;
            DrawControl(true);
        }

        /// <summary>
        /// 移动到上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMovePreviousPage_Click(object sender, EventArgs e)
        {
            PageIndex = Math.Max(1, PageIndex - 1);
            DrawControl(true);
        }

        /// <summary>
        /// 跳转到某一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorPositionPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int num = 0;
                if (int.TryParse(bindingNavigatorPositionPage.Text.Trim(), out num) && num > 0)
                {
                    if (pageCount<num)
                    {
                        num = pageCount;
                    }
                    PageIndex = num;
                    DrawControl(true);
                }
                else
                {
                    bindingNavigatorPositionPage.Text = pageIndex.ToString();
                }
            }
        }

        /// <summary>
        /// 移动到下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveNextPage_Click(object sender, EventArgs e)
        {

            PageIndex = Math.Min(PageCount, PageIndex + 1);
            DrawControl(true);
        }

        /// <summary>
        /// 移动到最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorMoveLastPage_Click(object sender, EventArgs e)
        {
            PageIndex = PageCount;
            DrawControl(true);
        }

        /// <summary>
        /// 每页显示记录数 回车刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstPageCounts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bindingNavigatorMovePreviousPage_Click(null, null);
            }
        }

        /// <summary>
        /// 变更值之后记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tstPageCounts_TextChanged(object sender, EventArgs e)
        {
            int num = 0;
            //如输入的字符不规范,则返回原先的记录数,不做刷新
            if (!int.TryParse(tstPageCounts.Text.Trim(), out num) || num <= 0)
            {
                tstPageCounts.Text = pageSize.ToString();
            }
            else
            {
                //做刷新,并返回到第一页
                pageSize = num; 
            }
            pageIndex = 1;
        }


        #endregion


   
    }
}
