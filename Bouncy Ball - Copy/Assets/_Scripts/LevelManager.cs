﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
	void Start () {
		
	}
	
	public void LoadLevel(string name) {
		SceneManager.LoadScene (name);

	}
}