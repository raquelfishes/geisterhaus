using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour {

	// Load game state in all scenes
	void Awake () {
		DontDestroyOnLoad(gameObject);
	}

	// Use this for initialization
	void Start () {
		Application.LoadLevel("MainMenu");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
