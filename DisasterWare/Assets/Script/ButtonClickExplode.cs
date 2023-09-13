using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickExplode : MonoBehaviour
{ 

    public void OnButtonClick()
    {
        FindObjectOfType<SoundManager>().Play("ButtonExplode");
    }
}




