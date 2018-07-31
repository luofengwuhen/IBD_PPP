using DevExpress.Spreadsheet;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using SnCodeModel;
using SnCodeServices;
using SnCodeViews.Comm;
using SnCodeViews.PickedPlan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SnCodeCommon;


namespace SnCodeViews
{
    public partial class PickedPlanForm : Form
    {
      
        //List<T_PickedPlan> opList = null;
        //PickedPlanService svr = new PickedPlanService();
        public PickedPlanForm()
        {
            InitializeComponent();

            pageControl1.OnPageChanged += new EventHandler(pagerControl1_OnPageChanged);
        }
         

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        { 
             LoadDataGrid(); 
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadDataGrid()
        {
            WaitDialogForm sdf = new WaitDialogForm("", "正在查询......"); 
          
            //ConditionItem[] conds = GetConditions();
            //if (conds != null)
            //{
            //    opList = svr.getList(conds);
            //    if (svr.HasError)
            //    {
            //        Utils.ShowPrompt(MessageType.mtWarning, "载入失败\n" + svr.Errors); 
            //    }
            //    else
            //    { 
            //        List<T_PickedPlan> list = opList.Skip((pageControl1.PageIndex - 1) * pageControl1.PageSize).Take(pageControl1.PageSize).ToList();
            //        pageControl1.DrawControl(opList.Count()); 
            //        if(list.Count()==0)
            //        {
            //            bsData.DataSource = null;
            //            bsDetails.DataSource = null;
            //        }
            //        else
            //        {
            //            bsData.DataSource = list;

            //            int[] ids=new int[list.Count()] ;
            //            int i=0;
            //            foreach (var pPlan in list)
            //            {
            //                ids[i] = pPlan.ID;
            //                i++;
            //            } 
            //            List<T_PickedPlanDetails> ppDetailsList = svr.getPickedPlanDetails(ids); 
            //            if (!svr.HasError)
            //            { 
            //                bsDetails.DataSource = ppDetailsList;
            //            }  
            //        }
            //    }
            //}
            sdf.Close(); 
         
        }

        /// <summary>
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void pagerControl1_OnPageChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        private void UserForm_Load(object sender, EventArgs e)
        { 
            //CheckedListBoxItem[] itemListQuery = OutPlanStateExtension.GetDropDownList(); 
            //cboPickedPlanState.Properties.Items.AddRange(itemListQuery); 

            //Common com = new Common();
            //bbiImport.Visibility = com.hasRights("200202") ? BarItemVisibility.Always : BarItemVisibility.Never;
            //btnDel.Visibility = com.hasRights("200203") ? BarItemVisibility.Always : BarItemVisibility.Never;

            //if (bbiImport.Visibility.Equals(BarItemVisibility.Never) && btnDel.Visibility.Equals(BarItemVisibility.Never))
            //{
            //    bar2.Visible = false;
            //}

            //ttPickedPlanOn1.Text = Global.SqlNow.Date.ToString("yyyy-MM-dd");
            //ttPickedPlanOn2.Text = Global.SqlNow.Date.ToString("yyyy-MM-dd");

            //repositoryItemCheckEdit1.CheckedChanged += new EventHandler(repositoryItemCheckEdit1_CheckedChanged);
            //repositoryItemCheckEdit2.CheckedChanged += new EventHandler(repositoryItemCheckEdit2_CheckedChanged);
        }

        /// <summary>
        /// 查询条件
        /// </summary>
        /// <returns></returns>
        private ConditionItem[] GetConditions()
        {
            List<ConditionItem> conds = new List<ConditionItem>();

           // conds.Add(new ConditionItem
           // {
           //     PropertyName = "PickedPlanCode",
           //     FindType = ConditionType.ctLike,
           //     Values = new object[] { txtPickedPlanCode.Text }
           // });

           // conds.Add(new ConditionItem
           // {
           //     PropertyName = "PickedPlanOn",
           //     FindType = ConditionType.ctBetween,
           //     Values = new object[] { DateTime.Parse(ttPickedPlanOn1.Text), DateTime.Parse(ttPickedPlanOn2.Text) }
           // });

           //CheckedListBoxItem clbi= cboPickedPlanState.EditValue as CheckedListBoxItem;
           //if (clbi != null && !clbi.Value.Equals(""))
           // {
           //     conds.Add(new ConditionItem
           //     {
           //         PropertyName = "PickedPlanState",
           //         FindType = ConditionType.ctEqual,
           //         Values = new object[] { int.Parse(clbi.Value.ToString()) }
           //     });
           // } 

            return conds.ToArray();
        }

        /// <summary>
        /// 行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }

        private void gridView1_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {

            BindingSource bindingSource = bsData.DataSource as BindingSource;
            if (bindingSource==null || bindingSource.Count == 0)
            {
                string str = "没有查询到你所想要的数据!";
                Font f = new Font("宋体", 10, FontStyle.Bold);
                Rectangle r = new Rectangle(e.Bounds.Left + 5, e.Bounds.Top + 5, e.Bounds.Width - 5, e.Bounds.Height - 5);
                e.Graphics.DrawString(str, f, Brushes.Black, r);
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //EditPickedPlanForm form = new EditPickedPlanForm();
            //form.Text = "新增物料信息";
            //form.state = "Add";
            //if(form.ShowDialog()==DialogResult.OK)
            //{
            //    LoadDataGrid();
            //}
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //T_PickedPlan tu = bsData.Current as T_PickedPlan;
            //EditPickedPlanForm form = new EditPickedPlanForm();
            //form.Text = "编辑物料信息";
            //form.state = "Edit";
            //form.editTu =tu ; 
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    LoadDataGrid();
            //}
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // List<T_PickedPlan> tuList = bsData.DataSource as List<T_PickedPlan>;
           // tuList = tuList.Where(o => o.UIChecked == true).ToList();
           // if (tuList == null || tuList.Count<1)
           // {
           //     Utils.ShowPrompt(MessageType.mtWarning, "请至少选择一条记录!");
           //     return;
           // }
           //DialogResult dr= Utils.ShowPrompt(MessageType.mtInformation, "即将删除该领料计划,删除之后将不可恢复!", null, MessageBoxButtons.OKCancel);
           //if (dr==DialogResult.Cancel)
           //{
           //    return;
           //}

           //svr.DelPickedPlan(tuList, Global.User);
           //if (svr.HasError)
           //{
           //    Utils.ShowPrompt(MessageType.mtWarning, "删除失败\n" + svr.Errors);
           //}
           //else
           //{
           //    Utils.ShowPrompt(MessageType.mtInformation, "删除成功\n");
           //    LoadDataGrid();
           //}
        }


        /// <summary>
        /// 列转义
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        { 
            //if (e.Column.FieldName.Equals("PickedPlanState"))
            //{
            //    e.DisplayText = OutPlanStateExtension.GetLabel(int.Parse(e.Value.ToString())); 
            //} 
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            //try
            //{
            //    ExcelForm excelForm = new ExcelForm();
            //    var iList = bsData.List;
            //    if (iList == null || iList.Count == 0) return;

            //    //表头
            //    excelForm.spreadsheetControl1.ActiveWorksheet.Cells[0, 0].Value = "料号";
            //    excelForm.spreadsheetControl1.ActiveWorksheet.Cells[0, 1].Value = "品名";
            //    excelForm.spreadsheetControl1.ActiveWorksheet.Cells[0, 2].Value = "规格";
            //    excelForm.spreadsheetControl1.ActiveWorksheet.Cells[0, 3].Value = "单位";
            //    excelForm.spreadsheetControl1.ActiveWorksheet.Cells[0, 4].Value = "状态";
            //    excelForm.spreadsheetControl1.BeginUpdate();
            //    for (int i = 0; i < iList.Count; i++)
            //    {
            //        T_PickedPlan PickedPlan = iList[i] as T_PickedPlan;
            //        //excelForm.spreadsheetControl1.ActiveWorksheet.Cells[i + 1, 0].Value = PickedPlan.PickedPlanCode;
            //        //excelForm.spreadsheetControl1.ActiveWorksheet.Cells[i + 1, 1].Value = PickedPlan.PickedPlanName;
            //        //excelForm.spreadsheetControl1.ActiveWorksheet.Cells[i + 1, 2].Value = PickedPlan.Spec;
            //        //excelForm.spreadsheetControl1.ActiveWorksheet.Cells[i + 1, 3].Value = PickedPlan.Unit;
            //        excelForm.spreadsheetControl1.ActiveWorksheet.Cells[i + 1, 4].Value = PickedPlan.PickedPlanState == 1 ? "有效" : "失效";
            //    }
            //    excelForm.spreadsheetControl1.EndUpdate();

            //    excelForm.btnPrintView.Visible = false;
            //    excelForm.btnExcelImport.Visible = false;
            //    excelForm.btnAddData.Visible = false;

            //    excelForm.ShowDialog();
            //}
            //catch(Exception ex)
            //{

            //}


        }

        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "表格文件 (*.xlsx)|*.xlsx";
            //openFileDialog.RestoreDirectory = true;
            //openFileDialog.FilterIndex = 1;
            //DataTable dataTable = new DataTable(); 
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{ 
            //    dataTable = Utils.ImportNPOI(openFileDialog.FileName,true); 
            //}
            //else
            //{
            //    return;
            //}

            ////保存记录 
            //svr.saveImport(dataTable, Global.User);//只取sheet1,来导入 

            ////显示结果
            //if (svr.HasError)
            //{
            //    Utils.ShowPrompt(MessageType.mtError, svr.Errors.ToString());
            //}
            //else
            //{
            //    Utils.ShowPrompt(MessageType.mtInformation, "导入成功");
            //    LoadDataGrid();
            //}   
        }
         
         
        
         void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            //bool isCheck = false;
            //CheckState check = (sender as DevExpress.XtraEditors.CheckEdit).CheckState; 
            //if (check == CheckState.Checked)
            //{
            //    isCheck = true;
            //}
            //T_PickedPlan pPlan = bsData.Current as T_PickedPlan;
            //List<T_PickedPlanDetails> ppDetailsList = bsDetails.DataSource as List<T_PickedPlanDetails>;
            //List<T_PickedPlan> pPlanList = bsData.DataSource as List<T_PickedPlan>;
            //T_PickedPlan newPlan = pPlanList.Where(o => o.ID == pPlan.ID).FirstOrDefault();
            // if(newPlan!=null)
            // {
            //     newPlan.UIChecked = isCheck;
            //     bsData.ResetBindings(true);
            // } 

            //ppDetailsList = ppDetailsList.Where(o => o.PickedPlanID == pPlan.ID).ToList();
            //foreach (var ppDetails in ppDetailsList)
            //{
            //    ppDetails.UIChecked = isCheck;
            //}
            //bsDetails.ResetBindings(true);
        }

         void repositoryItemCheckEdit2_CheckedChanged(object sender, EventArgs e)
         {
             //bool isCheck = false;

             //CheckState check = (sender as DevExpress.XtraEditors.CheckEdit).CheckState;
             ////chebox之后就更新数据集
             //T_PickedPlanDetails ppDetails = bsDetails.Current as T_PickedPlanDetails;
             //List<T_PickedPlanDetails> ppDetailsList = bsDetails.DataSource as List<T_PickedPlanDetails>;
             //T_PickedPlanDetails oldDetail = ppDetailsList.Where(o => o.ID == ppDetails.ID).FirstOrDefault();
             //if (check == CheckState.Checked)
             //{
             //    isCheck = true;
             //    //更新主表的数据集
             //    List<T_PickedPlan> pPlanList = bsData.DataSource as List<T_PickedPlan>;
             //    T_PickedPlan pPlan = pPlanList.Where(o => o.ID == ppDetails.PickedPlanID).FirstOrDefault();

             //    if (pPlan.UIChecked == false)
             //    {
             //        pPlan.UIChecked = isCheck;
             //        bsData.ResetBindings(true);
             //    }
             //} 
             //oldDetail.UIChecked = isCheck;
             //bsDetails.ResetBindings(true);

        
         }
 

         private void gridView2_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
         {
         }
        /// <summary>
        /// 发料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         private void btnMaterial_ItemClick(object sender, ItemClickEventArgs e)
         { 
             //SpecifiedMaterialForm form = new SpecifiedMaterialForm();

             ////判断是否有记录,并且剩余数量是否大于0,状态是否为新建或者已发料
             //List<T_PickedPlan> pPlanList = bsData.DataSource as List<T_PickedPlan>;
             //pPlanList = pPlanList.Where(o => o.UIChecked == true && o.PickedPlanState < (int)PickedPlanState.opsLoading).ToList();
             //if (pPlanList.Count < 1) return;
             

             //List<T_PickedPlanDetails> detailsList = bsDetails.DataSource as List<T_PickedPlanDetails>;
             //if (detailsList == null) return;
             //detailsList=detailsList.Where (o=>o.UIChecked==true && o.RemainNum>0).ToList();
             //if (detailsList.Count < 1) return;


             //foreach (var details in detailsList)
             //{
             //    details.RealNum =(decimal) details.RemainNum;
             //}
             //form.ppDetailsList = detailsList;
             //if (form.ShowDialog()==DialogResult.OK)
             //{
             //    LoadDataGrid();
             //}
         }
       
    }
}
