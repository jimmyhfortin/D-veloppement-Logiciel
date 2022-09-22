using System;
using Migrations;
using Model;
using MySql.Data.MySqlClient;
using System;

namespace Projet_final_SoftwareDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Connection sqlConn = new Connection();

            void migrateAll()
            {
                owner.migrate(sqlConn.conn);
                category.migrate(sqlConn.conn);
                software.migrate(sqlConn.conn);
                website.migrate(sqlConn.conn);
            }

            void rollbackAll()
            {
                website.rollback(sqlConn.conn);
                software.rollback(sqlConn.conn);
                owner.rollback(sqlConn.conn);
                category.rollback(sqlConn.conn);
            }

            void seedAll()
            {
                category.seed(sqlConn.conn);
                owner.seed(sqlConn.conn);
                software.seed(sqlConn.conn);
                website.seed(sqlConn.conn);
            }


            if (args.Length == 0)
            {
                Console.WriteLine("Starting Program.... Menus are loading....");
                Console.WriteLine();

                try
                {
                    {
                        DisplayController();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            else
            {
                Console.WriteLine("Arguments provided: " + args.Length);

                if (args.Contains("--rollback"))
                {
                    sqlConn.open();
                    Console.WriteLine("Rollback");
                    Console.WriteLine("RollBack Started");
                    rollbackAll();
                    Console.WriteLine("All tables deleted");
                    sqlConn.close();
                    ;
                }

                if (args.Contains("--migrate"))
                {
                    sqlConn.open();
                    Console.WriteLine("Migrate");
                    Console.WriteLine("Migration started");
                    migrateAll();
                    Console.WriteLine("All tables created");
                    sqlConn.close();
                }

                if (args.Contains("--refresh"))
                {
                    sqlConn.open();
                    Console.WriteLine("Refresh");
                    Console.WriteLine("refresh started deleting the database started");
                    rollbackAll();
                    Console.WriteLine("database deleted");
                    Console.WriteLine("re-create fresh database started");
                    migrateAll();
                    Console.WriteLine("database re-created");
                    sqlConn.close();
                }

                if (args.Contains("--seed"))
                {
                    sqlConn.open();
                    Console.WriteLine("Seed");
                    Console.WriteLine("seed started");
                    seedAll();
                    Console.WriteLine("all data seeded");
                    sqlConn.close();
                }
            }

            
            void DisplayController()
            {
                sqlConn.open();
                int countIndividus = SoftwareModel.SelectAll(sqlConn.conn).Count;
                int pageEnCours = 1;
                PrintModel.Print(sqlConn.conn, countIndividus, 1);
                int inputInt = PrintModel.InputInt(1, 7);
                while (inputInt != 7)
                {
                    switch (inputInt)
                    {
                        case 1: //suivant
                            pageEnCours++;
                            countIndividus = SoftwareModel.SelectAll(sqlConn.conn).Count;
                            PrintModel.Print(sqlConn.conn, countIndividus, pageEnCours);
                            inputInt = PrintModel.InputInt(1, 7);
                            break;
                        case 2: //precedent
                            pageEnCours--;
                            countIndividus = SoftwareModel.SelectAll(sqlConn.conn).Count;
                            PrintModel.Print(sqlConn.conn, countIndividus, pageEnCours);
                            inputInt = PrintModel.InputInt(1, 7);
                            break;
                        case 3: //revenir page 1
                            countIndividus = SoftwareModel.SelectAll(sqlConn.conn).Count;
                            PrintModel.Print(sqlConn.conn, countIndividus, 1);
                            pageEnCours = 1;
                            inputInt = PrintModel.InputInt(1, 7);
                            break;
                        case 4: //afficher id
                            countIndividus = SoftwareModel.SelectAll(sqlConn.conn).Count;
                            PrintModel.SelectId(sqlConn.conn, countIndividus);
                            countIndividus = SoftwareModel.SelectAll(sqlConn.conn).Count;
                            PrintModel.Print(sqlConn.conn, countIndividus, 1);
                            inputInt = PrintModel.InputInt(1, 7);
                            break;
                        case 5: //supprimer id
                            countIndividus = SoftwareModel.SelectAll(sqlConn.conn).Count;
                            PrintModel.DeleteId(sqlConn.conn, countIndividus);
                            countIndividus = SoftwareModel.SelectAll(sqlConn.conn).Count;
                            PrintModel.Print(sqlConn.conn, countIndividus, pageEnCours);
                            inputInt = PrintModel.InputInt(1, 7);
                            break;
                        case 6: //inserer id
                            PrintModel.InsertSoftware(sqlConn.conn);
                            countIndividus = SoftwareModel.SelectAll(sqlConn.conn).Count;
                            PrintModel.Print(sqlConn.conn, countIndividus, pageEnCours);
                            inputInt = PrintModel.InputInt(1, 7);
                            break;
                        default:
                            Console.WriteLine("Commande inconnue");
                            break;
                    }
                }

                sqlConn.close();
                //fin du programme
            }
        }
    }
}