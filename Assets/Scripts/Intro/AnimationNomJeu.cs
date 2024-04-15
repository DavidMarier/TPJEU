using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimationNomJeu : MonoBehaviour
{
    private TextMeshProUGUI TexteAnime;
    // Start is called before the first frame update
    void Start()
    {
        TexteAnime = GetComponent<TextMeshProUGUI>();
        StartCoroutine(MouvementTexte());
    }

    IEnumerator MouvementTexte()
    {
        // Détermine la durée de l'animation
        float DureeAnimation = 3f;
        // La position du texte au début de l'animation
        Vector2 PositionDebut = TexteAnime.rectTransform.position;
        // La position du texte à la fin de l'animation
        Vector2 PositionFin = new Vector2(PositionDebut.x, 200f);

        float TempsEcoule = 0f;
        while(TempsEcoule < DureeAnimation)
        {
            // Caclcule par interpolation la position du texte
            Vector2 NouvellePosition = Vector2.Lerp(PositionDebut, PositionFin, TempsEcoule / DureeAnimation);
            // Assigne la nouvelle position
            TexteAnime.rectTransform.position = NouvellePosition;
            // Incrémente le temps écoulé
            TempsEcoule += Time.deltaTime;
            
            yield return null;
        }

        yield return null;
    }
}
