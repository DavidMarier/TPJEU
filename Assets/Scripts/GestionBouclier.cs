using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionBouclier : MonoBehaviour
{
    public GameObject Bouclier;

    void OnTriggerEnter2D(Collider2D InfoCollision)
    {
        if(InfoCollision.gameObject.tag == "ProjectileEnemie")
        {
            Bouclier.SetActive(false);
            Bouclier.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
