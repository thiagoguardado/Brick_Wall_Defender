using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildenCollisionNetwork : MonoBehaviour {

	public PlayerControlNetwork parentControlScript;


	void OnCollisionEnter(Collision col){
	
		parentControlScript.CollisionWithChild(col);
	
	}

	void OnTriggerEnter(Collider col){

		parentControlScript.TriggerWithChild(col);

	}

}
