using UnityEngine;
using System.Collections;

public class Cloner : MonoBehaviour {

	public Color[] BgColor;
	public Camera cam;
	public Block block;
	public GameObject[] coins;

	public float blockSepDecrease;
	public float ballSpeedIncrease;
	public float BlockSpeedIncrease;
	public float BlockSep = 6f;
	public float increaseAmount;
	public float coinSepMin;
	public float coinSepMax;
	public float startCoinYPos;

	private float whenLevelIncreases;
	private float blockStartPoint = 17f;
	private float lastClonesXPos;
	private float coinSep;

	private bool coinCloned = false;
	private bool allreadyCloned = false;

	private int numIncreases;
	private int currentColor = 0;
	private int coinIndex = 0;

	private Vector3 coinClonePos;
	private Vector3 thisClonePos;

	private GameObject clone;
	private GameObject coinClone;

	// Use this for initialization
	void Start () {
		coinSep = Random.Range (coinSepMin, coinSepMax);

		whenLevelIncreases = increaseAmount;
		PlayerPrefs.SetInt("Score", 0);
		CloneBlock();
		CloneCoin ();

		print (PlayerPrefs.GetFloat ("Green Money"));
	}
	
	// Update is called once per frame
	void Update () {
		IncreaseDiff ();

		if (clone.transform.position.x <= blockStartPoint - BlockSep) {
			allreadyCloned = false;
			CloneBlock ();
		}
		if (coinClone.transform.position.y <= startCoinYPos - coinSep - Coin.fakeDestroyAmount) {
			coinCloned = false;
			print ("going to clone a coin");
			CloneCoin ();
		}
	}

	void CloneBlock () {
		if (!allreadyCloned) {
			thisClonePos = new Vector3(blockStartPoint, Random.Range(0.5f, 11.5f), 0f);
			clone = Instantiate(block.gameObject, thisClonePos, Quaternion.identity) as GameObject;
			allreadyCloned = true;
		}
	}

	void CloneCoin () {
		print (PlayerPrefs.GetFloat ("Green Money"));
		// clones 1 coin
		if (!coinCloned) {
			if (Random.Range (0f, 100f) <= PlayerPrefs.GetFloat ("Green Money")) {
				print ("Cloning green coin...");
				coinIndex = 1;
			} else {
				coinIndex = 0;
				print ("Cloning yellow coin...");
			}

			print ("cloning a coin");
			coinSep = Random.Range (coinSepMin, coinSepMax);
			coinClonePos = new Vector3 (Random.Range (0.5f, 14f), startCoinYPos, 0f);
			coinClone = Instantiate (coins[coinIndex], coinClonePos, Quaternion.identity) as GameObject;
			coinSep = Random.Range (coinSepMin, coinSepMax);
			coinCloned = true;
		}
	}
		
	void IncreaseDiff () {
		if (PlayerPrefs.GetInt("Score") >= whenLevelIncreases) {

			if (currentColor >= BgColor.Length) {
				currentColor = 0;
			}

			cam.backgroundColor = BgColor[currentColor];
			currentColor++;
			whenLevelIncreases += increaseAmount * 1.2f;
			numIncreases++;
		}
	}
}