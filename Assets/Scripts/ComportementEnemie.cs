using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementEnemie : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
        // D�truit l'enemie s'il entre en contacte avec un collider
        Destroy(gameObject);
    }
}
