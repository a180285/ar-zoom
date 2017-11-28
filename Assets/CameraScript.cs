using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

using System;
using System.Runtime.InteropServices;


public class CameraScript : MonoBehaviour {
	public WebCamTexture mCamera = null;

	// Use this for initialization
	void Start () {
		mCamera = new WebCamTexture (1920, 1080, 60);
		
		GetComponent<Renderer>().material.mainTexture = mCamera;
		mCamera.Play ();

	}
	
	// Update is called once per frame
	void Update () {

	}
}
