using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEquipSystem : MonoBehaviour {

    public Transform leftHand;
    public Transform rightHand;
    [Space(10)]
    public Transform leftHandItem;
    public Transform rightHandItem;
    [Space(10)]
    public Transform cameraRig;
	public static bool gunonlefthand;
	public static bool gunonrighthand;
	public GameObject[] guns;



	void Awake()
	{
		foreach (GameObject gun in guns)
		{
			gun.GetComponent<VRShoot> ().enabled = false;
			gun.GetComponent<Lasergun> ().enabled = false;
			gun.GetComponent<LineRenderer> ().enabled = false;

		}

	
		gunonlefthand = false;
		gunonrighthand = false;
	}

    void Update()
    {
        ManageEquipping();
    }

    void ManageEquipping()
    {
        switch (inputManager.controlMode)
        {
            case 0:
                ManageKeyboardEquipping();
                break;

            case 1:
                ManageJoypadEquipping();
                break;

            case 2:
                ManageHandEquipping();
                break;
        }
    }

    void ManageKeyboardEquipping()
    {

    }

    void ManageJoypadEquipping()
    {

    }

    void ManageHandEquipping()
    {
        Transform leftHandController = cameraRig.GetComponent<SteamVR_ControllerManager>().left.transform;
        Transform rightHandController = cameraRig.GetComponent<SteamVR_ControllerManager>().right.transform;

        SteamVR_TrackedController leftHandProperties = leftHandController.GetComponent<SteamVR_TrackedController>();
        SteamVR_TrackedController rightHandProperties = rightHandController.GetComponent<SteamVR_TrackedController>();


        Transform leftHandSelection = leftHand.GetComponent<VR_equipDetector>().selectedObject;
        Transform rightHandSelection = rightHand.GetComponent<VR_equipDetector>().selectedObject;




        if (leftHandProperties.gripped)
        {
            leftHandItem = leftHandSelection;



        }

        if (rightHandProperties.gripped)
        {
            rightHandItem = rightHandSelection;

        }


        if (leftHandItem)
        {
            Transform leftItemMount = leftHandSelection.GetComponent<itemHandler>().gripMount;

            leftHandItem.parent = leftHand;
            leftHandItem.localPosition = leftItemMount.localPosition;
            leftHandItem.localRotation = leftItemMount.localRotation;
			gunonlefthand = true;
			if (leftHand.GetComponent<VR_equipDetector> ().nameofthegun == guns [0].name) 
			{
				guns [0].GetComponent<VRShoot> ().enabled = true;
				guns [0].GetComponent<Lasergun> ().enabled = true;
				guns [0].GetComponent<LineRenderer> ().enabled = true;

			}
			if(leftHand.GetComponent<VR_equipDetector> ().nameofthegun == guns [1].name) 
			{
				guns [1].GetComponent<VRShoot> ().enabled = true;
				guns [1].GetComponent<Lasergun> ().enabled = true;
				guns [1].GetComponent<LineRenderer> ().enabled = true;

			}
		

        }

        if (rightHandItem)
        {
            Transform rightItemMount = rightHandSelection.GetComponent<itemHandler>().gripMount;

            rightHandItem.parent = rightHand;
            rightHandItem.localPosition = rightItemMount.localPosition;
			rightHandItem.localRotation = rightItemMount.localRotation;
			gunonrighthand = true;
			if (rightHand.GetComponent<VR_equipDetector> ().nameofthegun == guns [0].name) 
			{
				guns [0].GetComponent<VRShoot> ().enabled = true;
				guns [0].GetComponent<Lasergun> ().enabled = true;
				guns [0].GetComponent<LineRenderer> ().enabled = true;

			}
			if(rightHand.GetComponent<VR_equipDetector> ().nameofthegun == guns [1].name) 
			{
				guns [1].GetComponent<VRShoot> ().enabled = true;
				guns [1].GetComponent<Lasergun> ().enabled = true;
				guns [1].GetComponent<LineRenderer> ().enabled = true;

			}


		}
    }
}
