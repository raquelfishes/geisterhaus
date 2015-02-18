using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

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
		_gameManager.GetComponent<GameManager> ().addHumanCount ();
	}
}
