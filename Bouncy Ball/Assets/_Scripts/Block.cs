using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	public static float blockSpeed = 0.07f;
	public bool hasPassed = false;
	public GameObject explosion;
	public AudioClip boomSound;

	float rotationZ;
	float rotationY;
	float rotationX;

	GameObject explosionClone;
	ScoreCalculator scoreCalculator;
	LevelManager levelManager;
	Ball ball;
	
	void Start () {
		print (PlayerPrefs.GetFloat ("Take Time"));
		print (blockSpeed);
		//blockSpeed -= (blockSpeed / 100 * PlayerPrefs.GetFloat("Take Time"));
		scoreCalculator = GameObject.FindObjectOfType<ScoreCalculator>();
		ball = GameObject.FindObjectOfType<Ball>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		
		rotationZ = Random.Range(-1f, 1f);
		rotationY = Random.Range(-1f, 1f);
		rotationX = Random.Range(-1f, 1f);
	}
	
	void Update () {
		if (ball != null && hasPassed == false && ball.transform.position.x > this.transform.position.x) {
			hasPassed = true;
			
			scoreCalculator.PlayerScore += 1;
			PlayerPrefs.SetInt ("Score", scoreCalculator.PlayerScore);
		}
		
		Move();
		Rotate ();
	}

	void Move () {
		Vector3 moveBlock = new Vector3(blockSpeed, 0f, 0f);
		this.transform.position -= moveBlock;
	}
	
	void Rotate () {
		Vector3 rotateBlock = new Vector3(rotationX, rotationY, rotationZ);
		transform.Rotate (rotateBlock, Space.World);
	}
	
	void OnTriggerEnter(Collider col) {
		print ("trigger!!");
		if (col.gameObject == ball.gameObject) {
			blockSpeed = 0.06f;
			AudioSource.PlayClipAtPoint (boomSound, transform.position, 1f);

			if (explosionClone == null) {
				explosionClone = Instantiate (explosion, this.transform.position, Quaternion.identity) as GameObject;
			}

			StartCoroutine (DelaySceneChange ());
		}
	}
	
	IEnumerator DelaySceneChange() {
		Destroy(ball.gameObject);
		
		yield return new WaitForSeconds(1.5f);
		scoreCalculator.CalculateBestScore ();
		levelManager.LoadLevel("Lose");
	}
}
