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
			//ghostIn (_gameManager.GetComponent<GameManager>().getGhostSelected());
		}
	}



	public void ghostOut(int id){
		Debug.Log ("Ghost out " + id + "    " + idGhost);
		if (idGhost == id)
			idGhost = -1;
	}

	public void ghostIn(int id){
		idGhost = id;
		Debug.Log ("ghost in: " + idGhost);
	}

	public Vector3 getPosition(){
		return transform.position;
	}
	/*
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Ghost") {
			Debug.Log ("Trigger Stay ghost");
			ghostIn (other.gameObject.GetComponent<GhostPlayer> ().getId ());
		}
	}
	*/

	void OnTriggerEnter (Collider other) {
		GameObject vida = GameObject.Find ("HealthBar");
		if (other.gameObject.tag == "Ghost") {
			ghostIn (other.gameObject.GetComponent<GhostController> ().getId ());
		}
		if (other.gameObject.tag == "Human") {
			if (idGhost != -1){
				//_gameManager.GetComponent<GameManager> ().killHuman (other.gameObject);
				_gameManager.GetComponent<GameManager>().hurtHuman(other.gameObject);
			}
		}
	}
}
