using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GererVagueEnemies : MonoBehaviour
{
    public float Vitesse = 0.1f;

    /*public Camera MainCamera;
    private Vector2 LimitesEcran;
    private float PositionX;
    private float PositionY;*/
    // Start is called before the first frame update


    /*private void Awake()
    {
        MainCamera = Camera.main;
    }*/

    void Start()
    {
        // // Prend les dimensions de l'�cran
        // LimitesEcran = MainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // // R�cup�re la position x de la vague
        // PositionX = transform.position.x;
        // // R�cup�re la position y de la vague
        // PositionY = transform.position.y;
    }

    public void Update()
    {
        Vector2 Position = transform.position;
        if (Position.y < 1.30f)
        {
            // GetComponentInChildren<GestionCombattantKlaed>().signal = true;

            GestionCombattantKlaed[] lesVaisseau = GetComponentsInChildren<GestionCombattantKlaed>();
            foreach(GestionCombattantKlaed leVaisseau in lesVaisseau)
            {
                leVaisseau.signal = true;
            }
        }
        else
        {
            GestionCombattantKlaed[] lesVaisseau = GetComponentsInChildren<GestionCombattantKlaed>();
            foreach (GestionCombattantKlaed leVaisseau in lesVaisseau)
            {
                leVaisseau.signal = false;
            }
        }

        // G�re la trajectoire de la vague
        transform.Translate(Vector2.down * Vitesse * Time.deltaTime);
    }
}
