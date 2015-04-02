using UnityEngine;
using System.Collections;

public class ObjectController : MonoBehaviour {

	GameObject _gameManager = null;
	public int idGhost = -1;
	Camera _ghostCamera;
	public bool asignado= false;

	// Use this for initialization
	void Start () {
		//_gameManager = GameObject.FindWithTag ("GameManager");
		//_ghostCamera = GameObject.FindWithTag ("GhostCamera").camera;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setAsignado(bool b) {asignado = b;}
	public bool getAsignado() {return asignado;}

	void OnMouseDown(){
		//Debug.Log ("mouse!!!");
		if (GameObject.FindWithTag ("GameState").GetComponent<GameState> ().getModeGame () != 2) {
			//Si estamos en un modo de juego donde utilicemos la camara ghost
			Ray ray = _ghostCamera.ScreenPointToRay (Input.mousePosition);
			if (idGhost == -1 && Physics.Raycast (ray) && !asignado) {
				//It's not a ghost inside me!!!!! A ghost is comming here!!!!!!
				//_gameManager.GetComponent<GameManager> ().moveGhostHere (transform.position);
				_gameManager.GetComponent<GameManager> ().moveGhostHere (gameObject);
				//asignado= true;
				//ghostIn (_gameManager.GetComponent<GameManager>().getGhostSelected());
			} else if (idGhost != -1) {
				//there is a ghost inside me!!! I want to select it!!!!
				_gameManager.GetComponent<GameManager> ().changeGhostSelected (idGhost);
			}
		}
	}

	public void initialize(){
		_gameManager = GameObject.FindWithTag ("GameManager");
		if (GameObject.FindWithTag("GameState").GetComponent<GameState>().getModeGame() != 2)
			//Si estamos en un modo de juego donde utilicemos la camara ghost
			_ghostCamera = GameObject.FindWithTag ("GhostCamera").camera;
		//Debug.Log (_gameManager);
	}

	public void ghostOut(int id){
		//Debug.Log ("Ghost out " + id + "    " + idGhost);
		if (idGhost == id){
			idGhost = -1;
			asignado = false;
		}
	}

	public void ghostIn(int id){
		idGhost = id;
		//Debug.Log ("ghost in: " + idGhost);
	}

	public int getidGhost(){
		return idGhost;
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
		//Debug.Log ("entra algo!!!!!"+other.gameObject.tag);
		if (other.gameObject.tag == "Ghost") {
			ghostIn (other.gameObject.GetComponent<GhostController> ().getId ());
		}
		if (other.gameObject.tag == "Human") {
			if (idGhost != -1){
				//_gameManager.GetComponent<GameManager> ().killHuman (other.gameObject);
				_gameManager.GetComponent<GameManager>().hurtHuman(other.gameObject);
				//Debug.Log ("humano que se choca!!!!");
			}
		}
	}
}
