using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionBouclier : MonoBehaviour
{
    // Le bouclier
    public GameObject Bouclier;

    void OnTriggerEnter2D(Collider2D InfoCollision)
    {
        // Si un projectile ennemie entre en contacte avec le bouclier...
        if(InfoCollision.gameObject.tag == "ProjectileEnemie")
        {
            // Désactive le bouclier
            Bouclier.SetActive(false);
            // Désactive les collisions du bouclier
            Bouclier.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
