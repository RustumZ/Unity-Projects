using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public Block block;
	public float speed;
	public Text money;
	
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetFloat("Block Speed", 0.06f);
	}
	
	// Update is called once per frame
	void Update () {
		PlayerPrefs.SetFloat ("Ball Speed", speed);

		float mouseXPos = Input.mousePosition.x / 800 * 16;
		Vector3 ballSpeed = new Vector3(0f, PlayerPrefs.GetFloat("Ball Speed", speed), 0f);
		Vector3 ballX = new Vector3(Mathf.Clamp(mouseXPos, 0.96f, 13.5f), this.transform.position.y, 0f);
		
		this.transform.position = ballX;
		this.transform.position += ballSpeed;

		if (this.transform.position.y <= 0.8 || this.transform.position.y >= 11.2) {
			speed *= -1;
		}
	}

}