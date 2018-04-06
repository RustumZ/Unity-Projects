using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

	public Dropdown dropdown;
	public GameObject warning;
	public Text playerMoney;
	public GameObject Skins;
	public GameObject Upgrades;

	private int money;

	void Start () {

		money = PlayerPrefs.GetInt ("Money");
		playerMoney.text = "$" + money.ToString ();
	}

	public bool PayMoney (int cost) {
		if (money >= cost) {
			warning.SetActive (false);
			money -= cost;
			playerMoney.text = "$" + money.ToString ();
			PlayerPrefs.SetInt ("Money", money);
			return true;

		} else {
			warning.SetActive (true);
			return false;
		}
	}

	public void ChangeSellingType () {
		if (dropdown.value == 0) {
			Skins.SetActive (false);
			Upgrades.SetActive (true);

		} else if (dropdown.value == 1) {
			Upgrades.SetActive (false);
			Skins.SetActive (true);
		}
	}

	public void MoneyUpgrade (int cost) {
		if (PayMoney(cost)) {
			PlayerPrefs.SetFloat ("Green Money", 10);

			//GameObject MoreMoneyUpgrade = Upgrade.transform.Find ("MoreMoney Upgrade");

		}
	}
}
