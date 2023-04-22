using System.Windows.Forms;using DevExpress.XtraReports.UI;using System;
using barber_app.classes;

namespace barber_app.repost_pos
{
    public partial class snd_srf_report2 : DevExpress.XtraReports.UI.XtraReport
    {
        public snd_srf_report2()
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
            set_report_detailes();
            snd_type_lbl.Text = n_snds_forms.ar.ar_snd_qbd_form.theName;
            snd_id_lbl.Text = n_snds_forms.ar.ar_snd_srf_form.theId;
            money_lbl.Text = n_snds_forms.ar.ar_snd_srf_form.theValue;
            date_lbl.Text = n_snds_forms.ar.ar_snd_srf_form.theDate;
            notes_lbl.Text = n_snds_forms.ar.ar_snd_srf_form.theNotes;
            n2c_text.Text = n_snds_forms.ar.ar_snd_srf_form.n2c_text;
        }

        public static void print()
        {
            // 0 Direct
            if (barber_app.settings_files.main_settings.Default.reports_print_type == 0)
            {
                snd_srf_report2 report = new snd_srf_report2();
                report.BindData();
                report.PrinterName = barber_app.settings_files.main_settings.Default.reports_printer_name;
                report.Print();
            }
            else
            {
                snd_srf_report2 report = new snd_srf_report2();
                report.BindData();
                report.PrinterName = barber_app.settings_files.main_settings.Default.reports_printer_name;
                report.ShowPreview();
            }

        }
    }
}
