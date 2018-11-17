using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
	
	private Rigidbody rb ;
	private Vector3 velocity = Vector3.zero;
	private Vector3 Rotation = Vector3.zero;
	private Vector3 CamRotation = Vector3.zero;
	private Camera cam;
	[SerializeField]
	private float  jump= 5f;
	private bool isjumping;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		cam = GetComponentInChildren<Camera> ();
	}



	public void  Move( Vector3 _velocity)
	{
		velocity = _velocity;
	}
	public void  Rotate( Vector3 _Rotation)
	{
		Rotation = _Rotation;
	}
	public void  Rotatecam( Vector3 _Rotationcam)
	{
		CamRotation = _Rotationcam;
	}

	public void Jump()
	{
		if (isjumping == false) 
		{
			Vector3 jumpvec = Vector3.up * jump;
			rb.velocity = jumpvec;
			isjumping = true;
		}

	}

		
	// Update is called once per frame
	void FixedUpdate ()
	{
		PerformMovement ();
		PerformRotation ();
	}

	void PerformMovement()
	{
		if (velocity != Vector3.zero)
		{
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}

	}
	void PerformRotation()
	{
		if (Rotation!= Vector3.zero)
		{
			rb.MoveRotation (rb.rotation * Quaternion.Euler (Rotation));
			cam.transform.Rotate (CamRotation);
		}

	}


	void OnCollisionEnter()
	{
		isjumping = false;

	}
		


}
