using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ActionsAlien : NetworkBehaviour {

	[SyncVar]
	public bool keyPressed;
	[SyncVar]
	public bool moving;

	void Update () {
		if (Input.GetKey (KeyCode.E)) 
		{
			keyPressed = true;
		} 
		else 
		{
			keyPressed = false;
		}
	}

	void isMoving(bool move)
	{
		moving = move;
	}
}
