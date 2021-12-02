namespace barber_app.fatora_forms
{
    partial class ar_pos_uc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ar_pos_uc));
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.service_name_cb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.main_category_cb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.add_product_btn = new DevExpress.XtraEditors.PictureEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.agel_due_date_dtp = new DevExpress.XtraEditors.DateEdit();
            this.customer_name_cb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.pay_btn = new DevExpress.XtraEditors.SimpleButton();
            this.pay_and_print_btn = new DevExpress.XtraEditors.SimpleButton();
            this.quantites_grid_control = new DevExpress.XtraGrid.GridControl();
            this.productsmodelBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.main_gridview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colproduct_name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colbefore_tax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colafter_tax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldiscount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfull_value = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.before_tax_lbl = new System.Windows.Forms.Label();
            this.tax_lbl = new System.Windows.Forms.Label();
            this.after_tax_lbl = new System.Windows.Forms.Label();
            this.total_amount_before_tax_textbox = new DevExpress.XtraEditors.ButtonEdit();
            this.total_amount_after_tax_textbox = new DevExpress.XtraEditors.ButtonEdit();
            this.tax_textbox = new DevExpress.XtraEditors.ButtonEdit();
            this.customers_worker = new System.ComponentModel.BackgroundWorker();
            this.fill_services_worker = new System.ComponentModel.BackgroundWorker();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.fill_categories_worker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.service_name_cb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_category_cb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_product_btn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agel_due_date_dtp.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.agel_due_date_dtp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customer_name_cb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantites_grid_control)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsmodelBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_gridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_amount_before_tax_textbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_amount_after_tax_textbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tax_textbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            this.navigationPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl2.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupControl2.Appearance.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.BackColor = System.Drawing.Color.Lime;
            this.groupControl2.AppearanceCaption.BackColor2 = System.Drawing.Color.Lime;
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 10F);
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl2.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl2.Controls.Add(this.service_name_cb);
            this.groupControl2.Controls.Add(this.main_category_cb);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.add_product_btn);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Location = new System.Drawing.Point(436, 1);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(599, 75);
            this.groupControl2.TabIndex = 14;
            this.groupControl2.Text = "خيارات الفاتورة";
            // 
            // service_name_cb
            // 
            this.service_name_cb.EditValue = "";
            this.service_name_cb.EnterMoveNextControl = true;
            this.service_name_cb.Location = new System.Drawing.Point(47, 36);
            this.service_name_cb.Name = "service_name_cb";
            this.service_name_cb.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 10.5F);
            this.service_name_cb.Properties.Appearance.Options.UseFont = true;
            this.service_name_cb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.service_name_cb.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.customer_name_cb_Properties_ButtonClick);
            this.service_name_cb.Size = new System.Drawing.Size(194, 32);
            this.service_name_cb.TabIndex = 44;
            // 
            // main_category_cb
            // 
            this.main_category_cb.EditValue = "";
            this.main_category_cb.EnterMoveNextControl = true;
            this.main_category_cb.Location = new System.Drawing.Point(323, 36);
            this.main_category_cb.Name = "main_category_cb";
            this.main_category_cb.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 10.5F);
            this.main_category_cb.Properties.Appearance.Options.UseFont = true;
            this.main_category_cb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.main_category_cb.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.customer_name_cb_Properties_ButtonClick);
            this.main_category_cb.Size = new System.Drawing.Size(166, 32);
            this.main_category_cb.TabIndex = 43;
            this.main_category_cb.SelectedIndexChanged += new System.EventHandler(this.main_category_cb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cairo", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label1.Location = new System.Drawing.Point(239, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 26);
            this.label1.TabIndex = 34;
            this.label1.Text = "أسم الخدمة";
            // 
            // add_product_btn
            // 
            this.add_product_btn.EditValue = ((object)(resources.GetObject("add_product_btn.EditValue")));
            this.add_product_btn.Location = new System.Drawing.Point(7, 37);
            this.add_product_btn.Name = "add_product_btn";
            this.add_product_btn.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.add_product_btn.Properties.Appearance.Options.UseBackColor = true;
            this.add_product_btn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.add_product_btn.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.add_product_btn.Properties.SvgImageSize = new System.Drawing.Size(34, 29);
            this.add_product_btn.Size = new System.Drawing.Size(34, 31);
            this.add_product_btn.TabIndex = 33;
            this.add_product_btn.ToolTip = "إضافة المادة";
            this.add_product_btn.Click += new System.EventHandler(this.add_product_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cairo", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label3.Location = new System.Drawing.Point(486, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "التصنيف الرئيسي";
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.groupControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.BackColor = System.Drawing.Color.Lime;
            this.groupControl1.AppearanceCaption.BackColor2 = System.Drawing.Color.Lime;
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 10F);
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl1.AppearanceCaption.Options.UseBackColor = true;
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupControl1.Controls.Add(this.agel_due_date_dtp);
            this.groupControl1.Controls.Add(this.customer_name_cb);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Location = new System.Drawing.Point(1, 1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(433, 75);
            this.groupControl1.TabIndex = 17;
            this.groupControl1.Text = "خيارات العميل";
            // 
            // agel_due_date_dtp
            // 
            this.agel_due_date_dtp.EditValue = new System.DateTime(2021, 3, 8, 5, 2, 5, 0);
            this.agel_due_date_dtp.Location = new System.Drawing.Point(5, 37);
            this.agel_due_date_dtp.Name = "agel_due_date_dtp";
            this.agel_due_date_dtp.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 10.5F);
            this.agel_due_date_dtp.Properties.Appearance.Options.UseFont = true;
            this.agel_due_date_dtp.Properties.BeepOnError = false;
            this.agel_due_date_dtp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.agel_due_date_dtp.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.agel_due_date_dtp.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Fluent;
            this.agel_due_date_dtp.Properties.MaskSettings.Set("mask", "dd-MM-yyyy");
            this.agel_due_date_dtp.Properties.UseMaskAsDisplayFormat = true;
            this.agel_due_date_dtp.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.agel_due_date_dtp.Size = new System.Drawing.Size(118, 32);
            this.agel_due_date_dtp.TabIndex = 17;
            // 
            // customer_name_cb
            // 
            this.customer_name_cb.EditValue = "";
            this.customer_name_cb.EnterMoveNextControl = true;
            this.customer_name_cb.Location = new System.Drawing.Point(225, 37);
            this.customer_name_cb.Name = "customer_name_cb";
            this.customer_name_cb.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 10.5F);
            this.customer_name_cb.Properties.Appearance.Options.UseFont = true;
            this.customer_name_cb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.customer_name_cb.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.customer_name_cb_Properties_ButtonClick);
            this.customer_name_cb.Size = new System.Drawing.Size(151, 32);
            this.customer_name_cb.TabIndex = 39;
            this.customer_name_cb.SelectedIndexChanged += new System.EventHandler(this.customer_name_cb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label5.Location = new System.Drawing.Point(121, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "تاريخ الأستحقاق";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.label4.Location = new System.Drawing.Point(377, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 26);
            this.label4.TabIndex = 2;
            this.label4.Text = "العميل";
            // 
            // groupControl4
            // 
            this.groupControl4.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 10F);
            this.groupControl4.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl4.AppearanceCaption.Options.UseFont = true;
            this.groupControl4.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl4.Controls.Add(this.pay_btn);
            this.groupControl4.Controls.Add(this.pay_and_print_btn);
            this.groupControl4.Location = new System.Drawing.Point(512, 444);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(523, 124);
            this.groupControl4.TabIndex = 17;
            this.groupControl4.Text = "العمليات المتاحة";
            // 
            // pay_btn
            // 
            this.pay_btn.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.pay_btn.Appearance.Options.UseFont = true;
            this.pay_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pay_btn.ImageOptions.Image")));
            this.pay_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.pay_btn.Location = new System.Drawing.Point(18, 41);
            this.pay_btn.Name = "pay_btn";
            this.pay_btn.Size = new System.Drawing.Size(242, 73);
            this.pay_btn.TabIndex = 2;
            this.pay_btn.Text = "حفظ الفاتورة بدون طباعة";
            this.pay_btn.Click += new System.EventHandler(this.pay_btn_Click);
            // 
            // pay_and_print_btn
            // 
            this.pay_and_print_btn.Appearance.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold);
            this.pay_and_print_btn.Appearance.Options.UseFont = true;
            this.pay_and_print_btn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("pay_and_print_btn.ImageOptions.Image")));
            this.pay_and_print_btn.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.pay_and_print_btn.Location = new System.Drawing.Point(264, 41);
            this.pay_and_print_btn.Name = "pay_and_print_btn";
            this.pay_and_print_btn.Size = new System.Drawing.Size(242, 73);
            this.pay_and_print_btn.TabIndex = 1;
            this.pay_and_print_btn.Text = "حفظ وطباعة الفاتورة";
            this.pay_and_print_btn.Click += new System.EventHandler(this.pay_print_btn_Click);
            // 
            // quantites_grid_control
            // 
            this.quantites_grid_control.Cursor = System.Windows.Forms.Cursors.Hand;
            this.quantites_grid_control.DataSource = this.productsmodelBindingSource1;
            this.quantites_grid_control.Location = new System.Drawing.Point(1, 77);
            this.quantites_grid_control.MainView = this.main_gridview;
            this.quantites_grid_control.Name = "quantites_grid_control";
            this.quantites_grid_control.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.quantites_grid_control.Size = new System.Drawing.Size(1034, 365);
            this.quantites_grid_control.TabIndex = 38;
            this.quantites_grid_control.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.main_gridview});
            // 
            // productsmodelBindingSource1
            // 
            this.productsmodelBindingSource1.DataSource = typeof(barber_app.products_forms.products_model);
            // 
            // main_gridview
            // 
            this.main_gridview.Appearance.FocusedCell.Font = new System.Drawing.Font("Cairo", 8.25F);
            this.main_gridview.Appearance.FocusedCell.Options.UseFont = true;
            this.main_gridview.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(107)))), ((int)(((byte)(209)))));
            this.main_gridview.Appearance.FocusedRow.Font = new System.Drawing.Font("Cairo", 10.5F, System.Drawing.FontStyle.Bold);
            this.main_gridview.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.main_gridview.Appearance.FocusedRow.Options.UseBackColor = true;
            this.main_gridview.Appearance.FocusedRow.Options.UseFont = true;
            this.main_gridview.Appearance.FocusedRow.Options.UseForeColor = true;
            this.main_gridview.Appearance.FocusedRow.Options.UseTextOptions = true;
            this.main_gridview.Appearance.FocusedRow.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.main_gridview.Appearance.FocusedRow.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.main_gridview.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cairo", 10F);
            this.main_gridview.Appearance.HeaderPanel.Options.UseFont = true;
            this.main_gridview.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.main_gridview.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.main_gridview.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.main_gridview.Appearance.Row.Font = new System.Drawing.Font("Cairo", 10F);
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
            this.main_gridview.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.main_gridview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colproduct_name,
            this.colbefore_tax,
            this.colafter_tax,
            this.coldiscount,
            this.coltax,
            this.colfull_value,
            this.gridColumn1});
            this.main_gridview.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.main_gridview.GridControl = this.quantites_grid_control;
            this.main_gridview.Name = "main_gridview";
            this.main_gridview.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsBehavior.AllowIncrementalSearch = true;
            this.main_gridview.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Inplace;
            this.main_gridview.OptionsBehavior.UnboundColumnExpressionEditorMode = DevExpress.XtraEditors.ExpressionEditorMode.AutoComplete;
            this.main_gridview.OptionsCustomization.CustomizationFormSearchBoxVisible = true;
            this.main_gridview.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.main_gridview.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.main_gridview.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsFilter.AllowMultiSelectInCheckedFilterPopup = false;
            this.main_gridview.OptionsFilter.ShowAllTableValuesInCheckedFilterPopup = false;
            this.main_gridview.OptionsFind.AllowFindPanel = false;
            this.main_gridview.OptionsFind.FindNullPrompt = "ابدأ بكتابة النص لبدء البحث";
            this.main_gridview.OptionsFind.HighlightFindResults = false;
            this.main_gridview.OptionsFind.ShowClearButton = false;
            this.main_gridview.OptionsFind.ShowCloseButton = false;
            this.main_gridview.OptionsFind.ShowFindButton = false;
            this.main_gridview.OptionsFind.ShowSearchNavButtons = false;
            this.main_gridview.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Slide;
            this.main_gridview.OptionsNavigation.AutoFocusNewRow = true;
            this.main_gridview.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.main_gridview.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.True;
            this.main_gridview.OptionsSelection.MultiSelect = true;
            this.main_gridview.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.False;
            this.main_gridview.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;
            this.main_gridview.OptionsView.ShowGroupPanel = false;
            this.main_gridview.OptionsView.ShowIndicator = false;
            this.main_gridview.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            this.main_gridview.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.main_gridview_RowCellClick);
            this.main_gridview.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.main_gridview_InitNewRow);
            this.main_gridview.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.main_gridview_CellValueChanged);
            this.main_gridview.RowDeleted += new DevExpress.Data.RowDeletedEventHandler(this.main_gridview_RowDeleted);
            this.main_gridview.RowCountChanged += new System.EventHandler(this.main_gridview_RowCountChanged);
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.OptionsColumn.AllowMove = false;
            this.colid.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            // 
            // colproduct_name
            // 
            this.colproduct_name.Caption = "الخدمة";
            this.colproduct_name.FieldName = "product_name";
            this.colproduct_name.Name = "colproduct_name";
            this.colproduct_name.OptionsColumn.AllowMove = false;
            this.colproduct_name.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colproduct_name.Visible = true;
            this.colproduct_name.VisibleIndex = 0;
            // 
            // colbefore_tax
            // 
            this.colbefore_tax.Caption = "السعر قبل الضريبة";
            this.colbefore_tax.FieldName = "price_before_tax";
            this.colbefore_tax.Name = "colbefore_tax";
            this.colbefore_tax.OptionsColumn.AllowMove = false;
            this.colbefore_tax.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colbefore_tax.Visible = true;
            this.colbefore_tax.VisibleIndex = 1;
            // 
            // colafter_tax
            // 
            this.colafter_tax.Caption = "السعر بعد الضريبة";
            this.colafter_tax.FieldName = "price_after_tax";
            this.colafter_tax.Name = "colafter_tax";
            this.colafter_tax.OptionsColumn.AllowEdit = false;
            this.colafter_tax.OptionsColumn.AllowMove = false;
            this.colafter_tax.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colafter_tax.OptionsColumn.ShowInExpressionEditor = false;
            this.colafter_tax.Visible = true;
            this.colafter_tax.VisibleIndex = 2;
            // 
            // coldiscount
            // 
            this.coldiscount.Caption = "الخصم";
            this.coldiscount.FieldName = "discount";
            this.coldiscount.Name = "coldiscount";
            this.coldiscount.OptionsColumn.AllowMove = false;
            this.coldiscount.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.coldiscount.Visible = true;
            this.coldiscount.VisibleIndex = 3;
            // 
            // coltax
            // 
            this.coltax.Caption = "الضريبة";
            this.coltax.FieldName = "tax";
            this.coltax.Name = "coltax";
            this.coltax.OptionsColumn.AllowEdit = false;
            this.coltax.OptionsColumn.AllowMove = false;
            this.coltax.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.coltax.OptionsColumn.ShowInExpressionEditor = false;
            this.coltax.Visible = true;
            this.coltax.VisibleIndex = 4;
            // 
            // colfull_value
            // 
            this.colfull_value.Caption = "القيمة النهائية";
            this.colfull_value.FieldName = "total";
            this.colfull_value.Name = "colfull_value";
            this.colfull_value.OptionsColumn.AllowEdit = false;
            this.colfull_value.OptionsColumn.AllowMove = false;
            this.colfull_value.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colfull_value.OptionsColumn.ShowInExpressionEditor = false;
            this.colfull_value.Visible = true;
            this.colfull_value.VisibleIndex = 5;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "حذف";
            this.gridColumn1.ColumnEdit = this.repositoryItemButtonEdit1;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowMove = false;
            this.gridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // before_tax_lbl
            // 
            this.before_tax_lbl.AutoSize = true;
            this.before_tax_lbl.Font = new System.Drawing.Font("Cairo", 10F);
            this.before_tax_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.before_tax_lbl.Location = new System.Drawing.Point(366, 11);
            this.before_tax_lbl.Name = "before_tax_lbl";
            this.before_tax_lbl.Size = new System.Drawing.Size(135, 26);
            this.before_tax_lbl.TabIndex = 2;
            this.before_tax_lbl.Text = "الإجمالي قبل الضريبة";
            // 
            // tax_lbl
            // 
            this.tax_lbl.AutoSize = true;
            this.tax_lbl.Font = new System.Drawing.Font("Cairo", 10F);
            this.tax_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.tax_lbl.Location = new System.Drawing.Point(109, 11);
            this.tax_lbl.Name = "tax_lbl";
            this.tax_lbl.Size = new System.Drawing.Size(102, 26);
            this.tax_lbl.TabIndex = 3;
            this.tax_lbl.Text = "إجمالي الضريبة";
            // 
            // after_tax_lbl
            // 
            this.after_tax_lbl.AutoSize = true;
            this.after_tax_lbl.Font = new System.Drawing.Font("Cairo", 10F);
            this.after_tax_lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.after_tax_lbl.Location = new System.Drawing.Point(367, 51);
            this.after_tax_lbl.Name = "after_tax_lbl";
            this.after_tax_lbl.Size = new System.Drawing.Size(134, 26);
            this.after_tax_lbl.TabIndex = 4;
            this.after_tax_lbl.Text = "الإجمالي بعد الضريبة";
            // 
            // total_amount_before_tax_textbox
            // 
            this.total_amount_before_tax_textbox.EditValue = "";
            this.total_amount_before_tax_textbox.Location = new System.Drawing.Point(212, 7);
            this.total_amount_before_tax_textbox.Name = "total_amount_before_tax_textbox";
            this.total_amount_before_tax_textbox.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.total_amount_before_tax_textbox.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.total_amount_before_tax_textbox.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 10.5F, System.Drawing.FontStyle.Bold);
            this.total_amount_before_tax_textbox.Properties.Appearance.Options.UseFont = true;
            this.total_amount_before_tax_textbox.Properties.Appearance.Options.UseTextOptions = true;
            this.total_amount_before_tax_textbox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.total_amount_before_tax_textbox.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.total_amount_before_tax_textbox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.total_amount_before_tax_textbox.Properties.ReadOnly = true;
            this.total_amount_before_tax_textbox.Size = new System.Drawing.Size(148, 34);
            this.total_amount_before_tax_textbox.TabIndex = 41;
            // 
            // total_amount_after_tax_textbox
            // 
            this.total_amount_after_tax_textbox.EditValue = "";
            this.total_amount_after_tax_textbox.Location = new System.Drawing.Point(11, 47);
            this.total_amount_after_tax_textbox.Name = "total_amount_after_tax_textbox";
            this.total_amount_after_tax_textbox.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.total_amount_after_tax_textbox.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.total_amount_after_tax_textbox.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 10.5F, System.Drawing.FontStyle.Bold);
            this.total_amount_after_tax_textbox.Properties.Appearance.Options.UseFont = true;
            this.total_amount_after_tax_textbox.Properties.Appearance.Options.UseTextOptions = true;
            this.total_amount_after_tax_textbox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.total_amount_after_tax_textbox.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.total_amount_after_tax_textbox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.total_amount_after_tax_textbox.Properties.ReadOnly = true;
            this.total_amount_after_tax_textbox.Size = new System.Drawing.Size(349, 34);
            this.total_amount_after_tax_textbox.TabIndex = 39;
            // 
            // tax_textbox
            // 
            this.tax_textbox.EditValue = "";
            this.tax_textbox.Location = new System.Drawing.Point(11, 7);
            this.tax_textbox.Name = "tax_textbox";
            this.tax_textbox.Properties.AdvancedModeOptions.AllowCaretAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.tax_textbox.Properties.AdvancedModeOptions.AllowSelectionAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.tax_textbox.Properties.Appearance.Font = new System.Drawing.Font("Cairo", 10.5F, System.Drawing.FontStyle.Bold);
            this.tax_textbox.Properties.Appearance.Options.UseFont = true;
            this.tax_textbox.Properties.Appearance.Options.UseTextOptions = true;
            this.tax_textbox.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tax_textbox.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.tax_textbox.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.tax_textbox.Properties.ReadOnly = true;
            this.tax_textbox.Size = new System.Drawing.Size(93, 34);
            this.tax_textbox.TabIndex = 40;
            // 
            // customers_worker
            // 
            this.customers_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.customers_worker_DoWork);
            this.customers_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.customers_worker_RunWorkerCompleted);
            // 
            // fill_services_worker
            // 
            this.fill_services_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fill_services_worker_DoWork);
            this.fill_services_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fill_services_worker_RunWorkerCompleted);
            // 
            // groupControl6
            // 
            this.groupControl6.AppearanceCaption.Font = new System.Drawing.Font("Cairo", 10F);
            this.groupControl6.AppearanceCaption.ForeColor = System.Drawing.Color.RoyalBlue;
            this.groupControl6.AppearanceCaption.Options.UseFont = true;
            this.groupControl6.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl6.Controls.Add(this.navigationFrame1);
            this.groupControl6.Location = new System.Drawing.Point(1, 444);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(509, 124);
            this.groupControl6.TabIndex = 42;
            this.groupControl6.Text = "بيانات الفاتورة المالية";
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.navigationFrame1.Appearance.Options.UseBackColor = true;
            this.navigationFrame1.Controls.Add(this.navigationPage1);
            this.navigationFrame1.Location = new System.Drawing.Point(3, 34);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1});
            this.navigationFrame1.SelectedPage = this.navigationPage1;
            this.navigationFrame1.Size = new System.Drawing.Size(505, 85);
            this.navigationFrame1.TabIndex = 43;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage1
            // 
            this.navigationPage1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.navigationPage1.Appearance.Options.UseBackColor = true;
            this.navigationPage1.Caption = "navigationPage1";
            this.navigationPage1.Controls.Add(this.before_tax_lbl);
            this.navigationPage1.Controls.Add(this.total_amount_after_tax_textbox);
            this.navigationPage1.Controls.Add(this.total_amount_before_tax_textbox);
            this.navigationPage1.Controls.Add(this.tax_lbl);
            this.navigationPage1.Controls.Add(this.tax_textbox);
            this.navigationPage1.Controls.Add(this.after_tax_lbl);
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(505, 85);
            // 
            // fill_categories_worker
            // 
            this.fill_categories_worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fill_categories_worker_DoWork);
            this.fill_categories_worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fill_categories_worker_RunWorkerCompleted);
            // 
            // ar_pos_uc
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl6);
            this.Controls.Add(this.quantites_grid_control);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl4);
            this.Controls.Add(this.groupControl2);
            this.Name = "ar_pos_uc";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(1037, 570);
            this.Load += new System.EventHandler(this.ar_pos_uc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.service_name_cb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_category_cb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.add_product_btn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agel_due_date_dtp.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.agel_due_date_dtp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customer_name_cb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quantites_grid_control)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsmodelBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.main_gridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_amount_before_tax_textbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.total_amount_after_tax_textbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tax_textbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            this.navigationPage1.ResumeLayout(false);
            this.navigationPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraGrid.GridControl quantites_grid_control;
        private DevExpress.XtraEditors.ButtonEdit total_amount_before_tax_textbox;
        private DevExpress.XtraEditors.ButtonEdit tax_textbox;
        private DevExpress.XtraEditors.ButtonEdit total_amount_after_tax_textbox;
        private System.Windows.Forms.Label before_tax_lbl;
        private System.Windows.Forms.Label tax_lbl;
        private System.Windows.Forms.Label after_tax_lbl;
        private System.ComponentModel.BackgroundWorker customers_worker;
        private System.ComponentModel.BackgroundWorker fill_services_worker;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        public DevExpress.XtraEditors.SimpleButton pay_and_print_btn;
        public DevExpress.XtraEditors.SimpleButton pay_btn;
        public DevExpress.XtraGrid.Views.Grid.GridView main_gridview;
        public DevExpress.XtraGrid.Columns.GridColumn colid;
        public DevExpress.XtraGrid.Columns.GridColumn colproduct_name;
        public DevExpress.XtraGrid.Columns.GridColumn colbefore_tax;
        public DevExpress.XtraGrid.Columns.GridColumn colafter_tax;
        public DevExpress.XtraGrid.Columns.GridColumn coldiscount;
        public DevExpress.XtraGrid.Columns.GridColumn coltax;
        public DevExpress.XtraGrid.Columns.GridColumn colfull_value;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        public DevExpress.XtraEditors.DateEdit agel_due_date_dtp;
        public DevExpress.XtraEditors.ComboBoxEdit customer_name_cb;
        private DevExpress.XtraEditors.PictureEdit add_product_btn;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private System.Windows.Forms.BindingSource productsmodelBindingSource1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        public DevExpress.XtraEditors.ComboBoxEdit service_name_cb;
        public DevExpress.XtraEditors.ComboBoxEdit main_category_cb;
        private System.ComponentModel.BackgroundWorker fill_categories_worker;
    }
}
