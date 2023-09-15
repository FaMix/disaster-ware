using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    public GameObject gameLost;
    public GameObject explotion; 
    public GameObject gameManager;
    public GameObject sliderTimer;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<Player>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if(touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if(slider.value == 0)
        {
            this.endGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Block" && slider.value != 0)
        {
            sliderTimer.GetComponent<TimeBar>().enabled = false;
            gameLost.GetComponent<WaitSeconds>().enabled = true;
            explotion.SetActive(true);
            gameLost.GetComponent<SpriteRenderer>().enabled = false;
            this.endGame();
            
        }
    }

    private void endGame()
    {
        GameManager gameManagerObject = gameManager.GetComponent<GameManager>();
        gameManagerObject.CancelInvoke();
        gameManagerObject.enabled = false;
        gameObject.GetComponent<Player>().enabled = false;
    }
}
