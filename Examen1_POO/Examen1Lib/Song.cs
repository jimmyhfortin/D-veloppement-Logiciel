namespace Examen1Lib;

public class Song
{
    private static int NextId { get; set; } = 1;
    public int Id { get; }
    private string _titleSong;

    public string Title
    {
        get => _titleSong;
        set
        {
            if (value.Length < 1)
            {
                throw new ArgumentException("the title must be at least 1 characters long");
            }

            _titleSong = value;
        }
    }

    private string _artistSong;

    public string Artist
    {
        get => _artistSong;
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("the title must be at least 3 characters long");
            }

            _artistSong = value;
        }
    }

    private int _secondSong;

    public int Seconds
    {
        get => _secondSong;
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("the length must be at least 1 seconds");
            }

            _secondSong = value;
        }
    }

    public double Minutes
    {
        get
        {
            double minutes = _secondSong / 60.00;
            minutes = Math.Round(minutes, 2);
            return minutes;
        }
    }

    public Song(string title, string artist, int seconds)
    {
        Id = NextId;
        NextId++;
        Title = title;
        Artist = artist;
        Seconds = seconds;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        Song other = (Song) obj;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"'''{Id}: {Title} ({Artist}) {Minutes}'''";
    }
}