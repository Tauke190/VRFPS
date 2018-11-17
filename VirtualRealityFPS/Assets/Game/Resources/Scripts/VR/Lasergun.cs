using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Lasergun : MonoBehaviour {


	public Transform rayorigin;


	private LineRenderer laser;
	Ray ray;
	public float laserlimit = 50f;
	[SerializeField]
	LayerMask mask;
	public Vector3 laseroffset;


	// Use this for initialization
	void Start () 
	{
		
		laser = GetComponent<LineRenderer> ();	
	}

	// Update is called once per frame
	void Update () 
	{
		
		RaycastHit hit;
		if (Physics.Raycast(rayorigin.position, rayorigin.forward, out hit, 50f,mask))
		{
			ray.origin = rayorigin.position;
			ray.direction = rayorigin.forward;
			laser.SetPosition (0, rayorigin.position+laseroffset);
			laser.SetPosition (1,rayorigin.position + ray.direction * hit.distance);

		} else
		{
			ray.origin = rayorigin.position;
			ray.direction = rayorigin.forward;
			laser.SetPosition (0, rayorigin.position+laseroffset);
			laser.SetPosition (1, rayorigin.position + ray.direction * laserlimit);

		}
			
	}
}
