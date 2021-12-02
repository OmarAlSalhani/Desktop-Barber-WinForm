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
using DevExpress.Utils.Svg;
using barber_app.classes;
using System.IO;
using DevExpress.XtraGrid.Columns;

namespace barber_app.users_forms
{
    public partial class ar_users_form : DevExpress.XtraEditors.XtraForm
    {
        public ar_users_form()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            if ((System.Windows.SystemParameters.PrimaryScreenWidth == 1366 || System.Windows.SystemParameters.PrimaryScreenWidth == 1360) && System.Windows.SystemParameters.PrimaryScreenHeight >= 720)
            {
                this.Height = this.Height - 100;
                this.Width = this.Width - 100;
                tableLayoutPanel2.Height = tableLayoutPanel2.Height - 20;
                label1.Font = new Font("cairo", 12, FontStyle.Bold);
                groupControl2.AppearanceCaption.Font = new Font("cairo", 9, FontStyle.Bold);
                groupControl9.AppearanceCaption.Font = new Font("cairo", 9, FontStyle.Bold);
                groupControl17.AppearanceCaption.Font = new Font("cairo", 9, FontStyle.Bold);
            }
            my_grid_view_class.set_find_panel_font2(gridView1, grid_control, false, true);
            my_grid_view_class.set_font_and_hover_effect(gridView1);
            my_grid_view_class.show_empty_message2(gridView1);
        }

