using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApparitionEnemies : MonoBehaviour
{
    public Transform PointApparition;
    public GererVagueEnemies VaguesEnemies;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenererEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenererEnemies()
    {
        Instantiate(VaguesEnemies, PointApparition.position, transform.rotation);
        yield return null;
    }
}
