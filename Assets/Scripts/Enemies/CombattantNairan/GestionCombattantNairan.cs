using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GestionCombattantNairan : MonoBehaviour
{
    public ComportementTorpilleNairan TorpillePrefab;
    public Transform PositionLancement;
    public bool signal = true;

    void Start()
    {
        // L'enemie tire et se déplace
        InvokeRepeating("Actions", 0, 2.5f);
    }

    void Actions()
    {
        if(signal)
        {
            StartCoroutine(Tire());
            StartCoroutine(Deplacement());
        }
    }

    IEnumerator Tire()
    {
        float delaisTire = Random.Range(0, 2f);
        // Gère l'attaque
        yield return new WaitForSeconds(delaisTire);
        Instantiate(TorpillePrefab, PositionLancement.position, transform.rotation);
        yield return null;
    }

    IEnumerator Deplacement()
    {
        transform.Translate(new Vector2(0.5f, 0));
        yield return new WaitForSeconds(2f);
        transform.Translate(new Vector2(-0.5f, 0));
        yield return new WaitForSeconds(2f);
    }
}
