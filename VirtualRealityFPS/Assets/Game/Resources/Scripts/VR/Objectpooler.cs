using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectpooler : MonoBehaviour {

	public static Objectpooler instance;
	public GameObject prefab;
	public List<GameObject> objpool;
	public int poolcount = 20;

	void Awake()
	{
		if (instance == null) 
		{
			instance = this;
		}

		objpool = new List<GameObject> ();
		for (int i = 0; i < poolcount; i++) 
		{
			GameObject obj = Instantiate (prefab);
			obj.SetActive (false);
			objpool.Add (obj);
	
		}
	}	
}
