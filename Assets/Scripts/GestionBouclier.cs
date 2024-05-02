using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionBouclier : MonoBehaviour
{
    public GameObject Bouclier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D InfoCollision)
    {
        if(InfoCollision.gameObject.tag == "ProjectileEnemie")
        {
            Bouclier.SetActive(false);
            Bouclier.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
}
