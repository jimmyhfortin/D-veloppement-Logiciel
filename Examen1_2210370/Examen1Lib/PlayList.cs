using System.ComponentModel.DataAnnotations;

namespace Examen1Lib;

public class PlayList
{
    private string _name;

    public string Name
    {
        get => _name;
        set
        {
            if (value.Length < 1)
            {
                throw new ArgumentException("the play list name must be at least 1 characters long");
            }

            _name = value;
        }
    }

    public List<Song> SongList { get; set; }

    public int Count
    {
        get
        {
            int count = 0;
            for (int i = 0; i < SongList.Count; i++)
            {
                count = i;
            }

            return count;
        }
    }

    public PlayList(string name)
    {
        SongList = new List<Song>();
        Name = name;
    }

    public override string ToString()
    {
        return String.Join<Song>("\n", SongList);
        return String.Join(" ", SongList);
    }

    public int TotalLength()
    {
        int second = 0;
        for (int i = 0; i < SongList.Count; i++)
        {
            second += SongList[i].Seconds;
        }

        return second;
    }
}