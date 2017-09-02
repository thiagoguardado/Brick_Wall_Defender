using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour {

	public PlayerControl playerScrript;
	public Text collectiblesText;


	// Update is called once per frame
	void Update () {
		collectiblesText.text = playerScrript.colletiblesCount.ToString ();
	}
}
