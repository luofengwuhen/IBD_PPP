using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Spreadsheet;
using System.IO; 
using Microsoft.Office.Interop.Excel;

namespace SnCodeViews.Comm
{
    public partial class ExcelForm : DevExpress.XtraEditors.XtraForm
    {
        public ExcelForm()
        {
            InitializeComponent(); 
         
        }

        private void btnExprotExcel_Click(object sender, EventArgs e)
        {
            this.spreadsheetControl1.SaveDocument();
        }

        private void btnPrintView_Click(object sender, EventArgs e)
        {
            this.spreadsheetControl1.ShowPrintPreview();
        }

        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            string filePath = OpenExcel();
            if (!string.IsNullOrEmpty(filePath))
            {
                IWorkbook workbook = spreadsheetControl1.Document;
                workbook.LoadDocument(filePath);
            }
        }

        private string OpenExcel()
        {

            //申明保存对话框   
            OpenFileDialog dlg = new OpenFileDialog();
            //默然文件后缀   
            dlg.DefaultExt = "xlsx";
            //文件后缀列表   
            dlg.Filter = "Excel文件(*.xlsx)|*.XLSX|*.xls|*.XLS";
            //默然路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return "";
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == " ")
            { return ""; }

            return fileNameString;
        }


        private string SaveExcel()
        {
            //申明保存对话框   
            SaveFileDialog dlg = new SaveFileDialog();
            //默然文件后缀   
            dlg.DefaultExt = "xlsx";
            //文件后缀列表   
            dlg.Filter = "Excel文件(*.xlsx)|*.XLSX|*.xls|*.XLS";
            //默然路径是系统当前路径   
            dlg.InitialDirectory = Directory.GetCurrentDirectory();
            //打开保存对话框   
            if (dlg.ShowDialog() == DialogResult.Cancel) return "";
            //返回文件路径   
            string fileNameString = dlg.FileName;
            //验证strFileName是否为空或值无效   
            if (fileNameString.Trim() == " ")
            { return ""; }

            return fileNameString;
        }

        public void btnAddData_Click(object sender, EventArgs e)
        {
            //Workbook workbook = new Workbook();
            //RowCollection rows = workbook.Worksheets[0].Rows;  

            //Worksheet worksheet = spreadsheetControl1.ActiveWorksheet;
            //int rowCount = worksheet.Cells.CurrentRegion.RowCount;  
            ////当前数据列数  
            ////int columnCount = worksheet.Cells.CurrentRegion.ColumnCount;
            //for (int i = 0; i < rowCount; i++)
            //{
            //    T_Item item = new T_Item();
            //    item.ItemCode = worksheet.Cells[i, 0].Value != null ? worksheet.Cells[i, 0].Value.ToString() : "";
            //    item.ItemName = worksheet.Cells[i, 1].Value != null ? worksheet.Cells[i, 1].Value.ToString() : "";
            //    if (!item.ItemCode.Equals("") && !item.ItemName.Equals(""))
            //    {
            //        item.Spec = worksheet.Cells[i, 2].Value.ToString();
            //        item.Unit = worksheet.Cells[i, 3].Value.ToString();
            //        item.ItemState = 1;

            //        //iList.Add(item);
            //        //svr.AddItem(item, Global.User);
            //    }
            //}   
        }
    }
}