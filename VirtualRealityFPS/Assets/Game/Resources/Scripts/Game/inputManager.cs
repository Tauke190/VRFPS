using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class inputManager : MonoBehaviour 
{
    public enum viewPrefs { Headset, Monitor };
    public enum controlPrefs { KeyboardAndMouse, Joypad, HandControllers };

    public viewPrefs viewingPreferance = viewPrefs.Headset;
    public controlPrefs controllerPreferance = controlPrefs.HandControllers;

    public static int viewMode;
    public static int controlMode;

    public static bool detection_VRHeadset = false; //if a VR headset is detected or not
    public static bool detection_joystickController = false;
    public static bool detection_leftHandController = false;
    public static bool detection_rightHandController = false;

    void Awake()
    {
        viewMode = (int)viewingPreferance;
        controlMode = (int)controllerPreferance;

        DetectDevices();
    }

    void DetectDevices()
    {
        detection_VRHeadset = XRDevice.isPresent; //sets if a VR device is present or not


        string[] joystickNameList = Input.GetJoystickNames();

        if (joystickNameList.Length != 0)
        {
            for (int i = 0; i < joystickNameList.Length; i++)
            {
                switch (joystickNameList[0]) //checks primary name
                {
                    case "Controller (XBOX 360 For Windows)":
                        detection_joystickController = true; //detect xbox controller
                        break;


                    case "OpenVR Controller - Left":
                        detection_leftHandController = true;
                        break;

                    case "OpenVR Controller - Right":
                        detection_rightHandController = true;
                        break;
                }
            }
        }
    }
}
