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
            if(settings_files.permissions_settings.Default.customers_kshf_7sab==0)
            {
                customer_kshf_7sab_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_customers == 0)
            {
                customers_manage_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.customers_mdeonee == 0)
            {
                customers_deon_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.customers_paied_money == 0)
            {
                customers_paied_money_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.open_pos == 0)
            {
                pos_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.sales_report == 0)
            {
                sales_report_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_products == 0)
            {
                services_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_categories == 0)
            {
                categories_btn.Enabled = false;
            }

            if (settings_files.permissions_settings.Default.manage_settings == 0)
            {
                categories_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_storages == 0)
            {
                storages_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.storages_operations == 0)
            {
                storages_operations_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_users == 0)
            {
                users_btn.Enabled = false;
            }

            if (settings_files.permissions_settings.Default.manage_blackbox == 0)
            {
                blackbox_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.snd_qbd == 0)
            {
                snd_qbd_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.snd_srf == 0)
            {
                snds_srf_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.snds_report == 0)
            {
                snds_report_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_daily_brief == 0)
            {
                daily_brief_btn.Enabled = false;
            }
            if (settings_files.permissions_settings.Default.manage_today_agle == 0)
            {
                today_agel_btn.Enabled = false;
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

        private void snd_qbd_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_snds_forms.ar.ar_snd_qbd_form());
        }

        private void snds_srf_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_snds_forms.ar.ar_snd_srf_form());
        }

        private void snds_report_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_snds_forms.ar.ar_snds_report_form());
        }

        private void customers_manage_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new customers_forms.ar_customers_form());
        }

        private void users_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new users_forms.ar_users_form());
        }

        private void blackbox_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new n_blackbox_forms.ar.ar_blackbox_form());
        }

        private void daily_brief_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new ar_daily_report_form());
        }

        private void today_agel_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new ar_agel_notifications_form());
        }

        private void ash3ar_btn_ItemClick(object sender, ItemClickEventArgs e)
        {
            openForm(new ash3ar_forms.da2en_ash3ar_form());
        }
    }
}