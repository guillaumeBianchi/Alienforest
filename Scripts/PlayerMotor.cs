using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

	[SerializeField]
	private Camera cam;
	
	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private Vector3 camera_rotation = Vector3.zero;

	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
	}

	//Gets a movement vector.
	public void Move(Vector3 _velocity)
	{
		velocity = _velocity;
	}

	//Gets a rotationnal vector.
	public void Rotate(Vector3 _rotation)
	{
		rotation = _rotation;
	}

	//Gets a rotationnal vector for the camera.
	public void RotateCamera (Vector3 _camera_rotation)
	{
		camera_rotation = _camera_rotation;
	}

	//Runs every physics interaction
	void FixedUpdate()
	{
		PerformMovement();
		PerformRotation();
	}

	void PerformMovement()
	{
		if (velocity != Vector3.zero) 
		{
			//Better than transform.translate because it stops if there is a collision.
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}
	}

	void PerformRotation()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler(rotation));
		if (cam != null)
		{
			cam.transform.Rotate (-camera_rotation);
		}
	}
}
