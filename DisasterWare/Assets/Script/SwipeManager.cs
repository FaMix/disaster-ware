using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeManager : MonoBehaviour
{
    public List<string> sceneNames = new List<string>();
    private Vector2 _startTouchPosition;
    private Vector2 _currentTouchPosition;
    private bool _isSwiping;
    private bool _swipeUpDetected;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startTouchPosition = touch.position;
                _isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Moved && _isSwiping)
            {
                _currentTouchPosition = touch.position;
                SwipeUpCheck();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                _isSwiping = false;

                if (_swipeUpDetected)
                {
                    _swipeUpDetected = false;
                    LoadRandomScene();
                }
            }
        }
    }

    private void SwipeUpCheck()
    {
        if (_currentTouchPosition.y - _startTouchPosition.y > 100)  // Imposta la distanza minima dello swipe
        {
            

            if (ScoreManager.instance == null)
            {
                Debug.Log("null");
            }
                
            if (ScoreManager.instance != null)
            {
                //ScoreManager.instance.CurrentScoreIcon.SetActive(true);
                //ScoreManager.instance.CurrentScoreGO.SetActive(true);
                Debug.Log("instance is not null");
                ScoreManager.instance.AddPoints();
            }
            _isSwiping = false;
            _swipeUpDetected = true;
        }
    }

    private void LoadRandomScene()
    {
        int randomIndex = Random.Range(0, sceneNames.Count);
        string sceneToLoad = sceneNames[randomIndex];
        SceneManager.LoadScene(sceneToLoad);
        ScoreManager.instance.CurrentScoreIcon.SetActive(true);
        ScoreManager.instance.CurrentScoreGO.SetActive(true);
    }
     
}
