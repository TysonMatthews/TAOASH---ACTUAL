using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject OptionsMenu;

	public void PlayBttn() {
		SceneManager.LoadScene ("Scene 01");
	}

	public void OptionsBttn() {
		MainMenu.gameObject.SetActive (false);
		OptionsMenu.gameObject.SetActive (true);
	}

	public void ExitGameBttn() {
		Application.Quit ();
	}
}
