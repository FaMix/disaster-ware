using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPoints : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.Score = 0;
            ScoreManager.instance.CurrentScoreIcon.SetActive(false);
            ScoreManager.instance.CurrentScoreGO.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
