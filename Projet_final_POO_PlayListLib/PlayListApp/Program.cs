using DataRepoLib;
using PlayListLib;

namespace PlayListApp;

public class Program
{
    public static bool DemanderRejourer()
    {
        Console.WriteLine("Retourner au menu pricipal (o/n) : ");
        char reponse = Convert.ToChar(Console.ReadLine());
        if ((reponse == 'o') || (reponse == 'O'))
        {
            return true;
        }

        if ((reponse == 'n') || (reponse == 'N'))
        {
            return false;
        }
        else
        {
            Console.WriteLine($"Vous devez entrer la bonne lettre");
            return DemanderRejourer();
        }
    }

    public static int ReadInt(string message, int start, int end)
    {
        while (true)
        {
            Console.Write(message);
            try
            {
                int result = int.Parse(Console.ReadLine());
                if (result >= start && result <= end)
                {
                    return result;
                }

                Console.WriteLine($"Le nombre doit être entre {start} et {end} inclusivement");
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception ! " + e.Message);
            }
        }
    }

    public static List<Artist> SupprimerArtists(Artist artiste)
    {
        string dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "";
        var artistRepo = new JsonArtistRepo(Path.Combine(dir, "artists1.json"));
        artistRepo.Delete(artiste);
        var artists = artistRepo.SelectAll();
        return artists;
    }

    public static List<Artist> AjouterArtists(Artist artiste)
    {
        string dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "";
        var artistRepo = new JsonArtistRepo(Path.Combine(dir, "artists1.json"));
        artistRepo.Insert(artiste);
        var artists = artistRepo.SelectAll();
        return artists;
    }

    public static List<Song> SupprimerChanson(Song songe)
    {
        string dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "";
        var songRepo = new JsonSongRepo(Path.Combine(dir, "songs1.json"));
        songRepo.Delete(songe);
        var songs = songRepo.SelectAll();
        return songs;
    }

    public static List<Song> AjouterChasnon(Song songe)
    {
        string dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "";
        var songRepo = new JsonSongRepo(Path.Combine(dir, "songs1.json"));
        songRepo.Insert(songe);
        var songs = songRepo.SelectAll();
        return songs;
    }

    public static List<PlayList> AjouterPlayList(string playListe)
    {
        string dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "";
        var playListRepo = new JsonPlayListRepo(Path.Combine(dir, "playlists1.json"));
        playListRepo.Insert(new PlayList(playListe));
        var playLists = playListRepo.SelectAll();
        return playLists;
    }

    /*public static List<PlayList> AjouterChansonPlayList(PlayList playListe, Song songe)
     {
         string dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "";
         var playListRepo = new JsonPlayListRepo(Path.Combine(dir, "playlists1.json"));
         playListRepo.Insert(new Song(songe));
         playListRepo.Update(playListRepo.Insert(playListe,new Song()));
         var playLists = playListRepo.SelectAll();
         return playLists;
     }*/
    public static List<PlayList> SupprimerPlayList(PlayList playListe)
    {
        string dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "";
        var playListRepo = new JsonPlayListRepo(Path.Combine(dir, "playlists1.json"));
        playListRepo.Delete(playListe);
        var playLists = playListRepo.SelectAll();
        return playLists;
    }

