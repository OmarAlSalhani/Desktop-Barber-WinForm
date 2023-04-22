using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace barber_app.classes
{
    // this class used for perform commands in database like
    // connection , CRUD
    public class connection_class
    {


        // method used to set connection string , handle connection and open connection with database
        public static SQLiteConnection connection()
        {
            try
            {
                var path = Path.GetDirectoryName(
      System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                path = path.Substring(6);
                string database = path + @"\barber_database.db";
                SQLiteConnection con = new SQLiteConnection($@"Data Source={database}");
                con.Open();
                if (con.State != ConnectionState.Open)
                {
                    con.Open();
                }
                return con;
            }
            catch (Exception Ex)
            {
                classes.notifications_class.my_messageBox(Ex.Message);
                return null;
            }

        }
        public static bool check_connection()
        {
            if (connection() is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // method used to excute command on database
        // the command type is simple query with zero parameter
        // parameters :
        // query : the query statment
        public static int command(string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, connection());
            return command.ExecuteNonQuery();

        }
        // method used to excute select command on database and return DataTable
        // the command type is simple query with zero parameter
        // parameters :
        // query : the query statment
        public static DataTable select(string query)
        {
            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection());
                DataTable table = new DataTable();
                table.Clear();
                adapter.Fill(table);
                return table;
            }
            catch (Exception Ex)
            {
                classes.notifications_class.my_messageBox(Ex.Message);
                return null;
            }
        }
    }
}
