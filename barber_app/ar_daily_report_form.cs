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
using barber_app.classes;

namespace barber_app
{
    public partial class ar_daily_report_form : DevExpress.XtraEditors.XtraForm
    {
        public ar_daily_report_form()
        {
            InitializeComponent();
            first_date.DateTime = last_date.DateTime = DateTime.Now;
        }
        string get_data(string query)
        {
            DataTable table = connection_class.select(query);
                if (table.Rows.Count == 0)
            {
                return "0";
            }
            else
                return table.Rows[0][0].ToString();

        }
        bool IsZero()
        {
            if (
                   Convert.ToDouble(customers_deon_tb.Text) == 0
                && Convert.ToDouble(customers_paied_money_tb.Text) == 0
                && Convert.ToDouble(total_tax_tb.Text) == 0
                && Convert.ToDouble(snd_srf_tb.Text) == 0
                && Convert.ToDouble(total_without_tax_tb.Text) == 0
                && Convert.ToDouble(total_with_taxes_tb.Text) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void show_report_btn_Click(object sender, EventArgs e)
        {
            string f = first_date.DateTime.ToString("dd-MM-yyyy");
            string l = last_date.DateTime.ToString("dd-MM-yyyy");
            customers_deon_tb.Text = get_data($"select ifnull(sum(how_stay),0) as 'total' from agle_table where the_pay_date between '{f}' and '{l}'");
            customers_paied_money_tb.Text = get_data($"select ifnull(sum(value),0)  as 'total' from customers_paied_money_table where the_date between '{f}' and '{l}'");
            snd_srf_tb.Text = get_data($"select ifnull(sum(value),0) as 'value' from snd_srf_table where the_date between '{f}' and '{l}'");
            snd_srf_tb.Text = get_data($"select ifnull(sum(value),0) as 'value' from snd_kbd_table where the_date between '{f}' and '{l}'");
          
            total_tax_tb.Text = get_data($"select ifnull(sum(taxes),0) as 'value' from sales_head_table where sell_date between '{f}' and '{l}'");
            total_without_tax_tb.Text = get_data($"select ifnull(sum(total_before_taxes),0) as 'value' from sales_head_table where sell_date between '{f}' and '{l}'");
            total_with_taxes_tb.Text = get_data($"select ifnull(sum(total_amount),0) as 'value' from sales_head_table where sell_date between '{f}' and '{l}'");
            
            
            
            if (IsZero())
            {
                OmarNotifications.Alert.ShowInformation("لا يوجد بيانات لعرضها في الفترة المحددة");
                return;
            }
        }

        private void ar_daily_report_form_Load(object sender, EventArgs e)
        {

        }
    }
}