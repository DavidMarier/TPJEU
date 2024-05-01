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
        if(signal)
        {
            // L'enemie tire
            InvokeRepeating("Tirer", 0, 2.5f);
        }
    }

    void Tirer()
    {
        // Gère l'attaque
        Instantiate(TorpillePrefab, PositionLancement.position, transform.rotation);
    }



}
