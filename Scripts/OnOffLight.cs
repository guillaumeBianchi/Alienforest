using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(Collider))]
public class OnOffLight : MonoBehaviour {

	private Light my_light;
	private Collider my_collider;
	private bool is_on = true;

	void Start()
	{
		my_light = GetComponent<Light> ();
		my_collider = GetComponent<Collider> ();
	}

	void Update () {
		//Turning on/off the light
		if (Input.GetButtonDown ("Fire1")) 
		{
			//Debug.Log (is_on);
			is_on = !is_on;
			my_collider.enabled = is_on;
			my_light.enabled = is_on;
		}
	}
}
