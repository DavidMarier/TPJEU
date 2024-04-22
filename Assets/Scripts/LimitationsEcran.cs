using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitationsEcran : MonoBehaviour
{
    public Camera MainCamera; 
    private Vector2 LimitesEcran;
    private float LargeurObjet;
    private float HauteurObjet;

    // Use this for initialization
    void Start(){
        // Prend les dimensions de l'écran
        LimitesEcran = MainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // Récupère la moitié de la largeur du sprite
        LargeurObjet = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        // Récupère la moitié de la hauteur du sprite
        HauteurObjet = transform.GetComponent<SpriteRenderer>().bounds.extents.y; 
    }

    // Update is called once per frame
    void LateUpdate(){
        // Contient la position actuelle de l'objet
        Vector2 Position = transform.position;
        // Contient l'objet dans les limites de l'écran
        Position.x = Mathf.Clamp(Position.x, LimitesEcran.x * -1 + LargeurObjet, LimitesEcran.x - LargeurObjet);
        Position.y = Mathf.Clamp(Position.y, LimitesEcran.y * -1 + HauteurObjet, LimitesEcran.y - HauteurObjet);
        // Actualise la position de l'objet
        transform.position = Position;
    }
}
