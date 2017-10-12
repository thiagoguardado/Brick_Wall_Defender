using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ShotNetwork : NetworkBehaviour {

	public float speed = 4f;


	void Update () {
	
		if (GameControllerNetwork.inGame) {

			transform.Translate (Vector3.forward * speed * Time.deltaTime);

		}

	}

	public void Destroy(){

		NetworkServer.Destroy (gameObject);
	
	}
		
}
