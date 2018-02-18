using UnityEngine;
using System.Collections;

public class DifficultyIncreaser : MonoBehaviour {

	public Color[] BgColor;
	public Camera cam;
	public Block block;

	public float blockSepDecrease;
	public float ballSpeedIncrease;
	public float BlockSpeedIncrease;
	public float BlockSep = 6f;
	public float increaseAmount;

	private float whenLevelIncreases;
	private float blockStartPoint = 17f;
	private float lastClonesXPos;
	private bool allreadyCloned = false;
	private int currentColor = 0;

	private Vector3 thisClonePos;
	private GameObject clone;

	// Use this for initialization
	void Start () {
		whenLevelIncreases = increaseAmount;
		PlayerPrefs.SetInt("Score", 0);
		CloneBlock();
	}
	
	// Update is called once per frame
	void Update () {
		IncreaseDiff ();

		if (clone.transform.position.x <= blockStartPoint - BlockSep && !allreadyCloned) {
			allreadyCloned = true;
			CloneBlock();
		}
	}

	void CloneBlock () {
		thisClonePos = new Vector3(blockStartPoint, Random.Range(0.5f, 11.5f), 0f);
		clone = Instantiate(block.gameObject, thisClonePos, Quaternion.identity) as GameObject;
		allreadyCloned = false;
	}

	void IncreaseDiff () {
		if (PlayerPrefs.GetInt("Score") >= whenLevelIncreases) {

			if (currentColor >= BgColor.Length) {
				currentColor = 0;
			}

			cam.backgroundColor = BgColor[currentColor];
			currentColor += 1;
			whenLevelIncreases += increaseAmount * 1.2f;

			if (Block.blockSpeed < 0.15f) {
				Block.blockSpeed += BlockSpeedIncrease;

			} else if (BlockSep >= 4f) {
				BlockSep -= blockSepDecrease;
			}
		}
	}
}