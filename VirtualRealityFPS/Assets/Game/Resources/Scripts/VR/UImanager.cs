using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour {



	public TextMesh Magzine;
	public TextMesh Ammo;

	public AmmoManager ammomanager;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (VRGrabbing.havegun) {
			Magzine.text = "Magzine :" + ammomanager.Magzinecapacity.ToString ();
			Ammo.text = "Ammo : " + ammomanager.ammo.ToString ();
		} else 
		{
			
			Magzine.text = "";
			Ammo.text = "";
		}
	}
}
