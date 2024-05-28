using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AffichagePointsVictoire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Affiche le score quand la partie est gagnée
        GetComponent<TextMeshProUGUI>().text = "Points : " + ComportementEnemie.Points;
        // Change la valeur du meilleur score si le pointage de la partie est supérieur au meilleur score
        if(GestionIntroduction.MeilleurScore < ComportementEnemie.Points)
        {
            GestionIntroduction.MeilleurScore = ComportementEnemie.Points;
        }
    }
}
