using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LevelTimerNetwork : NetworkBehaviour {

	public Text timerText;
	[SyncVar]
	private float timer = 0f;
	[SyncVar]
	private bool isCounting = false;

	public static LevelTimerNetwork instancia;

	public Animator animator;


	void Awake(){

		instancia = this;
	}




	// Update is called once per frame
	void Update () {

		WriteTimerOnScreen ();

		if (GameControllerNetwork.inGame) {
		
			timer += Time.deltaTime;

		
		}

	}



	void WriteTimerOnScreen ()
	{
		timerText.text = ((int)timer).ToString ();


	}

	public void StartTimer(){
		timer = 0f;
	}

}
