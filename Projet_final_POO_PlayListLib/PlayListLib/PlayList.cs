namespace PlayListLib;

public class PlayList
{
    public string Name { get; set; }

    public int Count
    {
        get => Songs.Count;
        set { }
    }

    public List<Song> Songs { get; set; }

    public Duration TotalLength
    {
        get
        {
            Duration length = new Duration();
            foreach (var song in Songs)
            {
                //duration.Seconds += Songs.Count;
                length.Seconds += song.Length.TotalSeconds;
            }

            return length;
        }
        set { }
    }

    public PlayList()
    {
    }

    public PlayList(string name)
    {
        Name = name;
        Songs = new List<Song>();
        TotalLength = new Duration(Count);
    }

    public PlayList(string name, List<Song> songs)
    {
        Name = name;
        Songs = songs;
        TotalLength = new Duration(Count);
    }

    public PlayList(string name, params Song[] song)
    {
        Name = name;
        Songs = new List<Song>(song);
        TotalLength = new Duration(Count);
    }

    public Song Find(int Id)
    {
        for (int i = 0; i < Songs.Count; i++)
        {
            if (Id.Equals(Songs[i]))
            {
                return Songs[i];
            }
        }

        return Songs[-1];
    }

    public void Add(Song NewSong)
    {
        Songs.Add(NewSong);
    }

    public bool Remove(Song songUser) //Songs
    {
        for (int i = 0; i < Songs.Count; i++)
        {
            if (songUser.Equals(Songs[i]))
            {
                Songs.Remove(songUser);
                return true;
            }
        }

        return false;
    }

    public bool Remove(int songUserInt) //Songs
    {
        for (int i = 0; i < Songs.Count; i++)
        {
            if (songUserInt == Songs.Count)
            {
                Songs.Remove(Songs[i]);
                return true;
            }
        }

        return false;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        PlayList other = (PlayList) obj;
        return Name.Equals(other.Name) && Songs.Equals(other.Songs);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Count} {TimeSpan.FromSeconds(TotalLength.TotalSeconds)}\n{Name}\n{string.Join("\n", Songs)}";
    }
}