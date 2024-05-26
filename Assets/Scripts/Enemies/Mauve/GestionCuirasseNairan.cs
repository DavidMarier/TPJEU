using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCuirasseNairan : MonoBehaviour
{
    public ComportementTorpilleNairan TorpillePrefab;
    public Transform PositionLancement;
    public Transform PositionLancement2;
    public Transform PositionLancement3;
    public bool signal = false;


    void Start()
    {
        // L'enemie tire
        InvokeRepeating("Actions", 0, 2f);
    }

    void Actions()
    {
        if(signal)
        {
            StartCoroutine(Tire());
        }
    }

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
