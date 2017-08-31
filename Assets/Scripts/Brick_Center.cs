using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_Center : MonoBehaviour {

	public int brickID;
	public float brickDistanceFromCenter;
	public GameObject brick;


	void Awake(){


		brick.transform.localPosition = new Vector3 (0, 0, brickDistanceFromCenter);

	}


}
