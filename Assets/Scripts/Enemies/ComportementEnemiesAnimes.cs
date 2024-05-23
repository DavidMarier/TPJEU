using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportementEnemiesAnimes : MonoBehaviour
{
    // Start is called before the first frame update
    public AnimationClip Explosion;
    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
        // D�truit l'ennemie s'il entre en contacte avec un collider
        Destroy(gameObject, Explosion.length);
        GetComponent<Animator>().SetTrigger("explose");
        if(transform.parent != null)
        {
            Destroy(transform.parent.gameObject, Explosion.length);
        }
        
    }
}
