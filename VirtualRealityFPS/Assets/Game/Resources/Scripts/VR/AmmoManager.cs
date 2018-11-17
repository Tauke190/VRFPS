using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class AmmoManager : MonoBehaviour
{
	 
	private SteamVR_Controller.Device controller;
	private SteamVR_TrackedController trackedcontroller;
	private SteamVR_TrackedObject trackedobj;
	public int Magzinecapacity;
	public int ammo;
	public GameObject righthand;
	public GameObject lefthand;
	public GameObject lefthandwithmagzine;
	public GameObject lefthandwithmagzineused;
	public TextMesh Reloadmessage;
	public static bool canreload;


	// Use this for initialization
	void Start () 
	{
		trackedobj = GetComponentInParent<SteamVR_TrackedObject> ();
		trackedcontroller = GetComponentInParent<SteamVR_TrackedController> ();
		Magzinecapacity = 30;
		ammo = 60;
	}
	
	// Update is called once per frame
	void Update ()
	{

		controller = SteamVR_Controller.Input ((int)trackedobj.index);

		if (VRShoot.isshooting == true && Magzinecapacity > 0) 
		{
			Magzinecapacity--;
		}

		if (Magzinecapacity != 0) 
		{
			Reloadmessage.text = "";

		}

		if (Magzinecapacity == 0) 
		{
			Reloadmessage.text = "You gotta reload";
		}

		if (ammo == 0 && Magzinecapacity == 0) {
			canreload = false;
			Debug.Log ("Get Some ammo");
		} else 
		{
			canreload = true;

		}
		if (trackedcontroller.gripped)
		{
			if (canreload == true) 
			{
				lefthandwithmagzineused.SetActive (true);
			}
		}
	}



	void OnTriggerEnter(Collider col)
	{
		

		if (col.gameObject.tag == "HandActivation") 
		{
			lefthand.SetActive (true);
		}

	}
		
	public void Reload()
	{
		if (Magzinecapacity + ammo >= 30) {
			int ammotobefull = 30 - Magzinecapacity;
			Magzinecapacity += ammotobefull;
			ammo -= ammotobefull;
		} else 
		{
			Magzinecapacity += ammo;
			ammo -= ammo;

		}
	}

}
