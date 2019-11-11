using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHealth : MonoBehaviour {

	public int health = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.layer == 11) {
			Debug.Log ("Ball Hit Player Trigger");
			health--;
		}
	}
}
