using MySql.Data.MySqlClient;

namespace Model;

public class ownerModel
{
    public static void Ajouter(MySqlConnection conn, string owner)
    {
        MySqlCommand ajouter = new MySqlCommand($"insert into owner values ('{owner}', '{owner}', 0);", conn);
        ajouter.ExecuteNonQuery();
    }
}