using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

using System;
using System.Runtime.InteropServices;


public class CameraScript : MonoBehaviour {
	public WebCamTexture mCamera = null;

	private float gyroLimit = 0.5f;
	private float minZ = 2.4f;
	private float maxZ = 8;
	private float speed = 2.0f / 60;

	private int cnt = 0;

	// Use this for initialization
	void Start () {
		// Not work at all.
//		UnityEngine.XR.InputTracking.disablePositionalTracking = true;

		mCamera = new WebCamTexture (1920, 1080, 60);
		
		GetComponent<Renderer>().material.mainTexture = mCamera;
		mCamera.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		var gravity = Input.gyro.gravity;

		if (gravity.x < -gyroLimit) {
			float newz = transform.position.z - speed;
			if (newz > minZ) {
				transform.position = new Vector3(transform.position.x, transform.position.y, newz);
			}
		} else if (gravity.x > gyroLimit) {
			float newz = transform.position.z + speed;
			if (newz < maxZ) {
				transform.position = new Vector3(transform.position.x, transform.position.y, newz);
			}
		}
	}
}
