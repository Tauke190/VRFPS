using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEquipSystem : MonoBehaviour {

    public Transform leftHand;
    public Transform rightHand;
    [Space(10)]
    public GameObject leftHandItem;
    public GameObject rightHandItem;
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

        GameObject leftHandSelection = leftHand.GetComponent<VR_equipDetector>().selectedObject;
        GameObject rightHandSelection = rightHand.GetComponent<VR_equipDetector>().selectedObject;



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
            Vector3 leftItemOffset = leftHandItem.transform.position - leftHandItem.GetComponent<itemHandler>().gripCollider.bounds.center;
            Vector3 leftHandMount = leftHand.GetComponent<VR_equipDetector>().gripCollider.bounds.center;


            leftHandItem.transform.position = leftHandMount + leftItemOffset;
            
            if (leftHandItem.transform.parent != leftHand)
            {
                leftHandItem.transform.rotation = Quaternion.identity;
                leftHandItem.transform.RotateAround(leftHandItem.transform.position, leftHandItem.transform.right, 54.213f);
            }

            leftHandItem.transform.parent = leftHand;


            gunonlefthand = true;

            leftHandItem.GetComponent<VRShoot>().enabled = true;
            leftHandItem.GetComponent<Lasergun>().enabled = true;
            leftHandItem.GetComponent<LineRenderer>().enabled = true;
            leftHandItem.GetComponent<Rigidbody>().isKinematic = true;
        }
        
        if (rightHandItem)
        {
            Vector3 rightItemOffset = rightHandItem.transform.position - rightHandItem.GetComponent<itemHandler>().gripCollider.bounds.center;
            Vector3 rightHandMount = rightHand.GetComponent<VR_equipDetector>().gripCollider.bounds.center;


            rightHandItem.transform.position = rightHandMount + rightItemOffset;

            if (rightHandItem.transform.parent != rightHand)
            {
                rightHandItem.transform.rotation = Quaternion.identity;
                rightHandItem.transform.RotateAround(rightHandItem.transform.position, rightHandItem.transform.right, 54.213f);
            }

            rightHandItem.transform.parent = rightHand;

            gunonrighthand = true;

            rightHandItem.GetComponent<VRShoot>().enabled = true;
            rightHandItem.GetComponent<Lasergun>().enabled = true;
            rightHandItem.GetComponent<LineRenderer>().enabled = true;
            rightHandItem.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
