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
    public TextMeshProUGUI AffichageNuméroVague;

    // Start is called before the first frame update
    void Start()
    {
        RafraichissementBouclier.text = "E";

        StartCoroutine(FonduTexteVague());
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

    IEnumerator FonduTexteVague()
    {
        yield return new WaitForSeconds(0);
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
}
