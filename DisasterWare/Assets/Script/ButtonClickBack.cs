using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickBack : MonoBehaviour
{ 

    public void OnButtonClick()
    {
        FindObjectOfType<SoundManager>().Play("ButtonBack");
    }
}




