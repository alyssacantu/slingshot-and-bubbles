using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth2 : MonoBehaviour {

	void Update () {
		if (gameObject.transform.position.y < -7)
		{
			Die();
		}
}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.tag == "spike")
		{
			Die();
		}
	}

	void Die() {
		SceneManager.LoadScene("Level02");
	}


}
