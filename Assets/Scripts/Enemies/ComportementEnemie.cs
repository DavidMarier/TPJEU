using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementEnemie : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
        // D�truit l'ennemie s'il entre en contacte avec un collider
        Destroy(gameObject, 0.8f);
        GetComponent<Animator>().SetTrigger("explose");
    }
}
