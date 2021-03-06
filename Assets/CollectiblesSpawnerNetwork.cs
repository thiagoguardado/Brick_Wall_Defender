﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CollectiblesSpawnerNetwork : NetworkBehaviour {

	public Transform firstBrickPathExtent;
	private float spawnRadius;
	public GameObject collectible;
	[Range(0f,1f)]
	public float radiusPercentage;
	public float spawnRate;
	private float timer;

	public static CollectiblesSpawnerNetwork instancia;

	void Awake () {
		spawnRadius = radiusPercentage * firstBrickPathExtent.position.magnitude;
		timer = 0f;

		instancia = this;
	}

	// Update is called once per frame
	void Update () {


		if (GameControllerNetwork.inGame) {

			timer += Time.deltaTime;

			if (timer >= (1 / spawnRate)) {
				Spawn ();
				timer = 0f;
			}

		}

	}


	void Spawn(){

		Vector3 instPos = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
		instPos = instPos * (Random.Range(0,spawnRadius) / instPos.magnitude);
		float height = collectible.GetComponent<Renderer> ().bounds.extents.y / 2;
		instPos += new Vector3 (0, height, 0);

		GameObject go = Instantiate (collectible, instPos, Quaternion.identity);
		NetworkServer.Spawn (go);
	}
}
