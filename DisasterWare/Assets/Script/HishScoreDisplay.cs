using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScoreDisplay : MonoBehaviour
{
    public GameObject highScoreText;
    int highScore;

    void Start()
    {
        UpdateHighScoreText();
    }

    /*private void OnEnable()
    {
        UpdateHighScoreText();
    }*/

    public void UpdateHighScoreText()
    {
        if (ScoreManager.instance == null)
            Debug.Log("instance is null");

        if (ScoreManager.instance != null)
        {
            highScore = ScoreManager.instance.GetHighScore();
            Debug.Log("highscre: "+highScore);
        }

        if (highScoreText != null)
        {
            TextMeshProUGUI childTextMeshPro = highScoreText.GetComponentInChildren<TextMeshProUGUI>();
            if (childTextMeshPro != null)
            {
                childTextMeshPro.text = highScore.ToString();
            }
        }

    }
}
