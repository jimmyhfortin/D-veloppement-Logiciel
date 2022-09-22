using MySql.Data.MySqlClient;

namespace Model;

public class categoryModel
{
    public int IdCategory { get; set; }
    public string Sort { get; set; }

    public categoryModel()
    {
    }

    public categoryModel(int idCategory)
    {
        IdCategory = idCategory;

    }

    public static void Ajouter(MySqlConnection conn, int id, string sort)
    {
        MySqlCommand ajouter = new MySqlCommand($"insert into category values ({id}, '{sort}', 0);", conn);
        ajouter.ExecuteNonQuery();
    }
    public static categoryModel SelectCategory(MySqlConnection conn)
    {
        string sqlSelect = $"select idCategory from category order by idCategory DESC limit 1;";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        categoryModel category = new categoryModel();

        while (read.Read())
        {
            category = new categoryModel(read.GetInt32(0));
        }
        read.Close();
        return category;
    } 

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        categoryModel other = (categoryModel) obj;
        return IdCategory == other.IdCategory;
    }

    public override int GetHashCode()
    {
        return IdCategory.GetHashCode();
    }

    public override string ToString()
    {
        return $"  -  ";
    }
}