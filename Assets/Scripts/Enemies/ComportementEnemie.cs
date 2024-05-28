using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementEnemie : MonoBehaviour // ComportementEnnemie
{
    // Clip d'animation d'explosion
    public AnimationClip Explosion;

    // Son de l'explosion
    public AudioClip SonExplosion;

    // Déclare les points
    public static int Points;

    public static bool Collision = false;


    void Start()
    {
        Collision = false;
    }

    private void OnCollisionEnter2D(Collision2D InfoCollision)
    {
        // D�truit l'ennemie s'il entre en contacte avec un collider
        if(InfoCollision.gameObject.tag == "ProjectileJoueur")
        {
            // Joue le son de l'explosion
            GetComponent<AudioSource>().PlayOneShot(SonExplosion);
            // Détruit le gameObject
            Destroy(gameObject, Explosion.length);
            // Anime l'explosion
            GetComponent<Animator>().SetTrigger("explose");
            // Incrémente les points
            Points++;
            Collision = true;
            // Désactive les collisions
            GetComponent<Collider2D>().enabled = false;
        }
        
    }
}
