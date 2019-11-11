using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

	float vSpeed = 5f;
	public float hSpeed = 5f;
	Rigidbody2D rb;

	Vector3 offset;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		Vector3 pos = transform.position;

//		Vector3 velocity = new Vector3 (hSpeed * Time.deltaTime , vSpeed * Time.deltaTime, 0);
		Vector3 velocity = new Vector3 (hSpeed * Time.deltaTime, 0, 0);
		pos += transform.rotation * velocity;

		transform.position = pos;

	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.gameObject.layer == 8) {

//			Debug.Log ("Hit Ground/Ceilling");
			vSpeed = vSpeed * -1f;
		}
		if (col.gameObject.layer == 9) {

//			Debug.Log ("Hit Wall");
//			hSpeed = hSpeed * -1f;
		}
		if (col.gameObject.layer != 8 || (col.gameObject.layer != 9)) {
			foreach (ContactPoint2D hitPos in col.contacts) {

//				if(hitPos.point.x - transform.position.x < 0){
//					Debug.Log ("hit left");
////					Debug.Log (hitPos.point);
//					hSpeed = hSpeed * -1f;
//				}
//				if (hitPos.point.y - transform.position.y < 0) {
//					Debug.Log ("Hit bottom");
//				}
//				if (hitPos.point.y - transform.position.y > 0) {
//					Debug.Log ("Hit top");
//				}
//				if(hitPos.point.x - transform.position.x > 0){
//					Debug.Log ("hit right");
////					Debug.Log (hitPos.point);
//					hSpeed = hSpeed * -1f;
//				}

//				if (hitPos.normal.x < 0) {
//					hSpeed = hSpeed * -1f;
//					Debug.Log ("Hit right side " + hitPos.normal);
//				} else if (hitPos.normal.x > 0) {
//					hSpeed = hSpeed * -1f;
//					Debug.Log ("Hit left side " + hitPos.normal);
//				} else {
//
//					Debug.Log ("hit something");
//				}

//				if (hitPos.normal.x < 0 && hitPos.normal.y < 0) {
////					hSpeed = hSpeed * -1f;
//					Debug.Log ("Hit right side & up?" + hitPos.normal);
//				}
//				if (hitPos.normal.x < 0 && hitPos.normal.y > 0) {
//					//					hSpeed = hSpeed * -1f;
//					Debug.Log ("Hit right side & down? " + hitPos.normal);
//				}
				if (hitPos.normal.x > 0) {
					hSpeed = hSpeed * -1f;
//					Debug.Log ("Hit left side " + hitPos.normal);
				} 
				else if (hitPos.normal.y > 0){
					rb.AddForce (new Vector2(0,550));
					Debug.Log ("Hit bottom side " + hitPos.normal);
				}
				else if (hitPos.normal.y < 0){
					rb.AddForce (new Vector2(0,-250));
					Debug.Log ("Hit top side " + hitPos.normal);
				}
				else if (hitPos.normal.x < 0) {
					hSpeed = hSpeed * -1f;
//					Debug.Log ("Hit right " + hitPos.normal);
				}
				else {
					
//					Debug.Log ("hit something");
				}
			}
		}


	}

	void OnTriggerEnter2D (Collider2D col)
	{

		if (col.gameObject.layer == 8) {

//			Debug.Log ("Hit Ground/Ceilling");
			vSpeed = vSpeed * -1f;
		}
		if (col.gameObject.layer == 9) {
			
//			Debug.Log ("Hit Wall");
			hSpeed = hSpeed * -1f;
		}
	}
}
