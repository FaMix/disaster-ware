using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitSeconds : MonoBehaviour
{
    [SerializeField] private GameObject WaitForGameOver;
     
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForSeconds());
    }

    // Update is called once per frame
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(0.5f);
        WaitForGameOver.SetActive(true);
    }
}
