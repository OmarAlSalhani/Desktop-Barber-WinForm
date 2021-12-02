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
using System.Data.SqlClient;
using barber_app.classes;
using System.IO;
using barber_app.settings_files;

namespace barber_app.customers_forms
{
    public partial class ar_customers_form : DevExpress.XtraEditors.XtraForm
    {
        public ar_customers_form()
        {
            InitializeComponent();
            my_grid_view_class.set_font_and_hover_effect(main_gridview);
            my_grid_view_class.show_empty_message2(main_gridview);
        }
        public static bool came_from_logs = false;
        // check if all required data filled
        private bool CheckIfAllGood()
        {
            if (texts_class.is_null(name.Text.Trim()))
            {
                OmarNotifications.Alert.ShowInformation("أدخل إسم العميل");
                return false;
            }
            if (!validate_class.is_text_less_then_300_char(name.Text.Trim()))
            {
                return false;
            }
            return true;
        }
        // add data to database
        private void AddData()
        {
            if (CheckIfAllGood())
            {
                try
                {
                    double aol_moda = 0;
                    bool isDouble = Double.TryParse(aol_moda_text.Text, out aol_moda);
                    if (isDouble)
                    {
                        aol_moda = Math.Round(Convert.ToDouble(aol_moda_text.Text), 2);
                    }
                    DataTable table = connection_class.select("select isnull(max(customer_id)+1,1) from customers_table");
                    int id = Convert.ToInt32(table.Rows[0][0]);
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection_class.connection();
                    command.CommandText = "insert_into_customer_table";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@customer_id", id);
                    command.Parameters.AddWithValue("@customer_name", name.Text.Trim().Trim());
                    command.Parameters.AddWithValue("@customer_phone", (mobile.Text.Trim().Length == 0) ? "" : mobile.Text);
                    command.Parameters.AddWithValue("@customer_address", (address.Text.Trim().Length == 0) ? "" : address.Text);
                    command.Parameters.AddWithValue("@personal_pic", convert_class.image_to_byte(customer_pic.Image));
                    command.Parameters.AddWithValue("@rsed_aol_moda", aol_moda);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        logs_class.log_add($"إضافة العميل ذو الرقم {id}", id, "العملاء");
                        new_btn.PerformClick();
                    }
                    classes.notifications_class.success_message(); ;

                }
                catch (SqlException Ex)
                {
                    if (Ex.Message.Contains("unique"))
                    {
                        classes.notifications_class.my_messageBox("يوجد زبون مسجل بنفس الإسم");
                    }
                    else
                    {
                        classes.notifications_class.my_messageBox(Ex.Message);
                    }
                }
            }
        }
        // updata data to database
        private void UpdateData()
        {
            if (CheckIfAllGood())
            {
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection_class.connection();
                    command.CommandText = @"update customers_table set customer_name=@customer_name,customer_phone=@customer_phone,customer_address=@customer_address,personal_pic=@personal_pic,rsed_aol_moda=@rsed_aol_moda where customer_id=@customer_id";
                    command.Parameters.AddWithValue("@customer_id", Convert.ToInt32(id_tb.Text));
                    command.Parameters.AddWithValue("@customer_name", name.Text.Trim());
                    command.Parameters.AddWithValue("@customer_phone", texts_class.is_null(mobile.Text.Trim()) ? "" : mobile.Text.Trim());
                    command.Parameters.AddWithValue("@customer_address", texts_class.is_null(address.Text.Trim()) ? "" : address.Text.Trim());
                    command.Parameters.AddWithValue("@personal_pic", convert_class.image_to_byte(customer_pic.Image));
                    command.Parameters.AddWithValue("@rsed_aol_moda", (aol_moda_text.Text.Trim().Length == 0) ? 0 : Math.Round(Convert.ToDouble(aol_moda_text.Text), 2));
                    if (command.ExecuteNonQuery() == 1)
                    {
                        update_customer_in_all_tables(name.Text.Trim(), old_name);
                        logs_class.log_add($"تعديل العميل ذو الرقم {id_tb.Text}", 0, "العملاء");
                        new_btn.PerformClick();
                        classes.notifications_class.success_message();
                    }
                }
                catch (Exception Ex)
                {
                    if (Ex.Message.Contains("key row"))
                    {
                        OmarNotifications.Alert.ShowInformation("إسم العميل موجود مسبقاً");
                        return;
                    }
                    else
                        classes.notifications_class.my_messageBox(Ex.Message);
                }
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            AddData();

        }

