using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionEnemies : MonoBehaviour
{
    public Transform PointApparition;

    // Vagues
    public GameObject Vague1;
    public GameObject Vague2;

    //


    
    // Start is called before the first frame update
    void Start()
    {
        GenererEnemies(Vague1);
    }

    public void GenererEnemies(GameObject Vague)
    {
        Instantiate(Vague, PointApparition.position, transform.rotation);
    }

}

// transform.childCount < 1

