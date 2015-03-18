using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	GameObject _gameManager = null;

	// Use this for initialization
	void Start () {
		_gameManager = GameObject.FindWithTag ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		_gameManager.GetComponent<GameManager>().addHumanOut();
		_gameManager.GetComponent<GameManager>().killHuman(other.gameObject);
	}
}
