using migration;
using MySql.Data.MySqlClient;

namespace Model;

public class IndividusModel
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom{ get; set; }
    public string Telephones { get; set; }
    public string InfoAdd { get; set; }

    public IndividusModel()
    {
    }

    public IndividusModel(int id, string nom, string prenom, string telephones, string infoAdd)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Telephones = telephones;
        InfoAdd = infoAdd;
    }

    public IndividusModel(int id, string nom, string prenom, string telephones)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Telephones = telephones;
    }
    public static IndividusModel Select(MySqlConnection conn, int id)
    {
        string sqlSelect = $"select * from individus where id = {id};";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        IndividusModel individu = new IndividusModel();

        while (read.Read())
        {
            individu = new IndividusModel(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3),read.GetString(4));
        }
        return individu;
    }
    public static List<IndividusModel> SelectAll(MySqlConnection conn)
    {
        string sqlSelect = "SELECT * from individus;";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        List<IndividusModel> individusList = new List<IndividusModel>();

        while (read.Read())
        {
            IndividusModel personne = new IndividusModel(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3));
            individusList.Add(personne);
        }
        return individusList;
    }
    
    public static List<IndividusModel> SelectPage(MySqlConnection conn, double NbPage)
    {
        string sqlSelect = "";
        if(NbPage == 1) sqlSelect = $"SET sql_mode=(SELECT REPLACE(@@sql_mode, 'ONLY_FULL_GROUP_BY',''));select i.id,prenom,nom,telephone from individus as i join telephones on i.id = telephones.individu_id group by id having min(i.id) limit 10 offset 0;";
        if(NbPage == 2) sqlSelect = $"SET sql_mode=(SELECT REPLACE(@@sql_mode, 'ONLY_FULL_GROUP_BY',''));select i.id,prenom,nom,telephone from individus as i join telephones on i.id = telephones.individu_id group by id having min(i.id) limit 10 offset 10;";
        if(NbPage == 3) sqlSelect = $"SET sql_mode=(SELECT REPLACE(@@sql_mode, 'ONLY_FULL_GROUP_BY',''));select i.id,prenom,nom,telephone from individus as i join telephones on i.id = telephones.individu_id group by id having min(i.id) limit 10 offset 20;";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        List<IndividusModel> individusList = new List<IndividusModel>();

        while (read.Read())
        {
            IndividusModel personne = new IndividusModel(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3));
            individusList.Add(personne);
        }
        return individusList;
    }
    public static List<IndividusModel> SelectA(MySqlConnection conn, int pageActuelle)
    {
        string sqlSelect = $"SELECT i.id,prenom,nom,telephone from individus as i inner join telephones on i.id = telephones.individu_id limit 10 offset {pageActuelle}0;";
        //string sqlSelect = "SELECT * from individus;";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        List<IndividusModel> individusList = new List<IndividusModel>();

        while (read.Read())
        {
            IndividusModel personne = new IndividusModel(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3));
            individusList.Add(personne);
        }
        return individusList;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        IndividusModel other = (IndividusModel)obj;
         return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Id.ToString().PadRight(2,' ')} | {Prenom.ToUpper()} {Nom.ToUpper()} | {Telephones}";
    }
}