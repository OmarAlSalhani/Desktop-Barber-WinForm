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
    public partial class category_form : DevExpress.XtraEditors.XtraForm
    {
        public category_form()
        {
            InitializeComponent();
            my_grid_view_class.set_find_panel_font2(main_gridview, main_gridcontrol, false, false);
            my_grid_view_class.show_empty_message2(main_gridview);
            my_grid_view_class.set_font_and_hover_effect(main_gridview);
            id_tb.Text = IdFromDatabase();
        }
        // get product id


        private void print_btn_Click(object sender, EventArgs e)
        {
            if (main_gridview.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            repost_pos.manage_products.print (my_grid_view_class.gridview_to_data_table (main_gridview), null);
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

        #region New
        DataTable GetDataTable;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            GetDataTable = connection_class.select($"select id as 'الرقم' , category_name as 'أسم التصنيف' from categories_table");
        }
        private void category_form_Load(object sender, EventArgs e)
        {
            run_worker_class.run(backgroundWorker1);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            id_tb.Text = IdFromDatabase();
            my_grid_view_class.set_datasource(main_gridcontrol, main_gridview, GetDataTable);
        }
        private string IdFromDatabase()
        {
            DataTable dataTable = connection_class.select("Select ifnull(max(id)+1,1) from categories_table");
            return dataTable.Rows[0][0].ToString();
        }
        void clearAllAndRunWorker()
        {
            category_name_tb.Text = "";
            save_btn.Enabled = true;
            update_btn.Enabled = delete_btn.Enabled = false;
            run_worker_class.run(backgroundWorker1);
        }
        bool isDataOk()
        {
            if (id_tb.Text.Trim().Length == 0)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء الضغط على زر جديد");
                return false;
            }
            if (category_name_tb.Text.Trim().Length == 0)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء أدخال أسم التصنيف");
                return false;
            }

            return true;
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            if (isDataOk())
            {
                int id = Convert.ToInt32(id_tb.Text);
                string category = category_name_tb.Text;
                connection_class.command($"insert into categories_table values ({id},'{category}')");
                notifications_class.success_message();
                clearAllAndRunWorker();
            }

        }

        private void main_gridview_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            navigation($"select * from categories_table where id={Convert.ToInt32(main_gridview.GetFocusedRowCellValue(main_gridview.Columns[0].FieldName))}");
        }
        void navigation(string query)
        {
            DataTable table = connection_class.select(query);
            if (table.Rows.Count != 0)
            {
                id_tb.Text = table.Rows[0]["id"].ToString();
                category_name_tb.Text = table.Rows[0]["category_name"].ToString();
                save_btn.Enabled = false; update_btn.Enabled = delete_btn.Enabled = true;
            }
            else
            {
                DataTable table1 = connection_class.select("select * from categories_table");
                if (table1.Rows.Count == 0)
                {
                    OmarNotifications.Alert.ShowInformation("لا يوجد بيانات");
                    return;
                }
            }
        }

        #endregion

        private void new_btn_Click(object sender, EventArgs e)
        {
            clearAllAndRunWorker();
        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (notifications_class.my_messageBoxRightYesNo("هل أنت متأكد ؟") == DialogResult.Yes)
            {
                int id = Convert.ToInt32(id_tb.Text);
                connection_class.command($"update categories_table set category_name='{category_name_tb.Text}' where id={id}");
                notifications_class.success_message();
                clearAllAndRunWorker();
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            string names = "";
            foreach (int i in main_gridview.GetSelectedRows())
            {
                int id = Convert.ToInt32(main_gridview.GetRowCellValue(i, main_gridview.Columns[0]));
                DataTable getData = connection_class.select($"select service_name from services_table where main_category_id={id}");
                if (getData.Rows.Count != 0)
                {
                    names += getData.Rows[i][0].ToString() + "\n";
                }
            }
            if (names.Trim().Length != 0)
            {
                notifications_class.my_messageBox("لا يمكن حذف التصنيفات المحددة لأرتباطها بالخدمات الآتية :\n" + names, MessageBoxIcon.Information);
            }
            else
            {
                if (notifications_class.my_messageBoxRightYesNo("هل أنت متأكد ؟") == DialogResult.Yes)
                {
                    foreach (int i in main_gridview.GetSelectedRows())
                    {
                        int id = Convert.ToInt32(main_gridview.GetRowCellValue(i, main_gridview.Columns[0]));
                        connection_class.command($"delete from categories_table where id={id}");
                    }
                    notifications_class.success_message();
                    clearAllAndRunWorker();
                }
            }
        }
    }
}

