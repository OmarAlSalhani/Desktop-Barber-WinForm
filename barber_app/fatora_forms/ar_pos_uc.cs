using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using barber_app.classes;
using barber_app.settings_files;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using barber_app.classes;
using barber_app.settings_files;

namespace barber_app.fatora_forms
{
    public partial class ar_pos_uc : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// delete from head table
        /// delete from body table
        /// </summary>
        /// 
        bool is_all_ok_for_edit()
        {
            if (main_gridview.RowCount == 0)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء أختيار الخدمات أولاً");
                return false;
            }
            the_names = string.Empty;
            if (customer_name_cb.Text != "عميل نقدي")
            {
            }
            return true;
        }
        public ar_pos_uc()
        {
            InitializeComponent();
            my_grid_view_class.set_find_panel_font2(main_gridview, quantites_grid_control, false, false, false);
            my_grid_view_class.set_font_and_hover_effect(main_gridview);
            my_grid_view_class.show_empty_message2(main_gridview);
        }

        #region vars_area
        public static string the_date;
        // pos products user control
        // list to prevent add duplicate products to gridview
        public List<string> AddedProducts = new List<string>();
        DataTable products_table;
        // to store invoice id 
        public static int FatoraID = 0;

        #endregion
        #region methods_area
        string the_names = null;
        // to check if everything ok before add invoice
        private bool IsEveryThingOK()
        {
            if (main_gridview.RowCount == 0)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء أختيار الخدمات أولاً");
                return false;
            }
            return true;
        }
        // fill { total amount } and { discount } and { final amount } texts

        // get fatora id from database
        static int fatora_id()
        {
            DataTable table = connection_class.select("select isnull(max(fatora_id),1) from sales_head_table");
            return Convert.ToInt32(table.Rows[0][0]);
        }
        // fill table with report head info for print
        static DataTable head_datasource()
        {
            DataTable table = connection_class.select("select * from sales_head_table where fatora_id=" + fatora_id());
            return table;
        }
        // fill table with report body info for print
        static DataTable products_datasource()
        {
            DataTable table = connection_class.select("select * from sales_body_table where fatora_id=" + fatora_id());
            return table;
        }
        // get fatora id from database
        private void GetFatoraID()
        {
            DataTable fatora_id_table = connection_class.select("Select isnull(max(fatora_id)+1,1) from sales_head_table");
            FatoraID = Convert.ToInt32(fatora_id_table.Rows[0][0]);
        }
        // send invoice to database to save it`s info
        // for each invoice there`s two main thing :
        // invoice head : which hold un repeated info
        // invoice body : which hold repeated info { products }
        double get_discounts()
        {
            double discount = 0;
            for (int i = 0; i < main_gridview.RowCount; i++)
            {
                discount += Convert.ToDouble(main_gridview.GetRowCellValue(i, coldiscount).ToString());
            }
            return discount;
        }
        int add_fatora_head_and_body(string bill_type, string customer_name)
        {

            GetFatoraID();
            string pay_method = "آجل";

            if (ar_sell_fatora_checkout_form.cash_pay > 0 &&
                          ar_sell_fatora_checkout_form.card_pay <= 0)
            {
                pay_method = "نقداً";
            }
            if (ar_sell_fatora_checkout_form.card_pay > 0 &&
              ar_sell_fatora_checkout_form.cash_pay <= 0)
            {
                pay_method = "البطاقة الإئتمانية";
            }
            if (ar_sell_fatora_checkout_form.card_pay > 0 &&
              ar_sell_fatora_checkout_form.cash_pay > 0)
            {
                pay_method = "متعدد";
            }
            DataTable customersTable = connection_class.select($"select customer_id from customers_table where customer_name=N'{customer_name}'");
            int customer_id = 0;
            if (customersTable.Rows.Count != 0)
            {
                customer_id = Convert.ToInt32(customersTable.Rows[0][0]);
            }
            string sell_date = DateTime.Now.ToString("dd-MM-yyyy");
            string sell_time = DateTime.Now.ToString("hh:mm:ss tt");
            double total_amount =ar_sell_fatora_checkout_form.total_amount;
            double discount = get_discounts();
            double tax = get_tax();
            double cash =ar_sell_fatora_checkout_form.cash_pay;
            double card =ar_sell_fatora_checkout_form.card_pay;
            double paied_money =ar_sell_fatora_checkout_form.cash_pay +ar_sell_fatora_checkout_form.card_pay;
            double total_before_taxes = ar_sell_fatora_checkout_form.total_amount - get_tax();
            double net_amount =ar_sell_fatora_checkout_form.how_stay;
            connection_class.command($"insert into sales_head_table values ({FatoraID},N'{bill_type}',N'{sell_date}',N'{sell_time}',N'{customer_id}',{total_amount},{discount},{net_amount},N'{const_variables_class.userID}',N'{pay_method}',{tax},{total_before_taxes},{paied_money},{cash},{card}  )");
            int result = 0;
            //TODO
            // eqrar_taxes_class.add_sell_fatora(FatoraID, customer_name, main_settings.Default.enable_multi_pay == true ?ar_sell_fatora_checkout_form.total_amount - get_tax() : the_total_amount() - get_tax(), get_tax(), main_settings.Default.enable_multi_pay == true ?ar_sell_fatora_checkout_form.total_amount : the_total_amount());
            for (int i = 0; i < main_gridview.RowCount; i++)
            {
                string service_name = main_gridview.GetRowCellValue(i, colproduct_name).ToString();
                DataTable serviceTable = connection_class.select($"select id from services_table where service_name=N'{service_name}'");
                int serviceID = 0;
                if (serviceTable.Rows.Count != 0)
                {
                    serviceID = Convert.ToInt32(serviceTable.Rows[0][0]);
                }
                double price = Convert.ToDouble(main_gridview.GetRowCellValue(i, colafter_tax));
                double price_before_tax = Convert.ToDouble(main_gridview.GetRowCellValue(i, colbefore_tax));
                double product_discount = Convert.ToDouble(main_gridview.GetRowCellValue(i, coldiscount));
                double product_tax = Convert.ToDouble(main_gridview.GetRowCellValue(i, coltax));
                double full_value = Convert.ToDouble(main_gridview.GetRowCellValue(i, colfull_value));
                result = connection_class.command($"insert into sales_body_table values({FatoraID},N'{serviceID}',1,{price},{price_before_tax},{product_discount},{product_tax},{full_value})");
            }
            set_storage_value_and_logs();
            logs_class.log_add($"إضافة فاتورة مبيعات رقم {FatoraID}", FatoraID, "المبيعات");
            return result;
        }
        void clear_rows()
        {
            for (int c = 0; c < main_gridview.RowCount; c++)
            {
                main_gridview.DeleteRow(c);
            }
            for (int l = 0; l < main_gridview.DataRowCount; l++)
            {
                main_gridview.DeleteRow(l);
            }
            if (main_gridview.RowCount != 0)
            {
                for (int c = 0; c < main_gridview.RowCount; c++)
                {
                    main_gridview.DeleteRow(c);
                }
            }
            if (main_gridview.DataRowCount != 0)
            {
                for (int l = 0; l < main_gridview.DataRowCount; l++)
                {
                    main_gridview.DeleteRow(l);
                }

            }
            run_worker_class.run(fill_services_worker);

        }
        private void SendFatoraToDatabase(string bill_type, string customer_name)
        {
            if (IsEveryThingOK() == false)
            {
                return;
            }
            if (add_fatora_head_and_body(bill_type, customer_name) >= 1)
            {
                // بدي أعرف أذا عم بيع الوحدة الرئيسية أما لا
                for (int i = 0; i < main_gridview.RowCount; i++)
                {
                    if (i < main_gridview.RowCount)
                    {
                        string product_name = main_gridview.GetRowCellValue(i, colproduct_name).ToString();
                        if (i == main_gridview.RowCount - 1)
                        {
                            print_or_not();
                            clear_rows();
                            AddedProducts.Clear();
                            break;
                        }
                        else
                            continue;
                    }
                    else if (i == main_gridview.RowCount - 1)

                    {
                        print_or_not();
                        clear_rows();
                        AddedProducts.Clear();
                    }
                }
            }
        }
        bool print_fatora = false;
        void print_or_not()
        {
            //TODO
            /*   if (print_fatora)
               {
                   // print default fatora
                   if (pos_settings.Default.whice_fatora_to_print == 0)
                   {
                       // 0 = 80 mm
                       if (pos_settings.Default.A4_thermal_paper == 0)
                       {
                           if (pos_settings.Default.print == 1)
                           {
                               repost_pos.pos_report.print(products_datasource(), head_datasource());
                           }
                           else
                           {
                               repost_pos.pos_report.print(products_datasource(), head_datasource());
                           }
                       }
                       // 1 = A4
                       else if (pos_settings.Default.A4_thermal_paper == 1)
                       {

                           if (pos_settings.Default.print == 1)
                           {
                               repost_pos.A4_pos_report.print(products_datasource(), head_datasource());
                           }
                           else
                           {
                               //TODO
                              // repost_pos.A4_pos_report.print(products_datasource(), head_datasource());
                           }
                       }
                   }
               }*/
            /*else*/
            classes.notifications_class.success_message();
            customer_name_cb.SelectedIndex = 0;
        }
        #endregion
        void set_storage_value_and_logs()
        {
            if (fatora_forms.ar_sell_fatora_checkout_form.cash_pay > 0)
            {
                storage_class.storage_value_increase(fatora_forms.ar_sell_fatora_checkout_form.cash_pay);
                storage_class.storage_log_add($"القبض من فاتورة المبيعات ذات الرقم {FatoraID}",ar_sell_fatora_checkout_form.cash_pay, main_settings.Default.storage_name);
            }
            if (fatora_forms.ar_sell_fatora_checkout_form.card_pay > 0)
            {
                bank_class.bank_value_increase(fatora_forms.ar_sell_fatora_checkout_form.card_pay);
                bank_class.bank_log_add($"القبض من فاتورة المبيعات ذات الرقم {FatoraID}",ar_sell_fatora_checkout_form.card_pay, main_settings.Default.bank_name, false);
            }
           ar_sell_fatora_checkout_form.IsClicked = false;
        }
        //Cash pay button without print
        double the_total_amount()
        {
            double value = 0;
            for (int i = 0; i < main_gridview.DataRowCount; i++)
            {
                value += Convert.ToDouble(main_gridview.GetRowCellValue(i, colfull_value).ToString());
            }
            return value;
        }
        double get_tax()
        {
            double value = 0;
            if (settings_files.main_settings.Default.tax_value != 0)
            {
                for (int i = 0; i < main_gridview.DataRowCount; i++)
                {
                    double tax = Convert.ToDouble(main_gridview.GetRowCellValue(i, coltax).ToString());
                    value += tax;
                }
            }

            return value;
        }
        void send_fatora_to_agel_db()
        {
            GetFatoraID();
            DataTable CustomersTable = connection_class.select($"select customer_id from customers_table where customer_name=N'{customer_name_cb.Text}'");
            int customerID = 0;
            if(CustomersTable.Rows.Count!=0)
            {
                customerID = Convert.ToInt32(CustomersTable.Rows[0][0]);
            }
            DataTable table = connection_class.select("select isnull(max(agl_id)+1,1) from agle_table");
            SqlCommand command = new SqlCommand("insert into agle_table values (@agl_id,@fatora_id,@customer_id,@how_pay,@how_stay,@full_money,@the_pay_date,@ok,@sell_date)", connection_class.connection());
            double how_stay = ar_sell_fatora_checkout_form.total_amount - (fatora_forms.ar_sell_fatora_checkout_form.card_pay +ar_sell_fatora_checkout_form.cash_pay);
            command.Parameters.AddWithValue("@agl_id", Convert.ToInt32(table.Rows[0][0]));
            command.Parameters.AddWithValue("@fatora_id", FatoraID);
            command.Parameters.AddWithValue("@customer_id", customerID);
            command.Parameters.AddWithValue("@how_pay",ar_sell_fatora_checkout_form.card_pay +ar_sell_fatora_checkout_form.cash_pay);
            command.Parameters.AddWithValue("@how_stay", how_stay);
            command.Parameters.AddWithValue("@full_money",ar_sell_fatora_checkout_form.total_amount);
            command.Parameters.AddWithValue("@the_pay_date", agel_due_date_dtp.DateTime.ToString("dd-MM-yyyy"));
            command.Parameters.AddWithValue("@sell_date", DateTime.Now.ToString("dd-MM-yyyy"));
            command.Parameters.AddWithValue("@ok", 0);
            command.ExecuteNonQuery();
            classes.add_kshf_class.customer_kshf(customer_name_cb.Text, $"فاتورة مبيعات رقم ( {FatoraID} )", how_stay);
            classes.aol_moda_class.update_customer_aol_moda(customer_name_cb.Text, how_stay);
            SendFatoraToDatabase("آجل", customer_name_cb.Text);

        }
        private void pay_btn_Click(object sender, EventArgs e)
        {
            print_fatora = false;

            if (customer_name_cb.SelectedIndex == -1)
            {
                OmarNotifications.Alert.ShowInformation("يرجى تحديد العميل");
                return;
            }
            save_fatora();
        }
        private void main_gridview_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colbefore_tax)
            {
                double tax = (Convert.ToDouble(main_gridview.GetFocusedRowCellValue(colbefore_tax)) * main_settings.Default.tax_value) / 100;
                tax = tax + Convert.ToDouble(main_gridview.GetFocusedRowCellValue(colbefore_tax));
                main_gridview.SetFocusedRowCellValue(colafter_tax, tax);
            }
            if (e.Column == coldiscount)
            {
                double discount = Convert.ToDouble(main_gridview.GetFocusedRowCellValue(coldiscount));
                double after_tax = (Convert.ToDouble(main_gridview.GetFocusedRowCellValue(colbefore_tax)) * main_settings.Default.tax_value) / 100;
                after_tax = after_tax + Convert.ToDouble(main_gridview.GetFocusedRowCellValue(colbefore_tax));
                if (discount > after_tax)
                {
                    OmarNotifications.Alert.ShowInformation("لا يمكن أن يكون الخصم أكبر من سعر المبيع");
                }
                double val = after_tax - discount;
                main_gridview.SetFocusedRowCellValue(colafter_tax, val);
            }

            double total_before_tax = the_total_amount() - get_tax();
            total_amount_after_tax_textbox.Text = the_total_amount().ToString();
            total_amount_before_tax_textbox.Text = total_before_tax.ToString();
            tax_textbox.Text = get_tax().ToString();
        }

        private void main_gridview_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            double total_before_tax = the_total_amount() - get_tax();
            total_amount_after_tax_textbox.Text = the_total_amount().ToString();
            total_amount_before_tax_textbox.Text = total_before_tax.ToString();
            tax_textbox.Text = get_tax().ToString();
        }

        private void main_gridview_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            double total_before_tax = the_total_amount() - get_tax();
            total_amount_after_tax_textbox.Text = the_total_amount().ToString();
            total_amount_before_tax_textbox.Text = total_before_tax.ToString();
            tax_textbox.Text = get_tax().ToString();
        }


        private void pay_print_btn_Click(object sender, EventArgs e)
        {
            if (customer_name_cb.SelectedIndex == -1)
            {
                OmarNotifications.Alert.ShowInformation("يرجى تحديد العميل");
                return;
            }
            print_fatora = true;
            save_fatora();
        }

        private void ar_pos_uc_Load(object sender, EventArgs e)
        {
            agel_due_date_dtp.DateTime = DateTime.Now;
            run_worker_class.run(customers_worker);
        }

        private void main_gridview_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            try
            {
                if (e.Column.Caption == "حذف")
                {
                    AddedProducts.Remove(main_gridview.GetFocusedRowCellValue(colproduct_name).ToString());
                    main_gridview.DeleteRow(e.RowHandle);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                return;
            }
        }

        private void search_cb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {


        }

        private void customer_name_cb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                customers_forms.ar_customers_form form = new customers_forms.ar_customers_form();
                form.ShowDialog();
                run_worker_class.run(customers_worker);
            }
        }
        DataTable customers_table;
        private void customers_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            customers_table = connection_class.select("select customer_name from customers_table order by customer_name");

        }
        private void customers_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            classes.comboBox_class.fill_combobox(customers_table, customer_name_cb);
            customer_name_cb.Properties.Items.Insert(0, "عميل نقدي");
            customer_name_cb.SelectedIndex = 0;
            run_worker_class.run(fill_categories_worker);
        }
        public static bool is_bill_agel = false;
        public static bool is_gomla = false;
        public static int col_number_for_open_unit_form = 0;
        void add_via_combobox()
        {
            double price_after_tax = 0;
            double price_before_tax = 0;
            DataTable table = connection_class.select($"Select * from services_table where service_name=N'{service_name_cb.Text}'");
            if (table.Rows.Count == 0)
            {
                OmarNotifications.Alert.ShowInformation("الخدمة غير معرفة");
                return;
            }
            else
            {
                string service_name = table.Rows[0]["service_name"].ToString();
                price_before_tax = Math.Round(Convert.ToDouble(table.Rows[0]["price_before_tax"]), 2);
                double tax = (price_before_tax * main_settings.Default.tax_value) / 100;
                price_after_tax = tax + price_before_tax;
                main_gridview.AddNewRow();
                main_gridview.SetRowCellValue(GridControl.NewItemRowHandle, colid, table.Rows[0]["id"].ToString());
                main_gridview.SetRowCellValue(GridControl.NewItemRowHandle, colproduct_name, service_name);
                main_gridview.SetRowCellValue(GridControl.NewItemRowHandle, coldiscount, 0);
                main_gridview.SetRowCellValue(GridControl.NewItemRowHandle, coltax, tax);
                main_gridview.SetRowCellValue(GridControl.NewItemRowHandle, colbefore_tax, price_before_tax);
                main_gridview.SetRowCellValue(GridControl.NewItemRowHandle, colafter_tax, price_after_tax);
                main_gridview.SetRowCellValue(GridControl.NewItemRowHandle, colfull_value, price_after_tax);
                AddedProducts.Add(service_name);
            }
            main_gridview.MoveLast();
        }
        DataTable main_category_table;
        private void products_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            main_category_table = connection_class.select("select id,category_name from categories_table where is_main=1");
        }
        private void products_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            comboBox_class.fill_combobox(main_category_table, main_category_cb);
            run_worker_class.run(fill_services_worker);
        }

        private void main_gridview_RowCountChanged(object sender, EventArgs e)
        {
            double total_before_tax = the_total_amount() - get_tax();
            total_amount_after_tax_textbox.Text = the_total_amount().ToString();
            total_amount_before_tax_textbox.Text = total_before_tax.ToString();
            tax_textbox.Text = get_tax().ToString();
        }

        private void search_cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (texts_class.is_null(main_category_cb.Text) == false || main_category_cb.SelectedIndex != -1)
                {
                    add_via_combobox();
                    main_gridview.MoveLast();
                }
                else
                {
                    OmarNotifications.Alert.ShowInformation("يرجى أختيار الخدمة أولاً");
                    return;
                }
            }
        }
        private void add_product_button_Click(object sender, EventArgs e)
        {
            if (texts_class.is_null(main_category_cb.Text) == false || main_category_cb.SelectedIndex != -1)
            {
                add_via_combobox();
                main_gridview.MoveLast();
            }
            else
            {
                OmarNotifications.Alert.ShowInformation("يرجى أختيار الخدمة أولاً");
                return;
            }
        }

        private void search_cb_Click(object sender, EventArgs e)
        {
            main_category_cb.SelectAll();
        }

        private void customer_name_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customer_name_cb.Text != "عميل نقدي")
            {
                is_bill_agel = true;

            }
            else is_bill_agel = false;
        }
        void save_fatora()
        {
            if (IsEveryThingOK())
            {
                /*// اذا مو مفعل الدفع المتعدد وحالياً العميل نقدي
                if (customer_name_cb.Text == "عميل نقدي")
                {
                    SendFatoraToDatabase("نقداً", "عميل نقدي");
                    return;
                }
                // اذا مو مفعل الدفع المتعدد وحالياً العميل آجل
                if (customer_name_cb.Text != "عميل نقدي")
                {
                    send_fatora_to_agel_db();
                    return;
                }
*/
                get_tax();
               ar_sell_fatora_checkout_form form = new ar_sell_fatora_checkout_form();
                if (customer_name_cb.Text != "عميل نقدي")
                {
                    is_bill_agel = true;
                    form.pay_type_cb.Properties.Items.Remove("متعدد");
                }
                else is_bill_agel = false;
                form.total_textbox.Text = the_total_amount().ToString();
                form.net_textbox.Text = the_total_amount().ToString();
                form.ShowDialog();
                if (fatora_forms.ar_sell_fatora_checkout_form.IsClicked)
                {
                    // إذا الفاتورة مبيعات نقدية
                    if (customer_name_cb.Text == "عميل نقدي")
                    {
                        if (fatora_forms.ar_sell_fatora_checkout_form.how_stay > 0)
                        {
                            classes.notifications_class.my_messageBox("لم يتم دفع كامل قيمة الفاتورة\nوالعميل الحالي نقدي\nالرجاء تسديد كامل قيمة الفاتورة أو تحويل العميل إلى آجل", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        // إذا باقي الفاتورة يساوي الصفر
                        else if (fatora_forms.ar_sell_fatora_checkout_form.how_stay == 0)
                        {
                            SendFatoraToDatabase("نقداً", "عميل نقدي");
                        }

                    }
                    // إذا فاتورة المبيعات آجلة
                    else if (customer_name_cb.Text != "عميل نقدي")
                    {
                        if (fatora_forms.ar_sell_fatora_checkout_form.how_stay <= 0)
                        {
                            OmarNotifications.Alert.ShowInformation("تم دفع كامل قيمة الفاتورة\nيرجى تحويل العميل إلى نقدي");
                            return;
                        }
                        else if (fatora_forms.ar_sell_fatora_checkout_form.how_stay > 0)
                        {
                            send_fatora_to_agel_db();
                        }

                    }
                }
            }
        }
        string category_name = "";
        private void main_category_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (main_category_cb.SelectedIndex == -1)
            {
                service_name_cb.Properties.Items.Clear();
                return;
            }
            category_name = main_category_cb.Text;
            run_worker_class.run(fill_services_worker);
        }
        DataTable getServicesTable;
        private void fill_services_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            getServicesTable = connection_class.select($"select service_name from services_table where main_category_id=(select id from categories_table where category_name=N'{category_name}')");
        }
        DataTable getCategoriesTable;
        private void fill_categories_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            getCategoriesTable = connection_class.select($"select category_name from categories_table");
        }

        private void fill_categories_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            comboBox_class.fill_combobox(getCategoriesTable, main_category_cb);
        }

        private void fill_services_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            comboBox_class.fill_combobox(getServicesTable, service_name_cb);
        }
    }
}
