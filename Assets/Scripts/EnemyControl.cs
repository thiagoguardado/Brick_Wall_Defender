using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

	public Transform nose;
	public GameObject shot;
	public float shotsPerSecond;
	public float shotFreqMultiplierPerSecond;
	private float shotTimer = 0f;

	private float rotationTimer;
	private Quaternion nextRotation;
	private Quaternion lastRotation;
	private float nextRotationDuration;

	public AudioSource audiosource;

	public static EnemyControl instancia;

	void Awake(){

		// raffle next position
		RaffleRotation();

		// instance
		instancia = this;

	}


	void Update(){
	
		if (GameController.inGame) {

			Rotate ();

			CalculateShotFrequency ();

		}


	}




	void RaffleRotation ()
	{
		lastRotation = transform.rotation;
		nextRotation = Quaternion.Euler (0, Random.Range (0f, 360f), 0);
		nextRotationDuration = 1 / shotsPerSecond;
		rotationTimer = 0f;
	}



	void Rotate ()
	{

		rotationTimer += Time.deltaTime;

		if (rotationTimer <= nextRotationDuration) {

			transform.rotation = Quaternion.Lerp (lastRotation, nextRotation, rotationTimer / nextRotationDuration);

		} else {
		
			Shot ();

			RaffleRotation ();
		
		}
			
	}


	void CalculateShotFrequency ()
	{
		shotTimer += Time.deltaTime;

		if (shotTimer >= 1) {
		
			shotsPerSecond *= shotFreqMultiplierPerSecond;

			shotTimer = 0f;
		
		}
	}


	private void Shot(){

		Instantiate (shot, nose.position, transform.rotation);
		audiosource.Play ();
	
	}


}
