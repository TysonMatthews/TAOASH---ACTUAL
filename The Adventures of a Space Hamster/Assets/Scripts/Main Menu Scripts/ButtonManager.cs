using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject optionsMenu;
	public GameObject levelSelect;

	//Loads the next scene
	public void PlayBttn() {
		mainMenu.gameObject.SetActive (false);
		levelSelect.gameObject.SetActive (true);
	}

	/*Disables the Main Menu objects and simultaneously
	enables the Options Menu objects*/
	public void OptionsBttn() {
		mainMenu.gameObject.SetActive (false);
		optionsMenu.gameObject.SetActive (true);
	}

	//Quits Game
	public void ExitGameBttn() {
		Application.Quit ();
	}
}
