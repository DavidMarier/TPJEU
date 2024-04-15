using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMoteurs : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update()
    {
        // Active l'animation des moteurs à condition que...
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {         
            GetComponent<Animator>().SetBool("Moteur", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Moteur", false);
        }
    }
}
