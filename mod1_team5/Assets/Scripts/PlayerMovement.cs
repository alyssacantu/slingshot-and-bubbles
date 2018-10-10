using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int playerSpeed = 5;
    public bool facingRight = true;
    public int playerJumpPower = 1250;
	private float moveX;
	public bool isGrounded;
	Animator anim;
	
	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update () {
        PlayerMove();
		playerRaycast ();
	}

    void PlayerMove() {
        // Controls
		moveX = Input.GetAxis("Horizontal");

		if(Input.GetButtonDown("Jump") && isGrounded == true)
		{
			Jump();
		}

		// Animations
		// Right
		if (Input.GetKey(KeyCode.D))
		{
			anim.SetInteger("State", 1);
		}

		if (Input.GetKeyUp(KeyCode.D))
		{
			anim.SetInteger("State", 0);
		}

		// Left
		if (Input.GetKey(KeyCode.A))
		{
			anim.SetInteger("State", 1);
		}

		// Jump
		if (Input.GetKeyUp(KeyCode.A))
		{
			anim.SetInteger("State", 0);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Jump", true);
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			anim.SetBool("Jump", false);
		}

		// Attack
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			anim.SetBool("Attack", true);
		}

		if (Input.GetKeyUp(KeyCode.Mouse0))
		{
			anim.SetBool("Attack", false);
		}

		// Player Direction
		if (moveX < 0.0f && facingRight == false)
		{
			FlipPlayer();
		}

		else if(moveX > 0.0f && facingRight == true)
		{
			FlipPlayer();
		}

		// Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump() {
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
    }

	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D (Collision2D col) {
		// Debug.Log("Player has collided with " + col.collider.name);
		if (col.gameObject.tag == "ground") {
			isGrounded = true;
		}
	}

	void playerRaycast()
	{
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
		if (hit.distance < 1.0f && hit.collider.tag == "enemy") {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 1000);
			hit.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.right * 200);
			hit.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 15;
			hit.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			hit.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			hit.collider.gameObject.GetComponent<EnemyMove> ().enabled = false;
			// Destroy (hit.collider.gameObject);

		}
	}
}
