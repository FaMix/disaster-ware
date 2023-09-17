using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{

    // check if ball collides with something
    void OnCollisionEnter2D(Collision2D col)
    {
        // check if it is a can or a floor
        if (col.gameObject.tag.Equals("Bird"))
        {

            // invoke DestroyBall methid in 3 seconds
            Invoke("NewCandy",0f);

            //destroy ball game object in 3 seconds
            Destroy(gameObject);
        }
    }

    // call DecreaseNumberOfBalls method from instance of GameControlScript
    void NewCandy()
    {
        CandyControlScript.instance.GetNewCandy();
    }

}
