using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

	private LineRenderer laser;
	private Camera cam ;
	public LayerMask mask;

	// Use this for initialization
	void Start () 
	{
		cam = FindObjectOfType<Camera> ();
		laser = GetComponent<LineRenderer> ();
		if (cam == null)
		{
			Debug.LogError ("There is no fucking camera in the fucking game");
			this.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			Shoot ();

		}
	}

	void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, 100f, mask)) 
		{
			Debug.Log ("This fucking hit " +  hit.distance);
			Destroy (hit.transform.gameObject);

		}
	}
}
