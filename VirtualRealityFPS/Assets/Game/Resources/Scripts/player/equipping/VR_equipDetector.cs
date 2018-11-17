using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_equipDetector : MonoBehaviour {

    public Transform selectedObject;
	[HideInInspector]
	public  string nameofthegun;

    void OnTriggerStay(Collider detectedCollision)
    {
        selectedObject = detectedCollision.gameObject.transform;
		nameofthegun = detectedCollision.gameObject.name;

    }
}
