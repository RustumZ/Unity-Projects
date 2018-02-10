using UnityEngine;
using System.Collections;

public class BlockCloner : MonoBehaviour {
	
	public float BlockSep = 4f;
	public Block block;

	float blockStartPoint = 17f;
	float lastClonesXPos;
	bool allreadyCloned = false;

	Vector3 thisClonePos;

	GameObject clone;

	// Use this for initialization
	void Start () {
		CloneBlock();
	}
	
	// Update is called once per frame
	void Update () {

		if (clone.transform.position.x <= blockStartPoint - BlockSep && !allreadyCloned) {
			allreadyCloned = true;
			CloneBlock();
		}

	}
	
	// clone BlockNum blocks. with a random y pos and each one BlockSep units away from eachother.
	void CloneBlock() {
		thisClonePos = new Vector3(blockStartPoint, Random.Range(0.5f, 11.5f), 0f);
		clone = Instantiate(block.gameObject, thisClonePos, Quaternion.identity) as GameObject;
		allreadyCloned = false;
	}
}

