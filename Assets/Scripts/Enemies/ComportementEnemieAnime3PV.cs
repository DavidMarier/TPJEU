using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ComportementEnemieAnime3PV : MonoBehaviour
{
    public AnimationClip Explosion;

    public AudioClip SonExplosion;

    private int vies = 3;

    private void OnCollisionEnter2D(Collision2D InfoCollision)
    {
        // D�truit l'ennemie s'il entre en contacte avec un collider
        if(InfoCollision.gameObject.tag == "ProjectileJoueur")
        {
            vies--;

            if(vies == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(SonExplosion);
               Destroy(gameObject, Explosion.length);
                GetComponent<Animator>().SetTrigger("explose");
                // Partage les mêmes variables que ComportementEnemie
                ComportementEnemie.Points++;
                ComportementEnemie.Collision = true;
                GetComponent<Collider2D>().enabled = false;
                if(transform.parent != null)
                {
                    Destroy(transform.parent.gameObject, Explosion.length);
                } 
            }
        }
    }
}
