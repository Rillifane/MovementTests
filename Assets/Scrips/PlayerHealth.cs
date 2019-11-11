using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int health = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(health <= 0){
			playerDeath ();
		}

	}

	void playerDeath(){

		//Destroy (this.gameObject);
		//Debug.Log("Player Dead");
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.layer == 10) {
			health--;
			//Debug.Log ("Player Hit");
		}
	}
}
