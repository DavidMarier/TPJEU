using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FonduNoirVictoire : MonoBehaviour
{
    // Image noire du fondu
    private Image ImageNoire;

    // Start is called before the first frame update
    void Start()
    {
        ImageNoire = GetComponent<Image>();
        // Commence le fondu
        StartCoroutine(Fondu());
    }

    // Déclare la coroutine Fondu()
    IEnumerator Fondu()
    {
        // Détermine la durée du fondu
        float DureeFondu = 3f;

        float TempsEcoule = 0f;

        while(TempsEcoule < DureeFondu) 
        {
            // Calcule par interpolation la valeur alpha de 1 à 0
            float Alpha = Mathf.Lerp(1f, 0f, TempsEcoule / DureeFondu);
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
