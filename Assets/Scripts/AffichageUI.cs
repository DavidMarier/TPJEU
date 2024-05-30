using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AffichageUI : MonoBehaviour
{
    // Le texte qui affiche le pointage
    public TextMeshProUGUI Pointage;

    // Le nombre qui indique quand le bouclier redevient disponible
    public TextMeshProUGUI RafraichissementBouclier;

    // Affiche une image du bouclier
    public Image AffichageBouclier;

    // Un décompte qui indique quand le bouclier redevient disponible
    public int DecompteBouclier = 20;

    // Affiche le numéro de la vague actuelle
    public TextMeshProUGUI AffichageNumeroVague;

    // Start is called before the first frame update
    void Start()
    {
        RafraichissementBouclier.text = "E";

        // StartCoroutine(AffichageTexteVague());
    }
    

    // Update is called once per frame
    void Update()
    {

        // Actualise le pointage quand un ennemie est détruit
        if(ComportementEnemie.Collision)
        {
            Pointage.text = ComportementEnemie.Points.ToString();
            ComportementEnemie.Collision = false;
        }

        // Commence le décompte qui indique quand le bouclier redevient disponible lorsqu'on appuie sur E
        if(Input.GetKeyDown(KeyCode.E) && GestionJoueur.PeutActiverBouclier)
        {
            StartCoroutine(Decompte());
        }
    }

    // Gère le décompte
    IEnumerator Decompte()
    {
        // Tant que le décompte est au dessus de 0...
        while(DecompteBouclier > 0)
        {
            // Assombri le bouclier
            AffichageBouclier.color = Color.gray;
            // Affiche le nombre de secondes restantes
            RafraichissementBouclier.text = DecompteBouclier.ToString();
            // Décrémente le compteur
            DecompteBouclier--;
            // Attend une seconde
            yield return new WaitForSeconds(1);
            // Affiche le nombre de secondes restantes
            RafraichissementBouclier.text = DecompteBouclier.ToString();
        }

        // Quand le décompte est fini, on affiche la touche d'activation du bouclier
        RafraichissementBouclier.text = "E";
        // On lui redonne sa couleur originale
        AffichageBouclier.color = Color.white;
        // On remet le compteur à 20
        DecompteBouclier = 20;
    }


    // Gère l'affichage du numéro de la vague actuelle

    // IEnumerator AffichageTexteVague()
    // {
    //     if(true)
    //     {
    //         switch(GestionApparitionVagues.noVague)
    //         {
    //             case 1:
    //                 StartCoroutine(FonduTexteVagueAvant());
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague;
    //                 yield return new WaitForSeconds(1);
    //                 StartCoroutine(FonduTexteVagueApres());
    //             break;
    //             case 2: 
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague; 
    //             break;
    //             case 3: 
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague; 
    //             break;
    //             case 4: 
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague; 
    //             break;
    //             case 5: 
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague; 
    //             break;
    //             case 6: 
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague; 
    //             break;
    //             case 7: 
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague; 
    //             break;
    //             case 8: 
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague; 
    //             break;
    //             case 9: 
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague; 
    //             break;
    //             case 10: 
    //                 AffichageNumeroVague.text = "Vague " + GestionApparitionVagues.noVague; 
    //             break;
    //             case 11: 
    //                 AffichageNumeroVague.text = "Boss"; 
    //             break;
                
    //         } 
    //         yield return new WaitForSeconds(0);
    //     }
    // }

    // IEnumerator FonduTexteVagueApres()
    // {
    //     // Détermine la durée du fondu
    //     float DureeFondu = 1f;

    //     float TempsEcoule = 0f;

    //     while(TempsEcoule < DureeFondu) 
    //     {
    //         // Calcule par interpolation la valeur alpha de 1 à 0
    //         float Alpha = Mathf.Lerp(1f, 0f, TempsEcoule / DureeFondu);
    //         // Assigne à une NouvelleCouleur la couleur du texte
    //         Color NouvelleCouleur = AffichageNumeroVague.color;
    //         // Modifie la valeur alpha de la couleur par rapport au calcule par interpolation
    //         NouvelleCouleur.a = Alpha;
    //         // Assigne au texte sa nouvelle couleur
    //         AffichageNumeroVague.color = NouvelleCouleur;
    //         // Incrémente le temps écoulé
    //         TempsEcoule += Time.deltaTime;
            
    //         yield return null;
    //     }
    // }
    // IEnumerator FonduTexteVagueAvant()
    // {
    //     // Détermine la durée du fondu
    //     float DureeFondu = 1f;

    //     float TempsEcoule = 0f;

    //     while(TempsEcoule < DureeFondu) 
    //     {
    //         // Calcule par interpolation la valeur alpha de 1 à 0
    //         float Alpha = Mathf.Lerp(0f, 1f, TempsEcoule / DureeFondu);
    //         // Assigne à une NouvelleCouleur la couleur du texte
    //         Color NouvelleCouleur = AffichageNumeroVague.color;
    //         // Modifie la valeur alpha de la couleur par rapport au calcule par interpolation
    //         NouvelleCouleur.a = Alpha;
    //         // Assigne au texte sa nouvelle couleur
    //         AffichageNumeroVague.color = NouvelleCouleur;
    //         // Incrémente le temps écoulé
    //         TempsEcoule += Time.deltaTime;
            
    //         yield return null;
    //     }
    // }
}
