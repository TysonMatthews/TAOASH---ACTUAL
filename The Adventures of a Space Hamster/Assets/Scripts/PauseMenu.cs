using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;

	public GameObject pauseMenuUI;
	public GameObject optionsMenu;
	public OptionsManager oManager;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (GameIsPaused)
			{
				Resume ();
			} else
			{
				Pause();
			}
		}
	}

	public void Pause () {
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		oManager.gameIsPaused = true;
	}
	
	public void Resume () {
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
	}

	public void Options () {
		pauseMenuUI.gameObject.SetActive (false);
		optionsMenu.gameObject.SetActive (true);

	}

	public void Menu () {
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Main Menu");
	
	}

	public void Quit () {
		Debug.Log ("Quitting game...");
		Application.Quit ();
	}
}