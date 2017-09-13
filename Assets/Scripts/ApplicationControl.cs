using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplicationControl : MonoBehaviour {

	public static ApplicationControl instance = null;


	void Awake(){

		if (instance == null) {
		
			instance = this;

		} else if (instance != this) {
		
			Destroy (gameObject);
		
		}

		DontDestroyOnLoad (this.gameObject);

	}


	public void StartSinglePlayer(){

		SceneManager.LoadScene("main");

	}

		


}
