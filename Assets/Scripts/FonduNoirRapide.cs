using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FonduNoirRapide : MonoBehaviour
{
    private Image ImageNoire;
    // Start is called before the first frame update
    void Start()
    {
        ImageNoire = GetComponent<Image>();
        StartCoroutine(Fondu());
    }

    // Déclare la coroutine Fondu()
    IEnumerator Fondu()
    {
        // Détermine la durée du fondu
        float DureeFondu = 1f;

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

