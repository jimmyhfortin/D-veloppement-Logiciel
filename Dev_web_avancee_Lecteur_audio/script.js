// Votre code ici...
document.addEventListener("DOMContentLoaded" , () => {
    
    let btn_play = document.getElementById("btn-play");
    let lecteur = document.getElementById("lecteur");
    lecteur.src = getChansonActuelle().source;
    afficherChanson();

    /*1  Partir la lecture  */
    btn_play.addEventListener("click", btn_playPauseEventHandler);
    function btn_playPauseEventHandler(event) {
        if(estEnLecture()){
            pauseTrack();
        }
        else{
            playTrack();
        }
        
    }
    function playTrack() {
        lecteur.play();
        document.querySelector("img").src="img/pause.jpg";
        afficherChanson();
    }

    /*2  Faire pause  */
    function pauseTrack() {
        lecteur.pause();
        document.querySelector("img").src="img/play.jpg";
    }

    /*3  Aller à la prochaine chanson  */
    const btn_prochaine = document.getElementById("btn-prochaine");
    btn_prochaine.addEventListener("click", btn_prochaineChansonEventHandler);
    function btn_prochaineChansonEventHandler(event) {
        lecteur.src = getProchaineChanson().source;
        lecteur.play();
        afficherChanson();
    }

    /*4  Aller à la chanson précédente  */
    const btn_precedente = document.getElementById("btn-precedente");
    btn_precedente.addEventListener("click", btn_precedenteChansonEventHandler);
    function btn_precedenteChansonEventHandler(event) {
        lecteur.src = getPrecedenteChanson().source;
        lecteur.play();
        afficherChanson();
    }
    
    //5    Option de boucle (la chanson actuelle est jouée en boucle)
    const ckbx_boucle = document.getElementById("ckbx-boucle");
    ckbx_boucle.addEventListener('change', (event) => {
        if(document.getElementById("ckbx-boucle").checked){
            lecteur.loop = true;
            lecteur.play();
            afficherChanson();
        }
        else{
            lecteur.loop = false;
        }
        
    });
    
    //6    Changement automatique à la prochaine chanson à la fin de la chanson actuelle.
    lecteur.addEventListener('ended', function(e) {
        lecteur.src = getProchaineChanson().source;
        lecteur.play();
        afficherChanson();
    });

    //7    Affichage de la chanson actuelle (Artiste - Nom chanson)
    function afficherChanson (){
        const infoChanson = document.getElementById("info-chanson");
        infoChanson.innerText = `${getChansonActuelle().artiste} - ${getChansonActuelle().titre}`;
    }

    //8 && 9// 8-Affichage du temps écoulé de la chanson /&&/ 9-Affichage du temps total de la chanson
    let tempsChanson = document.getElementById("temps-chanson")
    lecteur.addEventListener('timeupdate', function(e) {
        const duration = parseInt(lecteur.duration);
        tempsChanson.innerText = `${formatSecondsAsTime(lecteur.currentTime)} / ${formatSecondsAsTime(duration)}`;
    });
    
    //10    Gestion du volume
    let volume_slider = document.getElementById("range-volume"); 
    volume_slider.addEventListener('change', (event) => {
        lecteur.volume = volume_slider.value;
    });
     
    //11 && 12// 11-Pouvoir accélérer la lecture (1.5 fois plus vite) /&&/ 12-Pouvoir ralentir la lecture (0.5 fois moins vite)
    const radio_vitesse = document.getElementsByName("radio-vitesse");
    for (let i = 0; i < radio_vitesse.length; i++) {
        radio_vitesse[i].addEventListener('change', (event) =>{
            if(event.target.value == 0.5 || event.target.value == 1 || event.target.value == 1.5){
                lecteur.playbackRate = event.target.value;
                lecteur.defaultPlaybackRate = lecteur.playbackRate;
            };
        })
    };
    
    //13    Changer le thème
    const theme = document.getElementById("select-theme");
    theme.addEventListener('change', (event) => {
        const divContainer = document.getElementById("conteneur-lecteur");
        divContainer.classList.replace(divContainer.classList[0], event.target.value);
    });
    
    
})

//Code du professeur-----------------------------------------------------------------------------
/**
 * Fonction permettant de savoir la chanson actuelle dans la liste <div id="liste-lecture">.
 * La chanson actuelle est celle qui est actuellement en lecture ou celle qui devrait être jouée
 * si l'utilisateur appuie sur play.
 *
 * @returns Retourne sous forme objet le chanson actuelle
 */
function getChansonActuelle() {
    const chansonActuelle = document.getElementsByClassName("chanson-actuelle")[0];
    return {
        artiste: chansonActuelle.dataset.artiste,
        titre: chansonActuelle.dataset.titre,
        source: chansonActuelle.dataset.source,
    };
}

/**
 * Fonction permettant d'avoir la chanson avant la chanson actuelle
 * dans la liste de lecture <div id="liste-lecture">.
 *
 * La chanson précédente devient conséquemment la chanson actuelle.
 *
 * @returns Retourne la chanson précédente sous forme objet.
 */
function getPrecedenteChanson() {
    const chansonActuelle = document.getElementsByClassName("chanson-actuelle")[0];
    let chansonPrecedente = chansonActuelle.previousElementSibling;
    if (chansonPrecedente == null) chansonPrecedente = chansonActuelle.parentElement.lastElementChild;
    chansonActuelle.className = "";
    chansonPrecedente.className = "chanson-actuelle";
    return {
        artiste: chansonPrecedente.dataset.artiste,
        titre: chansonPrecedente.dataset.titre,
        source: chansonPrecedente.dataset.source,
    };
}

/**
 * Fonction permettant d'avoir la prochaine chanson après la chanson actuelle
 * dans la liste de lecture <div id="liste-lecture">.
 *
 * La prochaine chanson devient conséquemment la chanson actuelle.
 *
 * @returns Retourne la prochaine chanson sous forme objet.
 */
function getProchaineChanson() {
    const chansonActuelle = document.getElementsByClassName("chanson-actuelle")[0];
    let prochaineChanson = chansonActuelle.nextElementSibling;
    if (prochaineChanson == null) prochaineChanson = chansonActuelle.parentElement.firstElementChild;
    chansonActuelle.className = "";
    prochaineChanson.className = "chanson-actuelle";
    return {
        artiste: prochaineChanson.dataset.artiste,
        titre: prochaineChanson.dataset.titre,
        source: prochaineChanson.dataset.source,
    };
}

/**
 * Fonction permettant de savoir si oui ou non le lecteur est en lecture.
 *
 * @returns true si le lecteur est en lecture, false dans le cas contraire
 */
function estEnLecture() {
    const lecteur = document.getElementById("lecteur");
    return lecteur.currentTime > 0 && !lecteur.paused && !lecteur.ended && lecteur.readyState > 2;
}

/**
 * Fonction permettant de convertir un nombre de secondes en
 * un format MM:SS sous forme de chaine de caractères.
 *
 * Tiré de https://stackoverflow.com/a/11234208/4759562
 *
 * @param {number} secs Un nombre de secondes
 * @returns Représentation textuelle en format MM:SS
 */
function formatSecondsAsTime(secs) {
    var hr = Math.floor(secs / 3600);
    var min = Math.floor((secs - hr * 3600) / 60);
    var sec = Math.floor(secs - hr * 3600 - min * 60);
    if (min < 10) min = "0" + min;
    if (sec < 10) sec = "0" + sec;
    return min + ":" + sec;
}
