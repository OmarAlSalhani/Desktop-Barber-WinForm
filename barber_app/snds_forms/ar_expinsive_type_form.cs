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

namespace barber_app.n_snds_forms.ar
{
    public partial class ar_expinsive_type_form : DevExpress.XtraEditors.XtraForm
    {
        public ar_expinsive_type_form()
        {
            InitializeComponent();
            my_grid_view_class.set_find_panel_font2(gridView1, gridControl1,false,true);
            my_grid_view_class.set_font_and_hover_effect(gridView1);
            my_grid_view_class.show_empty_message2(gridView1);
        }
        bool check_if_every_thing_ok()
        {

            if (texts_class.is_null(name_tb.Text.Trim()))
            {
                OmarNotifications.Alert.ShowInformation("الرجاء كتابة الأسم");
                return false;
            }
            if (!validate_class.is_text_less_then_300_char(name_tb.Text.Trim()))
            {
                return false;
            }
            return true;
        }
        private void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (check_if_every_thing_ok())
                {
                    connection_class.command($"insert into expinsivies_type_table values('{name_tb.Text.Trim()}')");
                    classes.notifications_class.success_message();
                    name_tb.Text= "";
                    run_worker_class.run(backgroundWorker1);

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("unique"))
                {
                    OmarNotifications.Alert.ShowInformation("السبب موجود مسبقاً");
                    name_tb.Text = "";
                }
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount != 0)
            {

                foreach (int i in gridView1.GetSelectedRows())
                {
                    int id = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.Columns[0].FieldName));
                    connection_class.command($"delete from expinsivies_type_table where id={id}");
                }
                notifications_class.success_message();
                run_worker_class.run(backgroundWorker1);
            }
            else
            {
                OmarNotifications.Alert.ShowInformation("الرجاء تحديد البيانات المراد حذفها");
                return;
            }
        }
        DataTable table;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            table = connection_class.select("select id as 'الرقم',name as 'السبب' from expinsivies_type_table");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            my_grid_view_class.set_datasource(gridControl1, gridView1, table);
        }

        private void ar_expinsive_type_form_Load(object sender, EventArgs e)
        {
            run_worker_class.run(backgroundWorker1);

        }
    }
}