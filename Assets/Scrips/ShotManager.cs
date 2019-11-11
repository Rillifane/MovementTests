using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotManager : MonoBehaviour
{

	public static ShotManager shotManager;
	public GameObject[] Shots;

	public int maxShots;
	public int numberOfShots = 0;
	//int typeOfShot; 0 - first type, 1- second type, 3-third type (maybe use enum instead).

	public GameObject bulletSpawner;
	GameObject bulletObject;

	public float fireDelay = 0.25f;
	float cooldownTimer = 0;

	// Use this for initialization
	void Start ()
	{

		if (shotManager == null) {
			shotManager = this;
		} else if (shotManager != this) {
			Destroy (gameObject);
		}

		maxShots = 1;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		cooldownTimer -= Time.deltaTime;
		
		if (canShoot () && Input.GetButton ("Fire1") && cooldownTimer <= 0) {

			Debug.Log ("fired");
			shoot ();
			cooldownTimer = fireDelay;
		}
	}

	bool canShoot ()
	{

		if (numberOfShots < maxShots) {

			return true;
		} else {
			return false;
		}
	}

	void shoot(){

		Vector3 pos = bulletSpawner.transform.position;
		bulletObject = Instantiate (Shots[0]);
		bulletObject.transform.position = pos;
		numberOfShots++;
	}

	public void destoryShot(){

		numberOfShots--;

	}
}
