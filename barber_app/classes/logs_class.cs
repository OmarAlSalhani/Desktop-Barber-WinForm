using System;
using System.Data.SqlClient;
using System.Data.SQLite;
namespace barber_app.classes
{
    ///what done :
    ///all banks
    ///add company
    ///all warehouses
    ///all users

    /// <summary>
    /// this class used for add logs to database about users events
    /// </summary>
    class logs_class
    {
        // method used to add log to logs table in database
        // parameters :
        // event_name : the event name that`s user make it
        public static void log_add(string event_name,int event_number,string event_screen)
        {
            connection_class.connection();
            SQLiteCommand command = new SQLiteCommand($"insert into black_box_table (userID,event_name,event_date,event_time,event_screen) values({classes.const_variables_class.userID},'{event_name}','{DateTime.Now.ToString("dd-MM-yyyy")}','{DateTime.Now.ToString("hh:mm:ss tt")}','{event_screen}')", connection_class.connection());
            command.ExecuteNonQuery();
        }
    }
}