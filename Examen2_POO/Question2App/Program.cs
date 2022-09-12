using Question2Lib;

namespace Question2App
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Question #2 part-A is done and respect ALL the requirements (see QuestionLib2)___________________________
            // Question #2 part-B_______________________________________________________________________________________
            // Question #2 part-B.1
            var character = new List<Character>();
            // Question #2 part-B.2
            Cleric character_1 = new Cleric(12, "The_Warrior666", 20, 12, 10, 16, 8, 20);
            Cleric character_2 = new Cleric("The_Warrior", 8, 16, 15, 3, 19, 3);
            Fighter character_3 = new Fighter(13, "The_Terminator", 20, 3, 3, 12, 12, 3);
            Fighter character_4 = new Fighter("The_Terminator_01", 3, 20, 20, 4, 6, 20);
            Druid character_5 = new Druid(2, "The_Falcon", 8, 18, 16, 20, 20, 18);
            Druid character_6 = new Druid("The_Falcon632", 12, 3, 8, 3, 3, 7);
            character.Add(character_1);
            character.Add(character_2);
            character.Add(character_3);
            character.Add(character_4);
            character.Add(character_5);
            character.Add(character_6);
            // Question #2 part-B.3
            foreach (var characterlist in character)
            {
                Console.WriteLine(characterlist);
            }

            for (int i = 0; i < character.Count; i++)
            {
                Console.WriteLine(character[i].Speak());
                Console.WriteLine(character[i].Attack());
                Console.WriteLine(character[i].Die());
                Console.WriteLine();
            }
            // End______________________________________________________________________________________________________
        }
    }
}