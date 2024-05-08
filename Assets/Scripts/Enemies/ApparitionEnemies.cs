using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionEnemies : MonoBehaviour
{
    public Transform PointApparition;
    public GameObject Vague1;
    // public GameObject VagueEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenererEnemies());
    }

    IEnumerator GenererEnemies()
    {
        Instantiate(Vague1, PointApparition.position, transform.rotation);
        yield return null;
    }
}
