using migration;
using MySql.Data.MySqlClient;

namespace Model;

public class telephonesModel
{
    public int  id { get; set; }
    public string telephone { get; set; }
    public string type_connection { get; set; }
    public int individu_id { get; set; }

    public telephonesModel(int id, string telephone, string type_connection, int individu_id)
    {
        this.id = id;
        this.telephone = telephone;
        this.type_connection = type_connection;
        this.individu_id = individu_id;
    }
    public static List<telephonesModel> select(MySqlConnection conn, int id)
    {
        string sqlSelect = $"select * from telephones where individu_id = {id};";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        List<telephonesModel> telephoneList = new List<telephonesModel>();

        while (read.Read())
        {
            telephonesModel telephone = new telephonesModel(read.GetInt32(0), read.GetString(1), read.GetString(2), read.GetInt32(3));
            telephoneList.Add(telephone);
        }
        return telephoneList;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        telephonesModel other = (telephonesModel)obj;
        return id == other.id;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }

    public override string ToString()
    {
        return $"   -  {type_connection} : {telephone}  ";
    }
}