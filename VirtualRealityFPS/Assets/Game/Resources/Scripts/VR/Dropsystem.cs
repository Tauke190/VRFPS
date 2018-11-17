using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropsystem : MonoBehaviour {


	public GameObject righthand;
	public GameObject lefthand;
	public GameObject Gunmodel;
	public GameObject M4;
	private SteamVR_TrackedController trackedcontroller;
	public Material handcolor;
	public GameObject lefthandMagzineused;

	private VRGrabbing vrgrabbing;

	private bool spawngunonce;
	// Use this for initialization
	void Start () 
	{
		vrgrabbing = GetComponentInChildren<VRGrabbing> ();
		trackedcontroller = GetComponent<SteamVR_TrackedController> ();

		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (trackedcontroller.padPressed)
		{
			
			if (VRGrabbing.havegun == true)
			{
				spawngunonce = true;
				righthand.SetActive (true);
				lefthandMagzineused.SetActive (false);

				lefthand.SetActive (true);
				if (spawngunonce == true) 
				{
					Instantiate (Gunmodel, transform.position, transform.rotation);
					spawngunonce = false;
				}
				M4.SetActive (false);
				VRGrabbing.havegun = false;

			}

		}
		
	}
}
