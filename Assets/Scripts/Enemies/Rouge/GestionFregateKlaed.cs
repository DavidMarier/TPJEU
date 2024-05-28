using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GestionFregateKlaed : MonoBehaviour
{
    // Prefab de la torpille
    public ComportementTorpilleKlaed TorpillePrefab;

    // Détermine les positions de lancement des torpilles
    public Transform PositionLancement;
    public Transform PositionLancement2;

    // Déclare un signal qui indique si l'ennemie peut tirer
    public bool signal = false;


    void Start()
    {
        // L'enemie tire
        InvokeRepeating("Actions", 0, 2.5f);
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

    // Instancie les torpilles avec un délais aléatoire entre 0 et 1.5 secondes
    IEnumerator Tire()
    {
        float delaisTire = Random.Range(0, 1.5f);
        // Gère l'attaque
        yield return new WaitForSeconds(delaisTire);
        Instantiate(TorpillePrefab, PositionLancement.position, transform.rotation);
        Instantiate(TorpillePrefab, PositionLancement2.position, transform.rotation);
        yield return null;
    }
}
