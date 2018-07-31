namespace SnCodeViews.PickedPlan
{
    partial class SpecifiedMaterialForm
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.Views.Grid.GridView gridView2;
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl3 = new DevExpress.XtraGrid.GridControl();
            this.bsDetails = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.ttSpecifiedMaterialDate = new DevExpress.XtraEditors.DateEdit();
            this.cboMaterialUser = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ttSpecifiedMaterialDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttSpecifiedMaterialDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaterialUser.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            gridView2.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(231)))), ((int)(((byte)(255)))));
            gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            gridView2.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(251)))), ((int)(((byte)(243)))));
            gridView2.Appearance.OddRow.Options.UseBackColor = true;
            gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn11,
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn12,
            this.gridColumn13});
            gridView2.CustomizationFormBounds = new System.Drawing.Rectangle(799, 378, 210, 210);
            gridView2.FixedLineWidth = 1;
            gridView2.GridControl = this.gridControl3;
            gridView2.IndicatorWidth = 40;
            gridView2.Name = "gridView2";
            gridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
            gridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            gridView2.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.False;
            gridView2.OptionsCustomization.AllowColumnMoving = false;
            gridView2.OptionsCustomization.AllowColumnResizing = false;
            gridView2.OptionsCustomization.AllowFilter = false;
            gridView2.OptionsCustomization.AllowSort = false;
            gridView2.OptionsMenu.EnableColumnMenu = false;
            gridView2.OptionsView.EnableAppearanceEvenRow = true;
            gridView2.OptionsView.EnableAppearanceOddRow = true;
            gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "领料计划号";
            this.gridColumn15.FieldName = "PickedPlanCode";
            this.gridColumn15.MaxWidth = 100;
            this.gridColumn15.MinWidth = 100;
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.AllowEdit = false;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            this.gridColumn15.Width = 100;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "行号";
            this.gridColumn9.FieldName = "LinesNo";
            this.gridColumn9.MaxWidth = 50;
            this.gridColumn9.MinWidth = 50;
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 50;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "生产单号";
            this.gridColumn10.FieldName = "MoDocNo";
            this.gridColumn10.MaxWidth = 150;
            this.gridColumn10.MinWidth = 150;
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.OptionsColumn.AllowEdit = false;
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 2;
            this.gridColumn10.Width = 150;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "料号";
            this.gridColumn4.FieldName = "ItemCode";
            this.gridColumn4.MaxWidth = 120;
            this.gridColumn4.MinWidth = 120;
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 120;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "品名";
            this.gridColumn5.FieldName = "ItemName";
            this.gridColumn5.MaxWidth = 200;
            this.gridColumn5.MinWidth = 200;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            this.gridColumn5.Width = 200;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "规格";
            this.gridColumn11.FieldName = "Spec";
            this.gridColumn11.MaxWidth = 150;
            this.gridColumn11.MinWidth = 150;
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 5;
            this.gridColumn11.Width = 150;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "领料数量";
            this.gridColumn1.FieldName = "RemainNum";
            this.gridColumn1.MaxWidth = 80;
            this.gridColumn1.MinWidth = 80;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.BackColor = System.Drawing.Color.LightSalmon;
            this.gridColumn2.AppearanceCell.Options.UseBackColor = true;
            this.gridColumn2.Caption = "实际数量";
            this.gridColumn2.ColumnEdit = this.repositoryItemTextEdit1;
            this.gridColumn2.FieldName = "RealNum";
            this.gridColumn2.MaxWidth = 80;
            this.gridColumn2.MinWidth = 80;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 7;
            this.gridColumn2.Width = 80;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "单位";
            this.gridColumn12.FieldName = "Unit";
            this.gridColumn12.MaxWidth = 80;
            this.gridColumn12.MinWidth = 80;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 8;
            this.gridColumn12.Width = 80;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "备注";
            this.gridColumn13.FieldName = "description";
            this.gridColumn13.MaxWidth = 200;
            this.gridColumn13.MinWidth = 200;
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 9;
            this.gridColumn13.Width = 200;
            // 
            // gridControl3
            // 
            this.gridControl3.DataSource = this.bsDetails;
            this.gridControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl3.Location = new System.Drawing.Point(0, 55);
            this.gridControl3.MainView = gridView2;
            this.gridControl3.Name = "gridControl3";
            this.gridControl3.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2,
            this.repositoryItemTextEdit1});
            this.gridControl3.Size = new System.Drawing.Size(1193, 549);
            this.gridControl3.TabIndex = 12;
            this.gridControl3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            gridView2});
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.ttSpecifiedMaterialDate);
            this.groupControl1.Controls.Add(this.cboMaterialUser);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(1193, 55);
            this.groupControl1.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(261, 21);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 18);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "领料日期:";
            // 
            // ttSpecifiedMaterialDate
            // 
            this.ttSpecifiedMaterialDate.EditValue = new System.DateTime(2017, 12, 27, 0, 0, 0, 0);
            this.ttSpecifiedMaterialDate.Location = new System.Drawing.Point(332, 19);
            this.ttSpecifiedMaterialDate.Name = "ttSpecifiedMaterialDate";
            this.ttSpecifiedMaterialDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ttSpecifiedMaterialDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ttSpecifiedMaterialDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.ttSpecifiedMaterialDate.Properties.DisplayFormat.FormatString = "yyyy-MM-dd";
            this.ttSpecifiedMaterialDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ttSpecifiedMaterialDate.Properties.EditFormat.FormatString = "yyyy-MM-dd";
            this.ttSpecifiedMaterialDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.ttSpecifiedMaterialDate.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.ttSpecifiedMaterialDate.Properties.Mask.EditMask = "yyyy-MM-dd";
            this.ttSpecifiedMaterialDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.ttSpecifiedMaterialDate.Size = new System.Drawing.Size(110, 24);
            this.ttSpecifiedMaterialDate.TabIndex = 6;
            // 
            // cboMaterialUser
            // 
            this.cboMaterialUser.Location = new System.Drawing.Point(88, 18);
            this.cboMaterialUser.Name = "cboMaterialUser";
            this.cboMaterialUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboMaterialUser.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboMaterialUser.Size = new System.Drawing.Size(132, 24);
            this.cboMaterialUser.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(32, 21);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 18);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "领料员:";
            // 
            // SpecifiedMaterialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1193, 634);
            this.Controls.Add(this.gridControl3);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SpecifiedMaterialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "发料";
            this.Load += new System.EventHandler(this.EditUserForm_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.gridControl3, 0);
            ((System.ComponentModel.ISupportInitialize)(gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ttSpecifiedMaterialDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ttSpecifiedMaterialDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboMaterialUser.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cboMaterialUser;
        private DevExpress.XtraGrid.GridControl gridControl3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit ttSpecifiedMaterialDate;
        private System.Windows.Forms.BindingSource bsDetails;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;



    }
}