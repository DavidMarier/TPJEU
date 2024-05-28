using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementBoss : MonoBehaviour
{
    // Clip d'animation d'explosion
    public AnimationClip Explosion;

    // Son de l'explosion
    public AudioClip SonExplosion;

    // Les points de vie du boss
    private int vies = 100;

    // Indique si le boss est mort
    public static bool mortBoss = false;

    void Start()
    {
        RotationBoss();
        // On s'assure que le boss n'est pas mort quand il apparait
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
            // Décrémente les points de vie du boss à chaque fois qu'un projectile le touche
            vies--;

            // Quand les vies sont à 0...
            if(vies == 0)
            {
                // Explose, joue le son de l'explosion, incrémente le score de 5 points, le boss meurt, désactive ses colliders et détruit les gameObjects
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
