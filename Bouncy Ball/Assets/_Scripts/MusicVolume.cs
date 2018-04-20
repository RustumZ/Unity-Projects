using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour {
	
	AudioSource audioSource;
	public Slider slider;
	
	// Use this for initialization
	void Start () {
		this.slider.value = PlayerPrefs.GetFloat ("Slider");
		if (GameObject.FindObjectOfType<MusicPlayer>() != null) {
			audioSource = GameObject.FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>();
		} else {
			print("No music player found");
		}
		
	}
	
	public void ChangeVolume () {
		PlayerPrefs.SetFloat ("Slider", this.slider.value);

		if (GameObject.FindObjectOfType<MusicPlayer>() != null) {
			print (PlayerPrefs.GetFloat ("Slider"));
			audioSource.volume = PlayerPrefs.GetFloat ("Slider");
		}
	}
}
