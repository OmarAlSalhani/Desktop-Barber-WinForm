﻿using DevExpress.XtraPrinting;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System;
using barber_app.classes;
using barber_app.settings_files;

namespace barber_app.repost_pos
{
    public partial class ash3ar_report : DevExpress.XtraReports.UI.XtraReport
    {
        public ash3ar_report()
        {
            InitializeComponent();
        }
        void set_report_detailes()
        {
            drebe_number_label.Text = "الرقم الضريبي : " + settings_files.main_settings.Default.tax_number;
            address_label.Text = "العنوان : " + settings_files.main_settings.Default.address;
            first_phone_label.Text = "الهاتف : " + settings_files.main_settings.Default.landline;
            second_phone_label.Text = "الجوال : " + settings_files.main_settings.Default.mobile;
            pharmacy_name_label.Text = settings_files.main_settings.Default.barber_name;
            logo_image.ImageUrl = settings_files.main_settings.Default.logo;
        }

        void BindData()
        {
            cash_paied_lbl.Text = fatora_forms.ar_sell_fatora_checkout_form.cash_pay.ToString();
            card_paied_lbl.Text = fatora_forms.ar_sell_fatora_checkout_form.card_pay.ToString();
            set_report_detailes();
        }

        public static void print(System.Data.DataTable products_datasource)
        {
            if (settings_files.main_settings.Default.invoice_print_type == 0)
            {
                ash3ar_report report = new ash3ar_report();
                report.DetailReport.DataSource = products_datasource;
                report.BindData();
                report.PrinterName = settings_files.main_settings.Default.invoice_printer_name;
                report.Print();
            }
            else
            {
                ash3ar_report report = new ash3ar_report();
                report.DetailReport.DataSource = products_datasource;
                report.BindData();
                report.PrinterName = settings_files.main_settings.Default.invoice_printer_name;

                report.ShowPreview();
            }
        }
    }
}
