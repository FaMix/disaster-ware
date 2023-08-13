using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        int finalScore = ScoreManager.instance.GetFinalScore();

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
