﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ScoreCalculator : MonoBehaviour {

	// Access to the text object so I can change it.
	Text scoreText;
	public int PlayerScore;
	
	void Start () {
		scoreText = GetComponent<UnityEngine.UI.Text>();
		PlayerScore = 0;
	}
	
	void Update () {
		// display the score
		scoreText.text = "Score: " + PlayerScore.ToString ();
	}
	
	public void CalculateBestScore () {
		if (PlayerScore >= int.Parse(PlayerPrefs.GetString("Best Score"))) {
			PlayerPrefs.SetString("Best Score", (PlayerScore).ToString());
		}
		
	}
}
