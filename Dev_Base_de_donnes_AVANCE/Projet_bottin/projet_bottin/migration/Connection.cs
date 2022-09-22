using MySql.Data.MySqlClient;

namespace migration;

public class Connection
{
    public static MySqlConnection Conn()
    {
        MySql.Data.MySqlClient.MySqlConnection conn = null;
        string myConnectionString;
        myConnectionString = "server=127.0.0.1;uid=root;" +
                             "pwd=(Metallica)00;database=bottin";
        try
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
            return conn;
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Console.WriteLine("Error the program is unable to connect to the database!");
        }

        return null;
    }
}