# Programmation Orientée Objet

## Examen 2

1. À faire individuellement. L'utilisation d'internet est permise, à condition de
   ne pas communiquer avec des personnes autres que le prof au sujet de l'examen.
   L'utilisation du code fourni par le prof est permise.
2. Créez une solution nommé `Examen2_1234567` : remplacez `1234567` par votre
   numéro d'étudiant (votre numéro de DA).
3. Créez un projet de type *bibliothèque de classes* nommé `Question1Lib`.
4. Créez un projet de type *application console* nommé `Question1App`.
5. Créez un projet de type *bibliothèque de classes* nommé `Question2Lib`.
6. Créez un projet de type *application console* nommé `Question2App`.
7. Vous devez *"zipper"* le dossier de votre solution et le remettre sur Léa,
   avant 12h30 le vendredi 27 mai. SVP nettoyer votre solution avant de créer
   le fichier zip.

### Question 1

#### Partie A : `Question1Lib`

Créez la classe `WordList` à partir du diagramme de classes donné plus bas.
Cette classe représente une liste de mots à utiliser, par exemple, dans un jeu
où le but est deviner un mot.

Le constructeur acceptant deux `string` doit
ouvrir le fichier ayant comme nom la valeur de `filename`, lire tout son
contenu, et placer les mots dans la liste de mots. Supposez qu'il y a seulement
un mot par ligne dans le fichier. Vous devez enlever les espaces au début et à
la fin de chaque ligne, convertir le mot en minuscules, et accepter seulement
les mots qui contiennent uniquement des lettres. Pour simplifier un peu, vous
pouvez ignorer les accents, et accepter seulement les mots qui contiennent
uniquement les 26 lettres de l'alphabet (pas de traits d'union ou autres
symboles).

La méthode `GetRandomWord` choisi un mot au hasard dans la liste, l'enlève de la
liste, et le retourne. S'il ne reste aucun mot dans la liste, alors une
exception doit être lancée, et attrapée dans l'application qui utilise cette
méthode.

````plantuml
@startuml
skinparam classAttributeIconSize 0

class WordList {
   +Name : string
   +Words : List<string>
   +Count : int { get; }
   +WordList(string)
   +WordList(string, List<string>)
   +WordList(string, ...string)
   +WordList(name : string, filename : string)
   +GetRandomWord() : string
}

@enduml
````

#### Partie B : `Question1App`

Dans le `Main` du `Program` de cette application :

1. Créez 4 `WordList` différentes, chacune utilisant un constructeur différent.
2. Créez un petit jeu qui demande à l'utilisateur de deviner un mot, à partir
   d'une des listes créées à l'étape précédente. La sortie devrait s'inspirer de
   l'exemple donné plus bas, sans devoir être identique. Un joueur peut jouer
   plusieurs fois et deviner plusieurs mots.
    1. le nombre d'essais infructueux maximum doit être 7
        - seulement les lettres qui ne sont pas dans le mot à deviner, et qui
          n'ont pas déjà été devinées, comptent comme un essai infructueux
    2. la liste de toutes les lettres déjà essayées doit être affichée après
       chaque essai (sans doublons et idéalement en ordre alphabétique)
    3. le mot à deviner doit être partiellement affiché, en incluant seulement
       les lettres déjà devinées correctement

````text
Mot à deviner de 5 lettres
7 essais restants
Lettres devinées : 
Votre lettre : a
_a___
7 essais restants
Lettres devinées : a
Votre lettre : e
_a__e
7 essais restants
Lettres devinées : a e
Votre lettre : s
Incorrect!
_a__e
6 essais restants
Lettres devinées : a e s
Votre lettre : s
Vous avez déjà deviné cette lettre
6 essais restants
Lettres devinées : a e s
Votre lettre : S
Vous avez déjà deviné cette lettre
6 essais restants
Lettres devinées : a e s
Votre lettre : A
Vous avez déjà deviné cette lettre
6 essais restants
Lettres devinées : a e s
Votre lettre : 3
Ceci n'est pas une lettre entre a et z
6 essais restants
Lettres devinées : a e s
Votre lettre : abc
Ceci n'est pas une lettre entre a et z
6 essais restants
Lettres devinées : a e s
Votre lettre : t
ta__e
6 essais restants
Lettres devinées : a e s t
Votre lettre : b
tab_e
6 essais restants
Lettres devinées : a b e s t
Votre lettre : l
table
Bravo!
Voulez-vous jouer une autre fois ? o
Mot à deviner de 6 lettres
7 essais restants
Lettres devinées : 
Votre lettre : q
Incorrect!
______
6 essais restants
Lettres devinées : q
Votre lettre : w
Incorrect!
______
5 essais restants
Lettres devinées : q w
Votre lettre : e
_____e
5 essais restants
Lettres devinées : e q w
Votre lettre : r
Incorrect!
_____e
4 essais restants
Lettres devinées : e q r w
Votre lettre : t
Incorrect!
_____e
3 essais restants
Lettres devinées : e q r t w
Votre lettre : y
Incorrect!
_____e
2 essais restants
Lettres devinées : e q r t w y
Votre lettre : u
Incorrect!
_____e
1 essais restants
Lettres devinées : e q r t u w y
Votre lettre : i
___i_e
1 essais restants
Lettres devinées : e i q r t u w y
Votre lettre : o
Incorrect!
___i_e
Le mot était : chaise
Voulez-vous jouer une autre fois ? n
Bye!
````

