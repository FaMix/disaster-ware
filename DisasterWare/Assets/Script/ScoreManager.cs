using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score = 0;
    int highscore = 0;
    public GameObject highscoreText;
    public Text currentScoreText;
    public GameObject currentScoreIcon;
    public GameObject currentScoreGO;
    public Text debug;
    public static ScoreManager instance;

    public global::System.Int32 Score { get => score; set => score = value; }
    public Text CurrentScoreText { get => currentScoreText; set => currentScoreText = value; }
    public GameObject CurrentScoreIcon { get => currentScoreIcon; set => currentScoreIcon = value; }
    public GameObject CurrentScoreGO { get => currentScoreGO; set => currentScoreGO = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //highscore = PlayerPrefs.GetInt("highscore");

        if (highscoreText != null)
        {
            TextMeshProUGUI childTextMeshPro = highscoreText.GetComponentInChildren<TextMeshProUGUI>();
            if (childTextMeshPro != null)
            {
                childTextMeshPro.text = highscore.ToString();
            }
        }

        if (CurrentScoreText != null)
        {
            Text childCurrentScoreText = CurrentScoreText.GetComponentInChildren<Text>();
            if (childCurrentScoreText != null)
            {
                childCurrentScoreText.text = Score.ToString();
            }
        }
    }

    public void AddPoints()
    {
        Score += 1;
        //PlayerPrefs.SetInt("score", score);
        debug.text = "Score current: " + Score.ToString();
        if (CurrentScoreText != null)
        {
            Text childCurrentScoreText = CurrentScoreText.GetComponentInChildren<Text>();
            if (childCurrentScoreText != null)
            {
                childCurrentScoreText.text = Score.ToString();
                Debug.Log("PUNTI CAMBIA: " + Score);
            }
        }
        

        if (Score > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", Score);
        }

        
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("highscore", 0) ;
    }

    public int GetFinalScore()
    {
        return Score;
    }

}
