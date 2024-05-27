using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionJoueur : MonoBehaviour
{
    public float VitesseDeplacement;
    private int PointDeVie = 4;
    public static bool PeutActiverBouclier = true;
    private bool Mort = false;
    

    public GameObject Bouclier;
    public GameObject Moteur;

    public ComportementProjectile ProjectilePrefab;

    public Transform PositionLancement;

    public AnimationClip Explosion;

    public Image ImageNoire;

    public AudioClip SonMort;
    public AudioClip SonBouclier;

    void Start()
    {
        PeutActiverBouclier = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!Mort)
        {
            Actions();
        }

        if(ComportementBoss.mortBoss)
        {
            StartCoroutine(FonduFin());
            Invoke("Victoire", 1.5f);
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
            GetComponent<AudioSource>().PlayOneShot(SonBouclier);
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
            GetComponent<Collider2D>().enabled = false;
        }

        StartCoroutine(ApparenceJoueur(Explosion));
    }

    // Gère les animations du joueur quand il se prend des dégats et transitoinne vers la scène de défaite
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
            GetComponent<AudioSource>().PlayOneShot(SonMort);
            StartCoroutine(FonduFin());
            yield return new WaitForSeconds(Clip.length);
            Defaite();
            Destroy(gameObject);
        }
        yield return null;
    }

    // Quand le joueur meurt, mène à la scène de défaite

    void Defaite()
    {
        SceneManager.LoadScene("Defaite");
    }

    void Victoire()
    {
        SceneManager.LoadScene("Victoire");
    }

    public IEnumerator FonduFin()
    {
        // Détermine la durée du fondu
        float DureeFondu = 1f;

        float TempsEcoule = 0f;

        while(TempsEcoule < DureeFondu) 
        {
            // Calcule par interpolation la valeur alpha de 0 à 1
            float Alpha = Mathf.Lerp(0f, 1f, TempsEcoule / DureeFondu);
            // Assigne à une NouvelleCouleur la couleur de l'image noire
            Color NouvelleCouleur = ImageNoire.color;
            // Modifie la valeur alpha de la couleur par rapport au calcule par interpolation
            NouvelleCouleur.a = Alpha;
            // Assigne à l'image sa nouvelle couleur
            ImageNoire.color = NouvelleCouleur;
            // Incrémente le temps écoulé
            TempsEcoule += Time.deltaTime;

            yield return null;
        }
    }


}
