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
    public int noVague = 1;

    
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
        if(noVague > 1 && noVague < 3)
            {
                Debug.Log(noVague);
            }
    }
    public void GenererEnemies(GameObject Vague)
    {
        Instantiate(Vague, PointApparition.position, transform.rotation);
    }

}

