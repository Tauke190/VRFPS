using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadUsedAmmo : MonoBehaviour {

	// Use this for initialization
	public GameObject righthand;
	public GameObject lefthand;
	public GameObject lefthandmagzineused;
	public AmmoManager ammomanger;
	void Start () 
	{
		
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Socket") 
		{
			ammomanger.Reload ();
			lefthandmagzineused.SetActive (false);
			AudioManager.PlayAudio ("Reload");

		}

	}

}