        int get_id()
        {
            DataTable table = connection_class.select("select isnull(max(user_id)+1,1) from users_table");
            return Convert.ToInt32(table.Rows[0][0]);
        }
        private void password_text_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (password_text.Properties.PasswordChar == '*')
                password_text.Properties.PasswordChar = '\0';
            else
                password_text.Properties.PasswordChar = '*';
        }
        // method to add data to database
        void set_permissions()
        {
            connection_class.command($@"INSERT INTO [dbo].[permissions_archive_snds_table]
     VALUES
           (N'{username_text.Text.Trim()}'
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_accounts_taxes_table]
          
     VALUES
           (N'{username_text.Text.Trim()}'
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)");
            connection_class.command($@"INSERT INTO permissions_banks_storages_table
     VALUES
           (N'{username_text.Text.Trim()}'
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_black_box_settings_table]          
     VALUES
           (N'{username_text.Text.Trim()}'
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_buies_sells_table]
        
     VALUES
           (N'{username_text.Text.Trim()}'
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_companies_morden_table]
         
     VALUES
           (N'{username_text.Text.Trim()}'
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_customers_table]
         
     VALUES
           (N'{username_text.Text.Trim()}'
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_employees_users_table]          
     VALUES
           (N'{username_text.Text.Trim()}'
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0,0,0,0)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_products_warehouses_table]           
     VALUES
           (N'{username_text.Text.Trim()}'
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)");
        }
        void add_data()
        {
            Image image = user_pic.Image.Clone() as Image;
            image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            int id = Convert.ToInt32(id_tb.Text);
            SqlCommand command = new SqlCommand("insert into users_table values (@id,@username,@password,@user_image,@storage_name,@bank_name)", connection_class.connection());
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@username", username_text.Text.Trim());
            command.Parameters.AddWithValue("@password", password_text.Text.Trim());
            command.Parameters.AddWithValue("@user_image", convert_class.image_to_byte(image));
            command.Parameters.AddWithValue("@storage_name", storage_name_cb.Text.Trim());
            command.Parameters.AddWithValue("@bank_name", bank_name_cb.Text.Trim() == "إضغط للإختيار" ? "" : bank_name_cb.Text.Trim());
            if (command.ExecuteNonQuery() == 1)
            {
                set_permissions();
                logs_class.log_add($"إضافة المستخدم ذو الرقم {id}", id, "المستخدمين");
                run_worker_class.run(backgroundWorker1);
                notifications_class.success_message();
            }
            else
            {
                OmarNotifications.Alert.ShowInformation("لم تتم إضافة المستخدم");
            }
        }
        // method to update data to database
        // last edit : 24-10-2020
        void update_data()
        {
            try
            {
                Image image = user_pic.Image.Clone() as Image;
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                SqlCommand command = new SqlCommand("update_user", connection_class.connection());
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@user_id", Convert.ToInt32(id_tb.Text));
                command.Parameters.AddWithValue("@user_name", username_text.Text.Trim());
                command.Parameters.AddWithValue("@password", password_text.Text.Trim());
                command.Parameters.AddWithValue("@user_image", convert_class.image_to_byte(image));
                command.Parameters.AddWithValue("@storage_name", storage_name_cb.Text.Trim());
                command.Parameters.AddWithValue("@bank_name", bank_name_cb.Text.Trim() == "إضغط للإختيار" ? "" : bank_name_cb.Text.Trim());
                if (command.ExecuteNonQuery() == 1)
                {
                    SqlCommand command2 = new SqlCommand("update_user_roles", connection_class.connection());
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@username", username_text.Text.Trim());
                    command2.Parameters.AddWithValue("@old_username", old_username);
                    command2.ExecuteNonQuery();
                    SqlCommand command3 = new SqlCommand("update_username_in_tables", connection_class.connection());
                    command3.CommandType = CommandType.StoredProcedure;
                    command3.Parameters.AddWithValue("@new_username", username_text.Text.Trim());
                    command3.Parameters.AddWithValue("@old_username", old_username);
                    command3.ExecuteNonQuery();
                    if (old_username == const_variables_class.username)
                    {
                        settings_files.main_settings.Default.username = username_text.Text.Trim();
                        settings_files.main_settings.Default.storage_name = storage_name_cb.Text.Trim();
                        settings_files.main_settings.Default.bank_name = bank_name_cb.Text.Trim();
                        settings_files.main_settings.Default.Save();
                    }
                    const_variables_class.username = settings_files.main_settings.Default.username;
                    logs_class.log_add($"تعديل بيانات المستخدم ذو الرقم {id_tb.Text}", Convert.ToInt32(id_tb.Text), "المستخدمين");
                    run_worker_class.run(backgroundWorker1);
                    classes.notifications_class.success_message();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("unique"))
                {
                    OmarNotifications.Alert.ShowError("إسم المستخدم موجود مسبقاً");
                    return;
                }
            }
        }
        // method to check if required texts are filled with data
        bool check_if_every_thing_ok()
        {
            if (texts_class.is_null(username_text.Text.Trim()))
            {
                OmarNotifications.Alert.ShowInformation("الرجاء كتابة إسم المستخدم");
                return false;
            }
            if (texts_class.is_null(password_text.Text))
            {
                OmarNotifications.Alert.ShowInformation("الرجاء كتابة كلمة المرور");
                return false;
            }
            if (username_text.Text.Trim().Trim().Length > 20 || password_text.Text.Trim().Length > 20)
            {
                OmarNotifications.Alert.ShowInformation("الحد الأقصى لإسم المستخدم وكلمة المرور 20 محرف");
                return false;
            }
            if (storage_name_cb.SelectedIndex == -1)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء إختيار الخزنة الخاصة بالمستخدم");
                return false;
            }
            if (bank_name_cb.Text.Trim().Length != 0 && bank_name_cb.Text != "إضغط للإختيار" && bank_name_cb.SelectedIndex == -1)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء إختيار البنك الخاص بالمستخدم");
                return false;
            }

            return true;
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (check_if_every_thing_ok())
                {
                    add_data();
                }
            }
            catch (SqlException Ex)
            {
                if (Ex.Message.Contains("Cannot insert duplicate key"))
                {
                    OmarNotifications.Alert.ShowInformation("إسم المستخدم موجود مسبقاً الرجاء تغييره");
                }
                else
                {
                    classes.notifications_class.my_messageBox(Ex.Message);
                }
            }
        }
        private void ar_users_form_Load(object sender, EventArgs e)
        {
            run_worker_class.run(backgroundWorker1);

        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 1)
            {
                OmarNotifications.Alert.ShowInformation("يجب تحديد مستخدم واحد فقط");
                return;
            }
            if (texts_class.is_null(id_tb.Text))
            {
                notifications_class.select_data_message();
                return;
            }
            if (check_if_every_thing_ok())
            {
                DialogResult dr = notifications_class.my_messageBoxRightYesNo("هل تريد تأكيد التعديل ؟");
                if (dr == DialogResult.Yes)
                    update_data();
            }
        }
        DataTable storage_table;
        DataTable bank_table;
        private void storage_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            storage_table = connection_class.select("select storage_name as 'الخزنة' from storage_table");
            bank_table = connection_class.select("select bank_name as 'البنك' from bank_table");
        }

        private void storage_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            classes.comboBox_class.fill_combobox(storage_table, storage_name_cb);
            classes.comboBox_class.fill_combobox(bank_table, bank_name_cb);
            bank_name_cb.SelectedIndex = -1;
            bank_name_cb.Properties.NullText = "إضغط للإختيار";
            bank_name_cb.Properties.NullValuePrompt = "إضغط للإختيار";
            new_btn.PerformClick();
        }

        private void upload_btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                user_pic.Image = Image.FromFile(openFileDialog1.FileName);
                // Image image = user_pic.Image.Clone() as Image;
                // image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                // user_pic.Image.Dispose();
                // user_pic.Image = image;
            }
        }

        private void delete_image_btn_Click(object sender, EventArgs e)
        {
            user_pic.Image = Properties.Resources.profile;
        }

        private void first_btn_Click(object sender, EventArgs e)
        {
            navigate_btn($"select * from users_table where user_id=(select min(user_id) from users_table)");

        }
        void clear_permissions(string username)
        {
            connection_class.command($"delete from permissions_products_warehouses_table where username=N'{username}'");
            connection_class.command($"delete from permissions_employees_users_table where username=N'{username}'");
            connection_class.command($"delete from permissions_customers_table where username=N'{username}'");
            connection_class.command($"delete from permissions_companies_morden_table where username=N'{username}'");
            connection_class.command($"delete from permissions_buies_sells_table where username=N'{username}'");
            connection_class.command($"delete from permissions_black_box_settings_table where username=N'{username}'");
            connection_class.command($"delete from permissions_banks_storages_table where username=N'{username}'");
            connection_class.command($"delete from permissions_archive_snds_table where username=N'{username}'");
            connection_class.command($"delete from permissions_accounts_taxes_table where username=N'{username}'");
        }
        private void delete_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount == 0)
                {
                    notifications_class.select_data_message();
                    return;
                }
                List<int> ids = new List<int>();
                if (gridView1.SelectedRowsCount == 1)
                {
                    foreach (int i in gridView1.GetSelectedRows())
                    {
                        int id = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns[0].FieldName));
                        ids.Add(id);
                        if (ids.Contains(1))
                        {
                            OmarNotifications.Alert.ShowInformation("لا يمكن حذف المستخدم الرئيسي");
                            return;
                        }

                        else
                        {
                            DialogResult dr = notifications_class.my_messageBox("هل تريد حذف المستخدم المحدد ؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                            if (dr == DialogResult.Yes)
                            {
                                string username = gridView1.GetRowCellValue(i, gridView1.Columns[1].FieldName).ToString();
                                if (username == const_variables_class.username)
                                {
                                    OmarNotifications.Alert.ShowInformation("لا يمكن حذف المستخدم المسجل دخوله حالياً");
                                    return;
                                }
                                connection_class.command($"Delete from users_table where user_id={id}");
                                clear_permissions(username);
                                logs_class.log_add($"حذف المستخدم ذو الرقم {id}", id, "المستخدمين");
                                run_worker_class.run(backgroundWorker1);
                                classes.notifications_class.success_message();
                            }
                        }
                    }
                }
                if (gridView1.SelectedRowsCount > 1)
                {
                    DialogResult dr = notifications_class.my_messageBox("هل تريد حذف المستخدمين المحددين ؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dr == DialogResult.Yes)
                    {
                        foreach (int i in gridView1.GetSelectedRows())
                        {
                            int id = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns[0].FieldName));
                            ids.Add(id);
                            if (ids.Contains(1))
                            {
                                OmarNotifications.Alert.ShowInformation("يرجى إلغاء تحديد المستخدم الرئيسي\nوالمحاولة مجدداً");
                                break;
                            }
                            string username = gridView1.GetRowCellValue(i, gridView1.Columns[1].FieldName).ToString();
                            if (username == const_variables_class.username)
                            {
                                OmarNotifications.Alert.ShowInformation("لا يمكن حذف المستخدم المسجل دخوله حالياً");
                                return;
                            }
                            connection_class.command($"Delete from users_table where user_id={id}");
                            clear_permissions(username);
                            logs_class.log_add($"حذف المستخدم ذو الرقم {id}", id, "المستخدمين");
                        }
                        run_worker_class.run(backgroundWorker1);
                        classes.notifications_class.success_message();
                    }
                }

            }
            catch (Exception ex)
            {
                classes.notifications_class.my_messageBox(ex.Message);
            }
        }
        DataTable users_table;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            users_table = connection_class.select(@"Select
user_id as 'رمز المستخدم'
,username as 'إسم المستخدم'
,storage_name as 'الخزنة'
,bank_name as 'البنك'
from users_table");
        }
        public static string username_for_roles = string.Empty;
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            my_grid_view_class.set_datasource(grid_control, gridView1, users_table);
            run_worker_class.run(storage_worker);
            delete_image_btn.PerformClick();
        }

        private void manage_roles_btn_Click(object sender, EventArgs e)
        {
            // if we didn`t select any user
            if (gridView1.SelectedRowsCount == 0)
            {
                OmarNotifications.Alert.ShowInformation("يرجى تحديد المستخدم أولاً");
                return;
            }
            if (gridView1.SelectedRowsCount > 1)
            {
                OmarNotifications.Alert.ShowInformation("يرجى تحديد مستخدم واحد فقط");
                return;
            }
            else
            {
                username_for_roles = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                ar_user_permissions_form form = new ar_user_permissions_form();
                form.top_label.Text = "إدارة صلاحيات المستخدم : " + username_for_roles;
                form.ShowDialog();
            }
        }

        private void print_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            //TODO
          //  repost_pos.users_report.print(my_grid_view_class.gridview_to_data_table(gridView1), null);
        }

        private void word_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            //TODO
            //repost_pos.users_report.to_word(my_grid_view_class.gridview_to_data_table(gridView1));
        }

        private void excel_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            //TODO
            //repost_pos.users_report.to_excel(my_grid_view_class.gridview_to_data_table(gridView1));
        }

        private void pdf_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.RowCount == 0)
            {
                notifications_class.no_data_message();
                return;
            }
            //TODO
            //repost_pos.users_report.to_pdf(my_grid_view_class.gridview_to_data_table(gridView1));
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            gridView1.ClearSelection();
            bank_name_cb.Enabled = storage_name_cb.Enabled = true;
            username_text.Text = string.Empty;
            password_text.Text = string.Empty;
            id_tb.Text = get_id().ToString();
            save_btn.Enabled = true;
            update_btn.Enabled = delete_btn.Enabled = false;
            user_pic.Image = Properties.Resources.profile;
        }
        void navigate_btn(string query)
        {
            DataTable table = connection_class.select(query);
            if (table.Rows.Count == 0)
            {
                DataTable table1 = connection_class.select("select * from users_table");
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
                int id = Convert.ToInt32(table.Rows[0]["user_id"]);
                id_tb.Text = id.ToString();
                username_text.Text = table.Rows[0]["username"].ToString();
                password_text.Text = table.Rows[0]["password"].ToString();
                storage_name_cb.Text = table.Rows[0]["storage_name"].ToString();
                bank_name_cb.Text = table.Rows[0]["bank_name"].ToString();
                byte[] photo_aray = (byte[])table.Rows[0]["user_image"];
                MemoryStream ms = new MemoryStream(photo_aray);
                Image image = Image.FromStream(ms);
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                user_pic.Image = image;
            }
            delete_btn.Enabled = true;
            update_btn.Enabled = true;
            save_btn.Enabled = false;
            storage_name_cb.Enabled = false;
            if (bank_name_cb.SelectedIndex == -1)
            {
                bank_name_cb.Enabled = true;
            }
            else
            {
                bank_name_cb.Enabled = false;
            }
            old_username = username_text.Text.Trim();
        }
        string old_username = "";
        bool is_next_clicked = false;
        private void next_btn_Click(object sender, EventArgs e)
        {
            navigate_btn(navigation_class.next_navigatoin("users_table", "user_id", id_tb.Text));
            is_next_clicked = true;
        }

        private void last_btn_Click(object sender, EventArgs e)
        {
            navigate_btn($"select * from users_table where user_id=(select max(user_id) from users_table)");
            is_next_clicked = false;
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            navigate_btn(navigation_class.prev_navigation("users_table", "user_id", id_tb.Text));
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridView1.SelectedRowsCount != 0)
            {
                navigate_btn($"select * from users_table where user_id={gridView1.GetFocusedRowCellValue(gridView1.Columns[0].FieldName)}");
            }
            if (gridView1.SelectedRowsCount == 0)
            {
                delete_btn.Enabled = false;
                update_btn.Enabled = false;
                save_btn.Enabled = true;
                new_btn.PerformClick();
            }
        }

        private void storage_name_cb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
              //TODO
              //metro_click_class.open("إدارة الخزنات");
                run_worker_class.run(storage_worker);
            }
        }
        private void bank_name_cb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {
                //TODO
                //metro_click_class.open("إدارة البنوك");
                run_worker_class.run(storage_worker);
            }
        }
        private void ar_users_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataTable check_table = connection_class.select("select * from users_table");
            if (check_table.Rows.Count == 0)
            {
                string message = "لقد قمت بحذف كافة المستخدمين ولن تتمكن من تسجيل الدخول من جديد\nسيتم إنشاء مستخدم جديد يملك كافة الصلاحيات ببيانات الدخول الآتية :\nإسم المستخدم 123 وكلمة المرور 123";
                notifications_class.my_messageBox(message);
                DataTable table = connection_class.select("select isnull(max(user_id)+1,1) from users_table");
                int id = Convert.ToInt32(table.Rows[0][0]);
                SqlCommand command = new SqlCommand("insert into users_table values (@id,@username,@password,@user_image,@storage_name,@bank_name)", connection_class.connection());
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@username", "123");
                command.Parameters.AddWithValue("@password", "123");
                command.Parameters.AddWithValue("@user_image", convert_class.image_to_byte(user_pic.Image));
                command.Parameters.AddWithValue("@storage_name", "الخزنة الرئيسية");
                command.Parameters.AddWithValue("@bank_name", string.Empty);
                if (command.ExecuteNonQuery() == 1)
                {
                    add_123_user_permissions();
                }
            }
            if (check_table.Rows.Count > 0)
            {
                string the_username = "";
                bool is_all_users_has_permessions = true;
                for (int i = 0; i < check_table.Rows.Count; i++)
                {
                    string username = check_table.Rows[i]["username"].ToString();
                    DataTable table = connection_class.select($"select add_user,edit_user,edit_permissions from permissions_employees_users_table where username=N'{username}'");
                    int add_user = Convert.ToInt32(table.Rows[0]["add_user"]);
                    int edit_user = Convert.ToInt32(table.Rows[0]["edit_user"]);
                    int edit_permissions = Convert.ToInt32(table.Rows[0]["edit_permissions"]);
                    if (add_user == 0 || edit_user == 0 || edit_permissions == 0)
                    {
                        is_all_users_has_permessions = false;
                        the_username = username;
                    }
                    else
                    {
                        is_all_users_has_permessions = true;
                        the_username = username;
                        break;
                    }
                }

                if (is_all_users_has_permessions == false)
                {
                    string message = $"سيتم منح المستخدم {the_username} صلاحيات إضافة وتعديل المستخدمين تلقائياً";
                    connection_class.command($@"UPDATE [dbo].[permissions_employees_users_table]
   SET 
      [add_user] = 1
      ,[edit_user] = 1
      ,[edit_permissions] = 1
 WHERE [username]=N'{the_username}'");
                    notifications_class.my_messageBox(message);
                }

            }

        }
        void add_123_user_permissions()
        {
            string username = "123";
            connection_class.command($@"INSERT INTO [dbo].[permissions_archive_snds_table]
     VALUES
           (N'{username}'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_accounts_taxes_table]
          
     VALUES
           (N'{username}'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)");
            connection_class.command($@"INSERT INTO permissions_banks_storages_table
     VALUES
           (N'{username}'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_black_box_settings_table]          
     VALUES
           (N'{username}'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_buies_sells_table]
        
     VALUES
           (N'{username}'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_companies_morden_table]
         
     VALUES
           (N'{username}'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_customers_table]
         
     VALUES
           (N'{username}'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_employees_users_table]          
     VALUES
           (N'{username}'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1,1,1,1)");
            connection_class.command($@"INSERT INTO [dbo].[permissions_products_warehouses_table]           
     VALUES
           (N'{username}'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)");
        }
        private void bank_name_cb_Click(object sender, EventArgs e)
        {
        }

        private void bank_name_cb_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void user_pic_ImageChanged(object sender, EventArgs e)
        {

        }
    }
}