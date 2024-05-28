using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementEnemiesAnimes : MonoBehaviour //ComportementEnnemiesAnimes
{
    // Clip d'animation d'explosion
    public AnimationClip Explosion;

    // Son de l'explosion
    public AudioClip SonExplosion;

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
            // Partage les mêmes variables que ComportementEnemie
            // Incrémente le score de 1
            ComportementEnemie.Points++;
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
