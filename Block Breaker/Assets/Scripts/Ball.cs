﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {
	
	Text text;
	Paddle paddle;
	private Vector3 paddleToBallVector;
	public bool hasStarted = false;

	// Use this for initialization
	void Start () {
		text = Text.FindObjectOfType<Text>();
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		// if the game has not started
		if (!hasStarted) {
			// Lock the ball relative to the paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// if the mouse is clicked
			if (Input.GetMouseButtonDown(0)) {
				print("Mouse Clicked, launching ball");
				
				// the game starts
				hasStarted = true;
				Destroy(text.gameObject);
				// launches the ball
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
		
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		Vector2 tweak = new Vector2 (Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
		
		if (hasStarted) {
			GetComponent<AudioSource>().Play();
			GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
