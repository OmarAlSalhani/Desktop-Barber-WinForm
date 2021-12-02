namespace barber_app.products_forms
{
    partial class category_form
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.delete_btn = new DevExpress.XtraEditors.SimpleButton();
            this.save_btn = new DevExpress.XtraEditors.SimpleButton();
            this.update_btn = new DevExpress.XtraEditors.SimpleButton();
            this.new_btn = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.category_name_tb = new DevExpress.XtraEditors.ButtonEdit();
            this.id_tb = new DevExpress.XtraEditors.ButtonEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControl16 = new DevExpress.XtraEditors.GroupControl();
            this.main_gridcontrol = new DevExpress.XtraGrid.GridControl();
            this.main_gridview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.category_name_tb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_tb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl16)).BeginInit();
            this.groupControl16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.main_gridcontrol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_gridview)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.RoyalBlue;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(566, 38);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 14F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(215, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "إدارة التصنيفات";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 10F);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.delete_btn);
            this.groupControl1.Controls.Add(this.save_btn);
            this.groupControl1.Controls.Add(this.update_btn);
            this.groupControl1.Controls.Add(this.new_btn);
            this.groupControl1.Location = new System.Drawing.Point(2, 361);
            this.groupControl1.LookAndFeel.SkinName = "DevExpress Style";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(562, 82);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "العمليات المتاحة";
            // 
            // delete_btn
            // 
            this.delete_btn.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.delete_btn.Appearance.Options.UseFont = true;
            this.delete_btn.ImageOptions.Image = global::barber_app.Properties.Resources.a_delete;
            this.delete_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.delete_btn.Location = new System.Drawing.Point(64, 37);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(105, 38);
            this.delete_btn.TabIndex = 3;
            this.delete_btn.Text = "حذف";
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // save_btn
            // 
            this.save_btn.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.save_btn.Appearance.Options.UseFont = true;
            this.save_btn.ImageOptions.Image = global::barber_app.Properties.Resources.a_save;
            this.save_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.save_btn.Location = new System.Drawing.Point(281, 37);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(105, 38);
            this.save_btn.TabIndex = 1;
            this.save_btn.Text = "حفظ";
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // update_btn
            // 
            this.update_btn.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.update_btn.Appearance.Options.UseFont = true;
            this.update_btn.ImageOptions.Image = global::barber_app.Properties.Resources.a_edit;
            this.update_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.update_btn.Location = new System.Drawing.Point(173, 37);
            this.update_btn.Name = "update_btn";
            this.update_btn.Size = new System.Drawing.Size(105, 38);
            this.update_btn.TabIndex = 2;
            this.update_btn.Text = "تعديل";
            this.update_btn.Click += new System.EventHandler(this.update_btn_Click);
            // 
            // new_btn
            // 
            this.new_btn.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.new_btn.Appearance.Options.UseFont = true;
            this.new_btn.ImageOptions.Image = global::barber_app.Properties.Resources.a_new;
            this.new_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.new_btn.Location = new System.Drawing.Point(390, 37);
            this.new_btn.Name = "new_btn";
            this.new_btn.Size = new System.Drawing.Size(105, 38);
            this.new_btn.TabIndex = 0;
            this.new_btn.Text = "جديد";
            this.new_btn.Click += new System.EventHandler(this.new_btn_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 10F);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl2.Controls.Add(this.category_name_tb);
            this.groupControl2.Controls.Add(this.id_tb);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Location = new System.Drawing.Point(2, 40);
            this.groupControl2.LookAndFeel.SkinName = "DevExpress Style";
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(562, 73);
            this.groupControl2.TabIndex = 7;
            this.groupControl2.Text = "البيانات الأساسية";
            // 
            // category_name_tb
            // 
            this.category_name_tb.EditValue = "";
            this.category_name_tb.EnterMoveNextControl = true;
            this.category_name_tb.Location = new System.Drawing.Point(9, 34);
            this.category_name_tb.Name = "category_name_tb";
            this.category_name_tb.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.category_name_tb.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.category_name_tb.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 10.5F);
            this.category_name_tb.Properties.Appearance.Options.UseFont = true;
            this.category_name_tb.Properties.Appearance.Options.UseTextOptions = true;
            this.category_name_tb.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.category_name_tb.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.category_name_tb.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.category_name_tb.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.category_name_tb.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.category_name_tb.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.category_name_tb.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.category_name_tb.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.category_name_tb.Properties.BeepOnError = false;
            this.category_name_tb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.category_name_tb.Properties.UseMaskAsDisplayFormat = true;
            this.category_name_tb.Size = new System.Drawing.Size(288, 34);
            this.category_name_tb.TabIndex = 42;
            // 
            // id_tb
            // 
            this.id_tb.EditValue = "";
            this.id_tb.EnterMoveNextControl = true;
            this.id_tb.Location = new System.Drawing.Point(392, 34);
            this.id_tb.Name = "id_tb";
            this.id_tb.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.id_tb.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.id_tb.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 10.5F);
            this.id_tb.Properties.Appearance.Options.UseFont = true;
            this.id_tb.Properties.Appearance.Options.UseTextOptions = true;
            this.id_tb.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id_tb.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.id_tb.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.id_tb.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id_tb.Properties.AppearanceFocused.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.id_tb.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.id_tb.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.id_tb.Properties.AppearanceReadOnly.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.id_tb.Properties.BeepOnError = false;
            this.id_tb.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.id_tb.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.id_tb.Properties.MaskSettings.Set("mask", "d");
            this.id_tb.Properties.ReadOnly = true;
            this.id_tb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.id_tb.Properties.UseMaskAsDisplayFormat = true;
            this.id_tb.Size = new System.Drawing.Size(79, 34);
            this.id_tb.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label2.Location = new System.Drawing.Point(472, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 26);
            this.label2.TabIndex = 40;
            this.label2.Text = "رقم التصنيف";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label3.Location = new System.Drawing.Point(300, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 26);
            this.label3.TabIndex = 37;
            this.label3.Text = "أسم التصنيف";
            // 
            // groupControl16
            // 
            this.groupControl16.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.groupControl16.Appearance.Options.UseBackColor = true;
            this.groupControl16.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 10F);
            this.groupControl16.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl16.AppearanceCaption.Options.UseFont = true;
            this.groupControl16.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl16.Controls.Add(this.main_gridcontrol);
            this.groupControl16.Location = new System.Drawing.Point(2, 115);
            this.groupControl16.LookAndFeel.SkinName = "DevExpress Style";
            this.groupControl16.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl16.Name = "groupControl16";
            this.groupControl16.Size = new System.Drawing.Size(562, 244);
            this.groupControl16.TabIndex = 12;
            this.groupControl16.Text = "معلومات التصنيفات";
            // 
            // main_gridcontrol
            // 
            this.main_gridcontrol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.main_gridcontrol.Dock = System.Windows.Forms.DockStyle.Fill;
            this.main_gridcontrol.Location = new System.Drawing.Point(2, 31);
            this.main_gridcontrol.MainView = this.main_gridview;
            this.main_gridcontrol.Name = "main_gridcontrol";
            this.main_gridcontrol.Size = new System.Drawing.Size(558, 211);
            this.main_gridcontrol.TabIndex = 37;
            this.main_gridcontrol.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.main_gridview});
            // 
            // main_gridview
            // 
            this.main_gridview.Appearance.FocusedCell.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.main_gridview.Appearance.FocusedCell.Options.UseFont = true;
            this.main_gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.FocusedRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.main_gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.main_gridview.Appearance.FocusedRow.Options.UseBackColor = true;
            this.main_gridview.Appearance.FocusedRow.Options.UseFont = true;
            this.main_gridview.Appearance.FocusedRow.Options.UseForeColor = true;
            this.main_gridview.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.main_gridview.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.main_gridview.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.main_gridview.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.main_gridview.Appearance.HeaderPanel.Options.UseFont = true;
            this.main_gridview.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.main_gridview.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.main_gridview.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.main_gridview.Appearance.Row.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.main_gridview.Appearance.Row.Options.UseFont = true;
            this.main_gridview.Appearance.Row.Options.UseTextOptions = true;
            this.main_gridview.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.main_gridview.Appearance.Row.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.main_gridview.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.SelectedRow.Font = new System.Drawing.Font("Cairo", 10F);
            this.main_gridview.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.main_gridview.Appearance.SelectedRow.Options.UseBackColor = true;
            this.main_gridview.Appearance.SelectedRow.Options.UseFont = true;
            this.main_gridview.Appearance.SelectedRow.Options.UseForeColor = true;
            this.main_gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.main_gridview.GridControl = this.main_gridcontrol;
            this.main_gridview.Name = "main_gridview";
            this.main_gridview.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsBehavior.AllowIncrementalSearch = true;
            this.main_gridview.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsBehavior.Editable = false;
            this.main_gridview.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.main_gridview.OptionsBehavior.UnboundColumnExpressionEditorMode = DevExpress.XtraEditors.ExpressionEditorMode.AutoComplete;
            this.main_gridview.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.main_gridview.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.main_gridview.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.main_gridview.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsFind.AllowFindPanel = false;
            this.main_gridview.OptionsFind.AlwaysVisible = true;
            this.main_gridview.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.main_gridview.OptionsFind.FindNullPrompt = "ابدأ بكتابة النص لبدء البحث";
            this.main_gridview.OptionsFind.HighlightFindResults = false;
            this.main_gridview.OptionsFind.SearchInPreview = true;
            this.main_gridview.OptionsFind.ShowClearButton = false;
            this.main_gridview.OptionsFind.ShowFindButton = false;
            this.main_gridview.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Slide;
            this.main_gridview.OptionsNavigation.AutoFocusNewRow = true;
            this.main_gridview.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.main_gridview.OptionsSelection.MultiSelect = true;
            this.main_gridview.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.main_gridview.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.main_gridview.OptionsView.ShowGroupPanel = false;
            this.main_gridview.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.main_gridview.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.main_gridview_SelectionChanged);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "الصور |*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // category_form
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 445);
            this.Controls.Add(this.groupControl16);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "category_form";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.category_form_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.category_name_tb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.id_tb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl16)).EndInit();
            this.groupControl16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.main_gridcontrol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_gridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton new_btn;
        private DevExpress.XtraEditors.SimpleButton save_btn;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl main_gridcontrol;
        private DevExpress.XtraGrid.Views.Grid.GridView main_gridview;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        public DevExpress.XtraEditors.SimpleButton delete_btn;
        public DevExpress.XtraEditors.SimpleButton update_btn;
        private DevExpress.XtraEditors.GroupControl groupControl16;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ButtonEdit id_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ButtonEdit category_name_tb;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}