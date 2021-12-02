using DevExpress.Utils.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Microsoft.Win32;
using barber_app.classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace barber_app
{
    public partial class login_form : Form
    {
        public login_form()
        {

            InitializeComponent();
            double width = System.Windows.SystemParameters.PrimaryScreenWidth;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;
            if (width == 1024 && height == 768)
            {
                Size = new Size(700, 500);
                pictureBox3.Size = new Size(225, 75);
                pictureBox3.MinimumSize = new Size(75, 75);
                pictureBox3.Dock = DockStyle.None;
                pictureBox3.Anchor = AnchorStyles.None;
                username_cb.Size = new Size(200, 44);
                password_tb.Size = new Size(200, 44);
                login_btn.Size = new Size(210, 47);
                password_tb.Font = new Font("cairo", 10);
                username_cb.Font = new Font("cairo", 10);
                login_btn.Font = new Font("cairo", 10);
                labelControl1.Font = new Font("cairo", 11, FontStyle.Bold);
            }
            if (width == 1280 && height == 800)
            {
                Size = new Size(850, 500);
                pictureBox3.Size = new Size(375, 75);
                pictureBox3.MinimumSize = new Size(375, 75);
                pictureBox3.Dock = DockStyle.None;
                pictureBox3.Anchor = AnchorStyles.None;
                username_cb.Size = new Size(225, 44);
                password_tb.Size = new Size(225, 44);
                login_btn.Size = new Size(235, 47);
                password_tb.Font = new Font("cairo", 12);
                username_cb.Font = new Font("cairo", 12);
                login_btn.Font = new Font("cairo", 12);
                labelControl1.Font = new Font("cairo", 13, FontStyle.Bold);
            }
        }


        DataTable users_table;
        private void fill_users_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            users_table = connection_class.select("select username from users_table");
        }

        private void fill_users_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            for (int i = 0; i < users_table.Rows.Count; i++)
            {
                string user = users_table.Rows[i][0].ToString();
                username_cb.Properties.Items.Add(user);
            }
            username_cb.SelectedIndex = 0;
        }
        private void login_form_Load(object sender, EventArgs e)
        {
            run_worker_class.run(fill_users_worker);
        }

        private void password_tb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (password_tb.Properties.PasswordChar == '*')
                password_tb.Properties.PasswordChar = '\0';
            else
                password_tb.Properties.PasswordChar = '*';
        }
        bool is_user_exist()
        {
            string username = username_cb.Text;
            string password = password_tb.Text;
            DataTable table = connection_class.select($"select * from users_table where username=N'{username}' and password=N'{password}'");
            if (table.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        bool is_everything_ok()
        {
            if (username_cb.SelectedIndex == -1 || texts_class.is_null(username_cb.Text))
            {
                OmarNotifications.Alert.ShowInformation("لا يمكن أن يكون أسم المستخدم فارغاً");
                return false;
            }
            if (texts_class.is_null(password_tb.Text))
            {
                OmarNotifications.Alert.ShowInformation("لا يمكن أن تكون كلمة المرور  فارغة");
                return false;
            }
            return true;
        }
        string username;
        private void login_btn_Click(object sender, EventArgs e)
        {
            if (is_everything_ok())
            {
                if (is_user_exist())
                {
                    username = username_cb.Text;
                    if (splashScreenManager1.IsSplashFormVisible == false)
                        splashScreenManager1.ShowWaitForm();
                    run_worker_class.run(permissions_worker);
                }
                else
                {
                    OmarNotifications.Alert.ShowError("بيانات الدخول غير صحيحة\nالرجاء المحاولة مجدداً");
                    return;
                }
            }
        }
        int role(DataTable table, string column)
        {
            try
            {
                return Convert.ToInt32(table.Rows[0][column].ToString());

            }
            catch
            {
                return 0;
            }
        }
        private void permissions_worker_DoWork(object sender, DoWorkEventArgs e)
        {
          

        /*    #region permissions_customers_table
            DataTable permissions_customers_table = connection_class.select($"select * from permissions_customers_table where username=N'{username}'");
            settings_files.permissions_customers.Default.add_customer = role(permissions_customers_table, "add_customer");
            settings_files.permissions_customers.Default.edit_customer = role(permissions_customers_table, "edit_customer");
            settings_files.permissions_customers.Default.customer_mdeonee = role(permissions_customers_table, "customer_mdeonee");
            settings_files.permissions_customers.Default.customers_mqbodat = role(permissions_customers_table, "customers_mqbodat");
            settings_files.permissions_customers.Default.customer_kshf = role(permissions_customers_table, "customers_kshf");
            settings_files.permissions_doctors.Default.doctor_manager = role(permissions_customers_table, "add_doctor");
            settings_files.permissions_doctors.Default.doctor_mdfo3at = role(permissions_customers_table, "doctor_mdfo3at");
            settings_files.permissions_doctors.Default.doctor_manager = role(permissions_customers_table, "doctor_most7qat");
            settings_files.permissions_customers.Default.Save();
            settings_files.permissions_doctors.Default.Save();
            permissions_worker.ReportProgress(75);
            #endregion
        */
        }

        private void permissions_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (progress == 100)
            {
                settings_files.main_settings.Default.username = username_cb.Text;
                DataTable table = connection_class.select($"select storage_name,bank_name from users_table where username=N'{username_cb.Text}'");
                settings_files.main_settings.Default.storage_name = table.Rows[0][0].ToString();
                settings_files.main_settings.Default.bank_name = table.Rows[0][1].ToString();
                settings_files.main_settings.Default.Save();
                splashScreenManager1.CloseWaitForm();
                Hide();
            }
        }
        int progress;
        private void permissions_worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress = e.ProgressPercentage;
        }

        private void close_btn_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Application.Exit();
        }

        private void minimize_btn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void tableLayoutPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            move_form_class.move(e, Handle);
        }

        private void tableLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            move_form_class.move(e, Handle);
        }
        private void keyboard_click(object sender, EventArgs e)
        {
            SimpleButton button = sender as SimpleButton;
            if (username_focused)
            {
                username_cb.Text += button.Text;
            }
            else
            {
                password_tb.Text += button.Text;
            }
        }
        private void keyboard_btn_Click(object sender, EventArgs e)
        {
            navigationFrame1.SelectedPage = navigationPage2;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
        }

        private void password_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_btn.PerformClick();
            }
        }

        private void username_cb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                password_tb.Focus();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
        }

        private void hide_keyboard_btn_Click(object sender, EventArgs e)
        {
        }
        bool username_focused = false;
        private void username_cb_Click(object sender, EventArgs e)
        {
            username_focused = true;
        }

        private void password_tb_Click(object sender, EventArgs e)
        {
            username_focused = false;
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            try
            {
                if (username_focused && username_cb.Text.Length != 0)
                {
                    username_cb.Text = username_cb.Text.Remove(username_cb.Text.Length - 1);
                }
                else
                {
                    if (password_tb.Text.Length != 0)
                    {
                        password_tb.Text = password_tb.Text.Remove(password_tb.Text.Length - 1);

                    }
                }
            }
            catch
            {

            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }
    }
}
