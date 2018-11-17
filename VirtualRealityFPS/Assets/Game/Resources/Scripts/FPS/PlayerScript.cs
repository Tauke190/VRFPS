
using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour {

	[SerializeField]
	Behaviour[] Componentstodisable;


	void Start()
	{
		if (!isLocalPlayer) 
		{
			for (int i=0; i < Componentstodisable.Length; i++) 
			{
				Componentstodisable [i].enabled = false;
			}
		}
		else
		{
			Camera.main.gameObject.SetActive(false);
		}
	}
}
