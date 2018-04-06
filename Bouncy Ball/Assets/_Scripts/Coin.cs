using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {

	private Ball ball;
	private Text moneyText;

	public float rotationY;
	public float rotationX;
	public float speed;

	public int coinValue;

	static int money = 0;
	static public float fakeDestroyAmount;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
		if (ball) {
			moneyText = ball.money;
			money = PlayerPrefs.GetInt("Money");
			moneyText.text = PlayerPrefs.GetInt("Money").ToString ();
			fakeDestroyAmount = 0f;
		}
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
			money += coinValue;
			PlayerPrefs.SetInt ("Money", money);
			moneyText.text = PlayerPrefs.GetInt("Money").ToString ();

			fakeDestroyAmount = 20f;
			Vector3 fakeDestory = new Vector3 (0f, fakeDestroyAmount, 0f);
			transform.position -= fakeDestory;
		}
	}
}
