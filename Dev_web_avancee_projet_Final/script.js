document.addEventListener("DOMContentLoaded", () => {
  document.getElementById("form").onsubmit = creationRangeeInput;
  document.getElementById("down").onclick = triResultatCroissant;
  document.getElementById("up").onclick = triResultatDecroissant;
  document.getElementById("triId").onclick = triResultatCroissantId;

  Construction5elements();

  let liste = localStorage.getItem("liste-etudiant");
  if (liste != null) {
    liste = JSON.parse(liste);
    liste.forEach((i) => creationRangee(i));
  }

  const boutonSupprimer = document.getElementsByClassName("delete");
  for (let index = 0; index < boutonSupprimer.length; index++) {
    boutonSupprimer[index].addEventListener("click", (event) => {
      // fonction suppression d'une rangee avec index du bouton delete
      event.target.parentElement.parentElement.remove();
      localStorage.removeItem(`${liste[index]}`);
      let listeTemporaire = JSON.parse(localStorage.getItem("liste-etudiant"));
      listeTemporaire.splice(index, 1);
      localStorage.setItem("liste-etudiant", JSON.stringify(listeTemporaire));
      CreationListeEtudiant();
    });
  }

  let inputId = document.getElementsByClassName("idMod");
  let inputNom = document.getElementById("nom");
  let inputPrenom = document.getElementById("prenom");
  let inputResulat = document.getElementById("resultat");
  const boutonModifier = document.getElementsByClassName("mod");
  for (let index = 0; index < boutonModifier.length; index++) {
    boutonModifier[index].addEventListener("click", (event) => {
      //fonction qui remet l'etudiant dans les formulaires et qui nous permets de le modifier. 
      const liste = RafraichirConvertirListe();
      let id =
        event.target.parentElement.parentElement.childNodes[0].textContent;
      let nom =
        event.target.parentElement.parentElement.childNodes[2].textContent;
      let prenom =
        event.target.parentElement.parentElement.childNodes[3].textContent;
      let resultat =
        event.target.parentElement.parentElement.childNodes[4].textContent;
      console.log(id);
      inputId[0] = id;
      inputNom.value = nom;
      inputPrenom.value = prenom;
      inputResulat.value = resultat;
      event.preventDefault();
      event.target.parentElement.parentElement.remove();
      localStorage.removeItem(`${liste[index]}`);
      let listeTemporaire = JSON.parse(localStorage.getItem("liste-etudiant"));
      listeTemporaire.splice(index, 1);
      localStorage.setItem("liste-etudiant", JSON.stringify(listeTemporaire));
    });
  }
});

function CreationListeEtudiant() {
  //fonction qui supprime et recree le tableau selon le localStorage
  let tbody = document.getElementById("tbody");
  let tfoot = document.querySelector("tfoot");
  tbody.remove();
  tbody = document.createElement("tbody");
  tbody.setAttribute("id", "tbody");
  insertAfter(tbody, tfoot);
  liste = RafraichirConvertirListe();
  liste.forEach((etudiant) => {
    creationRangee(etudiant);
    location.reload();
  });
}

function insertAfter(newNode, existingNode) {
  //fonction qui insere apres le <tfoot> le <tbody>
  existingNode.parentNode.insertBefore(newNode, existingNode.nextSibling);
}

function Etudiant(id, nom, prenom, resultat) {
  //Constructeur d'etudiants
  this.id = id;
  this.nom = nom;
  this.prenom = prenom;
  this.resultat = resultat;
}

function Construction5elements() {
  //fonction pour la creation des 5 elements de depart
  const etudiant1 = new Etudiant(1, "Andre", "Demontage", 88);
  const etudiant2 = new Etudiant(2, "Julie", "Tremblay", 76);
  const etudiant3 = new Etudiant(3, "Julien", "Bournival", 45);
  const etudiant4 = new Etudiant(4, "Jean-Thomas", "Lecuyer", 98);
  const etudiant5 = new Etudiant(5, "Emilie", "Jean", 82);
  const tableauEtudiants = [
    etudiant1,
    etudiant2,
    etudiant3,
    etudiant4,
    etudiant5,
  ];
  if (
    RafraichirConvertirListe() == null ||
    RafraichirConvertirListe().length == 0
  ) {
    tableauEtudiants.forEach((etudiant) => {
      sauverItemDansLocalStorage(etudiant);
    });
  }
}

