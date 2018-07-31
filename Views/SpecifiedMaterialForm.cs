using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraTreeList.Nodes;
using SnCodeModel;
using SnCodeServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SnCodeCommon;

namespace SnCodeViews.PickedPlan
{
    public partial class SpecifiedMaterialForm : BaseEditForm
    {
        public string state = "";
        public List<T_PickedPlanDetails> ppDetailsList = new List<T_PickedPlanDetails>();

        public SpecifiedMaterialForm()
        {
            InitializeComponent();
             

            btnOk.ItemClick += btnOk_ItemClick;
            btnCancel.ItemClick+=btnCancel_ItemClick;

         }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           
            MaterialService svr = new MaterialService();

            string materialName = cboMaterialUser.Text.Trim().ToString();
            if (materialName.Equals(""))
            {
                Utils.ShowPrompt(MessageType.mtWarning, "领料员不能为空!\n");
                return;
            }
            string specifiedMaterialDate = ttSpecifiedMaterialDate.Text.Trim().ToString();
            if (specifiedMaterialDate.Equals(""))
            {
                Utils.ShowPrompt(MessageType.mtWarning, "领料日期不能为空!\n");
                return;
            }

            WaitDialogForm sdf = new WaitDialogForm("", "正在保存......");
        
            string materialCode = (cboMaterialUser.EditValue as CheckedListBoxItem).Value.ToString();

            List<T_PickedPlanDetails> ppDeatilsList = bsDetails.DataSource as List<T_PickedPlanDetails>;
            svr.AddMaterial(ppDeatilsList, materialCode, materialName, specifiedMaterialDate, Global.User);
           
            sdf.Close(); 
            if (svr.HasError)
            {
                Utils.ShowPrompt(MessageType.mtError, "发料计划保存失败：" + svr.Errors);
                return;
            }
         
            this.DialogResult=DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 界面打开后加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUserForm_Load(object sender, EventArgs e)
        {  
            
            UserService usv = new UserService();
            List<T_User> tuList = usv.getList(null);
            CheckedListBoxItem[] itemListQuery = new CheckedListBoxItem[tuList.Count];
            int i=0;
            foreach (var tu in tuList)
            {
                itemListQuery[i] = new CheckedListBoxItem(tu.UserCode, tu.UserName);
                i++;
            }

            this.cboMaterialUser.Properties.Items.AddRange(itemListQuery);

            ttSpecifiedMaterialDate.Text = Global.SqlNow.Date.ToString("yyyy-MM-dd");

            bsDetails.DataSource = ppDetailsList;
        }

       

    }
}
