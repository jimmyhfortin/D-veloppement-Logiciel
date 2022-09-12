# Programmation orientée objet

## Projet : gestion de listes de chansons

#### Diagramme de classes

````plantuml
@startuml
skinparam classAttributeIconSize 0

class Artist {
    {static} +NextId : int
    +Id : int
    +Name : string
    +Website : string
    +Artist()
    +Artist(int, string, string)
    +Artist(string, string)
    +Artist(int, string)
    +Artist(string)
}

class Duration {
    +Hours : int
    +Minutes : int
    +Seconds : int
    +TotalSeconds : int {+get}
    +Duration()
    +Duration(int, int, int)
    +Duration(int)
}

class Song {
    {static} +NextId : int 
    +Id : int
    +Title : string
    +Genre : string
    +Song()
    +Song(int, string, string, Artist, Duration)
    +Song(string, string, Artist, Duration)
    +Song(string, string, Artist, int)
    +Song(string, Artist, Duration)
    +Song(string, Artist, int)
}
Song "*" --> "1" Artist : Artist
Duration "1" <-- "*" Song : Length

class PlayList {
    +Name : string
    +Count : int
    +Playlist()
    +PlayList(string)
    +PlayList(string, List<Song>)
    +PlayList(string, ...Song)
    +Find(int) : Song
    +Add(Song) : void
    +Remove(Song) : bool
    +Remove(int) : bool
}
PlayList "*" o--> "*" Song : Songs
Duration "1" <- "*" PlayList : TotalLength


interface IDataSource {
    +Open() : bool
    +Close() : bool
}

interface IDataRepo<TData, TKey> {
    +SelectAll() : List<TData>
    +Select(TKey) : TData?
    +Insert(TData) : bool
    +Update(TData) : bool
    +Delete(TData) : bool
    +Delete(TKey) : bool
}
IDataSource <|. IDataRepo 

abstract class JsonDataRepo {
    +Filename : string
    +SelectAll() : List<TData>
    +Insert(TData) : bool
    +Update(TData) : bool
    +Delete(TData) : bool
    +Save(List<TData>) : bool
    {abstract} +Select(TKey) : TData?
    {abstract} +Delete(TKey) : bool
}
IDataRepo <|.. JsonDataRepo

class JsonArtistRepo {
    +Select(int) : Artist?
    +Delete(int) : bool
}
JsonDataRepo <|-- JsonArtistRepo : <Artist, int>

class JsonSongRepo {
    +Select(int) : Song?
    +Delete(int) : bool
}
JsonDataRepo <|-- JsonSongRepo : <Song, int>

class JsonPlayListRepo {
    +Select(string) : PlayList?
    +Delete(string) : bool
}
JsonDataRepo <|-- JsonPlayListRepo : <PlayList, string>


Artist <. JsonArtistRepo
Song <. JsonSongRepo
PlayList <.. JsonPlayListRepo

@enduml
````

### Partie A : `PlayListLib`

Créez une bibliothèque de classes nommée `PlayListLib`, contenant les classes
données dans le diagramme de classes suivant. Les méthodes `Equals`,
`GetHashCode`, `ToString` devraient être redéfinies dans chacune de ces
classes. Le format exact des chaînes retournées est à votre choix, mais il doit
tout de même être représentatif et logique.

````plantuml
@startuml
skinparam classAttributeIconSize 0

class Artist {
    {static} +NextId : int 
    +Id : int 
    +Name : string
    +Website : string
    +Artist()
    +Artist(int, string, string)
    +Artist(string, string)
    +Artist(int, string)
    +Artist(string)
}

class Duration {
    +Hours : int
    +Minutes : int
    +Seconds : int
    +TotalSeconds : int {+get}
    +Duration()
    +Duration(int, int, int)
    +Duration(int)
}

class Song {
    {static} +NextId : int 
    +Id : int 
    +Title : string
    +Genre : string
    +Song()
    +Song(int, string, string, Artist, Duration)
    +Song(string, string, Artist, Duration)
    +Song(string, string, Artist, int)
    +Song(string, Artist, Duration)
    +Song(string, Artist, int)
}
Song "*" --> "1" Artist : Artist
Duration "1" <-- "*" Song : Length

class PlayList {
    +Name : string
    +Count : int
    +Playlist()
    +PlayList(string)
    +PlayList(string, List<Song>)
    +PlayList(string, ...Song)
    +Find(int) : Song
    +Add(Song) : void
    +Remove(Song) : bool
    +Remove(int) : bool
}
PlayList "*" o--> "*" Song : Songs
Duration "1" <- "*" PlayList : TotalLength

@enduml
````

### Partie B : `DataRepoLib`

Cette partie contient la couche de données, c'est-à-dire les classes utilisées
pour interagir avec une base de données. Cette version contient seulement une
base de données très simple qui enregistre les données dans des fichiers textes
en format JSON. Il sera possible, dans une version future, d'ajouter des classes
pour interagir avec une vraie base de données, comme par exemple MySQL. Pour ce
projet, il n'est pas nécessaire d'utiliser une vraie base de données.

````plantuml
@startuml
skinparam classAttributeIconSize 0

interface IDataSource {
    +Open() : bool
    +Close() : bool
}

interface IDataRepo<TData, TKey> {
    +SelectAll() : List<TData>
    +Select(TKey) : TData?
    +Insert(TData) : bool
    +Update(TData) : bool
    +Delete(TData) : bool
    +Delete(TKey) : bool
}
IDataSource <|.. IDataRepo 

abstract class JsonDataRepo {
    +Filename : string
    +SelectAll() : List<TData>
    +Insert(TData) : bool
    +Update(TData) : bool
    +Delete(TData) : bool
    +Save(List<TData>) : bool
    {abstract} +Select(TKey) : TData?
    {abstract} +Delete(TKey) : bool
}
IDataRepo <|.. JsonDataRepo : <TData, TKey>

class JsonPlayListRepo {
    +Select(string) : PlayList?
    +Delete(string) : bool
}
JsonDataRepo <|-- JsonPlayListRepo : <PlayList, string>

class JsonArtistRepo {
    +Select(int) : Artist?
    +Delete(int) : bool
}
JsonDataRepo <|-- JsonArtistRepo : <Artist, int>

class JsonSongRepo {
    +Select(int) : Song?
    +Delete(int) : bool
}
JsonDataRepo <|-- JsonSongRepo : <Song, int>

@enduml
````

### Partie C : `PlayListApp`

Ce projet de type *application console* doit utiliser les deux bibliothèques de
classes pour créer une application de gestion de listes de chansons.
L'application devra avoir un certain nombre de menus et de sous-menus permettant
les actions énumérées plus bas. La structure des menus et le texte à écrire sur
la console n'est pas définie exactement, il y a de la flexibilité dans la forme
et la présentation des informations sur la console.

1. Il doit y avoir 3 modes principaux d'utilisation de l'application :
    1. mode **Artiste**
    2. mode **Chanson**
    3. mode **Liste**
2. Dans chaque mode, on doit pouvoir
    1. Sélectionner et afficher tous les objets de ce mode
    2. Sélectionner un objet de ce mode selon sa clé et l'afficher
    3. Insérer un nouvel objet
        - pour une liste de chansons, on peut insérer une liste de chansons vide
          et permettre les actions supplémentaires décrites plus bas
    4. Effacer un objet existant selon sa clé
3. Dans le mode **Liste**, on doit aussi pouvoir
    1. Ajouter une chanson
    2. Enlever une chanson
