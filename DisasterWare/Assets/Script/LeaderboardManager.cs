using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
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
        else
        {
            var request = new GetPlayerProfileRequest
            {
            };
            PlayFabClientAPI.GetPlayerProfile(request, SetCurrentUsername, OnError);
        }
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
    }

    private void SetCurrentUsername(GetPlayerProfileResult result)
    {
        gameObject.GetComponent<PlayFabManager>().loggedInUsername = result.PlayerProfile.DisplayName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
