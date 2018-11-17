using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	[SerializeField]
	[Range(1,10)]
	private float speed;
	[SerializeField]
	private float turnspeed;
	private PlayerMotor player_motor;


	// Use this for initialization
	void Start ()
	{ 
		player_motor = GetComponent<PlayerMotor>();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		float x_mov = Input.GetAxisRaw ("Horizontal");
		float z_mov = Input.GetAxisRaw ("Vertical");


		Vector3 movehorizontal = transform.right * x_mov;
		Vector3 movevertical = transform.forward * z_mov;

		//Final movement  
		Vector3 velocity = (movevertical + movehorizontal).normalized * speed;


		//Calculate Rotation 

		float y_rot = Input.GetAxisRaw ("Mouse X");

		Vector3 Rotation = new Vector3 (0.0f, y_rot, 0.0f) * turnspeed;



		//Calculate CameraRotaion

		float x_rot = Input.GetAxisRaw ("Mouse Y");
		Vector3 camRotation = new Vector3 (x_rot,0.0f, 0.0f) * turnspeed;


		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			player_motor.Jump ();
		}



		player_motor.Move(velocity);
		player_motor.Rotate (Rotation);
		player_motor.Rotatecam (-camRotation);

	}
	void OnCollisionEnter()
	{
		
	}
}
