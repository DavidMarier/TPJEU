using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionArrierePlan : MonoBehaviour
{
    // Détermine la vitesse de l'arrière plan
    public float Vitesse;

    // Détermine la position initiale de l'arrière plan
    public float PositionDebut;

    // Détermine la position finale de l'arrière plan
    public float PositionFin;

    // Update is called once per frame
    void Update()
    {
        // Effectue une translation verticale 
        transform.Translate(0f, -Vitesse, 0f);

        // Quand la translation se termine -> retourne à une position antérieur
        if(transform.position.y <= PositionDebut){
            transform.position = new Vector2(-0.66f, PositionFin);
        }
 
    }
}
