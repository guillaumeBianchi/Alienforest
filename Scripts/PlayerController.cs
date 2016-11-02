using UnityEngine;

//Dependency: A PlayerMotor component is attached to the gameobject w/e.
[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	private float speed = 10f;

	private PlayerMotor motor;

	void Start()
	{
		motor = GetComponent<PlayerMotor>();
	}

	void Update()
	{
		//Get inputs and calculate movement velocity as a 3D vector.
		float x_mov = Input.GetAxisRaw("Horizontal");
		float z_mov = Input.GetAxisRaw("Vertical");

		//transform.right instead of Vector3.right because this one is local, we want the current rotation.
		Vector3 move_horizontal = transform.right * x_mov;
		Vector3 move_vertical = transform.forward * z_mov;

		// .normalized makes the length of the vector equal to one. (move_vertical + move_horizontal) > 1 because we add both. But we only want them to give us the direction.
		Vector3 velocity = (move_vertical + move_horizontal).normalized * speed;

		motor.Move (velocity);
	}
}
