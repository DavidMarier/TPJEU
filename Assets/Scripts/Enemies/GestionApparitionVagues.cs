using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionApparitionVagues : MonoBehaviour
{
    // Point d'apparition des vagues
    public Transform PointApparition;

    // Vagues
    public GameObject Vague1;
    public GameObject Vague2;
    public GameObject Vague3;
    public GameObject Vague4;
    public GameObject Vague5;
    public GameObject Vague6;
    public GameObject Vague7;
    public GameObject Vague8;
    public GameObject Vague9;
    public GameObject Vague10;
    public GameObject Vague11;

    // Vagues apparues
    private bool Vague2Bool = false;
    private bool Vague3Bool = false;
    private bool Vague4Bool = false;
    private bool Vague5Bool = false;
    private bool Vague6Bool = false;
    private bool Vague7Bool = false;
    private bool Vague8Bool = false;
    private bool Vague9Bool = false;
    private bool Vague10Bool = false;
    private bool Vague11Bool = false;

    // Numéro de la vague en cours
    public static int noVague = 1;
    
    // Gère l'apparitionde la première vague
    void Start()
    {
        // ! Pour tester les vagues, changer ce numéro !
        noVague = 1;

        if(noVague == 1)
        {
            GenererEnemies(Vague1);
        }
    }

    // Gère l'apparition des autres vagues
    public void Update()
    {
        if(noVague == 2 && !Vague2Bool)
        {
            Vague2Bool = true;
            GenererEnemies(Vague2);
        }
        if(noVague == 3 && !Vague3Bool)
        {
            Vague3Bool = true;
            GenererEnemies(Vague3);
        }
        if(noVague == 4 && !Vague4Bool)
        {
            Vague4Bool = true;
            GenererEnemies(Vague4);
        }
        if(noVague == 5 && !Vague5Bool)
        {
            Vague5Bool = true;
            GenererEnemies(Vague5);
        }
        if(noVague == 6 && !Vague6Bool)
        {
            Vague6Bool = true;
            GenererEnemies(Vague6);
        }
        if(noVague == 7 && !Vague7Bool)
        {
            Vague7Bool = true;
            GenererEnemies(Vague7);
        }
        if(noVague == 8 && !Vague8Bool)
        {
            Vague8Bool = true;
            GenererEnemies(Vague8);
        }
        if(noVague == 9 && !Vague9Bool)
        {
            Vague9Bool = true;
            GenererEnemies(Vague9);
        }
        if(noVague == 10 && !Vague10Bool)
        {
            Vague10Bool = true;
            GenererEnemies(Vague10);
        }
        if(noVague == 11 && !Vague11Bool)
        {
            Vague11Bool = true;
            GenererEnemies(Vague11);
        }

    }

    // Instancie les vagues
    public void GenererEnemies(GameObject Vague)
    {
        Instantiate(Vague, PointApparition.position, transform.rotation);
    }

}

