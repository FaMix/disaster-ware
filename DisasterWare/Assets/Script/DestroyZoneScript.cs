﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZoneScript : MonoBehaviour {

	// if ball goes out of the screen
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals ("Candy")) {

			// then you lose one attempt
			CandyControlScript.instance.GetNewCandy();

			// and lose a ball
			Destroy (col.gameObject);
		}

		// if it is a can then destroy a can
		//if (col.gameObject.tag.Equals ("Can"))
			//Destroy (col.gameObject);

	}

}
