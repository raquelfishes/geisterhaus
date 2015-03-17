using UnityEngine;
using System.Collections;

public class GenerateCharacters : MonoBehaviour {

	public Vector3 positionFirstHuman = new Vector3 (0.0f, 1.0f, 0.0f);
	public GameObject ghost;
	public GameObject human;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void instantiateCharacters(int numHumans, int numGhosts){
		createHumans(numHumans);
		createGhosts(numGhosts);
	}

	private void createHumans(int num){
		Vector3 pos = positionFirstHuman;
		Vector3 aux = new Vector3(2.0f,0.0f,0.0f);
		//pos = pos - aux * num;
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
			aux_ghost.AddComponent<GhostController>();
		}
	}
}
