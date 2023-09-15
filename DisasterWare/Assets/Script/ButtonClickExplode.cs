using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickExplode : MonoBehaviour
{

    void Start() {
        FindObjectOfType<SoundManager>().Play("ButtonExplode");
    }
    
}




