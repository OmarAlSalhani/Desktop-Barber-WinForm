using barber_app.classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using barber_app.classes;

namespace barber_app.users_forms
{
    public partial class ar_user_permissions_form : DevExpress.XtraEditors.XtraForm
    {
        public ar_user_permissions_form()
        {
            InitializeComponent(); 

        }
        string username;
        int checkbox_to_int(CheckBox checkBox)
        {
            if (checkBox.Checked)
                return 1;
            else
                return 0;
        }
        bool table_cell_to_int(string table_column)
        {
            int a = Convert.ToInt32(table_column);
            if (a == 0)
                return false;
            else
                return true;
        }
       /* void get_accounts_taxes_permissions()
        {
            DataTable table = connection_class.select($"select * from permissions_accounts_taxes_table where username=N'{username}'");
            account_rsed_report_cbx.Checked = table_cell_to_int(table.Rows[0]["account_rsed_report"].ToString());
            accounts_forwarding_cbx.Checked = table_cell_to_int(table.Rows[0]["accounts_forwarding"].ToString());
            tree_add_cbx.Checked = table_cell_to_int(table.Rows[0]["tree_add"].ToString());
            tree_edit_cbx.Checked = table_cell_to_int(table.Rows[0]["tree_edit"].ToString());
            daily_qed_show_add_cbx.Checked = table_cell_to_int(table.Rows[0]["daily_qed_show_add"].ToString());
            daily_qed_edit_cbx.Checked = table_cell_to_int(table.Rows[0]["daily_qed_edit"].ToString());
            daily_qed_report_cbx.Checked = table_cell_to_int(table.Rows[0]["daily_qed_report"].ToString());
            mezan_morag3a_cbx.Checked = table_cell_to_int(table.Rows[0]["mezan_morag3a"].ToString());
            eqrar_tax_cbx.Checked = table_cell_to_int(table.Rows[0]["eqrar_tax"].ToString());
        }*/
        /*void update_accounts_taxes_permissions()
        {
            connection_class.command($@"UPDATE [dbo].[permissions_accounts_taxes_table]
       SET
      [account_rsed_report] = {checkbox_to_int(account_rsed_report_cbx)}
      ,[accounts_forwarding] = {checkbox_to_int(accounts_forwarding_cbx)}
      ,[tree_add] = {checkbox_to_int(tree_add_cbx)}
      ,[tree_edit] = {checkbox_to_int(tree_edit_cbx)}
      ,[daily_qed_show_add] ={checkbox_to_int(daily_qed_show_add_cbx)}
      ,[daily_qed_edit] = {checkbox_to_int(daily_qed_edit_cbx)}
      ,[daily_qed_report] = {checkbox_to_int(daily_qed_report_cbx)}
      ,[mezan_morag3a] = {checkbox_to_int(mezan_morag3a_cbx)}
      ,[eqrar_tax] = {checkbox_to_int(eqrar_tax_cbx)}
 WHERE [username]=N'{username}'");
        }*/

        private void ar_user_permissions_form_Load(object sender, EventArgs e)
        {
            username = ar_users_form.username_for_roles;
            if (backgroundWorker1.IsBusy == false)
                backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           // get_accounts_taxes_permissions();
           
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            username = ar_users_form.username_for_roles;
           // update_accounts_taxes_permissions();
        
            notifications_class.success_message();

        }
    }
}