function creationRangee(etudiant) {
  //fonction creation des row a partir des objets (5 de ceux auto et les autres provenant des inputs)

  // Récupération d'un tableau et creation d'une row
  const tab = document.getElementById("tbody");
  const row = document.createElement("tr");
  let td = document.createElement("td");

  // Création de la rangée et de la première cellule (id)
  td = document.createElement("td");
  td.textContent = etudiant.id;
  td.className = "idMod";
  row.appendChild(td);

  // Création de la deuxième cellule (color)
  td = document.createElement("td");
  if (etudiant.resultat < 60) {
    td.className = "red";
  } else {
    td.className = "green";
  }
  row.appendChild(td);

  // Création de la troisieme cellule (nom)
  td = document.createElement("td");
  td.textContent = etudiant.nom;
  td.className = "nomMod";
  row.appendChild(td);

  // Création de la quatrieme cellule (prenom)
  td = document.createElement("td");
  td.textContent = etudiant.prenom;
  td.className = "prenomMod";
  row.appendChild(td);

  // Création de la cinquieme cellule (resultat)
  td = document.createElement("td");
  td.className = "resultat";
  td.textContent = etudiant.resultat;
  row.appendChild(td);

  // Création de la sixieme cellule (bool)
  td = document.createElement("td");
  if (etudiant.resultat < 60) {
    td.textContent = true;
  } else {
    td.textContent = false;
  }
  row.appendChild(td);

  // Création de la septieme cellule (delete) && (modifier)
  td = document.createElement("td");
  const btnSupprimer = document.createElement("button");
  btnSupprimer.type = "button";
  btnSupprimer.className = "fa-solid fa-trash delete";
  td.appendChild(btnSupprimer);

  const btnModifier = document.createElement("button");
  btnModifier.type = "button";
  btnModifier.className = "fa-solid fa-wand-magic-sparkles mod";

  //btnModifier.onclick = modifierEtudiant;
  td.appendChild(btnModifier);
  row.appendChild(td);

  // Ajout de la rangée au tableau
  tab.appendChild(row);
  Calculer();
}

function creationRangeeInput(event) {
  //fonction qui ecoute le formulaire et les inputs
  event.preventDefault();

  // On récupère les inputs des items ainsi que leurs valeurs et ont les passes dans le constructeur ainsi que dans la fonction creationRangee
  const inputNom = document.getElementById("nom");
  const inputPrenom = document.getElementById("prenom");
  const inputResulat = document.getElementById("resultat");
  const id = autoId();
  const nom = inputNom.value;
  const prenom = inputPrenom.value;
  const resultat = inputResulat.value;
  const newEtudiant = new Etudiant(id, nom, prenom, resultat);
  creationRangee(newEtudiant);
  sauverItemDansLocalStorage(newEtudiant);

  // On vide le formulaire
  inputNom.value = "";
  inputPrenom.value = "";
  inputResulat.value = "";
  location.reload();
}

function modifierEtudiant(event) {
  const modification = document.getElementsByClassName(
    "fa-solid fa-wand-magic-sparkles"
  );
  listEtudiant = RafraichirConvertirListe();
  let idEtudiant = 0;
  for (let index = 0; index < listEtudiant.length; index++) {
    modification[index].addEventListener("click", (event) => {
      idEtudiant = listEtudiant[index].id;
      StartEdit(idEtudiant);
      idEtudiant = 0;
    });
  }
}

function triResultatCroissant() {
  //fonction de tri en ordre croissant
  listeEtudiant = RafraichirConvertirListe();
  listeEtudiant.sort(function (a, b) {
    return parseFloat(a.resultat) - parseFloat(b.resultat);
  });
  localStorage.setItem("liste-etudiant", JSON.stringify(listeEtudiant));
  CreationListeEtudiant();
}

function triResultatDecroissant() {
  //fonction de tri en ordre decroissant
  listeEtudiant = RafraichirConvertirListe();
  listeEtudiant.sort(function (a, b) {
    return parseFloat(b.resultat) - parseFloat(a.resultat);
  });
  localStorage.setItem("liste-etudiant", JSON.stringify(listeEtudiant));
  CreationListeEtudiant();
}

function triResultatCroissantId() {
  //fonction de tri en ordre croissant
  listeEtudiant = RafraichirConvertirListe();
  listeEtudiant.sort(function (a, b) {
    return parseFloat(a.id) - parseFloat(b.id);
  });
  localStorage.setItem("liste-etudiant", JSON.stringify(listeEtudiant));
  CreationListeEtudiant();
}

function sauverItemDansLocalStorage(etudiant) {
  //fonction pour sauvegarder les etudiants dans le local Storage
  let liste = localStorage.getItem("liste-etudiant");
  if (liste != null) {
    liste = JSON.parse(liste);
  } else {
    liste = [];
  }

  liste.push(etudiant);
  localStorage.setItem("liste-etudiant", JSON.stringify(liste));
}

function autoId() {
  //fonction attribution auto de Id selon le nombre d'enfants du noeud <tbody>
  const tbody = document.getElementById("tbody");
  if (tbody.childElementCount == 0) {
    return 1;
  } else {
    return parseInt(tbody.lastChild.childNodes[0].textContent) + 1;
  }
}

function numAverage(etudiant) {
  //fonction qui prend un tableau en parametre et qui calcule la moyenne
  let b = etudiant.length,
    c = 0,
    i;
  for (i = 0; i < b; i++) {
    c += Number(etudiant[i]);
  }
  document.getElementById("moyenne").innerHTML =
    Math.round((c / b) * 100) / 100;
}

function Calculer() {
  //fonction qui prend l'ensemble des resultat <td> ayant le className=resulat et qui appel numAverage
  const tabEtudiant = [];
  const resultat = document.getElementsByClassName("resultat");
  for (i = 0; i < resultat.length; i++) {
    tabEtudiant.push(Number(resultat[i].innerHTML));
  }
  numAverage(tabEtudiant);
}

function RafraichirConvertirListe() {
  //fonction qui retourne la liste en javascript du local storage
  return JSON.parse(localStorage.getItem("liste-etudiant"));
}
