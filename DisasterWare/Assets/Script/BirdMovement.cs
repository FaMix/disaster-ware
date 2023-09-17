using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdMovement : MonoBehaviour
{
    public float velocita = 2.0f; // La velocità di movimento dell'uccellino
    public float limiteDestro = 5.0f; // Il limite destro dello schermo
    public float limiteSinistro = -5.0f; // Il limite sinistro dello schermo
    private bool vaiVersoDestra = true; // Indica se l'uccellino sta andando verso destra
    public Sprite mediumSize;
    public Sprite fatSize;
    int hasEaten = 0;
    public Image birdImage;
    public GameObject swipeUp;
    public GameObject slider;
    public GameObject explosion;

    void Update()
    {
        // Muovi l'uccellino verso destra o sinistra
        if (vaiVersoDestra)
        {
            transform.Translate(Vector3.down * velocita * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * velocita * Time.deltaTime);
        }

        // Verifica se l'uccellino ha raggiunto uno dei limiti
        if (transform.position.x >= limiteDestro)
        {
            vaiVersoDestra = false;
        }
        else if (transform.position.x <= limiteSinistro)
        {
            vaiVersoDestra = true;
        }

        if(explosion.activeSelf == true)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // check if it is a can or a floor
        if (col.gameObject.tag.Equals("Candy"))
        {
            hasEaten++;
            if (hasEaten == 1)
            {
                birdImage.sprite = mediumSize;
            }
            else if(hasEaten == 2)
            {
                birdImage.sprite = fatSize;
            }
            else if (hasEaten == 3)
            {
                swipeUp.SetActive(true);
                slider.GetComponent<TimeBarExp>().enabled = false;
            }

        }
    }
}