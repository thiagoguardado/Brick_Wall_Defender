using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MyNetworkManager : NetworkManager {



	public override void OnClientConnect(NetworkConnection conn)
	{
		Debug.Log("MyNetworkManager::OnClientConnect("+conn+")");

		base.OnClientConnect(conn);

		GameController.AddPlayer (1);

	}


	public override void OnClientDisconnect(NetworkConnection conn)
	{
		Debug.Log("MyNetworkManager::OnClientDisconnect("+conn+")");

		base.OnClientDisconnect(conn);

		GameController.AddPlayer (-1);

	}



}
