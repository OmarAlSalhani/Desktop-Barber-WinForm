﻿using System;
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
using barber_app.classes;

namespace barber_app.n_snds_forms.ar
{
    public partial class ar_snd_srf_form : DevExpress.XtraEditors.XtraForm
    {
        public ar_snd_srf_form()
        {
            InitializeComponent();
            snd_date_dtp.DateTime = DateTime.Now;
        }

        public static string theName, theNotes, theDate, theId, theValue, n2c_text;
        bool is_ok()
        {
            double value = texts_class.is_number(value_textbox.Text) ? Convert.ToDouble(value_textbox.Text) : 0;
            if (value <= 0)
            {
                OmarNotifications.Alert.ShowInformation("لا يمكن أن تكون القيمة صفر أو سالبة");
                return false;
            }
            if (snd_type_cb.SelectedIndex == -1)
            {
                OmarNotifications.Alert.ShowInformation("الرجاء إختيار سبب السند");
                return false;
            }
            return true;

        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                

                    if (is_ok())
                    {
                        DialogResult dr = notifications_class.my_messageBoxRightYesNo("هل تريد صرف السند ؟");
                        if (dr == DialogResult.Yes)
                        {
                            add_snd();
                            clear_form();
                        }

                    }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("PRIMARY KEY"))
                {
                    OmarNotifications.Alert.ShowInformation("رقم السند مكرر\nالرجاء الضغط على جديد لتوليد رقم جديد");
                    return;
                }
                else
                {
                    OmarNotifications.Alert.ShowInformation(ex.Message);
                }
            }
        }

        DataTable table;
        private void fill_cb_worker_DoWork(object sender, DoWorkEventArgs e)
        {
            table = connection_class.select("select name as 'السبب' from expinsivies_type_table");
        }
        private void fill_cb_worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            classes.comboBox_class.fill_combobox(table, snd_type_cb);
        }
        void navigate_btn(string query)
        {
            DataTable table = connection_class.select(query);
            if (table.Rows.Count == 0)
            {
                DataTable table1 = connection_class.select("select * from snd_srf_table");
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
                int id = Convert.ToInt32(table.Rows[0]["id"]);
                id_tb.Text = id.ToString();
                snd_type_cb.Text = table.Rows[0]["reason"].ToString();
                value_textbox.Text = table.Rows[0]["value"].ToString();
                notes_textbox.Text = table.Rows[0]["notes"].ToString();
                snd_date_dtp.DateTime = Convert.ToDateTime(table.Rows[0]["the_date"].ToString());
                delete_btn.Enabled = true;
                update_btn.Enabled = true;
                save_btn.Enabled = false;

            }
        }
        void openForm(XtraForm form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.IconOptions.ShowIcon = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.Text = "";
            form.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress);
            form.ShowDialog();

        }

        private void snd_type_cb_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
            {

                ar_expinsive_type_form form = new ar_expinsive_type_form();
                openForm(form);
                if (fill_cb_worker.IsBusy == false)
                {
                    fill_cb_worker.RunWorkerAsync();
                }
            }

        }
        private void update_btn_Click(object sender, EventArgs e)
        {

            if (is_ok())
            {
                DialogResult dr = notifications_class.my_messageBoxRightYesNo("هل تريد تأكيد التعديل ؟");
                if (dr == DialogResult.Yes)
                {
                    DataTable old_data_table = connection_class.select($"select * from snd_srf_table where id={get_id_from_lbl()}");
                    double value = Convert.ToDouble(old_data_table.Rows[0]["value"]);
                    string reason = snd_type_cb.Text.Trim();
                    double new_value = Convert.ToDouble(value_textbox.Text);
                    string the_date = snd_date_dtp.DateTime.ToString("dd-MM-yyyy");
                    string username = classes.const_variables_class.username;
                    string notes = notes_textbox.Text.Trim();
                    string added_date = classes.const_variables_class.now_date;
                    logs_class.log_add($"تعديل سند الصرف برقم {get_id_from_lbl()}", 0, "السندات");
                    classes.storage_class.storage_value_increase(value);
                    classes.storage_class.storage_value_decrease(new_value);
                    storage_class.storage_log_add($"تعديل سند الصرف ذو الرقم [ {get_id_from_lbl()} ]", value - new_value, settings_files.main_settings.Default.storage_id);
                    connection_class.command($"delete from snd_srf_table where id={get_id_from_lbl()}");
                    connection_class.command($"insert into snd_srf_table values ({get_id_from_lbl()},'{reason}',{new_value},'{the_date}','{username}','{notes}','{added_date}')");
                    new_btn.PerformClick();
                    classes.notifications_class.success_message();
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {

            DialogResult dr = classes.notifications_class.my_messageBox("هل تريد حذف السند ؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                connection_class.command($"delete from snd_srf_table where id={get_id_from_lbl()}");
                double value = Convert.ToDouble(value_textbox.Text);
                classes.storage_class.storage_value_increase(value);
                logs_class.log_add($"حذف سند الصرف ذو الرقم [ {get_id_from_lbl()} ]", 0, "السندات");
                classes.storage_class.storage_log_add($"حذف  سند الصرف برقم {get_id_from_lbl()}", value, settings_files.main_settings.Default.storage_id);
                new_btn.PerformClick();
                classes.notifications_class.success_message();
            }
        }

        private void new_btn_Click(object sender, EventArgs e)
        {
            clear_form();
            get_snd_number();
        }

        private void first_btn_Click(object sender, EventArgs e)
        {
            navigate_btn("select * from snd_srf_table where id=(select min(id) from snd_srf_table)");

        }
        bool is_next_clicked = false;
        private void second_btn_Click(object sender, EventArgs e)
        {
            navigate_btn(navigation_class.next_navigatoin("snd_srf_table", "id", id_tb.Text));
            is_next_clicked = true;
        }

        private void prev_btn_Click(object sender, EventArgs e)
        {
            navigate_btn(navigation_class.prev_navigation("snd_srf_table", "id", id_tb.Text));
            is_next_clicked = false;
        }

        private void last_btn_Click(object sender, EventArgs e)
        {
            navigate_btn("select * from snd_srf_table where id=(select max(id) from snd_srf_table)");

        }

        private void ar_snd_srf_form_Load(object sender, EventArgs e)
        {
            new_btn.PerformClick();
            run_worker_class.run(fill_cb_worker);
        }
        void clear_form()
        {
            value_textbox.Text =
                notes_textbox.Text =
                string.Empty;
            save_btn.Enabled = true;
            update_btn.Enabled = delete_btn.Enabled = false;

        }
        void print()
        {
            DataTable table = connection_class.select($@"select [id]
      ,[reason]
      ,[value]
      ,the_date as 'the_date'
      ,[username]
      ,[notes]
      ,[added_date]
  FROM [snd_srf_table] where id={get_id_from_lbl()}");
            theName = table.Rows[0]["reason"].ToString();
            theNotes = table.Rows[0]["notes"].ToString();
            theDate = table.Rows[0]["the_date"].ToString();
            theId = get_id_from_lbl().ToString();
            theValue = table.Rows[0]["value"].ToString();
            n2c_text = N2C.ConvertN2C.ConvertNow(Convert.ToDouble(theValue), "ر.س", "");
            repost_pos.snd_srf_report2.print();
        }
        void add_snd()
        {
            string reason = snd_type_cb.Text.Trim();
            double value = Convert.ToDouble(value_textbox.Text);
            string the_date = snd_date_dtp.DateTime.ToString("dd-MM-yyyy");
            string username = classes.const_variables_class.username;
            string notes = notes_textbox.Text.Trim();
            string added_date = classes.const_variables_class.now_date;
            connection_class.command($"insert into snd_srf_table values ({get_id_from_lbl()},'{reason}',{value},'{the_date}','{username}','{notes}','{added_date}')");
            classes.storage_class.storage_value_decrease(value);
            classes.storage_class.storage_log_add($"صرف سند الصرف ذو الرقم [ {get_id_from_lbl()} ]", value * -1, settings_files.main_settings.Default.storage_id);
            logs_class.log_add($"إضافة سند الصرف برقم {get_id_from_lbl()}", 0, "السندات");
            DialogResult dr = classes.notifications_class.my_messageBox("تمت إضافة سند الصرف بنجاح\nهل تريد طباعته ؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                print();
            }
            else

                get_snd_number();

        }
        void get_snd_number()
        {
            DataTable table = connection_class.select("select ifnull(max(id)+1,1) from snd_srf_table");
            id_tb.Text = table.Rows[0][0].ToString();
        }
        int get_id_from_lbl()
        {
            return Convert.ToInt32(id_tb.Text);
        }
    }
}