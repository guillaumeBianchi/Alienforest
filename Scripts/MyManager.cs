using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

class MyManager : NetworkManager
{
    public GameObject prefabPlayer = null;
    public GameObject prefabAlien = null;
    public bool first = true;

 

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Vector3 spawn_pos;
        GameObject prefab = null;

        if (first)
        {
            prefab = prefabPlayer;
            first = false;
            spawn_pos = new Vector3(0, 0, -5);
        }
        else
        {
            prefab = prefabAlien;
            playerControllerId += 1;
            spawn_pos = new Vector3(0, 0, 5);
        }
        GameObject player = (GameObject)Instantiate(prefab, spawn_pos, Quaternion.identity);

        //GameObject player = (GameObject)Instantiate(playerPrefab, spawn_pos, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, 0);
    }
}