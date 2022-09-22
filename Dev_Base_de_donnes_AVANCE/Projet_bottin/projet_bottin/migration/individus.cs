using MySql.Data.MySqlClient;

namespace migration;

public class individus
{
    
    public static void migrate(MySqlConnection conn)
    {
        MySqlCommand createTable = new MySqlCommand(@"
                CREATE TABLE if not exists `individus` (`id` int PRIMARY KEY,`nom` varchar(50),`prenom` varchar(50),`relation_id` int,`information_additionnelle` text,foreign key (relation_id) references relations(id));
                ", conn);
        createTable.ExecuteNonQuery();
    }

    public static void rollback(MySqlConnection conn)
    {
        MySqlCommand deleteTable = new MySqlCommand("drop table if exists individus;", conn);
        deleteTable.ExecuteNonQuery();
    }
    
    public static void seed(MySqlConnection conn)
    {
        MySqlCommand insertInto = new MySqlCommand(@"
            insert into individus value(1, 'Eulogius', 'Gamal', 1, 'Ne pas deranger la fds');
            insert into individus value(2, 'Aucaman', 'Aida', 2, 'Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page');
            insert into individus value(3, 'Penelope', 'Aleksander', 1, 'Ne pas deranger la fds');
            insert into individus value(4, 'Ramakrishna', 'Reagan', 3, 's/o');
            insert into individus value(5, 'Christina', 'Daniyal', 1, 'Ne pas deranger la fds');
            insert into individus value(6, 'Jep', 'Sibonakaliso', 2, 'Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page');
            insert into individus value(7, 'Catharina', ' Eli', 3, 'Ne pas deranger la fds');
            insert into individus value(8, 'Siva', ' Larisa', 2, 's/o');
            insert into individus value(9, 'Murtaza', 'Akantha', 1, 'Ne pas deranger la fds');
            insert into individus value(10, 'Ecim', 'Zhelimir', 3, 'Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page');
            insert into individus value(11, 'Allegra', ' Mair', 3, 'Ne pas deranger la fds');
            insert into individus value(12, 'Gennarino', 'Kepa', 2, 's/o');
            insert into individus value(13, 'Milogost', 'Curt', 1, 'Ne pas deranger la fds');
            insert into individus value(14, 'Daniela', 'Giacomina', 2, 'Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page');
            insert into individus value(15, 'Fearghas', 'Emmitt', 1, 'Ne pas deranger la fds');
            insert into individus value(16, 'Charissa', 'Zhivko', 2, 's/o');
            insert into individus value(17, 'Roald', 'Wekesa', 1, 'Ne pas deranger la fds');
            insert into individus value(18, 'Lidmila', 'Benita', 2, 's/o');
            insert into individus value(19, 'Jehohanan', ' Ippolit', 3, 'Ne pas deranger la fds');
            insert into individus value(20, 'Bohumil', 'Ronit', 2, 'Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page');
            insert into individus value(21, 'Alcippe', 'Shyamala', 1, 'Ne pas deranger la fds');
            insert into individus value(22, 'Vijay', 'Markuss', 2, 's/o');
            insert into individus value(23, 'Xabier', ' Gallcobar', 3, 'Ne pas deranger la fds');
            insert into individus value(24, 'Hadi', 'Rozalija', 2, 's/o');
            insert into individus value(25, 'Echo', 'Suzan', 1, 'Ne pas deranger la fds');
            insert into individus value(26, 'Sona', 'Riderch', 2, 'Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page');
            insert into individus value(27, 'Achilles', 'Vasuda', 1, 'Ne pas deranger la fds');
            insert into individus value(28, 'Golshan', 'Gerrard', 2, 'Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page');
            insert into individus value(29, 'Budur', 'Antonija', 3, 'Ne pas deranger la fds');
            insert into individus value(30, 'Zenon', 'Rafaela', 2, 'Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page');
            ",conn);
            insertInto.ExecuteNonQuery();
            
    }

    
}