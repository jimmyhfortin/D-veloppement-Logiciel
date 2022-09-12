namespace PlayListLib;

public class Duration
{
    public int Hours { get; set; }

    public int Minutes { get; set; }

    public int Seconds { get; set; }

    public int TotalSeconds
    {
        get => (Hours * 3600 + Minutes * 60 + Seconds);
    }

    public Duration()
    {
    }

    public Duration(int hours, int minutes, int seconds)
    {
        Hours = hours;
        Minutes = minutes;
        Seconds = seconds;
    }

    public Duration(int seconds)
    {
        Seconds = seconds;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        Duration other = (Duration) obj;

        return TotalSeconds == other.TotalSeconds;
    }

    public override int GetHashCode()
    {
        return TotalSeconds.GetHashCode();
    }

    public override string ToString()
    {
        TimeSpan t = TimeSpan.FromSeconds(TotalSeconds);
        return $"{TotalSeconds}";
    }
}