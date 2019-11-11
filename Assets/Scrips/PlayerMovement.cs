using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public float moveSpeed = 5f;
	float movementX;

	Animator animator;
	SpriteRenderer spriteRenderer;
//	Rigidbody2D rb2D;


	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();
//		rb2D = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{

		Input.GetAxis ("Horizontal");

		Vector3 pos = transform.position;
		movementX = Input.GetAxisRaw ("Horizontal") * moveSpeed;
		pos.x += movementX * Time.deltaTime;

		if (pos.x > 8.1f){
			pos.x = 8.1f;
		}
		if (pos.x < -8.05f){
			pos.x = -8.05f;
		}
		transform.position = pos;

//		movementX = Input.GetAxisRaw ("Horizontal") * moveSpeed;
//		Vector3 movement = new Vector3(movementX * Time.deltaTime, 0, 0);
//		rb2D.MovePosition (transform.position + movement);

	}

	void FixedUpdate(){

		animator.SetInteger ("movementX", Mathf.RoundToInt(movementX));
		if (movementX < 0) {
			spriteRenderer.flipX = true;
		} else {
			spriteRenderer.flipX = false;
		}
	}

}
