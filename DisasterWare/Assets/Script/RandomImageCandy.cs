using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;

public class RandomImageCandy : MonoBehaviour
{
    public List<Sprite> immagini; // Una lista delle immagini che vuoi mostrare
    public Image immagineDaMostrare; // Il componente Image dove verrà mostrata l'immagine

    void Start()
    {
        // Assicurati che ci siano almeno alcune immagini nella lista
        if (immagini.Count > 0)
        {
            // Scegli un indice casuale tra 0 e il numero di immagini - 1
            int indiceCasuale = Random.Range(0, immagini.Count);

            // Mostra l'immagine corrispondente all'indice casuale
            immagineDaMostrare.sprite = immagini[indiceCasuale];
        }
        else
        {
            Debug.LogError("La lista delle immagini è vuota. Aggiungi almeno una immagine alla lista.");
        }
    }
}
