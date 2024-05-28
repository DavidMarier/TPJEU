using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCuirasseKlaed : MonoBehaviour
{
    // Prefab de la torpille
    public ComportementTorpilleKlaed TorpillePrefab;

    // Détermine les positions de lancement des torpilles 
    public Transform PositionLancement;
    public Transform PositionLancement2;
    public Transform PositionLancement3;

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

    // Instancie les torpille avec un délais aléatoire entre 0 et 1.5 secondes
    IEnumerator Tire()
    {
        float delaisTire = Random.Range(0, 1.5f);
        // Gère l'attaque
        yield return new WaitForSeconds(delaisTire);
        Instantiate(TorpillePrefab, PositionLancement.position, transform.rotation);
        Instantiate(TorpillePrefab, PositionLancement2.position, transform.rotation);
        Instantiate(TorpillePrefab, PositionLancement3.position, transform.rotation);
        yield return null;
    }
}
