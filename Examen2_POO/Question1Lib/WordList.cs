using System.Text.RegularExpressions;

namespace Question1Lib;

public class WordList
{
    public string Name { get; set; }
    public List<string> Words { get; set; }
    public int Count 
    {
        get => Words.Count;
        set { }
        
    }
    public WordList(String name)
    {
        Name = name;
        Words = new List<string>();
    }

    public WordList(String name, List<string> words)
    {
        Name = name;
        Words = words;
    }

    public WordList(String name, params string[] words)
    {
        Name = name;
        Words = new List<string>(words);
    }

    public WordList(string name, string filename)
    {
        Name = name;
        string[] lineFileName = File.ReadAllLines("filename.txt");
        string[] listeArray = lineFileName.ToArray();
        Words = new List<string>(listeArray);
    }

    public string
        GetRandomWord() // Lake of time for that method sorry...She's not perfect but not far at least I hope so.
    {
        string[] lineFileName = File.ReadAllLines("filename.txt");
        string[] listeArray = lineFileName.ToArray();
        List<string> words = new List<string>(listeArray);
        Random random = new Random();
        int randomNum = random.Next(1, words.Count);
        for (int i = 0; i < words.Count; i++)
        {
            if (words[randomNum] == words[i])
            {
                File.Delete(words[i]);
                words.Remove(words[i]);
            }
            else
            {
                Console.WriteLine(words[randomNum]);
                throw new ArgumentException("No more word in the list");
            }
        }

        return Words[randomNum];
    }

    //I did not see in the task description asking for the redefinition of the overriding member in the Class WorldList but I did it anyway.
    public override bool Equals(object? obj)
    {
        if (obj == null || this.GetType() != obj.GetType())
        {
            return false;
        }

        WordList other = (WordList) obj;
        return Name.Equals(other.Name) && Count.Equals(other.Count);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public override string ToString()
    {
        return $"({Name}, {Count}, {string.Join("\n", Words)})";
    }
}