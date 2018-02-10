using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour {

	// Access to the text object so I can change it.
	Text scoreText;
	public int PlayerScore;
	int bestScoreAsInt;
	
	void Start () {
		
		scoreText = GetComponent<UnityEngine.UI.Text>();
		PlayerScore = 0;
	}
	
	void Update () {
		bestScoreAsInt = int.Parse(PlayerPrefs.GetString("Best Score"));
		
		// display the score
		scoreText.text = "Score: " + PlayerScore.ToString();
	}
	
	public void CalculateBestScore () {
		if (PlayerScore > bestScoreAsInt) {
			PlayerPrefs.SetString("Best Score", (PlayerScore).ToString());
		}
		
	}
}
