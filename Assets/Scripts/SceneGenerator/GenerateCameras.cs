using UnityEngine;
using System.Collections;

public class GenerateCameras : MonoBehaviour {

	public GameObject humanCamera;
	public Vector3 positionCamera = new Vector3(6.5f,5.5f,-25f);
	public Quaternion rotationCamera = Quaternion.identity;
	public GameObject ghostCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void instantiateCameras(){
		GameObject go;
		go=Instantiate(humanCamera,positionCamera,rotationCamera) as GameObject;
		go=Instantiate(ghostCamera,positionCamera,rotationCamera) as GameObject;
	}
}
