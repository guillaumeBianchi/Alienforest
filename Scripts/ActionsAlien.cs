using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class ActionsAlien : NetworkBehaviour {

	[SyncVar]
	public bool keyPressed;
	[SyncVar]
	public bool moving;
	[SyncVar]
	public bool isMetamorph = false;

	GameObject transformation;
	GameObject model;

	void Start()
	{
		transformation = GameObject.FindGameObjectWithTag ("Transformation");
		model = GameObject.FindGameObjectWithTag ("AlienModel");
	}
		

	void Update () {
		if (isLocalPlayer) 
		{
			if (Input.GetKey (KeyCode.E)) 
			{
				keyPressed = true;
			} 
			else 
			{
				keyPressed = false;
			}

			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				isMetamorph = !isMetamorph;
			} 
		}

		if (isMetamorph) {
			transformation.SetActive (true);
			model.SetActive (false);
		} 
		else 
		{
			transformation.SetActive (false);
			model.SetActive (true);
		}
	}

	void isMoving(bool move)
	{
		moving = move;
	}
}
