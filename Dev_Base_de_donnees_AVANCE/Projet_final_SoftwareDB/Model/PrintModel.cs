using MySql.Data.MySqlClient;

namespace Model;

public class PrintModel
{
    public static void Print(MySqlConnection conn, int count, int pageEnCours) //Afficher l'interface utilisteur
    {
        double countPage = Math.Ceiling((double) count / 10);
        Console.Clear();
        Console.WriteLine($"Nombre de logiciel: => {count}\nId | {"logiciel".PadRight(20, ' ')} | Site internet \n");
        foreach (var software in SoftwareModel.SelectPage(conn, pageEnCours))
        {
            Console.WriteLine(software);
        }

        //if (SoftwareModel.Select2(conn, pageEnCours).Count < 10)
        if (pageEnCours >= countPage)
        {
            Console.WriteLine($"\npage en cours {pageEnCours} sur {countPage} pages");
            Console.WriteLine($"Vous etes sur la derniere page");
            Console.Write(
                "\nOption disponible: [2]Precedent, [3]Revenir page 1, [4]Afficher(Id), [5]Supprimer(Id), [6]Ajouter, [7]Quitter,   \n> commande : ");
        }
        else if (pageEnCours == 1)
        {
            Console.WriteLine($"\npage en cours {pageEnCours} sur {countPage} pages");
            Console.WriteLine($"Vous etes sur la premiere page");
            Console.Write(
                "\nOption disponible: [1]Suivant, [4]Afficher(Id), [5]Supprimer(Id), [6]Ajouter, [7]Quitter \n> commande : ");
        }
        else
        {
            Console.WriteLine($"\npage en cours {pageEnCours} sur {countPage} pages");
            Console.WriteLine($"Page : {pageEnCours}/{countPage}");
            Console.Write(
                "\nOption disponible: [1]Suivant, [2]Precedent, [3]Revenir page 1, [4]Afficher(Id), [5]Supprimer(Id), [6]Ajouter, [7]Quitter \n> commande : ");
        }
    }

    public static void SelectId(MySqlConnection conn, int count) //Afficher Id selectionnee
    {
        Console.Write($"Entrer l'ID du logiciel a afficher : ");
        int idInput = Int32.Parse(Console.ReadLine());
        var softwareAll = SoftwareModel.SelectAll(conn);
        SoftwareModel softwareList = SoftwareModel.Select(conn, idInput);
        for (int i = 0; i < count; i++)
        {
            if (idInput == softwareAll[i].Id)
            {
                Console.Clear();
                Console.Write(
                    $"\nId : {idInput}\nlogiciel : {softwareList.SoftwareName} \nOpen source : {softwareList.OpenSource} \nCategory : {softwareList.IdCategory}\nWeb site :");
                foreach (var web in websiteModel.select(conn, idInput))
                {
                    Console.Write(web);
                }

                Console.Write($"\nOwner :");
                Console.WriteLine($"{softwareList.Owner}");
                Console.Write($"Description :");
                Console.WriteLine($"{softwareList.Description}");
                GoBack();
                return;
            }
        }

        Console.WriteLine($"Ce logicile a ete supprimer");
        GoBack();
    }

    public static void DeleteId(MySqlConnection conn, int count) // Supprimer l'Id selectionnee
    {
        Console.Write($"Entrer l'Id a supprimer : ");
        int idInput = int.Parse(Console.ReadLine());
        if (idInput > 0 && idInput <= count)
        {
            SoftwareModel.Delete(conn, idInput);
            websiteModel.Delete(conn, idInput);
            Console.WriteLine($"Le logiciel avec l'ID *{idInput}* a ete correctement supprimer");
            GoBack();
        }
        else if (!(idInput > 0 && idInput <= count))
        {
            Console.WriteLine($"Erreur cette Id n'exsiste pas ! ");
            GoBack();
        }
        else
        {
            GoBack();
        }
    }

    public static void InsertSoftware(MySqlConnection conn) // Ajouter software
    {
        string softwareName;
        string website;
        string osSupported;
        string priceFee;
        string description;
        string openSource;
        bool openS = false;
        string owner;
        string category;

        Console.Clear();
        Console.Write($"Nom du logiciel a ajouter : ");
        softwareName = Console.ReadLine();

        Console.Write($"Site internet: ");
        website = Console.ReadLine();

        Console.Write($"Os supported : ");
        osSupported = Console.ReadLine();

        Console.Write($"Prix : ");
        priceFee = Console.ReadLine();

        Console.Write($"Description : ");
        description = Console.ReadLine();

        Console.Write($"Open source (false or true) : ");
        openSource = Console.ReadLine();
        if (openSource != "false") openS = true;

        Console.Write($"Proprietaire : ");
        owner = Console.ReadLine();

        Console.Write($"Categorie (string) : ");
        category = Console.ReadLine();
        //attribution automatique des ID ! 
        int idCategory = categoryModel.SelectCategory(conn).IdCategory + 1;
        int idWebsite = websiteModel.SelectWebsiteId(conn).IdWebsite + 1;
        int softwareId = SoftwareModel.SelectSoftwareId(conn).Id + 1;

        ownerModel.Ajouter(conn, owner);
        categoryModel.Ajouter(conn, idCategory, category);
        SoftwareModel.Ajouter(conn, softwareId, softwareName, osSupported, priceFee, description, openS, owner,
            idCategory);
        websiteModel.Ajouter(conn, idWebsite, website, softwareId);
    }

    public static void GoBack() //print 
    {
        Console.Write($"Presser une touche pour revenir en arriere-->");
        Console.ReadKey();
    }

    public static int InputInt(int start, int end) //verification input 
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