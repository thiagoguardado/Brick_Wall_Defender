using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class GameControllerNetwork : NetworkBehaviour {

	public static GameControllerNetwork instancia;

	public static bool networkActive = false;

	public static bool started = false;
	public static bool ended = false;
	public static bool paused = false;

	public static int levelNumber;
	public static int numberPlayers;
	public static int previousNumberPlayers;

	public PostProcessingProfile inGameProfile;
	public PostProcessingProfile gameWinProfile;
	public PostProcessingProfile gameLoseProfile;

	public Text winText;
	public Text loseText;
	public Text levelNumberText;
	public Button nextLevelButton;
	public Button menuButton;


	public Transform maxRaycast;
	public Transform firstPathEnd;

	public AudioClip winclip;
	public AudioClip loseclip;
	private AudioSource audiosource;

	private static float first_enemyShotsPerSecond = 0.75f;
	private static float first_timer = 45f;
	private static float first_collectibleSpawnRate = 0.85f;

	public static float enemyShotsPerSecond;
	public static float timer;
	public static float collectibleSpawnRate;

	public float enemyShotsPerSecondIncreaseRate = 1.1f;
	public float timerIncreaseRate = 1f;
	public float collectibleSpawnRateIncreaseRate = 1.1f;


	public static bool inGame{
		get{ 
			if (started && !ended && !paused) {
				return true;
			} else {
				return false;
			}
		}
	}



	void Awake(){

		instancia = this;
		started = false;
		ended = false;

		audiosource = GetComponent<AudioSource> ();

		previousNumberPlayers = numberPlayers;

		enemyShotsPerSecond = first_enemyShotsPerSecond;
		collectibleSpawnRate = first_collectibleSpawnRate;

	}


	void Start(){
		
		InitialSetup ();

		StartLevel ();
	}


	void Update(){

//		if (!inGame && Input.GetButtonDown("Fire1")) {
//
//			StartLevel ();
//
//		}


	}


	public void StartLevel(){

		// set parameters
		started = true;
		ended = false;
		paused = false;

		// start timer
		GameObject.FindGameObjectWithTag ("Timer").GetComponent<LevelTimerNetwork> ().StartTimer ();

	}


	public void WinGame(){

		ended = true;

		audiosource.PlayOneShot (winclip);

		ChangeCameraProfile (instancia.gameWinProfile);

		winText.gameObject.SetActive(true);
		menuButton.gameObject.SetActive (true);
		nextLevelButton.gameObject.SetActive(true);

		EventSystem.current.SetSelectedGameObject (nextLevelButton.gameObject);

	}

	public void LoseGame(){

		ended = true;

		audiosource.PlayOneShot (loseclip);

		ChangeCameraProfile (instancia.gameLoseProfile);

		levelNumberText.text = "You reached level " + levelNumber.ToString ();
		levelNumberText.gameObject.SetActive (true);
		loseText.gameObject.SetActive (true);
		menuButton.gameObject.SetActive (true);

		EventSystem.current.SetSelectedGameObject (menuButton.gameObject);

	}


	void InitialSetup ()
	{

		winText.gameObject.SetActive (false);
		loseText.gameObject.SetActive (false);
		levelNumberText.gameObject.SetActive (false);
		menuButton.gameObject.SetActive (false);
		nextLevelButton.gameObject.SetActive (false);

		ChangeCameraProfile (inGameProfile);


		EnemyControlNetwork.instancia.shotsPerSecond = enemyShotsPerSecond;
		CollectiblesSpawnerNetwork.instancia.spawnRate = collectibleSpawnRate;


	}

	private static void ChangeCameraProfile(PostProcessingProfile profile){
	
		PostProcessingBehaviour ppb = Camera.main.gameObject.GetComponent<PostProcessingBehaviour> ();
		ppb.profile = profile;
	
	}


	public static void NewGame(int numberOfPlayers){

		numberPlayers = numberOfPlayers;

		float multiplier = 1f;

		if (numberPlayers > 1) {
			multiplier += (numberPlayers - 1) / 2;
		}
			
		enemyShotsPerSecond = first_enemyShotsPerSecond * multiplier;
		timer = first_timer;
		collectibleSpawnRate = first_collectibleSpawnRate * multiplier;

		levelNumber = 1;


	}

	public static void NewNetworkGame(){
	
		networkActive = true;

		numberPlayers = 1;

		enemyShotsPerSecond = first_enemyShotsPerSecond;
		collectibleSpawnRate = first_collectibleSpawnRate;

		levelNumber = 1;

	}


	public static void LoadNetworkgame(){
	
		networkActive = true;

		numberPlayers += 1;

		float multiplier = 1f;

		if (numberPlayers > 1) {
			multiplier += (numberPlayers - 1) / 2;
		}

//		EnemyControlNetwork.instancia.shotsPerSecond = first_enemyShotsPerSecond * multiplier;
//		CollectiblesSpawnerNetwork.instancia.spawnRate = first_collectibleSpawnRate * multiplier;

		levelNumber = 1;

	}


	public void NextLevelButton(){

		float playermult = (float)numberPlayers / (float)previousNumberPlayers;

		enemyShotsPerSecond = enemyShotsPerSecond * playermult * enemyShotsPerSecondIncreaseRate;
		timer = timer * playermult * timerIncreaseRate;
		collectibleSpawnRate = collectibleSpawnRate * playermult * collectibleSpawnRateIncreaseRate;

		levelNumber += 1;

		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);

	}



	public void MenuButton(){
	

		SceneManager.LoadScene ("Menu");

	}

	public static void AddPlayer(int number){

		numberPlayers += number;

		float multiplier = 1f;

		if (numberPlayers > 1) {
			multiplier += (numberPlayers - 1) / 2;
		}

//		EnemyControlNetwork.instancia.shotsPerSecond = first_enemyShotsPerSecond * multiplier;
//		CollectiblesSpawnerNetwork.instancia.spawnRate = first_collectibleSpawnRate * multiplier;

		levelNumber = 1;

	}



}
