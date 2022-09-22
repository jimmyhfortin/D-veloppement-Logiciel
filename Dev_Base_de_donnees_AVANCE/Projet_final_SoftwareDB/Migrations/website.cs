using MySql.Data.MySqlClient;

namespace Migrations;

public class website
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
            CREATE TABLE if not exists `website` (
            `idWebsite` int PRIMARY KEY,
            `website` varchar(100),
            `softwareId` int,
            `IsDeleted` BIT NOT NULL DEFAULT 0,
            foreign key (softwareId) references software(id));
            ", conn);
            createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists website;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into website value(1 , 'https://www.gong.io/product/', 1, 0);
            insert into website value(2 , 'https://simplenote.com/', 2, 0);
            insert into website value(3, 'https://www.zendesk.com/', 3, 0);
            insert into website value(4 , 'https://amplitude.com/', 4, 0);
            insert into website value(5 , 'https://www.zoominfo.com/products/chorus', 5, 0);
            insert into website value(6 , 'https://www.atlassian.com/software/confluence', 6, 0);
            insert into website value(7 , 'https://visualstudio.microsoft.com/fr/', 7, 0);
            insert into website value(8 , 'https://www.apollo.io/', 8, 0);
            insert into website value(9 , 'https://sendoso.com/', 9, 0);
            insert into website value(10 , 'https://salesloft.com/', 10, 0);
            insert into website value(11 , 'https://amplitude.com/', 11, 0);
            insert into website value(12 , 'https://www.zoominfo.com/products/chorus', 12, 0);
            insert into website value(13 , 'https://www.atlassian.com/software/confluence', 13, 0);
            insert into website value(14 , 'https://visualstudio.microsoft.com/fr/', 14, 0);
            insert into website value(15 , 'https://www.apollo.io/', 15, 0);
            insert into website value(16 , 'https://www.gong.io/product/', 16, 0);
            insert into website value(17 , 'https://simplenote.com/', 17, 0);
            insert into website value(18, 'https://www.zendesk.com/', 18, 0);
            insert into website value(19 , 'https://amplitude.com/', 19, 0);
            insert into website value(20 , 'https://www.zoominfo.com/products/chorus', 20, 0);
            insert into website value(21 , 'https://www.apollo.io/', 21, 0);
            insert into website value(22 , 'https://sendoso.com/', 22, 0);
            insert into website value(23 , 'https://salesloft.com/', 23, 0);
            insert into website value(24 , 'https://www.gong.io/product/', 24, 0);
            insert into website value(25 , 'https://simplenote.com/', 25, 0);
            insert into website value(26, 'https://www.zendesk.com/', 26, 0);
            insert into website value(27 , 'https://amplitude.com/', 27, 0);
            insert into website value(28 , 'https://www.zoominfo.com/products/chorus', 28, 0);
            insert into website value(29 , 'https://www.atlassian.com/software/confluence', 29, 0);
            insert into website value(30 , 'https://visualstudio.microsoft.com/fr/', 30, 0);
            ",conn);
            insertInto.ExecuteNonQuery();
    }    
}