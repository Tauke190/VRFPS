
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGrabbing : MonoBehaviour 
{

	[Tooltip("Right controller  of VR")]
	public GameObject Righthand;
	[Tooltip("Left controller  of VR")]
	public GameObject Lefthand;
	public GameObject handwithmagzine;

	public   Material handcoloronselect;
	public   Material handcolor;

	public GameObject M4;
	private SteamVR_TrackedController trackedcontroller;

	[HideInInspector]
	public  Renderer render;




	public static bool havegun;

	public  AmmoManager ammomanger;

	public TextMesh DebugMessage;



	// Use this for initialization
	void Start () 
	{
		render = GetComponentInChildren<Renderer> ();
		trackedcontroller = GetComponentInParent< SteamVR_TrackedController> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		
		
	}
	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Gun") 
		{
			render.sharedMaterial = handcoloronselect;

			if (trackedcontroller.gripped) {
				Righthand.SetActive (false);
				Lefthand.SetActive (false);
				M4.SetActive (true);
				Destroy (col.gameObject);
				havegun = true;
				AudioManager.PlayAudio ("Grab");
			}
		} 

		if (col.gameObject.tag == "Ammo")
		{
			render.sharedMaterial = handcoloronselect;
			if (trackedcontroller.gripped && M4.activeInHierarchy) 
			{
				Destroy (col.gameObject);
				Lefthand.SetActive (false);
				handwithmagzine.SetActive (true);
				AudioManager.PlayAudio ("Grab");


			} else 
			{
				if (trackedcontroller.gripped) 
				{

					DebugMessage.text = "You need to have a gun";
				}

			}


		}
		/*if (col.gameObject.tag == "Magzinesocket") 
		{
			ammomanger.ammo += 30;
			handwithmagzine.SetActive (false);
			Lefthand.SetActive (true);

		}
		*/

	}

	void OnTriggerExit(Collider col)
	{
		DebugMessage.text = "";
		render.sharedMaterial = handcolor;
		if (col.gameObject.tag == "HandActivation") 
		{
			if (M4.activeInHierarchy)
			{
				Lefthand.SetActive (false);
			}

		}
	}
}
