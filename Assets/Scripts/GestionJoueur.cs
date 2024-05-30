using System.Collections;
using System.Collections.Generic;
// using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GestionJoueur : MonoBehaviour
{
    // La vitesse à laquelle se déplace le joueur
    public float VitesseDeplacement;

    // Points de vie du joueur
    public float PointDeVie = 4;
    // Points de vie maximum du joueur
    public float PointDeVieMaximum = 4;

    // Détermine si le joueur peut activer le bouclier
    public static bool PeutActiverBouclier = true;

    // Détermine si le joueur est mort
    private bool Mort = false;

    // Détermine si le joueur peut tirer
    private bool PeutTirer = true;
    
    // Le Bouclier
    public GameObject Bouclier;

    // Le moteur
    public GameObject Moteur;

    // Prefab de la torpille
    public ComportementProjectile ProjectilePrefab;

    // La position de lancement des torpilles
    public Transform PositionLancement;

    // Clip d'animation d'explosion
    public AnimationClip Explosion;

    // Image du fondu
    public Image ImageNoire;

    // Son de l'explosion
    public AudioClip SonMort;

    // Son du bouclier
    public AudioClip SonBouclier;

    // Son du tire
    public AudioClip SonTire;

    // Son du joueur quand il se prend des dégats
    public AudioClip SonTouche;

    // La barre de vie du joueur
    public BarreDeVie BarreVieJoueur;

    void Awake()
    {
        BarreVieJoueur = GetComponentInChildren<BarreDeVie>();
    }

    void Start()
    {
        PeutActiverBouclier = true;
        BarreVieJoueur.AjusterBarreVie(PointDeVie, PointDeVieMaximum);
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
        if (Input.GetKeyDown(KeyCode.Space) && PeutTirer)
        {         
            Instantiate(ProjectilePrefab, PositionLancement.position, transform.rotation);
            PeutTirer = false;
            GetComponent<AudioSource>().PlayOneShot(SonTire);
            Invoke("DelaisRecuperationTire", 0.5f);
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
        yield return new WaitForSeconds(1);
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
            BarreVieJoueur.AjusterBarreVie(PointDeVie, PointDeVieMaximum);
            GetComponent<AudioSource>().PlayOneShot(SonTouche);
        }

        if(PointDeVie <= 0)
        {
            Mort = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<AudioSource>().PlayOneShot(SonMort);
        }

        StartCoroutine(ApparenceJoueur(Explosion));
    }

    void DelaisRecuperationTire()
    {
        PeutTirer = true;
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

    // Quand le joueur gagne, mène à la scène de victoire
    
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
