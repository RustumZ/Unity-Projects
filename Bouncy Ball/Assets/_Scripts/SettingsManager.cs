using UnityEngine;
using System.Collections;

public class SettingsManager : MonoBehaviour {
	public GameObject warning;

	string reset;

	public void BestScoreReset () {
		reset = "Best Score";
		warning.SetActive(true);
	}

	public void ResetMoney () {
		reset = "Money";
		warning.SetActive(true);
	}
	
	public void CancelRequest () {
		warning.SetActive(false);
	}
	
	public void YesRequest () {
		PlayerPrefs.SetString(reset, "0");
		warning.SetActive(false);
	}
}
