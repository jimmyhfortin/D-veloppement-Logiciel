using MySql.Data.MySqlClient;

namespace Migrations;

public class Connection
{
    public MySqlConnection conn { get; private set; }

    public Connection()
    {
        string myConnectionString;
        myConnectionString = "server=127.0.0.1;uid=root;" +
                             "pwd=dev;database=dev";

        try
        {
            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;
        }
        catch (MySqlException ex)
        {
            Console.WriteLine("Error the program is unable to connect to the database!");
        }
    }

    public void open()
    {
        conn.Open();
    }

    public void close()
    {
        conn.Close();
    }
}