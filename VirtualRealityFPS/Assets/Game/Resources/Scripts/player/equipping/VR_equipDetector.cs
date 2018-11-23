using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_equipDetector : MonoBehaviour {

    public GameObject selectedObject;
    public Collider gripCollider;
	[HideInInspector]
	public  string nameofthegun;

    void OnTriggerStay(Collider detectedCollision)
    {
        selectedObject = detectedCollision.gameObject;
		nameofthegun = detectedCollision.gameObject.name;
    }
}
