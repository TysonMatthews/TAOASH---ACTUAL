using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

	public Toggle fullscreenToggle;
	public Dropdown resolutionDropdown;
	public Dropdown textureQualityDropdown;
	public Dropdown antialiasingDropdown;
	public Dropdown vSyncDropdown;
	public Slider volumeSlider;
	public Button applyBttn;
	public AudioSource music;
	public AudioSource soundSource;
	public Resolution[] resolutions;
	public GameSettings gameSettings;
	public GameObject mainMenu;
	public GameObject optionsMenu;

	public bool gameIsPaused;

	void Start () {
		gameSettings = new GameSettings ();

		fullscreenToggle.onValueChanged.AddListener (delegate { OnFullscreenToggle ();});
		resolutionDropdown.onValueChanged.AddListener (delegate { OnResolutionChange ();});
		textureQualityDropdown.onValueChanged.AddListener (delegate { OnTextureQualityChange ();});
		antialiasingDropdown.onValueChanged.AddListener (delegate { OnAntialiasingChange ();});
		vSyncDropdown.onValueChanged.AddListener (delegate { OnVSyncChange ();});
		volumeSlider.onValueChanged.AddListener (delegate { OnVolumeChange ();});
		applyBttn.onClick.AddListener (delegate { OnApply ();});

		resolutions = Screen.resolutions;
		foreach(Resolution resolution in resolutions) {
			resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
		}

		if(File.Exists(Application.persistentDataPath + "/gamesettings.json") == true) {
			LoadSettings ();
		}
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (gameIsPaused)
			{
				BackBttn ();
				Time.timeScale = 0f;
			}
		}
	}

	public void OnFullscreenToggle () {
		gameSettings.fullscreen = Screen.fullScreen = fullscreenToggle.isOn;
	}

	public void OnResolutionChange () {
		Screen.SetResolution (resolutions [resolutionDropdown.value].width, resolutions [resolutionDropdown.value].height, Screen.fullScreen);
	}

	public void OnTextureQualityChange () {
		QualitySettings.masterTextureLimit = gameSettings.textureQuality = textureQualityDropdown.value;
	}

	public void OnAntialiasingChange () {
		QualitySettings.antiAliasing = gameSettings.antialiasing = (int)Mathf.Pow (2f, antialiasingDropdown.value);
	}

	public void OnVSyncChange () {
		QualitySettings.vSyncCount = gameSettings.vSync = vSyncDropdown.value;
	}

	public void OnVolumeChange () {
		music.volume = gameSettings.volume = volumeSlider.value;
	}

	public void OnApply () {
		SaveSettings ();
	}

	public void SaveSettings () {
		string jsonData = JsonUtility.ToJson (gameSettings, true);
		File.WriteAllText (Application.persistentDataPath + "/gamesettings.json", jsonData);
	}

	public void LoadSettings () {
		gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

		volumeSlider.value = gameSettings.volume;
		antialiasingDropdown.value = gameSettings.antialiasing;
		vSyncDropdown.value = gameSettings.vSync;
		textureQualityDropdown.value = gameSettings.textureQuality;
		resolutionDropdown.value = gameSettings.resolutionIndex;
		fullscreenToggle.isOn = gameSettings.fullscreen;
		Screen.fullScreen = gameSettings.fullscreen;

		resolutionDropdown.RefreshShownValue ();
	}

	public void BackBttn () {
		optionsMenu.gameObject.SetActive (false);
		mainMenu.gameObject.SetActive (true);
	}
}
