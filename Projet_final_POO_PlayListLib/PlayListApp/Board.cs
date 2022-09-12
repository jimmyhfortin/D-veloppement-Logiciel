namespace PlayListApp;

public class Board
{
    public static void Print(string messagestring1 = "", string messagestring2 = "", string messagestring3 = "")
    {
        string tableau = "|".PadRight(50, ' ') + "|";
            messagestring1 = messagestring1.PadRight(20, ' ');
            messagestring2 = messagestring2.PadRight(20, ' ');
            messagestring3 = messagestring3.PadRight(100, ' ');
            
            Console.Clear();
            Console.WriteLine($"|-----------------------------------------------------------------------------------|");
            Console.WriteLine($"|                                    PlayListLib                                    |");
            Console.WriteLine($"|-----------------------------------------------------------------------------------|");
            Console.WriteLine($"|{messagestring1}                                                                    ");
            Console.WriteLine($"|-----------------------------------------------------------------------------------|");
            Console.WriteLine($"|{messagestring2}                                                                    ");
            Console.WriteLine($"|-----------------------------------------------------------------------------------|");
            Console.WriteLine($"|{messagestring3}                                                                    ");
            Console.WriteLine($"|-----------------------------------------------------------------------------------|");
            //Console.WriteLine("Appuyer sur une touche pour continuer");
            //Console.ReadKey();
        }
    

        public static string PadMessage(string source, int longeure)
        {
            int espace = longeure - source.Length; 
            int padLeft = espace / 2 + source.Length;
            return source.PadLeft(padLeft).PadRight(longeure);
        }

        public static void  Endmessage(string message1, string message2 = "")
        {
            Console.WriteLine($"**{message1} {message2}**");
        }
}