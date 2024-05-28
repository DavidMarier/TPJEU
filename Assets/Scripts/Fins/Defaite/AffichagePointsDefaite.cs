using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AffichagePointsDefaite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Affiche le score quand la partie est perdue
        GetComponent<TextMeshProUGUI>().text = "Points : " + ComportementEnemie.Points;
    }

}
