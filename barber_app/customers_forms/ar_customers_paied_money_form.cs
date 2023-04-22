﻿using DevExpress.XtraGrid;
using barber_app.classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barber_app.customers_forms
{
    public partial class ar_customers_paied_money_form : DevExpress.XtraEditors.XtraForm
    {
        public ar_customers_paied_money_form()
        {
            InitializeComponent(); 
            first_date.DateTime = last_date.DateTime = DateTime.Now;

            my_grid_view_class.set_find_panel_font2(gridView1, gridControl1,true,true);
            my_grid_view_class.set_font_and_hover_effect(gridView1);
            my_grid_view_class.show_empty_message2(gridView1);
        }

        private void employees_cb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

        }

        DataTable customer_table, users_table;
        public static string date_time, the_name, the_money, the_fatora_numbers, from_date, to_date;

        private void ar_customers_paied_money_form_Load(object sender, EventArgs e)
        {
            DataTable table = connection_class.select("select id as 'الرمز',fatora_id as 'رقم الفاتورة',(select customer_name from customers_table where customers_table.customer_id=customers_paied_money_table.customer_id ) as 'العميل',value as 'المبلغ المقبوض',the_date as 'تاريخ القبض',(select username from users_table where users_table.user_id=customers_paied_money_table.userID) as 'المستخدم' from customers_paied_money_table where 1 = 2 ");
            my_grid_view_class.set_datasource(gridControl1, gridView1, table);
            if (customer_worker.IsBusy == false)
            {
                customer_worker.RunWorkerAsync();
            }
        }

        public static double total_paied, total_stay, total;

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            if (gridView1.RowCount != 0)
            {
                total_paied = my_grid_view_class.column_sum(gridView1, "المبلغ المقبوض");
                from_date = first_date.DateTime.ToString("dd-MM-yyyy");
                to_date = last_date.DateTime.ToString("dd-MM-yyyy");
                repost_pos.customers_paied_money_report.print(classes.my_grid_view_class.gridview_to_data_table(gridView1), null);
            }
        }


        private void gridView1_CustomDrawEmptyForeground(object sender, DevExpress.XtraGrid.Views.Base.CustomDrawEventArgs e)
        {

        }

        private void word_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            total_paied = my_grid_view_class.column_sum(gridView1, "المبلغ المقبوض");
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            repost_pos.customers_paied_money_report.to_word(classes.my_grid_view_class.gridview_to_data_table(gridView1));
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if(gridView1.SelectedRowsCount==0)
            {
                notifications_class.select_data_message();
                return;
            }
            if (gridView1.SelectedRowsCount != 0)
            {
                DialogResult dr = notifications_class.my_messageBox("هل تريد تأكيد الحذف ؟", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    foreach (int i in gridView1.GetSelectedRows())
                    {
                        int ID = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns[0]));
                        connection_class.command($"delete from customers_paied_money_table where id={ID}");
                        logs_class.log_add($"حذف بيانات مقبوضات العملاء ذات الرقم : {ID}", ID, "العملاء");
                    }
                    classes.notifications_class.success_message();
                    show_report_btn.PerformClick();
                }
            }
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            total_paied = my_grid_view_class.column_sum(gridView1, "المبلغ المقبوض");
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
            repost_pos.customers_paied_money_report.to_excel(classes.my_grid_view_class.gridview_to_data_table(gridView1));
        }

        private void pdf_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            total_paied = my_grid_view_class.column_sum(gridView1, "المبلغ المقبوض");
            from_date = first_date.DateTime.ToString("dd-MM-yyyy");
            to_date = last_date.DateTime.ToString("dd-MM-yyyy");
           repost_pos.customers_paied_money_report.to_pdf(classes.my_grid_view_class.gridview_to_data_table(gridView1));
        }

        private void customer_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            customer_table = connection_class.select("select distinct customer_name from customers_table");
            users_table = connection_class.select("select distinct username from users_table");
        }

        private void customer_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            classes.lookup_edit_class.fill_lookup(customer_table, customer_cb, "customer_name");
            classes.lookup_edit_class.fill_lookup(users_table, username_cb, "username");
        }
        DataTable table;
        int query_status()
        {
            int query_status = 0;
            if (customer_checkbox.Checked)
                query_status = 1;
            if (date_checkbox.Checked)
                query_status = 2;
            if (username_checkbox.Checked)
                query_status = 3;
            if (date_checkbox.Checked && customer_checkbox.Checked)
                query_status = 4;
            if (date_checkbox.Checked && username_checkbox.Checked)
                query_status = 5;
            if (customer_checkbox.Checked && username_checkbox.Checked)
                query_status = 6;
            if (date_checkbox.Checked && username_checkbox.Checked && customer_checkbox.Checked)
                query_status = 7;
            return query_status;
        }
        void do_search(int query_status)
        {
            DataTable CustomerIDTable = connection_class.select($"select customer_id from customers_table where customer_name='{customer_cb.Text}'");
            int customerID = 0;
            if (CustomerIDTable.Rows.Count != 0)
            {
                customerID = Convert.ToInt32(CustomerIDTable.Rows[0][0]);
            }
            DataTable UserIDTable = connection_class.select($"select user_id from users_table where username='{username_cb.Text}'");
            int userID = 0;
            if (UserIDTable.Rows.Count != 0)
            {
                userID = Convert.ToInt32(UserIDTable.Rows[0][0]);
            }
            string f = first_date.DateTime.ToString("dd-MM-yyyy");
            string l = last_date.DateTime.ToString("dd-MM-yyyy");
            if (query_status == 1)
            {
                table = connection_class.select($"select id as 'الرمز',fatora_id as 'رقم الفاتورة',(select customer_name from customers_table where customers_table.customer_id=customers_paied_money_table.customer_id ) as 'العميل',value as 'المبلغ المقبوض',the_date as 'تاريخ القبض',(select username from users_table where users_table.user_id=customers_paied_money_table.userID) as 'المستخدم' from customers_paied_money_table where customer_id={customerID}");
            }
            if (query_status == 2)
            {
                table = connection_class.select($"select id as 'الرمز',fatora_id as 'رقم الفاتورة',(select customer_name from customers_table where customers_table.customer_id=customers_paied_money_table.customer_id ) as 'العميل',value as 'المبلغ المقبوض',the_date as 'تاريخ القبض',(select username from users_table where users_table.user_id=customers_paied_money_table.userID) as 'المستخدم' from customers_paied_money_table where the_date between '{f}' and '{l}'");
            }
            if (query_status == 3)
            {
                table = connection_class.select($"select id as 'الرمز',fatora_id as 'رقم الفاتورة',(select customer_name from customers_table where customers_table.customer_id=customers_paied_money_table.customer_id ) as 'العميل',value as 'المبلغ المقبوض',the_date as 'تاريخ القبض',(select username from users_table where users_table.user_id=customers_paied_money_table.userID) as 'المستخدم' from customers_paied_money_table where user_id={userID}");
            }
            if (query_status == 4)
            {
                table = connection_class.select($"select id as 'الرمز',fatora_id as 'رقم الفاتورة',(select customer_name from customers_table where customers_table.customer_id=customers_paied_money_table.customer_id ) as 'العميل',value as 'المبلغ المقبوض',the_date as 'تاريخ القبض',(select username from users_table where users_table.user_id=customers_paied_money_table.userID) as 'المستخدم' from customers_paied_money_table where customer_id={customerID} and the_date between '{f}' and '{l}'");
            }
            if (query_status == 5)
            {
                table = connection_class.select($"select id as 'الرمز',fatora_id as 'رقم الفاتورة',(select customer_name from customers_table where customers_table.customer_id=customers_paied_money_table.customer_id ) as 'العميل',value as 'المبلغ المقبوض',the_date as 'تاريخ القبض',(select username from users_table where users_table.user_id=customers_paied_money_table.userID) as 'المستخدم' from customers_paied_money_table where user_id={userID} and the_date between '{f}' and '{l}'");

            }
            if (query_status == 6)
            {
                table = connection_class.select($"select id as 'الرمز',fatora_id as 'رقم الفاتورة',(select customer_name from customers_table where customers_table.customer_id=customers_paied_money_table.customer_id ) as 'العميل',value as 'المبلغ المقبوض',the_date as 'تاريخ القبض',(select username from users_table where users_table.user_id=customers_paied_money_table.userID) as 'المستخدم' from customers_paied_money_table where user_id={userID} and customer_id={customerID}");

            }
            if (query_status == 7)
            {
                table = connection_class.select($"select id as 'الرمز',fatora_id as 'رقم الفاتورة',(select customer_name from customers_table where customers_table.customer_id=customers_paied_money_table.customer_id ) as 'العميل',value as 'المبلغ المقبوض',the_date as 'تاريخ القبض',(select username from users_table where users_table.user_id=customers_paied_money_table.userID) as 'المستخدم' from customers_paied_money_table where customer_id={customerID} and user_id={userID} and the_date between '{f}' and '{l}'");
            }
            if (table.Rows.Count == 0)
            {
                notifications_class.grid_message();
                gridControl1.DataSource = null;
                return;
            }
            my_grid_view_class.set_datasource(gridControl1, gridView1, table);
            my_grid_view_class.set_summary(gridView1, "المبلغ المقبوض");
        }

        private void show_report_btn_Click(object sender, EventArgs e)
        {
            if (customer_checkbox.Checked == false && date_checkbox.Checked == false && username_checkbox.Checked == false)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء تحديد خيار للبحث");
                return;
            }
            do_search(query_status());
        }
    }
}
