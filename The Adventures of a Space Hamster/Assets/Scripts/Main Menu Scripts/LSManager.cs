using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LSManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject levelSelect;

	public GameObject LvlBrief;
	public Text title;
	public Text bestTime;
	public Text mostMoney;
	public Button Continue;
	public string scene;

	public ScoreManager iScore;

	public void BackBttn() {
		levelSelect.gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (true);
	}

	public void ContinueBttn() {
		SceneManager.LoadScene (scene);
	}

	public void Level01() {
		LvlBrief.gameObject.SetActive (true);
		scene = "Level 01";
		title.text = "Level 1";
		bestTime.text = "Fastest   Run:  " + iScore.timeHighScorel01;
		mostMoney.text = "Most   Coins:  " + iScore.coinHighScorel01;
	}

	public void Level02() {
		LvlBrief.gameObject.SetActive (true);
		title.text = "Level 2";
		bestTime.text = "Fastest   Run:  " + iScore.timeHighScorel02; 
		mostMoney.text = "Most   Coins:  " + iScore.coinHighScorel02;

	}

	public void Level03() {
		LvlBrief.gameObject.SetActive (true);
		title.text = "Level 3";
		bestTime.text = "Fastest   Run:  " + iScore.timeHighScorel03; 
		mostMoney.text = "Most   Coins:  " + iScore.coinHighScorel03;

	}

	public void Level04() {
		LvlBrief.gameObject.SetActive (true);
		title.text = "Level 4";
		bestTime.text = "Fastest   Run:  " + iScore.timeHighScorel04; 
		mostMoney.text = "Most   Coins:  " + iScore.coinHighScorel04;

	}

	public void Level05() {
		LvlBrief.gameObject.SetActive (true);
		title.text = "Level 5";
		bestTime.text = "Fastest   Run:  " + iScore.timeHighScorel05; 
		mostMoney.text = "Most   Coins:  " + iScore.coinHighScorel05;

	}

	public void Level06() {
		LvlBrief.gameObject.SetActive (true);
		title.text = "Level 6";
		bestTime.text = "Fastest   Run:  " + iScore.timeHighScorel06; 
		mostMoney.text = "Most   Coins:  " + iScore.coinHighScorel06;

	}

	public void Level07() {
		LvlBrief.gameObject.SetActive (true);
		title.text = "Level 7";
		bestTime.text = "Fastest   Run:  " + iScore.timeHighScorel07; 
		mostMoney.text = "Most   Coins:  " + iScore.coinHighScorel07;

	}

	public void Level08() {
		LvlBrief.gameObject.SetActive (true);
		title.text = "Level 8";
		bestTime.text = "Fastest   Run:  " + iScore.timeHighScorel08; 
		mostMoney.text = "Most   Coins:  " + iScore.coinHighScorel08;

	}
}
