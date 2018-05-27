using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	public Text CurrentLevel;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetString ("Level") == null) {
			PlayerPrefs.SetString ("Level", "Easy");
		}
		CurrentLevel.text = "Current Level: " + PlayerPrefs.GetString("Level");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeLevel (string name) {
		PlayerPrefs.SetString ("Level", name);
		CurrentLevel.text = "Current Level: " + PlayerPrefs.GetString("Level");
	}
}
