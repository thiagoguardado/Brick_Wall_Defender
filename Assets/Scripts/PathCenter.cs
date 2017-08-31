using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCenter : MonoBehaviour {

	public int pathID;
	public float rotationSpeed;
	public float distanceFromCenter;
	public int numberOfBricks;
	public GameObject brick;


	// Use this for initialization
	void Awake() {


		for (int i = 0; i < numberOfBricks; i++) {

			Vector3 instPosition = transform.position + new Vector3(0,0,distanceFromCenter);
			GameObject go = Instantiate (brick, instPosition, Quaternion.identity, transform);
			go.transform.RotateAround(Vector3.zero,Vector3.up, 360 / (float)numberOfBricks * i);

		}

	}


	void Update(){
	
		transform.Rotate (Vector3.up, rotationSpeed * Time.deltaTime);
	
	}
	

}
