using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        GestionFregateKlaed[] lesFregatesKlaed;
        GestionRapideNairan[] lesRapidesNairan;
        GestionCroiseNairan[] lesCroisesNairan;
        GestionCuirasseKlaed[] lesCuirasseKlaed;
        GestionCuirasseNairan[] lesCuirasseNairan;
        Vector2 Position = transform.position;
        
        if (Position.y < 1.25f)
        {
            lesVaisseauxKlaed = GetComponentsInChildren<GestionCombattantKlaed>();
            lesVaisseauxNairan = GetComponentsInChildren<GestionCombattantNairan>();
            lesFregatesKlaed = GetComponentsInChildren<GestionFregateKlaed>();
            lesRapidesNairan = GetComponentsInChildren<GestionRapideNairan>();
            lesCroisesNairan = GetComponentsInChildren<GestionCroiseNairan>();
            lesCuirasseKlaed = GetComponentsInChildren<GestionCuirasseKlaed>();
            lesCuirasseNairan = GetComponentsInChildren<GestionCuirasseNairan>();

            foreach (GestionCombattantKlaed leVaisseau in lesVaisseauxKlaed)
            {
                leVaisseau.signal = true;
            }

            foreach (GestionCombattantNairan leVaisseau in lesVaisseauxNairan)
            {
                leVaisseau.signal = true;
            }

            foreach (GestionFregateKlaed laFregate in lesFregatesKlaed)
            {
                laFregate.signal = true;
            }
            
            foreach (GestionRapideNairan leRapide in lesRapidesNairan)
            {
                leRapide.signal = true;
            }

            foreach (GestionCroiseNairan leCroise in lesCroisesNairan)
            {
                leCroise.signal = true;
            }

            foreach (GestionCuirasseKlaed leCuirasse in lesCuirasseKlaed)
            {
                leCuirasse.signal = true;
            }

            foreach (GestionCuirasseNairan leCuirasse in lesCuirasseNairan)
            {
                leCuirasse.signal = true;
            }
        }
        else
        {
            lesVaisseauxKlaed = GetComponentsInChildren<GestionCombattantKlaed>();
            lesVaisseauxNairan = GetComponentsInChildren<GestionCombattantNairan>();
            lesFregatesKlaed = GetComponentsInChildren<GestionFregateKlaed>();
            lesRapidesNairan = GetComponentsInChildren<GestionRapideNairan>();
            lesCroisesNairan = GetComponentsInChildren<GestionCroiseNairan>();
            lesCuirasseKlaed = GetComponentsInChildren<GestionCuirasseKlaed>();
            lesCuirasseNairan = GetComponentsInChildren<GestionCuirasseNairan>();

            foreach (GestionCombattantKlaed leVaisseau in lesVaisseauxKlaed)
            {
                leVaisseau.signal = false;
            }

            foreach (GestionCombattantNairan leVaisseau in lesVaisseauxNairan)
            {
                leVaisseau.signal = false;
            }

            foreach (GestionFregateKlaed laFregate in lesFregatesKlaed)
            {
                laFregate.signal = false;
            }

            foreach (GestionRapideNairan leRapide in lesRapidesNairan)
            {
                leRapide.signal = false;
            }

            foreach (GestionCroiseNairan leCroise in lesCroisesNairan)
            {
                leCroise.signal = false;
            }

            foreach (GestionCuirasseKlaed leCuirasse in lesCuirasseKlaed)
            {
                leCuirasse.signal = false;
            }

            foreach (GestionCuirasseNairan leCuirasse in lesCuirasseNairan)
            {
                leCuirasse.signal = false;
            }
        }

        // Si la vague dépasse le bas de l'écran, elle se détruit et on passe à la prochaine
        if(Position.y < -2)
        {
            Debug.Log("ok");
            GestionApparitionVagues.noVague++;
            Destroy(gameObject);
            Debug.Log(GestionApparitionVagues.noVague);
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

