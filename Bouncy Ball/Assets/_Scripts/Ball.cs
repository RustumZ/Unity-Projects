using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public Block block;
	public float speed;
	
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat("Block Speed", 0.06f);
	}
	
	// Update is called once per frame
	void Update () {
		float mouseXPos = Input.mousePosition.x / 800 * 16;
		Vector3 ballSpeed = new Vector3(0f, speed, 0f);
		Vector3 ballX = new Vector3(Mathf.Clamp(mouseXPos, 0.5f, 14f), this.transform.position.y, 0f);
		
		this.transform.position = ballX;
		this.transform.position += ballSpeed;

		if (this.transform.position.y <= 0.5 || this.transform.position.y >= 11.5) {
			speed *= -1;
		}
	}

}