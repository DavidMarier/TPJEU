using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GererVagueEnemies : MonoBehaviour
{
    // Détermine la vitesse d'une vague
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

        VagueBoss();
    }

    // Gère l'activation du signal de chaque vaisseau quand il arrive à une certaine position y
    void Vagues()
    {
        GestionCombattantKlaed[] lesVaisseauxKlaed;
        GestionCombattantNairan[] lesVaisseauxNairan;
        GestionFregateKlaed[] lesFregatesKlaed;
        GestionRapideNairan[] lesRapidesNairan;
        GestionCroiseNairan[] lesCroisesNairan;
        GestionCuirasseKlaed[] lesCuirasseKlaed;
        GestionCuirasseNairan[] lesCuirasseNairan;
        GestionBoss Boss;
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
            Boss = GetComponentInChildren<GestionBoss>();

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

            if(GestionApparitionVagues.noVague == 11)
            {
                Boss.signal = true;
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
            Boss = GetComponentInChildren<GestionBoss>();

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

            if(GestionApparitionVagues.noVague == 11)
            {
                Boss.signal = false;
            }
        }

        // Si la vague dépasse le bas de l'écran, elle se détruit et on passe à la prochaine
        if(Position.y < -2)
        {
            GestionApparitionVagues.noVague++;
            Destroy(gameObject);
        }
    }

    // Quand la vague du boss arrive à la position y 0, elle cesse d'avancer
    public void VagueBoss()
    {
        Vector2 Position = transform.position;

        if(GestionApparitionVagues.noVague == 11)
        {
            if(Position.y < 0)
            {
                Vitesse = 0;
            }
        }
    }

    // On détecte quand la vague est vide et on détruit le game object vide
    public void DetecterVagueVide()
    {
        if (transform.childCount < 1)
        {
            GestionApparitionVagues.noVague++;
            Destroy(gameObject);
        }
    }
}

