using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanManager : MonoBehaviour
{
    [SerializeField] private GameObject swipeScene;
    [SerializeField] private Slider slider;

    private float cleanPercent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cleanPercent = gameObject.GetComponentInChildren<Clean>().GetDirtAmount();
        endGame();
    }

    void endGame()
    {
        if (slider.value != 0f && cleanPercent<=0.58)
        {
            slider.GetComponent<TimeBar>().enabled = false;
            swipeScene.SetActive(true);
            gameObject.GetComponentInChildren<Clean>().enabled = false;
            this.enabled = false;
            return;
        } else if (slider.value == 0)
        {
            gameObject.GetComponentInChildren<Clean>().enabled = false;
            this.enabled = false;
            return;
        }
    }
}
