using System.Threading.Channels;
using Examen1Lib;


namespace Examen1App
{
    public class Program
    {
        static void Main(string[] args)
        {
            //### Part C : application______________________________________________________________________________
            //Creation of 3 *play list* with 4 songs each
            var metallica1 = new PlayList("Metallica");
            metallica1.SongList.Add(new Song("Fuel", "Metallica", 258));
            metallica1.SongList.Add(new Song("Heros Of The Day", "Metallica", 253));
            metallica1.SongList.Add(new Song("Kall of kluklu", "Metallica", 512));
            metallica1.SongList.Add(new Song("Master Of Puppet", "Metallica", 501));
            

            var metallica2 = new PlayList("Symphonic Metallica");
            metallica2.SongList.Add(new Song("Master Of Puppet", "Metallica", 501));
            metallica2.SongList.Add(new Song("Of Wolf And Man", "Metallica", 287));
            metallica2.SongList.Add(new Song("No Leaf Clover", "Metallica", 326));
            metallica2.SongList.Add(new Song("Nothing Else Matters", "Metallica", 388));

            var tomorrowland = new PlayList("Tomorrowland Belgium 2018");
            tomorrowland.SongList.Add(new Song("Balearic Mornings", "Hi-LO", 270));
            tomorrowland.SongList.Add(new Song("Element Of A New Life", "VerWest", 195));
            tomorrowland.SongList.Add(new Song("Si Soy Fuego", "Paul Kalkbrenner", 312));
            tomorrowland.SongList.Add(new Song("Stars", "Luke Bond", 205));

            //Part C.2 to C.4
            while (true)
            {
                int choice = 0;
                do
                {
                    Console.WriteLine($"Make a choice between these *play list*");
                    Console.WriteLine($"Choice [1] for ({metallica1.Name})");
                    Console.WriteLine($"Choice [2] for ({metallica2.Name})");
                    Console.WriteLine($"Choice [3] for ({tomorrowland.Name})");
                    Console.WriteLine($"Choice [0] for (quit)");
                    choice = int.Parse(Console.ReadLine());
                } while (choice != 0 && choice != 1 && choice != 2 && choice != 3);


                if (choice == 0) break;
                if (choice == 1) Console.WriteLine($"{metallica1} \n{TimeSpan.FromSeconds(metallica1.TotalLength())}");
                else if (choice == 2) Console.WriteLine($"{metallica2} \n{TimeSpan.FromSeconds(metallica2.TotalLength())}");
                else if (choice == 3) Console.WriteLine($"{tomorrowland} \n{TimeSpan.FromSeconds(tomorrowland.TotalLength())}");
                Console.WriteLine("Press any key to restart");
                Console.ReadKey();
            }
            //End_______________________________________________________________________________________________________
        }
    }
}