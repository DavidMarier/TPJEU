using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class ComportementProjectile : MonoBehaviour
{
    public float Vitesse = 5f;
    private void Update()
    {   
        // Gère la trajectoire du projectile
        transform.Translate(Vector2.up * Vitesse * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
        // Détruit le projectile s'il entre en contacte avec un collider
        Destroy(gameObject);
    }
}
