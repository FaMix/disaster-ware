using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwipeManager : MonoBehaviour
{
    public List<string> sceneNames = new List<string>();
    private Vector2 _startTouchPosition;
    private Vector2 _currentTouchPosition;
    private bool _isSwiping;

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
            }
        }
    }

    private void SwipeUpCheck()
    {
        if (_currentTouchPosition.y - _startTouchPosition.y > 100) // Imposta la distanza minima dello swipe
        {
            _isSwiping = false;
            LoadRandomScene();
        }
    }

    private void LoadRandomScene()
    {
        int randomIndex = Random.Range(0, sceneNames.Count);
        string sceneToLoad = sceneNames[randomIndex];
        SceneManager.LoadScene(sceneToLoad);
    }
}
