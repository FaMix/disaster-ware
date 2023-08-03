using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{ 

    public void OnButtonClick()
    {
        FindObjectOfType<SoundManager>().Play("ButtonPress");
    }
}




