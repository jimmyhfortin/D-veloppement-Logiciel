using MySql.Data.MySqlClient;

namespace migration;

public class relations
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
                CREATE TABLE if not exists `relations` (`id` int PRIMARY KEY,`nom` varchar(50));
                ", conn);
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists relations;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into relations value(1, 'Professionnel');
            insert into relations value(2, 'Famille');
            insert into relations value(3, 'Amies');
            ",conn);
            insertInto.ExecuteNonQuery();
    }
}