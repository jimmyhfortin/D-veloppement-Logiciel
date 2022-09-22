using System.Threading.Channels;
using System.Xml;
using migration;
using Model;
using MySql.Data.MySqlClient;

//Livrable_1____________________________________________________________________________________________________________
MySqlConnection conn = Connection.Conn(); //Connection to MySQL database

void migrateAll(MySqlConnection conn)
{
    relations.migrate(conn);
    type_connections.migrate(conn);
    pays.migrate(conn);
    provinces.migrate(conn);
    villes.migrate(conn);
    individus.migrate(conn);
    telephones.migrate(conn);
    notes.migrate(conn);
    adresses.migrate(conn);
}

void rollbackAll(MySqlConnection conn)
{
    adresses.rollback(conn);
    notes.rollback(conn);
    telephones.rollback(conn);
    individus.rollback(conn);
    villes.rollback(conn);
    provinces.rollback(conn);
    pays.rollback(conn);
    type_connections.rollback(conn);
    relations.rollback(conn);
}

void seedAll(MySqlConnection conn)
{
    pays.seed(conn);
    provinces.seed(conn);
    villes.seed(conn);
    relations.seed(conn);
    type_connections.seed(conn);
    individus.seed(conn);
    telephones.seed(conn);
    notes.seed(conn);
    adresses.seed(conn);
}


if (args.Length == 0)
{
    Console.WriteLine("No arguments provided");
}
else //Verification des arguments 
{
    if (args[0] == "--rollback" || args[0] == "--seed" || args[0] == "--migrate")
    {
        rollbackAll(conn);
        migrateAll(conn);
        seedAll(conn);
    }
    
    else
    {
        Console.WriteLine("Argument provided : " + args.Length);
        foreach (var argument in args)
        {
            Console.WriteLine(argument);


            // If statment for the argument choice

            if (argument == "--migrate")
            {
                Console.WriteLine("Migration started");
                migrateAll(conn);
                Console.WriteLine("All tables created");
            }

            if (argument == "--rollback")
            {
                Console.WriteLine("RollBack Started");
                rollbackAll(conn);
                Console.WriteLine("All tables deleted");
            }

            if (argument == "--refresh")
            {
                Console.WriteLine("refresh started deleting the database started");
                rollbackAll(conn);
                Console.WriteLine("database deleted");
                Console.WriteLine("re-create fresh database started");
                migrateAll(conn);
                Console.WriteLine("database re-created");
            }

            if (argument == "--seed")
            {
                Console.WriteLine("seed started");
                seedAll(conn);
                Console.WriteLine("all data seeded");
            }
        }
    }

//Livrable_2____________________________________________________________________________________________________________
    int countIndividus = IndividusModel.SelectAll(conn).Count;
    double NbPage = Math.Round((double) (IndividusModel.SelectAll(conn).Count / 10));
    Console.WriteLine(NbPage);
    string input = null;
    int pageEnCours = 1;
    PrintModel.Print(conn, countIndividus, 1, 1);
    int inputInt = PrintModel.InputInt(1, 5);
    while (inputInt != 5)
    {
        switch (inputInt)
        {
            case 1:
                pageEnCours++;
                countIndividus = IndividusModel.SelectAll(conn).Count;
                PrintModel.Print(conn, countIndividus, pageEnCours, NbPage);
                inputInt = PrintModel.InputInt(1, 5);
                break;
            case 2:
                pageEnCours--;
                countIndividus = IndividusModel.SelectAll(conn).Count;
                PrintModel.Print(conn, countIndividus, pageEnCours, NbPage);
                inputInt = PrintModel.InputInt(1, 5);
                break;
            case 3:
                countIndividus = IndividusModel.SelectAll(conn).Count;
                PrintModel.SelectId(conn, countIndividus);
                input = Console.ReadLine();
                PrintModel.Print(conn, countIndividus, pageEnCours, NbPage);
                inputInt = PrintModel.InputInt(1, 5);
                break;
            case 4:
                countIndividus = IndividusModel.SelectAll(conn).Count;
                PrintModel.DeleteId(conn, countIndividus);
                input = Console.ReadLine();
                PrintModel.Print(conn, countIndividus, pageEnCours, NbPage);
                inputInt = PrintModel.InputInt(1, 5);
                break;
        }
    }

    conn.Close();
    // End of the program
}