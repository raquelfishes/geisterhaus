using UnityEngine;
using System.Collections;

public class HumanCamera : MonoBehaviour {

	Camera _humanCamera;

	// Use this for initialization
	void Start () {
		_humanCamera = gameObject.camera;
		GameObject[] ghost_objects = GameObject.FindGameObjectsWithTag("GhostObject");
		for (int i = 0; i < ghost_objects.Length; i++) {
			//Enmascarar eventos de raton en los objetos
			_humanCamera.eventMask = ~(1 << ghost_objects[i].layer);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
