using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCroiseNairan : MonoBehaviour
{
    // Prefab de la torpille
    public ComportementTorpilleNairan TorpillePrefab;

    // Détermine la position de lancement des torpilles
    public Transform PositionLancement;

    // Déclare un signal qui indique si l'ennemie peut tirer
    public bool signal = false;


    void Start()
    {
        // L'enemie tire
        InvokeRepeating("Actions", 0, 1.5f);
    }

    void Actions()
    {
        // Si le signal est actif...
        if(signal)
        {
            // Tire
            StartCoroutine(Tire());
        }
    }

    // Instancie les torpilles avec un délais aléatoire entre 0 et 2 secondes
    IEnumerator Tire()
    {
        float delaisTire = Random.Range(0, 2f);
        // Gère l'attaque
        yield return new WaitForSeconds(delaisTire);
        Instantiate(TorpillePrefab, PositionLancement.position, transform.rotation);
        yield return null;
    }
}
