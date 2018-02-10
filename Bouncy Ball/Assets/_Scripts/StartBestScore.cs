using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartBestScore : MonoBehaviour {
	
	void Start () {
		GetComponent<Text>().text = "Your best score is: " + PlayerPrefs.GetString("Best Score");
	}
}
