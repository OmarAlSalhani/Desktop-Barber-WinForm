using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using barber_app.classes;
using barber_app.settings_files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace barber_app.products_forms
{
    public partial class ar_products_form : DevExpress.XtraEditors.XtraForm
    {
        public ar_products_form()
        {
            InitializeComponent();
            my_grid_view_class.set_find_panel_font2(main_gridview, main_gridcontrol, false, false);
            my_grid_view_class.show_empty_message2(main_gridview);
            my_grid_view_class.set_font_and_hover_effect(main_gridview);

        }
        // get product id
        private string IdFromDatabase()
        {
            DataTable dataTable = connection_class.select("Select ifnull(max(id)+1,1) from services_table");
            return dataTable.Rows[0][0].ToString();
        }
        void navigation(string query)
        {
            DataTable table = connection_class.select(query);
            if (table.Rows.Count != 0)
            {
                new_btn.PerformClick();
                id_tb.Text = table.Rows[0]["id"].ToString();
                main_category_cb.Text = table.Rows[0]["category_name"].ToString();
                service_name_tb.Text = table.Rows[0]["service_name"].ToString();
                price_before_tax_tb.Text = table.Rows[0]["price_before_tax"].ToString();
                price_with_tax_tb.Text = (table.Rows[0]["price_with_tax"]).ToString();
                save_btn.Enabled = false; update_btn.Enabled = delete_btn.Enabled = true;
            }
            else
            {
                DataTable table1 = connection_class.select("select * from services_table");
                if (table1.Rows.Count == 0)
                {
                    OmarNotifications.Alert.ShowInformation("لا يوجد بيانات");
                    return;
                }
            }
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (main_gridview.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            repost_pos.manage_products.print (my_grid_view_class.gridview_to_data_table (main_gridview), null);
        }

        private void main_gridview_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            navigation($"select id,(select category_name from categories_table where categories_table.id=main_category_id) as 'category_name',service_name ,price_before_tax,((price_before_tax*{(main_settings.Default.tax_value)})/100)+price_before_tax as 'price_with_tax' from services_table where id={Convert.ToInt32(main_gridview.GetFocusedRowCellValue(main_gridview.Columns[0].FieldName))}");
        }
        private void word_btn_Click(object sender, EventArgs e)
        {
             repost_pos.manage_products.to_word (my_grid_view_class.gridview_to_data_table (main_gridview));
        }

        private void excel_btn_Click_1(object sender, EventArgs e)
        {
            repost_pos.manage_products.to_excel (my_grid_view_class.gridview_to_data_table (main_gridview));
        }

        private void pdf_btn_Click(object sender, EventArgs e)
        {
             repost_pos.manage_products.to_pdf (my_grid_view_class.gridview_to_data_table (main_gridview));
        }
        void select_all_for_edit_text(object sender, EventArgs e)
        {
            ButtonEdit buttonEdit = sender as ButtonEdit;
            buttonEdit.SelectAll();
        }


        bool is_next_clicked = false;




        void clearAllAndRunWorker()
        {
            id_tb.Text = IdFromDatabase();
            service_name_tb.Text = "";
            price_before_tax_tb.Text = "0";
            run_worker_class.run(backgroundWorker1);
        }
        bool isDataOk()
        {
            if (id_tb.Text.Trim().Length == 0)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء الضغط على زر جديد");
                return false;
            }
            if (main_category_cb.SelectedIndex == -1)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء أختيار التصنيف الرئيسي");
                return false;
            }
            if (service_name_tb.Text.Trim().Length == 0)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء أدخال أسم الخدمة");
                return false;
            }
            if (Convert.ToDouble(price_before_tax_tb.Text) == 0)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء أدخال السعر");
                return false;
            }
            return true;
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            if (isDataOk())
            {
                try
                {

                    int id = Convert.ToInt32(id_tb.Text);
                    DataTable table = connection_class.select($"select id from categories_table where category_name='{main_category_cb.Text}'");
                    int category = Convert.ToInt32(table.Rows[0][0]);
                    string service = service_name_tb.Text;
                    double price = Convert.ToDouble(price_before_tax_tb.Text);
                    connection_class.command($"insert into services_table values ({id},{category},'{service}',{price})");
                    notifications_class.success_message();
                    clearAllAndRunWorker();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("with unique index"))
                    {
                        notifications_class.my_messageBox("أسم الخدمة موجود مسبقاً");
                    }
                    else
                    {
                        notifications_class.my_messageBox(ex.Message);
                    }
                }
            }

        }

        private void main_category_cb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                category_form f = new category_form();
                f.ShowDialog();
                run_worker_class.run(categoryWorker);
            }

        }

        DataTable categoryTable;
        private void categoryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            categoryTable = connection_class.select("select category_name from categories_table");
        }

        private void categoryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            comboBox_class.fill_combobox(categoryTable, main_category_cb);
            clearAllAndRunWorker();
        }

        private void ar_products_form_Load(object sender, EventArgs e)
        {
            run_worker_class.run(categoryWorker);
        }

        private void price_before_tax_tb_TextChanged(object sender, EventArgs e)
        {
            double price = Convert.ToDouble(price_before_tax_tb.Text);
            double tax = (price * main_settings.Default.tax_value) / 100;
            price_with_tax_tb.Text = (price + tax).ToString();
        }
        DataTable GetDataTable;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            GetDataTable = connection_class.select($"select id as 'رقم الخدمة',(select category_name from categories_table where categories_table.id=main_category_id) as 'التصنيف الرئيسي',service_name as 'أسم الخدمة',price_before_tax as 'السعر بدون ضريبة',((price_before_tax*{(main_settings.Default.tax_value)})/100)+price_before_tax as 'السعر بعد الضريبة' from services_table");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            my_grid_view_class.set_datasource(main_gridcontrol, main_gridview, GetDataTable);
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (notifications_class.my_messageBoxRightYesNo("هل أنت متأكد ؟") == DialogResult.Yes)
            {
                try
                {
                    connection_class.command($"update services_table set service_name='{service_name_tb.Text}',price_before_tax={Convert.ToDouble(price_before_tax_tb.Text)}, main_category_id=(select id from categories_table where category_name='{main_category_cb.Text}') where id={Convert.ToInt32(id_tb.Text)}");
                    notifications_class.success_message();
                    clearAllAndRunWorker();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("with unique index"))
                    {
                        notifications_class.my_messageBox("أسم الخدمة موجود مسبقاً");
                    }
                    else
                    {
                        notifications_class.my_messageBox(ex.Message);
                    }
                }

            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            foreach (int i in main_gridview.GetSelectedRows())
            {
                int id = Convert.ToInt32(main_gridview.GetRowCellValue(i, main_gridview.Columns[0]));
                string name = main_gridview.GetRowCellValue(i, main_gridview.Columns["أسم الخدمة"]).ToString();
                DataTable getData = connection_class.select($"select service_id from sales_body_table where service_id={id}");
                if (getData.Rows.Count != 0)
                {
                    notifications_class.my_messageBox($"لا يمكن حذف الخدمة {name} لإرتباطها بفواتير مبيعات", MessageBoxIcon.Information);
                    return;
                }
            }
            if (notifications_class.my_messageBoxRightYesNo("هل أنت متأكد ؟") == DialogResult.Yes)
            {
                foreach (int i in main_gridview.GetSelectedRows())
                {
                    int id = Convert.ToInt32(main_gridview.GetRowCellValue(i, main_gridview.Columns[0]));
                    connection_class.command($"delete from services_table where id={id}");
                }
                notifications_class.success_message();
                clearAllAndRunWorker();
            }
        }
    }
}

