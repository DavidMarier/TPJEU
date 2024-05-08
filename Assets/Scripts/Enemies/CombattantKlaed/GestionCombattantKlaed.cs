using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCombattantKlaed : MonoBehaviour
{
    public ComportementTorpilleKlaed TorpillePrefab;
    public Transform PositionLancement;
    public bool signal = false;

    void Start()
    {
        // L'enemie tire
        InvokeRepeating("Tirer", 0, 2.5f);
    }

    void Tirer()
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
