using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DevExpress.Utils.Localization;
using DevExpress.LookAndFeel;

namespace barber_app.classes
{
    class notifications_class
    {
        public static UserLookAndFeel look()
        {
            //configuring the UserLookAndFeel 
            UserLookAndFeel lookAndFeelError = new UserLookAndFeel(null);
            lookAndFeelError.SkinName = "DevExpress Style";
            lookAndFeelError.Style = LookAndFeelStyle.Skin;
            lookAndFeelError.UseDefaultLookAndFeel = false;
            XtraMessageBox.AllowCustomLookAndFeel = true;
            return lookAndFeelError;
        }
        public static DialogResult my_messageBox(string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return XtraMessageBox.Show(look(), text, "", buttons, icon);
        }
        public static DialogResult my_messageBox(string text, string caption)
        {
            return XtraMessageBox.Show(look(), text, caption);
        }

        public static DialogResult my_messageBoxRightYesNo(string text)
        {
            XtraMessageBox.AllowCustomLookAndFeel = true;
            return XtraMessageBox.Show(look(), text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
        public static DialogResult my_messageBox(string text, MessageBoxIcon icon)
        {
            XtraMessageBox.AllowCustomLookAndFeel = true;
            return XtraMessageBox.Show(look(), text, "", MessageBoxButtons.OK, icon);
        }
        public static DialogResult my_messageBox(string text)
        {
            XtraMessageBox.AllowCustomLookAndFeel = true;
            return XtraMessageBox.Show(look(), text, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult my_messageBox(Form form, string text)
        {
            XtraMessageBox.AllowCustomLookAndFeel = true;
            return XtraMessageBox.Show(look(), form, text, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public static DialogResult my_messageBox(string text, MessageBoxButtons buttons)
        {
            XtraMessageBox.AllowCustomLookAndFeel = true;
            return XtraMessageBox.Show(look(), text, "", buttons, MessageBoxIcon.Information);
        }
        public static DialogResult database_error_messageBox(string text)
        {
            XtraMessageBox.AllowCustomLookAndFeel = true;
            return classes.notifications_class.my_messageBox(text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void success_message()
        {
          
                OmarNotifications.Alert.ShowSucess("تمت العملية بنجاح");
            
        }
        public static void no_data_message()
        {
           
                OmarNotifications.Alert.ShowInformation("لا يوجد بيانات لطباعتها أو تصديرها");
           
        }
        public static void grid_message()
        {
           
                OmarNotifications.Alert.ShowInformation("لا يوجد بيانات لعرضها");
           
        }
        public static void select_data_message()
        {
            OmarNotifications.Alert.ShowInformation("الرجاء تحديد البيانات أولاً");
        }
    }

}
