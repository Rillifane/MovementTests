using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour {

	public float vSpeed = 5f;
	public int bulletDamage;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, vSpeed * Time.deltaTime, 0);
		pos += transform.rotation * velocity;
		transform.position = pos;

	}

	void OnTriggerEnter2D(Collider2D col){

		Destroy (this.gameObject);
		ShotManager.shotManager.destoryShot ();

	}
}
