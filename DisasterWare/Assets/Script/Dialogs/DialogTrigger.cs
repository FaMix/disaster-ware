using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Message[] messagges;
    public Actor[] actors;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messagges, actors);
    }
}

[System.Serializable]
public class Message
{
    public int actorId;
    public string message;

}
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}