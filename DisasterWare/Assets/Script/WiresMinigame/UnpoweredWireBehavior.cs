using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpoweredWireBehavior : MonoBehaviour
{
    UnpoweredWireStats unpoweredWireS;

    // Start is called before the first frame update
    void Start()
    {
        unpoweredWireS = GetComponent<UnpoweredWireStats>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageLight();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PoweredWireStats>())
        {
            PoweredWireStats poweredWireS = collision.GetComponent<PoweredWireStats>();
            if (poweredWireS.color == unpoweredWireS.color)
            {
                poweredWireS.connected = true;
                unpoweredWireS.connected = true;
                poweredWireS.connectedPos = gameObject.transform.position;
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PoweredWireStats>())
        {
            PoweredWireStats poweredWireS = collision.GetComponent<PoweredWireStats>();
            poweredWireS.connected = false;
            unpoweredWireS.connected = false;
        }
    }

    void ManageLight()
    {
        if (unpoweredWireS.connected)
        {
            unpoweredWireS.poweredLight.SetActive(true);
            unpoweredWireS.unpoweredLight.SetActive(false);
        }
        else
        {
            unpoweredWireS.poweredLight.SetActive(false);
            unpoweredWireS.unpoweredLight.SetActive(true);
        }
    }
}
