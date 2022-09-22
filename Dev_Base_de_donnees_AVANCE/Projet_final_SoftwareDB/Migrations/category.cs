using MySql.Data.MySqlClient;

namespace Migrations;

public class category
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
            CREATE TABLE if not exists `category` (
            `idCategory` int PRIMARY KEY,
            `sort` varchar(75),
            `IsDeleted` BIT NOT NULL DEFAULT 0);", conn);
            createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists category;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into category value(1, 'Conversation Intelligence', 0);
            insert into category value(2, 'Product Analytics', 0);
            insert into category value(3, 'Sales Engagement', 0);
            insert into category value(4, 'Direct Mail Automation', 0);
            insert into category value(5, 'Java Integrated Development Environments (IDE)', 0);
            insert into category value(6, 'Sales Intelligence', 0);
            insert into category value(7, 'Computing platform operating environments', 0);
            insert into category value(8, 'Help Desk', 0);
            insert into category value(9, 'note-taking application', 0);
            insert into category value(10, 'Knowledge Base', 0);
            insert into category value(11, 'Image Manipulation Program', 0);
            ",conn);
            insertInto.ExecuteNonQuery();
    }    
}