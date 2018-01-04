using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public GameObject MainMenu;
	public GameObject OptionsMenu;

	public AudioMixer audioMixer;

	public Dropdown resolutionDropdown;

	Resolution[] resolutions;

	void Start () {
		resolutions = Screen.resolutions;

		//clears options in resolution dropdown
		resolutionDropdown.ClearOptions();

		//creates list of strings
		List<string> options = new List<string> ();

		int currentResolutionIndex = 0;

		//converts array options to a string
		for (int i = 0; i < resolutions.Length; i++) {
			string option = resolutions [i].width + " x " + resolutions [i].height;	
			options.Add(option);

				if (resolutions[i].width == Screen.currentResolution.width &&
					resolutions[i].height == Screen.currentResolution.height) {
					currentResolutionIndex = i;
				}
		}

		//adds options list to resolution dropdown
		resolutionDropdown.AddOptions (options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue ();
	}

	public void SetResolution (int resolutionIndex) {
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
	}

	public void SetVolume (float volume) {
		audioMixer.SetFloat ("Volume", volume);
	}

	public void BackBttn() {
		MainMenu.gameObject.SetActive (true);
		OptionsMenu.gameObject.SetActive (false);
	}

	public void SetFullscreen (bool isFullscreen) {
		Screen.fullScreen = isFullscreen;
	}
}
