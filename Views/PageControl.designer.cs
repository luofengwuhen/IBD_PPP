namespace UserControls
{
    partial class PageControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageControl));
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountPages = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstPage = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousPage = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionPage = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextPage = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastPage = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tslCounts = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstPageCounts = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackColor = System.Drawing.Color.White;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountPages;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstPage,
            this.bindingNavigatorMovePreviousPage,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionPage,
            this.bindingNavigatorCountPages,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextPage,
            this.bindingNavigatorMoveLastPage,
            this.bindingNavigatorSeparator2,
            this.toolStripLabel1,
            this.tslCounts,
            this.toolStripLabel2,
            this.tstPageCounts,
            this.toolStripLabel3});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 1);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstPage;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastPage;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextPage;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousPage;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionPage;
            this.bindingNavigator1.Size = new System.Drawing.Size(988, 27);
            this.bindingNavigator1.TabIndex = 3;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountPages
            // 
            this.bindingNavigatorCountPages.Name = "bindingNavigatorCountPages";
            this.bindingNavigatorCountPages.Size = new System.Drawing.Size(38, 24);
            this.bindingNavigatorCountPages.Text = "/ {0}";
            this.bindingNavigatorCountPages.ToolTipText = "总页数";
            // 
            // bindingNavigatorMoveFirstPage
            // 
            this.bindingNavigatorMoveFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstPage.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstPage.Image")));
            this.bindingNavigatorMoveFirstPage.Name = "bindingNavigatorMoveFirstPage";
            this.bindingNavigatorMoveFirstPage.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstPage.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstPage.Text = "移到第一页";
            this.bindingNavigatorMoveFirstPage.Click += new System.EventHandler(this.bindingNavigatorMoveFirstPage_Click);
            // 
            // bindingNavigatorMovePreviousPage
            // 
            this.bindingNavigatorMovePreviousPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousPage.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousPage.Image")));
            this.bindingNavigatorMovePreviousPage.Name = "bindingNavigatorMovePreviousPage";
            this.bindingNavigatorMovePreviousPage.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousPage.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousPage.Text = "移到上一条记录";
            this.bindingNavigatorMovePreviousPage.Click += new System.EventHandler(this.bindingNavigatorMovePreviousPage_Click);
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionPage
            // 
            this.bindingNavigatorPositionPage.AccessibleName = "位置";
            this.bindingNavigatorPositionPage.AutoSize = false;
            this.bindingNavigatorPositionPage.Name = "bindingNavigatorPositionPage";
            this.bindingNavigatorPositionPage.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionPage.Text = "0";
            this.bindingNavigatorPositionPage.ToolTipText = "当前页";
            this.bindingNavigatorPositionPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.bindingNavigatorPositionPage_KeyDown);
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextPage
            // 
            this.bindingNavigatorMoveNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextPage.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextPage.Image")));
            this.bindingNavigatorMoveNextPage.Name = "bindingNavigatorMoveNextPage";
            this.bindingNavigatorMoveNextPage.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextPage.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextPage.Text = "移到下一页";
            this.bindingNavigatorMoveNextPage.Click += new System.EventHandler(this.bindingNavigatorMoveNextPage_Click);
            // 
            // bindingNavigatorMoveLastPage
            // 
            this.bindingNavigatorMoveLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastPage.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastPage.Image")));
            this.bindingNavigatorMoveLastPage.Name = "bindingNavigatorMoveLastPage";
            this.bindingNavigatorMoveLastPage.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastPage.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastPage.Text = "移到最后一页";
            this.bindingNavigatorMoveLastPage.Click += new System.EventHandler(this.bindingNavigatorMoveLastPage_Click);
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 24);
            this.toolStripLabel1.Text = "共 ";
            // 
            // tslCounts
            // 
            this.tslCounts.Name = "tslCounts";
            this.tslCounts.Size = new System.Drawing.Size(18, 24);
            this.tslCounts.Text = "0";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(96, 24);
            this.toolStripLabel2.Text = " 条记录,每页 ";
            // 
            // tstPageCounts
            // 
            this.tstPageCounts.Name = "tstPageCounts";
            this.tstPageCounts.Size = new System.Drawing.Size(50, 27);
            this.tstPageCounts.Text = "0";
            this.tstPageCounts.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstPageCounts_KeyDown);
            this.tstPageCounts.TextChanged += new System.EventHandler(this.tstPageCounts_TextChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(28, 24);
            this.toolStripLabel3.Text = " 条";
            // 
            // PageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bindingNavigator1);
            this.Name = "PageControl";
            this.Size = new System.Drawing.Size(988, 28);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountPages;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstPage;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousPage;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionPage;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextPage;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastPage;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel tslCounts;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        public System.Windows.Forms.ToolStripTextBox tstPageCounts;
    }
}
