using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScore : MonoBehaviour {
	
	public Text endScore;
	public Text bestScore;
	
	void Update () {
		
		endScore.text = "Your score was: " + (PlayerPrefs.GetInt("Score")).ToString();
		bestScore.text = "Your best score is: " + PlayerPrefs.GetString("Best Score");
	}
}
