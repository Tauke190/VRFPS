using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactive : MonoBehaviour {

	void OnEnable()
	{
		StartCoroutine ("setinactive");
	}



	IEnumerator setinactive()
	{
		while (true) 
		{
			yield return new WaitForSeconds (2f);
			gameObject.SetActive (false);
		}
	}
}
