using UnityEngine;
using System.Collections;

public class DifficultyIncreaser : MonoBehaviour {

	public float blockSepDecrease;
	public float ballSpeedIncrease;
	public float BlockSpeedIncrease;

	public float increaseAmount;
	public Color[] BgColor;
	public Camera cam;

	float whenLevelIncreases;
	BlockCloner blockCloner;
	int currentColor = 0;

	// Use this for initialization
	void Start () {
		blockCloner = FindObjectOfType<BlockCloner>();
		whenLevelIncreases = increaseAmount;
		PlayerPrefs.SetInt("Score", 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.GetInt("Score") >= whenLevelIncreases) {
		
			if (currentColor >= BgColor.Length) {
				currentColor = 0;
			}
			
			cam.backgroundColor = BgColor[currentColor];
			currentColor += 1;
			whenLevelIncreases += increaseAmount * 1.2f;
			
			if (Block.blockSpeed < 0.15f) {
				Block.blockSpeed += BlockSpeedIncrease;
				
			} else if (blockCloner.BlockSep >= 4f) {
				blockCloner.BlockSep -= blockSepDecrease;
			}
		}
	}
}