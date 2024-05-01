using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GererVagueEnemies : MonoBehaviour
{
    public float Vitesse = 0.1f;

    public Camera MainCamera;
    private Vector2 LimitesEcran;
    private float PositionX;
    private float PositionY;
    // Start is called before the first frame update


    private void Awake()
    {
        MainCamera = Camera.main;
    }

    void Start()
    {
        // Prend les dimensions de l'écran
        LimitesEcran = MainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // Récupère la position x de la vague
        PositionX = transform.position.x;
        // Récupère la position y de la vague
        PositionY = transform.position.y;
    }

    private void Update()
    {
        Vector2 Position = transform.position;

        if (Position.x == Mathf.Clamp(Position.x, LimitesEcran.x * -1 + PositionX, LimitesEcran.x - PositionX) && Position.y == Mathf.Clamp(Position.y, LimitesEcran.y * -1 + PositionY, LimitesEcran.y - PositionY))
        {
            GetComponentInChildren<GestionCombattantKlaed>().signal = true;
        }
        else
        {
            GetComponentInChildren<GestionCombattantKlaed>().signal = false;
        }

        // Gère la trajectoire de la vague
        transform.Translate(Vector2.down * Vitesse * Time.deltaTime);
    }
}
