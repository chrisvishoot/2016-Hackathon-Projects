using UnityEngine;
using System.Collections;
using UnityEngine.VR;


public class VRAdjustment : MonoBehaviour {

	private Vector3 monitorRotation = new Vector3 (-12f, 0f, 0f);
	private Vector3 openVRPosition = new Vector3 (0f, -1.75f, 0f);

	// Use this for initialization
	void Awake () {
	
		// If there is no VR device, tilt camera upwards.
		if (!VRDevice.isPresent) {

			transform.localRotation = Quaternion.Euler (monitorRotation);
		} else {

			if (VRSettings.loadedDeviceName == "OpenVR") {
			
				transform.localPosition = openVRPosition;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyUp (KeyCode.R)) {
		
			InputTracking.Recenter ();
		} 
	}

	void OnApplicationQuit () {
	
		VRSettings.enabled = false;
	}
}
