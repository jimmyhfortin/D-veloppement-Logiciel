using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using MySql.Data.MySqlClient;

namespace migration;

public class telephones
{
    

    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
                CREATE TABLE if not exists `telephones` (
                    `id` int PRIMARY KEY,
                    `telephone` varchar(15),
                    `type_connection` varchar(10),
                    `individu_id` int,
                    foreign key (type_connection) references type_connections(id),
                    foreign key (individu_id) references individus(id))", conn
                );
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists telephones;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into telephones value(1, '418-485-9125', 'Cell', 1);
            insert into telephones value(2, '514-459-9631', 'Fax', 2);
            insert into telephones value(3, '514-569-8917', 'Fax', 3);
            insert into telephones value(4, '514-459-9631', 'Fax', 4);
            insert into telephones value(5, '418-485-9125', 'Cell', 5);
            insert into telephones value(6, '514-459-9631', 'Fax', 6);
            insert into telephones value(7, '514-569-8917', 'Fax', 7);
            insert into telephones value(8, '514-369-8438', 'Fax', 8);
            insert into telephones value(9, '418-485-9125', 'Cell', 9);
            insert into telephones value(10, '514-569-8917', 'Fax', 10);
            insert into telephones value(11, '514-459-9631', 'Fax', 11);
            insert into telephones value(12, '514-459-9631', 'Fax', 12);
            insert into telephones value(13, '418-485-9125', 'Cell', 13);
            insert into telephones value(14, '514-569-8917', 'Fax', 14);
            insert into telephones value(15, '514-459-9631', 'Fax', 15);
            insert into telephones value(16, '514-459-9631', 'Fax', 16);
            insert into telephones value(17, '418-485-9125', 'Cell', 17);
            insert into telephones value(18, '514-369-8438', 'Fax', 18);
            insert into telephones value(19, '514-459-9631', 'Fax', 19);
            insert into telephones value(20, '514-369-8438', 'Fax', 20);
            insert into telephones value(21, '418-485-9125', 'Cell', 21);
            insert into telephones value(22, '514-569-8917', 'Fax', 22);
            insert into telephones value(23, '514-459-9631', 'Fax', 23);
            insert into telephones value(24, '514-459-9631', 'Fax', 24);
            insert into telephones value(25, '514-569-8917', 'Fax', 25);
            insert into telephones value(26, '418-485-9125', 'Cell', 26);
            insert into telephones value(27, '514-459-9631', 'Fax', 27);
            insert into telephones value(28, '514-569-8917', 'Fax', 28);
            insert into telephones value(29, '514-459-9631', 'Fax', 29);
            insert into telephones value(30, '514-369-8438', 'Fax', 30);
            ",conn);
            insertInto.ExecuteNonQuery();
    }
    
    
}