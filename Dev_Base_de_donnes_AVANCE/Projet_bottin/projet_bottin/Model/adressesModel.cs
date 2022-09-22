using MySql.Data.MySqlClient;

namespace Model;

public class adressesModel
{
    public string Adresses { get; set; }
    public string NomProvinces { get; set; }

    public adressesModel(string adresses, string nomProvinces)
    {
        Adresses = adresses;
        NomProvinces = nomProvinces;
    }


    public adressesModel()
    {
    }

    public static List<adressesModel> Select(MySqlConnection conn, int id)
    {
        string sqlSelect = $"select addresse,nom from addresses C inner join provinces  A on C.province_id = A.id where individu_id = {id};";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        List<adressesModel> individuAdresse = new List<adressesModel>();

        while (read.Read())
        {
            adressesModel personneAdresse = new adressesModel(read.GetString(0), read.GetString(1));
            individuAdresse.Add(personneAdresse);
        }
        return individuAdresse;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        adressesModel other = (adressesModel)obj;
         return Adresses == other.Adresses;
    }

    public override int GetHashCode()
    {
        return Adresses.GetHashCode();
    }

    public override string ToString()
    {
        return $"  -  {Adresses} {NomProvinces}";
        
    }
}