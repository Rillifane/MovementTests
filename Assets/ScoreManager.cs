using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager scoreManager;
	public int scoreValue;
	public Text scoreTextGO;
	public string scoreText = "Score :";

	// Use this for initialization
	void Start () {

		if (scoreManager == null) {
			scoreManager = this;
		} else if (scoreManager != this) {
			Destroy (gameObject);
		}

		scoreValue = 0;
		scoreTextGO.GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {

//		scoreTextGO.text = "This is some score.";

	}


}
