using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	//Top Coins
	public int coinHighScorel01;
	public int coinHighScorel02;
	public int coinHighScorel03;
	public int coinHighScorel04;
	public int coinHighScorel05;
	public int coinHighScorel06;
	public int coinHighScorel07;
	public int coinHighScorel08;

	//Coins
	public int coinScorel01;
	public int coinScorel02;
	public int coinScorel03;
	public int coinScorel04;
	public int coinScorel05;
	public int coinScorel06;
	public int coinScorel07;
	public int coinScorel08;

	//Top Times
	public float timeHighScorel01;
	public float timeHighScorel02;
	public float timeHighScorel03;
	public float timeHighScorel04;
	public float timeHighScorel05;
	public float timeHighScorel06;
	public float timeHighScorel07;
	public float timeHighScorel08;

	//Times
	public float timeScorel01;
	public float timeScorel02;
	public float timeScorel03;
	public float timeScorel04;
	public float timeScorel05;
	public float timeScorel06;
	public float timeScorel07;
	public float timeScorel08;


	void Start () {
		coinScorel01 = 0;
		coinScorel02 = 0;
		coinScorel03 = 0;
		coinScorel04 = 0;
		coinScorel05 = 0;
		coinScorel06 = 0;
		coinScorel07 = 0;
		coinScorel08 = 0;

		timeScorel01 = 0;
		timeScorel02 = 0;
		timeScorel03 = 0;
		timeScorel04 = 0;
		timeScorel05 = 0;
		timeScorel06 = 0;
		timeScorel07 = 0;
		timeScorel08 = 0;

		timeHighScorel01 = PlayerPrefs.GetFloat ("timeHighScorel01", timeHighScorel01);
		timeHighScorel02 = PlayerPrefs.GetFloat ("timeHighScorel02", timeHighScorel02);
		timeHighScorel03 = PlayerPrefs.GetFloat ("timeHighScorel03", timeHighScorel03);
		timeHighScorel04 = PlayerPrefs.GetFloat ("timeHighScorel04", timeHighScorel04);
		timeHighScorel05 = PlayerPrefs.GetFloat ("timeHighScorel05", timeHighScorel05);
		timeHighScorel06 = PlayerPrefs.GetFloat ("timeHighScorel06", timeHighScorel06);
		timeHighScorel07 = PlayerPrefs.GetFloat ("timeHighScorel07", timeHighScorel07);
		timeHighScorel08 = PlayerPrefs.GetFloat ("timeHighScorel08", timeHighScorel08);

		coinHighScorel01 = PlayerPrefs.GetInt ("coinHighScorel01", coinHighScorel01);
		coinHighScorel02 = PlayerPrefs.GetInt ("coinHighScorel02", coinHighScorel02);
		coinHighScorel03 = PlayerPrefs.GetInt ("coinHighScorel03", coinHighScorel03);
		coinHighScorel04 = PlayerPrefs.GetInt ("coinHighScorel04", coinHighScorel04);
		coinHighScorel05 = PlayerPrefs.GetInt ("coinHighScorel05", coinHighScorel05);
		coinHighScorel06 = PlayerPrefs.GetInt ("coinHighScorel06", coinHighScorel06);
		coinHighScorel07 = PlayerPrefs.GetInt ("coinHighScorel07", coinHighScorel07);
		coinHighScorel08 = PlayerPrefs.GetInt ("coinHighScorel08", coinHighScorel08);

	}
	
	void Update () {
		//Updates the Fastest Time if the player achieves a faster time
		if(timeScorel01 > timeHighScorel01){
			timeHighScorel01 = timeScorel01;
			PlayerPrefs.SetFloat ("timeHighScorel01", timeHighScorel01);
		}

		if(timeScorel02 > timeHighScorel02){
			timeHighScorel02 = timeScorel02;
			PlayerPrefs.SetFloat ("timeHighScorel02", timeHighScorel02);
		}

		if(timeScorel03 > timeHighScorel03){
			timeHighScorel03 = timeScorel03;
			PlayerPrefs.SetFloat ("timeHighScorel03", timeHighScorel03);
		}

		if(timeScorel04 > timeHighScorel04){
			timeHighScorel04 = timeScorel04;
			PlayerPrefs.SetFloat ("timeHighScorel04", timeHighScorel04);
		}

		if(timeScorel05 > timeHighScorel05){
			timeHighScorel05 = timeScorel05;
			PlayerPrefs.SetFloat ("timeHighScorel05", timeHighScorel05);
		}

		if(timeScorel06 > timeHighScorel06){
			timeHighScorel06 = timeScorel06;
			PlayerPrefs.SetFloat ("timeHighScorel06", timeHighScorel06);
		}

		if(timeScorel07 > timeHighScorel07){
			timeHighScorel07 = timeScorel07;
			PlayerPrefs.SetFloat ("timeHighScorel07", timeHighScorel07);
		}

		if(timeScorel08 > timeHighScorel08){
			timeHighScorel08 = timeScorel08;
			PlayerPrefs.SetFloat ("timeHighScorel08", timeHighScorel08);
		}

		//Updates the highest coin score if the player aquires more coins
		if(coinScorel01 > coinHighScorel01){
			coinHighScorel01 = coinScorel01;
			PlayerPrefs.SetInt ("coinHighScorel01", coinHighScorel01);
		}
		if(coinScorel02 > coinHighScorel02){
			coinHighScorel02 = coinScorel02;
			PlayerPrefs.SetInt ("coinHighScorel02", coinHighScorel02);
		}
		if(coinScorel03 > coinHighScorel03){
			coinHighScorel03 = coinScorel03;
			PlayerPrefs.SetInt ("coinHighScorel03", coinHighScorel03);
		}
		if(coinScorel04 > coinHighScorel04){
			coinHighScorel04 = coinScorel04;
			PlayerPrefs.SetInt ("coinHighScorel04", coinHighScorel04);
		}
		if(coinScorel05 > coinHighScorel05){
			coinHighScorel05 = coinScorel05;
			PlayerPrefs.SetInt ("coinHighScorel05", coinHighScorel05);
		}
		if(coinScorel06 > coinHighScorel06){
			coinHighScorel06 = coinScorel06;
			PlayerPrefs.SetInt ("coinHighScorel06", coinHighScorel06);
		}
		if(coinScorel07 > coinHighScorel07){
			coinHighScorel07 = coinScorel07;
			PlayerPrefs.SetInt ("coinHighScorel07", coinHighScorel07);
		}
		if(coinScorel08 > coinHighScorel08){
			coinHighScorel08 = coinScorel08;
			PlayerPrefs.SetInt ("coinHighScorel08", coinHighScorel08);
		}
	}
}
