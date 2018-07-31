using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using DevExpress.XtraSplashScreen;
using System.Threading;


namespace Views
{
    public partial class MainForm : RibbonForm
    {

        Common com = new Common();
        public MainForm()
        {
            SplashScreenManager.ShowForm(typeof(SplashScreen1));
            InitializeComponent();
            InitSkinGallery();
            Thread.Sleep(2000);
            SplashScreenManager.CloseForm(); 

        }  
    
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(rgbiSkins, true);
        }

        private void spreadsheetCommandBarButtonItem108_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void siInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
   
        }

        #region 子窗体
        private Form frmChild = null;
        private void openWindow()
        {  
            XtraTabPage page = new XtraTabPage(); 

            if (frmChild != null)
            {
                frmChild.Visible = true;
                frmChild.Dock = DockStyle.Fill;
                frmChild.FormBorderStyle = FormBorderStyle.None;
                frmChild.TopLevel = false; 
            }

            page.Controls.Add(frmChild);
            page.Text = frmChild.Text;

            foreach (XtraTabPage xtp in xtraTabControl1.TabPages)
            {
                if (xtp.Text.Equals(frmChild.Text))
                {
                    xtraTabControl1.SelectedTabPage=xtp;
                    return;
                }
            }

            xtraTabControl1.TabPages.Add(page);
            xtraTabControl1.SelectedTabPage = page;

            //设置关闭事件 

            xtraTabControl1.CloseButtonClick += new EventHandler(XtraTabControl1CloseButtonClick);
        }

        //在程序关闭之后 要释放窗体等资源 
        void XtraTabControl1CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs a = (ClosePageButtonEventArgs)e;
            string tabpagename = a.Page.Text;
            foreach (Control xtp in xtraTabControl1.TabPages)
            {
                if (xtp.Text == tabpagename)
                {
                    xtp.Dispose();
                    return;
                }
            }
        }
        #endregion

        /// <summary>
        /// 窗体加载后的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            //siStatus.Caption = "  " + Global.User.UserCode + "[" + Global.User.UserName + "]" + "   |"
            //    + "    日期 : " + Global.SqlNow.ToShortDateString() + "    |"
            //    + "     版本：V1.0.171208.1";

            ////判断是否具有权限
            //frpSystem.Visible = com.hasRights("10") || com.hasRights("20");
            //rpgRight.Visible = com.hasRights("10");
            //rpgBussniss.Visible = com.hasRights("20"); 

            //bbiUser.Visibility = com.hasRights("1001") ? BarItemVisibility.Always : BarItemVisibility.Never;
            //bbiRole.Visibility = com.hasRights("1002") ? BarItemVisibility.Always : BarItemVisibility.Never; 

            //bbiItem.Visibility = com.hasRights("2001") ? BarItemVisibility.Always : BarItemVisibility.Never;
            //bbiPickedPlan.Visibility = com.hasRights("2002") ? BarItemVisibility.Always : BarItemVisibility.Never;
            //bbiMaterial.Visibility = com.hasRights("2003") ? BarItemVisibility.Always : BarItemVisibility.Never; 

        }
         

        #region 打开子窗体
        /// <summary>
        /// 用户管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmChild = new UserForm();
            //openWindow();
        }

        /// <summary>
        /// 角色管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmChild = new RoleForm();
            //openWindow();
        }

        /// <summary>
        /// 物料管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmChild = new ItemForm();
            //openWindow();
        }
        /// <summary>
        /// 领料计划管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiPickedPlan_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmChild = new PickedPlanForm();
            //openWindow();
        }

        /// <summary>
        /// 领料管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            //frmChild = new MaterialForm();
            //openWindow();

        }

        #endregion

 





    }
}