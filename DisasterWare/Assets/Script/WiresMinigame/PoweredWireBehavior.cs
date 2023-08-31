using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PoweredWireBehavior : MonoBehaviour
{

    bool mouseDown = false;
    [SerializeField] private PoweredWireStats poweredWireS;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        poweredWireS = gameObject.GetComponent<PoweredWireStats>();
        lineRenderer = gameObject.GetComponentInParent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWire();
        lineRenderer.SetPosition(3, new Vector3(gameObject.transform.position.x - .1f, gameObject.transform.position.y - .1f, gameObject.transform.position.z));
        lineRenderer.SetPosition(2, new Vector3(gameObject.transform.position.x - .4f, gameObject.transform.position.y - .1f, gameObject.transform.position.z));
    }

    void OnMouseDown()
    {
        mouseDown = true;
    }

    void OnMouseOver()
    {
        poweredWireS.movable = true;
    }

    void OnMouseExit()
    {
        if(!poweredWireS.moving)
        {
            poweredWireS.movable = false;
        }
    }

    void OnMouseUp()
    {
        mouseDown = false;
        if(!this.poweredWireS.connected)
            gameObject.transform.position = poweredWireS.startPosition;
        else
            gameObject.transform.position = poweredWireS.connectedPos;

    }

    void MoveWire()
    {
        if (mouseDown && poweredWireS.movable)
        {
            poweredWireS.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, transform.parent.position.z));
        }
        else
            poweredWireS.moving = false;
    }
}
