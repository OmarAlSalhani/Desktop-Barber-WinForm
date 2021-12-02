using System;
using System.Data;
using System.Data.SqlClient;

namespace barber_app.classes
{
    class bank_class
    {        // method used to add log to logs table in database
        // parameters :
        // event_name : the event name that`s user make it
        public static void bank_log_add(string event_name, double rsed, string bank_name, bool is_dollar)
        {
            connection_class.connection();
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            DataTable curreny_table = connection_class.select($"select currency from bank_table where bank_name=N'{bank_name}'");
            SqlCommand command = new SqlCommand("insert into bank_logs_table values(@bank_event,@the_rsed,@the_date,@the_time,@employee_name,@bank_name)", connection_class.connection());
            command.Parameters.AddWithValue("@employee_name", classes.const_variables_class.username);
            command.Parameters.AddWithValue("@the_rsed", rsed);
            command.Parameters.AddWithValue("@the_time", DateTime.Now.ToString("hh:mm:ss tt"));
            command.Parameters.AddWithValue("@the_date", date);
            command.Parameters.AddWithValue("@bank_event", event_name);
            command.Parameters.AddWithValue("@bank_name", bank_name);
            command.ExecuteNonQuery();
        }
        public static void bank_value_increase(double value)
        {
            connection_class.connection();
            SqlCommand command = new SqlCommand("update bank_table set bank_value=bank_value+@bank_value where bank_name=@bank_name", connection_class.connection());
            command.Parameters.AddWithValue("@bank_value", value);
            command.Parameters.AddWithValue("@bank_name", settings_files.main_settings.Default.bank_name);
            command.ExecuteNonQuery();
        }
        public static void bank_value_decrease(double value)
        {
            connection_class.connection();
            DataTable curreny_table = connection_class.select($"select currency from bank_table where bank_name=N'{settings_files.main_settings.Default.bank_name}'");
            SqlCommand command = new SqlCommand("update bank_table set bank_value=bank_value-@bank_value where bank_name=@bank_name", connection_class.connection());
            command.Parameters.AddWithValue("@bank_value", value);
            command.Parameters.AddWithValue("@bank_name", settings_files.main_settings.Default.bank_name);
            command.ExecuteNonQuery();

        }
        public static double get_current_bank_value()
        {
            DataTable table = connection_class.select($"select isnull(bank_value,0),currency from bank_table where bank_name=N'{settings_files.main_settings.Default.bank_name}'");
            string string_val = table.Rows[0][0].ToString();
            double value = Convert.ToDouble(string_val);
            return value;
        }
    }
}
