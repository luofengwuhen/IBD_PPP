namespace SnCodeViews.Comm
{
    partial class ExcelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAddData = new DevExpress.XtraEditors.SimpleButton();
            this.btnExcelImport = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrintView = new DevExpress.XtraEditors.SimpleButton();
            this.btnExprotExcel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // spreadsheetControl1
            // 
            this.spreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl1.Location = new System.Drawing.Point(0, 0);
            this.spreadsheetControl1.Name = "spreadsheetControl1";
            this.spreadsheetControl1.Options.Behavior.Column.AutoFit = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled;
            this.spreadsheetControl1.Options.Behavior.Row.AutoFit = DevExpress.XtraSpreadsheet.DocumentCapability.Enabled;
            this.spreadsheetControl1.Size = new System.Drawing.Size(1070, 669);
            this.spreadsheetControl1.TabIndex = 0;
            this.spreadsheetControl1.Text = "spreadsheetControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAddData);
            this.panelControl1.Controls.Add(this.btnExcelImport);
            this.panelControl1.Controls.Add(this.btnPrintView);
            this.panelControl1.Controls.Add(this.btnExprotExcel);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 669);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelControl1.Size = new System.Drawing.Size(1070, 50);
            this.panelControl1.TabIndex = 1;
            // 
            // btnAddData
            // 
            this.btnAddData.Location = new System.Drawing.Point(137, 15);
            this.btnAddData.Name = "btnAddData";
            this.btnAddData.Size = new System.Drawing.Size(100, 25);
            this.btnAddData.TabIndex = 3;
            this.btnAddData.Text = "保存数据";
            this.btnAddData.Click += new System.EventHandler(this.btnAddData_Click);
            // 
            // btnExcelImport
            // 
            this.btnExcelImport.Location = new System.Drawing.Point(12, 15);
            this.btnExcelImport.Name = "btnExcelImport";
            this.btnExcelImport.Size = new System.Drawing.Size(100, 25);
            this.btnExcelImport.TabIndex = 2;
            this.btnExcelImport.Text = "从Excel导入";
            this.btnExcelImport.Click += new System.EventHandler(this.btnExcelImport_Click);
            // 
            // btnPrintView
            // 
            this.btnPrintView.Location = new System.Drawing.Point(958, 15);
            this.btnPrintView.Name = "btnPrintView";
            this.btnPrintView.Size = new System.Drawing.Size(100, 25);
            this.btnPrintView.TabIndex = 1;
            this.btnPrintView.Text = "打印预览";
            this.btnPrintView.Click += new System.EventHandler(this.btnPrintView_Click);
            // 
            // btnExprotExcel
            // 
            this.btnExprotExcel.Location = new System.Drawing.Point(832, 15);
            this.btnExprotExcel.Name = "btnExprotExcel";
            this.btnExprotExcel.Size = new System.Drawing.Size(100, 25);
            this.btnExprotExcel.TabIndex = 0;
            this.btnExprotExcel.Text = "导出到Excel";
            this.btnExprotExcel.Click += new System.EventHandler(this.btnExprotExcel_Click);
            // 
            // ExcelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 719);
            this.Controls.Add(this.spreadsheetControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ExcelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "预览";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
        public DevExpress.XtraEditors.SimpleButton btnPrintView;
        public DevExpress.XtraEditors.SimpleButton btnExprotExcel;
        public DevExpress.XtraEditors.SimpleButton btnExcelImport;
        public DevExpress.XtraEditors.SimpleButton btnAddData;
    }
}