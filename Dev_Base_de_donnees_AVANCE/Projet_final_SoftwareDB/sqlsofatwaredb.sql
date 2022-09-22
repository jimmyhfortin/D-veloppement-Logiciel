create database SoftwareDB;
use SoftwareDB;
drop database SoftwareDB;

select * from software;
select * from owner;

insert into pays values(
                1, 'Canada');
insert into pays values(
                2, 'Etats-Unis');
                
/*select * from individus in information_additionnelle where individus_id = 2 ;*/ 
select information_additionnelle from individus where id = 2; 
select C.IDClient,Nom,Prénom,Qte_Achetée from Clients C inner join Achats  A on C.IDClient = A.IDClient;
select addresse,nom from addresses C inner join provinces  A on C.province_id = A.id where individu_id = 2;
SELECT i.id,prenom,nom,telephone from individus as i inner join telephones on i.id = telephones.individu_id limit 10 OFFSET 20;
SET sql_mode=(SELECT REPLACE(@@sql_mode, 'ONLY_FULL_GROUP_BY',''));select i.id,prenom,nom,telephone from individus as i join telephones on i.id = telephones.individu_id group by id having min(i.id) limit 10 offset 0;
SET sql_mode=(SELECT REPLACE(@@sql_mode, 'ONLY_FULL_GROUP_BY',''));select i.id,softwareName,OsSupported,website from software as i join website on i.id = website.softwareId group by id having min(i.id) limit 10 offset 0;
select * from website where softwareId = 1;
select i.id,prenom,nom,telephone from individus as i inner join telephones on i.id = telephones.individu_id limit 10 offset 0;
/*SELECT  from software where ;*/