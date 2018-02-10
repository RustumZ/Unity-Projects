using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour {
	
	AudioSource audioSource;
	public Slider slider;
	
	// Use this for initialization
	void Start () {
		if (GameObject.FindObjectOfType<MusicPlayer>() != null) {
			audioSource = GameObject.FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>();
		} else {
			print("No music player found");
		}
		
	}
	
	public void ChangeVolume () {
		
		if (GameObject.FindObjectOfType<MusicPlayer>() != null) {
			audioSource.volume = this.slider.value;
		}
	}
}
