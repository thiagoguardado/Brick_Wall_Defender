using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

	public float timeToDestroy;
	private float timer = 0;


	void Update () {

		if(GameController.inGame){

			timer += Time.deltaTime;

			if (timer >= timeToDestroy) {
				DestroyThis ();
			}

		}

	}
	

	private void DestroyThis(){

		Destroy (gameObject);

	}

}
