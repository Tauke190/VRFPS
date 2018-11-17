using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAmmunition : MonoBehaviour {


	public GameObject righthand;
	public GameObject lefthand;
	public GameObject lefthandwithmagzine;
	public AmmoManager ammomanger;
	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col ) 
	{
		if (col.gameObject.tag == "Socket") 
		{
			ammomanger.ammo += 30;
			lefthandwithmagzine.SetActive (false);
			lefthand.SetActive (true);
			AudioManager.PlayAudio ("Reload");

		}
			
		
	}
}
