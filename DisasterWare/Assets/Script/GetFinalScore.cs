using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using PlayFab;

public class GetFinalScore : MonoBehaviour
{
    public GameObject finalScoreText;
    public GameObject currentScore;


    private void OnEnable()
    {
        GetFinalScoreText();
        

        if (currentScore != null)
        {
            if (finalScoreText.activeSelf == true)
            {
                currentScore.SetActive(false);
            }
        }


    }

    public void GetFinalScoreText()
    {
        Debug.Log("ho chiamato finalscoretext()");
        int finalScore = ScoreManager.instance.GetFinalScore();

        if (finalScore == ScoreManager.instance.GetHighScore())
        {
            if (PlayFabClientAPI.IsClientLoggedIn())
            {
                try
                {
                    gameObject.GetComponent<PlayFabManager>().SendLeaderboard(finalScore);
                }
                catch (PlayFabException e)
                {
                    Debug.LogException(e);
                }
            }
        }

        if (finalScoreText != null)
        {
            TextMeshProUGUI finalScoreChildText = finalScoreText.GetComponentInChildren<TextMeshProUGUI>();
            if (finalScoreChildText != null)
            {
                finalScoreChildText.text = finalScore.ToString();
            }
        }

    }
}
