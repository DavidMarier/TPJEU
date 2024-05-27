using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionIntroduction : MonoBehaviour
{
    private Image ImageNoire;

    public AudioClip SonDebut;

    void Start()
    {
        ImageNoire = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Permet de commencer le jeu en chargeant la scène "TP". 
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            StartCoroutine(Fondu());
            GetComponent<AudioSource>().PlayOneShot(SonDebut);
        }
    }

    // Déclare la coroutine Fondu()
    IEnumerator Fondu()
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
            // Appel la fonction CommencerJeu avec un délais de 3 secondes
            Invoke("CommencerJeu", 3f);
        }
    }

    void CommencerJeu()
    {   
        // Charge la scène "TP"
        SceneManager.LoadScene("TP");
    }
}
