using MySql.Data.MySqlClient;

namespace migration;

public class pays
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
                CREATE TABLE if not exists `pays` (
                    `id` int PRIMARY KEY,
                    `nom` varchar(50))", conn
                );
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists pays;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into pays values(
                1, 'Canada');
                insert into pays values(
                2, 'Etats-Unis')",conn);
            insertInto.ExecuteNonQuery();
    }
}