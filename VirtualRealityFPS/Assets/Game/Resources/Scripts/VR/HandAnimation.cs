using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimation : MonoBehaviour {

	private Animator _anim;
	private SteamVR_TrackedController trackedcontroller;

	// Use this for initialization
	void Start ()
	{
		_anim = GetComponentInChildren<Animator>();
		trackedcontroller = GetComponentInParent<SteamVR_TrackedController>();
	}

	// Update is called once per frame
	void Update ()
	{
        //if we are pressing grab, set animator bool IsGrabbing to true
        if (trackedcontroller.gripped)
        {

            if (!_anim.GetBool("Isgrabbing"))
            {
                _anim.SetBool("Isgrabbing", true);
            }
        }
        else
        {
            //if we let go of grab, set IsGrabbing to false
            if (_anim.GetBool("Isgrabbing"))
            {
                _anim.SetBool("Isgrabbing", false);
            }
        }
    }
}
