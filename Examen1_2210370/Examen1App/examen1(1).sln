# Programmation Orientée Objet

## Examen 1

1. À faire individuellement. L'utilisation d'internet est permis, à condition de
   ne pas communiquer avec des personnes autre que le prof au sujet de l'examen.
   L'utilisation du code fourni par le prof est permis.
2. Créez une solution nommé `Examen1_1234567` : remplacez `1234567` par votre
   numéro d'étudiant (votre numéro de DA).
3. Créez un projet de type *bibliothèque de classes* nommé `Examen1Lib`.
3. Créez un projet de type *application console* nommé `Examen1App`.
4. Vous devez *"zipper"* le dossier de votre solution et le remettre sur Léa,
   avant minuit le dimanche 24 avril. SVP nettoyer votre solution avant de créer
   le fichier zip.

### Partie A : classe `Song`

1. Créez un classe nommée `Song`, représentant une chanson, avec les propriétés
   suivantes:
    - `Id` : un `int` qui doit être généré automatiquement et qui ne peut pas
      être modifié après la création d'une chanson
    - `Title` : le titre de la chanson, une chaîne de caractères d'au moins 1
      caractère
    - `Artist` : le nom de l'artiste, une chaîne de caractères d'au moins 3
      caractères
    - `Seconds` : la durée de la chanson, en secondes, un entier plus grand que
      1
    - `Minutes` : la durée de la chanson, en minutes, un `double` calculé à
      partir de `Seconds`
2. Créez un constructeur qui accepte le titre, le nom de l'artiste et la durée
   en seconde de la chanson.
3. Deux chansons sont égales si elles ont le même `Id`.
4. Le `ToString` doit retourner une chaîne de caractère selon le format donné
   dans l'exemple suivant :

   ```23: Kamikaze (Patrice Michaud) 4:05```


### Partie B : class `PlayList`

1. Créez un classe nommée `PlayList`, représentant une liste de chansons, avec
   les propriétés suivantes:
    - `Name` : le nom de la *play list*, une chaîne de caractères d'au moins 1
      caractère
    - `SongList` : une liste de chansons
    - `Count` : retourne le nombre de chansons dans la liste
2. Créez un constructeur qui accepte le nom de la liste, et qui créé une liste
   de chansons vide
3. Créez une méthode nommée `TotalLength` qui retourne la durée totale (en
   secondes) de toutes les chansons dans la liste.
4. La méthode `ToString` doit retourner une chaîne de caractères contenant tout
   le contenu de la liste ; le format exact est à votre choix
5. Il n'est pas nécessaire de définir d'autres méthodes dans cette classe, mais vous pouvez le faire si désiré.

### Partie C : l'application

1. Dans le `Main` du `Program.cs`, créez 3 `PlayList`s, et placez quelques chansons
   (3 ou 4, ou plus si vous désirez) dans chaque liste
    - les listes doivent être différentes, mais certaines chansons pourraient se
      retrouver dans plus d'une liste
    - vous n'êtes obligé de placer de vraies chansons dans les listes, mais au moins mettez des valeurs raisonnables (pas de valeurs aléatoires)
2. Affichez le nom des 3 listes, et demandez à l'utilisateur de choisir parmi les 3 listes.
3. Affichez le contenu de la liste choisie sur la console, ainsi que la durée totale de toutes les chansons dans un format approprié, tel que `HH:MM:SS` ou `MM:SS` (*heures:minutes:secondes* ou *minutes:secondes*).
4. Demandez à l'utilisateur s'il/elle désire quitter ou revenir au choix de liste, et répétez les étapes 2, 3 et 4 si nécessaire, ou sinon quitter
