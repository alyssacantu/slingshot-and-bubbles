using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {

public AudioClip lvl1Boss;
AudioSource lvl1;
bool mPlay;
bool mToggleChange;

	void Start(){
		lvl1=GetComponent<AudioSource>();
		mPlay = true;
	}

	void Update() {
		if(mPlay == true && mToggleChange == true)
		{
			lvl1.Play();
			mToggleChange = false;
		}
	}

	void OnTriggerEnter2D(Collider2D trig) {
		if (trig.gameObject.name == "EndLevel")
		{
			lvl1.Stop();
			AudioSource.PlayClipAtPoint(lvl1Boss, transform.position);

		}
	}
}
