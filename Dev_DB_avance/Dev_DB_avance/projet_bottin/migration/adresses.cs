using MySql.Data.MySqlClient;

namespace migration;

public class adresses
{
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
                CREATE TABLE if not exists`addresses` (
                    `Id` int PRIMARY KEY,
                    `addresse` varchar(30),
                    `ville_id` int,
                    `pays_id` int,
                    `province_id` int,
                    `individu_id` int,
                    foreign key (ville_id) references villes(id),
                    foreign key (pays_id) references pays(id),
                    foreign key (province_id) references provinces(id),
                    foreign key (individu_id) references individus(id))", conn
                );
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists addresses;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into addresses value(1, '1962 Brookside Drive', 1, 1, 1, 1);
            insert into addresses value(2, '7896 Av Wellington', 2, 2, 2, 2);
            insert into addresses value(3, '3505 Green Acres Road', 1, 1, 1, 3);
            insert into addresses value(4, '1463 Augusta Park', 2, 2, 2, 4);
            insert into addresses value(5, '3896 Cherry Camp Road', 1, 1, 1, 5);
            insert into addresses value(6, '4502 Cedar Lane', 2, 2, 2, 6);
            insert into addresses value(7, '304 Dovetail Estates', 1, 1, 1, 7);
            insert into addresses value(8, '4963 Morningview Lane', 2, 2, 2, 8);
            insert into addresses value(9, '2281 Ethels Lane', 1, 1, 1, 9);
            insert into addresses value(10, '4969 McKinley Avenue', 2, 2, 2, 10);
            insert into addresses value(11, '3771 Sherwood Circle', 1, 1, 1, 11);
            insert into addresses value(12, '1104 Brown Street', 2, 2, 2, 12);
            insert into addresses value(13, '2733 Alpha Avenue', 1, 1, 1, 13);
            insert into addresses value(14, '1896 Hillcrest Avenue', 2, 2, 2, 14);
            insert into addresses value(15, '2190 Eagle Lane', 1, 1, 1, 15);
            insert into addresses value(16, '2778 Snyder Avenue', 2, 2, 2, 16);
            insert into addresses value(17, '2402 Hall Street', 1, 1, 1, 17);
            insert into addresses value(18, '1410 Parkway Street', 2, 2, 2, 18);
            insert into addresses value(19, '513 Big Elm', 1, 1, 1, 19);
            insert into addresses value(20, '1950 Elliott Street', 2, 2, 2, 20);
            insert into addresses value(21, '4601 West Street', 1, 1, 1, 21);
            insert into addresses value(22, '2059 Tipple Road', 2, 2, 2, 22);
            insert into addresses value(23, '2789 Saint James Drive', 1, 1, 1, 23);
            insert into addresses value(24, '39 Seneca Drive', 2, 2, 2, 24);
            insert into addresses value(25, '868 Grove Avenue', 1, 1, 1, 25);
            insert into addresses value(26, '2083 Hewes Avenue', 2, 2, 2, 26);
            insert into addresses value(27, '1460 Valley Drive', 1, 1, 1, 27);
            insert into addresses value(28, '3503 New Creek Road', 2, 2, 2, 28);
            insert into addresses value(29, '4571 Maxwell Street', 1, 1, 1, 29);
            insert into addresses value(30, '3451 Blane Street', 2, 2, 2, 30);
            ",conn);
            insertInto.ExecuteNonQuery();
    }
}