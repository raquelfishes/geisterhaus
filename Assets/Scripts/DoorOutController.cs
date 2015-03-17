using UnityEngine;
using System.Collections;

public class DoorOutController : MonoBehaviour {

	GameObject _gameManager = null;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		Debug.Log ("trigger enter " + other.gameObject.tag);
		//Open door
		_gameManager.GetComponent<GameManager>().addHumanOut();
	}

	void OnTriggerExit (Collider other) {
		//me cargo al humano de la escena
		_gameManager.GetComponent<GameManager>().removeHumanScene(other.gameObject);
	}
}
