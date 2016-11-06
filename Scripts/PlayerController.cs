using UnityEngine;

//Dependency: A PlayerMotor component is attached to the gameobject w/e.
using System;


[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 10f;
	[SerializeField]
	private float max_speed = 20f;
	[SerializeField]
	private float look_sensitivity = 3f;
	private float normal_speed;

	private PlayerMotor motor;

	void Start()
	{
		normal_speed = speed;
		motor = GetComponent<PlayerMotor>();
	}

	void Update()
	{

		//Get inputs and calculate movement velocity as a 3D vector.
		float x_mov = Input.GetAxisRaw("Horizontal");
		float z_mov = Input.GetAxisRaw("Vertical");

		if (gameObject.tag == "Alien") 
		{
			if (x_mov > 0 || z_mov > 0) {
				gameObject.SendMessage ("isMoving", true);
			} 
			else 
			{
				gameObject.SendMessage ("isMoving", false);
			}

			if (Input.GetKey (KeyCode.LeftShift)) {
				speed = max_speed;
			} 
			else 
			{
				speed = normal_speed;
			}
		}

		//transform.right instead of Vector3.right because this one is local, we want the current rotation.
		Vector3 move_horizontal = transform.right * x_mov;
		Vector3 move_vertical = transform.forward * z_mov;

		// .normalized makes the length of the vector equal to one. (move_vertical + move_horizontal) > 1 because we add both. But we only want them to give us the direction.
		Vector3 velocity = (move_vertical + move_horizontal).normalized * speed;

		//Apply movement
		motor.Move (velocity);

		//Calculate rotation as a 3D vector. Only for turning around. Rotate around y axis because the up/down only have to affect the camera and not the entire player (It would mess up the movements).
		float y_rotation = Input.GetAxisRaw("Mouse X");

		Vector3 rotation = new Vector3 (0f,y_rotation,0f) * look_sensitivity;

		//Apply rotation
		motor.Rotate (rotation);

		//Calculate camera rotation.
		float x_rotation = Input.GetAxisRaw("Mouse Y");

		Vector3 camera_rotation = new Vector3 (x_rotation,0f,0f) * look_sensitivity;

		//Apply rotation
		motor.RotateCamera (camera_rotation);
	}
}
