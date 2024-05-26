using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementEnemie : MonoBehaviour // ComportementEnnemie
{
    public AnimationClip Explosion;

    public static int Points = 0;

    public static bool Collision = false;

    void Start()
    {
        Points = 0;

        Collision = false;
    }

    private void OnCollisionEnter2D(Collision2D InfoCollision)
    {
        // D�truit l'ennemie s'il entre en contacte avec un collider
        if(InfoCollision.gameObject.tag == "ProjectileJoueur")
        {
            Destroy(gameObject, Explosion.length);
            GetComponent<Animator>().SetTrigger("explose");
            Points++;
            Collision = true;
            GetComponent<Collider2D>().enabled = false;
        }
        
    }
}
