namespace PlayListLib;

public class Song
{
    public static int NextId { get; set; } = 1;

    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }

    public Duration Length { get; set; }

    public Artist Artist { get; set; }

    public Song()
    {
    }

    public Song(int id, string title, string genre, Artist artist, Duration minutes)
    {
        Id = id;
        Title = title;
        Genre = genre;
        Artist = artist;
        Length = minutes;
    }

    public Song(string title, string genre, Artist artist, Duration minutes)
    {
        Id = NextId;
        NextId++;
        Title = title;
        Genre = genre;
        Artist = artist;
        Length = minutes;
    }

    public Song(string title, string genre, Artist artist, int length)
    {
        Id = NextId;
        NextId++;
        Title = title;
        Genre = genre;
        Artist = artist;
        Length = new Duration(length);
    }

    public Song(string title, Artist artist, Duration minutes)
    {
        Id = NextId;
        NextId++;
        Title = title;
        Artist = artist;
        Length = minutes;
    }

    public Song(string title, Artist artist, int length)
    {
        Id = NextId;
        NextId++;
        Title = title;
        Artist = artist;
        Length = new Duration(length);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        Song other = (Song) obj;
        return Id.Equals(other.Id) && Title.Equals(other.Title);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"({Id}) {Title}, ({Artist.Name}), {TimeSpan.FromSeconds(Length.TotalSeconds)}";
    }
}