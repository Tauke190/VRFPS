using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour {




	private SteamVR_TrackedController trackcontroller;
	public GameObject M4;
	public SteamVR_TrackedObject trackeobj;
	private GameObject currentobj;

	// Use this for initialization
	void Start ()
	{
		trackcontroller = GetComponent<SteamVR_TrackedController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Spawngun ();
	}

	void Spawngun()
	{
		if (currentobj == null) 
		{
				currentobj = Instantiate (M4);
				currentobj.transform.parent = trackeobj.transform;
		}
	}
}
