using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using barber_app.settings_files;
using System.Data.SqlClient;
using DevExpress.XtraGrid;
using barber_app.classes;

namespace barber_app.fatora_forms
{
    public partial class ar_sell_report_form : XtraForm
    {

        public ar_sell_report_form()
        {
            InitializeComponent();
            first_date.DateTime = last_date.DateTime = DateTime.Now;
            my_grid_view_class.set_find_panel_font2(gridView2, gridControl2, true, true);
            my_grid_view_class.show_empty_message2(gridView2);
            my_grid_view_class.set_font_and_hover_effect(gridView2);
        }
        bool convert_int32(int num, string textbox)
        {
            if (!int.TryParse(textbox, out num))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        void uncheck_radio()
        {
            if (date_cbx.Checked || username_cbx.Checked || customer_cbx.Checked || fatora_type_cbx.Checked)
            {
                id_barcode_radio.Checked = false;
            }
        }
        int choices()
        {
            int c = 2;
            if (id_barcode_radio.Checked)
            {
                c = 1;
            }
            if (date_cbx.Checked && username_cbx.Checked == false && customer_cbx.Checked == false && fatora_type_cbx.Checked == false)
            {
                c = 2;
            }
            if (username_cbx.Checked && date_cbx.Checked == false && customer_cbx.Checked == false && fatora_type_cbx.Checked == false)
            {
                c = 3;
            }
            if (customer_cbx.Checked && date_cbx.Checked == false && username_cbx.Checked == false && fatora_type_cbx.Checked == false)
            {
                c = 4;
            }
            if (fatora_type_cbx.Checked && customer_cbx.Checked == false && date_cbx.Checked == false && username_cbx.Checked == false)
            {
                c = 5;
            }
            if (date_cbx.Checked && username_cbx.Checked && fatora_type_cbx.Checked == false && customer_cbx.Checked == false)
            {
                c = 6;
            }
            if (date_cbx.Checked && username_cbx.Checked && customer_cbx.Checked && fatora_type_cbx.Checked == false)
            {
                c = 7;
            }
            if (date_cbx.Checked && username_cbx.Checked && customer_cbx.Checked && fatora_type_cbx.Checked)
            {
                c = 8;
            }
            if (username_cbx.Checked && customer_cbx.Checked && date_cbx.Checked == false && fatora_type_cbx.Checked == false)
            {
                c = 9;
            }
            if (username_cbx.Checked && fatora_type_cbx.Checked && date_cbx.Checked == false && customer_cbx.Checked == false)
            {
                c = 10;
            }
            if (username_cbx.Checked && customer_cbx.Checked && fatora_type_cbx.Checked && date_cbx.Checked == false)
            {
                c = 11;
            }
            if (customer_cbx.Checked && fatora_type_cbx.Checked && date_cbx.Checked == false && username_cbx.Checked == false)
            {
                c = 12;
            }
            return c;
        }
        string query(int choices)
        {
            string f = first_date.DateTime.ToString("dd-MM-yyyy");
            string l = last_date.DateTime.ToString("dd-MM-yyyy");
            string a = "";
            if (choices == 1)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where fatora_id={Convert.ToInt32(id_barcode_tb.Text)}";
            }
            if (choices == 2)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where sell_date between convert(date,'{f}',105) and convert(date,'{l}',105)";
            }
            if (choices == 3)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where username=N'{username_cb.Text}'";
            }
            if (choices == 4)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where customer_name=N'{customer_name_cb.Text}'";
            }
            if (choices == 5)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where bill_type=N'{fatora_type_cb.Text}'";
            }
            if (choices == 6)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where sell_date between convert(date,'{f}',105) and convert(date,'{l}',105) and username=N'{username_cb.Text}'";
            }
            if (choices == 7)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where sell_date between convert(date,'{f}',105) and convert(date,'{l}',105) and username=N'{username_cb.Text}' and customer_name=N'{customer_name_cb.Text}'";
            }
            if (choices == 8)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where sell_date between convert(date,'{f}',105) and convert(date,'{l}',105) and username=N'{username_cb.Text}' and customer_name=N'{customer_name_cb.Text}' and bill_type=N'{fatora_type_cb.Text}'";
            }
            if (choices == 9)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where customer_name=N'{customer_name_cb.Text}' and username=N'{username_cb.Text}'";
            }
            if (choices == 10)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where bill_type=N'{fatora_type_cb.Text}' and username=N'{username_cb.Text}'";
            }
            if (choices == 11)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where bill_type=N'{fatora_type_cb.Text}' and username=N'{username_cb.Text}' and customer_name=N'{customer_name_cb.Text}'";
            }
            if (choices == 12)
            {
                a = $@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'   
  FROM [sales_head_table] where bill_type=N'{fatora_type_cb.Text}' and customer_name=N'{customer_name_cb.Text}'";
            }
            return a;
        }
        private void id_barcode_radio_CheckedChanged(object sender, EventArgs e)
        {
            if (id_barcode_radio.Checked)
            {
                date_cbx.Checked = customer_cbx.Checked = username_cbx.Checked = fatora_type_cbx.Checked = false;
            }
        }

        private void date_cbx_CheckedChanged(object sender, EventArgs e)
        {
            uncheck_radio();
        }

        private void show_report_btn_Click(object sender, EventArgs e)
        {
            if (date_cbx.Checked == false && id_barcode_radio.Checked == false && username_cbx.Checked == false && customer_cbx.Checked == false && fatora_type_cbx.Checked == false)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء تحديد خيار للبحث");
                return;
            }
            if (id_barcode_radio.Checked)
            {
                if (texts_class.is_null(id_barcode_tb.Text))
                {
                    OmarNotifications.Alert.ShowInformation("يرجى كتابة الرقم أو الباركود");
                    return;
                }
                else
                {
                    int invoice_id = 0;
                    if (convert_int32(invoice_id, id_barcode_tb.Text) == false)
                    {
                        OmarNotifications.Alert.ShowInformation("الرقم المدخل غير صحيح");
                        return;
                    }
                }
            }
            DataTable table = connection_class.select(query(choices()));
            if (table.Rows.Count == 0)
            {
                notifications_class.grid_message();
                gridControl2.DataSource = null;
                return;
            }
            my_grid_view_class.set_datasource(gridControl2, gridView2, table);
            my_grid_view_class.set_summary(gridView2, "القيمة الإجمالية");
            my_grid_view_class.set_summary(gridView2, "القيمة المدفوعة");
            my_grid_view_class.set_summary(gridView2, "القيمة المتبقية");
        }
        public static string from_date, to_date;
        private void print_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            //TODO
            //repost_pos.sales_report.print(my_grid_view_class.gridview_to_data_table(gridView2), null);

        }

        private void ar_sell_report_form_Load(object sender, EventArgs e)
        {
            DataTable table = connection_class.select(@"SELECT [fatora_id] as 'رقم الفاتورة'
      ,[bill_type] as 'نوع الفاتورة'
      ,convert(varchar,[sell_date],105)+' '+[sell_time] as 'تاريخ ووقت البيع'
      ,(select customer_name from customers_table where customers_table.customer_id=sales_head_table.customer_id) as 'العميل'
      ,[total_amount] as 'القيمة الإجمالية'
	  ,[paied_money] as 'القيمة المدفوعة'
      ,[net_amount] as 'القيمة المتبقية'
	  ,[pay_method] as 'طريقة الدفع'
      ,(select username from users_table where users_table.user_id=userID) as 'المستخدم'    
  FROM [sales_head_table] where 1 = 2");
            my_grid_view_class.set_datasource(gridControl2, gridView2, table);
            if (fill_cb_worker.IsBusy == false)
                fill_cb_worker.RunWorkerAsync();
        }
        DataTable customers_table, users_table, bill_type_table;
        private void fill_cb_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            customers_table = connection_class.select("select distinct customer_name as 'العميل' from customers_table");
            users_table = connection_class.select("select distinct username as 'المستخدم' from users_table");
            bill_type_table = connection_class.select("select distinct bill_type as 'نوع الفاتورة' from sales_head_table");
        }

        private void fill_cb_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            classes.lookup_edit_class.fill_lookup(customers_table, customer_name_cb, "العميل");
            classes.lookup_edit_class.fill_lookup(users_table, username_cb, "المستخدم");
        }

        private void word_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            //TODO
            //  repost_pos.sales_report.to_word(my_grid_view_class.gridview_to_data_table(gridView2));
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            //TODO
            //repost_pos.sales_report.to_excel(my_grid_view_class.gridview_to_data_table(gridView2));
        }

        private void pdf_btn_Click(object sender, EventArgs e)
        {
            if (gridView2.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            //TODO
            //repost_pos.sales_report.to_pdf(my_grid_view_class.gridview_to_data_table(gridView2));
        }
        public static int fatora_id;

    }
}