using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	private Ball ball;
	private Text moneyText;

	static int money = 0;
	public float rotationY;
	public float rotationX;
	public float speed;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
		moneyText = Text.FindObjectOfType<Text> ();

		money = PlayerPrefs.GetInt("Money");
		moneyText.text = "$" + PlayerPrefs.GetInt("Money").ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 moveCoin = new Vector3 (0f, speed, 0f);
		transform.position -= moveCoin;

		Vector3 rotateCoin = new Vector3(rotationX, rotationY, 0);
		transform.Rotate (rotateCoin, Space.World);
	}

	void OnTriggerEnter(Collider col) {
		if (col.gameObject == ball.gameObject) {
			money++;
			PlayerPrefs.SetInt ("Money", money);
			moneyText.text = "$" + PlayerPrefs.GetInt("Money").ToString ();

			Vector3 fakeDestory = new Vector3 (0f, 20f, 0f);
			transform.position -= fakeDestory;
		}
	}
}
