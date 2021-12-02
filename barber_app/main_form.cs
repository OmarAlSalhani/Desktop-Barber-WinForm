using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace barber_app
{
    public partial class main_form : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public main_form()
        {
            InitializeComponent();
           /* if (settings_files.roles_settings.Default.msrofat == 0)
            {
                categories_btn.Enabled = false;
            }*/
          
        }

        private void manage_employees_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void add_salary_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void salaries_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void advances_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void rewards_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void add_reward_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void discounts_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void add_discount_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        void openForm(XtraForm form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.IconOptions.ShowIcon = false;
            form.FormBorderStyle = FormBorderStyle.FixedSingle;
            form.MaximizeBox = false;
            form.Text = "";
            form.LookAndFeel.SetSkinStyle(DevExpress.LookAndFeel.SkinStyle.DevExpress);
            form.Show();

        }

        private void services_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new products_forms.ar_products_form());
        }

        private void pos_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new fatora_forms.pos_form());
        }

        private void categories_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new products_forms.category_form());
        }

        private void settings_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_settings_forms.ar.ar_main_settings_form());
        }

        private void storages_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new storages_forms.ar_storages_form());
        }

        private void storages_operations_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new storages_forms.ar_storage_operations_form());
        }

        private void sales_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new fatora_forms.ar_sell_report_form());
        }

        private void customers_deon_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new customers_forms.ar_customers_mdeonee_form());
        }

        private void customers_paied_money_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new customers_forms.ar_customers_paied_money_form());
        }

        private void customer_kshf_7sab_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new customers_forms.ar_customers_kshf_7sab_form());
        }
    }
}