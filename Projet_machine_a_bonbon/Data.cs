using System;
using System.IO;
using Project;


namespace Machine_bonbon
{
    public class Data
    {
      const String FILE_NAME = "candies.data"; //mot cl� const pour emp�che de changer la valeur de FILE_NAME => elle devient une constante
      const String DELIMITER = "|";//variable DELEMITER => constante DELIMITER 

        //fonction qui va nous permettre de charger les donn�es des bonbons du fichier candies.data
        public Candy[] LoadCandies() {

        Candy[] candies = new Candy[0]; //d�claration et r�servation de la m�moire de notre tableau avec taille tableau 0
        String line; //variable ligne de type chaine de caract�re qu'on utilisera pour r�cup�rer une ligne de candies.data
        //la classe StreamReader permet de lire un fichier de donn�es comme dans notre cas candies.data
        //avec StreamReader on va pouvoir lire le fichier candies.data et r�cup�rer les donn�es y contenant
        StreamReader streamReader = GetReader(FILE_NAME); //stremReader : variable lecteur de fichier.
        //la varibale streamReader prend comme valeur le nom du fichier � lire
        while((line = streamReader.ReadLine()) != null)  //tant que la variable stremReader arrive � lire des lignes dans le fichier
        {
          //format d'une ligne dans le fichier candies.data: 1|Wacky Monkey|2|10
          String name = line.Split(DELIMITER)[1]; //on divise la ligne courante par le d�limiteur | 
         //une chaine caract�res qui est "split�" avec la fonction Split(d�limiteur) retourne un tableau de string
         //une fois la chaine est split�e, on affecte � la variable name la valeur de la 2eme case du tableau
          decimal price = decimal.Parse(line.Split(DELIMITER)[2]);//on splite et on affecte la valeur du tableau qui a la position 2(3eme case)
          int stock = int.Parse(line.Split(DELIMITER)[3]);//idem
          
          //on a maintenant r�cup�rer les donn�es d'un bonbon � partir de ligne qu'on a plac� dans les variables:name , price et stock
          /*---RAPPEL----
           une variable structur�e on l'appelle objet
           une case de la variable structur�e on l'appelle attribut
           */
          Candy newCandy = new Candy(name, price, stock);//on d�clare un objet(variable structur�e) de type Candy et j'itilialise l'attribut(case) name de l'objet newCandy
          //newCandy.Price = price; //on affecte la valeur de price � l'attribut newCandy.Price de l'objet newCandy
          //newCandy.Stock = stock;//on affecte la valeur de price � l'attribut newCandy.Price de l'objet newCandy
          
          //j'ajoute mon nouvel bonbon r�cup�r� (que j'ai maintenant dans l'objet newCandy) au tableau des candies � l'aide de la fonction AddCandy()
          candies = AddCandy(candies, newCandy);//la fonction AddCandy prend en entr�e le tableau candies et l'objet qui contient le bonbon � ajouter au tableau
          //la fonction AddCandy() retourne un le tableau candies apr�s avoir ajouter le nouvel bonbon dans ce tableau
        }  
        
        //rappellez vous toutes ces instructions sont dans la fonction LoadCandies()
        //la fonction LoadCandies() a pu lire les lignes du fichier, r�cup�rer les donn�es des bonbons � partir du fichier et les placer dans la tableau
        return candies;//on retourne le tableau rempli

      }
        //fonction GetReader() qui permet de cr�er un lecteur de fichier: la fonction prend en param�tres le nom du fichier
        //une variable de type StreamReader a besoin d'une r�servation de la m�moire (avec le mot cl� new)
        //elle prend le chemin du fichier en param�tres
        private StreamReader GetReader(String filename) {
            return new StreamReader($@"{Directory.GetCurrentDirectory()}/{filename}");
        }

        //fonction qui permet d'ajouter un bonbon de type Candy dans le tableau de type Candy[]
        private Candy[] AddCandy(Candy[] candies, Candy candy) {
          Candy[] newCandies = new Candy[candies.Length + 1];//cr�ation d'un nouveu tableau avec une case de plus
          for (int i = 0; i < candies.Length; i++)
          {
              newCandies[i] = candies[i];//copier les donn�es du tableau candies dans le tableau newCandies
          }
          newCandies[candies.Length] = candy; //ajouter � la derni�re case ajout� de newCandies les donn�es de candy (nouveau bonbon)
          return newCandies; //on retourne le nouveau tableau aui contient maintenant tous le tableau de d�part + le nouveau bonbon
        }
    }
}
