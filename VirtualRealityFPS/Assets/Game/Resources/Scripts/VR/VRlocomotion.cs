using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRlocomotion : MonoBehaviour
{

	public float speed;
	private Valve.VR.EVRButtonId VRtouchpad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

	[SerializeField]
	private Transform Rig;
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input ((int)trackedobject.index); } }
	private SteamVR_TrackedObject trackedobject;

	private Vector3 touchpadaxis = Vector3.zero;

	// Use this for initialization

	void Start ()
	{

		trackedobject = GetComponent<SteamVR_TrackedObject> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (controller == null) 
		{
			Debug.Log ("Controller not intiatelized");
			return;
		}
		var device = SteamVR_Controller.Input ((int)trackedobject.index);



		if (controller.GetTouch( VRtouchpad)) 
		{
			touchpadaxis = device.GetAxis (EVRButtonId.k_EButton_Axis0);
			if (Rig != null) 
			{
				Rig.position += ((transform.right * touchpadaxis.x + transform.forward * touchpadaxis.y).normalized) *Time.deltaTime*speed;
				Rig.position = new Vector3 (Rig.position.x, 0, Rig.position.z);


			}


		}

		
	}
}
