using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{

	public float hSpeed = 5f;
	Rigidbody2D rb;
	public int forceBounce;
	public int sideForceBounce;

	// Use this for initialization
	void Start ()
	{
		
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (hSpeed * Time.deltaTime, 0, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;

	}

	void OnCollisionEnter2D (Collision2D col)
	{
//		if (col.gameObject.layer == 9) {
//			foreach (ContactPoint2D hitPos in col.contacts) {
//				if (hitPos.normal.x > 0) {
//					hSpeed = hSpeed * -1f;
//				} else if (hitPos.normal.x < 0) {
//					hSpeed = hSpeed * -1f;
//					Debug.Log ("hit wall?");
//				} else {
//					Debug.Log ("hit something");
//				}
//			} 
//		} else if (col.gameObject.layer == 8) {
//			foreach (ContactPoint2D hitPos in col.contacts) {
//				if (hitPos.normal.y > 0) {
//					rb.AddForce (new Vector2 (0, 600));
//				} else if (hitPos.normal.y < 0) {
//					rb.AddForce (new Vector2 (0, -600));
//				
//				}
//			}
//		}

		foreach (ContactPoint2D hitPos in col.contacts) {
				
			if (hitPos.normal.x > 0.99) {
				hSpeed = hSpeed * -1f;
				rb.AddForce (new Vector2 (sideForceBounce, 0));
			} else if (hitPos.normal.x < -0.99) {
				hSpeed = hSpeed * -1f;
				rb.AddForce (new Vector2 (-sideForceBounce, 0));
			}

			if (hitPos.normal.y > 0) {
				rb.AddForce (new Vector2 (0, forceBounce));
			} else if (hitPos.normal.y < 0) {
				rb.AddForce (new Vector2 (0, -forceBounce));

			}
		}
	}

//	void OnTriggerEnter2D (Collider2D col)
//	{
//		if (col.gameObject.layer == 9) {
//
//			//			Debug.Log ("Hit Wall");
//			hSpeed = hSpeed * -1f;
//		}
//	}
}
