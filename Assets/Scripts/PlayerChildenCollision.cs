using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildenCollision : MonoBehaviour {

	public PlayerControl parentControlScript;


	void OnCollisionEnter(Collision col){
	
		parentControlScript.CollisionWithChild(col);
	
	}

	void OnTriggerEnter(Collider col){

		parentControlScript.TriggerWithChild(col);

	}

}
