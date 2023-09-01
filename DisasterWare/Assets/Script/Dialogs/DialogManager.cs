using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public Text messageText;
    public RectTransform backgroundBox;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;

    public static bool isActive = false;

    public GameObject SwipeScene;
    public GameObject DialogBox;
    public Animator animator;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors; 
        activeMessage = 0;
        isActive = true;

        Debug.Log("Starter Message:" + messages.Length);
        DisplayMessage();
    }

    void DisplayMessage() { 
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorImage.sprite = actorToDisplay.sprite;

        if (activeMessage == 0)
        {
            animator.SetBool("isMean", true);
        }
        else if (activeMessage == 1)
        {
            animator.SetBool("isMean", false);
            animator.SetBool("IsSus", true);
        }
        else if(activeMessage == 2)
        {
            animator.SetBool("IsSus", false);
            animator.SetBool("isAngry", true);
        }
        else if (activeMessage == 3)
        {
            animator.SetBool("isAngry", false);
            animator.SetBool("isSurprised", true);
        }
        else if (activeMessage == 4)
        {
            animator.SetBool("isSurprised", false);
            animator.SetBool("IsSus", true);
        }
        else if (activeMessage == 5)
        {
            animator.SetBool("IsSus", false);
            animator.SetBool("isSurprised", true);
        }
        else if (activeMessage == 6)
        {
            animator.SetBool("isSurprised", false);
            animator.SetBool("isMean", true);
        }




    }

    public void NextMessage()
    {
        activeMessage++;
        Debug.Log("Message n:" + activeMessage);
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            isActive = false;
            Debug.Log("Conversation Ended!");
            animator.SetBool("isMean", false);
            SwipeScene.SetActive(true);
            DialogBox.SetActive(false);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Controlla se è stato toccato lo schermo
        if (Input.touchCount > 0 )
        {
            // Controlla se il tocco è un tocco iniziale
            if (Input.GetTouch(0).phase == TouchPhase.Began && isActive == true)
            {
                // Chiamiamo l'azione quando il tocco inizia
                NextMessage();
            }
        }

    }
}
