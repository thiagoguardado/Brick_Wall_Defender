using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {


	public float levelTimer = 60f;
	public Text timerText;
	private float timer = 0f;
	private bool isCounting = false;


	void Awake(){
		WriteTimerOnScreen();
	}


	// Update is called once per frame
	void Update () {

		if (GameController.inGame) {
		
			timer += Time.deltaTime;

			WriteTimerOnScreen ();

			if (timer >= levelTimer) {
			
				// Ends level winning
			
				GameController.WinGame ();

			}
		
		}

	}

	void WriteTimerOnScreen ()
	{
		timerText.text = (levelTimer - Mathf.Floor (timer)).ToString ();
	}

	public void StartTimer(){
		timer = 0f;
	}
}
