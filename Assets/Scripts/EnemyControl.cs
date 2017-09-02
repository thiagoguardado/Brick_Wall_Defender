using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

	public Transform nose;
	public GameObject shot;
	public float speed;
	public float shotsPerSecond;
	private float shotTimer = 0f;

	void Update(){
	
		Rotate ();

		CalculateShot ();


	}

	void Rotate ()
	{
		transform.Rotate (Vector3.up, speed * Time.deltaTime);
	}

	private void KeepAligned(){
		transform.LookAt (Vector3.zero);
	}

	void CalculateShot ()
	{
		shotTimer += Time.deltaTime;

		if (shotTimer >= 1 / shotsPerSecond) {
		
			Shot ();
			shotTimer = 0f;
		
		}
	}

	private void Shot(){


	
		Instantiate (shot, nose.position, transform.rotation);
	
	}


}