        private void customer_pic_upload_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                customer_pic.Image = Image.FromFile(openFileDialog1.FileName);
            else return;
        }

        private void earse_customer_pic_Click(object sender, EventArgs e)
        {
            customer_pic.Image = Properties.Resources.profile;
        }

        private void new_btn_Click(object sender, EventArgs e)
        {

            run_worker_class.run(backgroundWorker1);
        }
        void clear()
        {
            name.Text =
                address.Text =
                mobile.Text =
                aol_moda_text.Text = string.Empty;
            id_tb.Text = get_id().ToString();
            customer_pic.Image = Properties.Resources.profile;

        }
        int get_id()
        {
            DataTable table = connection_class.select("select isnull(max(customer_id)+1,1) from customers_table");
            return Convert.ToInt32(table.Rows[0][0]);
        }
        void update_customer_in_all_tables(string new_name, string old_name)
        {
            connection_class.command($"update agle_table set customer_name=N'{new_name}' where customer_name=N'{old_name}'");
            connection_class.command($"update sell_head_table set customer_name=N'{new_name}' where customer_name=N'{old_name}'");
            connection_class.command($"update customers_paied_money_table set customer_name=N'{new_name}' where customer_name=N'{old_name}'");
            connection_class.command($"update customer_kshf_table set customer_name=N'{new_name}' where customer_name=N'{old_name}'");
            connection_class.command($"update archived_sell_head_table set customer_name=N'{new_name}' where customer_name=N'{old_name}'");
        }
        void delete_customer_in_all_tables(string name)
        {
            connection_class.command($"delete from agle_table where customer_name=N'{name}'");
            connection_class.command($"delete from sell_head_table where customer_name=N'{name}'");
            connection_class.command($"delete from customers_paied_money_table where customer_name=N'{name}'");
            connection_class.command($"delete from customer_kshf_table where customer_name=N'{name}' ");
            connection_class.command($"delete from archived_sell_head_table where customer_name=N'{name}'");
        }
        private void update_btn_Click(object sender, EventArgs e)
        {

            if (main_gridview.SelectedRowsCount > 1)
            {
                OmarNotifications.Alert.ShowInformation("يجب تحديد عميل واحد فقط");
                return;
            }

            DialogResult dr = notifications_class.my_messageBox("هل تريد تأكيد التعديل ؟", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                UpdateData();
        }
        string old_name;
        void navigate_btn(string query)
        {
            DataTable table = connection_class.select(query);
            if (table.Rows.Count == 0)
            {
                DataTable table1 = connection_class.select("select * from customers_table");
                if (table1.Rows.Count == 0)
                {
                    OmarNotifications.Alert.ShowInformation("لا يوجد بيانات");
                    return;
                }
                else
                {
                    if (is_next_clicked)
                        first_btn.PerformClick();
                    else
                        last_btn.PerformClick();
                }
            }
            else
            {
                int id = Convert.ToInt32(table.Rows[0]["customer_id"]);
                id_tb.Text = id.ToString();
                name.Text = table.Rows[0]["customer_name"].ToString();
                mobile.Text = table.Rows[0]["customer_phone"].ToString();
                address.Text = table.Rows[0]["customer_address"].ToString();
                aol_moda_text.Text = table.Rows[0]["rsed_aol_moda"].ToString();
                byte[] photo_aray = (byte[])table.Rows[0]["personal_pic"];
                MemoryStream ms = new MemoryStream(photo_aray);
                customer_pic.Image = Image.FromStream(ms);
                old_name = name.Text.Trim();
            }
            delete_btn.Enabled = true;
            update_btn.Enabled = true;
            save_btn.Enabled = false;
            aol_moda_text.Enabled = false;
        }

        private void first_btn_Click(object sender, EventArgs e)
        {
            navigate_btn($"select * from customers_table where customer_id=(select min(customer_id) from customers_table)");

        }
        bool is_next_clicked = false;

        private void next_btn_Click(object sender, EventArgs e)
        {
            navigate_btn(navigation_class.next_navigatoin("customers_table", "customer_id", id_tb.Text));
            is_next_clicked = true;
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            navigate_btn(navigation_class.prev_navigation("customers_table", "customer_id", id_tb.Text));
            is_next_clicked = false;
        }

        private void last_btn_Click(object sender, EventArgs e)
        {
            navigate_btn($"select * from customers_table where customer_id=(select max(customer_id) from customers_table)");

        }

        private void ar_customers_form_Load(object sender, EventArgs e)
        {
            run_worker_class.run(backgroundWorker1);

        }

        private void delete_btn_Click(object sender, EventArgs e)
        {

            if (main_gridview.SelectedRowsCount == 0)
            {
                notifications_class.select_data_message();
            }
            if (main_gridview.SelectedRowsCount > 0)
            {
                foreach (int i in main_gridview.GetSelectedRows())
                {
                    string the_name = main_gridview.GetRowCellValue(i, main_gridview.Columns[1].FieldName).ToString();
                    if (!validate_class.is_customer_agel_clean(the_name))
                    {
                        return;
                    }
                }
                DialogResult dr = classes.notifications_class.my_messageBox("هل تريد حذف العملاء المحددين ؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    foreach (int i in main_gridview.GetSelectedRows())
                    {
                        delete_customer_in_all_tables(name.Text.Trim());
                        string the_name = main_gridview.GetRowCellValue(i, main_gridview.Columns[1].FieldName).ToString();
                        connection_class.command($"delete from customers_table where customer_id={Convert.ToInt32(main_gridview.GetRowCellValue(i, main_gridview.Columns[0].FieldName))}");
                        logs_class.log_add($"حذف العميل ذو الرقم {id_tb.Text}", 0, "العملاء");
                    }
                    new_btn.PerformClick();
                    notifications_class.success_message();
                }

            }
        }
        private void main_gridview_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (main_gridview.RowCount != 0)
            {
                navigate_btn($"select * from customers_table where customer_id={Convert.ToInt32(main_gridview.GetFocusedRowCellValue(main_gridview.Columns[0]))}");
                delete_btn.Enabled = true;
                update_btn.Enabled = true;
                save_btn.Enabled = false;
            }
            if (main_gridview.SelectedRowsCount == 0)
            {
                delete_btn.Enabled = false;
                update_btn.Enabled = false;
                save_btn.Enabled = true;
                new_btn.PerformClick();
            }
        }
        DataTable get_data_table;

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            get_data_table = connection_class.select("select customer_id as 'الرمز' , customer_name as 'الإسم',customer_phone as 'الهاتف',customer_address as 'العنوان',rsed_aol_moda as 'رصيد أول المدة' from customers_table");
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            my_grid_view_class.set_datasource(quantites_grid_control, main_gridview, get_data_table);
            if(get_data_table.Rows.Count!=0)
            my_grid_view_class.set_summary(main_gridview, "رصيد أول المدة");
            main_gridview.ClearSelection();
            update_btn.Enabled = false;
            delete_btn.Enabled = false;
            save_btn.Enabled = true;
            aol_moda_text.Enabled = true;
            clear();

        }
        private void print_btn_Click(object sender, EventArgs e)
        {
            if (main_gridview.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            //TODO
            // repost_pos.manage_customers.print(my_grid_view_class.gridview_to_data_table(main_gridview), null);
        }

        private void word_btn_Click(object sender, EventArgs e)
        {
            //TODO
            // repost_pos.manage_customers.to_word(my_grid_view_class.gridview_to_data_table(main_gridview));
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            //TODO
            //  repost_pos.manage_customers.to_excel(my_grid_view_class.gridview_to_data_table(main_gridview));
        }

        private void pdf_btn_Click(object sender, EventArgs e)
        {
            //TODO
            //repost_pos.manage_customers.to_pdf(my_grid_view_class.gridview_to_data_table(main_gridview));
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}