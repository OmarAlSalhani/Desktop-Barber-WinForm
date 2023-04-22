using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace barber_app.classes
{
    class add_kshf_class
    {
        public static void customer_kshf(string customer_name,string statment,double value)
        {
            int customer_id = -1;
            DataTable get_id_table = connection_class.select($"select customer_id from customers_table where customer_name='{customer_name}'");
            if(get_id_table.Rows.Count!=0)
            {
                customer_id = Convert.ToInt32(get_id_table.Rows[0][0]);
            }
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            connection_class.command($"insert into customer_kshf_table (customer_id,statment,value,the_date,userID) values({customer_id},'{statment}',{value},'{date}','{const_variables_class.userID}')");
        }
    }
}
