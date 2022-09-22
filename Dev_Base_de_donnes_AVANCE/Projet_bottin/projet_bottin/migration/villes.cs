using MySql.Data.MySqlClient;

namespace migration;

public class villes
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
                CREATE TABLE if not exists `villes` (
                    `id` int PRIMARY KEY,
                    `nom` varchar(50),
                    `province_id` int,
                    foreign key (province_id) references provinces(id))", conn
                );
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists villes;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into villes value(
                1, 'Shawinigan', 1);
                insert into villes value(
                2, 'Montreal', 2)",conn);
            insertInto.ExecuteNonQuery();
    }
}