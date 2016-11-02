using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
	
	private Vector3 velocity = Vector3.zero;
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

	//Runs every physics interaction
	void FixedUpdate()
	{
		PerformMovement();
	}

	void PerformMovement()
	{
		if (velocity != Vector3.zero) 
		{
			//Better than transform.translate because it stops if there is a collision.
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}
	}
}
