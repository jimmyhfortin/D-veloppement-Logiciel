using System;
using System.Transactions;
using Project;

namespace Machine_bonbon 
{
    internal class Program
    {
        public static Candy[] LoadCandies()
        {
            Candy[] candies;
            Data dataManager = new Data(); /* declaration et reservation de la mémoire de la
            variable structurée(objet) dataManager de type Data */
            candies = dataManager.LoadCandies(); /* appel de la fonction LoadCandies() avec la
            variable structurée dataManager vu que c’est une fonction propre à la classe Data et
            qu’on ne peut pas l’utiliser ailleurs sauf en créant une variable de type Data */
            return candies;
        }
        public static int GetSelection(int input=25)
        {
            Board.Print();
            while (true)
            {
                Console.Write("->");
                input = int.Parse(Console.ReadLine());
                if (input <= 0 || input > 26)
                {
                    Console.WriteLine("Entrer une selection entre 1 & 25 ");
                }
                else
                {
                    break;
                }
                
            }
            Board.Print(selection:input);
            return input-1;
        }
        public static Candy GetCandy(int input, Candy[] candies)
        {
            return candies[input];
        }
        public static decimal GetCoin(int input, int select, Candy bonbon, decimal sommeRecu)
        {
            do
            {
                Console.Write($"[0] = Annuler\n[1] = 5c\n[2] = 10c\n[3] = 25c\n[4] = 1$\n[5] = 2$\n->");
                input = int.Parse(Console.ReadLine());
                Board.Print(bonbon.Name, select+1, bonbon.Price, received:sommeRecu);
            } while ((input < 0 || input > 5) && bonbon.Stock > 0);
            
            //Board.Print(bonbon.Name, select+1, bonbon.Price, received:sommeRecu);
            switch(input)
            {
                case 0:
                    return 0;
                case 1:
                    return 0.05m;
                case 2:
                    return 0.10m;
                case 3:
                    return 0.25m;
                case 4:
                    return 1.00m;
                case 5:
                    return 2.00m;
            }
            return input;
        }
        static void Main(string[] args)
        {
            Candy[] candies = LoadCandies(); //Declaration d'un tableau de type Candy qui contient tous les donnees des bonbons fichier.data
            while (true)
            {
                //Board.Print();
                int select = GetSelection();
                Candy bonbon = GetCandy(select, candies);
                while (bonbon.Stock >= 0)
                {
                    //Board.Print(candies[select].Name, select+1, bonbon.Price);
                    if (bonbon.Stock == 0)
                    {
                        Board.Print(message:candies[select].Name + " VIDE", select+1);
                        select = GetSelection();
                        bonbon = GetCandy(select, candies);
                        
                    }
                    else
                    {
                        Board.Print(candies[select].Name, select+1, bonbon.Price);
                        break;
                    }
                }
                //Console.WriteLine("Bravo!");
                decimal coin = 0, sommeRecu=0;
                bool isCompleted =true, isCanceled=true;
                int input=0;
                //coin = GetCoin(input, select, bonbon, sommeRecu);
                while (true)
                {
                    coin = GetCoin(input, select, bonbon, sommeRecu);
                    sommeRecu = sommeRecu + coin;
                    Board.Print(candies[select].Name, select+1, bonbon.Price, received:sommeRecu, returned:(sommeRecu-bonbon.Price));
                    if (coin == 0)
                    {
                        Board.Print(message:"ANNULEE", select+1, bonbon.Price, received:sommeRecu, returned:sommeRecu);
                        break;
                        /*coin = GetCoin(input, select, bonbon, sommeRecu);
                        sommeRecu = sommeRecu + coin;
                        Board.Print(candies[select].Name, select+1, bonbon.Price, received:sommeRecu, returned:(sommeRecu-bonbon.Price));
                        */
                    }
                    else if (sommeRecu < bonbon.Price)
                    {
                        /*coin = GetCoin(input, select, bonbon, sommeRecu);
                        sommeRecu = sommeRecu + coin;*/
                        Board.Print(candies[select].Name, select+1, bonbon.Price, received:sommeRecu);
                        
                    }
                    else if (sommeRecu >= bonbon.Price)
                    {
                        Board.Print("PRENNEZ VOTRE FRIANDISE...", select+1, bonbon.Price, received:sommeRecu, returned:(sommeRecu-bonbon.Price), result:candies[select].Name);
                        bonbon.Stock--;
                        isCompleted = true;
                        break;
                    }
                    
                }

                Console.WriteLine("Appuyer sur une touche pour recommencer");
                Console.ReadKey();

            }
            
            
            /*do
            {
                coin = GetCoin(input, select, bonbon, sommeRecu);
                sommeRecu = sommeRecu+coin;
                //Board.Print(candies[select].Name, select+1, bonbon.Price, received:sommeRecu);
                //while (sommeRecu <= bonbon.Price)//metre les exception comme else if en premier et ensuite a la fin traiter le while
                {
                    if (coin == 0 && sommeRecu == 0)
                    {
                        Board.Print(message:"ANNULEE", select+1, bonbon.Price, received:sommeRecu);
                    }
                    else if (coin == 0 && sommeRecu > 0)
                    {
                        sommeRecu = 0;
                        Board.Print(message:"ANNULEE", select+1, bonbon.Price, received:sommeRecu);
                    }
                    else if (sommeRecu < bonbon.Price && coin != 0)
                    {
                        Board.Print(candies[select].Name, select+1, bonbon.Price, received:sommeRecu);
                        sommeRecu = sommeRecu+coin;
                        coin = GetCoin(input, select, bonbon, sommeRecu);
                        //Board.Print(candies[select].Name, select+1, bonbon.Price, received:sommeRecu);
                    }
                    else
                    {
                        Board.Print(candies[select].Name, select+1, bonbon.Price, received:sommeRecu);
                    }
                    
                    
                }
                //sommeRecu += coin;
                //Board.Print(candies[select].Name, select+1, bonbon.Price, received:sommeRecu);
                
            } while (sommeRecu < bonbon.Price);*/
            /*do
            {
                coin = GetCoin();
                
            } while (coin == 0);*/



























        }
    }
}