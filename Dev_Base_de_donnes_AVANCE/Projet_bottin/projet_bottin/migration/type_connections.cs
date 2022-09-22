using MySql.Data.MySqlClient;

namespace migration;

public class type_connections
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
                CREATE TABLE if not exists `type_connections` (`id` varchar(10) PRIMARY KEY,`type` varchar(10));
                ", conn);
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists type_connections;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into type_connections value('Cell', 'cellulaire');
            insert into type_connections value('Maison', 'Maison');
            insert into type_connections value('Fax', 'fax');
            ",conn);
            insertInto.ExecuteNonQuery();
    }
}