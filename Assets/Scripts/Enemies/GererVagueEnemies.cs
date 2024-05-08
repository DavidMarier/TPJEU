using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GererVagueEnemies : MonoBehaviour
{
    public float Vitesse = 0.1f;

    public void Update()
    {
        StartCoroutine(ApparitionDesEnemies());
    }

    IEnumerator ApparitionDesEnemies()
    {
        Vague1();
        // G�re la trajectoire de la vague
        transform.Translate(Vector2.down * Vitesse * Time.deltaTime);
        yield return null;
    }

    void Vague1()
    {
        GestionCombattantKlaed[] lesVaisseaux;
        Vector2 Position = transform.position;
        
        if (Position.y < 1.25f)
        {
            lesVaisseaux = GetComponentsInChildren<GestionCombattantKlaed>();
            foreach(GestionCombattantKlaed leVaisseau in lesVaisseaux)
            {
                leVaisseau.signal = true;
            }
        }
        else
        {
            lesVaisseaux = GetComponentsInChildren<GestionCombattantKlaed>();
            foreach (GestionCombattantKlaed leVaisseau in lesVaisseaux)
            {
                leVaisseau.signal = false;
            }
        }

        // Faire retourner la vague à sa position initiale
        // if(lesVaisseaux.Length == 0 && Position.y < 2)
        // {
        //     transform.Translate(new Vector2(0, 2f));
        // }
        
    }

    void Vague2()
    {
        Vector2 Position = transform.position;

    }
}

