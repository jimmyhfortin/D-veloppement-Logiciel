using migration;

namespace Model;

using MySql.Data.MySqlClient;

public class PrintModel
{
    public static void Print(MySqlConnection conn, int count, int pageEnCours, double NbPage)//Afficher l'interface
    {
        double countPage = count / 10;
        Console.Clear();
        Console.WriteLine($"Nombre de contact total: {count}\n\nId | Nom complet | Telephone principal |");
        foreach (var individus in IndividusModel.SelectPage(conn, pageEnCours))
        {
            Console.WriteLine(individus);
        }
        
        if (IndividusModel.SelectA(conn, pageEnCours-1).Count < 10)
        {
            Console.WriteLine($"Vous etes sur la derniere page");
            Console.Write("\nOption disponible: [2]Precedent, [3]Afficher (Id), [4]Supprimer (Id), [5]Quitter \n> commande : ");
        }
        else if (pageEnCours == 1)
        {
            Console.WriteLine($"Page : {pageEnCours}/{countPage}");
            Console.Write("\nOption disponible: [1]Suivant, [3]Afficher (Id), [4]Supprimer (Id), [5]Quitter \n> commande : ");
        }
        else
        {
            Console.WriteLine($"Page : {pageEnCours}/{countPage}");
            Console.Write("\nOption disponible: [1]Suivant, [2]Precedent, [3]Afficher (Id), [4]Supprimer (Id), [5]Quitter \n> commande : ");
        }
            
    }

    public static void SelectId(MySqlConnection conn, int count) //Afficher Id selectionnee
    {
        Console.Write($"Entrer l'Id a afficher : ");
        int idInput = int.Parse(Console.ReadLine());
        IndividusModel individuList = IndividusModel.Select(conn, idInput);
        if (idInput > 0 && idInput <= count)
        {
            Console.Clear();
            Console.WriteLine(
                $"\nId : {idInput}\nNom complet : {individuList.Prenom} {individuList.Nom}\nTelephones :");
            foreach (var tel in telephonesModel.select(conn, idInput))
            {
                Console.WriteLine(tel);
            }

            Console.WriteLine($"\nAdresses :");
            foreach (var adresse in adressesModel.Select(conn, idInput))
            {
                Console.WriteLine(adresse);
            }

            Console.WriteLine($"\nNotes :");
            foreach (var note in NotesModel.Select(conn, idInput))
            {
                Console.WriteLine(note);
            }

            Console.WriteLine($"\nInformation additionnelles :\n{individuList.InfoAdd}");
            Console.WriteLine("\nappuyer sur une touche pour revenir en arriere");

        }
        else
        {
            Console.WriteLine($"Error this Id doesn't exist");
        }
    }
    public static void DeleteId(MySqlConnection conn, int count)// Supprimer l'Id selectionnee
    {
        Console.Write($"Entrer l'Id a supprimer : ");
        int idInput = int.Parse(Console.ReadLine());
        if (idInput > 0 && idInput <= count)
        {
            MySqlCommand supprimerIndividu = new MySqlCommand
                ($"delete FROM notes WHERE individu_id = {idInput};" +
                 $"delete FROM addresses WHERE individu_id = {idInput};" +
                 $"delete FROM telephones WHERE individu_id = {idInput};" +
                 $"delete FROM individus WHERE id = {idInput};", conn);
            supprimerIndividu.ExecuteNonQuery();
            Console.WriteLine($"Individu {idInput} supprimer");
            Console.WriteLine("\nappuyer sur une touche pour revenir en arriere");
        }
        else if (!(idInput > 0 && idInput <= count))
        {
            Console.WriteLine($"Error this Id doesn't exist");
            Console.WriteLine("\nappuyer sur une touche pour revenir en arriere");
        }
        else
        {
            Console.WriteLine("\nappuyer sur une touche pour revenir en arriere");
        }
    }
    public static int InputInt(int start, int end)
    {
        while (true)
        {
            try
            {
                int result = int.Parse(Console.ReadLine());
                if (result >= start && result <= end)
                {
                    return result;
                }

                Console.WriteLine($"Le nombre doit être entre {start} et {end} inclusivement");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Vous devez entrer un nombre entre {start} et {end} inclusivement ");
            }
        }
    }
}   