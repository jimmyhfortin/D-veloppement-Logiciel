using PlayListLib;

namespace DataRepoLib;

public class JsonArtistRepo : JsonDataRepo<Artist, int>
{
    public JsonArtistRepo(string fileName) : base(fileName)
    {
    }

    public override List<Artist> SelectAll()
    {
        var playLists = base.SelectAll();
        if (playLists.Count > 0)
        {
            var max = playLists.Select(x => x.Id).Max();
            if (max >= Artist.NextId)
            {
                Artist.NextId = max + 1; // Demander au prof
            }
        }

        return playLists;
    }
    
    public override Artist? Select(int id)
    {
        List<Artist> artists = SelectAll();
        return artists.Find(x => x.Id == id);
    }

    public override bool Delete(int id)
    {
        Artist artist = new Artist
        {
            Id = id // Demander au prof
        };
        return Delete(artist);
    }
    
}