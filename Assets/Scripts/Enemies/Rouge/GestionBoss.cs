using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionBoss : MonoBehaviour
{
    public ComportementTorpilleKlaed TorpillePrefab;
    public ComportementBalleGauche BalleGauchePrefab;
    public ComportementBalleDroite BalleDroitePrefab;
    public Transform PositionLancement;
    public Transform PositionLancement2;
    public Transform PositionLancement3;
    public Transform PositionLancement4;
    public Transform PositionLancement5;
    public Transform PositionLancement6;
    public Transform PositionLancement7;
    public Transform PositionLancement8;
    public Transform PositionLancement9;
    public Transform PositionLancement10;
    public Transform PositionLancement11;
    public bool signal = false;


    void Start()
    {
        // L'enemie tire
        InvokeRepeating("Actions", 0, 1f);
        GetComponent<Animator>().SetBool("arrive", false);
    }

    void Actions()
    {
        if(signal && !ComportementBoss.mortBoss)
        {
            StartCoroutine(TireTorpille());
            StartCoroutine(TireBalleGauche());
            StartCoroutine(TireBalleDroite());
            GetComponent<Animator>().SetBool("arrive", true);
        }
    }

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
