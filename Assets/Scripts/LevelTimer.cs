using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour {

	[HideInInspector]
	public float levelTimer = 45f;
	public Text timerText;
	private float timer = 0f;
	private bool isCounting = false;

	public static LevelTimer instancia;

	public Animator animator;

	private float timerblink;
	private bool gotbig = false;

	void Awake(){

		instancia = this;
	}




	// Update is called once per frame
	void Update () {

		WriteTimerOnScreen ();

		if (GameController.inGame) {
		
			timer += Time.deltaTime;

			Blink ();

			WriteTimerOnScreen ();

			if (timer >= levelTimer) {
			
				// Ends level winning
				GameController.instancia.WinGame ();

			}
		
		}

	}

	void Blink ()
	{
		if (levelTimer - timer <= 5) {
			if (!gotbig) {
				animator.SetBool ("ScaleUp", true);
				gotbig = true;
				timerblink = -Time.deltaTime;
			}
			timerblink += Time.deltaTime;
			if (timerblink >= 1f) {
				animator.SetTrigger ("Blink");
				timerblink = 0f;
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
