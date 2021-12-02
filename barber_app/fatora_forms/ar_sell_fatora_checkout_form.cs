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

namespace barber_app.fatora_forms
{
    public partial class ar_sell_fatora_checkout_form : DevExpress.XtraEditors.XtraForm
    {
        public static string the_pay_type;
        public static bool IsClicked = false;
        public static double cash_pay, card_pay, how_stay, total_amount;

        private void ar_sell_fatora_checkout_form_Load(object sender, EventArgs e)
        {
            the_pay_type = "نقداً";
           
            if (settings_files.main_settings.Default.bank_name.Trim().Length == 0)
            {
                pay_type_cb.Enabled = false;
                card_pay_textbox.Text = "0";
                card_pay_textbox.Enabled = false;
                cash_focused = true;
            }
            cash_pay_textbox.Select();
            net_textbox.Text = total_textbox.Text;
            cash_pay_textbox.Text = total_textbox.Text;
        }
        void keypad(object sender, EventArgs e)
        {
            SimpleButton button = sender as SimpleButton;
            if(pay_type_cb.Text=="نقداً")
            {
                cash_focused = true;
                card_focused = false;
            }
            if(pay_type_cb.Text== "البطاقة الإئتمانية")
            {
                card_focused = true;
                cash_focused = false;
            }
            if (cash_focused)
            {
                cash_pay_textbox.Text = cash_pay_textbox.Text + button.Text;
            }
            else if (card_focused)
            {
                card_pay_textbox.Text = card_pay_textbox.Text + button.Text;
            }
            
        }
        private void cash_pay_textbox_TextChanged(object sender, EventArgs e)
        {
            cash_pay_textbox.Text = barber_app.classes.texts_class.is_number(cash_pay_textbox.Text) ? cash_pay_textbox.Text : "";
            if (barber_app.classes.texts_class.is_number(cash_pay_textbox.Text))
            {
                double cash = Convert.ToDouble(cash_pay_textbox.Text);
                double card = Convert.ToDouble(card_pay_textbox.Text);
                double total = Convert.ToDouble(total_textbox.Text);
                double value = total - (cash + card);
                net_textbox.Text = value.ToString();
            }
            else
            {
                cash_pay_textbox.Text = "0";
            }
        }

        private void card_pay_textbox_TextChanged(object sender, EventArgs e)
        {
            card_pay_textbox.Text = barber_app.classes.texts_class.is_number(card_pay_textbox.Text) ? card_pay_textbox.Text : "";
            if (barber_app.classes.texts_class.is_number(card_pay_textbox.Text))
            {
                double cash = Convert.ToDouble(cash_pay_textbox.Text);
                double card = Convert.ToDouble(card_pay_textbox.Text);
                double total = Convert.ToDouble(total_textbox.Text);
                double value = total - (cash + card);
                net_textbox.Text = value.ToString();
            }
            else
            {
                card_pay_textbox.Text = "0";
            }
        }

        private void pay_type_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pay_type_cb.SelectedIndex == 0)
            {
                the_pay_type = "نقداً";
                card_pay_textbox.Text = "0";
                card_pay_textbox.Enabled = false;
                cash_pay_textbox.Enabled = true;
            }
            if (pay_type_cb.SelectedIndex == 1)
            {
                the_pay_type = "بطاقة إئتمانية";
                cash_pay_textbox.Text = "0";
                cash_pay_textbox.Enabled = false;
                card_pay_textbox.Enabled = true;
            }
            if (pay_type_cb.SelectedIndex == 2)
            {
                the_pay_type = "متعدد";
                cash_pay_textbox.Enabled = card_pay_textbox.Enabled = true;
            }
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            total_amount = Math.Round(Convert.ToDouble(total_textbox.Text), 2);
            how_stay = Math.Round(Convert.ToDouble(net_textbox.Text), 2);
            card_pay = Math.Round(Convert.ToDouble(card_pay_textbox.Text), 2);
            cash_pay = Math.Round(Convert.ToDouble(cash_pay_textbox.Text), 2);
            
            if (ar_pos_uc.is_bill_agel)
            {
                if (how_stay <= 0)
                {
                    OmarNotifications.Alert.ShowInformation("لا يمكن دفع كامل قيمة الفاتورة\nللعميل الآجل");
                    return;
                }
            }
            if (ar_pos_uc.is_bill_agel == false)
            {
                if (cash_pay <= 0 && the_pay_type == "نقداً")
                {
                    OmarNotifications.Alert.ShowInformation("لا يمكن أن تكون القيمة صفر أو سالبة");
                    return;
                }
                if (card_pay <= 0 && the_pay_type == "بطاقة إئتمانية")
                {
                    OmarNotifications.Alert.ShowInformation("لا يمكن أن تكون القيمة صفر أو سالبة");
                    return;
                }
                if (the_pay_type == "متعدد")
                {
                    if (cash_pay <= 0 || card_pay <= 0)
                    {
                        OmarNotifications.Alert.ShowInformation("لا يمكن أن تكون القيمة صفر أو سالبة");
                        return;
                    }
                }
                if (how_stay > 0)
                {
                    OmarNotifications.Alert.ShowInformation("لا يمكن دفع جزء من قيمة الفاتورة\nللعميل النقدي");
                    return;
                }
            }
            if (how_stay < 0)
            {
                OmarNotifications.Alert.ShowInformation("المبلغ المدفوع أكبر من قيمة الفاتورة");
                return;
            }
            IsClicked = true;
            Close();
        }
        int SC_CLOSE = 0xF060;
        int WM_SYSCOMMAND = 0x0112;
        bool xClick = false;
        bool cash_focused = false;
        bool card_focused = false;
        private void cash_pay_textbox_Click(object sender, EventArgs e)
        {
            cash_focused = true;
            card_focused = false;
        }
        private void card_pay_textbox_Click(object sender, EventArgs e)
        {
            card_focused = true;
            cash_focused = false;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            if (cash_focused)
            {
                cash_pay_textbox.Text = "0";
            }
            else if (card_focused)
            {
                card_pay_textbox.Text = "0";
            }
        }

       

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND && m.WParam.ToInt32() == SC_CLOSE)
                xClick = true;
            base.WndProc(ref m);
        }
        private void ar_sell_fatora_checkout_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xClick)
                IsClicked = false;
        }

        public ar_sell_fatora_checkout_form()
        {
            InitializeComponent();
        }
    }
}