using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TexteIntroduction : MonoBehaviour
{
    public GameObject CommencerJeu;
    private bool TexteVisible = false;

    // Start is called before the first frame update
    void Start()
    {  
        // Appel à chaque 0,5 seconde la fonction "ClignotementTexte"
        InvokeRepeating("ClignotementTexte", 0f, 0.5f);
    }

    void ClignotementTexte()
    {
        // Si true -> false, si false -> true
        TexteVisible = !TexteVisible;
        // Active ou désactive le TexteVisible
        CommencerJeu.SetActive(TexteVisible);
    }
    
}
