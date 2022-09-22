using MySql.Data.MySqlClient;

namespace Model;

public class NotesModel
{
    public int Id { get; set; }
    public int individuId { get; set; }
    public string Note { get; set; }
    public string Date { get; set; }

    public NotesModel()
    {
    }

    public NotesModel(int id, int individuId, string note, string date)
    {
        Id = id;
        this.individuId = individuId;
        Note = note;
        Date = date;
    }
    public static List<NotesModel> Select(MySqlConnection conn, int id)
    {
        string sqlSelect = $"select * from notes where individu_id = {id};";
        using var command = new MySqlCommand(sqlSelect, conn);
        using MySqlDataReader read = command.ExecuteReader();
        List<NotesModel> individuNotes = new List<NotesModel>();

        while (read.Read())
        {
            NotesModel personneNotes = new NotesModel(read.GetInt32(0), read.GetInt32(1), read.GetString(2), read.GetString(3));
            individuNotes.Add(personneNotes);
        }
        return individuNotes;
    }
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        NotesModel other = (NotesModel)obj;
         return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"  -  {Note}";
        
    }
}