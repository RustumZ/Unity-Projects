using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MusicVolume : MonoBehaviour {
	
	public AudioSource audioSource;
	public Slider slider;
	
	// Use this for initialization
	void Start () {
		slider.value = PlayerPrefs.GetFloat ("Slider");
		
	}

	public void ChangeVolume () {
		if (audioSource) {
			audioSource.volume = slider.value;
			PlayerPrefs.SetFloat ("Slider", slider.value);
		} else {
			audioSource = GameObject.FindObjectOfType<MusicPlayer>().GetComponent<AudioSource>();
		}

	}
}
