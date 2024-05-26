using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCroiseNairan : MonoBehaviour
{
    public ComportementTorpilleNairan TorpillePrefab;
    public Transform PositionLancement;
    public bool signal = false;


    void Start()
    {
        // L'enemie tire
        InvokeRepeating("Actions", 0, 1.5f);
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
        float delaisTire = Random.Range(0, 2f);
        // Gère l'attaque
        yield return new WaitForSeconds(delaisTire);
        Instantiate(TorpillePrefab, PositionLancement.position, transform.rotation);
        yield return null;
    }
}
