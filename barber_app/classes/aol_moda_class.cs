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
            DataTable get_id_table = connection_class.select($"select customer_id from customers_table where customer_name='{customer_name}'");
            if (get_id_table.Rows.Count != 0)
            {
                id = Convert.ToInt32(get_id_table.Rows[0][0]);
            }
            connection_class.command($"update customers_table set rsed_aol_moda=rsed_aol_moda+{value} where customer_id={id}");
        }
    }
}
