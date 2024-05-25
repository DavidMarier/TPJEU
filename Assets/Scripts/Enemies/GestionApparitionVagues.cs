using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionApparitionVagues : MonoBehaviour
{
    public Transform PointApparition;

    // Vagues
    public GameObject Vague1;
    public GameObject Vague2;
    public GameObject Vague3;

    // Vagues apparues
    private bool Vague2Bool = false;
    private bool Vague3Bool = false;

    // Numéro de la vague
    public static int noVague = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        if(noVague == 1)
        {
            GenererEnemies(Vague1);
        }
    }

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
    }
    public void GenererEnemies(GameObject Vague)
    {
        Instantiate(Vague, PointApparition.position, transform.rotation);
    }

}

