using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static bool started = false;
	public static bool ended = false;
	public static bool paused = false;

	public static bool inGame{
		get{ 
			if (started && !ended && !paused) {
				return true;
			} else {
				return false;
			}
		}
	}


	void Update(){

		if (!inGame && Input.GetButtonDown("Fire1")) {

			StartLevel ();

		}


	}


	public void StartLevel(){

		// set parameters
		started = true;
		ended = false;
		paused = false;

		// start timer
		GameObject.FindGameObjectWithTag ("Timer").GetComponent<LevelTimer> ().StartTimer ();

	}


	public static void WinGame(){

		ended = true;

	}

	public static void LoseGame(){

		ended = true;

	}

}
