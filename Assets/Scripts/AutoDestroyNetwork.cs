using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AutoDestroyNetwork : NetworkBehaviour {

	public float timeToDestroy;
	[SyncVar]
	private float timer = 0;


	void Update () {

		if(GameControllerNetwork.inGame){

			timer += Time.deltaTime;

			if (timer >= timeToDestroy) {
				DestroyThis ();
			}

		}

	}
	

	private void DestroyThis(){

		NetworkServer.Destroy (gameObject);

	}

}
