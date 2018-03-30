using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public static bool queenDestroyed;
	public GameObject smoke;
	
	private int maxHits;
	private int timesHit = 0;
	private LevelManager levelManager;
	private bool isBreakable;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		queenDestroyed = false;
		
		isBreakable = (this.tag == "Breakable") || (this.tag == "Queen");
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		
		if (isBreakable && ball.hasStarted == false) {
			breakableCount++;
		}
	}
	
	void OnCollisionEnter2D (Collision2D collision) {
		if (isBreakable) {
			HandleHits();
		}
	}
	
	
	void HandleHits () {
		timesHit++;
		maxHits = hitSprites.Length + 1;
		
		if (timesHit >= maxHits) {
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.4f);
			
			if (this.tag == "Queen") {
				queenDestroyed = true;
			}
			breakableCount--;
			levelManager.BrickDestroyed();
			
			GameObject smokeClone = Instantiate (smoke, transform.position, Quaternion.Euler(0, 180, 0)) as GameObject;
			smokeClone.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
			
			Destroy(gameObject);
		} else {
			LoadSprites();
		}
	}
	
	
	void LoadSprites () {
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
		else {
		Debug.LogError("Brick sprite missing");
		}
	}
	
	// TODO Remove this method once we actually win!
	
	void SimulateWin () {
		levelManager.LoadNextLevel();
	}
}
