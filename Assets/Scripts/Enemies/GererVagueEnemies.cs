using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GererVagueEnemies : MonoBehaviour
{
    public float Vitesse = 0.1f;

    public void Update()
    {
        ApparitionDesEnemies();
        DetecterVagueVide();
    }

    public void ApparitionDesEnemies()
    {
        Vagues();
        // G�re la trajectoire de la vague
        transform.Translate(Vector2.down * Vitesse * Time.deltaTime);
    }

    void Vagues()
    {
        GestionCombattantKlaed[] lesVaisseauxKlaed;
        GestionCombattantNairan[] lesVaisseauxNairan;
        Vector2 Position = transform.position;
        
        if (Position.y < 1.25f)
        {
            lesVaisseauxKlaed = GetComponentsInChildren<GestionCombattantKlaed>();
            lesVaisseauxNairan = GetComponentsInChildren<GestionCombattantNairan>();

            foreach (GestionCombattantKlaed leVaisseau in lesVaisseauxKlaed)
            {
                leVaisseau.signal = true;
            }

            foreach (GestionCombattantNairan leVaisseau in lesVaisseauxNairan)
            {
                leVaisseau.signal = true;
            }
        }
        else
        {
            lesVaisseauxKlaed = GetComponentsInChildren<GestionCombattantKlaed>();
            lesVaisseauxNairan = GetComponentsInChildren<GestionCombattantNairan>();

            foreach (GestionCombattantKlaed leVaisseau in lesVaisseauxKlaed)
            {
                leVaisseau.signal = false;
            }

            foreach (GestionCombattantNairan leVaisseau in lesVaisseauxNairan)
            {
                leVaisseau.signal = false;
            }
        }
  
    }

    // On détecte quand la vague est vide et on détruit le game object vide
    public void DetecterVagueVide()
    {
        if (transform.childCount < 1)
        {
            Debug.Log("ok");
            GestionApparitionVagues.noVague++;
            Destroy(gameObject);
            Debug.Log(GestionApparitionVagues.noVague);
        }
    }
}

