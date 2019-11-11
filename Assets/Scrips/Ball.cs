using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public int ballHealth = 1;
	public GameObject nextBall;
	public Color ballColor;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (ballHealth <= 0){

			ballDeath ();
			spawnNext ();

		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Space Pressed");
			takeDamage (1);
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.layer == 11) {
			Debug.Log ("Ball Hit Player Trigger");
			takeDamage (1);
		}
		if(col.gameObject.layer == 12){
			takeDamage(col.gameObject.GetComponent<ShootBullet>().bulletDamage);
		}
	}

	void takeDamage(int damage){

		ballHealth = ballHealth - damage;
	}

	void ballDeath(){
		Destroy (this.gameObject);
	}

	void spawnNext(){

		if (nextBall == null) {
			//Debug.Log ("Last ball size");
			return;
		}
		else if (nextBall != null) {

			Vector3 pos = this.transform.position;
			for (int i = 0; i < 2; i++) {
				GameObject nb = Instantiate (nextBall);
				nb.transform.position = pos;
				if (i == 1) {

					nb.GetComponent<BallBounce> ().hSpeed = -5;
					nb.GetComponent<Renderer> ().material.color = ballColor;
					//Debug.Log ("Speed set negative for ball 2");
				}
			}

			//Debug.Log ("Ball spawned");

		}
	}
}