### Question 2

#### Partie A : `Question2Lib`

1. Définissez une classe nommée `Character`, qui représente un personnage
   (un *"character"*) dans un jeu du type *Dongeons & Dragons*, en vous basant
   sur le diagramme de classes donné plus bas :
    - les attributs doivent être les suivants :
        - `Id`: un nombre entier positif unique pour pouvoir identifier, ou
          distinguer, tous les personnages
        - `Name`: le nom du personnage
        - les 6 propriétés suivantes, dans l'ordre donné ci-dessous, tous des
          nombres entiers positifs entre 3 et 20 inclusivement, qui
          caractérisent les habilités du personnage : `Strength`
          , `Dexterity`, `Constitution`, `Intelligence`, `Wisdom`
          , `Charisma`
    - le premier constructeur doit pouvoir accepter ces 8 valeurs, dans l'ordre
      donné
    - le deuxième constructeur doit pouvoir accepter les mêmes valeurs, sauf
      le `Id`, qui doit être déterminé automatiquement
2. Redéfinissez les méthodes `ToString`, `Equals` et `GetHashCode` dans cette
   classe. La chaîne retournée devrait contenir toutes les données de façon
   compacte, comme donné ci-dessous.

   Exemple :

   ````(2) Bob [7 4 2 7 12 8]````

   où 2 est l'`id`, `Bob` le nom, et les nombres entre `[]` sont les autres
   attributs dans l'ordre `SDCIWC`: `strength`, `dexterity`, `constitution`,
   `intelligence`, `wisdom`, `charisma`.
3. Définissez les autres classes données dans le diagramme de classes.
    1. La méthode `ToString` doit inclure le type de *character* dans la chaîne
       retournée pour chacune des sous-classes, comme par exemple

       ````{Cleric} (2) Bob [7 4 2 7 12 8]````

       Vous devez soit redéfinir le `ToString` dans chacune des sous-classes,
       soit (idéalement) trouver une façon de modifier le `ToString`
       dans `Character`, pour afficher le nom de la sous-classe dans
       le `ToString` de `Character`
    2. Soyez créatif pour les méthodes `Speak`, `Attack` et `Die`. Ces méthodes
       retournent des `string` parce que faire un vrai jeu complet serait trop
       long et compliqué, donc ces méthodes vont faire semblant de faire quelque
       chose en retournant un string, qui pourra être affiché sur la `Console`
       ou ailleurs dans une application. Vous devez retourner des `string`
       différentes pour chacune de ces méthodes dans chaque classe, qui seront
       différentes des `string` retournées par les `ToString`. Soyez créatif ou
       philosophe, tout en restant dans le bon goût et le respect, pour trouver
       ces `string`. Par exemple, pour `Speak`, vous pourriez
       retourner `Je m'appelle Bob`, et pour `Die`, vous pourriez
       retourner `"RIP Bob"`, ou quelque chose du genre.

````plantuml
@startuml
skinparam classAttributeIconSize 0

abstract class Character {
    {static} +NextId : int
    +Id : int
    +Name : string
    +Strength : int
    +Dexterity : int
    +Constitution : int
    +Intelligence : int
    +Wisdom : int
    +Charisma : int
    +Character(int, string, int, int, int, int, int, int) 
    +Character(string, int, int, int, int, int, int) 
    {abstract} +Speak() : string
    {abstract} +Attack() : string
    {abstract} +Die() : string
}

class Cleric {
    +Cleric(int, string, int, int, int, int, int, int) 
    +Cleric(string, int, int, int, int, int, int)
    +Speak() : string
    +Attack() : string
    +Die() : string
}
Character <|-- Cleric

class Druid {
    +Druid(int, string, int, int, int, int, int, int) 
    +Druid(string, int, int, int, int, int, int)
    +Speak() : string
    +Attack() : string
    +Die() : string
}
Cleric <|-- Druid
 
class Fighter {
    +Fighter(int, string, int, int, int, int, int, int) 
    +Fighter(string, int, int, int, int, int, int)
    +Speak() : string
    +Attack() : string
    +Die() : string
}
Character <|-- Fighter

 
@enduml
````

#### Partie B : `Question2App`

Dans le `Main` du `Program` de cette application :

1. Créez une liste vide de `Character`
2. Créez 2 personnages (`Character`) de chaque type, avec des valeurs
   différentes, et ajoutez-les dans la liste
3. En utilisant le polymorphisme :
    1. Écrivez tous les personnages sur la `Console`
    2. Testez les méthodes `Speak`, `Attack` et `Die` sur tous les personnages.

**Note** : le but ici n'est pas de faire un vrai jeu, mais plutôt de tester les
différentes méthodes. 