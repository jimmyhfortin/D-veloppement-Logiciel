using MySql.Data.MySqlClient;
using Ubiety.Dns.Core;

namespace Model;

public class SoftwareModel
{
    public int Id { get; set; }
    public string SoftwareName { get; set; }
    public string Os { get; set; }
    public string FeePrice { get; set; }
    public string Description { get; set; }
    public bool OpenSource { get; set; }
    public string Owner { get; set; }
    public int IdCategory { get; set; }
    public string WebSite { get; set; }

    public SoftwareModel()
    {
    }

    public SoftwareModel(int id)
    {
        Id = id;
    }

    public SoftwareModel(int id, string softwareName, string os, string webSite)
    {
        Id = id;
        SoftwareName = softwareName;
        Os = os;
        WebSite = webSite;
    }

    public SoftwareModel(int id, string softwareName, string os, string feePrice, string description, bool openSource,
        string owner, int idCategory)
    {
        Id = id;
        SoftwareName = softwareName;
        Os = os;
        FeePrice = feePrice;
        Description = description;
        OpenSource = openSource;
        Owner = owner;
        IdCategory = idCategory;
    }

    public static SoftwareModel SelectSoftwareId(MySqlConnection conn)
    {
        string sqlSelect = $"select id from software order by id DESC limit 1;";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        SoftwareModel softwareid = new SoftwareModel();

        while (read.Read())
        {
            softwareid = new SoftwareModel(read.GetInt32(0));
        }

        return softwareid;
    }

    public static SoftwareModel Select(MySqlConnection conn, int id)
    {
        string sqlSelect = $"select * from software where IsDeleted = 0 and id = {id};";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        SoftwareModel software = new SoftwareModel();

        while (read.Read())
        {
            software = new SoftwareModel(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3),
                read.GetString(4), read.GetBoolean(5), read.GetString(6), read.GetInt32(7));
        }

        return software;
    }

    public static List<SoftwareModel> SelectAll(MySqlConnection conn)
    {
        string sqlSelect = "SELECT * from software where IsDeleted = 0;";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        List<SoftwareModel> softwareList = new List<SoftwareModel>();

        while (read.Read())
        {
            SoftwareModel software = new SoftwareModel(read.GetInt32(0), read.GetString(1), read.GetString(2),
                read.GetString(3), read.GetString(4), read.GetBoolean(5), read.GetString(6), read.GetInt32(7));
            softwareList.Add(software);
        }

        return softwareList;
    }

    public static List<SoftwareModel> SelectPage(MySqlConnection conn, int NbPage)
    {
        int page = NbPage - 1;
        string sqlSelect = "";
        sqlSelect =
            $"SET sql_mode=(SELECT REPLACE(@@sql_mode, 'ONLY_FULL_GROUP_BY',''));select i.id,softwareName,OsSupported,website from software as i join website on i.id = website.softwareId where i.IsDeleted = 0 group by id having min(i.id) limit 10 offset {page}0;";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        List<SoftwareModel> softwareList = new List<SoftwareModel>();

        while (read.Read())
        {
            SoftwareModel software =
                new SoftwareModel(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetString(3));
            softwareList.Add(software);
        }

        return softwareList;
    }

    public static void Delete(MySqlConnection conn, int id)
    {
        MySqlCommand delete = new MySqlCommand($"update software set IsDeleted = 1 where id = {id};", conn);
        delete.ExecuteNonQuery();
    }

    public static void Ajouter(MySqlConnection conn, int id, string name, string os, string price, string description,
        bool opensource, string owner, int idCategory)
    {
        MySqlCommand ajouter =
            new MySqlCommand(
                $"insert into software values ({id}, '{name}', '{os}', '{price}', '{description}', {opensource}, '{owner}', {idCategory}, 0);",
                conn);
        ajouter.ExecuteNonQuery();
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        SoftwareModel other = (SoftwareModel) obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return SoftwareName.GetHashCode();
    }

    public override string ToString()
    {
        return
            $"{Id.ToString().PadRight(2)} | {SoftwareName.ToString().PadRight(20, ' ')} | {WebSite.ToString().ToUpper()}";
    }
}