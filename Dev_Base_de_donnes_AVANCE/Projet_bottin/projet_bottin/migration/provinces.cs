using MySql.Data.MySqlClient;

namespace migration;

public class provinces
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
                CREATE TABLE if not exists `provinces` (
                    `id` int PRIMARY KEY,
                    `nom` varchar(50),
                    `pays_id` int,
                    foreign key (pays_id) references pays(id))", conn
                );
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists provinces;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into provinces value(
                1, 'Quebec', 1);
                insert into provinces value(
                2, 'Ontario', 1)",conn);
            insertInto.ExecuteNonQuery();
    }
}