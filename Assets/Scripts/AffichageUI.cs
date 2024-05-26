using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AffichageUI : MonoBehaviour
{

    public TextMeshProUGUI Pointage;
    public TextMeshProUGUI RafraichissementBouclier;
    public Image AffichageBouclier;

    public int DecompteBouclier = 20;
    // Start is called before the first frame update
    void Start()
    {
        RafraichissementBouclier.text = "E";
    }

    // Update is called once per frame
    void Update()
    {
        // Actualise le pointage quand un ennemie est détruit
        if(ComportementEnemie.Collision)
        {
            Pointage.text = "Pointage : " + ComportementEnemie.Points;
            ComportementEnemie.Collision = false;
        }

        if(Input.GetKeyDown(KeyCode.E) && GestionJoueur.PeutActiverBouclier)
        {
            StartCoroutine(Decompte());
        }
    }

    IEnumerator Decompte()
    {
        while(DecompteBouclier > 0)
        {
            AffichageBouclier.color = Color.gray;
            RafraichissementBouclier.text = DecompteBouclier.ToString();
            DecompteBouclier--;
            yield return new WaitForSeconds(1);
            RafraichissementBouclier.text = DecompteBouclier.ToString();
        }
        RafraichissementBouclier.text = "E";
        AffichageBouclier.color = Color.white;
        DecompteBouclier = 20;
    }
}
