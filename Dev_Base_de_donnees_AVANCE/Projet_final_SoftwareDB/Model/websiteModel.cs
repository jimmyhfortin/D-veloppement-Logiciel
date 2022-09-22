using MySql.Data.MySqlClient;

namespace Model;

public class websiteModel
{
    public int IdWebsite { get; set; }
    public string Website { get; set; }
    public int SoftwareId { get; set; }

    public websiteModel()
    {
    }

    public websiteModel(int idWebsite, string website, int softwareId)
    {
        IdWebsite = idWebsite;
        Website = website;
        SoftwareId = softwareId;
    }

    public websiteModel(int idWebsite)
    {
        IdWebsite = idWebsite;
    }


    public static websiteModel SelectWebsiteId(MySqlConnection conn)
    {
        string sqlSelect = $"select idWebsite from website order by idWebsite DESC limit 1;";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        websiteModel website = new websiteModel();

        while (read.Read())
        {
            website = new websiteModel(read.GetInt32(0));
        }

        read.Close();
        return website;
    }

    public static List<websiteModel> select(MySqlConnection conn, int id)
    {
        string sqlSelect = $"select * from website where IsDeleted = 0 and softwareId = {id};";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        List<websiteModel> websiteList = new List<websiteModel>();

        while (read.Read())
        {
            websiteModel website = new websiteModel(read.GetInt32(0), read.GetString(1), read.GetInt32(2));
            websiteList.Add(website);
        }

        read.Close();
        return websiteList;
    }

    public static void Delete(MySqlConnection conn, int id)
    {
        string sqlSelect = $"update website set IsDeleted = 1 where softwareId = {id};";
        using var delete = new MySqlCommand(sqlSelect, conn);
        delete.ExecuteNonQuery();
    }

    public static void Ajouter(MySqlConnection conn, int id, string website, int idSoftware)
    {
        MySqlCommand ajouter =
            new MySqlCommand($"insert into website values ({id}, '{website}', {idSoftware}, 0);", conn);
        ajouter.ExecuteNonQuery();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        websiteModel other = (websiteModel) obj;
        return IdWebsite == other.IdWebsite;
    }

    public override int GetHashCode()
    {
        return IdWebsite.GetHashCode();
    }

    public override string ToString()
    {
        return $"   -  {Website} ";
    }
}