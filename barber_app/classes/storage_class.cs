using System;
using System.Data;
using System.Data.SqlClient;
namespace barber_app.classes
{
    class storage_class
    {
        // method used to add log to logs table in database
        // parameters :
        // event_name : the event name that`s user make it
        public static void storage_log_add(string event_name, double rsed, string storage_name)
        {
            DataTable getIdTable = connection_class.select($"select id from storage_table where storage_name=N'{storage_name}'");
            int id = 0;
            if(getIdTable.Rows.Count!=0)
            {
                id = Convert.ToInt32(getIdTable.Rows[0][0]);
            }
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            connection_class.connection();
            SqlCommand command = new SqlCommand("insert into storage_logs_table values(@storage_event,@the_rsed,@the_date,@the_time,@employee_name,@storage_id)", connection_class.connection());
            command.Parameters.AddWithValue("@employee_name", classes.const_variables_class.username);
            command.Parameters.AddWithValue("@the_rsed", rsed);
            command.Parameters.AddWithValue("@the_time", DateTime.Now.ToString("hh:mm:ss tt"));
            command.Parameters.AddWithValue("@the_date", date);
            command.Parameters.AddWithValue("@storage_event", event_name);
            command.Parameters.AddWithValue("@storage_id", id);
            command.ExecuteNonQuery();
        }
        public static void storage_value_increase(double value)
        {
            connection_class.connection();
            SqlCommand command = new SqlCommand("update storage_table set storage_value=storage_value+@storage_value where storage_name=@storage_name", connection_class.connection());
            command.Parameters.AddWithValue("@storage_value", value);
            command.Parameters.AddWithValue("@storage_name", settings_files.main_settings.Default.storage_name);
            command.ExecuteNonQuery();
        }
        public static void storage_value_decrease(double value)
        {
            connection_class.connection();
            SqlCommand command = new SqlCommand("update storage_table set storage_value=storage_value-@storage_value where storage_name=@storage_name", connection_class.connection());
            command.Parameters.AddWithValue("@storage_value", value);
            command.Parameters.AddWithValue("@storage_name", settings_files.main_settings.Default.storage_name);
            command.ExecuteNonQuery();

        }
        public static double get_current_storage_value()
        {
            DataTable table = connection_class.select($"select isnull(storage_value,0) from storage_table where storage_name=N'{settings_files.main_settings.Default.storage_name}'");
            string string_val = table.Rows[0][0].ToString();
            double value = Convert.ToDouble(string_val);
            return value;

        }
    }
}
