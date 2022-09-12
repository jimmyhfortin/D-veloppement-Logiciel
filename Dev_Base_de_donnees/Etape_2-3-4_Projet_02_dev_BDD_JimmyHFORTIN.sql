                                       /**//**/-- Étape 2: Définition des données (DDL) -- /**//**/
                                            
-- création de la base de donnée
create database Jeux_de_donnees;
-- utilisation de la base donnée Jeux_de_donnees
use Jeux_de_donnees;
-- création des tables (Element, Liste, Tirage et Element_Tirage) --

-- création de la table Liste
create table Liste(
-- clef primaire
idLISTE int primary key,
-- attribut
nomLISTE varchar(50)
);

-- création de la table Element
create table Element(
-- clef primraire
idELEMENT int primary key,
-- attributs
idLISTE int,
nomELEMENT varchar(50),
-- clef étrangère
foreign key(idLISTE) references Liste(idLISTE)
);

-- -- création de la table Tirage
create table Tirage(
-- clef primarire
idTIRAGE int primary key,
-- attributs
idLISTE int,
nomTIRAGE varchar(100),
descriptionTIRAGE text,
dateCreationTIRAGE datetime,
dateEffectueeTIRAGE datetime,
nombreElementsAtirerTIRAGE int,
typeTIRAGE int, -- (inclusif=1 & exculif=0)
-- clef étrangère
foreign key(idLISTE) references Liste(idLISTE)
);

-- -- création de la table Element_Tirage
create table Element_Tirage(
-- clef primaire
Position int,
-- clefs primaire composites
idELEMENT int,
idTIRAGE int,
-- Définition des clefs primarire composites
foreign key(idELEMENT) references Element(idELEMENT),
foreign key(idTIRAGE) references Tirage(idTIRAGE),
primary key(Position,idELEMENT,idTIRAGE)
);
-- 


										/**//**/-- Étape 3: Manipulation des données (DML) --/**//**/

-- ajout des données aux tables précédemment créé --

-- ajout de donnée à la table (Liste)
insert into Liste(idLISTE,nomLISTE) value(01,"Tirage_Lundi");
insert into Liste value(02,"Tirage_Mardi"), (03,"Tirage_Mercredi"), (04,"Tirage_Jeudi"), (05,"Tirage_Fin_de_Semaine"), (06,"Tirage_à_déterminer");
insert into Liste value(07,"Tirage_Surpise");
-- 

-- ajout de donnée à la table (Element)
insert into Element(idELEMENT, idLISTE, nomELEMENT) value(101,01,"Voiture");
insert into Element value(102,02,"Bateaux"), (103,02,"Maison"), (104,01,"Voyage"), (105,02,"Tout-Terrain"),(106,06,"Escapade_Tropicale");
-- 

-- ajout de donnée à la table (Tirage)
insert into Tirage(idTIRAGE, idLISTE, nomTIRAGE, descriptionTIRAGE, dateCreationTIRAGE, dateEffectueeTIRAGE,nombreElementsAtirerTIRAGE,typeTIRAGE) value(201,01,"Premier_Tirage", "Tirage_premiere_chance","2022-08-13","2021-08-13",1,0);
insert into Tirage value(202,02,"Deuxieme_Tirage", "Tirage_deuxieme_chance","2022-07-10","2022-08-16",1,1), (203,02,"Troisieme_Tirage", "Tirage_troisieme_chance","2022-02-09","2022-06-22",1,1), (204,03,"Quatrieme_Tirage", "Tirage_quatrieme_chance","2022-03-10","2022-05-05",1,0),(205,04,"Cinquieme_Tirage", "Tirage_cinquieme_chance","2022-04-13","2022-04-26",1,0);
insert into Tirage value(206,02,"Derniere_chance", "Derniere_chance","2022-05-10","2022-08-14",4,1);
-- 

-- ajout de donnée à la table (Element_Tirage)
insert into Element_Tirage(idELEMENT, idTIRAGE, Position) value(101,201,1), (105,203,2), (104,204,3), (103,202,4),(101,205,5), (102,201,6), (105,205,7);
insert into Element_Tirage(idELEMENT, idTIRAGE, Position) value(105,206,8);
--

										/**//**/-- Étape 4: Requêtage des données (DQL) --/**//**/

-- interrogation demandée à la base de données 

-- Requête #1
select idTIRAGE,idELEMENT,idListe from Element_Tirage,Liste order by idLISTE; 

-- Requête #2
select Liste.idLISTE,count(idELEMENT),count(idTIRAGE) from Liste,Element_Tirage natural join Tirage group by Liste.idLISTE order by idLISTE;

-- Requête #3
select nomELEMENT,idLISTE from Element where idLISTE = 2; 

-- Requête #4
select distinct Liste.idLISTE from Liste where Liste.idLISTE NOT IN(select idLISTE from Tirage); -- GOOD

-- Requête #5
select nomELEMENT,typeTIRAGE from Element inner join Tirage where typeTIRAGE = 1 group by nomELEMENT; -- GOOD par moi a revoir 

-- Requête #6
select distinct position,idELEMENT,typeTIRAGE from Element_Tirage inner join Tirage on typeTIRAGE = 1 order by Position; -- ok

-- Requête #7
select distinct Tirage.idLISTE,dateEffectueeTIRAGE from Element_Tirage,Tirage where dateEffectueeTIRAGE < "2021-08-14" order by idLISTE; -- GOOD

-- Requête #8
select Tirage.idLISTE,typeTIRAGE from Tirage where typeTIRAGE > 0 order by idLISTE; -- GOOOOOOOOOD

-- Requête #9
select distinct Element.idELEMENT,Element_Tirage.idTIRAGE,Liste.idLISTE from Element,Element_Tirage,Liste where Element.idELEMENT NOT IN(select idELEMENT from Element_Tirage) order by Element.idELEMENT; 

-- Requête #10
select count(*) as 'Nombre des listes qui ne conitennet pas encore des éléments' from Element,Liste where Element.idELEMENT NOT IN(select idLISTE from Liste) order by Element.idELEMENT;


-- Fin.  


