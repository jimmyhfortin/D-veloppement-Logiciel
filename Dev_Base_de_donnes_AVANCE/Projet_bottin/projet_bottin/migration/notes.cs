using MySql.Data.MySqlClient;

namespace migration;

public class notes
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
                CREATE TABLE if not exists`notes` (
                    `id` int PRIMARY KEY,
                    `individu_id` int,
                    `note` varchar(50),
                    `created_at` date,
                    foreign key (individu_id) references individus(id))", conn
                );
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists notes;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into notes value(1, 1, 'littattiwemme-2712@yopmail.com', '2022-06-15');
            insert into notes value(2, 2, 'hamurefricrou-2585@yopmail.com', '2022-01-25');
            insert into notes value(3, 3, 'quejoraheiprau-2799@yopmail.com', '2022-06-15');
            insert into notes value(4, 4, 'crafrennagrausa-1401@yopmail.com', '2022-01-25');
            insert into notes value(5, 5, 'grauzeigrowepra-6959@yopmail.com', '2022-06-15');
            insert into notes value(6, 6, 'kibrisikuyu-4509@yopmail.com', '2022-01-25');
            insert into notes value(7, 7, 'mopazulleku-1052@yopmail.com', '2022-06-15');
            insert into notes value(8, 8, 'frajocuttana-2588@yopmail.com', '2022-01-25');
            insert into notes value(9, 9, 'setejuppiku-1803@yopmail.com', '2022-06-15');
            insert into notes value(10, 10, 'progudulauwo-4540@yopmail.com', '2022-01-25');
            insert into notes value(11, 11, 'nuppuneppomo-8352@yopmail.com', '2022-06-15');
            insert into notes value(12, 12, 'zoppegoilleitte-2266@yopmail.com', '2022-01-25');
            insert into notes value(13, 13, 'trobroipragrimou-8913@yopmail.com', '2022-06-15');
            insert into notes value(14, 14, 'freukellouseppe-7269@yopmail.com', '2022-01-25');
            insert into notes value(15, 15, 'tikusahecra-1281@yopmail.com', '2022-06-15');
            insert into notes value(16, 16, 'leuttigoumokeu-5199@yopmail.com', '2022-01-25');
            insert into notes value(17, 17, 'depriteumoute-1783@yopmail.com', '2022-06-15');
            insert into notes value(18, 18, 'jemammeunule-6615@yopmail.com', '2022-01-25');
            insert into notes value(19, 19, 'rebeufaummelau-4654@yopmail.com', '2022-06-15');
            insert into notes value(20, 20, 'feigibazeila-8575@yopmail.com', '2022-01-25');
            insert into notes value(21, 21, 'pifaugraxoitte-3787@yopmail.com', '2022-06-15');
            insert into notes value(22, 22, 'titidduppogri-2370@yopmail.com', '2022-01-25');
            insert into notes value(23, 23, 'prauhattoriri-8182@yopmail.com', '2022-06-15');
            insert into notes value(24, 24, 'rouprelolleitrau-4314@yopmail.com', '2022-01-25');
            insert into notes value(25, 25, 'wabogrehawo-1362@yopmail.com', '2022-06-15');
            insert into notes value(26, 26, 'sibeprevatra-3730@yopmail.com', '2022-01-25');
            insert into notes value(27, 27, 'ciwoifretoppe-2721@yopmail.com', '2022-06-15');
            insert into notes value(28, 28, 'keugrehellacru-8527@yopmail.com', '2022-01-25');
            insert into notes value(29, 29, 'pemmillaheceu-2788@yopmail.com', '2022-06-15');
            insert into notes value(30, 30, 'guhannemouce-3625@yopmail.com', '2022-01-25');
            ",conn);
            insertInto.ExecuteNonQuery();
    }
}