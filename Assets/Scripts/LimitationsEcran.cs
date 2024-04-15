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
        LargeurObjet = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        HauteurObjet = transform.GetComponent<SpriteRenderer>().bounds.extents.y; 
    }

    // Update is called once per frame
    void LateUpdate(){
        Vector2 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, LimitesEcran.x * -1 + LargeurObjet, LimitesEcran.x - LargeurObjet);
        viewPos.y = Mathf.Clamp(viewPos.y, LimitesEcran.y * -1 + HauteurObjet, LimitesEcran.y - HauteurObjet);
        transform.position = viewPos;
    }
}
