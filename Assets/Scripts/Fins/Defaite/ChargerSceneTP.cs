using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChargerSceneTP : MonoBehaviour
{
    // Image noire du fondu
    public Image ImageNoire;

    void Update()
    {
        // Si on appuie sur la barre d'espace...
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // On commence le fondu
            StartCoroutine(FonduIntroduction());
            // On charge la scène de jeu après 2 secondes
            Invoke("ChargerTP", 2f);
            // On remet les points à 0
            ComportementEnemie.Points = 0;

        }
    }

    // Charge la scène de jeu
    void ChargerTP()
    {
        SceneManager.LoadScene("TP");
    }
    
    // Déclare la coroutine Fondu()
    IEnumerator FonduIntroduction()
    {
        // Détermine la durée du fondu
        float DureeFondu = 2f;

        float TempsEcoule = 0f;

        while(TempsEcoule < DureeFondu) 
        {
            // Calcule par interpolation la valeur alpha de 0 à 1
            float Alpha = Mathf.Lerp(0f, 1f, TempsEcoule / DureeFondu);
            // Assigne à une NouvelleCouleur la couleur de l'image noire
            Color NouvelleCouleur = ImageNoire.color;
            // Modifie la valeur alpha de la couleur par rapport au calcule par interpolation
            NouvelleCouleur.a = Alpha;
            // Assigne à l'image sa nouvelle couleur
            ImageNoire.color = NouvelleCouleur;
            // Incrémente le temps écoulé
            TempsEcoule += Time.deltaTime;

            yield return null;
            
        }
    }
}
