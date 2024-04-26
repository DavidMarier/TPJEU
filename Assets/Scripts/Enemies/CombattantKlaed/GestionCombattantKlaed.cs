using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCombattantKlaed : MonoBehaviour
{
    public ComportementTorpilleKlaed TorpillePrefab;
    public Transform PositionLancement;
    
    void Start()
    {
        // L'enemie tire
        InvokeRepeating("Tirer", 0, 2.5f);
    }

    void Tirer()
    {
        // Gère l'attaque
        Instantiate(TorpillePrefab, PositionLancement.position, transform.rotation);
    }
}
