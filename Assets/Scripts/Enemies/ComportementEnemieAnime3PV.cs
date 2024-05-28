using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ComportementEnemieAnime3PV : MonoBehaviour
{
    // Clip d'animation d'explosion
    public AnimationClip Explosion;

    // Son de l'explosion
    public AudioClip SonExplosion;

    // Les points de vie de l'ennemie
    private int vies = 3;

    private void OnCollisionEnter2D(Collision2D InfoCollision)
    {
        // D�truit l'ennemie s'il entre en contacte avec un collider
        if(InfoCollision.gameObject.tag == "ProjectileJoueur")
        {
            // Décrémente un point de vie
            vies--;

            // Si l'ennemie n'a plus de point de vie...
            if(vies == 0)
            {
                // Joue le son de l'explosion
                GetComponent<AudioSource>().PlayOneShot(SonExplosion);
                // Détruit le gameObject
                Destroy(gameObject, Explosion.length);
                // Anime l'explosion
                GetComponent<Animator>().SetTrigger("explose");
                // Partage les mêmes variables que ComportementEnemie
                // Incrémente le score de 3
                ComportementEnemie.Points += 3;
                ComportementEnemie.Collision = true;
                // Désactive les collisions
                GetComponent<Collider2D>().enabled = false;
                // Détruit le gameObject vide parent quand il se détruit 
                if(transform.parent != null)
                {
                    Destroy(transform.parent.gameObject, Explosion.length);
                } 
            }
        }
    }
}
