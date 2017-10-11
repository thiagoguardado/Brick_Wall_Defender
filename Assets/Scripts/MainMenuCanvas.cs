using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvas : MonoBehaviour {

	public void StartSinglePlayer(){

		GameController.NewGame (1);

	}



	public void StartLocalMultiplayer(){

		GameController.NewGame (2);

	}


	public void StartLanMultiplayer(){

		SceneManager.LoadScene ("lanconfig");

	}
}
