using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanConfig : MonoBehaviour {

	public InputField ipInput;
	public InputField portInput;

	void Awake(){


		ipInput.placeholder.GetComponent<Text> ().text = Network.player.ipAddress;
		portInput.placeholder.GetComponent<Text> ().text = "8080";

	}


	public void StartHost(){

		string ip;
		string port;

		if (ipInput.text == "") {
			ip = ipInput.placeholder.GetComponent<Text> ().text;
		} else {
			ip = ipInput.text;
		}

		if (portInput.text == "") {
			port = portInput.placeholder.GetComponent<Text> ().text;
		} else {
			port = portInput.text;
		}

		MyNetworkManager.singleton.networkAddress = ip;
		MyNetworkManager.singleton.networkPort = int.Parse(port);

		GameControllerNetwork.NewNetworkGame ();

		MyNetworkManager.singleton.StartHost ();

	}


	public void StartClient(){

		string ip;
		string port;

		if (ipInput.text == "") {
			ip = ipInput.placeholder.GetComponent<Text> ().text;
		} else {
			ip = ipInput.text;
		}

		if (portInput.text == "") {
			port = portInput.placeholder.GetComponent<Text> ().text;
		} else {
			port = portInput.text;
		}

		MyNetworkManager.singleton.networkAddress = ip;
		MyNetworkManager.singleton.networkPort = int.Parse(port);

		GameControllerNetwork.LoadNetworkgame ();

		MyNetworkManager.singleton.StartClient ();


	}



}
