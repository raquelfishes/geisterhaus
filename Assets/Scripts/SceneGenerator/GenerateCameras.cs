using UnityEngine;
using System.Collections;
public class GenerateCameras : MonoBehaviour {

	public GameObject humanCamera;
	private Vector3 positionCamera = new Vector3(6.5f,10.0f,-20.0f);
	private Quaternion rotationCamera = Quaternion.Euler(new Vector3(50.0f,0.0f,0.0f));
	public GameObject ghostCamera;

	void Awake() {
		instantiateCameras ();
	}

	// Use this for initialization
	void Start () {
		//instantiateCameras();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void instantiateCameras(){
		GameObject cam;
		cam=Instantiate(humanCamera,positionCamera,rotationCamera) as GameObject;
		cam=Instantiate(ghostCamera,positionCamera,rotationCamera) as GameObject;
	}
}
