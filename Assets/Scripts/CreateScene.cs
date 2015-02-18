using UnityEngine;
using System.Collections;

public class CreateScene : MonoBehaviour {

	GameObject _gameManager;
	public int n_humans;
	public int n_ghosts;
	public GameObject ghost;
	public GameObject human;
	public GameObject doorIn;

	void Awake(){
		createHumans (n_humans);
		createGhosts (n_ghosts);
	}
	// Use this for initialization
	void Start () {
		_gameManager = GameObject.Find ("GameManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createGhosts(){
	
	}

	private void createHumans(int num){
		Vector3 pos = doorIn.transform.position;
		Vector3 aux = new Vector3(0.0f,0.0f,1.0f);
		pos = pos - aux * n_humans;
		for (int i=0; i<num; i++) {
			var aux_human = Instantiate (human, pos, Quaternion.identity) as GameObject;
			aux_human.AddComponent<HumanPlayer>();
			pos = pos + aux;
		}
	}

	private void createGhosts(int num){
		Vector3 pos= new Vector3(0.0f,0.0f,0.0f);
		for (int i=0; i<num; i++) {
			var aux_ghost = Instantiate (ghost, pos, Quaternion.identity) as GameObject;
			aux_ghost.AddComponent<GhostPlayer>();
		}
	}
}
