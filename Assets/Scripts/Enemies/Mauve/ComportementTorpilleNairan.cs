using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementTorpilleNairan : MonoBehaviour
{
    public float Vitesse = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        // Détruit le projectile s'il n'a pas touché de gameobject après x secondes
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        // Gère la trajectoire du projectile
        transform.Translate(Vector2.down * Vitesse * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D InfoCollision)
    {
        // Détruit le projectile s'il entre en contacte avec un collider
        if(InfoCollision.gameObject.tag == "Joueur" || InfoCollision.gameObject.tag == "ProjectileJoueur")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D InfoCollision)
    {
        // Détruit le projectile s'il entre en contacte avec un collider
        if(InfoCollision.gameObject.tag == "Bouclier")
        {
            Destroy(gameObject);
        }
    }
}
