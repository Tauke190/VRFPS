using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class VRShoot : MonoBehaviour {


	public Transform rayorigin;
	public Transform handcontrollerright;
	public Transform handcontrollerleft;

	public static VRShoot instance;
	[Header("Decals Setting")]
	public GameObject decals;
	public List<GameObject> decalspool;
	public int decalpoolcount;




	[Header("BulletParticleSystemSetting")]
	public GameObject bulletparticlesystem;
	public List<GameObject> bulletparticlepool;
	public int bulletpoolcount;



	[Header("SmokeSetting")]
	public GameObject smoke;
	public List<GameObject> smokepool;
	public int smokepoolcount;



	public Transform guntip;
	private SteamVR_TrackedController trackcontroller;
	public SteamVR_Controller.Device controller;
	private SteamVR_TrackedObject trackedobject;
	private GameObject m4;


	public static bool isshooting;
	[SerializeField]
	private LayerMask mask;

	//public AmmoManager ammomanger;



	private Vector3 smokeoffset = new Vector3(0,0,0.1f);


	void Start()
	{
		trackcontroller = GetComponentInParent<SteamVR_TrackedController> ();
		trackedobject =  GetComponentInParent<SteamVR_TrackedObject> ();

	}


	void Awake()
		{
		if (instance == null) 
		{
			instance = this;
		}


	

		decalspool = new List<GameObject> ();
		for (int i = 0; i < decalpoolcount; i++) 
		{
			GameObject decalobj = Instantiate (decals);
			decalobj.SetActive (false);
			decalspool.Add (decalobj);

		}
		for (int i = 0; i < bulletpoolcount; i++) 
		{
			GameObject bulletobj = Instantiate (bulletparticlesystem);
			bulletobj.SetActive (false);
			bulletparticlepool.Add (bulletobj);

		}
		for (int i = 0; i < smokepoolcount; i++) 
		{
			GameObject smokeobj = Instantiate (smoke);
			smokeobj.SetActive (false);
			smokepool.Add(smokeobj);

		}
	}
	void Update () 
	{
		

		controller = SteamVR_Controller.Input ((int)trackedobject.index);



		//Single Shot 
		if (controller.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) && playerEquipSystem.gunonlefthand == true)
		{
			Shoot ();	
			//controller.TriggerHapticPulse (500);
		}
		if (controller.GetTouchDown (SteamVR_Controller.ButtonMask.Trigger) && playerEquipSystem.gunonrighthand == true) 
		{
			Shoot ();
	
		}
			//Burst Shot 
		/*if (trackcontroller.triggerPressed)) 
		{
			Shoot ();
		}
        */

		else 
		{
			isshooting = false;
		}

	}

      void Shoot()
	{
		RaycastHit hit;
		if (Physics.Raycast (rayorigin.position,rayorigin.forward, out hit, 100f, mask)) 
		{
			//Destroy (hit.transform.gameObject);
			//if (ammomanger.Magzinecapacity > 0) 
			//{
				GameObject Decalsused = GetDecalsofpool();
				Decalsused.transform.position = hit.point;
				Decalsused.transform.rotation = Quaternion.FromToRotation(Vector3.back, hit.normal);
				Decalsused.SetActive (true);
				if (Decalsused == null)
				{
					return;
				}
				GameObject bullet = GetBulletfromparticlesofpool ();
				bullet.transform.position = guntip.position;
				bullet.SetActive (true);
				if (bullet == null)
				{
					return;
				}
				isshooting = true;
				//controller.TriggerHapticPulse (1000);
				GameObject usedsmoke = GetSmokefromPool ();
				usedsmoke.transform.position = guntip.position + smokeoffset;
				usedsmoke.SetActive (true);
				if (usedsmoke == null)
				{
					return;
				}
				AudioManager.PlayAudio ("Shoot");
			//}
		}
	}


	public GameObject GetDecalsofpool()
	{
		for (int i = 0; i < decalspool.Count; i++) 
		{
			if (decalspool [i].activeInHierarchy == false) 
			{
				return decalspool [i];
			} 
		}
		return null;
	}
		

	public GameObject GetBulletfromparticlesofpool()
	{
		for (int i = 0; i < bulletparticlepool.Count; i++) 
		{
			if (bulletparticlepool [i].activeInHierarchy == false) 
			{
				return bulletparticlepool[i];
			}
		}

		return null;
	}



	public GameObject GetSmokefromPool()
	{
		for (int i = 0; i < smokepool.Count; i++) 
		{
			if (smokepool [i].activeInHierarchy == false) 
			{
				return smokepool [i];
			}
		}

		return null;
	}
		
}
