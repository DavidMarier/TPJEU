using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementBoss : MonoBehaviour
{
    public AnimationClip Explosion;

    public AudioClip SonExplosion;

    private int vies = 100;

    static public bool mortBoss = false;

    void Start()
    {
        RotationBoss();
        mortBoss = false;
    }

    void RotationBoss()
    {
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }

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
                ComportementEnemie.Points += 5;
                ComportementEnemie.Collision = true;
                mortBoss = true;
                GetComponent<Collider2D>().enabled = false;
                if(transform.parent != null)
                {
                    Destroy(transform.parent.gameObject, Explosion.length);
                } 
            }
        }
    }
}
