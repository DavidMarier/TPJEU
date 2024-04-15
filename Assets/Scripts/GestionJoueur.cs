using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GestionJoueur : MonoBehaviour
{
    public float VitesseDeplacement;
    private bool PeutActiverBouclier = true;
    public GameObject Bouclier;
    public ComportementProjectile ProjectilePrefab;
    public Transform PositionLancement;

    // Update is called once per frame
    void Update()
    {
        Actions();
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

}