    static void Main(string[] args)
    {
        // Partie A PLayListLib && partie B DataRepoLib_________________________________________________________________
        // Insertion de donnees dans la base de donnees de type.json____________________________________________________
        string dir = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? "";

        var artistRepo = new JsonArtistRepo(Path.Combine(dir, "artists1.json"));
        var artists = artistRepo.SelectAll();
        // artistRepo.Insert(new Artist("Metallica","www.metallica.com"));
        // artistRepo.Insert(new Artist("Iron Maiden", "www.ironmaiden.com"));
        // artistRepo.Insert(new Artist("Dumas"));
        // artistRepo.Insert(new Artist("Paul Plamondon"));
        // artists = artistRepo.SelectAll();
        Console.WriteLine("Artistes :");
        Console.WriteLine(string.Join("\n", artists));

        var songRepo = new JsonSongRepo(Path.Combine(dir, "songs1.json"));
        var songs = songRepo.SelectAll();
        // songRepo.Insert(new Song("Enter Sandman", artists[0], 331));
        // songRepo.Insert(new Song("Sad But True", "Metal", artists[0], new Duration(0, 5, 24)));
        // songRepo.Insert(new Song("The Uniforgiven", artists[0], new Duration(0, 3, 47)));
        // songRepo.Insert(new Song("Of Wolf and Man", artists[0], new Duration(0, 4, 16))); 
        // songRepo.Insert(new Song("Caught Somewhere in Time", artists[1], new Duration(0, 7, 27)));
        // songRepo.Insert(new Song("Wasted Years", artists[1], new Duration(0, 5, 09)));
        // songRepo.Insert(new Song("Sea of Madness", artists[1], new Duration(0, 3, 52)));
        // songRepo.Insert(new Song("The Loneliness of the Long Distance Runner", artists[1], new Duration(0, 6, 33)));
        // songRepo.Insert(new Song("J'erre", artists[2], new Duration(0, 2, 48)));
        // songRepo.Insert(new Song("Ne me dis pas", artists[2], new Duration(0, 3, 23)));
        // songRepo.Insert(new Song("Alors Alors", artists[2], new Duration(0, 3, 12)));

        // Console.WriteLine("Chansons :");
        // Console.WriteLine(string.Join("\n", songs));

        var playListRepo = new JsonPlayListRepo(Path.Combine(dir, "playlists1.json"));
        var playLists = playListRepo.SelectAll();
        // playListRepo.Insert(new PlayList("Metallica", songs[0], songs[1], songs[2], songs[3]));
        // playListRepo.Insert(new PlayList("Iron Maiden", songs[4], songs[5], songs[6], songs[7]));
        // playListRepo.Insert(new PlayList("Dumas", songs[8], songs[9],songs[10]));
        // Console.WriteLine("Listes :");
        // Console.WriteLine(string.Join("\n", playLists));

        // Fin de la partie A && B des insertions de donnees dans la base de donnees____________________________________
        // Partie C PlayListApp_________________________________________________________________________________________

        while (true)
        {
            int selectionInt;
            string selectionString1;
            string selectionString2;

            do
            {
                Board.Print("Choisissez le mode", "[1] *Artiste* [2] *Chanson* [3] *PlayList*", "[0] *Quitter*");
                selectionInt = ReadInt("Entrer un nombre entre 0 & 3 ->>>>: ", 0, 3);
            } while (selectionInt != 0 && selectionInt != 1 && selectionInt != 2 && selectionInt != 3);

            if (selectionInt == 0) break;
            if (selectionInt == 1)
            {
                do
                {
                    Board.Print("Mode *ARTIST*",
                        "[1] Afficher *Artiste* [2] Selection *Artist* Id [3] Creer *Artist* [4] supprimer *Artist*",
                        "[0] *Quitter*");
                    selectionInt = ReadInt("Entrer un nombre entre 0 & 4 ->>>>: ", 0, 4);
                } while (selectionInt != 0 && selectionInt != 1 && selectionInt != 2 && selectionInt != 3 &&
                         selectionInt != 4);

                switch (selectionInt)
                {
                    case 0:
                        break;
                    case 1: // Fonctionne
                        Console.WriteLine("Artist :");
                        foreach (var artist in artists)
                        {
                            Console.WriteLine(artist);
                        }

                        Console.ReadKey();


                        break;
                    case 2: // Fonctionne
                        Console.WriteLine("Entrer l'Id de l'Artist :");
                        selectionInt = int.Parse(Console.ReadLine());

                        for (int i = 0; i < artists.Count; i++)
                        {
                            //if (selectionInt.Equals(artists[i].Id))

                            if (selectionInt == artists[i].Id)
                            {
                                Console.WriteLine(artists[i]);
                                break;
                            }
                        }

                        Console.ReadKey();
                        break;
                    case 3: // Fonctionne 
                        Console.WriteLine("Entrer le nom de l'Artiste a ajouter");
                        selectionString1 = Console.ReadLine();
                        bool existant = false;
                        for (int i = 0; i < artists.Count; i++)
                        {
                            if (selectionString1 == (artists[i].Name))
                            {
                                existant = true;
                                Console.WriteLine($"Artiste deja existant");
                                break;
                            }
                        }

                        if (!existant)
                        {
                            artists = AjouterArtists(new Artist(selectionString1));
                            Board.Endmessage("Artist", "ajouté");
                            break;
                        }

                        Console.ReadKey();
                        break;

                    case 4: // Fonctionne
                        Console.WriteLine("Entrer l'Id de l'artiste a supprimer");
                        selectionInt = int.Parse(Console.ReadLine());

                        for (int i = 0; i < artists.Count; i++)
                        {
                            if (selectionInt == artists[i].Id)
                            {
                                artists = SupprimerArtists(artists[i]);
                                break;
                            }
                        }

                        Board.Endmessage("Artist", "supprimé");
                        Console.ReadKey();
                        break;
                }
            }

            else if (selectionInt == 2)
            {
                do
                {
                    Board.Print("Mode *CHANSON*",
                        "[1] Afficher *Chansons* [2] Selection *Id-Chanson* \n|[3] Creer *Chanson* avec nouveau *Artiste* [4] Creer *Chanson* [5] suprimer *Chanson*",
                        "[0] *Quitter*");
                    selectionInt = ReadInt("Entrer un nombre entre 0 & 4 ->>>>: ", 0, 4);
                } while (selectionInt != 0 && selectionInt != 1 && selectionInt != 2 && selectionInt != 3 &&
                         selectionInt != 4 && selectionInt != 5);

                switch (selectionInt)
                {
                    case 0:
                        break;
                    case 1: // Fonctionne
                        Console.WriteLine("Chansons :");
                        Console.WriteLine(string.Join("\n", songs));
                        Console.ReadKey();
                        break;
                    case 2: // Fonctionne
                        Console.WriteLine("Entrer l'Id de la Chanson :");
                        selectionInt = int.Parse(Console.ReadLine());
                        foreach (var song in songs) // utiliser la methode find
                        {
                            if (selectionInt == song.Id)
                            {
                                Console.WriteLine(song);
                            }
                        }

                        Console.ReadKey();
                        break;
                    case 3: // Fonctionne
                        Console.WriteLine("Entrer le titre de la Chanson a ajouter");
                        selectionString1 = Console.ReadLine();
                        Console.WriteLine("Entrer le nouveau *Artist* de la Chanson a ajouter");
                        selectionString2 = Console.ReadLine();
                        Console.WriteLine("Entrer la duree de la Chanson a ajouter en seconde");
                        selectionInt = int.Parse(Console.ReadLine());
                        for (int i = 0; i < songs.Count; i++)
                        {
                            if (selectionString1 != songs[i].Title)
                            {
                                songs = AjouterChasnon(new Song(selectionString1, new Artist(selectionString2),
                                    selectionInt));
                                Board.Endmessage("Nouvelle chansson & nouvelle Artiste", "créé");
                                break;
                            }
                        }

                        Console.ReadKey();
                        break;
                    case 4: // Fonctionne
                        Console.WriteLine("Entrer le titre de la Chanson a ajouter");
                        selectionString1 = Console.ReadLine();
                        Console.WriteLine("Entrer l'Artist de la Chanson a ajouter");
                        selectionString2 = Console.ReadLine();
                        Console.WriteLine("Entrer la duree de la Chanson a ajouter en seconde");
                        selectionInt = int.Parse(Console.ReadLine());
                        for (int i = 0; i < songs.Count; i++)
                        {
                            if (selectionString2 != artists[i].Name)
                            {
                                Board.Endmessage("Artist", "invalide");
                                break;
                            }

                            if (selectionString2 == artists[i].Name)
                            {
                                songs = AjouterChasnon(new Song(selectionString1, artists[i], selectionInt));
                                Board.Endmessage("Nouvelle chansson", "créé");
                                break;
                            }
                        }

                        Console.ReadKey();
                        break;
                    case 5: // Fonctionne
                        Console.WriteLine("Entrer l'Id de la Chanson a supprimer");
                        selectionInt = int.Parse(Console.ReadLine());
                        for (int i = 0; i < songs.Count; i++)
                        {
                            if (selectionInt == songs[i].Id)
                            {
                                songs = SupprimerChanson(songs[i]);
                                break;
                            }
                        }

                        Board.Endmessage("Chanson", "supprimé");
                        Console.ReadKey();
                        break;
                }
            }


            else if (selectionInt == 3)
            {
                do
                {
                    Board.Print("Mode *PLAYLIST*",
                        "[1] Afficher *PlayList* [2] Selection nom *PlayList* [3] Creer *PlayList* \n|[4] supprimer *PlayList* [5] inserer *Chanson*",
                        "[0] *Quitter*");
                    selectionInt = ReadInt("Entrer un nombre entre 0 & 4 : ", 0, 4);
                } while (selectionInt != 0 && selectionInt != 1 && selectionInt != 2 && selectionInt != 3 &&
                         selectionInt != 4 && selectionInt != 5);

                switch (selectionInt)
                {
                    case 0:
                        break;
                    case 1: // Fonctionne
                        Console.WriteLine("PlayList :");
                        Console.WriteLine(string.Join("\n", playLists));
                        Console.ReadKey();
                        break;
                    case 2: // Fonctionne
                        Console.WriteLine("Entrer le nom de la playList :");
                        selectionString1 = Console.ReadLine();
                        foreach (var playlist in playLists)
                        {
                            if (selectionString1 == playlist.Name)
                            {
                                Console.WriteLine(playlist);
                            }
                        }

                        Console.ReadKey();
                        break;
                    case 3: // Fonctionne
                        Console.WriteLine("Entrer le titre de la PlayList a ajouter");
                        selectionString1 = Console.ReadLine();
                        bool existant = false;
                        for (int i = 0; i < playLists.Count; i++)
                        {
                            if (selectionString1 == (playLists[i].Name))
                            {
                                existant = true;
                                Console.WriteLine($"PlayList deja existante");
                                break;
                            }
                        }

                        if (!existant)
                        {
                            playLists = AjouterPlayList(selectionString1);
                            Board.Endmessage("Nouvelle", "PlayList ajouté");
                            break;
                        }

                        Console.ReadKey();

                        break;
                    case 4: // marche pas
                        Console.WriteLine("Entrer le nom de la PlayList a supprimer");
                        selectionString1 = Console.ReadLine();
                        for (int i = 0; i < playLists.Count; i++)
                        {
                            if (selectionString1 == playLists[i].Name)
                            {
                                //playLists = SupprimerPlayList(playLists[i].Name);
                                playLists = SupprimerPlayList(playLists[i]);

                                break;
                            }
                        }

                        Board.Endmessage("PlayList", "supprimé");
                        Console.ReadKey();
                        break;
                    case 5: // marche pas
                        Console.WriteLine("Entrer l'Id de la Chanson a ajouter");
                        selectionInt = int.Parse(Console.ReadLine());
                        Console.WriteLine("Entrer le nom de la PlayList a lequel la Chanson va etre ajoute");
                        selectionString1 = Console.ReadLine();
                        //selectionString2 = PlayList.selectionInt.Id.Find(Console.ReadLine());
                        /*for (int i = 0; i < songs.Count; i++)
                        {
                            if (selectionInt == songs[i].Id)
                            {
                                playLists = AjouterPlayList()
                            }
                        }
                        for (int i = 0; i < playLists.Count; i++)
                        {
                            if (selectionString1 == playLists[i].Name)
                            {
                                songs = AjouterChasnon(songs.Add(selectionInt));
                                Board.Endmessage("Nouvelle chansson", "créé");
                                break;
                            }
                        }*/

                        Console.ReadKey();
                        break;
                }
            }

            if (!DemanderRejourer())
            {
                break;
            }

            Console.Clear();
        }
    }
}