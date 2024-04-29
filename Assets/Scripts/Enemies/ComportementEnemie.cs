using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementEnemie : MonoBehaviour
{
    public AnimationClip Explosion;
    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
        // D�truit l'ennemie s'il entre en contacte avec un collider
        Destroy(gameObject, Explosion.length);
        GetComponent<Animator>().SetTrigger("explose");
    }
}
