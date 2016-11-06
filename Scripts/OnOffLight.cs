using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(Collider))]
public class OnOffLight : MonoBehaviour {

	private Light my_light;
	private Collider my_collider;
	private bool is_on = true;

	public GameObject respawn;

	void Start()
	{
		respawn = GameObject.FindGameObjectWithTag ("SpawnAlien");
		my_light = GetComponent<Light> ();
		my_collider = GetComponent<Collider> ();
	}

	void Update () {
		my_collider.enabled = is_on;
		my_light.enabled = is_on;
	}

	void OnTriggerStay(Collider collide_with)
	{
		if (collide_with.gameObject.tag == "Alien") 
		{
			if (collide_with.gameObject.GetComponent<ActionsAlien> ().moving == true) 
			{
				collide_with.gameObject.transform.position = respawn.transform.position;
			}
		}
	}
}
