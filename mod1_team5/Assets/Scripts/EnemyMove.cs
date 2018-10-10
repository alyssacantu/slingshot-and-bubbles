using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour {

	public int EnemySpeed;
	public int xMoveDirection;
	public bool facingRight = true;

	void Update () {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDirection, 0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (xMoveDirection, 0) * EnemySpeed;

		if(hit.distance < 1.0f) {
			Flip();

			if (hit.collider.tag == "Player")
			{
				SceneManager.LoadScene("Level01");
			}
		}

	}

	void FlipEnemy() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void Flip() {
		if (xMoveDirection > 0)
		{
			xMoveDirection = -1;
			FlipEnemy();
		}
		else {
			xMoveDirection = 1;
			FlipEnemy();
		}
	}
}
