using MySql.Data.MySqlClient;

namespace Migrations;

public class owner
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
            CREATE TABLE if not exists `owner` (
            `idOwner` varchar(100) PRIMARY KEY,
            `owner` varchar(100),
            `IsDeleted` BIT NOT NULL DEFAULT 0);", conn);
            createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists owner;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into owner values('Hellman & Friedman and Permira', 'Hellman & Friedman and Permira', 0);
            insert into owner values('Amit Bendov', 'Amit Bendov', 0);
            insert into owner values('Automattic', 'Automattic', 0);
            insert into owner values('Mikkel Svane - CEO & Founder', 'Mikkel Svane - CEO & Founder', 0);
            insert into owner values('Spenser Skates', 'Spenser Skates', 0);
            insert into owner values('Roy Raanani', 'Roy Raanani', 0);
            insert into owner values('Atlassian.inc', 'Atlassian.inc', 0);
            insert into owner values('Microsoft.inc', 'Microsoft.inc', 0);
            insert into owner values('Tim Zheng - Founder', 'Tim Zheng - Founder', 0);
            insert into owner values('Kyle Porter', 'Kyle Porter', 0);
            insert into owner values('Kris Rudeegraap', 'Kris Rudeegraap', 0);
            insert into owner values('none', 'none', 0);
            ", conn);
            insertInto.ExecuteNonQuery();
    }
}