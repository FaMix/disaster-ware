using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireManager : MonoBehaviour
{
    [SerializeField] private List<PoweredWireStats> wires;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject swipeScene;
    private bool allConnected = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckWires();
        CheckEndGame();
    }

    void CheckWires()
    {
        int count = 0;
        foreach (PoweredWireStats wire in wires)
        {
            if (wire.connected)
            {
                count++;
            }
        }
        if (count == 4)
        {
            this.allConnected = true;
        }
        else
        {
            this.allConnected = false;
        }
    }

    void CheckEndGame()
    {
        if (slider.value == 0)
        {
            this.enabled = false;
        foreach (PoweredWireStats wire in wires)
            {
                wire.GetComponent<PoweredWireBehavior>().enabled = false;
            }
            return;
        }
        if (this.allConnected == true && slider.value != 0)
        {
            slider.GetComponent<TimeBarExp>().enabled = false;
            foreach (PoweredWireStats wire in wires)
            {
                wire.GetComponent<PoweredWireBehavior>().enabled = false;
            }
            swipeScene.SetActive(true);
            this.enabled = false;
        }
    }
}
