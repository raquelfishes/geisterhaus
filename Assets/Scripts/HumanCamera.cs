﻿using UnityEngine;
using System.Collections;

public class GhostCamera : MonoBehaviour {

	Camera _humanCamera;

	// Use this for initialization
	void Start () {
		_humanCamera = GameObject.Find ("HumanCamera").camera;
		GameObject[] ghost_objects = GameObject.FindGameObjectsWithTag("GhostObject");
		for (int i = 0; i < ghost_objects.Length; i++) {
			_humanCamera.eventMask = ~(1 << ghost_objects[i].layer);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
