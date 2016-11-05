using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

class MyManager : NetworkManager
{
    public GameObject prefabPlayer = null;
    public GameObject prefabAlien = null;

	public GameObject position_man = null;
	public GameObject position_alien = null;
    public bool first = true;

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Vector3 spawn_pos;
        GameObject prefab = null;

        if (first)
        {
            prefab = prefabPlayer;
            first = false;
			spawn_pos = position_man.transform.position;
        }
        else
        {
            prefab = prefabAlien;
			spawn_pos = position_alien.transform.position;
        }
        GameObject player = (GameObject)Instantiate(prefab, spawn_pos, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player, 0);
    }
}