using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	//Script Reference Variables
	public PlayerController iPlayer;
	public ScoreManager iScore;
	public Timer iTime;
	public CameraController iCam;
	public Animator playerAnim;
	public Animator creditsTXTAnim;
	public Animator creditsIMGAnim;
	public Image creditsIMG;
	public Image creditsIMG02;
	public GameObject creditsIMGi;
	public GameObject creditsTXT;
	public GameObject barrier04;
	public GameObject barrier05;
	public GameObject endBarrier;

	//Health/Lifes Variables
	public bool beingDamaged;
	public Text healthAmount;
	public Text gameOver;
	public Slider healthBarSlider;
	public int maxHealth;
	public int currentHealth;
	public int lives = 3;
	public Image life1;
	public Image life2;
	public Image life3;
	public Sprite Life;
	public Sprite noLife;

	//Oxygen Variables
	public float maxOxygen;
	public float currentOxygen;
	public Slider oxygenBarSlider;
	public float oxygenDrain;
	public float emptyOxyReset;
	public int emptyOxyDamage;
	public GameObject oxygenBarFill;

	//Coin Variables
	public int coinCount;
	public Text coinText;

	//Being Damaged Variables
	public Color red = new Color (233f, 152f, 152f, 255f);
	public Color white = new Color (255f, 255f, 255f, 255f);
	public Color black = new Color (0f, 0f, 255f);
	public float beingDamagedTimer;
	public bool colorChange;
	public bool coroutineCalled;
	public GameObject deathParticle;

	//Respawning Variables
	public float waitToRespawn;
	public float waitToReset;
	private bool respawning;

	void Start () {
		iPlayer = FindObjectOfType<PlayerController> ();
		iScore = FindObjectOfType<ScoreManager> ();
		iTime = FindObjectOfType<Timer> ();
		iCam = FindObjectOfType<CameraController> ();

		gameOver.gameObject.SetActive (false);
		creditsIMGi.gameObject.SetActive (false);
		creditsTXT.gameObject.SetActive (false);
		barrier04.gameObject.SetActive (false);
		barrier05.gameObject.SetActive (false);

		currentHealth = maxHealth;
		SetHealthAmount ();
		currentOxygen = maxOxygen;

	}
	
	void Update () {
		if(currentHealth <= 0 && !respawning) {
			Respawn ();
			respawning = true;
			lives -= 1;
			UpdateLives ();
			StopCoroutine ("OxygenTakeDamage");
		}

		if (lives <= 0) {
			StartCoroutine ("GameOver");
			StopCoroutine ("RespawnCo");
		}

		if (!respawning) {
			currentOxygen -= (oxygenDrain * Time.deltaTime);
		}

		if (currentOxygen <= 0) {
			StartCoroutine ("OxygenDamageTake");
		}

		if (oxygenBarSlider.value <= 0) {
			oxygenBarFill.gameObject.SetActive (false);

		} else {oxygenBarFill.gameObject.SetActive (true);}

		if (beingDamaged) {
				StartCoroutine ("BeingDamaged");
		}

		if (currentOxygen > maxOxygen) {
			currentOxygen = maxOxygen;
		}

		if (currentHealth < 0f) {
			currentHealth = 0;
		}

		if (currentHealth > maxHealth) {
			currentHealth = maxHealth;
		}
		SetHealthAmount ();
		SetCoinAmount();
		SetOxygenAmount ();
	}

	public void Respawn () {
		StartCoroutine ("RespawnCo");
	}

	public IEnumerator RespawnCo () {
		Instantiate (deathParticle, iPlayer.transform.position, iPlayer.transform.rotation);
		iPlayer.gameObject.SetActive (false);

		yield return new WaitForSeconds (waitToRespawn);

		currentHealth = maxHealth;
		healthBarSlider.value = 100;
		oxygenBarFill.gameObject.SetActive (true);
		currentOxygen = maxOxygen;
		oxygenBarSlider.value = 100;
		SetHealthAmount ();
		respawning = false;

		iPlayer.transform.position = iPlayer.respawnPosition;
		iPlayer.gameObject.SetActive (true);
	}

	public IEnumerator GameOver () {
		gameOver.gameObject.SetActive (true);
		coinCount = 0;

		yield return new WaitForSeconds (waitToReset);

		SceneManager.LoadScene ("Main Menu");
	}

	public IEnumerator OxygenDamageTake () {
		HurtPlayer (emptyOxyDamage);
		currentOxygen = emptyOxyReset;
		yield return null;
	}

	public IEnumerator BeingDamaged (){
		iPlayer.GetComponent<SpriteRenderer>().color = red;
		yield return new WaitForSeconds (.2f);
		iPlayer.GetComponent<SpriteRenderer> ().color = white;
		beingDamaged = false;
		yield return new WaitForSeconds (.2f);
	}
		
	public void FinLevel (){
		StartCoroutine ("FinishLevel");
		Debug.Log ("Function");
	}

	public IEnumerator FinishLevel () {
		Debug.Log ("Coroutine");
		iPlayer.enabled = false;
		iCam.target = endBarrier;
		iCam.followAhead = 0f;
		creditsIMGi.gameObject.SetActive (true);
		creditsTXT.gameObject.SetActive (true);
		barrier04.gameObject.SetActive (true);
		barrier05.gameObject.SetActive (true);
		
		yield return new WaitForSeconds (2f);

		playerAnim.SetBool ("LevelFinished", false);
		creditsIMGAnim.SetBool ("Fade Image", true);

		yield return new WaitForSeconds (2f);
		creditsIMG02.gameObject.SetActive (true);

		creditsIMGAnim.SetBool ("Fade Image", false);
		creditsTXTAnim.SetBool ("Roll Text", true);

		yield return new WaitForSeconds (30f);

		SceneManager.LoadScene ("Main Menu");
	}

	public void HurtPlayer (int damageToTake) {
		currentHealth -= damageToTake;
		healthBarSlider.value -= damageToTake;
		SetHealthAmount ();
		beingDamaged = true;
	}

	void SetHealthAmount () {
		healthAmount.text = "H e a  lth: " + currentHealth;
		healthBarSlider.value = currentHealth;
	}

	void SetCoinAmount () {
		coinText.text = "" + coinCount;
		iScore.coinScorel01 = coinCount;
	}

	void SetOxygenAmount () {
		oxygenBarSlider.value = currentOxygen;
	}

	public void AddCoins (int coinsToAdd) {
		coinCount += coinsToAdd;
	}
		
	void UpdateLives () {
		switch (lives) {
		case 3:
			life1.sprite = Life;
			life2.sprite = Life;
			life3.sprite = Life;
			return;
		case 2:
			life1.sprite = Life;
			life2.sprite = Life;
			life3.sprite = noLife;
			return;
		case 1:
			life1.sprite = Life;
			life2.sprite = noLife;
			life3.sprite = noLife;
			return;
		case 0:
			life1.sprite = noLife;
			life2.sprite = noLife;
			life3.sprite = noLife;
			return;

		default:
			life1.sprite = noLife;
			life2.sprite = noLife;
			life3.sprite = noLife;
			return;
		}
	}
}
