using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class TouchedByAlien : NetworkBehaviour {

	[SyncVar]
	public bool alienPressedButton;
	[SyncVar]
	public bool alienIsClose;

	void Start () {
		alienPressedButton = false;
		alienIsClose = false;
	}

	void Update () {
		
		if (alienPressedButton && alienIsClose) 
		{
			print ("Finish: Man lost");
			SceneManager.LoadScene (0);
		}
	}

	void OnTriggerStay(Collider collide_with)
	{
		if (collide_with.gameObject.tag == "Alien") 
		{
			alienPressedButton = collide_with.gameObject.GetComponent<ActionsAlien> ().keyPressed;
			alienIsClose = true;
		}
	}

	void OnTriggerExit(Collider collide_with)
	{
		if (collide_with.gameObject.tag == "Alien") 
		{
			alienIsClose = false;
		}
	}
}
