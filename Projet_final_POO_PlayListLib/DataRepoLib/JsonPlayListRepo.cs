using PlayListLib;

namespace DataRepoLib;

public class JsonPlayListRepo : JsonDataRepo<PlayList, string>
{
    public JsonPlayListRepo(string fileName) : base(fileName)
    {
    }

    public override PlayList? Select(string id)
    {
        List<PlayList> playLists = SelectAll();
        return playLists.Find(x => x.Name.Equals(id));
    }

    public override bool Delete(string name)
    {
        return Delete(new PlayList(name));
    }
    
}