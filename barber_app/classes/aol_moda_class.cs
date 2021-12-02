using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barber_app.classes
{
    class aol_moda_class
    {
        public static void update_customer_aol_moda(string customer_name, double value)
        {
            int id = -1;
            DataTable get_id_table = connection_class.select($"select customer_id from customers_table where customer_name=N'{customer_name}'");
            if (get_id_table.Rows.Count != 0)
            {
                id = Convert.ToInt32(get_id_table.Rows[0][0]);
            }
            connection_class.command($"update customers_table set rsed_aol_moda+={value} where customer_id={id}");
        }
        public static void update_supplier_aol_moda(string supplier_name, double value)
        {
            int id = -1;
            DataTable get_id_table = connection_class.select($"select id from morden_table where the_name=N'{supplier_name}'");
            if (get_id_table.Rows.Count != 0)
            {
                id = Convert.ToInt32(get_id_table.Rows[0][0]);
            }
            connection_class.command($"update morden_table set aol_moda+={value} where id={id}");
        }
        public static void update_doctor_aol_moda(string doctor_name, double value)
        {
            int id = -1;
            double profit = 0;
            DataTable get_id_table = connection_class.select($"select id,profit from doctors_table where doctor_name=N'{doctor_name}'");
            if (get_id_table.Rows.Count != 0)
            {
                id = Convert.ToInt32(get_id_table.Rows[0][0]);
                profit = Convert.ToDouble(get_id_table.Rows[0][1]);
            }
            connection_class.command($"update doctors_table set aol_moda+={value*(profit/100)} where id={id}");
        }
        public static void update_doctor_aol_moda_for_most7qat(string doctor_name, double value)
        {
            int id = -1;
            double profit = 0;
            DataTable get_id_table = connection_class.select($"select id,profit from doctors_table where doctor_name=N'{doctor_name}'");
            if (get_id_table.Rows.Count != 0)
            {
                id = Convert.ToInt32(get_id_table.Rows[0][0]);
                profit = Convert.ToDouble(get_id_table.Rows[0][1]);
            }
            connection_class.command($"update doctors_table set aol_moda+={value} where id={id}");
        }
    }
}
