using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {

	GameObject _gameManager = null;
	int idGhost = -1;
	Camera _ghostCamera;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find ("GameManager");
		_ghostCamera = GameObject.Find ("GhostCamera").camera;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Ray ray = _ghostCamera.ScreenPointToRay(Input.mousePosition);
		if (idGhost == -1 && Physics.Raycast(ray)) {
			_gameManager.GetComponent<GameManager>().moveGhostHere(transform.position);
			ghostIn (_gameManager.GetComponent<GameManager>().getGhostSelected());
		}
	}

	public void ghostOut(int id){
		Debug.Log ("Ghost out " + id + "    " + idGhost);
		if (idGhost == id)
			idGhost = -1;
	}

	public void ghostIn(int id){
		idGhost = id;
	}

	public Vector3 getPosition(){
		return transform.position;
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log ("trigger enter " + idGhost);
		if (idGhost != -1) {
			if (other.gameObject.tag == "Human") {
				_gameManager.GetComponent<GameManager> ().killHuman (other.gameObject);
				//Destroy (other.gameObject);
			}
		}
	}
}
