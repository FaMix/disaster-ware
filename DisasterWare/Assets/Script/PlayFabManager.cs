using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.Threading;
//using UnityEditor.UIElements;
//using UnityEditor.PackageManager;

public class PlayFabManager : MonoBehaviour
{
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField nameInput;
    public TMP_Text errorTextLoginBox;
    public TMP_Text errorTextUserBox;
    public GameObject loginBox;
    public GameObject usernameBox;
    public GameObject rowPrefab;
    public Transform rowsParent;
    public string loggedInUsername;

    public GameObject loginSuccesful, registerSuccesful;

    // Start is called before the first frame update
    void Start()
    {
        //Login();

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }

    public void RegisterButton()
    {
        this.loginBox.SetActive(false);
        this.usernameBox.SetActive(true);

    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        this.loggedInUsername = result.Username;
        this.loginBox.SetActive(false);
        this.usernameBox.SetActive(false);
        this.registerSuccesful.SetActive(true);
        Debug.Log("Registrato e loggato con successo");
    }

    public void SubmitNameButton()
    {
        if (nameInput.text.Length > 14)
        {
            this.errorTextUserBox.text = "Username is too long";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            DisplayName = nameInput.text,
            Username = nameInput.text,
            RequireBothUsernameAndEmail = true
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "E8064"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    private void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        Debug.Log("Password reset email inviata");
    }

    /*
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }*/

    void OnSuccess(LoginResult result)
    {
        Debug.Log("Login riuscito/Account creato");
        var request = new GetPlayerProfileRequest
        {
            PlayFabId = result.PlayFabId,
        };
        PlayFabClientAPI.GetPlayerProfile(request, SetCurrentUsername, OnError);

        this.loginBox.SetActive(false);
        this.loginSuccesful.SetActive(true);
    }

    private void SetCurrentUsername(GetPlayerProfileResult result)
    {
        this.loggedInUsername = result.PlayerProfile.DisplayName;
        Debug.Log(this.loggedInUsername);    
    }

    void OnError(PlayFabError error)
    {
        if(this.errorTextLoginBox != null)
            this.errorTextLoginBox.text = error.ErrorMessage;
        if(this.errorTextUserBox != null)
            this.errorTextUserBox.text = error.ErrorMessage;
        Debug.Log("Errore durante login/creazione");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Score",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leadeboard aggiornata con successo");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    private void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            Debug.Log(texts);
            texts[0].text = (item.Position+1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }

    public void GetLeaderboardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Score",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    private void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TMP_Text[] texts = newGo.GetComponentsInChildren<TMP_Text>();
            Debug.Log(texts);
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
            Debug.Log(this.loggedInUsername);
            if (string.Compare(item.DisplayName, this.loggedInUsername) == 0)
            {
                Debug.Log("sono uguali");
                texts[0].color = UnityEngine.Color.cyan;
                texts[1].color = UnityEngine.Color.cyan;
                texts[2].color = UnityEngine.Color.cyan;
            }
        }
    }
}
