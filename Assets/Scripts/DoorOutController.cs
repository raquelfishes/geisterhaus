using UnityEngine;
using System.Collections;

public class DoorOutController : MonoBehaviour {

	GameObject _gameManager = null;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.FindWithTag ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		//me cargo al humano de la escena
		_gameManager.GetComponent<GameManager>().addHumanOut(other.gameObject);
		other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
		other.gameObject.GetComponent<Rigidbody>().active = false;
		_gameManager.GetComponent<GameManager>().killHuman(other.gameObject);
	}

	void OnTriggerExit (Collider other) {
		//me cargo al humano de la escena
		_gameManager.GetComponent<GameManager>().addHumanOut(other.gameObject);
		other.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
		other.gameObject.GetComponent<Rigidbody>().active = false;
		_gameManager.GetComponent<GameManager>().killHuman(other.gameObject);
	}
}
