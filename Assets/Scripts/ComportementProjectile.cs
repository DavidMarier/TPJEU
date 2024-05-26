using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class ComportementProjectile : MonoBehaviour
{
    public float Vitesse = 5f;

    private void Update()
    {   
        // Gère la trajectoire du projectile
        transform.Translate(Vector2.up * Vitesse * Time.deltaTime);

        // Détruit le projectile s'il dépasse ou touche à la bordure haute de la caméra
        Vector2 Position = transform.position;
        if(Position.y >= 1.5f)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D infoCollision)
    {
        // Détruit le projectile s'il entre en contacte avec un collider
        Destroy(gameObject);
    }
}
