using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeBar : MonoBehaviour
{
    public GameObject gameOver;
    public Slider slider;
    public float maxTime;
    float timeLeft;
    bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        //maxTime = 3f;
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver && timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            slider.value = timeLeft / maxTime;
        }
        else if (!isGameOver)
        {
            isGameOver = true;
            //Time.timeScale = 0;
            gameOver.SetActive(true);
        }
    }
}
