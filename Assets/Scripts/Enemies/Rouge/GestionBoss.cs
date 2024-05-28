using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionBoss : MonoBehaviour
{
    // Prefab de la torpille
    public ComportementTorpilleKlaed TorpillePrefab;

    // Prefab des balles
    public ComportementBalleGauche BalleGauchePrefab;
    public ComportementBalleDroite BalleDroitePrefab;

    // Détermine les positions de lancement des torpilles
    public Transform PositionLancement;
    public Transform PositionLancement2;
    public Transform PositionLancement3;
    public Transform PositionLancement4;
    public Transform PositionLancement5;

    // Détermine les positions de lancement des balles
    public Transform PositionLancement6;
    public Transform PositionLancement7;
    public Transform PositionLancement8;
    public Transform PositionLancement9;
    public Transform PositionLancement10;
    public Transform PositionLancement11;

    // Déclare un signal qui indique si l'ennemie peut tirer
    public bool signal = false;


    void Start()
    {
        // L'ennemie tire
        InvokeRepeating("Actions", 0, 1f);
        // N'est pas animé
        GetComponent<Animator>().SetBool("arrive", false);
    }

    void Actions()
    {
        // Si le signal est actif et que le boss n'est pas mort...
        if(signal && !ComportementBoss.mortBoss)
        {
            // Tire
            StartCoroutine(TireTorpille());
            StartCoroutine(TireBalleGauche());
            StartCoroutine(TireBalleDroite());
            // S'anime
            GetComponent<Animator>().SetBool("arrive", true);
        }
    }

    // Instancie les torpilles 
    IEnumerator TireTorpille()
    {
        // Gère l'attaque
        Instantiate(TorpillePrefab, PositionLancement.position, transform.rotation);
        Instantiate(TorpillePrefab, PositionLancement2.position, transform.rotation);
        Instantiate(TorpillePrefab, PositionLancement3.position, transform.rotation);
        Instantiate(TorpillePrefab, PositionLancement4.position, transform.rotation);
        Instantiate(TorpillePrefab, PositionLancement5.position, transform.rotation);
        yield return null;
    }

    // Instancie les balles
    IEnumerator TireBalleDroite()
    {
        Instantiate(BalleDroitePrefab, PositionLancement6.position, transform.rotation);
        Instantiate(BalleDroitePrefab, PositionLancement7.position, transform.rotation);
        Instantiate(BalleDroitePrefab, PositionLancement8.position, transform.rotation);
        yield return null;
    }
    IEnumerator TireBalleGauche()
    {
        Instantiate(BalleGauchePrefab, PositionLancement9.position, transform.rotation);
        Instantiate(BalleGauchePrefab, PositionLancement10.position, transform.rotation);
        Instantiate(BalleGauchePrefab, PositionLancement11.position, transform.rotation);
        yield return null;
    }
}
