using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarreDeVie : MonoBehaviour
{
    public Slider slider;

    public void AjusterBarreVie(float ValeurActuelle, float ValeurMaximale)
    {
        slider.value = ValeurActuelle / ValeurMaximale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
