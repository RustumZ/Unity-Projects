using UnityEngine;
using System.Collections;

public class OnClickedFunct : MonoBehaviour {
	public GameObject warning;

	public void BestScoreReset () {
		warning.SetActive(true);
	}
	
	public void CancelRequest () {
		warning.SetActive(false);
	}
	
	public void YesRequest () {
		PlayerPrefs.SetString("Best Score", "0");
		warning.SetActive(false);
	}
}
