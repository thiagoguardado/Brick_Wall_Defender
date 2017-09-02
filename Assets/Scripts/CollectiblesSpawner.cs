using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesSpawner : MonoBehaviour {

	public Transform firstBrickPathExtent;
	private float spawnRadius;
	public GameObject collectible;
	[Range(0f,1f)]
	public float radiusPercentage;
	public float spawnRate;
	private float timer;


	void Awake () {
		spawnRadius = radiusPercentage * firstBrickPathExtent.position.magnitude;
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if (timer >= (1 / spawnRate)) {
			Spawn ();
			timer = 0f;
		}

	}


	void Spawn(){

		Vector3 instPos = new Vector3 (Random.Range (-1f, 1f), 0, Random.Range (-1f, 1f));
		instPos = instPos * (Random.Range(0,spawnRadius) / instPos.magnitude);
		float height = collectible.GetComponent<Renderer> ().bounds.extents.y / 2;
		instPos += new Vector3 (0, height, 0);

		Instantiate (collectible, instPos, Quaternion.identity);

	}
}
