using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour {

GameObject slingshot;
GameObject bubbles;
int playerselect;


	void Start () {
		playerselect = 1;
		slingshot = GameObject.Find("Slingshot");
		bubbles = GameObject.Find("Bubbles");
	}

	void Update ()
	{
		if (Input.GetButtonDown("Switch"))
		{
			if (playerselect == 1)
			{
				playerselect = 2;
			}

			else if (playerselect == 2)
			{
				playerselect = 1;
			}
		}
		if (playerselect == 1)
		{
			slingshot.SetActive(true);
			bubbles.SetActive(false);
		}

		else if (playerselect == 2)
		{
			slingshot.SetActive(false);
			bubbles.SetActive(true);
		}
	}
}
