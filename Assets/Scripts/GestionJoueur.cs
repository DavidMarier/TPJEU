using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GestionJoueur : MonoBehaviour
{
    public float VitesseDeplacement;
    private int PointDeVie = 4;
    private bool PeutActiverBouclier = true;
    private bool Mort = false;
    

    public GameObject Bouclier;
    public GameObject Moteur;

    public ComportementProjectile ProjectilePrefab;

    public Transform PositionLancement;

    public AnimationClip Explosion;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Mort)
        {
            Actions();
        }
    }

    void Actions()
    {
        // Gère les déplacements horizontaux
        float DeplacementX = Input.GetAxis("Horizontal") * VitesseDeplacement * Time.deltaTime;
        // Gère les déplacements verticaux
        float DeplacementY = Input.GetAxis("Vertical") * VitesseDeplacement * Time.deltaTime;
        // Actualise la position en x et en y
        transform.Translate(new Vector2(DeplacementX, DeplacementY));

        // Gère l'attaque
        if (Input.GetKeyDown(KeyCode.Space))
        {         
            Instantiate(ProjectilePrefab, PositionLancement.position, transform.rotation);
        }
        // Gère le bouclier
        if (Input.GetKey(KeyCode.E) && PeutActiverBouclier)
        {
            PeutActiverBouclier = false;
            StartCoroutine(ActivationDesactivationBouclier());
            Invoke("DelaisRecuperationBouclier", 20f);
        }

    }
    // Gère le bouclier
    IEnumerator ActivationDesactivationBouclier()
    {
        Bouclier.SetActive(true);
        Bouclier.GetComponent<CircleCollider2D>().enabled = true;
        yield return new WaitForSeconds(5);
        Bouclier.SetActive(false);
        Bouclier.GetComponent<CircleCollider2D>().enabled = false;
        yield return null;
    }
    void DelaisRecuperationBouclier()
    {
        PeutActiverBouclier = true;
    }
    void OnTriggerEnter2D(Collider2D InfoCollision)
    {
        if(InfoCollision.gameObject.tag == "ProjectileEnemie")
        {
            Bouclier.SetActive(false);
            Bouclier.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    // Gère les dégats pris par le joueur et sa mort
    void OnCollisionEnter2D(Collision2D InfoCollision)
    {
        if(InfoCollision.gameObject && PointDeVie > 0)
        {
            PointDeVie--;
        }

        if(PointDeVie <= 0)
        {
            Mort = true;
        }

        StartCoroutine(ApparenceJoueur(Explosion));
    }

    // Gère les animations du joueur quand il se prend des dégats
    IEnumerator ApparenceJoueur(AnimationClip Clip)
    {
        if(PointDeVie == 3)
        {
             GetComponent<Animator>().SetInteger("75%", 3);
        }
        else if(PointDeVie == 2)
        {
             GetComponent<Animator>().SetInteger("50%", 2);
        }
        else if(PointDeVie == 1)
        {
            GetComponent<Animator>().SetInteger("25%", 1);
        }
        else
        {
            GetComponent<Animator>().SetTrigger("explose");
            Moteur.SetActive(false);
            yield return new WaitForSeconds(Clip.length);
            Destroy(gameObject);
        }
        yield return null;
    }

}
