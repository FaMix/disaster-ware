using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject loginPage;

    void Start()
    {
        if (!PlayFabClientAPI.IsClientLoggedIn())
        {
            this.loginPage.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
