using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public float speed;
	public Text money;

	
	// Update is called once per frame
	void Update () {
		Vector3 ballSpeed = new Vector3(0f, speed, 0f);
		this.transform.position += ballSpeed;

		if (this.transform.position.y <= 0.8 || this.transform.position.y >= 11.2) {
			speed *= -1;
		}

			float mouseXPos = Input.mousePosition.x / 800 * 16;
			Vector3 ballX = new Vector3 (Mathf.Clamp (mouseXPos, 0.96f, 13.5f), this.transform.position.y, 0f);
			this.transform.position = ballX;
	}

}