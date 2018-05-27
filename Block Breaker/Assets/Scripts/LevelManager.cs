using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Brick.breakableCount = 0;
		SceneManager.LoadScene (name);
	}
	
	public void LoadNextLevel() {
		SceneManager.LoadScene (sceneBuildIndex: + 1);
	}
	
	public void BrickDestroyed() {
		if (Brick.breakableCount <= 0 || Brick.queenDestroyed) {
			print ("loading next level");
			Brick.breakableCount = 0;
			LoadNextLevel();
		}
	}
}
