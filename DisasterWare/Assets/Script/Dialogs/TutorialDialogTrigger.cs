using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogTrigger : MonoBehaviour
{
    public MessageT[] messagges;
    public ActorT[] actors;

    // Start is called before the first frame update
    void Start()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        FindObjectOfType<TutorialDialogManager>().OpenDialogue(messagges, actors);
    }
}

[System.Serializable]
public class MessageT
{
    public int actorId;
    public string message;

}
[System.Serializable]
public class ActorT
{
    public string name;
    public Sprite sprite;
}