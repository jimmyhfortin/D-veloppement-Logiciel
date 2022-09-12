using PlayListLib;

namespace DataRepoLib;

public class JsonSongRepo : JsonDataRepo<Song, int>
{
    public JsonSongRepo(string fileName) : base(fileName)
    {
    }

    public override List<Song> SelectAll()
    {
        var songs = base.SelectAll();
        if (songs.Count > 0)
        {
            var max = songs.Select(x => x.Id).Max();
            if (max >= Song.NextId)
            {
                Song.NextId = max + 1;
            }
        }

        return songs;
    }
    
    public override Song? Select(int id)
    {
        List<Song> songs = SelectAll();
        return songs.Find(x => x.Id == id);
    }

    public override bool Delete(int id)
    {
        Song song = new Song
        {
            Id = id
        };
        return Delete(song);
    }
    
}